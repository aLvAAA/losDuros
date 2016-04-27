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

namespace PagoElectronico.Transferencias
{
    public partial class Transferencia : Form
    {
        private SqlConnection sqlCon = null;

        private String usr = null;

        public Transferencia()
        {
            InitializeComponent();
        }

        public Transferencia(SqlConnection sqlCon, String usr):this()
        {
            this.sqlCon = sqlCon;

             //se guarda el usuario logueado
            this.usr = usr;

            //se carga el combobox
            recuperarTiposDeMoneda();

        }

        void recuperarTiposDeMoneda()
        {
            //limpio por las dudas
            comboBox_moneda.Items.Clear();

            //consula
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TIPO_MONEDA ";
            cmd.CommandText += "FROM NETSTLE.TIPOMONEDA";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego los tipos de moneda al combobox
                    comboBox_moneda.Items.Add(reader.GetString(0));
                }
                //mostramos por default el primer item
                comboBox_moneda.SelectedIndex = 0;
            }
            //libero
            reader.Close();
            //libero
            cmd.Dispose();
        }

        private void textBox_importe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button_SelOrigen_Click(object sender, EventArgs e)
        {
            ABM_Cuenta.Listado frmList = new ABM_Cuenta.Listado(true, sqlCon, usr);

            //muestro
            if (frmList.ShowDialog() == DialogResult.Yes)
            {
                textBox_cuentaOrigen.Text = frmList.getNumeroDeCuenta();
                errorProvider_origen.Clear();
            }

            //libero
            frmList.Dispose();
        }

        private void button_SelDestino_Click(object sender, EventArgs e)
        {
            ABM_Cuenta.Listado frmList = new ABM_Cuenta.Listado(sqlCon, false);

            //muestro
            if (frmList.ShowDialog() == DialogResult.Yes)
            {
                textBox_cuentaDestino.Text = frmList.getNumeroDeCuenta();
                errorProvider_dest.Clear();
            }

            //libero
            frmList.Dispose();
        }

        private bool actualizarSaldo(String cuenta, String importe)
        {
            //actualiso saldo
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.CUENTA SET ";
            cmd.CommandText += "CTA_SALDO = CTA_SALDO + " + importe + " ";
            cmd.CommandText += "WHERE CTA_NUMERO = " + cuenta;
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

        private bool tieneMasSaldoQue(String cuenta,String importe)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CUENTA";
            cmd.CommandText += " WHERE CTA_SALDO >= " + importe + " AND";
            cmd.CommandText += " CTA_NUMERO = '" + cuenta + "'";

            cmd.Connection = sqlCon;

            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                //libero
                cmd.Dispose();
                return true;
            }

            //libero
            cmd.Dispose();
            MessageBox.Show("Saldo insuficiente para realizar la transferencia.", "Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private bool sonDelMismoCliente(String cuentaOrigen, String cuentaDest)
        {
            //iconsulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CTA_NRO_DOC_CLIENTE,CTA_TIPO_DOC_CLIENTE FROM NETSTLE.CUENTA WHERE CTA_NUMERO = " + cuentaOrigen;
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();
            String nroDoc = null;
            String tipoDoc = null;

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    nroDoc = reader.GetDecimal(0).ToString();
                    tipoDoc = reader.GetString(1);

                    //libero
                    reader.Dispose();

                    cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CUENTA WHERE CTA_NUMERO = " + cuentaDest + " AND CTA_NRO_DOC_CLIENTE = " + nroDoc + " AND CTA_TIPO_DOC_CLIENTE = '" + tipoDoc + "'";

                    if ((Int32)cmd.ExecuteScalar() > 0)
                    {
                        //libero
                        cmd.Dispose();
                        return true;
                    }
                    //libero
                    cmd.Dispose();
                    return false;
                }
            }

            //libero
            cmd.Dispose();
            throw new Exception("Error al determinar si las cuentas pertencecen a un mismo cliente");
        }

        private void generarTransaccion(String cuentaOrigen, String cuentaDest, String importe)
        {
            //inserto transaccion
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.TRANSACCION (TRANS_CTA_EMISORA,TRANS_DESCRIPCION,TRANS_COSTO,TRANS_PENDIENTE,TRANS_TIPO_MONEDA,TRANS_FECHA) ";
            cmd.CommandText += "VALUES(" + cuentaOrigen + ",";
            cmd.CommandText += "'Comisión por transferencia.',";
            cmd.CommandText += "(SELECT TIPO_CTA_COSTO_TRANSACCION FROM NETSTLE.TIPOCUENTA WHERE TIPO_CTA = (SELECT CTA_TIPO FROM NETSTLE.CUENTA WHERE CTA_NUMERO = " + cuentaOrigen + "))*" + ((sonDelMismoCliente(cuentaOrigen, cuentaDest)) ? "0" : importe) + ",";
            cmd.CommandText += (sonDelMismoCliente(cuentaOrigen, cuentaDest))? "0,":"1,";
            cmd.CommandText += "'" + comboBox_moneda.GetItemText(comboBox_moneda.SelectedItem) + "',";
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

        private void guardarTransferencia()
        {
            //guardo comprobante saldo
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            cmd.CommandText = "INSERT INTO NETSTLE.TRANSFERENCIA (TRANSF_CTA_ORIGEN,TRANSF_CTA_DESTINO,TRANSF_IMPORTE,TRANSF_TIPO_MONEDA,TRANSF_FECHA) ";
            cmd.CommandText += "VALUES(" + textBox_cuentaOrigen.Text + ",";
            cmd.CommandText += textBox_cuentaDestino.Text + ",";
            cmd.CommandText += textBox_importe.Text + ",";
            cmd.CommandText += "'" + comboBox_moneda.GetItemText(comboBox_moneda.SelectedItem) + "'," + "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + ")";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla TRANSFERENCIA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Transferencia registrada.", "Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_cuentaOrigen.Text == "")
            {
                errorProvider_origen.SetError(textBox_cuentaOrigen, "Por favor seleccione una cuenta origen.");
                vacio = true;
            }

            if (textBox_cuentaDestino.Text == "")
            {
                errorProvider_dest.SetError(textBox_cuentaDestino, "Por favor seleccione una cuenta destino.");
                vacio = true;
            }

            if (textBox_importe.Text == "")
            {
                errorProvider_importe.SetError(textBox_importe, "Por favor indique el importe a transferir.");
                vacio = true;
            }

            //salgo?
            if (vacio) return;

            if (tieneMasSaldoQue(textBox_cuentaOrigen.Text, textBox_importe.Text))
            {
                //descuento
                actualizarSaldo(textBox_cuentaOrigen.Text, "-" + textBox_importe.Text);
                //incremento
                actualizarSaldo(textBox_cuentaDestino.Text, textBox_importe.Text);

                //guardo 
                generarTransaccion(textBox_cuentaOrigen.Text, textBox_cuentaDestino.Text,textBox_importe.Text);
                guardarTransferencia();

                //limpio
                textBox_cuentaOrigen.Text = "";
                textBox_cuentaDestino.Text = "";
                textBox_importe.Text = "";
                comboBox_moneda.SelectedIndex = 0;
            }
        }

        private void textBox_importe_TextChanged(object sender, EventArgs e)
        {
            errorProvider_importe.Clear();
        }
    }
}