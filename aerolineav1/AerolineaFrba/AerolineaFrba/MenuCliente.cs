using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class InicioCliente : Form
    {
        public InicioCliente()
        {
            InitializeComponent();
        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultaSaldo_Click(object sender, EventArgs e)
        {

        }

        private void operacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compraPasajeencomiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_Pasaje.Form1 a = new Compra_Pasaje.Form1();
            a.Show();
        }

        private void consultaDeMillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Millas.ConsultaMillas cm = new Consulta_Millas.ConsultaMillas();
            cm.Show();
        }

        private void canjeDeMillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canje_Millas.CanjeMillas a = new Canje_Millas.CanjeMillas();
            a.Show();
        }

    }
}
