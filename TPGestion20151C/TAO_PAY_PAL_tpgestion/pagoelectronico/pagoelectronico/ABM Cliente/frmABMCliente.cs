using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using PagoElectronico.ENTIDADES;
using PagoElectronico.NEGOCIO;

namespace PagoElectronico.ABM_Cliente
{
    public partial class frmABMCliente : Form
    {
        public int user_id;
        public bool isAdmin;
        public DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaActual"]);
        public E_Usuario u = new E_Usuario();

        public frmABMCliente()
        {
            InitializeComponent();
            N_Cliente.CargarTipoDocumentos(cmbTipoDoc_a, cmbTipoDoc_m, cmbTipoDoc_L);
            N_Cliente.CargarPaises(cmbPais_a, cmbPais_m);
            N_Cliente.InicializarFechasCliente(dtpNacimiento, dtpNacimiento_m, fechaActual);
        }

        private void frmABMCliente_Load(object sender, EventArgs e)
        {
            if (!isAdmin && user_id !=0)
            {
                N_Cliente.Cargar_Datos_Cliente(lblNroUser, txtNom_m, txtApe_m, txtNroDoc_m, txtMail_m, txtCalle_m, txtNroCalle_m, txtPiso_m, txtDepto_m, cmbTipoDoc_m, cmbPais_m, dtpNacimiento_m, user_id);
                btnEditarOK.Enabled = true;
            }
            else if (isAdmin && user_id!=0)
            {
                if (dgvBusqueda.DataSource == null)
                {
                    btnHabilitarCliente.Enabled = false;
                    btnInhabilitarCliente.Enabled = false;
                    btnEditar.Enabled = false;
                }
            }
        }

        private void btnSalirABMcliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Pestaña de Alta
        private void txtNom_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtApe_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtNroDoc_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtCalle_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtNroCalle_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtPiso_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtDepto_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void btnLimpiar_A_Click(object sender, EventArgs e)
        {
            Vista.LimpiarAlta(txtNom_a,txtApe_a,txtNroDoc_a,txtMail_a,txtCalle_a,txtNroCalle_a,txtPiso_a,txtDepto_a,cmbTipoDoc_a,cmbPais_a,dtpNacimiento,fechaActual);
        }
        private void btnAltaOK_Click(object sender, EventArgs e)
        {
            if (txtNom_a.Text == "" || txtApe_a.Text == "" || txtNroDoc_a.Text == "" || !Vista.EsMailValido(txtMail_a.Text) || txtCalle_a.Text == "" || txtNroCalle_a.Text == "")
            {
                MessageBox.Show("Revise si los campos obligatorios estan completos y \nCon su respectivo formato", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                E_Cliente c = new E_Cliente();
                c.nombre = txtNom_a.Text;
                c.apellido = txtApe_a.Text;
                c.tipoDocDesc = cmbTipoDoc_a.Text;
                c.nroDoc = Convert.ToInt32(txtNroDoc_a.Text);
                c.mail = txtMail_a.Text;
                c.fechaNacimiento = dtpNacimiento.Value;
                c.pais = cmbPais_a.Text;
                c.domCalle = txtCalle_a.Text;
                c.domNro = Convert.ToInt32(txtNroCalle_a.Text);
                if (txtPiso_a.Text != "") c.domPiso = Convert.ToInt32(txtPiso_a.Text);
                if (txtDepto_a.Text != "") c.domDepto = txtDepto_a.Text;
                if (N_Cliente.Registrar_Cliente(u, c))
                {
                    if (user_id == 0)
                    {
                        this.Hide();
                        new Login.frmLogin().ShowDialog();
                    }
                    else
                    {
                        btnAltaOK.Enabled = false;
                    }
                }                
            }
        }
       
        #endregion

        #region Pestaña de Modificacion
        private void txtNom_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtApe_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtNroDoc_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtCalle_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtNroCalle_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtPiso_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtDepto_m_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void btnEditarOK_Click(object sender, EventArgs e)
        {
            if (txtNom_m.Text == "" || txtApe_m.Text == "" || txtMail_m.Text == "" || txtCalle_m.Text == "" || txtNroDoc_m.Text == "" || txtNroCalle_m.Text == "")
            {
                MessageBox.Show("Algunos campos estan vacios", "Datos Incompletos");
            }
            else
            {
                E_Cliente c = new E_Cliente();
                c.id = Convert.ToInt32(lblNroUser.Text);
                c.nombre = txtNom_m.Text;
                c.apellido = txtApe_m.Text;
                c.tipoDocDesc = cmbTipoDoc_m.Text;
                c.nroDoc = Convert.ToInt32(txtNroDoc_m.Text);
                c.pais = cmbPais_m.Text;
                c.mail = txtMail_m.Text;
                c.domCalle = txtCalle_m.Text;
                c.domNro = Convert.ToInt32(txtNroCalle_m.Text);
                c.fechaNacimiento = dtpNacimiento_m.Value;
                if (txtPiso_m.Text != "") c.domPiso = Convert.ToInt32(txtPiso_m.Text);
                if (txtDepto_m.Text != "") c.domDepto = txtDepto_m.Text;

                if (N_Cliente.Editar_Cliente(c))
                {
                    if (isAdmin)
                    {
                        Vista.LimpiarEdicion(lblNroUser, txtNom_m, txtApe_m, txtMail_m, txtNroDoc_m, txtCalle_m, txtNroCalle_m, txtPiso_m, txtDepto_m, cmbTipoDoc_m, cmbPais_m, dtpNacimiento_m, fechaActual);
                        tc_ABMcliente.SelectedIndex = 1;
                        btnFiltrar.PerformClick();
                    }
                    else
                    { btnSalirABMcliente.PerformClick(); }
                }
            }
        }
        #endregion

        #region Pestaña de Listado
        private void dgvBusqueda_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnHabilitarCliente.Enabled = true;
            btnInhabilitarCliente.Enabled = true;
        }
        private void txtNom_l_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtApe_l_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloLetra(e);
        }
        private void txtNroDoc_l_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void btnLimpiar_L_Click(object sender, EventArgs e)
        {
            new Vista().LimpiarListado(txtNom_l, txtApe_l, txtMail_l, txtNroDoc_l, cmbTipoDoc_L);
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            E_Cliente c = new E_Cliente();
            if (txtNom_l.Text != "") c.nombre = txtNom_l.Text;
            if (txtApe_l.Text != "") c.apellido = txtApe_l.Text;
            c.tipoDocDesc = cmbTipoDoc_L.Text;
            if (txtNroDoc_l.Text != "") c.nroDoc = Convert.ToInt32(txtNroDoc_l.Text);
            if (txtMail_l.Text != "") c.mail = txtMail_l.Text;
            N_Cliente.Listado_Clientes(c, dgvBusqueda);
            if (dgvBusqueda.RowCount > 0)
                btnEditar.Enabled = true;

        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            N_Cliente.Cargar_Datos_Cliente(lblNroUser, txtNom_m, txtApe_m, txtNroDoc_m,
                txtMail_m, txtCalle_m, txtNroCalle_m, txtPiso_m, txtDepto_m, cmbTipoDoc_m,
                cmbPais_m, dtpNacimiento_m, Convert.ToInt32(dgvBusqueda.CurrentRow.Cells[0].Value));
            tc_ABMcliente.SelectedIndex = 0;
            btnEditarOK.Enabled = true;
        }
        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            E_Cliente c = new E_Cliente();
            N_Cliente.Listado_Clientes(c, dgvBusqueda);
            if (dgvBusqueda.RowCount > 0)
                btnEditar.Enabled = true;
        }
        private void btnHabilitarCliente_Click(object sender, EventArgs e)
        {
            int i = dgvBusqueda.CurrentRow.Index;
            int id = Convert.ToInt32(dgvBusqueda.Rows[i].Cells[0].Value);
            if (dgvBusqueda.Rows[i].DefaultCellStyle.BackColor == Color.LightGreen)
            {
                MessageBox.Show("Cliente ya esta habilitado", "Error de Habilitarcion");
            }
            else
            {
                N_Cliente.Habilitar(id);
                btnFiltrar.PerformClick();
            }
        }
        private void btnInhabilitarCliente_Click(object sender, EventArgs e)
        {
            int i = dgvBusqueda.CurrentRow.Index;
            int id = Convert.ToInt32(dgvBusqueda.Rows[i].Cells[0].Value);
            if (dgvBusqueda.Rows[i].DefaultCellStyle.BackColor == Color.LightCoral)
            {
                MessageBox.Show("Cliente ya esta Inhabilitado", "Error de Inhabilitacion");
            }
            else
            {
                N_Cliente.Inhabilitar(id);
                btnFiltrar.PerformClick();
            }    
        }

        #endregion

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            frmTarjeta t = new PagoElectronico.ABM_Cliente.frmTarjeta();
            t.user_id = user_id;
            t.ShowDialog();
        }

        

        

    }
}
