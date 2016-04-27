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

namespace PagoElectronico.Retiros
{
    public partial class Retiro : Form
    {
        private SqlConnection sqlCon = null;

        private String usuario = null;

        public Retiro()
        {
            InitializeComponent();
        }

        public Retiro(SqlConnection sqlCon, String usuario):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;

            //cargo las cuentas habilitadas del cliente.
            cargarCuentas();
            cargarBancos();
        }

        private void cargarCuentas()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CTA_NUMERO FROM NETSTLE.USUARIO ";
            cmd.CommandText += " JOIN NETSTLE.CLIENTE ON (USR_NOMBRE = CLI_NOMBRE_USUARIO)";
            cmd.CommandText += " JOIN NETSTLE.CUENTA ON (CTA_TIPO_DOC_CLIENTE = CLI_TIPO_DOCUMENTO AND CTA_NRO_DOC_CLIENTE = CLI_NRO_DOCUMENTO)";
            cmd.CommandText += " WHERE CTA_ESTADO = 'HABILITADA' AND ";
            cmd.CommandText += " USR_NOMBRE = '" + usuario + "'";
            
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox_cuenta.Items.Add(reader.GetDecimal(0).ToString());
                }

                comboBox_cuenta.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("El cliente no tiene ninguna cuenta para realizar el retiro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button_aceptar.Enabled = false;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void cargarBancos()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT BAN_CODIGO ,BAN_NOMBRE FROM NETSTLE.BANCO";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox_banco.Items.Add(reader.GetDecimal(0).ToString() + "-" + reader.GetString(1));
                }

                comboBox_banco.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void textBox_importe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private bool tieneMasSaldoQue(String importe)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CUENTA";
            cmd.CommandText += " WHERE CTA_SALDO >= " + importe + " AND";
            cmd.CommandText += " CTA_NUMERO = '" + comboBox_cuenta.GetItemText(comboBox_cuenta.SelectedItem) + "'";

            cmd.Connection = sqlCon;

            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                //libero
                cmd.Dispose();
                return true;
            }
     
            //libero
            cmd.Dispose();
            MessageBox.Show("Saldo insuficiente para realizar el retiro.", "Retiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private bool actualizarSaldo()
        {
            //actualiso saldo
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.CUENTA SET ";
            cmd.CommandText += "CTA_SALDO = CTA_SALDO - " + textBox_importe.Text + " ";
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

        private string cotizacionMonedaCuenta()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TIPO_MONEDA_COTIZACION FROM NETSTLE.CUENTA";
            cmd.CommandText += " JOIN NETSTLE.TIPOMONEDA ON (CTA_TIPO_MONEDA = TIPO_MONEDA)";
            cmd.CommandText += " WHERE CTA_NUMERO = " + comboBox_cuenta.GetItemText(comboBox_cuenta.SelectedItem);
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();
            String cotizacion = null;

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    cotizacion = reader.GetDouble(0).ToString();
                }
            }

            //libero
            reader.Close();
            cmd.Dispose();
            return cotizacion;
        }

        private void guardarRetiro()
        {
            //guardo retiro
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.RETIRO (RET_NRO_CUENTA,RET_IMPORTE,RET_TIPO_MONEDA,RET_FECHA) ";
            cmd.CommandText += "VALUES(" + comboBox_cuenta.GetItemText(comboBox_cuenta.SelectedItem) + ",";
            cmd.CommandText += textBox_importe.Text + "*" + cotizacionMonedaCuenta() + ",";
            cmd.CommandText += "'DOLAR',";
            cmd.CommandText += "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + ")";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla RETIRO.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Retiro registrado.", "Retiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
        }

        private String codBanco()
        {
            String cod = comboBox_banco.GetItemText(comboBox_banco.SelectedItem);
            int i = 0;

            while (true)
            {
                if (cod[i] != '-')
                {
                    i++;
                    continue;
                }

                return cod.Substring(0, i);
            }
        }

        private String nombreBanco()
        {
            String nombre = comboBox_banco.GetItemText(comboBox_banco.SelectedItem);
            int i = 0;

            while (true)
            {
                if (nombre[i] != '-')
                {
                    i++;
                    continue;
                }

                return nombre.Substring(i + 1);
            }
        }

        private void generarCheque()
        {
            //guardo cheque
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.CHEQUE(CHE_COD_BANCO,CHE_NOMBRE_BANCO,CHE_NOMBRE_CLIENTE,CHE_APELLIDO_CLIENTE,CHE_IMPORTE,CHE_TIPO_MONEDA,CHE_FECHA) ";
            cmd.CommandText += "SELECT ";
            cmd.CommandText += codBanco() + ",";
            cmd.CommandText += "'" + nombreBanco() + "',";
            cmd.CommandText += "CLI_NOMBRE,";
            cmd.CommandText += "CLI_APELLIDO,";
            cmd.CommandText += textBox_importe.Text + "*" + cotizacionMonedaCuenta() + ",";
            cmd.CommandText += "'DOLAR',";
            cmd.CommandText += "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + " FROM NETSTLE.CLIENTE WHERE CLI_NOMBRE_USUARIO = '" + usuario + "'";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla CHEQUE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //libero
            cmd.Dispose();
        }

        private bool verificarDoc(String doc)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText += "SELECT COUNT(*) FROM NETSTLE.CLIENTE WHERE CLI_NRO_DOCUMENTO = " + doc + "AND CLI_NOMBRE_USUARIO = " + usuario;
            cmd.Connection = sqlCon;

            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                 //libero
                cmd.Dispose();
                return  true;
            }

            //libero
            cmd.Dispose();
            MessageBox.Show("Numero de documento incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return  false;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (textBox_importe.Text == "" || Convert.ToInt64(textBox_importe.Text) <= 0)
            {
                errorProvider_importe.SetError(textBox_importe, "Por favor ingrese un importe valido.");
                return;
            }

            if (tieneMasSaldoQue(textBox_importe.Text))
            {
                //nueva instancia
                Documento doc = new Documento();

                if (doc.ShowDialog() == DialogResult.OK)
                {
                    if (verificarDoc(doc.getNroDocumento()))
                    {
                        if (actualizarSaldo())
                        {
                            guardarRetiro();
                            generarCheque();

                            //limpio
                            comboBox_banco.SelectedIndex = 0;
                            comboBox_cuenta.SelectedIndex = 0;
                            textBox_importe.Text = "";
                        }
                    }
                }
            }
        }

        private void textBox_importe_TextChanged(object sender, EventArgs e)
        {
            errorProvider_importe.Clear();
        }
    }
}
