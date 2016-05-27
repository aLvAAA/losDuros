using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PagoElectronico.ENTIDADES;
using PagoElectronico.NEGOCIO;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class frmABMCuenta : Form
    {
        // ATRIBUTOS LOCALES
        public int id;
        public DateTime fecha;
        public bool isAdmin;
        Int64 cuenta;        
        
        // CONSTRUCTOR
        public frmABMCuenta()
        {
            InitializeComponent();
        }



        // SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // LOAD
        private void frmABMCuenta_Load(object sender, EventArgs e)
        {
            btnSeleccionarCliente.Enabled = false;
            //N_Cuenta.Actualizar_Cuentas_al_Dia_de_Hoy(fecha);
            if (isAdmin)
            {
                tcCuentas.SelectedIndex = 3;
                tcCuentas.TabPages.Remove(tabPage5);
                N_Cuenta.Cargar_Comboboxs_Admin(cmbPais1, cmbMon1,cmbCat3, cmbEstado3, cmbDoc);                
            }
            else
            {                
                tcCuentas.SelectedIndex = 4;
                tcCuentas.TabPages.Remove(tabPage3);
                tcCuentas.TabPages.Remove(tabPage4);
                N_Cuenta.Cargar_Combobox_Cliente(cmbPais1, cmbMon1);
                N_Cuenta.Mostrar_Cuentas_Un_Cliente(id, dgvCuentasCliente);
                if (dgvCuentasCliente.Rows.Count > 0)
                {
                    btnEditarC.Enabled = true;
                    btnBajarC.Enabled = true;
                }                
            }
            N_Cuenta.cargarComboboxCategoria(cmbCat1, "migracion", "migracion");
        }

        // LIMPIAR FILTROS CLIENTES
        private void btnLimpiarFiltro1_Click(object sender, EventArgs e)
        {
            txtNom.Text = "";
            txtApe.Text = "";
            txtMail.Text = "";
            txtNroDoc.Text = "";
            cmbDoc.SelectedIndex = 0;
        }

        // LIMPIAR FILTROS CUENTAS
        private void btnLimpiarFiltro2_Click(object sender, EventArgs e)
        {
            txtNomC.Text = "";
            txtApeC.Text = "";
            txtIdC.Text = "";
            cmbCat3.SelectedIndex = 0;
            cmbEstado3.SelectedIndex = 0;
        }

        // FILTRAR CUENTAS
        private void btnFiltrarCuentas_Click(object sender, EventArgs e)
        {
            N_Cuenta.Mostrar_Cuentas_X_Filtro(dgvCuentasAdmin, txtIdC.Text, txtNomC.Text, txtApeC.Text, cmbCat3.Text, cmbEstado3.Text);
            if (dgvCuentasAdmin.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnBajarOK.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnBajarOK.Enabled = false;
            }
            btnLimpiarFiltro2.PerformClick();
        }

        // MOSTRAR CUENTAS GLOBALES
        private void btnTodasCuentas_Click(object sender, EventArgs e)
        {
            N_Cuenta.Mostrar_Cuentas_Globales(dgvCuentasAdmin);
            if (dgvCuentasAdmin.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnBajarOK.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnBajarOK.Enabled = false;
            }
            btnLimpiarFiltro2.PerformClick();
        }

        // NUEVA CUENTA AMDIN INICIAR
        private void btnNueva_Click(object sender, EventArgs e)
        {
            tcCuentas.SelectedIndex = 2;
            btnFiltrarClientes.Enabled = true;
            btnClientesGlobales.Enabled = true;
        }

        // NUEVA CUENTA FIN
        private void btnAltaOK_Click(object sender, EventArgs e)
        {
            N_Cuenta.Alta_Cuenta(btnAltaOK, id, fecha, cmbCat1.Text, cmbPais1.Text, cmbMon1.Text, Convert.ToInt32(nudSuscrip1.Value));
            if (isAdmin)
            {
                tcCuentas.SelectedIndex = 3;
                N_Cuenta.Mostrar_Cuentas_Globales(dgvCuentasAdmin);
            }
            else
            {
                tcCuentas.SelectedIndex = 2;
                N_Cuenta.Mostrar_Cuentas_Un_Cliente(id, dgvCuentasCliente);
            }
        }

        // EDITAR CUENTA INICIAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Color fila = dgvCuentasAdmin.CurrentRow.DefaultCellStyle.BackColor;
            if (fila == Color.Gold || fila == Color.LightSalmon || fila == Color.SkyBlue)
            {
                MessageBox.Show("No se puede editar una cuenta pendiente de activacion o inhabilitada o cerrada", "Restriccion de Edicion");
            }
            else
            {
                cuenta = Convert.ToInt64(dgvCuentasAdmin.CurrentRow.Cells[0].Value);
                lblCuenta.Text = "Cuenta: " + cuenta.ToString();
                tcCuentas.SelectedIndex = 1;
                N_Cuenta.cargarComboboxCategoria(cmbCat2,dgvCuentasAdmin.CurrentRow.Cells[3].Value.ToString(),"migracion");
                btnEdicionOK.Enabled = true;
            }
        }

        // EDITAR CUENTA FIN
        private void btnEdicionOK_Click(object sender, EventArgs e)
        {
            N_Cuenta.Editar_Cuenta(btnEdicionOK, cuenta, fecha, cmbCat2.Text, Convert.ToInt32(nudSuscrip2.Value));
            if (isAdmin)
            {
                tcCuentas.SelectedIndex = 3;
                //N_Cuenta.Cargar_Comboboxs_Admin(cmbCat1, cmbPais1, cmbMon1, cmbCat2, cmbCat3, cmbEstado3, cmbDoc);
                N_Cuenta.Mostrar_Cuentas_Globales(dgvCuentasAdmin);                
            }
            else
            {
                tcCuentas.SelectedIndex = 2;
                N_Cuenta.Mostrar_Cuentas_Un_Cliente(id, dgvCuentasCliente);
                //N_Cuenta.Cargar_Combobox_Cliente(cmbCat1, cmbPais1, cmbMon1, cmbCat2);
            }
            cmbCat2.DataSource = null;
        }

        // MOSTRAR FILTRO CLIENTES
        private void btnFiltrarClientes_Click(object sender, EventArgs e)
        {
            N_Cuenta.Buscar_Clientes_por_Filtro(txtNom.Text, txtApe.Text, txtMail.Text, cmbDoc.Text, txtNroDoc.Text, dgvClientes, btnSeleccionarCliente);
            btnLimpiarFiltro1.PerformClick();
            if (dgvClientes.RowCount > 0) btnSeleccionarCliente.Enabled = true;
        }

        //MOSTRAR CLIENTES GLOBALES
        private void btnClientesGlobales_Click(object sender, EventArgs e)
        {
            N_Cuenta.Buscar_Clientes_Globales(dgvClientes, btnSeleccionarCliente);
            btnLimpiarFiltro1.PerformClick();
            if (dgvClientes.RowCount > 0) btnSeleccionarCliente.Enabled = true;
        }

        // SELECCIONAR CLIENTE DE LA CUENTA
        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            tcCuentas.SelectedIndex = 0;
            btnAltaOK.Enabled = true;
        }

        // NUEVA CUENTA INICIO CLIENTE
        private void btnNuevaC_Click(object sender, EventArgs e)
        {
            tcCuentas.SelectedIndex = 0;
            btnAltaOK.Enabled = true;
        }

        // EDITAR CUENTA CLIENTE INICIO
        private void btnEditarC_Click(object sender, EventArgs e)
        {
            Color fila = dgvCuentasCliente.CurrentRow.DefaultCellStyle.BackColor;
            if (fila == Color.Gold || fila == Color.SkyBlue || fila == Color.LightSalmon)
            {
                MessageBox.Show("No se puede editar a una cuenta pendiente de activacion o inhabilitada o cerrada", "Edicion fallida");
            }
            else
            {
                tcCuentas.SelectedIndex = 1;
                cuenta = Convert.ToInt64(dgvCuentasCliente.CurrentRow.Cells[0].Value);
                lblCuenta.Text = "Cuenta: " + cuenta.ToString();
                N_Cuenta.cargarComboboxCategoria(cmbCat2,dgvCuentasCliente.CurrentRow.Cells[1].Value.ToString(),"migracion");
                btnEdicionOK.Enabled = true;
            }
        }

        // BAJA CUENTA CLIENTE
        private void btnBajarC_Click(object sender, EventArgs e)
        {
            Color fila = dgvCuentasCliente.CurrentRow.DefaultCellStyle.BackColor;
            if (fila == Color.Gold || fila == Color.SkyBlue || fila == Color.LightSalmon)
            {
                MessageBox.Show("No se puede editar a una cuenta pendiente de activacion o inhabilitada o cerrada", "Error de baja");
            }
            else
            {
                cuenta = Convert.ToInt64(dgvCuentasCliente.CurrentRow.Cells[0].Value);
                N_Cuenta.Baja_Cuenta(cuenta, fecha);
                N_Cuenta.Mostrar_Cuentas_Un_Cliente(id, dgvCuentasCliente);
            }
        }

        // BAJA CUENTA ADMIN
        private void btnBajarOK_Click(object sender, EventArgs e)
        {
            Color fila = dgvCuentasAdmin.CurrentRow.DefaultCellStyle.BackColor;
            if (fila == Color.Gold || fila == Color.LightSalmon || fila == Color.SkyBlue)
            {
                MessageBox.Show("No se puede dar de baja una cuenta no habilitada", "Restriccion de Baja");
            }
            else
            {
                cuenta = Convert.ToInt64(dgvCuentasAdmin.CurrentRow.Cells[0].Value);
                N_Cuenta.Baja_Cuenta(cuenta, fecha);
                N_Cuenta.Mostrar_Cuentas_Globales(dgvCuentasAdmin);
            }
        }



       





    }
}
