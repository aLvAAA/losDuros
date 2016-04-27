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

namespace PagoElectronico.ABM_Cliente
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

            //cargo paises en combobox pais
            cargarPaises(comboBox_pais);

            //cargo paises en combobox nacionalidad
            cargarPaises(comboBox_nacionalidad);

            //cargo los tipos de documentos
            cargarTipoDocumentos();
        }

        private void cargarPaises(ComboBox comboBox)
        {
            //limpio por las dudas
            comboBox.Items.Clear();

            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT PAIS_NOMBRE FROM NETSTLE.PAIS";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox.Items.Add(reader.GetString(0));
                }

                comboBox.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void cargarTipoDocumentos()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TIPO_DOCUMENTO FROM NETSTLE.TIPODOCUMENTO";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox_tipoDoc.Items.Add(reader.GetString(0));
                }

                comboBox_tipoDoc.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void button_fecha_Click(object sender, EventArgs e)
        {
            //nueva instancia
            Calendario frmCal = new Calendario();

            //muestro
            if (frmCal.ShowDialog() == DialogResult.Yes)
            {
                DateTime time = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

                if (frmCal.getFechaDateTime() < time)
                {
                    //recupero fecha
                    textBox_fecha.Text = frmCal.getFecha();
                    errorProvider_fecha.Clear();
                }
                else
                {
                    // no pudistes haber nacido mañana
                    MessageBox.Show("No es una fecha valida.", "Fecha De Nacimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //libero
            frmCal.Dispose();  
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

        private bool existeCliente()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CLIENTE WHERE ";
            cmd.CommandText += "CLI_NRO_DOCUMENTO = " + textBox_nroDoc.Text + " AND ";
            cmd.CommandText += "CLI_TIPO_DOCUMENTO = '" + comboBox_tipoDoc.GetItemText(comboBox_tipoDoc.SelectedItem) + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("Ya existe un cliente con el mismo tipo y numero de documento.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private bool existeMail()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CLIENTE WHERE ";
            cmd.CommandText += "UPPER(CLI_MAIL) LIKE UPPER('%" + textBox_mail.Text + "%')";
           
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("Ya existe un cliente registrado con ese e-mail.", "E-Mail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void insertarCliente()
        {
            //inserto usuario
            SqlCommand cmd = new SqlCommand();
            
            //inserto cliente
            cmd.CommandText = "INSERT INTO NETSTLE.CLIENTE (CLI_NRO_DOCUMENTO,CLI_TIPO_DOCUMENTO,CLI_NOMBRE_USUARIO,CLI_NOMBRE,CLI_APELLIDO,CLI_PAIS,CLI_MAIL,CLI_FECHA_NACIMIENTO,CLI_DOM_CALLE,CLI_DOM_NRO,CLI_NACIONALIDAD,CLI_LOCALIDAD,CLI_ELIMINADO) ";
            cmd.CommandText += "VALUES (" + textBox_nroDoc.Text + ",";
            cmd.CommandText += "'" + comboBox_tipoDoc.GetItemText(comboBox_tipoDoc.SelectedItem) + "',";
            cmd.CommandText += "'" + textBox_usuario.Text + "',";
            cmd.CommandText += "'" + textBox_nombre.Text + "',";
            cmd.CommandText += "'" + textBox_apellido.Text + "',";
            cmd.CommandText += "'" + comboBox_pais.GetItemText(comboBox_pais.SelectedItem) + "',";
            cmd.CommandText += "'" + textBox_mail.Text + "',";
            cmd.CommandText += "CONVERT(DATETIME,'" + textBox_fecha.Text + "',121),";
            cmd.CommandText += "'" + textBox_calle.Text + "',";
            cmd.CommandText += "" + textBox_nro.Text + ",";
            cmd.CommandText += "'" + comboBox_nacionalidad.GetItemText(comboBox_nacionalidad.SelectedItem) + "',";
            cmd.CommandText += "'" + textBox_localidad.Text + "',0)";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla CLIENTE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return;
            }

            if (textBox_piso.Text != "")
            {
                //actualizo
                cmd.CommandText = "UPDATE NETSTLE.CLIENTE SET CLI_DOM_PISO = '" + textBox_piso.Text + "' WHERE CLI_NOMBRE_USUARIO = '" + textBox_usuario.Text + "'";
                //ejecuto
                if (cmd.ExecuteNonQuery() < 1)
                {
                    //fallo
                    MessageBox.Show("Error al insertar en la tabla CLIENTE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //libero
                    cmd.Dispose();
                    return;
                }
            }

            if (textBox_depto.Text != "")
            {
                //actualizo
                cmd.CommandText = "UPDATE NETSTLE.CLIENTE SET CLI_DOM_DEPTO = '" + textBox_depto.Text + "' WHERE CLI_NOMBRE_USUARIO = '" + textBox_usuario.Text + "'";
                //ejecuto
                if (cmd.ExecuteNonQuery() < 1)
                {
                    //fallo
                    MessageBox.Show("Error al insertar en la tabla CLIENTE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //libero
                    cmd.Dispose();
                    return;
                }
            }

            //exito
            MessageBox.Show("Se ha creado el cliente de forma satisfactoria.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //libero
            cmd.Dispose();
        }

        private bool usuarioTieneCliente()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CLIENTE WHERE ";
            cmd.CommandText += "CLI_NOMBRE_USUARIO = '" + textBox_usuario.Text + "'" ;

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

        private bool clienteHabilitado()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CLIENTE WHERE ";
            cmd.CommandText += "CLI_NOMBRE_USUARIO = '" + textBox_usuario.Text + "' AND ";
            cmd.CommandText += "CLI_ELIMINADO = 0";

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

        private void hablitarCliente()
        {
            //update
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.CLIENTE SET CLI_ELIMINADO = 0 WHERE ";
            cmd.CommandText += "CLI_NOMBRE_USUARIO = '" + textBox_usuario.Text + "'";

            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al habilitar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Se rehabilito al cliente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
        }

        private void cambiarContraseña(String psw)
        {
            //update
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.USUARIO SET USR_CONTRASEÑA = ";
            cmd.CommandText += "'" + encriptarSHA256(psw) + "' WHERE ";
            cmd.CommandText += "USR_NOMBRE = '" + textBox_usuario.Text + "'";

            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al cambiar contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Contraseña cambiada.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_usuario.Text == "")
            {
                errorProvider_usuario.SetError(textBox_usuario, "Por favor ingrese el nombre de usuario.");
                vacio = true;
            }

            if (textBox_psw.Text == "")
            {
                errorProvider_psw.SetError(textBox_psw, "Por favor ingrese la contraseña.");
                vacio = true;
            }

            if (textBox_nroDoc.Text == "")
            {
                errorProvider_nroDoc.SetError(textBox_nroDoc, "Por favor ingrese el numero de documento.");
                vacio = true;
            }
            
            if (textBox_nombre.Text == "")
            {
                errorProvider_nombre.SetError(textBox_nombre, "Por favor ingrese el nombre.");
                vacio = true;
            }

            if (textBox_apellido.Text == "")
            {
                errorProvider_ape.SetError(textBox_apellido, "Por favor ingrese el apellido.");
                vacio = true;
            }

            if (textBox_mail.Text == "")
            {
                errorProvider_mail.SetError(textBox_mail, "Por favor ingrese el mail.");
                vacio = true;
            }

            if (textBox_localidad.Text == "")
            {
                errorProvider_localidad.SetError(textBox_localidad, "Por favor ingrese la localidad.");
                vacio = true;
            }

            if (textBox_calle.Text == "")
            {
                errorProvider_calle.SetError(textBox_calle, "Por favor ingrese la calle.");
                vacio = true;
            }

            if (textBox_nro.Text == "")
            {
                errorProvider_nro.SetError(textBox_nro, "Por favor ingrese la numeracion de la calle.");
                vacio = true;
            }

            if (textBox_fecha.Text == "")
            {
                errorProvider_fecha.SetError(textBox_fecha, "Por favor ingrese la fecha de nacimiento.");
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

            //si existe un usuario con ese nombre
            if (existeNombreDeUsuario())
            {
                if (!usuarioTieneCliente())
                {
                    if (!existeCliente())
                    {
                        //nuevo
                        insertarCliente();
                        //limpio
                        limpiar();
                    }
                }
                else
                {
                    if (clienteHabilitado())
                    {
                        MessageBox.Show("El usuario ya tiene un cliente asociado y habilitado.", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("¿Desea cambiar la contraseña para habilitar el cliente?", "Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            NuevaContraseña frmNueva = new NuevaContraseña();

                            if (frmNueva.ShowDialog() == DialogResult.Yes)
                            {
                                cambiarContraseña(frmNueva.getContraseña());
                                hablitarCliente();
                                //limpio
                                limpiar();
                            }

                            //libero
                            frmNueva.Dispose();
                        }
                    }
                }
            }
            else
            {
                if (!existeCliente())
                {
                    //nuevos
                    insertarUsuario();
                    insertarCliente();
                    //limpio
                    limpiar();
                }
            }
        }

        private void agregarnuevoPais(ComboBox comboBox)
        {
            //nueva instancia
            Pais frmPais = new Pais(sqlCon);

            if (frmPais.ShowDialog() == DialogResult.Yes)
            {
                //borro todos los items del combobox
                comboBox.Items.Clear();

                //recargo
                cargarPaises(comboBox);

                //selecciono el pais que recien creo
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    if (comboBox.GetItemText(comboBox.Items[i]) == frmPais.getNuevoPais())
                    {
                        comboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            //libero
            frmPais.Dispose();
        }

        private void button_pais_Click(object sender, EventArgs e)
        {
            agregarnuevoPais(comboBox_pais);
            //recargo
            cargarPaises(comboBox_nacionalidad);
        }

        private void button_nacionalidad_Click(object sender, EventArgs e)
        {
            agregarnuevoPais(comboBox_nacionalidad);
            //recargo
            cargarPaises(comboBox_pais);
        }

        private void textBox_usuario_TextChanged(object sender, EventArgs e)
        {
            errorProvider_usuario.Clear();
        }

        private void textBox_nroDoc_TextChanged(object sender, EventArgs e)
        {
            errorProvider_nroDoc.Clear();
        }

        private void textBox_nombre_TextChanged(object sender, EventArgs e)
        {
            errorProvider_nombre.Clear();
        }

        private void textBox_apellido_TextChanged(object sender, EventArgs e)
        {
            errorProvider_ape.Clear();
        }

        private void textBox_mail_TextChanged(object sender, EventArgs e)
        {
            errorProvider_mail.Clear();
        }

        private void textBox_calle_TextChanged(object sender, EventArgs e)
        {
            errorProvider_calle.Clear();
        }

        private void textBox_nro_TextChanged(object sender, EventArgs e)
        {
            errorProvider_nro.Clear();
        }

        private void textBox_psw_TextChanged(object sender, EventArgs e)
        {
            errorProvider_psw.Clear();
        }

        private void textBox_localidad_TextChanged(object sender, EventArgs e)
        {
            errorProvider_localidad.Clear();
        }

        private void limpiar()
        {
            //limpio textobox
            textBox_apellido.Text = "";
            textBox_calle.Text = "";
            textBox_depto.Text = "";
            textBox_fecha.Text = "";
            textBox_mail.Text = "";
            textBox_nombre.Text = "";
            textBox_nro.Text = "";
            textBox_piso.Text = "";
            textBox_nroDoc.Text = "";
            textBox_usuario.Text = "";
            textBox_psw.Text = "";
            textBox_pregunta.Text = "";
            textBox_respuesta.Text = "";
            textBox_localidad.Text = "";

            //mujestro primer elemento de los combobox
            comboBox_pais.SelectedIndex = 0;
            comboBox_nacionalidad.SelectedIndex = 0;
            comboBox_tipoDoc.SelectedIndex = 0;

            //saco las advertencias
            errorProvider_calle.Clear();
            errorProvider_nombre.Clear();
            errorProvider_ape.Clear();
            errorProvider_localidad.Clear();
            errorProvider_mail.Clear();
            errorProvider_nro.Clear();
            errorProvider_fecha.Clear();
            errorProvider_usuario.Clear();
            errorProvider_nroDoc.Clear();
            errorProvider_psw.Clear();
            errorProvider_pregunta.Clear();
            errorProvider_respuesta.Clear();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void textBox_piso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox_nroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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
