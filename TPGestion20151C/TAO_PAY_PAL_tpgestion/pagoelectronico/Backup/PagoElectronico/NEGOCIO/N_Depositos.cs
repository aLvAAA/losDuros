using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using PagoElectronico.DATOS;

namespace PagoElectronico.NEGOCIO
{
    public class N_Depositos
    {
        public static void Cargar_Tarjetas(int id, DateTime fecha, DataGridView tarjetas)
        {
            tarjetas.DataSource = D_Depositos.Listado_Tarjetas(id, fecha);
            if (tarjetas.Rows.Count == 0)
            {
                MessageBox.Show("Intente asosiar una tarjeta y vuelva","Error : Cliente sin Tarjeta"); 
            }
        }

        public static void Cargar_Cuentas(int id, DateTime fecha, DataGridView cuentas)
        {
            cuentas.DataSource = D_Depositos.Listado_Cuentas(id,fecha);
            if (cuentas.Rows.Count == 0) MessageBox.Show("Intente crear una cuenta de deposito y vuelva", "Error : Cliente sin cuenta");
        }

        public static string Confirmar_Deposito(int id, Int64 cuenta, string tarjeta, string emisor, double monto, DateTime fecha)
        {
            return D_Depositos.Deposito_OK(id,cuenta,tarjeta,emisor,monto,fecha);        
        }

        public static void Cargar_Comprobante(int id, Label fecha, Label deposito, Label cuenta, Label cliente, Label depositado)
        {
            DataTable dt = new DataTable();
            dt = D_Depositos.Cargar_Datos_Del_Deposito(id);
            deposito.Text = "Deposito N° " + dt.Rows[0][0].ToString();
            fecha.Text = "Fecha Operacion " + dt.Rows[0][1].ToString();
            cliente.Text = "Cliente ID ... " + dt.Rows[0][2].ToString();
            cuenta.Text = "Cuenta N° ....... " + dt.Rows[0][3].ToString();
            depositado.Text = "Depositado ..... "+ dt.Rows[0][4].ToString(); 
        }
    }
}
