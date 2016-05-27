using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.NEGOCIO;
using System.Text.RegularExpressions;

namespace PagoElectronico.Retiros
{
    public class Vista
    {
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

        public static void CargarBancos(ComboBox c)
        {
            c.DataSource = N_Retiro.CargarBancos();
            c.ValueMember = "";
            c.DisplayMember = "banco_nombre";
        }

        public static void InicializarCheque(Label l1, Label l2, Label l3, Label l4, Label l5)
        {
            l1.Text = "N° Cheque : ";
            l2.Text = "Fecha : ";
            l3.Text = "Lugar de retiro :";
            l4.Text = "Importe Extraido : ";
            l5.Text = "Nombre y Apellido : ";            
        }

        public static void SoloDigitoDecimal(KeyPressEventArgs e, TextBox textBox1)
        {
            try
            {

                if (textBox1.Text.Contains('.'))
                {
                    if (!char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }

                    if (e.KeyChar == '\b')
                    {
                        e.Handled = false;
                    }
                }
                else
                {
                    if (!char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }

                    if (e.KeyChar == '.' || e.KeyChar == '\b')
                    {
                        e.Handled = false;
                    }
                }
                if (Regex.IsMatch(textBox1.Text, @"\.\d\d"))
                {
                    e.Handled = true;
                    if (e.KeyChar == '\b')
                    {
                        e.Handled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de tipeo");
            }
        }
    }
}
