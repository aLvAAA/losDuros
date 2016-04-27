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

namespace PagoElectronico.ABM_Cuenta
{
    public partial class Modificacion : Form
    {
        private SqlConnection sqlCon = null;

        private String usuario = null;

        public Modificacion()
        {
            InitializeComponent();
        }

        public Modificacion(SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;

            //cargo
            cargarTipoCuenta();
        }

        public Modificacion(SqlConnection sqlCon, String usuario):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;

            //cargo
            cargarTipoCuenta();
        }

        private void cargarTipoCuenta()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TIPO_CTA FROM NETSTLE.TIPOCUENTA";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox_tipoCuenta.Items.Add(reader.GetString(0));
                }

                comboBox_tipoCuenta.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void textBox_nroDeSuscripciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox_nroDeSuscripciones_TextChanged(object sender, EventArgs e)
        {
            errorProvider_sus.Clear();
        }

        private void cargarTipoCuentaCliente()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CTA_TIPO FROM NETSTLE.CUENTA WHERE CTA_NUMERO = " + textBox_cuenta.Text;
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                String tipo = reader.GetString(0);
                int i = 0;

                while (true)
                {
                    if (tipo == comboBox_tipoCuenta.GetItemText(comboBox_tipoCuenta.Items[i]))
                    {
                        comboBox_tipoCuenta.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            //nueva instancia
            ABM_Cuenta.Listado frmBusc = null;

            if (usuario != null)
            {
                frmBusc = new ABM_Cuenta.Listado(true,sqlCon,usuario);
            }
            else
            {
                frmBusc = new ABM_Cuenta.Listado(true,sqlCon);
            }
        
            //muestro
            if (frmBusc.ShowDialog() == DialogResult.Yes)
            {
                textBox_cuenta.Text = frmBusc.getNumeroDeCuenta();
                textBox_nroDeSuscripciones.Text = "";
                errorProvider_nroCuenta.Clear();

                //cargo
                cargarTipoCuentaCliente();
            }

            //libero
            frmBusc.Dispose();
        }

        private bool actualizarCuenta()
        {
            //update
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.CUENTA SET CTA_TIPO = '" + comboBox_tipoCuenta.GetItemText(comboBox_tipoCuenta.SelectedItem) + "',";
            cmd.CommandText += "CTA_ESTADO = 'PENDIENTE_DE_ACTIVACION',";
            cmd.CommandText += "CTA_DIAS_DE_SUSCRIPCION = (SELECT TIPO_CTA_DURACION FROM NETSTLE.TIPOCUENTA WHERE TIPO_CTA = '" + comboBox_tipoCuenta.GetItemText(comboBox_tipoCuenta.SelectedItem) + "')*" + textBox_nroDeSuscripciones.Text + ",";
            cmd.CommandText += "CTA_FECHA_APERTURA = NULL ";
            cmd.CommandText += "WHERE CTA_NUMERO = " + textBox_cuenta.Text;
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al modificar la cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return false;
            }
            else
            {
                //exito
                MessageBox.Show("Cuenta modificada con exito.", "Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
            return true;
        }

        private void generarTransaccion()
        {
            //inserto transaccion
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.TRANSACCION (TRANS_CTA_EMISORA,TRANS_DESCRIPCION,TRANS_COSTO,TRANS_TIPO_MONEDA,TRANS_PENDIENTE,TRANS_FECHA) ";
            cmd.CommandText += "VALUES(" + textBox_cuenta.Text + ",";
            cmd.CommandText += "'Modificacion de cuenta.',";
            cmd.CommandText += "(SELECT TIPO_CTA_COSTO_APERTURA FROM NETSTLE.TIPOCUENTA WHERE TIPO_CTA = '" + comboBox_tipoCuenta.GetItemText(comboBox_tipoCuenta.SelectedItem) + "')*" + textBox_nroDeSuscripciones.Text + ",";
            cmd.CommandText += "(SELECT CTA_TIPO_MONEDA FROM NETSTLE.CUENTA WHERE CTA_NUMERO = " + textBox_cuenta.Text + "),";
            cmd.CommandText += "1,";
            cmd.CommandText += "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + ")";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla TRANSACCION.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //libero
            cmd.Dispose();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_cuenta.Text == "")
            {
                errorProvider_nroCuenta.SetError(textBox_cuenta, "Por favor seleccione una cuenta.");
                vacio = true;
            }

            if (textBox_nroDeSuscripciones.Text == "" || Convert.ToInt64(textBox_nroDeSuscripciones.Text) <= 0)
            {
                errorProvider_sus.SetError(textBox_nroDeSuscripciones, "Por favor ingrese la cantidad de suscripciones.");
                vacio = true;
            }

            //salgo?
            if (vacio) return;

            if (actualizarCuenta())
            {
                generarTransaccion();

                //limpio
                textBox_cuenta.Text = "";
                textBox_nroDeSuscripciones.Text = "";
                comboBox_tipoCuenta.SelectedIndex = 0;
            }
        }
    }
}
