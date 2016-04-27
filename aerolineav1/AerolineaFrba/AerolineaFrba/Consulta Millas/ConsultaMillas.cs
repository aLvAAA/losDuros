using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaMillas : Form
    {
        private GD2C2015DataSetTableAdapters.CanjeTableAdapter CanjeMillasAdapter;
        GD2C2015DataSet.CanjeDataTable CanjeMillasData;

        public ConsultaMillas()
        {
            InitializeComponent();
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
           dniBox.Text = "";
           millas.Visible = false;
        }

        //Buscar
        private void buscar_Click(object sender, EventArgs e)
        {
            //Validar dni
            String dniString = dniBox.Text;
            decimal dni;
            if (string.IsNullOrWhiteSpace(dniString) || !Decimal.TryParse(dniString, out dni))
            {
                MessageBox.Show("El dni debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dniBox.BackColor = Color.Red;
                return;
            }
            else
            {
                //Mostrar millas
                CanjeMillasAdapter = new GD2C2015DataSetTableAdapters.CanjeTableAdapter();

                millas.Visible = true;
                millas.Text = "Total Millas :" + CanjeMillasAdapter.ConsultaMillas(dni).ToString();
            }
            
        }
                
        private void encomiendasLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dniBox.Text))
            {
                AerolineaFrba.Consulta_Millas.DetalleEncomienda d = new AerolineaFrba.Consulta_Millas.DetalleEncomienda(dniBox.Text);
                d.Show();
            }
            else MessageBox.Show("Debe ingresar un dni");
        }

        private void viajesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dniBox.Text))
            {
                //Redirijo a lista viajes
                AerolineaFrba.Consulta_Millas.DetalleViaje v = new AerolineaFrba.Consulta_Millas.DetalleViaje(dniBox.Text);
                v.Show();
            }
            else MessageBox.Show("Debe ingresar un dni");
        }

        private void canjesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dniBox.Text))
            {
                //Redirijo a lista Canjes
                AerolineaFrba.Consulta_Millas.DetalleCanje c = new AerolineaFrba.Consulta_Millas.DetalleCanje(dniBox.Text);
                c.Show();
            }
            else MessageBox.Show("Debe ingresar un dni");
        }

    }
}
