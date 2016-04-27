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

namespace PagoElectronico.Depositos
{
    public partial class Deposito : Form
    {
        private SqlConnection sqlCon = null;

        private String usuario = null;

        public Deposito()
        {
            InitializeComponent();
        }

        public Deposito(SqlConnection sqlCon, String usuario):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;

            //cargo los tipos monedas
            cargarTipoMoneda();
            //cargo las tarjetas no vencidas
            cargarTarjetas();
            //cargo las cuentas no cerradas del cliente.
            cargarCuentas();
        }

        private void cargarTipoMoneda()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TIPO_MONEDA FROM NETSTLE.TIPOMONEDA";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //limpio
                comboBox_tipoMoneda.Items.Clear();

                while (reader.Read())
                {
                    //agrego
                    comboBox_tipoMoneda.Items.Add(reader.GetString(0));
                }

                comboBox_tipoMoneda.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void cargarTarjetas()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "SELECT TAR_NUMERO FROM NETSTLE.USUARIO ";
            cmd.CommandText += " JOIN NETSTLE.CLIENTE ON (USR_NOMBRE = CLI_NOMBRE_USUARIO)";
            cmd.CommandText += " JOIN NETSTLE.TARJETA ON (TAR_TIPO_DOC_CLI = CLI_TIPO_DOCUMENTO AND TAR_NRO_DOC_CLI = CLI_NRO_DOCUMENTO)";
            cmd.CommandText += " WHERE USR_NOMBRE = '" + usuario + "' AND";
            cmd.CommandText += " TAR_ELIMINADA = 0 AND";
            cmd.CommandText += " TAR_FECHA_VENCIMIENTO > " + "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)";

            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //limpio
                comboBox_Tarjeta.Items.Clear();

                while (reader.Read())
                {
                    //agrego
                    comboBox_Tarjeta.Items.Add(reader.GetString(0));
                }

                comboBox_Tarjeta.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void cargarCuentas()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CTA_NUMERO FROM NETSTLE.USUARIO ";
            cmd.CommandText += " JOIN NETSTLE.CLIENTE ON (USR_NOMBRE = CLI_NOMBRE_USUARIO)";
            cmd.CommandText += " JOIN NETSTLE.CUENTA ON (CTA_TIPO_DOC_CLIENTE = CLI_TIPO_DOCUMENTO AND CTA_NRO_DOC_CLIENTE = CLI_NRO_DOCUMENTO)";
            cmd.CommandText += " WHERE CTA_ESTADO = 'HABILITADA' AND";
            cmd.CommandText += " USR_NOMBRE = '" + usuario + "'";
            
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //limpio
                comboBox_cuenta.Items.Clear();

                while (reader.Read())
                {
                    //agrego
                    comboBox_cuenta.Items.Add(reader.GetDecimal(0).ToString());
                }

                comboBox_cuenta.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("El cliente no tiene ninguna cuenta para realizar el deposito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button_aceptar.Enabled = false;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private bool actualizarSaldo()
        {
            //actualiso saldo
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.CUENTA SET " ;
            cmd.CommandText += "CTA_SALDO = CTA_SALDO + " + textBox_importe.Text + " ";
            cmd.CommandText += "WHERE CTA_NUMERO = " + comboBox_cuenta.GetItemText(comboBox_cuenta.SelectedItem);
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al actualizar el saldo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            //libero
            cmd.Dispose();
            return true;
        }

        private void guardarDeposito()
        {
            //guardo comprobante saldo
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.DEPOSITO (DEP_NRO_TARJETA,DEP_NRO_CUENTA,DEP_IMPORTE,DEP_TIPO_MONEDA,DEP_FECHA) ";
            cmd.CommandText += "VALUES('" + comboBox_Tarjeta.GetItemText(comboBox_Tarjeta.SelectedItem) + "',";
            cmd.CommandText += "" + comboBox_cuenta.GetItemText(comboBox_cuenta.SelectedItem) + ",";
            cmd.CommandText += textBox_importe.Text + ",";
            cmd.CommandText += "'" + comboBox_tipoMoneda.GetItemText(comboBox_tipoMoneda.SelectedItem) + "',";
            cmd.CommandText += "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + ")";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla DEPOSITO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Deposito registrado.", "Deposito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (textBox_importe.Text == "" || Convert.ToInt64(textBox_importe.Text) == 0)
            {
                errorProvider_importe.SetError(textBox_importe, "Por favor ingrese un importe valido.");
                return;
            }
          
            //hago efectivo el deposito
            if (actualizarSaldo())
            {
                guardarDeposito();

                //limpio
                comboBox_cuenta.SelectedIndex = 0;
                comboBox_tipoMoneda.SelectedIndex = 0;
                comboBox_Tarjeta.SelectedIndex = 0;
                textBox_importe.Text = "";
            }
        }

        private void textBox_importe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox_importe_TextChanged(object sender, EventArgs e)
        {
            errorProvider_importe.Clear();
        }
    }

}
