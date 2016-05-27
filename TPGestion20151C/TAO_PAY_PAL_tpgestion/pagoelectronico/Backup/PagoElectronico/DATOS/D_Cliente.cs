using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.DATOS
{
    public class D_Cliente
    {
        
        public static string Alta_Cliente(E_Usuario u, E_Cliente c)
        {
            string rta = "OK";
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cliente_Alta";

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = u.username;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = u.pass;
                cmd.Parameters.Add("@pre", SqlDbType.VarChar, 255).Value = u.preguntaSecreta;
                cmd.Parameters.Add("@res", SqlDbType.VarChar, 255).Value = u.respuestaSecreta;
                cmd.Parameters.Add("@creacion", SqlDbType.DateTime).Value = u.fechaCreacion;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = c.nombre;
                cmd.Parameters.Add("@ape", SqlDbType.VarChar, 255).Value = c.apellido;
                cmd.Parameters.Add("@tipoDocDesc", SqlDbType.VarChar, 50).Value = c.tipoDocDesc;
                cmd.Parameters.Add("@nroDoc", SqlDbType.VarChar, 255).Value = c.nroDoc;
                cmd.Parameters.Add("@paisDesc", SqlDbType.VarChar, 100).Value = c.pais;
                cmd.Parameters.Add("@domCalle", SqlDbType.VarChar, 255).Value = c.domCalle;
                cmd.Parameters.Add("@nroCalle", SqlDbType.Int).Value = c.domNro;
                cmd.Parameters.Add("@piso", SqlDbType.Int).Value = c.domPiso;
                cmd.Parameters.Add("@depto", SqlDbType.VarChar, 10).Value = c.domDepto;
                cmd.Parameters.Add("@nacimiento", SqlDbType.DateTime).Value = c.fechaNacimiento;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255).Value = c.mail;

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

        public static string Editar_Cliente(E_Cliente c)
        {
            string rta = "OK";
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cliente_Editar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = c.id;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 255).Value = c.nombre;
                cmd.Parameters.Add("@ape", SqlDbType.VarChar, 255).Value = c.apellido;
                cmd.Parameters.Add("@tipoDocDesc", SqlDbType.VarChar, 250).Value = c.tipoDocDesc;
                cmd.Parameters.Add("@nroDoc", SqlDbType.Int).Value = c.nroDoc;
                cmd.Parameters.Add("@paisDesc", SqlDbType.VarChar, 100).Value = c.pais;
                cmd.Parameters.Add("@calle", SqlDbType.VarChar, 255).Value = c.domCalle;
                cmd.Parameters.Add("@nroCalle", SqlDbType.Int).Value = c.domNro;
                cmd.Parameters.Add("@piso", SqlDbType.Int).Value = c.domPiso;
                cmd.Parameters.Add("@depto", SqlDbType.VarChar, 10).Value = c.domDepto;
                cmd.Parameters.Add("@nacimiento", SqlDbType.DateTime).Value = c.fechaNacimiento;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255).Value = c.mail;

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

        public static string Habilitar_Deshabiitar_Cliente(int id, string accion)
        {
            string rta = "OK";
            D_ConexionBD con = new D_ConexionBD();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cliente_Habilitar_Inhabilitar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@accion", SqlDbType.VarChar, 20).Value = accion;

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

        public static DataTable Listar_Clientes(E_Cliente c)
        {
            DataTable DT_resultado = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Clientes_Listado";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 255).Value = c.nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 255).Value = c.apellido;
                cmd.Parameters.Add("@tipoDocDesc", SqlDbType.VarChar, 250).Value = c.tipoDocDesc;
                cmd.Parameters.Add("@nroDoc", SqlDbType.Int).Value = c.nroDoc;
                cmd.Parameters.Add("@mail", SqlDbType.VarChar, 255).Value = c.mail;
                //cmd.Parameters.Add("@accion", SqlDbType.VarChar, 20).Value = accion;

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DT_resultado);
            }
            catch
            {
                DT_resultado = null;
            }
            return DT_resultado;
        }

        public static DataTable Cargar_Cmb(string concepto)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;

            if (concepto == "monedas") cmd.CommandText = "select tm_descripcion from TAO_PAY_PAL.Tipo_Moneda";
            if (concepto == "estados") cmd.CommandText = "select estado_descricion from TAO_PAY_PAL.Estado_Cuenta";
            if (concepto == "documento") cmd.CommandText = "select td_descripcion from TAO_PAY_PAL.Tipo_Documento order by 1 desc";
            if (concepto == "paises") cmd.CommandText = "select pais_descripcion from TAO_PAY_PAL.Pais ORDER BY 1";
            if (concepto == "bancos") cmd.CommandText = "select banco_nombre from TAO_PAY_PAL.Banco"; 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public static string Verificar_Username(string username)
        {
            string rta = "OK";
            try
            {
                D_ConexionBD con = new D_ConexionBD();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Usuario_Verificar_Username";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = username;

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

        public static DataRow Datos_Clientes_Para_Edicion(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "TAO_PAY_PAL.sp_Cliente_Informacion";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            return dt.Rows[0];
        }

        public static bool Estado_Cliente(int id)
        {
            bool valido = true;
            try
            {
                D_ConexionBD con = new D_ConexionBD();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.Conexion;
                cmd.CommandText = "if (not exists(select 1 from TAO_PAY_PAL.Cliente where cli_id=" + id.ToString() + " and cli_estado='A')) " +
                                    "raiserror('1',16,1)";
                con.AbrirConexion();
                cmd.ExecuteNonQuery();
                con.CerrarConexion();
            }
            catch
            {
                valido = false;
            }
            return valido;
        }
    }
}
