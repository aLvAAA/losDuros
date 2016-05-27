using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.NEGOCIO;

namespace PagoElectronico.Depositos
{
    public partial class frmComprobanteDepo : Form
    {
        public frmComprobanteDepo()
        {
            InitializeComponent();
        }

        // ATRIBUTOS
        public int id;

        // SALIR
        private void btnVolverDepo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // LOAD
        private void frmComprobanteDepo_Load(object sender, EventArgs e)
        {
            N_Depositos.Cargar_Comprobante(id, lblFecha, lblDepoCod, lblCuenta, lblCliente, lblDineroDepo);

        }
    }
}
