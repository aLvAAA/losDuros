using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //con esto nos conectamos
                SqlConnection sqlCon = null;
                //creo una instancia del conector de la base de datos
                sqlCon = new SqlConnection( "server=localhost\\SQLSERVER2008; initial catalog=GD1C2015; user id=gd; password=gd2015");
                //nos conectamos
                sqlCon.Open();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frm_programa(sqlCon));

                //cerramos la conexion
                sqlCon.Close();

            }
            catch (SqlException e)
            {
                //le informamos al usuario
                MessageBox.Show(e.Message, "Error: " + e.Number);
            }
        }
    }
}
