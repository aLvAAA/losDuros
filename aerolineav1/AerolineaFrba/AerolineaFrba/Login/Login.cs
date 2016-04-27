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

namespace AerolineaFrba.Login_Form
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
                
        //Iniciar sesion
        private void Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar campos
                if (string.IsNullOrWhiteSpace(usuarioBox.Text) || string.IsNullOrWhiteSpace(passBox.Text))
                {
                    MessageBox.Show("Debe ingresar un Usuario y Contraseña");
                }
                else
                {
                    //Intentar login
                    AerolineaFrba.Model.Usuario user = new Model.Usuario(usuarioBox.Text, passBox.Text);
                    if (user.intentarLogin())
                    {
                        //Mostrar menu admin
                        AerolineaFrba.Model.Usuario.admin = true;
                        Inicio i = new Inicio();
                        i.Show();
                        this.Close();
                    }
                }
                
            }
            //Sino, mostrar error que arrojo la base
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 40003:
                        MessageBox.Show("Password incorrecta", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    case 40002:
                        MessageBox.Show("Usuario Bloqueado!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    case 40001:
                        MessageBox.Show("El Usuario no existe!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                }
            }

           
        }

        //Limpiar
        private void Cancelar_Click(object sender, EventArgs e)
        {
            usuarioBox.Text = "";
            passBox.Text = "";
            
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            usuarioBox.BackColor = Color.White;
        }
    }
}
