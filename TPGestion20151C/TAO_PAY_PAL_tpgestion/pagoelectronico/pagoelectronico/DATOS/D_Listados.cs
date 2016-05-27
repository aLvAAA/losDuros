
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.DATOS
{
    class D_Listados
    {

        public static DataTable GetListado(int trim, int año, string nro)
        {
            DataTable DT_resultado = new DataTable();
            D_ConexionBD con = new D_ConexionBD();

            try
            {
                //Defino que stored procedure voy a utilizar
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_Listado"+nro;
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Delcaro los filtros de busqueda
                SqlParameter p_trim = new SqlParameter();
                p_trim.ParameterName = "@trim";
                p_trim.SqlDbType = SqlDbType.Int;
                p_trim.Value = trim;
                SqlCmd.Parameters.Add(p_trim);

                SqlParameter p_año = new SqlParameter();
                p_año.ParameterName = "@anio";
                p_año.SqlDbType = SqlDbType.Int;
                p_año.Value = año;
                SqlCmd.Parameters.Add(p_año);

                SqlDataAdapter DA = new SqlDataAdapter(SqlCmd);
                DA.Fill(DT_resultado);
            }
            catch (Exception ex)
            {
                DT_resultado = null;
                MessageBox.Show(ex.Message, "Error de conexion en Listados");
            }

            return DT_resultado;
        }
    }

}
