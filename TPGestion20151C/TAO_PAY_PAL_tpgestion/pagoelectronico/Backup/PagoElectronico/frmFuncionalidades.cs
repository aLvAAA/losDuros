using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PagoElectronico.ABM_Rol;
using PagoElectronico.Listados;
using PagoElectronico.Login;
using PagoElectronico.NEGOCIO;

namespace PagoElectronico
{
    public partial class frmFuncionalidades : Form
    {
        public int user_id;
        public bool isAdmin;
        private frmLogin login;

        public frmLogin Login
        {
            get { return login; }
            set { login = value; }
        }
        public DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fechaActual"]);

        public frmFuncionalidades(char rol)
        {
            InitializeComponent();
            //mostrarBotones(rol);
           
        }

        private void btnAbmRol_Click(object sender, EventArgs e)
        {
            new frmAbmRol().ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Registrar el horario de la salida del usuario antes de salir de la aplicacion

            this.Close();
            login.Show();
        }

        private void btnABMclientes_Click(object sender, EventArgs e)
        {
            ABM_Cliente.frmABMCliente f = new ABM_Cliente.frmABMCliente();
            f.user_id = user_id;
            if (isAdmin)
            {
                f.isAdmin = isAdmin;
                f.tc_ABMcliente.TabPages.Remove(f.tabPage1);
                f.tc_ABMcliente.SelectedIndex = 1;
            }
            else
            {
                f.isAdmin = isAdmin;
                f.tc_ABMcliente.TabPages.Remove(f.tabPage1);
                f.tc_ABMcliente.TabPages.Remove(f.tabPage3);
                f.tc_ABMcliente.SelectedIndex = 1;
            }            
            f.ShowDialog();
        }

        private void btnRetiroEfectivo_Click(object sender, EventArgs e)
        {
            Retiros.frmRetiroEfectivo r = new Retiros.frmRetiroEfectivo();
            r.user_id = user_id;
            r.ShowDialog();
        }

        private void btnFacturarCostos_Click(object sender, EventArgs e)
        {
            Facturacion.frmFacturacion f = new PagoElectronico.Facturacion.frmFacturacion();
            f.fecha = fecha;
            if (isAdmin)
            {
                f.tcFacturacion.SelectedIndex = 1;
                f.btnFacturaOK.Enabled = false;
            }
            else
            {
                f.tcFacturacion.TabPages.Remove(f.tcFacturacion.TabPages[1]);
                f.user_id = user_id;
            }
            f.isAdmin = isAdmin;
            f.ShowDialog();
        }

        private void btnTarCliente_Click(object sender, EventArgs e)
        {
            ABM_Cliente.frmTarjeta t = new PagoElectronico.ABM_Cliente.frmTarjeta();
            t.user_id = user_id;
            t.ShowDialog();
        }

        private void mostrarBotones(char rol)
        {
            switch (rol)
            {
                case 'c':
                    btnABMCuentas.Visible = true;
                    btnConsultaSaldo.Visible = true;
                    btnTarCliente.Visible = true;
                    btnRetiroEfectivo.Visible = true;
                    btnDepositos.Visible = true;
                    btnTransferencia.Visible = true;
                    btnFacturarCostos.Visible = true;
                    
                    break;
                case 'a':
                    btnConsultaSaldo.Visible = true;
                    btnABMCuentas.Visible = true;
                    btnFacturarCostos.Visible = true;
                    btnAbmRol.Visible = true;
                    btnABMclientes.Visible = true;
                    btnListado.Visible = true;
                    break;
                default:
                    Console.WriteLine("Rol no implementado");
                    break;
            }

        }

        private void btnConsultaSaldo_Click(object sender, EventArgs e)
        {
            Consulta_Saldos.frmConsultarSaldo f = new PagoElectronico.Consulta_Saldos.frmConsultarSaldo();
            if (isAdmin)
            {
                f.tcSaldo.SelectedIndex = 1;
            }
            else
            {
                f.tcSaldo.SelectedIndex = 0;
                f.tcSaldo.TabPages.Remove(f.tabPage2);
            }
            f.isAdmin = isAdmin;
            f.id_user = user_id;
            f.fechaActual = fecha;
            f.ShowDialog();
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            Transferencias.Transferencia transf = new PagoElectronico.Transferencias.Transferencia(user_id);
            transf.ShowDialog();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            new frmListados().ShowDialog();
        }

        private void btnABMCuentas_Click(object sender, EventArgs e)
        {
            ABM_Cuenta.frmABMCuenta f = new PagoElectronico.ABM_Cuenta.frmABMCuenta();
            f.isAdmin = isAdmin;
            f.fecha = fecha;
            if (!isAdmin) f.id = user_id;
            f.ShowDialog();
        }

        private void btnDepositos_Click(object sender, EventArgs e)
        {
            Depositos.frmDepositos d = new PagoElectronico.Depositos.frmDepositos();
            d.id = user_id;
            d.fecha = fecha;
            d.ShowDialog();
        }

        private void frmFuncionalidades_Load(object sender, EventArgs e)
        {
            N_Cuenta.Actualizar_Cuentas_al_Dia_de_Hoy(fecha); //ACTUALIZA LAS CUENTAS
            N_Tarjeta.ActualizarTarjetas(fecha);

            DataTable dtFuncionalidades;

            //Valido mientras no se pueda acceder con un rol distinto a admin o cliente
            //Se tiene en cuenta que como el enunciano no pide abm de user es correcto
            if (isAdmin)
            {
                dtFuncionalidades = N_Rol.GetFuncionalidades(1);
            }
            else
            {
                dtFuncionalidades = N_Rol.GetFuncionalidades(2);
                btnTarCliente.Visible = true;
            }

            //Por cada funcionalidad habilito el boton que le corresponde
            foreach (DataRow funcionalidad in dtFuncionalidades.Rows)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Button)
                    {
                        if (c.Text == (funcionalidad[1].ToString()))
                        {
                            c.Visible = true;
                        }
                            
                        
                    }
                } 
               
            }             
        }

       
    }
}
