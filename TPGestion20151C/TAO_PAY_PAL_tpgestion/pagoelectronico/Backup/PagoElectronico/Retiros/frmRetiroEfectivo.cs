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
using System.Globalization;

namespace PagoElectronico.Retiros
{
    public partial class frmRetiroEfectivo : Form
    {
        public int user_id;
        public DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaActual"]);


        public frmRetiroEfectivo()
        {
            InitializeComponent();            
        }

        // ANTES DE REALIZAR UN DEPOSITO, SE CONTROLA SI ES UN CLIENTE HABILITADO
        private void frmRetiroEfectivo_Load(object sender, EventArgs e)
        {
            if (N_Cliente.Esta_Cliente_Habilitado(user_id))
            {
                N_Retiro.CargarCuentas(dgvCuentas, user_id, fecha);
                Vista.CargarBancos(cmbBanco);
            }
            else
            {
                MessageBox.Show("Cliente Inhabilitado, no puede realizar esta operacion", "Estado de Cliente incorrecto");
            }

        }

        
        // SALE DEL FORMULARIO
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // SE CONTROLA EL RESULTADO DEL RETIRO, SI ESTUVO BIEN MUESTRA EL CHEQUE
        private void btnRetiroOK_Click(object sender, EventArgs e)
        {            
            if (txtMonto.Text == "" || txtDoc.Text == "")
            {
                MessageBox.Show("Especifique un importe extraer y/o complete su numero de documento", "Error, Campos vacios");
            }
            else
            {
                Double montoEfectivo = double.Parse(txtMonto.Text, CultureInfo.InvariantCulture);
                if (montoEfectivo <= Convert.ToDouble(dgvCuentas.CurrentRow.Cells[3].Value))
                {
                    string rta;
                    E_Retiro r = new E_Retiro();
                    r.banco = cmbBanco.Text;
                    if (montoEfectivo > 0) r.monto = montoEfectivo;
                    r.cuenta = Convert.ToInt64(dgvCuentas.CurrentRow.Cells[0].Value);
                    r.fecha = fecha;
                    r.id = user_id;
                    if (txtDoc.Text != "") r.dni = Convert.ToInt32(txtDoc.Text);
                    rta = N_Retiro.RetirarEfectivo(r);
                    if (rta == "OK")
                    {
                        txtDoc.Text = "";
                        txtMonto.Text = "";
                        new frmComprobanteRetiro().ShowDialog();
                        N_Retiro.CargarCuentas(dgvCuentas, user_id, fecha);
                    }
                    else
                    {
                        MessageBox.Show(rta, "Resultado de Extraccion");
                    }
                }
                else
                {
                    MessageBox.Show("Importe Superior a lo disponible", "Saldo insufuciente");
                }
            }            
        }
                
        // CAMBIA LA ETIQUETA DE TIPO DE MONEDA CUANDO CAMBIA DE SELECCION DE CUENTA
        private void dgvCuentas_SelectionChanged(object sender, EventArgs e)
        {
            lblMoneda.Text = dgvCuentas.CurrentRow.Cells[2].Value.ToString();
        }      

        // RESTRICCION DE DATOS DE ENTRADA ... SOLO NUMEROS
        private void txtDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }

        // RESTRICCION DE DATOS DE ENTRADA ... SOLO TIPO MONEDA XXX.XX
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtMonto.Text.Length; i++)
            {
                if (txtMonto.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
    }
}
