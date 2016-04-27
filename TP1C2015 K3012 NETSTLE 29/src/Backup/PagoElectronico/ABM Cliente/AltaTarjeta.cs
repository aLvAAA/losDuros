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
    public partial class AltaTarjeta : Form
    {
        private SqlConnection sqlCon = null;

        public AltaTarjeta()
        {
            InitializeComponent();
        }

        public AltaTarjeta(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;

            //cargo fecha emision
            DateTime time = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
            textBox_fech_emi.Text = time.ToString("yyyy-MM-dd HH:MM:ss");

            //cargar combobox
            cargarEmisores(comboBox_emisores);
        }

        void cargarEmisores(ComboBox comboBox)
        {
            //limpio por las dudas
            comboBox.Items.Clear();

            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT EMISOR_DESC FROM NETSTLE.EMISOR";
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

        private bool existeNumeroTarjeta()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.TARJETA WHERE ";
            cmd.CommandText += "TAR_NUMERO = '" + textBox_numero.Text + "'";
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

        private void insertarTarjeta()
        {
            //inserto tarjeta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO NETSTLE.TARJETA (TAR_NUMERO,TAR_NRO_DOC_CLI,TAR_TIPO_DOC_CLI,TAR_EMISOR,TAR_FECHA_EMISION,TAR_FECHA_VENCIMIENTO,TAR_ELIMINADA,TAR_COD_SEGURIDAD,TAR_COD_ULT_4_NROS) ";
            cmd.CommandText += "VALUES (" + textBox_numero.Text + ",";
            cmd.CommandText += textBox_nro_doc.Text + ",";
            cmd.CommandText += "'" + textBox_tipo_doc.Text + "',";
            cmd.CommandText += "'" + comboBox_emisores.GetItemText(comboBox_emisores.SelectedItem) + "',";
            cmd.CommandText += "CONVERT(DATETIME,'" + textBox_fech_emi.Text + "',121),";
            cmd.CommandText += "CONVERT(DATETIME,'" + textBox_fech_ven.Text + "',121),";
            cmd.CommandText += "0,";
            cmd.CommandText += "'" + encriptarSHA256(textBox_codigo.Text) + "',";
            cmd.CommandText += "'" + textBox_codigo.Text.Substring(12,4) + "')";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla TARJETA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return;
            }

            //libero
            cmd.Dispose();
        }

        private void button_sel_fecha_Click(object sender, EventArgs e)
        {
            //nueva instancia
            Calendario frmCal = new Calendario();

            //muestro
            if (frmCal.ShowDialog() == DialogResult.Yes)
            {
                DateTime time = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

                if (frmCal.getFechaDateTime() > time)
                {
                    //recupero fecha
                    textBox_fech_ven.Text = frmCal.getFecha();
                    errorProvider_fecha.Clear();
                }
                else
                {
                    // no pudo haber vencido ayer
                    MessageBox.Show("No es una fecha de vencimiento valida.", "Fecha de Vencimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //libero
            frmCal.Dispose();  
        }

        private void textBox_numero_TextChanged(object sender, EventArgs e)
        {
            errorProvider_numero.Clear();
        }

        private void textBox_codigo_TextChanged(object sender, EventArgs e)
        {
            errorProvider_codigo.Clear();
        }

        private void textBox_fech_ven_TextChanged(object sender, EventArgs e)
        {
            errorProvider_fecha.Clear();
        }

        private void textBox_numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void limpiar()
        {
            //limpio textobox
            textBox_numero.Text = "";
            textBox_fech_ven.Text = "";
            textBox_codigo.Text = "";
            textBox_nro_doc.Text = "";
            textBox_tipo_doc.Text = "";

            //muestro primer elemento de los combobox
            comboBox_emisores.SelectedIndex = 0;

            //saco las advertencias
            errorProvider_numero.Clear();
            errorProvider_fecha.Clear();
            errorProvider_codigo.Clear();
        }
        
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
       
        private void button_buscar_Click(object sender, EventArgs e)
        {
            //nueva instancia
            Buscador frmBusc = new Buscador(sqlCon, false);

            if (frmBusc.ShowDialog() == DialogResult.Yes)
            {
                //identificacion de cliente
                textBox_tipo_doc.Text = frmBusc.getClienteTipoDocumento();
                textBox_nro_doc.Text = frmBusc.getClienteNroDocumento();
            }

            //libero
            frmBusc.Dispose();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (textBox_nro_doc.Text != "" && textBox_tipo_doc.Text != "")
            {
                bool vacio = false;

                if (textBox_numero.Text == "")
                {
                    errorProvider_numero.SetError(textBox_numero, "Por favor ingrese el numero de la tarjeta.");
                    vacio = true;
                }

                if (textBox_fech_ven.Text == "")
                {
                    errorProvider_fecha.SetError(textBox_fech_ven, "Por favor ingrese la fecha de vencimiento.");
                    vacio = true;
                }

                if (textBox_codigo.Text == "")
                {
                    errorProvider_codigo.SetError(textBox_codigo, "Por favor ingrese el código de seguridad.");
                    vacio = true;
                }
                else if (textBox_codigo.Text.Length < 16)
                {
                    errorProvider_codigo.SetError(textBox_codigo, "El codigo de seguridad debe tener 16 digitos");
                    vacio = true;
                }

                //me las tomo?
                if (vacio) return;

                if (existeNumeroTarjeta())
                {
                    MessageBox.Show("Ya existe ese número de tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //nuevo
                    insertarTarjeta();
                    //se creo nuevo usuario
                    MessageBox.Show("Se ha creado una nueva tarjeta", "Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
            }
            else
            {
                MessageBox.Show("Por favor busque y seleccione un cliente para asociar la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
