using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PagoElectronico.DATOS
{
    public class D_ConexionBD
    {
        public SqlConnection Conexion;

        public D_ConexionBD()
        {
            Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["gd1c2015"].ConnectionString);
        }

        public void AbrirConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Broken || Conexion.State == ConnectionState.Closed)
                    Conexion.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar de abrir Conexion", e);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }

            catch (Exception e)
            {
                throw new Exception("Error al tratar de cerrar Conexion", e);
            }
        }
    }
}
