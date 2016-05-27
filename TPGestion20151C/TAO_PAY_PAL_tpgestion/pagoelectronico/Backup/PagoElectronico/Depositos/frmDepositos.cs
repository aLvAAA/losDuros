using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.NEGOCIO;
using System.Globalization;

namespace PagoElectronico.Depositos
{
    public partial class frmDepositos : Form
    {
        public frmDepositos()
        {
            InitializeComponent();
        }

        //  ATRIBUTOS
        public int id;
        public DateTime fecha;

        // LOAD
        private void frmDepositos_Load(object sender, EventArgs e)
        {
            N_Depositos.Cargar_Tarjetas(id,fecha,dgvTarjetas);
            N_Depositos.Cargar_Cuentas(id,fecha,dgvCuentas);
            if (dgvCuentas.Rows.Count == 0 || dgvTarjetas.Rows.Count == 0) this.Close();
        }

        // DEPOSITAR
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            Int64 cuenta = Convert.ToInt64(dgvCuentas.CurrentRow.Cells[0].Value);
            string tarjeta = dgvTarjetas.CurrentRow.Cells[0].Value.ToString();
            string emisor = dgvTarjetas.CurrentRow.Cells[1].Value.ToString();
            if (txtMonto.Text!="") 
            {
                double monto = double.Parse(txtMonto.Text, CultureInfo.InvariantCulture);
                string resu = N_Depositos.Confirmar_Deposito(id, cuenta, tarjeta, emisor, monto, fecha);
                if (resu == "OK")
                {
                    MessageBox.Show("Deposito Hecho Correctamente", "Resultado de Deposito");
                    frmComprobanteDepo c = new frmComprobanteDepo();
                    c.id = id;
                    c.ShowDialog();
                    txtMonto.Text = "";
                    N_Depositos.Cargar_Cuentas(id, fecha, dgvCuentas);
                }
                else
                {
                    MessageBox.Show(resu, "Resultado de Deposito");
                }                
            }
            else
            {
                MessageBox.Show("Campo vacio, escriba el monto deseado para depositar","Error de datos");
            }
            

        }


        // SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // VALIDAR INPUT DEL MONTO TEXTBOX
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
