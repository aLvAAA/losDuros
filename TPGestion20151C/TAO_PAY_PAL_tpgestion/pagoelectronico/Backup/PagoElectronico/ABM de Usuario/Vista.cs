using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_de_Usuario
{
    public class Vista
    {
        public static bool CadenaVacia(TextBox t)
        {
            if (t.Text == "")
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static bool LongitudCadenaMayorA_N(TextBox t, int n)
        {
            if (t.Text.Length > n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
