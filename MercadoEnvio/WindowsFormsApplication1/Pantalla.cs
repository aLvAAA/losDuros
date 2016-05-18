using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Pantalla : Form
    {

        private SqlConnection sqlCon = null;

        private String usuario = null;

        private String rol = null;

        public Pantalla()
        {
            InitializeComponent();
           
        }

         public Pantalla(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //creo instancia de nueva ventana
            Login.frm_login frmLogin = new Login.frm_login(sqlCon); ;

            //llamo
            if (frmLogin.ShowDialog() == DialogResult.Yes)
            {
                //activo menu
               // activarMenuSegunRol(frmLogin.GetRolUsuario());
                Login.SeleccionRol frmRol = new Login.SeleccionRol(sqlCon, usuario);
                frmRol.Show();
                //guardo el usuario
            //    usuario = frmLogin.GetUsuario();

                //veo de activar pestaña cambio rol
               // activarCambioRol();
            }
            else
            {
                this.Close();
            }

            //libero
            frmLogin.Dispose();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Login.frm_login frmLogin = new Login.frm_login();

            frmLogin.Show();
        }








    }
}
