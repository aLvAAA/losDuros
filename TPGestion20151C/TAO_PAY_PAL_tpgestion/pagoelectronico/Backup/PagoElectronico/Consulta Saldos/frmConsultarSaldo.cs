using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.NEGOCIO;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.Consulta_Saldos
{
    public partial class frmConsultarSaldo : Form
    {
        public frmConsultarSaldo()
        {
            InitializeComponent();
        }
        
        
        // Variables Locales
        public bool isAdmin;
        public int id_user;
        public DateTime fechaActual;
        
        
        // Load
        private void frmConsultarSaldo_Load(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                gbCuentasCliente.Visible = false;
                pSaldo.Location = new Point(10, 25);
                gbMovimientos.Location = new Point(10, 75);
                N_Saldo.cargarDocumentos(cmbTipoDoc);
                N_Saldo.cargarTipoMoneda(cmbTipoMon);
            }
            else
            {                
                N_Saldo.cargarCuentasCliente(id_user, dgvCuentasCliente, btnVerMov);
                if (dgvCuentasAdmin.Rows.Count > 0) btnVerMov.Enabled = true;
            }
        }

        
        // Cliente -- tabPage1
        private void btnVerMov_Click(object sender, EventArgs e)
        {
            string moneda;
            Int64 cuenta = Convert.ToInt64(dgvCuentasCliente.CurrentRow.Cells[0].Value);
            if (isAdmin)
            {
                moneda = dgvCuentasCliente.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                moneda = dgvCuentasCliente.CurrentRow.Cells[3].Value.ToString();

            }
            lblCuenta.Text = "Cuenta N° " + cuenta.ToString();
            N_Saldo.cargarLosUltimosCincoDepositos(dgvDepositos, cuenta);
            N_Saldo.cargarLosUltimosCincoRetiros(dgvRetiros, cuenta);
            N_Saldo.cargarLasUltimasDiezTransferencias(dgvTransf, cuenta);
            N_Saldo.mostrarSaldo(lblSaldo, cuenta, moneda);
        }

        
        // Administrador -- tabPage2
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtDoc.Text = "";
            txtCuenta.Text = "";
            cmbTipoDoc.SelectedIndex = 0;
            cmbTipoMon.SelectedIndex = 0;
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            E_Saldo s = new E_Saldo();
            if (txtID.Text != "") s.id = txtID.Text;
            if (txtNombre.Text != "") s.nombre = txtNombre.Text;
            if (txtApellido.Text != "") s.apellido = txtApellido.Text;
            if (txtMail.Text != "") s.mail = txtMail.Text;
            if (txtDoc.Text != "") s.nroDoc = txtDoc.Text;
            if (txtCuenta.Text != "") s.cta = txtCuenta.Text;
            s.tipoDoc = cmbTipoDoc.Text;
            s.moneda = cmbTipoMon.Text;
            N_Saldo.cargarCuentasAdminConFiltros(btnLimpiar, dgvCuentasAdmin, s);
            if (dgvCuentasAdmin.RowCount > 0)
            {
                btnConsultar.Enabled = true;
            }
            else
            {
                btnConsultar.Enabled = false;
            }
        }
        private void btnCuentasGlobales_Click(object sender, EventArgs e)
        {
            N_Saldo.cargarCuentasAdminGlobales(dgvCuentasAdmin);
            if (dgvCuentasAdmin.RowCount > 0)
            {
                btnConsultar.Enabled = true;
            }
            else
            {
                btnConsultar.Enabled = false;
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dgvCuentasAdmin.RowCount == 0)
            {
                MessageBox.Show("No hay cuentas cargadas", "Atencion");
            }
            else
            {
                lblCuenta.Text = "Cuenta: ";
                lblSaldo.Text = "Saldo: ";
                tcMovimientos.SelectedIndex = 0;
                Int64 cuenta = Convert.ToInt64(dgvCuentasAdmin.CurrentRow.Cells[0].Value);
                string moneda = dgvCuentasAdmin.CurrentRow.Cells[5].Value.ToString();
                tcSaldo.SelectedIndex = 0;
                lblCuenta.Text = lblCuenta.Text + " " + cuenta.ToString();
                N_Saldo.cargarLosUltimosCincoDepositos(dgvDepositos, cuenta);
                N_Saldo.cargarLosUltimosCincoRetiros(dgvRetiros, cuenta);
                N_Saldo.cargarLasUltimasDiezTransferencias(dgvTransf, cuenta);
                N_Saldo.mostrarSaldo(lblSaldo, cuenta, moneda); 
            }
            
        }

        
        // Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        
        // Validaciones de Entrada de datos
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloDigito(e);
        }
        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloDigito(e);
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetra(e);
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetra(e);
        }
        private void txtDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloDigito(e);
        }

        
        /*******************CAPITA PRESENTACION******************************/
        public static void SoloDigito(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de tipeo");
            }
        }
        public static void SoloLetra(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de tipeo");
            }
        }

    }
}
