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

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class Alta : Form
    {
        private SqlConnection sqlCon = null;

        public Alta()
        {
            InitializeComponent();
        }

        public Alta(SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;
        }

        private bool existeNombreDeUsuario()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.USUARIO WHERE ";
            cmd.CommandText += "USR_NOMBRE = '" + textBox_usuario.Text + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                //libero
                cmd.Dispose();
                //existe
                return true;
            }
            else
            {
                //libero
                cmd.Dispose();
                //no existe
                return false;
            }
        }

        private String encriptarSHA256(String str)
        {
            SHA256Managed hashManaged = new SHA256Managed();

            byte[] hash = hashManaged.ComputeHash(Encoding.Unicode.GetBytes(str));

            return BitConverter.ToString(hash);
        }

        private void insertarUsuario()
        {
            //inserto usuario
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.USUARIO (USR_NOMBRE,USR_CONTRASEÑA,USR_PREGUNTA,USR_RESPUESTA,USR_HABILITADO,USR_ELIMINADO,USR_INTENTOS_FALLIDOS,USR_FECHA_CREACION) ";
            cmd.CommandText += "VALUES('" + textBox_usuario.Text + "',";
            cmd.CommandText += "'" + encriptarSHA256(textBox_psw.Text) + "',";
            cmd.CommandText += "'" + textBox_pregunta.Text + "',";
            cmd.CommandText += "'" + encriptarSHA256(textBox_respuesta.Text) + "',1,0,0,";
            cmd.CommandText += "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + ")";

            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla USUARIO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return;
            }

            //inserto rol cliente
            cmd.CommandText = "INSERT INTO NETSTLE.ROLXUSUARIO (ROLUSR_NOMBRE,ROLUSR_NOMBRE_USUARIO) VALUES('CLIENTE','" + textBox_usuario.Text + "')";

            //ejecuto
            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla ROLXUSUARIO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return;
            }

            //libero
            cmd.Dispose();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_usuario.Text == "")
            {
                errorProvider_usr.SetError(textBox_usuario, "Por favor ingrese el nombre de usuario.");
                vacio = true;
            }

            if (textBox_psw.Text == "")
            {
                errorProvider_psw.SetError(textBox_psw, "Por favor ingrese la contraseña.");
                vacio = true;
            }

            if (textBox_pregunta.Text == "")
            {
                errorProvider_pregunta.SetError(textBox_pregunta, "Por favor ingrese la pregunta.");
                vacio = true;
            }

            if (textBox_respuesta.Text == "")
            {
                errorProvider_respuesta.SetError(textBox_respuesta, "Por favor ingrese la respuesta.");
                vacio = true;
            }

            //me las tomo?
            if (vacio) return;

            if (existeNombreDeUsuario())
            {
                MessageBox.Show("Ya existe ese nombre de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //nuevo
                insertarUsuario();
                //se creo nuevo usuario
                MessageBox.Show("Se ha creado un nuevo usuario.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox_usuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider_usr.Clear();
        }

        private void textBox_psw_TextChanged(object sender, EventArgs e)
        {
            errorProvider_psw.Clear();
        }

        private void textBox_pregunta_TextChanged(object sender, EventArgs e)
        {
            errorProvider_pregunta.Clear();
        }

        private void textBox_respuesta_TextChanged(object sender, EventArgs e)
        {
            errorProvider_respuesta.Clear();
        }
    }
}
