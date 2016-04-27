using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Devolucion
{
    public partial class IngresoPNR : Form
    {
        public IngresoPNR()
        {
            InitializeComponent();
        }
        
        private void siguiente_Click(object sender, EventArgs e)
        {
            //Validar pnr
            String pnrString = pnrBox.Text;
            decimal pnr = -1;
            if (!string.IsNullOrWhiteSpace(pnrString) && !Decimal.TryParse(pnrString, out pnr))
            {
                MessageBox.Show("El PNR es invalido!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Chequear que exista la compra
            GD2C2015DataSetTableAdapters.CompraTableAdapter compraAdapter = new GD2C2015DataSetTableAdapters.CompraTableAdapter();
            if (compraAdapter.GetData().FindBycompra_id(pnr) == null)
            {
                MessageBox.Show("No existe una compra asociada a ese PNR", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Devolucion.DetallesDevolucion a = new Devolucion.DetallesDevolucion(pnr);
            a.Show();
            this.Close();
        }
    }
}
