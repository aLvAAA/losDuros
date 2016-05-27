using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.NEGOCIO;

namespace PagoElectronico.Listados
{
    public partial class frmListados : Form
    {
        public frmListados()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListados_Load(object sender, EventArgs e)
        {
            cmbTrim.Enabled = false;
            cmbListado.Enabled = false;
            btnVerListado.Enabled = false;
        }

        private void soloNumeros(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Ingrese un año correcto", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void txtAño_TextChanged(object sender, EventArgs e)
        {
            if (añoValido())
            {
                cmbTrim.Enabled = true;
               
            }
            else
            {
                cmbTrim.SelectedIndex = -1;
                cmbTrim.Enabled = false;

                cmbListado.SelectedIndex = -1;
                cmbListado.Enabled = false;

                btnVerListado.Enabled = false;
            }
        }

        private bool añoValido()
        {
            if (txtAño.Text.Length == 4)  
            {
                if ((Convert.ToInt32(txtAño.Text)) > 1800)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Ingrese un año mayor a 1800", "Ayuda");
                }
               
            }
            return false;
        }

        private void cmbTrim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTrim.SelectedIndex >= 0)
            {
                cmbListado.Enabled = true;
            }
            else
            {
                cmbListado.SelectedIndex = -1;
                cmbListado.Enabled = false;

                btnVerListado.Enabled = false;
            }
        }

        private void cmbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListado.SelectedIndex >= 0)
            {
                btnVerListado.Enabled = true;
            }
            else
            {
                btnVerListado.Enabled = false;
            }
        }

        private void btnVerListado_Click(object sender, EventArgs e)
        {
            int trim = Convert.ToInt32(cmbTrim.Text);
            int año = Convert.ToInt32(txtAño.Text);

            dgvListado.DataSource = N_Listados.GenerarListado(trim, año, cmbListado.Text);

            if (dgvListado.RowCount == 0)
                MessageBox.Show("No se encontraron registros", "Info");
        }


    }
}
