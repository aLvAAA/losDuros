using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using PagoElectronico.NEGOCIO;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.ABM_Cliente
{
    public partial class frmTarjeta : Form
    {
    #region Variables Locales
        public int user_id;
        public DateTime FechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaActual"]);

    #endregion 

        public frmTarjeta()
        {
            InitializeComponent();
            dtpEmisor_a.MaxDate = FechaActual; // la fecha de emision de tarjeta es hasta la fecha actual...
            dtpEmisor_a.Value = FechaActual;
            dtpVenc_a.MinDate = FechaActual.AddDays(1); // las fechas de vencimiento de tarjetas comienzan a partir de un dia despues
            cmbEmisor.SelectedIndex = 0; // muestro en el combobox el primer emisor
            //N_Tarjeta.ActualizarTarjetas(FechaActual); // actualiza la base de las tarjetas hasta el dia de hoy
            N_Tarjeta.Cargar_Tarjetas_Cliente_X(cmbTarjeta_Edit, cmbTarjeta_Baja, user_id); // muestra las tarjetas en los combobox, que no fueron desvinculadas...
        }
                
        private void tcTarjeta_Selecting(object sender, TabControlCancelEventArgs e)
        {
            N_Tarjeta.Cargar_Tarjetas_Cliente_X(cmbTarjeta_Edit, cmbTarjeta_Baja, user_id);
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        #region asociar
        private void txtNroTar_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtNroTar_a_TextChanged(object sender, EventArgs e)
        {
            txtNroTar_a.MaxLength = 16;
        }
        private void txtSeguridad_a_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtSeguridad_a_TextChanged(object sender, EventArgs e)
        {
            txtSeguridad_a.MaxLength = 3;
        }
        private void btnAsociarTarjeta_Click(object sender, EventArgs e)
        {
            string estado = null;
            E_Tarjeta t = new E_Tarjeta();
            if (txtNroTar_a.Text == "" || txtSeguridad_a.Text == "")
            {
                MessageBox.Show("Ingrese la informacion necesaria", "Campos vacios", MessageBoxButtons.OK);
            }
            else
            {
                if (txtNroTar_a.Text.Length < 16)
                {
                    estado = "Deben ser 16 digitos el numero de la tarjeta";
                }
                else
                {
                    t.Codigo = txtNroTar_a.Text;
                    t.user_id = user_id;
                    t.emisor = cmbEmisor.Text;
                    t.fechaEmision = dtpEmisor_a.Value;
                    t.fechaVencimiento = dtpVenc_a.Value;
                    if (txtSeguridad_a.Text.Length < 3 || txtSeguridad_a.Text == "")
                    {
                        estado = "Deben ser 3 digitos el codigo de seguridad";
                    }
                    else
                    {
                        t.seguridad = txtSeguridad_a.Text;
                        estado = N_Tarjeta.asociarTarjeta(t);
                    }
                }
                if (estado == null)
                {
                    btnLimpiar.PerformClick(); // hace un clic al boton limpiar del alta ...
                    MessageBox.Show("Asociacion Existosa", "Resultado de Asociacion de Tarjeta");
                }
                else
                {
                    MessageBox.Show(estado, "Resultado de Asociacion de Tarjeta");
                }
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNroTar_a.Text = "";
            cmbEmisor.SelectedIndex = 0;
            dtpEmisor_a.Value = FechaActual;
            dtpVenc_a.Value = FechaActual.AddDays(1);
            txtSeguridad_a.Text = "";
        }
        #endregion


        #region modificar

        private void cmbTarjeta_Edit_SelectedIndexChanged(object sender, EventArgs e)
        {
            N_Tarjeta.cargarCampos(lblNewDate, lblEstado, user_id, cmbTarjeta_Edit.Text);            
            if (Convert.ToDateTime(lblNewDate.Text) < FechaActual)
            {
                dtpNewDate.MinDate = FechaActual.AddDays(1);
                dtpNewDate.Value = FechaActual.AddDays(1);
            }
            else 
            {
                dtpNewDate.MinDate = (Convert.ToDateTime(lblNewDate.Text)).AddDays(1);
                dtpNewDate.Value = (Convert.ToDateTime(lblNewDate.Text)).AddDays(1);
            }            
        }
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void txtNewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }        
        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.MaxLength = 3;
        }
        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            txtNewPass.MaxLength = 3;
        }
        private void rbSeguridad_Click(object sender, EventArgs e)
        {
            rbVencimiento.Checked = false;
            dtpNewDate.Enabled = false;
            txtPass.Enabled = true;
            txtNewPass.Enabled = true;
        }
        private void rbVencimiento_Click(object sender, EventArgs e)
        {
            rbSeguridad.Checked = false;
            dtpNewDate.Enabled = true;
            txtPass.Text = "";
            txtNewPass.Text = "";
            txtPass.Enabled = false;
            txtNewPass.Enabled = false;
        }
        private void btnEditarTarjeta_Click(object sender, EventArgs e)
        {
            string rta;
            E_Tarjeta t = new E_Tarjeta();
            t.user_id = user_id;
            t.Codigo = cmbTarjeta_Edit.Text;
            if (rbVencimiento.Checked)
            {
                t.fechaVencimiento = dtpNewDate.Value;
                rta = (N_Tarjeta.EditarTarjeta(t) == "OK") ? "Vencimiento Actualizado" : "No se pudo actualizar vencimiento";
            }
            else
            {
                t.fechaVencimiento = Convert.ToDateTime(lblNewDate.Text);
                if (txtPass.Text.Length < 3 || txtNewPass.Text.Length < 3)
                {
                    rta = "Codigo/s de seguridad incorrecto/s, verifique que son 3 digitos";
                }
                else
                {
                    t.seguridad = txtPass.Text;
                    t.seguridadNueva = txtNewPass.Text;
                    rta = (N_Tarjeta.EditarTarjeta(t) == "OK") ? "Codigo seguridad Actualizado" : "Codigo Seguridad Incorrecto";
                }
            }
            MessageBox.Show(rta,"Resultado de Edición de Tarjeta");
            if (rta == "Vencimiento Actualizado" || rta == "Codigo seguridad Actualizado")
                N_Tarjeta.Cargar_Tarjetas_Cliente_X(cmbTarjeta_Edit, cmbTarjeta_Baja, user_id);

            rbVencimiento.PerformClick();            
        }
        #endregion


        #region desasociar
        private void txtPass_Baja_TextChanged(object sender, EventArgs e)
        {
            txtPass_Baja.MaxLength = 3;
        }
        private void txtPass_Baja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }
        private void btnDesasociarTarjeta_Click(object sender, EventArgs e)
        {
            string rta = null;
            if (txtPass_Baja.Text.Length < 3)
            {
                MessageBox.Show("Ingrese los 3 digitos del Codigo de Seguridad para Desasociar la Tarjeta", "Validacion de Campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                E_Tarjeta t = new E_Tarjeta();
                t.user_id = user_id;
                t.Codigo = cmbTarjeta_Baja.Text;
                t.seguridad = txtPass_Baja.Text;
                rta = N_Tarjeta.DesasociarTarjeta(t, FechaActual);
                if (rta == null)
                {
                    MessageBox.Show("Desasociacion de Tarjeta realizada Exitosamente", "Resultado de Desasociacion de Tarjeta", MessageBoxButtons.OK);
                    N_Tarjeta.Cargar_Tarjetas_Cliente_X(cmbTarjeta_Edit, cmbTarjeta_Baja, user_id);
                }
                else
                {
                    MessageBox.Show(rta, "Resultado de Desasociacion de Tarjeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtPass_Baja.Text = "";
            }
        }
        #endregion

        private void frmTarjeta_Load(object sender, EventArgs e)
        {
            lblFechaSistema.Text = FechaActual.ToString();
        }

        
   
    }
}
