using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using PagoElectronico.ENTIDADES;


namespace PagoElectronico.DATOS
{
    public class D_Factura
    {
        public static DataTable Lista_Deudores_x_filtro(E_Cliente c)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Factura_Deudores_X_Filtro";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = c.nombre;
            cmd.Parameters.Add("@ape", SqlDbType.VarChar, 255).Value = c.apellido;
            cmd.Parameters.Add("mail", SqlDbType.VarChar, 255).Value = c.mail;
            cmd.Parameters.Add("@tipoDoc", SqlDbType.VarChar, 50).Value = c.tipoDocDesc;
            cmd.Parameters.Add("@nroDoc", SqlDbType.Int).Value = c.nroDoc;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }

        public static DataTable Lista_De_Todos_Los_Deudores()
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Factura_Deudores_Globales";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Buscar_Depositos(int id)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = con.Conexion;
            SqlCmd.CommandText = "select dep_fecha as Fecha," +
                                 "dep_numeroCuenta as Cuenta," +
                                 "dep_importe as Importe " +
                                 "from TAO_PAY_PAL.Deposito " +
                                 "where nroFactura is null and dep_cli_id=" + id.ToString() +
                                 " order by 1";
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Buscar_Retiros(int id)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = con.Conexion;
            SqlCmd.CommandText = "select ret_fecha,ret_nroCuenta,ret_nroCheque,ret_importe " +
                                 "from TAO_PAY_PAL.Retiro, TAO_PAY_PAL.Cuenta " +
                                 "where nroFactura is null and ret_nroCuenta = cta_numero and cta_cli_id=" + id.ToString() +
                                 " order by 1";

            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Buscar_Tranferencias(int id)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = con.Conexion;
            SqlCmd.CommandText = "select transf_fechaHora as Fecha, transf_origenCuenta as Cuenta," +
                                 "transf_destinoCuenta as Destino, transf_importe as Importe " +
                                 "from TAO_PAY_PAL.Transferencia,TAO_PAY_PAL.Cuenta " +
                                 "where transf_nroFactura is null and transf_origenCuenta=cta_numero and cta_cli_id=" + id.ToString() +
                                 " order by 1";
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Buscar_Transacciones(int id)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = con.Conexion;
            SqlCmd.CommandText = "TAO_PAY_PAL.sp_Factura_Mostrar_Transacciones";
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            da.Fill(dt);
            return dt;
        }

        public static DataRow Buscar_Datos_Cliente(int id)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand SqlCmd = new SqlCommand();

            SqlCmd.Connection = con.Conexion;
            SqlCmd.CommandText = "TAO_PAY_PAL.sp_Factura_Datos_Cliente";
            SqlCmd.CommandType = CommandType.StoredProcedure;

            SqlCmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
            da.Fill(dt);

            return dt.Rows[0];
        }

        public static void FacturarOK(int id, Int64 factura, double monto, DateTime fecha)
        {
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Factura_Confirmar_OK";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@factura", SqlDbType.BigInt).Value = factura;
            cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;

            con.AbrirConexion();
            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }

    }
}
