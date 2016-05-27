using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PagoElectronico.Transferencias
{
    class Vista
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
