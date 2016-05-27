using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PagoElectronico.NEGOCIO;
using PagoElectronico.ENTIDADES;
using PagoElectronico.DATOS;

namespace PagoElectronico.Login
{
    public partial class frmMasDeUnRol : Form
    {
        // ATRIBUTOS
        public E_Login usuario;
        private frmLogin login;

        public frmLogin Login
        {
            get { return login; }
            set { login = value; }
        }

        public frmMasDeUnRol(string usuario)
        {
            InitializeComponent();
            llenarItems(cb_RolesDeUsuario, usuario);
        }

        public void llenarItems(ComboBox cb, string usuario)
        {
            D_ConexionBD con = new D_ConexionBD();
            con.AbrirConexion();
            try
            {
                string consulta = "select r.rol_descripcion " +
                                    "from TAO_PAY_PAL.Usuario u " +
                                    "join TAO_PAY_PAL.Usuario_x_Rol ur " +
                                    "on(u.usr_id=ur.usr_id) " +
                                    "join TAO_PAY_PAL.Rol r " +
                                    "on(ur.rol_codigo=r.rol_codigo) " +
                                    "where u.usr_username = '" + usuario + "' "+
                                    "and r.rol_estado != 'N'";

                SqlCommand SqlCmd = new SqlCommand(consulta, con.Conexion);
                SqlDataReader dr = SqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    cb.Items.Add(dr["rol_descripcion"].ToString());
                }
                cb_RolesDeUsuario.SelectedIndex = 0;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el ComboBox" + ex.ToString());
            }
        }

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            switch (cb_RolesDeUsuario.Text)
            {
                case "Administrador":
                    //FUNCION CON PARAMETRO 'A' PARA MOSTRAR FUNCIONALIDADES DE ADMIN
                    //new frmFuncionalidades('a').ShowDialog();
                    frmFuncionalidades a = new frmFuncionalidades('a');
                    a.user_id = N_Login.IdentificarUsuario(usuario);
                    a.isAdmin = true;
                    a.Login = login;
                    login.Limpiar();
                    a.Show();
                    this.Close();
                    break;
                case "Cliente":
                    //hace algo
                    //MessageBox.Show("Funcionalidades de Cliente - No implementado");
                    //FUNCION CON PARAMETRO 'C' PARA MOSTRAR FUNCIONALIDADES DE CLIENTE
                    frmFuncionalidades c = new frmFuncionalidades('c');
                    c.user_id = N_Login.IdentificarUsuario(usuario);
                    c.isAdmin = false;
                    c.Login = login;
                    login.Limpiar();
                    c.Show();
                    this.Close();
                    break;
            }
        }

    }
}
