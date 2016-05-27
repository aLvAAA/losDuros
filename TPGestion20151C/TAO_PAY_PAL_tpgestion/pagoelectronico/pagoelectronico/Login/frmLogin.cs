using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.NEGOCIO;
using PagoElectronico.DATOS;
using PagoElectronico.ENTIDADES;
using System.Data.SqlClient;

namespace PagoElectronico.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(Form p)
        {
            p.Close();
            InitializeComponent();
        }

        private void btn_acceder_Click(object sender, EventArgs e)
        {
            E_Login usuario = new E_Login(tb_usuario.Text, tb_contraseña.Text);
            N_Login n_cliente = new N_Login();
            if (n_cliente.ValidarUsuario(usuario))
            {
                this.Registrar_Acceso("OK", usuario);

                if (n_cliente.TieneMasDeUnRol(usuario))
                {
                    frmMasDeUnRol r = new frmMasDeUnRol(usuario.username);
                    r.usuario = usuario;
                    r.Login = this;
                    r.Show();
                    this.Hide();
                }
                else
                {
                    if (Rol_habilitado(usuario.username)) //Aca se verifica si su rol unico esta habilitado
                    {
                        switch (Id_Rol(usuario.username))
                        {
                            case "0":
                                MessageBox.Show("No se ha podido saber el Rol");
                                break;
                            case "1": //new frmFuncionalidades().ShowDialog();
                                frmFuncionalidades f = new frmFuncionalidades('a');
                                f.user_id = N_Login.IdentificarUsuario(usuario);
                                f.isAdmin = true;
                                f.Login = this;
                                this.Limpiar();

                                f.Show();
                                this.Hide();
                                break;
                            case "2": //MessageBox.Show("Funcionalidades de cliente - No implementado");

                                frmFuncionalidades c = new frmFuncionalidades('c');
                                c.user_id = N_Login.IdentificarUsuario(usuario);
                                c.isAdmin = false;
                                c.Login = this;
                                this.Limpiar();

                                c.Show();
                                this.Hide();
                                //new frmFuncionalidades('c').ShowDialog();//new frmFuncionalidades().ShowDialog();
                                break;

                            default:
                                MessageBox.Show("No capturo ningun valor");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede loguear en este momento"); //Usuario unico deshabilitado
                    }
                }
            }
            
            else
            {
                this.Registrar_Acceso("NO", usuario);
            }
        }

        public bool Rol_habilitado(string usuario)
        {
            D_ConexionBD con = new D_ConexionBD();
            con.AbrirConexion();
            try
            {
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = con.Conexion;
                SqlCmd.CommandText = "TAO_PAY_PAL.sp_Rol_habilitado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p_username = new SqlParameter();
                p_username.ParameterName = "@username";
                p_username.SqlDbType = SqlDbType.VarChar;
                p_username.Size = 50;
                p_username.Value = usuario;
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

        public void Limpiar() {
            tb_usuario.Clear();
            tb_contraseña.Clear();
        }

        public void Registrar_Acceso(string acceso, E_Login Usuario)
        {
            D_Login D_registro = new D_Login();
            D_registro.Registrar_Acceso(acceso, Usuario);
        }

        public string Id_Rol(string Usuario)
        {
            D_ConexionBD con = new D_ConexionBD();
            con.AbrirConexion();
            string queryString =
            "SELECT r.rol_codigo " +
            "from TAO_PAY_PAL.Usuario u,  TAO_PAY_PAL.Usuario_x_Rol ur, TAO_PAY_PAL.Rol r " +
            "where u.usr_id = ur.usr_id and ur.rol_codigo = r.rol_codigo and u.usr_username='" + Usuario + "'";


            string algo = "0";
            SqlCommand command = new SqlCommand(queryString, con.Conexion);
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    algo = reader[0].ToString();
                    reader.Close();
                    return algo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            reader.Close();
            con.CerrarConexion();
            return algo;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btn_registrarme_Click(object sender, EventArgs e)
        {            
            new ABM_de_Usuario.frmAltaUsuarioCliente().ShowDialog();
            //this.Hide();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
