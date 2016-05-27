using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using PagoElectronico.ENTIDADES;
using PagoElectronico.DATOS;

namespace PagoElectronico.NEGOCIO
{
    public class N_Tarjeta
    {
        public static void MostrarEmisores(ComboBox cmb)
        {
            cmb.DataSource = D_Tarjeta.CargarEmisores();
            cmb.ValueMember = "";
            cmb.DisplayMember = "emi_descripcion";
        }

        public static void ActualizarTarjetas(DateTime x)
        {
            new D_Tarjeta().ActualizarTarjetasXFechaSistema(x);
        }

        public static void cargarCampos(Label fec, Label state, int id, string nro_tar)
        {
            DataTable dt = new DataTable();
            dt = new D_Tarjeta().BuscarDatosTarjeta(id, nro_tar);
            DataRow row = dt.Rows[0];
            fec.Text = row[0].ToString();
            state.Text = row[1].ToString();
            if (state.Text == "Activo")
            {
                state.BackColor = Color.LightGreen;
            }
            else
            {
                state.BackColor = Color.LightCoral;
            }
        }

        public static string asociarTarjeta(E_Tarjeta t)
        {
            string rta = null;
            try
            {
                new D_Tarjeta().InsertarTarjeta(t);
            }
            catch (Exception ex)
            {
                rta = ex.Message;
            }
            return rta;
        }

        public static string EditarTarjeta(E_Tarjeta t)
        {
            return new D_Tarjeta().EditarTarjeta(t);            
        }

        public static string DesasociarTarjeta(E_Tarjeta t, DateTime date)
        {
            string rta = new D_Tarjeta().EliminarTarjeta(t, date);
            if (rta != null)
            {
                rta = "Error : " + rta;
            }
            return rta;
        }

        //cargo las tarjetas del cliente X que no esten desvinculadas
        public static void Cargar_Tarjetas_Cliente_X(ComboBox c1, ComboBox c2, int id)
        {
            DataTable dt = new DataTable();
            dt = D_Tarjeta.TarjetasDelClienteX(id);
            if (dt == null)
            {
                MessageBox.Show("Usted no posee tarjetas aun ", "Error de tarjetas");
            }
            else
            {
                c1.DataSource = dt;
                c1.ValueMember = "";
                c1.DisplayMember = "tarjetas";

                c2.DataSource = dt;
                c2.ValueMember = "";
                c2.DisplayMember = "tarjetas";
            }
        }

        /* *********** Capita de Presentacion del frmTarjeta **************** */
        
    }
}
