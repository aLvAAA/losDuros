using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagoElectronico.ENTIDADES;
using PagoElectronico.DATOS;
using PagoElectronico.NEGOCIO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PagoElectronico.DATOS
{
    class D_Login
    {
        public bool ValidarUsuario(E_Login Usuario) // (JON)
        {
            bool resu = true;
            D_ConexionBD con = new D_ConexionBD();
            con.AbrirConexion();
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_ValidarUsuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p_username = new SqlParameter();
                p_username.ParameterName = "@username";
                p_username.SqlDbType = SqlDbType.VarChar;
                p_username.Size = 100;
                p_username.Value = Usuario.username;
                SqlCmd.Parameters.Add(p_username);

                SqlParameter p_password = new SqlParameter();
                p_password.ParameterName = "@password";
                p_password.SqlDbType = SqlDbType.VarChar;
                p_password.Size = 100;
                p_password.Value = N_Cliente.GetSHA256(Usuario.password).ToString();
                SqlCmd.Parameters.Add(p_password);

                SqlCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : Error en Validar Usuario");
                resu = false;
            }
            con.CerrarConexion();
            return resu;
        }

        public bool TieneMasDeUnRol(E_Login Usuario)
        {
            D_ConexionBD con = new D_ConexionBD();
            con.AbrirConexion();
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_TieneMasDeUnRol";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p_username = new SqlParameter();
                p_username.ParameterName = "@username";
                p_username.SqlDbType = SqlDbType.VarChar;
                p_username.Size = 50;
                p_username.Value = Usuario.username;
                SqlCmd.Parameters.Add(p_username);
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return true;
            }
            con.CerrarConexion();
            return false;
        }

        public void Registrar_Acceso(string acceso, E_Login Usuario)
        {
            D_ConexionBD con = new D_ConexionBD();
            con.AbrirConexion();
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_Log_Acceso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p_acceso = new SqlParameter();
                p_acceso.ParameterName = "@acceso";
                p_acceso.SqlDbType = SqlDbType.VarChar;
                p_acceso.Size = 2;
                p_acceso.Value = acceso;
                SqlCmd.Parameters.Add(p_acceso);

                SqlParameter p_username = new SqlParameter();
                p_username.ParameterName = "@username";
                p_username.SqlDbType = SqlDbType.VarChar;
                p_username.Size = 50;
                p_username.Value = Usuario.username;
                SqlCmd.Parameters.Add(p_username);

                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CerrarConexion();
        }

        public static DataTable ObtenerIDUsuario(E_Login u)
        {
            DataTable dt = new DataTable();
            D_ConexionBD con = new D_ConexionBD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conexion;
            cmd.CommandText = "TAO_PAY_PAL.sp_Login_ID";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username",SqlDbType.VarChar, 100).Value = u.username;
            cmd.Parameters.Add("@password",SqlDbType.VarChar, 255).Value = N_Cliente.GetSHA256(u.password).ToUpper();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


    }
}
