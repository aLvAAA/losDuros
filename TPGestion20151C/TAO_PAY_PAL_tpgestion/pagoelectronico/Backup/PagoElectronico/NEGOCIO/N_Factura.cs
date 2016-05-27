using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using PagoElectronico.DATOS;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.NEGOCIO
{
    public class N_Factura
    {
        public static void Mostrar_Deudores_Por_Filtro(E_Cliente c, DataGridView d, Button b)
        {
            DataTable dt = new DataTable();
            dt = D_Factura.Lista_Deudores_x_filtro(c);
            if (dt.Rows.Count > 0)
            {
                d.DataSource = dt;
                b.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existe/n Deudor/es aun !!!", "Resultado de Busqueda de Deudores");
                d.DataSource = null;
                b.Enabled = false;
            }
        }

        public static void Mostrar_Todos_Los_Deudores(DataGridView d, Button b)
        {
            DataTable dt = new DataTable();
            dt = D_Factura.Lista_De_Todos_Los_Deudores();
            if (dt.Rows.Count > 0)
            {
                d.DataSource = dt;
                b.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existe/n Deudor/es aun !!!", "Resultado de Busqueda de Deudores");
                d.DataSource = null;
                b.Enabled = false;
            } 
        }

        public static void MostrarDetallesFactura(int id, DataGridView depositos, DataGridView retiros, DataGridView transf, DataGridView transacciones)
        {
            string mensajeError = "El Cliente no realizo: ";
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            dt1 = D_Factura.Buscar_Depositos(id);
            if (dt1.Rows.Count > 0)
            {
                depositos.DataSource = dt1;
            }
            else
            {
                mensajeError += "Depositos ";
                depositos.DataSource = null; 
            }

            dt2 = D_Factura.Buscar_Retiros(id);
            if (dt2.Rows.Count > 0)
            {
                retiros.DataSource = dt2;
            }
            else 
            {
                mensajeError += "Retiros ";
                retiros.DataSource = null;
            }

            dt3 = D_Factura.Buscar_Tranferencias(id);
            if (dt3.Rows.Count > 0)
            {
                transf.DataSource = dt3;
            }
            else
            {
                mensajeError += "Transferencias ";
                transf.DataSource = null;
            }

            dt4 = D_Factura.Buscar_Transacciones(id);
            if (dt4.Rows.Count > 0)
            {
                transacciones.DataSource = dt4;
            }
            else
            {
                mensajeError += "Transacciones .";
                transacciones.DataSource = null;
            }

            if (mensajeError != "El Cliente no realizo: ") MessageBox.Show(mensajeError, "Resultado de Detalle de Facturación");
        }

        public static void CargarDocumento(ComboBox c)
        {
            c.ValueMember = "";
            c.DisplayMember = "td_descripcion";
            c.DataSource = D_Cliente.Cargar_Cmb("documento");
        }

        public static Int64 MostrarDatosCliente(int id, Label l2, Label l3)
        {
            DataRow dr = D_Factura.Buscar_Datos_Cliente(id);
            l2.Text = l2.Text + dr[1].ToString();
            l3.Text = l3.Text + dr[2].ToString();
            return Convert.ToInt64(dr[0]);
        }

        public static double CalcularTotal(DataGridView d)
        {
            double suma = 0;
            for ( int i = 0; i < d.Rows.Count ;i++ )
            {
                suma += Convert.ToDouble(d.Rows[i].Cells[3].Value);
            }
            return suma;
        }

        public static void FacturarOK(int id, Int64 cuenta, double monto, DateTime fecha)
        {
            D_Factura.FacturarOK(id, cuenta, monto, fecha);
            MessageBox.Show("Cliente al Dia, Transacciones facturadas :D", "Resultado de Factura");
        }

    }
}
