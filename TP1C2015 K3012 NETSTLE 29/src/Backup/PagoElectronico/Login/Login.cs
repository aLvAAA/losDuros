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

namespace PagoElectronico.Login
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

        private void textBox_usr_TextChanged(object sender, EventArgs e)
        {
            error_text1.Clear();
        }

        private void textBox_psw_TextChanged(object sender, EventArgs e)
        {
            error_text2.Clear();
        }

        private void frm_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = existeUsr && usrRol != null? DialogResult.Yes : DialogResult.No;
        }

        void borrarIntentosFallidos()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.USUARIO ";
            cmd.CommandText += "SET USR_INTENTOS_FALLIDOS = 0 ";
            cmd.CommandText += "WHERE USR_NOMBRE = '" + textBox_usr.Text + "'";
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

        private int intentosFallidos()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT USR_INTENTOS_FALLIDOS FROM NETSTLE.USUARIO ";
            cmd.CommandText += "WHERE USR_NOMBRE = '" + textBox_usr.Text + "'";
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

                    cmd.CommandText = "UPDATE NETSTLE.USUARIO ";
                    cmd.CommandText += "SET USR_INTENTOS_FALLIDOS = " + (cantIntentosFallidos + 1) + " ";
                    cmd.CommandText += "WHERE USR_NOMBRE = '" + textBox_usr.Text + "'";
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
                        cmd.CommandText = "UPDATE NETSTLE.USUARIO ";
                        cmd.CommandText += "SET USR_HABILITADO = 0 ";
                        cmd.CommandText += "WHERE USR_NOMBRE = '" + textBox_usr.Text + "'";

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

        void actualizarTablaAuditoria(bool fallo)
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO NETSTLE.AUDITORIA (AUD_NOMBRE_USUARIO,AUD_ESTADO,AUD_FECHA_HORA)";
            cmd.CommandText += "VALUES('" + textBox_usr.Text + "','" + (fallo ? "FALLO" : "EXITO") + "',";
            cmd.CommandText += "GETDATE())";
            cmd.Connection = sqlCon;

            //ejecuto
            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla AUDITORIA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //libero
            cmd.Dispose();
        }

        private bool existeUsuario()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.USUARIO WHERE ";
            cmd.CommandText += "USR_NOMBRE = '" + textBox_usr.Text + "' ";
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

        private String encriptarSHA256(String str)
        {
            SHA256Managed hashManaged= new SHA256Managed();

            byte[] hash = hashManaged.ComputeHash(Encoding.Unicode.GetBytes(str));

            return BitConverter.ToString(hash);
        }

        private bool contraseñaCorrecta()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.USUARIO WHERE ";
            cmd.CommandText += "USR_NOMBRE = '" + textBox_usr.Text + "' ";
            cmd.CommandText += "AND USR_CONTRASEÑA = '" + encriptarSHA256(textBox_psw.Text) + "' ";
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

        private bool usuarioHabilitado()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.USUARIO WHERE ";
            cmd.CommandText += "USR_NOMBRE = '" + textBox_usr.Text + "' ";
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

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_usr.Text.Length == 0)
            {
                error_text1.SetError (textBox_usr, "Por favor escriba el nombre de usuario.");
                vacio = true;
            }

            if (textBox_psw.Text.Length == 0)
            {
                error_text2.SetError(textBox_psw, "Por favor escriba la contraseña.");
                vacio= true;
            }

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
                            actualizarTablaAuditoria(false);
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
                        actualizarTablaAuditoria(true);
                        //el usuario ingreso mal la contraseña, incremento en uno los intentos fallidos e inhabilito si paso los 3
                        incrementarIntentosFallidos(); 
                    }
                }
            }
        }

        private void textBox_psw_Enter(object sender, EventArgs e)
        {
            //apretar enter en el textobox contraseña equivale a hacer clilc en ingresar
            ActiveForm.AcceptButton = btn_ingresar;
        }

        public String GetUsuario()
        {
            return usrString;
        }

        public String GetRolUsuario()
        {
            return usrRol;
        }

        private void btn_registrarse_Click(object sender, EventArgs e)
        {
            ABM_de_Usuario.Alta frmAlta = new ABM_de_Usuario.Alta(sqlCon);

            frmAlta.ShowDialog();

            frmAlta.Dispose();
        }
    }
}
