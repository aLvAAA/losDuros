using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data;
using PagoElectronico.DATOS;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.NEGOCIO
{
    public class N_Retiro
    {
        public static void CargarCuentas(DataGridView d, int id, DateTime t)
        {
            DataTable dt = new DataTable();
            dt = D_Retiro.CargarCuentas(id, t);
            if (dt == null)
            {
                MessageBox.Show("El Cliente no tiene Cuentas", "Error de Cuentas");
            }
            else
            {
                d.DataSource = dt;
            }
        }

        public static string RetirarEfectivo(E_Retiro r)
        {
            return D_Retiro.RetirarEfectivo(r);
        }

        public static void GenerarCheque(Label l1, Label l2, Label l3, Label l4, Label l5)
        {
            DataRow dr = D_Retiro.GenerarComprobante();
            if (dr == null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                l1.Text = l1.Text + " " + dr[0].ToString();
                l2.Text = l2.Text + " " + dr[1].ToString();
                l3.Text = l3.Text + " " + dr[2].ToString();
                l4.Text = l4.Text + " " + dr[3].ToString();
                l5.Text = l5.Text + " " + dr[4].ToString();
            }

        }

        public static DataTable CargarBancos()
        {
            return D_Cliente.Cargar_Cmb("bancos");
        }
    }
}
