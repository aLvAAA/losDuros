using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Consulta : Form
    {
        private SqlConnection sqlCon = null;

        private String usr = null;

        private String cuenta = null;

        public Consulta()
        {
            InitializeComponent();
        }

        public Consulta(SqlConnection sqlCon, String usr):this()
        {
            this.sqlCon = sqlCon;

            //se guarda el usuario logueado
            this.usr = usr;

            //se carga de combobox
            recuperarCuentasPropias(usr);

        }

        public Consulta(SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;

            //se carga de combobox
            recuperarTodasLasCuentas();
        }

        void recuperarCuentasPropias(String usr)
        {
            //limpio por las dudas
            comboBox_cuentas.Items.Clear();

            //consula
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CTA_NUMERO ";
            cmd.CommandText += "FROM NETSTLE.CUENTA JOIN NETSTLE.CLIENTE ";
            cmd.CommandText += "ON CTA_NRO_DOC_CLIENTE = CLI_NRO_DOCUMENTO AND CTA_TIPO_DOC_CLIENTE = CLI_TIPO_DOCUMENTO ";
            cmd.CommandText += "WHERE CLI_NOMBRE_USUARIO = '" + usr + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego las cuentas al combobox
                    comboBox_cuentas.Items.Add(reader.GetDecimal(0));
                }
                //mostramos por default el primer item
                comboBox_cuentas.SelectedIndex = 0;
            }
            //libero
            reader.Close();
            //libero
            cmd.Dispose();
        }

        void recuperarTodasLasCuentas()
        {
            //limpio por las dudas
            comboBox_cuentas.Items.Clear();

            //consula
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CTA_NUMERO ";
            cmd.CommandText += "FROM NETSTLE.CUENTA";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego las cuentas al combobox
                    comboBox_cuentas.Items.Add(reader.GetDecimal(0));
                }
                //mostramos por default el primer item
                comboBox_cuentas.SelectedIndex = 0;
            }
            //libero
            reader.Close();
            //libero
            cmd.Dispose();
        }

        private void button_consultar_Click(object sender, EventArgs e)
        {
            this.cuenta = comboBox_cuentas.GetItemText(comboBox_cuentas.SelectedItem);

            if (comboBox_cuentas.Items.Count == 0)
            {
                MessageBox.Show("No contiene cuentas para consultar.", "Saldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //nueva instancia
            Estado frmEst = new Estado(sqlCon, cuenta);

            frmEst.MdiParent = frmEst.MdiParent;
            this.Close();
            frmEst.Show();
        }

    }
}
