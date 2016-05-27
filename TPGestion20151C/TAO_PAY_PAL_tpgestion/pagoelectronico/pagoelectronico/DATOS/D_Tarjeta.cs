using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

using PagoElectronico.ENTIDADES;

namespace PagoElectronico.DATOS
{
    public class D_Tarjeta
    {
        public void ActualizarTarjetasXFechaSistema(DateTime fecha)
        {
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Tarjeta_Actualizar_Estados_Por_Fecha";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fechaSistema", SqlDbType.DateTime).Value = fecha;

                con.AbrirConexion();
                cmd.ExecuteNonQuery();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error al actualizar Tarjetas");
            }
        }

        public static DataTable TarjetasDelClienteX(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Tarjeta_Listado";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                MessageBox.Show(ex.Message, "Error de CargarComboTarjeta");
            }
            return dt;
        }

        public DataTable BuscarDatosTarjeta(int id, string nro_tar)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Tarjeta_Informacion";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@tar", SqlDbType.VarChar, 100).Value = nro_tar;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            return dt;
        }

        public void InsertarTarjeta(E_Tarjeta t)
        {
            DataTable dt = new DataTable();

            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Tarjeta_Insertar";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = t.user_id;
            cmd.Parameters.Add("@tar",SqlDbType.VarChar, 100).Value = t.Codigo;
            cmd.Parameters.Add("@emisor",SqlDbType.VarChar, 30).Value = t.emisor;
            cmd.Parameters.Add("@fechaEmision",SqlDbType.DateTime).Value = t.fechaEmision;
            cmd.Parameters.Add("@fechaVencimiento",SqlDbType.DateTime).Value = t.fechaVencimiento;
            cmd.Parameters.Add("@codSeguridad",SqlDbType.Char, 3).Value = t.seguridad;

            con.AbrirConexion();
            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }

        public string EditarTarjeta(E_Tarjeta t)
        {
            string rta = "OK";

            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Tarjeta_Editar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = t.user_id;
                cmd.Parameters.Add("@tar", SqlDbType.VarChar, 100).Value = t.Codigo;
                cmd.Parameters.Add("@fechaVencimiento", SqlDbType.DateTime).Value = t.fechaVencimiento;
                cmd.Parameters.Add("@codSeguridad", SqlDbType.Char, 3).Value = t.seguridad;
                cmd.Parameters.Add("@codSeguridadNueva", SqlDbType.Char, 3).Value = t.seguridadNueva;
                
                con.AbrirConexion();
                cmd.ExecuteNonQuery();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                rta = ex.Message;
            }
            return rta;
        }

        public string EliminarTarjeta(E_Tarjeta t, DateTime date)
        {
            string rta = null;
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Tarjeta_Desasociar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = t.user_id;
                cmd.Parameters.Add("@tar", SqlDbType.VarChar, 100).Value = t.Codigo;
                cmd.Parameters.Add("@codSeg", SqlDbType.Char, 3).Value = t.seguridad;
                cmd.Parameters.Add("@fechaDesasociacion", SqlDbType.DateTime).Value = date;

                con.AbrirConexion();
                cmd.ExecuteNonQuery();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                rta = ex.Message;
            }
            return rta;
        }

        public static DataTable CargarEmisores()
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "select emi_id,emi_descripcion from TAO_PAY_PAL.Emisor_Tarjeta";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

    }
}
