using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PagoElectronico.ABM_Cliente
{
    public partial class Modificacion : Form
    {
        private SqlConnection sqlCon = null;

        private String nroDoc = null;

        private String tipoDoc = null;

        public Modificacion()
        {
            InitializeComponent();
        }

        public Modificacion(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;
        }

        private void limpiarTextBox()
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
            textBox_localidad.Text = "";
        }

        private void cargarDatosCliente()
        {
            //cargo los paises
            cargarPaises();

            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CLI_NOMBRE,";
            cmd.CommandText += "CLI_APELLIDO,";
            cmd.CommandText += "CLI_PAIS,";
            cmd.CommandText += "CLI_MAIL,";
            cmd.CommandText += "CLI_FECHA_NACIMIENTO,";
            cmd.CommandText += "CLI_DOM_CALLE,";
            cmd.CommandText += "CLI_DOM_NRO,";
            cmd.CommandText += "CLI_DOM_PISO,";
            cmd.CommandText += "CLI_DOM_DEPTO,";
            cmd.CommandText += "CLI_NOMBRE_USUARIO,";
            cmd.CommandText += "CLI_ELIMINADO,";
            cmd.CommandText += "CLI_LOCALIDAD ";

            cmd.CommandText += "FROM NETSTLE.CLIENTE WHERE ";
            cmd.CommandText += "CLI_NRO_DOCUMENTO = " + nroDoc + " AND CLI_TIPO_DOCUMENTO = '" + tipoDoc + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    //limpio por las dudas
                    limpiarTextBox();
                    
                    //nombre del cliente
                    textBox_nombre.Text = reader.GetString(0);

                    //apellido del cliente
                    textBox_apellido.Text = reader.GetString(1);

                    //mail del cliente
                    textBox_mail.Text = reader.GetString(3);
                    
                    //muestro seleccionado el pais del cliente en el combobox
                    for (int i = 0; i < comboBox_pais.Items.Count; i++)
                    {
                        if (comboBox_pais.Items[i].ToString() == reader.GetString(2))
                        {
                            comboBox_pais.SelectedIndex = i;
                            break;
                        };
                    }

                    //fecha nacimiento 
                    textBox_fecha.Text = reader.GetDateTime(4).ToString("yyyy-MM-dd HH:MM:ss");
                    
                    //calle del cliente
                    textBox_calle.Text = reader.GetString(5);

                    //nro calle del cliente
                    textBox_nro.Text = reader.GetDecimal(6).ToString();

                    //si el cliente esta inhabilitado
                    if (reader.GetBoolean(10))
                    {
                        //habilito combobox para que pueda hablitarlo
                        comboBox_habilitado.Enabled = true;

                        //muestra no
                        comboBox_habilitado.SelectedIndex = 1;
                    }
                    else
                    {
                        //muestra si
                        comboBox_habilitado.SelectedIndex = 0;
                    }

                    //piso del cliente
                    if (!reader.IsDBNull(7))
                        textBox_piso.Text = reader.GetDecimal(7).ToString();

                    //depto del cliente
                    if (!reader.IsDBNull(8))
                        textBox_depto.Text = reader.GetString(8);

                    //localidad del cliente
                    if (!reader.IsDBNull(11))
                        textBox_localidad.Text = reader.GetString(11);
                }
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        void cargarPaises()
        {
            //limpio por lad dudas
            comboBox_pais.Items.Clear();
            
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
                    comboBox_pais.Items.Add(reader.GetString(0));
                }

                comboBox_pais.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            //nueva instancia
            Buscador frmBusc = new Buscador(sqlCon,true);

            if (frmBusc.ShowDialog() == DialogResult.Yes)
            {
                //identificacion de cliente
                tipoDoc = frmBusc.getClienteTipoDocumento();
                nroDoc = frmBusc.getClienteNroDocumento();

                //inhabilito combobox_habilitida
                comboBox_habilitado.Enabled = false;

                //cargo los datos del cliente
                cargarDatosCliente();
            }

            //libero
            frmBusc.Dispose();
        }

        private void button_restaurar_Click(object sender, EventArgs e)
        {
            if (nroDoc != null && tipoDoc != null)
            {
                //cargo los datos del cliente
                cargarDatosCliente();

                //saco las advertencias
                errorProvider_calle.Clear();
                errorProvider_nombre.Clear();
                errorProvider_ape.Clear();
                errorProvider_mail.Clear();
                errorProvider_nro.Clear();
                errorProvider_fecha.Clear();
                errorProvider_localidad.Clear();
            }
        }

        private void actualizarCliente()
        {
            //update
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.CLIENTE SET ";

            //si no tiene nada inserto null
            cmd.CommandText += "CLI_DOM_PISO = " + ((textBox_piso.Text != "") ? textBox_piso.Text : "NULL") + ",";
            //si no tiene nada inserto null
            cmd.CommandText += "CLI_DOM_DEPTO = " + ((textBox_depto.Text != "") ? ("'" + textBox_depto.Text + "'") : "NULL") + ",";

            cmd.CommandText += "CLI_NOMBRE = '" + textBox_nombre.Text + "',";
            cmd.CommandText += "CLI_APELLIDO = '" + textBox_apellido.Text + "',";
            cmd.CommandText += "CLI_PAIS = '" + comboBox_pais.GetItemText(comboBox_pais.SelectedItem) + "',";
            cmd.CommandText += "CLI_MAIL = '" + textBox_mail.Text + "',";
            cmd.CommandText += "CLI_DOM_CALLE = '" + textBox_calle.Text + "',";
            cmd.CommandText += "CLI_DOM_NRO = " + textBox_nro.Text + ",";
            cmd.CommandText += "CLI_FECHA_NACIMIENTO = CONVERT(DATETIME,'" + textBox_fecha.Text + "',121),";
            cmd.CommandText += "CLI_ELIMINADO = " + ((comboBox_habilitado.SelectedIndex == 0) ? "0 ":"1 ");
            cmd.CommandText += "WHERE CLI_NRO_DOCUMENTO = " + nroDoc + " AND CLI_TIPO_DOCUMENTO = '" + tipoDoc + "'";

            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Se ha guardado la modificacion.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (comboBox_habilitado.SelectedIndex == 0)
                {
                    //inhablito combobox_hablitado
                    comboBox_habilitado.Enabled = false;
                }
            }

            //libero
            cmd.Dispose();
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
            textBox_localidad.Text = "";

            //mujestro primer elemento de los combobox
            comboBox_pais.SelectedIndex = 0;
          
            //saco las advertencias
            errorProvider_calle.Clear();
            errorProvider_nombre.Clear();
            errorProvider_ape.Clear();
            errorProvider_localidad.Clear();
            errorProvider_mail.Clear();
            errorProvider_nro.Clear();
            errorProvider_fecha.Clear();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (nroDoc!= null && tipoDoc != null)
            {
                bool vacio = false;

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

                //me las tomo?
                if (vacio) return;

                //actualizo
                actualizarCliente();
                //limpio
                limpiar();
            }
        }
        
        private void textBox_calle_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider_calle.Clear();
        }

        private void textBox_nombre_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider_nombre.Clear();
        }

        private void textBox_apellido_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider_ape.Clear();
        }

        private void textBox_mail_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider_mail.Clear();
        }

        private void textBox_nro_TextChanged_1(object sender, EventArgs e)
        {
            errorProvider_nro.Clear();
        }

        private void textBox_piso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button_fecha_Click(object sender, EventArgs e)
        {
            if (nroDoc != null && tipoDoc != null)
            {
                //nueva instancia
                Calendario frmCal= new Calendario();

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
        }
        
        private void button_pais_Click(object sender, EventArgs e)
        {
            if (nroDoc != null && tipoDoc != null)
            {
                //nueva instanca
                Pais frmPais = new Pais(sqlCon);

                if (frmPais.ShowDialog() == DialogResult.Yes)
                {
                    //borro todos los items del combobox
                    comboBox_pais.Items.Clear();

                    //recargo
                    cargarPaises();

                    //selecciono el pais que recien creo
                    for (int i = 0; i < comboBox_pais.Items.Count; i++)
                    {
                        if (comboBox_pais.GetItemText(comboBox_pais.Items[i]) == frmPais.getNuevoPais())
                        {
                            comboBox_pais.SelectedIndex = i;
                            break;
                        }
                    }
                }

                //libero
                frmPais.Dispose();
            }
        }

        private void textBox_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox_localidad_TextChanged(object sender, EventArgs e)
        {
            errorProvider_localidad.Clear();
        }
    }
}
