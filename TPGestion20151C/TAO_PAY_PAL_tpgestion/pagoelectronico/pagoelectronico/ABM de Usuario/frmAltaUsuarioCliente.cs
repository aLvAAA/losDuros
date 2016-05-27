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
using System.Configuration;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class frmAltaUsuarioCliente : Form
    {
        public DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaActual"]);

        public frmAltaUsuarioCliente()
        {
            InitializeComponent();
        }

        private void btnSeguirAlta_Click(object sender, EventArgs e)
        {
            if (!Vista.CadenaVacia(txtUser) && !Vista.CadenaVacia(txtPass) && Vista.LongitudCadenaMayorA_N(txtUser, 5) && Vista.LongitudCadenaMayorA_N(txtPass, 5))
            {
                E_Usuario u = new E_Usuario(txtUser.Text, N_Cliente.GetSHA256(txtPass.Text).ToUpper(), fecha);
                if (!Vista.CadenaVacia(txtPsec) && !Vista.CadenaVacia(txtRsec))
                {
                    u.preguntaSecreta = txtPsec.Text;
                    u.respuestaSecreta = N_Cliente.GetSHA256(txtRsec.Text).ToUpper();
                }
                if (N_Cliente.Username_Duplicado(u.username))
                {
                    MessageBox.Show("El Username esta siendo usado por otro usuario", "Error de registro de Usuario");
                }
                else
                {
                    ABM_Cliente.frmABMCliente f = new PagoElectronico.ABM_Cliente.frmABMCliente();
                    f.u = u;
                    f.isAdmin = false;
                    f.user_id = 0;
                    f.tc_ABMcliente.TabPages.Remove(f.tabPage2);
                    f.tc_ABMcliente.TabPages.Remove(f.tabPage3);
                    this.Hide();
                    f.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("El username y la contraseña deben tener por lo menos 6 caracteres!! ", "Error de ingreso de datos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
