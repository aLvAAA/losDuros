using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using PagoElectronico.ENTIDADES;

namespace PagoElectronico.DATOS
{
    public class D_Cuenta
    {
        public static DataTable MostrarCuentasUnCliente(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "select cta_numero Cuenta, cat_descripcion Categoria, cta_fechaCierre Valido_hasta, pais_descripcion Pais, cta_estado Estado " +
                                  "from TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Pais, TAO_PAY_PAL.Categoria_Cuenta " +
                                  "where cta_cli_id=" + id.ToString() + " and cat_codigo=cta_categoria and pais_codigo=cta_paisCodigo";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt.Clear();
            }
            return dt;
        }

        public static DataTable MostrarCuentasXFiltros(string nombre, string apellido, string id, string estado, string cate)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cuenta_Busqueda_X_Filtro";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.VarChar, 18).Value = id;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = nombre;
                cmd.Parameters.Add("@ape", SqlDbType.VarChar, 255).Value = apellido;
                cmd.Parameters.Add("@categoria", SqlDbType.VarChar, 50).Value = cate;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar, 50).Value = estado;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt.Clear();
            }
            return dt;

        }

        public static DataTable MostrarCuentasMuchosClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "select cta_numero Cuenta, cta_cli_id ID, cli_nombre+' '+cli_apellido Cliente, cat_descripcion Categoria, pais_descripcion Pais, cta_estado Estado " +
                                  "from TAO_PAY_PAL.Cuenta, TAO_PAY_PAL.Pais, TAO_PAY_PAL.Categoria_Cuenta, TAO_PAY_PAL.Cliente " +
                                  "where cat_codigo=cta_categoria and pais_codigo=cta_paisCodigo and cli_id=cta_cli_id";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt.Clear();
            }
            return dt;
        }

        public static string Alta_Cuenta(int id, DateTime fecha, string cate, string pais, string mone, int suscrip)
        {
            string resu = "OK";
            D_ConexionBD con = new D_ConexionBD();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cuenta_Alta";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                cmd.Parameters.Add("@categoria", SqlDbType.VarChar, 50).Value = cate;
                cmd.Parameters.Add("@pais", SqlDbType.VarChar, 255).Value = pais;
                cmd.Parameters.Add("@moneda", SqlDbType.VarChar, 50).Value = mone;
                cmd.Parameters.Add("@suscrip", SqlDbType.Int).Value = suscrip;

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

        public static string Editar_Cuenta(DateTime fecha, Int64 cuenta, string cate, int suscrip)
        {
            string resu = "OK";
            D_ConexionBD con = new D_ConexionBD();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cuenta_Edicion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                cmd.Parameters.Add("@cuenta", SqlDbType.BigInt).Value = cuenta;
                cmd.Parameters.Add("@categoria", SqlDbType.VarChar, 50).Value = cate;
                cmd.Parameters.Add("@suscrip", SqlDbType.Int).Value = suscrip;

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

        public static string Baja_Cuenta(Int64 cuenta, DateTime fecha)
        {
            string resu = "OK";
            D_ConexionBD con = new D_ConexionBD();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cuenta_Baja";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("@cuenta", SqlDbType.BigInt).Value = cuenta;
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

        public static void ActualizarCuentas(DateTime fecha)
        {
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Cuenta_ActualizarAlaFecha";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
            con.AbrirConexion();
            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }

        public static DataTable cargarCombobox(string tabla)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;

            if (tabla == "monedas") cmd.CommandText = "select tm_descripcion from TAO_PAY_PAL.Tipo_Moneda";
            if (tabla == "categoria") cmd.CommandText = "select cat_descripcion from TAO_PAY_PAL.Categoria_Cuenta";
            if (tabla == "estados") cmd.CommandText = "select estado_descricion from TAO_PAY_PAL.Estado_Cuenta";
            if (tabla == "documento") cmd.CommandText = "select td_descripcion from TAO_PAY_PAL.Tipo_Documento order by 1 desc";
            if (tabla == "paises") cmd.CommandText = "select pais_descripcion from TAO_PAY_PAL.Pais ORDER BY 1";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Lista_Clientes()
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "select cli_id Codigo, cli_nombre+' '+cli_apellido Cliente, td_descripcion+' '+convert(varchar(20),cli_nroDoc) Documento, cli_mail Mail " +
                              "from TAO_PAY_PAL.Cliente, TAO_PAY_PAL.Tipo_Documento " +
                              "where td_codigo=cli_tipoDoc";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static DataTable Lista_Clientes_con_Filtro(string nom, string ape, string mail, string doc, string nrodoc)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Cuentas_Clientes_Filtro";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 255).Value = nom;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 255).Value = ape;
            cmd.Parameters.Add("@tipoDocDesc", SqlDbType.VarChar, 100).Value = doc;
            cmd.Parameters.Add("@nroDoc", SqlDbType.VarChar, 20).Value = nrodoc;
            cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255).Value = mail;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        
    }
}
