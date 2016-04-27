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
    public partial class SeleccionTarjetaVencida : Form
    {
        private SqlConnection sqlCon = null;

        private String tarjeta = null;

        public SeleccionTarjetaVencida()
        {
            InitializeComponent();
        }

        public SeleccionTarjetaVencida(SqlConnection sqlCon) : this()
        {
            this.sqlCon = sqlCon;

            //se cargan las tarjetas
            cargarTarjetasVencidas();
        }

        void cargarTarjetasVencidas()
        {
            //limpio por las dudas
            comboBox_tarjetas.Items.Clear();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            //consulta
            SqlCommand cmd = new SqlCommand();
            /*SELESC DE TARJETAS VENCIDAS*/
            cmd.CommandText = "SELECT TAR_NUMERO FROM NETSTLE.TARJETA WHERE ";
            cmd.CommandText += "TAR_FECHA_VENCIMIENTO < " + "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + " AND TAR_ELIMINADA = 0";
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

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            tarjeta = comboBox_tarjetas.GetItemText(comboBox_tarjetas.SelectedItem);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
