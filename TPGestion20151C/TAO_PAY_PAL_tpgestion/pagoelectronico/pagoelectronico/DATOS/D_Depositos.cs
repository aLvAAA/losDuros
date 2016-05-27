using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PagoElectronico.DATOS
{
    public class D_Depositos
    {
        public static DataTable Listado_Cuentas(int id, DateTime fecha)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Depositos_Cuentas_Habilitadas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id",SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fecha",SqlDbType.DateTime).Value = fecha;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Listado_Tarjetas(int id, DateTime fecha)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Depositos_Tarjetas_Activas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt; 
        }

        public static string Deposito_OK(int id, Int64 cuenta, string tarjeta, string emisor, double monto, DateTime fecha)
        {
            string resu = "OK";
            try
            {                
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Depositos_Depositar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@cta",SqlDbType.VarChar, 18).Value = cuenta;
                cmd.Parameters.Add("@tar",SqlDbType.VarChar, 100).Value = tarjeta;
                cmd.Parameters.Add("@emisor",SqlDbType.VarChar, 255).Value = emisor;
                cmd.Parameters.Add("@monto",SqlDbType.Decimal).Value = monto;
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                con.AbrirConexion();
                cmd.ExecuteNonQuery();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                resu = ex.Message;
            }
            return resu;
        }

        public static DataTable Cargar_Datos_Del_Deposito(int id)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "select top 1 dep_codigo Codigo, dep_fecha Fecha, dep_cli_id Cliente, dep_numeroCuenta Cuenta, dep_importe Monto "+
                              "from TAO_PAY_PAL.Deposito where dep_cli_id="+id.ToString()+
                              " order by 1 desc";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
