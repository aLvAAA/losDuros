using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Cliente
{
    public partial class SeleccionTarjeta : Form
    {
        private SqlConnection sqlCon = null;

        private String tarjeta = null;

        public SeleccionTarjeta()
        {
            InitializeComponent();
        }

        public SeleccionTarjeta(SqlConnection sqlCon) : this()
        {
            this.sqlCon = sqlCon;

            //se cargan las tarjetas
            cargarTarjetas();
        }

        void cargarTarjetas()
        {
            //limpio por las dudas
            comboBox_tarjetas.Items.Clear();

            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TAR_NUMERO FROM NETSTLE.TARJETA";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego nuevo item
                    comboBox_tarjetas.Items.Add(reader.GetString(0));
                }
                //mostramos por default el primer item
                comboBox_tarjetas.SelectedIndex = 0;
            }
            //libero
            reader.Close();
            cmd.Dispose();
        }

        public String getTarjetaSeleccionada()
        {
            return tarjeta;
        }

        private void button_aceptar_Click_1(object sender, EventArgs e)
        {
            tarjeta = comboBox_tarjetas.GetItemText(comboBox_tarjetas.SelectedItem);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
