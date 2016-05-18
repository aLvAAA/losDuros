using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;

namespace WindowsFormsApplication1.Login
{
    public partial class frm_login : Form
    {

        private SqlConnection sqlCon = null;

        private bool existeUsr = false;

        private String usrString = null;

        private String usrRol = null;

         public frm_login()
        {
            InitializeComponent();
        }

         public frm_login(SqlConnection sqlCon):this()
         {
             this.sqlCon = sqlCon;
         }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (vacio) return;

            if (existeUsuario())
            {
                if (contraseñaCorrecta())
                {
                    if (usuarioHabilitado())
                    {
                        //creo instancia de nueva ventana
                        SeleccionRol frmRol = new SeleccionRol(sqlCon, textBox_usr.Text);

                        //muestro para que el usuario seleccione el rol
                        if (frmRol._ShowDialog() == DialogResult.Yes)
                        {
                            //recupero rol del formulario seleccion rol
                            usrRol = frmRol.getRol();

                            //seteo para que retorne con exito
                            existeUsr = true;
                            //seteo nombre de ususrio para luego recuperarlo desdes del form padre
                            usrString = textBox_usr.Text;
                            //actualizo la tabla auditoria
                          
                            //borro
                            borrarIntentosFallidos();

                            //cierro
                            this.Close();
                        }
                        //else
                        //{
                        //    //el usuario no seleccion o no tiene rol habilitado para mostrar
                        //}

                        //libero
                        frmRol.Dispose();
                    }
                }
                else
                {
                    //el usuario escribio mal la contraseña y ademas esta habilitado, se deberia registrar un intento fallido en la tabla auditoria
                    if (usuarioHabilitado())
                    {
                        
                        //el usuario ingreso mal la contraseña, incremento en uno los intentos fallidos e inhabilito si paso los 3
                        incrementarIntentosFallidos();
                    }
                }
            }


        }
       

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        //Usuario
        private bool existeUsuario()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM dbo.USUARIO WHERE ";
            cmd.CommandText += "usr_name = '" + textBox_usr.Text + "' ";
            cmd.CommandText += "AND USR_ELIMINADO = 0";
            cmd.Connection = sqlCon;

            if ((Int32)cmd.ExecuteScalar() < 1)
            {
                MessageBox.Show("El usuario " + textBox_usr.Text + " no existe.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //libero
            cmd.Dispose();
            return true;
        }

        private bool usuarioHabilitado()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM dbo.USUARIO WHERE ";
            cmd.CommandText += "usr_name = '" + textBox_usr.Text + "' ";
            cmd.CommandText += "AND USR_HABILITADO = 1";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() < 1)
            {
                MessageBox.Show("El usuario se ha inhabilitado, contactese con el administrador.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //libero
            cmd.Dispose();
            return true;
        }


        // Intentos Fallidos
        private int intentosFallidos()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT USR_INTENTOS_FALLIDOS FROM dbo.USUARIO ";
            cmd.CommandText += "WHERE USR_name = '" + textBox_usr.Text + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                //recupero
                int cant = reader.GetInt32(0);
                //libero
                reader.Close();
                //libero
                cmd.Dispose();
                //exito
                return cant;
            }
            else
            {
                //libero
                reader.Close();
                //libero
                cmd.Dispose();
                //fallo
                MessageBox.Show("Error al leer el campo USR_INTENTOS_FALLIDOS en la tabla USUARIO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        void incrementarIntentosFallidos()
        {
            Int32 cantIntentosFallidos = 0;
            //recupero los intentos fallidos
            if ((cantIntentosFallidos = intentosFallidos()) != -1)
            {
                if (cantIntentosFallidos < 3)
                {
                    //consula sql
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "UPDATE dbo.USUARIO ";
                    cmd.CommandText += "SET USR_INTENTOS_FALLIDOS = " + (cantIntentosFallidos + 1) + " ";
                    cmd.CommandText += "WHERE usr_name = '" + textBox_usr.Text + "'";
                    cmd.Connection = sqlCon;

                    //ejecuto
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        //fallo
                        MessageBox.Show("Error al actualizar el campo USR_INTENTOS_FALLIDOS de tabla USUARIO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (cantIntentosFallidos > 1)
                    {
                        //inhabilito
                        cmd.CommandText = "UPDATE dbo.USUARIO ";
                        cmd.CommandText += "SET USR_HABILITADO = 0 ";
                        cmd.CommandText += "WHERE usr_name = '" + textBox_usr.Text + "'";

                        //ejecuto
                        if (cmd.ExecuteNonQuery() < 1)
                        {
                            //fallo
                            MessageBox.Show("Error al actualizar el campo USR_HABILITADO de tabla USUARIO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //libero
                    cmd.Dispose();
                }
            }
        }

        void borrarIntentosFallidos()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE dbo.USUARIO ";
            cmd.CommandText += "SET USR_INTENTOS_FALLIDOS = 0 ";
            cmd.CommandText += "WHERE usr_name = '" + textBox_usr.Text + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al actualizar el campo USR_INTENTOS_FALLIDOS de tabla USUARIO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //libero
            cmd.Dispose();
        }


        //Contraseña
        private String encriptarSHA256(String str)
        {
            SHA256Managed hashManaged = new SHA256Managed();

            byte[] hash = hashManaged.ComputeHash(Encoding.Unicode.GetBytes(str));

            return BitConverter.ToString(hash);
        }

        private bool contraseñaCorrecta()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM dbo.USUARIO WHERE ";
            cmd.CommandText += "usr_name = '" + textBox_usr.Text + "' ";
            cmd.CommandText += "AND usr_contraseña = '" + textBox_psw.Text + "' ";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() < 1)
            {
                MessageBox.Show("Contraseña invalida para el usuario " + textBox_usr.Text, "Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //libero
            cmd.Dispose();
            return true;
        }

      
        
    }
}
