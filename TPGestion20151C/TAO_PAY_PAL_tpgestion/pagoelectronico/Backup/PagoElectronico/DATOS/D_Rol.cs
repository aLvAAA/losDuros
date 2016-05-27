using System;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.DATOS
{
    class D_Rol
    {

        public static DataTable GetEstado(E_Rol rol)
        {
            DataTable DT_resultado = new DataTable();
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_GetEstadoRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Delcaro los filtros de busqueda
                SqlParameter p_id = new SqlParameter();
                p_id.ParameterName = "@id";
                p_id.SqlDbType = SqlDbType.Int;
                p_id.Value = rol.Id;
                SqlCmd.Parameters.Add(p_id);

                SqlDataAdapter DA = new SqlDataAdapter(SqlCmd);
                DA.Fill(DT_resultado);
            }
            catch (Exception ex)
            {
                DT_resultado = null;
                MessageBox.Show(ex.Message, "Error de D_Rol");
            }

            return DT_resultado;
        }

        //Agrega funcionalidad a un rol
        public static string AgregarFuncionalidad(int codRol, int codFunc)
        {
            string rta = "";
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Abro conexion
                con.AbrirConexion();

                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_AgregarFuncionalidadRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Declaro los parametros que voy a necesitar
                SqlParameter p_rolId = new SqlParameter();
                p_rolId.ParameterName = "@rolId";
                p_rolId.SqlDbType = SqlDbType.Int;
                p_rolId.Value = codRol;
                SqlCmd.Parameters.Add(p_rolId);

                SqlParameter p_funcId = new SqlParameter();
                p_funcId.ParameterName = "@funcId";
                p_funcId.SqlDbType = SqlDbType.Int;
                p_funcId.Value = codFunc;
                SqlCmd.Parameters.Add(p_funcId);


                //Ejecuta comando y devuelve si fue correcto o no
                rta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar";
            }

            catch (Exception ex)
            {
                rta = ex.Message;
            }

            finally
            {
                //Cierro conexion
                if (con.Conexion.State == ConnectionState.Open) con.CerrarConexion();
            }

            return rta;
        }

        //Quita funcionalidad a un rol
        public static string QuitarFuncionalidad(int codRol, int codFunc)
        {
            string rta = "";
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Abro conexion
                con.AbrirConexion();

                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_QuitarFuncionalidadRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Declaro los parametros que voy a necesitar
                SqlParameter p_rolId = new SqlParameter();
                p_rolId.ParameterName = "@rolId";
                p_rolId.SqlDbType = SqlDbType.Int;
                //p_rolId.Size = 255;
                p_rolId.Value = codRol;
                SqlCmd.Parameters.Add(p_rolId);

                SqlParameter p_funcId = new SqlParameter();
                p_funcId.ParameterName = "@funcId";
                p_funcId.SqlDbType = SqlDbType.Int;
                //p_funcId.Size = 1;
                p_funcId.Value = codFunc;
                SqlCmd.Parameters.Add(p_funcId);


                //Ejecuta comando y devuelve si fue correcto o no
                rta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo quitar";
            }

            catch (Exception ex)
            {
                rta = ex.Message;
            }

            finally
            {
                //Cierro conexion
                if (con.Conexion.State == ConnectionState.Open) con.CerrarConexion();
            }

            return rta;
        }

        //Insertar
        public static int Insertar(E_Rol rol)
        {
            //string rta = "";
            int rta = -1;
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Abro conexion
                con.AbrirConexion();

                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_AltaRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Declaro los parametros que voy a necesitar
                SqlParameter p_nombre = new SqlParameter();
                p_nombre.ParameterName = "@nombreRol";
                p_nombre.SqlDbType = SqlDbType.VarChar;
                p_nombre.Size = 255;
                p_nombre.Value = rol.Nombre;
                SqlCmd.Parameters.Add(p_nombre);

                SqlParameter p_estado = new SqlParameter();
                p_estado.ParameterName = "@estado";
                p_estado.SqlDbType = SqlDbType.Char;
                p_estado.Size = 1;
                p_estado.Value = rol.Estado;
                SqlCmd.Parameters.Add(p_estado);


                //Ejecuta comando y devuelve si fue correcto o no
                //rta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar";
                rta = Convert.ToInt32(SqlCmd.ExecuteScalar());
            }

            catch (Exception)
            {
                //rta = ex.Message;

            }

            finally
            {
                //Cierro conexion
                if (con.Conexion.State == ConnectionState.Open) con.CerrarConexion();
            }

            return rta;
        }

        //Modificar
        public static string Modificar(E_Rol rol)
        {
            string rta = "";
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Abro conexion
                con.AbrirConexion();

                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_ModificarRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Declaro los parametros que voy a utilizar
                SqlParameter p_id = new SqlParameter();
                p_id.ParameterName = "@rolId";
                p_id.SqlDbType = SqlDbType.Int;
                p_id.Value = rol.Id;
                SqlCmd.Parameters.Add(p_id);

                SqlParameter p_nombre = new SqlParameter();
                p_nombre.ParameterName = "@nombre";
                p_nombre.SqlDbType = SqlDbType.VarChar;
                p_nombre.Size = 50;
                p_nombre.Value = rol.Nombre;
                SqlCmd.Parameters.Add(p_nombre);

                SqlParameter p_estado = new SqlParameter();
                p_estado.ParameterName = "@estado";
                p_estado.SqlDbType = SqlDbType.Char;
                //p_estado.Size = 255;
                p_estado.Value = rol.Estado;
                SqlCmd.Parameters.Add(p_estado);

                //Ejecuta comando y devuelve si fue correcto o no
                rta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo modificar rol";
            }

            catch (Exception ex)
            {
                rta = ex.Message;
            }

            finally
            {
                //Cierro conexion
                if (con.Conexion.State == ConnectionState.Open) con.CerrarConexion();
            }

            return rta;
        }

        //Busca rol segun filtros
        public static DataTable BuscarRoles(string nombre, char estado, int codFunc)
        {
            DataTable DT_resultado = new DataTable();
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_BuscarRoles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Delcaro los filtros de busqueda
                SqlParameter p_nombre = new SqlParameter();
                p_nombre.ParameterName = "@nombre";
                p_nombre.SqlDbType = SqlDbType.VarChar;
                p_nombre.Size = 50;
                p_nombre.Value = nombre;
                SqlCmd.Parameters.Add(p_nombre);

                SqlParameter p_estado = new SqlParameter();
                p_estado.ParameterName = "@estado";
                p_estado.SqlDbType = SqlDbType.Char;
                p_estado.Size = 1;
                p_estado.Value = estado;
                SqlCmd.Parameters.Add(p_estado);

                SqlParameter p_codFunc = new SqlParameter();
                p_codFunc.ParameterName = "@codFunc";
                p_codFunc.SqlDbType = SqlDbType.Int;
                p_codFunc.Value = codFunc;
                SqlCmd.Parameters.Add(p_codFunc);

                SqlDataAdapter DA = new SqlDataAdapter(SqlCmd);
                DA.Fill(DT_resultado);
            }
            catch (Exception ex)
            {
                DT_resultado = null;
                MessageBox.Show(ex.Message, "Error de D_Rol");
            }

            return DT_resultado;
        }

        //Baja logica
        public static string Baja(E_Rol rol)
        {
            string rta = "";
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Abro conexion
                con.AbrirConexion();

                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_BajaRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Declaro los parametros que voy a utilizar
                SqlParameter p_id = new SqlParameter();
                p_id.ParameterName = "@rolId";
                p_id.SqlDbType = SqlDbType.Int;
                p_id.Value = rol.Id;
                SqlCmd.Parameters.Add(p_id);

                //Ejecuta comando y devuelve si fue correcto o no
                rta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo dar de baja rol";
            }

            catch (Exception ex)
            {
                rta = ex.Message;
            }

            finally
            {
                //Cierro conexion
                if (con.Conexion.State == ConnectionState.Open) con.CerrarConexion();
            }

            return rta;
        }

        //Obtener todos los roles
        public static DataTable GetRoles()
        {
            DataTable DT_resultado = new DataTable("Rol");

            D_ConexionBD con = new D_ConexionBD();

            try
            {

                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_GetRoles";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DA = new SqlDataAdapter(SqlCmd);
                DA.Fill(DT_resultado);
            }
            catch (Exception ex)
            {
                DT_resultado = null;
                MessageBox.Show(ex.Message, "Error de D_Rol");
            }

            return DT_resultado;
        }

        //Obtener funcionalidades por rol
        public static DataTable BuscarFuncionalidades(E_Rol rol)
        {
            DataTable DT_resultado = new DataTable("Rol");
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_BuscarFuncionalidadesRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Delcaro los filtros de busqueda
                SqlParameter p_id = new SqlParameter();
                p_id.ParameterName = "@id";
                p_id.SqlDbType = SqlDbType.Int;
                p_id.Value = rol.Id;
                SqlCmd.Parameters.Add(p_id);

                SqlDataAdapter DA = new SqlDataAdapter(SqlCmd);
                DA.Fill(DT_resultado);
            }
            catch (Exception ex)
            {
                DT_resultado = null;
                MessageBox.Show(ex.Message, "Error de D_Rol");
            }

            return DT_resultado;
        }


        //Obtener todas funcionalidades
        public static DataTable GetFuncionalidades()
        {
            DataTable DT_resultado = new DataTable("Rol");
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_GetFuncionalidades";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DA = new SqlDataAdapter(SqlCmd);
                DA.Fill(DT_resultado);
            }
            catch (Exception ex)
            {
                DT_resultado = null;
                MessageBox.Show(ex.Message, "Error de D_Rol");
            }

            return DT_resultado;
        }
    }
}
