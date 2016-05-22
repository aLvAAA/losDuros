using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication1.ABM_Visibilidad;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //con esto nos conectamos
                SqlConnection sqlCon = null;
                //creo una instancia del conector de la base de datos
                sqlCon = new SqlConnection("server=localhost\\SQLSERVER2012; initial catalog=GD1C2016; user id=gd; password=gd2016");
                //nos conectamos
                sqlCon.Open();
                MessageBox.Show("conectado");


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Visibilidad(sqlCon));

                }

            
            catch (SqlException e)
            {
                //le informamos al usuario
                MessageBox.Show(e.Message, "Error: " + e.Number);
            }
           
        }
    }
}
