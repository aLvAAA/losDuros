using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.DATOS
{
    public class D_Retiro
    {
        public static DataTable CargarCuentas(int id, DateTime fecha)
        {
            D_ConexionBD con = new D_ConexionBD();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Retiro_Actualizar_y_Buscar_Cuentas_Por_UserID";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id",SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fecha",SqlDbType.DateTime).Value = fecha;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static string RetirarEfectivo(E_Retiro r)
        {
            string rta = "OK";

            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand Cmd = new SqlCommand();

                Cmd.Connection = con.Conexion;
                Cmd.CommandText = "TAO_PAY_PAL.sp_Retiro_Registrar";
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Add("@id",SqlDbType.Int).Value = r.id;
                Cmd.Parameters.Add("@cta",SqlDbType.BigInt).Value = r.cuenta;
                Cmd.Parameters.Add("@fecha",SqlDbType.DateTime).Value = r.fecha;
                Cmd.Parameters.Add("@monto",SqlDbType.Float).Value = r.monto;
                Cmd.Parameters.Add("@banco",SqlDbType.VarChar, 20).Value = r.banco;
                Cmd.Parameters.Add("dni",SqlDbType.Int).Value = r.dni;

                con.AbrirConexion();
                Cmd.ExecuteNonQuery();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                rta = ex.Message;
            }
            return rta;
        }

        public static DataRow GenerarComprobante()
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = con.Conexion;
            sqlCom.CommandText = "TAO_PAY_PAL.sp_Retiro_Generar_Cheque";
            sqlCom.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(sqlCom);
            da.Fill(dt);

            return dt.Rows[0];

        }

        public static DataTable CargarBancos()
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();

            SqlCommand sqlcom = new SqlCommand();
            sqlcom.Connection = con.Conexion;
            sqlcom.CommandText = "TAO_PAY_PAL.sp_Mostrar_Paises_tipoDoc_Bancos_Monedas";
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Add("@concepto",SqlDbType.VarChar, 20).Value = "bancos";
            
            SqlDataAdapter da = new SqlDataAdapter(sqlcom);
            da.Fill(dt);
            return dt;
        }
    }
}
