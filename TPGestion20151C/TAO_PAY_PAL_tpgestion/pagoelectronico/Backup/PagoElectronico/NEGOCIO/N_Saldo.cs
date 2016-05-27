using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using PagoElectronico.DATOS;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.NEGOCIO
{
    public class N_Saldo
    {
        public static void cargarCuentasAdminConFiltros(Button b, DataGridView d, E_Saldo s)
        {
            DataTable dt = new DataTable();
            dt = D_Saldo.Buscar_X_Filtro(s);
            if (dt == null)
            {
                MessageBox.Show("No hay cuentas con esos parametros", "Resultado de buscqueda cuentas");
            }
            else
            {
                d.DataSource = dt;
                //b.PerformClick();
            }
        }
        public static void cargarCuentasAdminGlobales(DataGridView d)
        {
            d.DataSource = D_Saldo.Buscar_Cuentas_Globalmente();
        }
        public static void cargarCuentasCliente(int id, DataGridView cuentas, Button b)
        {
            cuentas.DataSource = D_Saldo.Buscar_Cuentas_X_Cliente(id);
            if (cuentas.Rows.Count == 0)
            {
                MessageBox.Show("No tiene aun cuentas por consultar", "Resultado de Busquedas de Cuentas");
                b.Enabled = false;
            }
            else
            {
                b.Enabled = true;
            }
        }

        public static void cargarLosUltimosCincoDepositos(DataGridView depositos, Int64 cuenta)
        {
            depositos.DataSource = D_Saldo.Buscar_5_Ultimos_Depositos(cuenta);
            if (depositos.DataSource == null) MessageBox.Show("Todavia no realizo depositos", "Resultado de Consulta Depositos");
        }
        public static void cargarLosUltimosCincoRetiros(DataGridView retiros, Int64 cuenta)
        {
            retiros.DataSource = D_Saldo.Buscar_5_Ultimos_Retiros(cuenta);
            if (retiros.DataSource == null) MessageBox.Show("Todavia no realizo retiros", "Resultado de Consulta Retiros");
        }
        public static void cargarLasUltimasDiezTransferencias(DataGridView transf, Int64 cuenta)
        {
            transf.DataSource = D_Saldo.Buscar_10_Ultimas_Transferencias(cuenta);
            if (transf.DataSource == null) MessageBox.Show("Todavia no realizo o le hicieron transferencias", "Resultado de Consulta Transferencias");
        }

        public static void mostrarSaldo(Label saldo, Int64 cuenta, string moneda)
        {
            saldo.Text = "Saldo :  " + D_Saldo.Buscar_Saldo(cuenta)[0].ToString() + " " + moneda;
        }

        public static void cargarDocumentos(ComboBox c)
        {
            c.DataSource = D_Cliente.Cargar_Cmb("documento");
            c.ValueMember = "";
            c.DisplayMember = "td_descripcion";
        }
        public static void cargarTipoMoneda(ComboBox c)
        {
            c.DataSource = D_Cliente.Cargar_Cmb("monedas");
            c.ValueMember = "";
            c.DisplayMember = "tm_descripcion";
        }
    }
}
