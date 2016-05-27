using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using PagoElectronico.DATOS;


namespace PagoElectronico.ABM_Cliente
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

        public static bool EsMailValido(string strMailAddress)
        {
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        public static void LimpiarAlta(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6, TextBox t7, TextBox t8, ComboBox c1, ComboBox c2, DateTimePicker dtp, DateTime d)
        {
            t1.Text = String.Empty;
            t2.Text = String.Empty;
            t3.Text = String.Empty;
            t4.Text = String.Empty;
            t5.Text = String.Empty;
            t6.Text = String.Empty;
            t7.Text = String.Empty;
            t8.Text = String.Empty;
            c1.SelectedIndex = 0;
            c2.SelectedIndex = 0;
            dtp.Value = d.AddYears(-18);
            dtp.MaxDate = d.AddYears(-18);
        }

        public static void LimpiarEdicion(Label l1, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6, TextBox t7, TextBox t8, ComboBox c1, ComboBox c2, DateTimePicker dtp, DateTime d)
        {
            l1.Text = String.Empty;
            t1.Text = String.Empty;
            t2.Text = String.Empty;
            t3.Text = String.Empty;
            t4.Text = String.Empty;
            t5.Text = String.Empty;
            t6.Text = String.Empty;
            t7.Text = String.Empty;
            t8.Text = String.Empty;
            c1.SelectedIndex = 0;
            c2.SelectedIndex = 0;
            dtp.Value = d.AddYears(-18);
            dtp.MaxDate = d.AddYears(-18);
        }

        public void LimpiarListado(TextBox t1, TextBox t2, TextBox t3, TextBox t4, ComboBox cb)
        {
            t1.Text = string.Empty;
            t2.Text = string.Empty;
            t3.Text = string.Empty;
            t4.Text = string.Empty;
            cb.SelectedIndex = 0;
        }
        
    }
}
