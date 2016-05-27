using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

using PagoElectronico.ENTIDADES;

namespace PagoElectronico.DATOS
{
    public class D_Saldo
    {
        public static DataTable Buscar_Cuentas_X_Cliente(int id)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "select cta_numero Cuenta, cat_descripcion Categoria, pais_descripcion Pais, tm_descripcion Moneda " +
                              "from TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Pais, TAO_PAY_PAL.Categoria_Cuenta, TAO_PAY_PAL.Tipo_Moneda " +
                              "where cta_cli_id=" + id.ToString() + " and cta_paisCodigo= pais_codigo and cat_codigo=cta_categoria and tm_codigo=cta_tipoMoneda";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Buscar_X_Filtro(E_Saldo s)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Saldo_BuscarCuentasXFiltro";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.VarChar, 18).Value = s.id;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = s.nombre;
                cmd.Parameters.Add("@ape", SqlDbType.VarChar, 255).Value = s.apellido;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255).Value = s.mail;
                cmd.Parameters.Add("@tipoDoc", SqlDbType.VarChar, 50).Value = s.tipoDoc;
                cmd.Parameters.Add("@nroDoc", SqlDbType.VarChar, 18).Value = s.nroDoc;
                cmd.Parameters.Add("@nroCta", SqlDbType.VarChar, 18).Value = s.cta;
                cmd.Parameters.Add("@moneda", SqlDbType.VarChar, 50).Value = s.moneda;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dt = null;
            }
            return dt;
        }

        public static DataTable Buscar_Cuentas_Globalmente()
        {
            DataTable dt = new DataTable();

            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Saldo_BuscarCuentasGlobales";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Buscar_5_Ultimos_Depositos(Int64 cuenta)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Saldo_5Depositos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cuenta", SqlDbType.BigInt).Value = cuenta;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable Buscar_5_Ultimos_Retiros(Int64 cuenta)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Saldo_5Retiros";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cuenta", SqlDbType.BigInt).Value = cuenta;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataTable Buscar_10_Ultimas_Transferencias(Int64 cuenta)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Saldo_10Transferencias";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cuenta", SqlDbType.BigInt).Value = cuenta;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public static DataRow Buscar_Saldo(Int64 cuenta)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "select cta_saldo from TAO_PAY_PAL.Cuenta where cta_numero=" + Convert.ToString(cuenta);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt.Rows[0];
        }
    }
}
