using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class Visibilidad : Form
    {
        private SqlConnection sqlCon = null;


        public Visibilidad()
        {
            InitializeComponent();
        }

         public Visibilidad(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;
        }

        private void Visibilidad_Load(object sender, EventArgs e)
        {
              //limpio por las dudas
               comboBox1.Items.Clear();

               //consula
               SqlCommand cmd = new SqlCommand();

               cmd.CommandText = "select t.Publicacion_Visibilidad_Desc from gd_esquema.Maestra as t";
               cmd.CommandText += " group by t.Publicacion_Visibilidad_Desc";         
               cmd.Connection = sqlCon;

               //ejecuto
              try
               {                 
               SqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   comboBox1.Items.Add(reader["Publicacion_Visibilidad_Desc"]);
               }
               comboBox1.SelectedIndex = 0;
                   reader.Close();
                   reader.Dispose();

                              }
               catch(Exception ex){
                   MessageBox.Show(ex.Message,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);                   
               }
         




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
