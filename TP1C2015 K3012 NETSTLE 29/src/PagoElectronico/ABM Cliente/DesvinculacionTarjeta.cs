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
    public partial class DesvinculacionTarjeta : Form
    {
        private SqlConnection sqlCon = null;

        public DesvinculacionTarjeta()
        {
            InitializeComponent();
        }

        public DesvinculacionTarjeta(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            //nueva instancia
            SeleccionTarjetaVencida frmCal = new SeleccionTarjetaVencida(sqlCon);

            //muestro
            if (frmCal.ShowDialog() == DialogResult.Yes)
            {
                //recupero tarjeta
                textBox_tarjeta.Text = frmCal.getTarjetaSeleccionada();
                //errorProvider_fecha.Clear();
            }

            //libero
            frmCal.Dispose();  
        }

        private void textBox_tarjeta_TextChanged(object sender, EventArgs e)
        {
            errorProvider_tarjeta.Clear();
        }

        private void button_desvincular_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_tarjeta.Text == "")
            {
                errorProvider_tarjeta.SetError(textBox_tarjeta, "Por favor ingrese el nombre de usuario.");
                vacio = true;
            }

            //me las tomo?
            if (vacio) return;

            //elimino tarjeta
            eliminarTarjeta();
        }

        private void eliminarTarjeta()
        {
            //update
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.TARJETA SET ";
            cmd.CommandText += "TAR_ELIMINADA = '1'";
            cmd.CommandText += "WHERE TAR_NUMERO = '" + textBox_tarjeta.Text + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al eliminar la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Se ha guardado la modificacion.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
        }

    }

}
