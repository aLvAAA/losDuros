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

namespace PagoElectronico.Facturacion
{
    public partial class frmFacturacion : Form
    {
        // Atributos 
        public DateTime fecha;
        public int user_id;
        public bool isAdmin;
        Int64 factura = 0;
        double monto = 0;


        public frmFacturacion()
        {
            InitializeComponent();
        }

        // LOAD
        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                N_Factura.CargarDocumento(cmbDoc);
                btnDetalle.Enabled = false;
            }
            else
            {
                LimpiarFactura(lblFactura, lblFecha, lblID, lblNomApe, lblMail, lblTotal);
                lblID.Text = lblID.Text + user_id.ToString();
                factura = N_Factura.MostrarDatosCliente(user_id, lblNomApe, lblMail);
                lblFactura.Text += factura.ToString();
                N_Factura.MostrarDetallesFactura(user_id, dgvDepositos, dgvRetiros, dgvTransferencias, dgvCostos);
                btnFacturaOK.Enabled = true;
                monto = N_Factura.CalcularTotal(dgvCostos);
                lblTotal.Text += monto.ToString();
                if (monto == 0)
                {
                    MessageBox.Show("No tienes transacciones por facturar", "Resutado Facturacion");
                    this.Close();
                }
            }
            lblFecha.Text += fecha.ToString();
        }
        
 
        // LIMPIAR FILTROS
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNom.Text = "";
            txtApe.Text = "";
            txtMail.Text = "";
            txtNroDoc.Text = "";
            cmbDoc.SelectedIndex = 0;
        }


        // BUSCAR DEUDORES POR FILTRO
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            E_Cliente c = new E_Cliente();
            c.nombre = txtNom.Text;
            c.apellido = txtApe.Text;
            c.tipoDocDesc = cmbDoc.Text;
            if (txtNroDoc.Text != "") c.nroDoc = Convert.ToInt32(txtNroDoc.Text);
            c.mail = txtMail.Text;
            N_Factura.Mostrar_Deudores_Por_Filtro(c, dgvDeudores, btnDetalle);
        }
        
        
        // MOSTRAR TODOS LOS DEUDORES
        private void btnTodos_Click(object sender, EventArgs e)
        {
            N_Factura.Mostrar_Todos_Los_Deudores(dgvDeudores, btnDetalle);
        }
        

        // MOSTRAR LAS TRANSACCIONES Y MOVIMIENTOS HASTA ESA FECHA
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            LimpiarFactura(lblFactura, lblFecha, lblID, lblNomApe, lblMail, lblTotal);
            user_id = Convert.ToInt32(dgvDeudores.CurrentRow.Cells[0].Value);
            N_Factura.MostrarDetallesFactura(user_id, dgvDepositos, dgvRetiros, dgvTransferencias, dgvCostos);
            factura = N_Factura.MostrarDatosCliente(user_id, lblNomApe, lblMail);
            lblFactura.Text += factura.ToString();
            lblID.Text = lblID.Text + user_id.ToString();
            tcFacturacion.SelectedIndex = 0;
            btnFacturaOK.Enabled = true;
            monto = N_Factura.CalcularTotal(dgvCostos);
            lblTotal.Text += monto.ToString();
        }


        // EFECTUAR LA FACTURACION DE LAS TRANSACCIONES
        private void btnFacturaOK_Click(object sender, EventArgs e)
        {
            N_Factura.FacturarOK(user_id, factura, monto, fecha);
            dgvCostos.DataSource = null;
            dgvDepositos.DataSource = null;
            dgvRetiros.DataSource = null;
            dgvTransferencias.DataSource = null;
            LimpiarFactura(lblFactura, lblFecha, lblID, lblNomApe, lblMail, lblTotal);
            tcFacturacion.SelectedIndex = 1;
            btnFacturaOK.Enabled = false;
            btnTodos.PerformClick();
        }

        
        // SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /********************CAPITA DE PRESENTACION**********************/
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
        public static void LimpiarFactura(Label fact, Label fec, Label cli, Label nomape, Label mail, Label tot)
        {
            fact.Text = "Factura N° ";
            fec.Text = "Fecha: ";
            cli.Text = "ID ";
            nomape.Text = "Nombre y Apellido : ";
            mail.Text = "Mail: ";
            tot.Text = "Total a Pagar ";
        }

        // VALIDACIONES A CAMPOS DE ENTRADA
        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetra(e);
        }

        private void txtApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetra(e);
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloDigito(e);
        }

        


    }
}
