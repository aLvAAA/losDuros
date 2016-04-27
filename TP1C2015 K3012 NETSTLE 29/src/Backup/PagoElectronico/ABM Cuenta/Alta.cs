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
    public partial class Alta : Form
    {
        private SqlConnection sqlCon = null;

        private String usuario = null;

        public Alta()
        {
            InitializeComponent();
        }

        //sobrecarga del constructor usado solo por el admin
        public Alta(SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;

            //cargo
            cargarPaises(comboBox_pais);
            cargarTipoCuenta();
            cargarTipoMoneda();
        }

        //sobrecarga del constructor usado solo por el cliente
        public Alta(SqlConnection sqlCon, String usuario):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;

            //cargo
            cargarPaises(comboBox_pais);
            cargarTipoCuenta();
            cargarTipoMoneda();
            recuperarDoc(usuario);


            //al cliente no le dejo buscar
            button_buscar.Enabled = false;
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

        private void recuperarDoc(String usuario)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CLI_NRO_DOCUMENTO,CLI_TIPO_DOCUMENTO FROM NETSTLE.CLIENTE WHERE ";
            cmd.CommandText += "CLI_NOMBRE_USUARIO = '" + usuario + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    //identificacion del cliente
                    textBox_nroDoc.Text = reader.GetDecimal(0).ToString();
                    textBox_tipoDoc.Text = reader.GetString(1);
                }
            }
            else
            {
                MessageBox.Show("El usuario no tiene un cliente asociado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2.Enabled = false;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void textBox_cuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private bool existeNumeroDeCuenta()
        {
            //inserto cuenta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CUENTA WHERE CTA_NUMERO = " + textBox_cuenta.Text;
            cmd.Connection = sqlCon;

            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                //aviso
                MessageBox.Show("Existe una cuenta con ese numero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return true;
            }

            //libero
            cmd.Dispose();
            return false;
        }

        private bool guardarCuenta()
        {
            //inserto cuenta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO NETSTLE.CUENTA (CTA_NUMERO,CTA_TIPO,CTA_TIPO_MONEDA,CTA_PAIS,CTA_NRO_DOC_CLIENTE,CTA_TIPO_DOC_CLIENTE,CTA_DIAS_DE_SUSCRIPCION,CTA_ESTADO,CTA_SALDO) ";
            cmd.CommandText += "VALUES(" + textBox_cuenta.Text + ",";
            cmd.CommandText += "'" + comboBox_tipoCuenta.GetItemText(comboBox_tipoCuenta.SelectedItem) + "',";
            cmd.CommandText += "'" + comboBox_tipoMoneda.GetItemText(comboBox_tipoMoneda.SelectedItem) + "',";
            cmd.CommandText += "'" + comboBox_pais.GetItemText(comboBox_pais.SelectedItem) + "',";
            cmd.CommandText += textBox_nroDoc.Text + ",";
            cmd.CommandText += "'" + textBox_tipoDoc.Text + "',";
            cmd.CommandText += "(SELECT TIPO_CTA_DURACION FROM NETSTLE.TIPOCUENTA WHERE TIPO_CTA = '" + comboBox_tipoCuenta.GetItemText(comboBox_tipoCuenta.SelectedItem) + "')*" + textBox_nroDeSuscripciones.Text + ",";
            cmd.CommandText += "'PENDIENTE_DE_ACTIVACION',0)";
            cmd.Connection = sqlCon;

            bool res;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla CUENTA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                res = false;
            }
            else
            {
                //exito
                MessageBox.Show("Se ha guardado la cuenta de forma satisfactoria.", "Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                res = true;
            }

            //libero
            cmd.Dispose();
            return res;
        }

        private void generarTransaccion()
        {
            //inserto transaccion
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.TRANSACCION (TRANS_CTA_EMISORA,TRANS_DESCRIPCION,TRANS_COSTO,TRANS_TIPO_MONEDA,TRANS_PENDIENTE,TRANS_FECHA) ";
            cmd.CommandText += "VALUES(" + textBox_cuenta.Text + ",";
            cmd.CommandText += "'Apertura de cuenta.',";
            cmd.CommandText += "(SELECT TIPO_CTA_COSTO_APERTURA FROM NETSTLE.TIPOCUENTA WHERE TIPO_CTA = '" + comboBox_tipoCuenta.GetItemText(comboBox_tipoCuenta.SelectedItem) + "')*" + textBox_nroDeSuscripciones.Text + ",";
            cmd.CommandText += "(SELECT CTA_TIPO_MONEDA FROM NETSTLE.CUENTA WHERE CTA_NUMERO = " + textBox_cuenta.Text + "),1,";
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_cuenta.Text == "")
            {
                errorProvider_nroCuenta.SetError(textBox_cuenta, "Por favor ingrese el numero de cuenta.");
                vacio = true;
            }

            if (textBox_nroDoc.Text == "")
            {
                errorProvider_cliente1.SetError(textBox_nroDoc, "Por favor seleccione un cliente.");
                errorProvider_cliente2.SetError(textBox_tipoDoc, "Por favor seleccione un cliente.");
                vacio = true;
            }

            if (textBox_nroDeSuscripciones.Text == "" || Convert.ToInt64(textBox_nroDeSuscripciones.Text) <= 0)
            {
                errorProvider_sus.SetError(textBox_nroDeSuscripciones, "Por favor ingrese la cantidad de suscripciones.");
                vacio = true;
            }

            //salgo?
            if (vacio) return;

            //existe numero de cuenta?
            if (!existeNumeroDeCuenta())
            {
                if (guardarCuenta())
                {
                    generarTransaccion();
                    limpiar();
                }
            }
        }

        private void textBox_cuenta_TextChanged(object sender, EventArgs e)
        {
            errorProvider_nroCuenta.Clear();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            //nueva instancia
            ABM_Cliente.Buscador frmBusc = new ABM_Cliente.Buscador(sqlCon, false);

            if (frmBusc.ShowDialog() == DialogResult.Yes)
            {
                //identificacion de cliente
                textBox_nroDoc.Text = frmBusc.getClienteNroDocumento();
                textBox_tipoDoc.Text = frmBusc.getClienteTipoDocumento();
                
                //limpio advertencia
                errorProvider_cliente1.Clear();
                errorProvider_cliente2.Clear();
            }

            //libero
            frmBusc.Dispose();
        }

        private void limpiar()
        {
            //limpio textbox
            textBox_cuenta.Text = "";
            textBox_nroDeSuscripciones.Text = "";
            
            if (usuario == null)
            {
                textBox_nroDoc.Text = "";
                textBox_tipoDoc.Text = "";
            }

            //muestro primer elemento
            comboBox_pais.SelectedIndex = 0;
            comboBox_tipoCuenta.SelectedIndex = 0;
            comboBox_tipoMoneda.SelectedIndex = 0;

            //elimino advertencias
            errorProvider_nroCuenta.Clear();
            errorProvider_cliente1.Clear();
            errorProvider_cliente2.Clear();
            errorProvider_sus.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
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
    }
}
