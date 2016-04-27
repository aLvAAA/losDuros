using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.Login
{
    public partial class SeleccionRol : Form
    {
        private SqlConnection sqlCon = null;

        private String rol = null;

        private String usr = null;

        public SeleccionRol()
        {
            InitializeComponent();
        }

        public SeleccionRol(SqlConnection sqlCon, String usr):this()
        {
            this.sqlCon = sqlCon;
            this.usr = usr;
        }

        private bool recuperarRolesHabilitados()
        {
            //consula
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT NETSTLE.ROLXUSUARIO.ROLUSR_NOMBRE FROM NETSTLE.ROLXUSUARIO ";
            cmd.CommandText += "JOIN NETSTLE.ROL ON (NETSTLE.ROL.ROL_NOMBRE = NETSTLE.ROLXUSUARIO.ROLUSR_NOMBRE AND ROL_HABILITADO = 1) WHERE ";
            cmd.CommandText += "ROLUSR_NOMBRE_USUARIO = '" + usr + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego los roles al combobox
                    roles.Items.Add(reader.GetString(0));
                }

                //si hay un solo rol para el usuario
                if (roles.Items.Count == 1)
                {
                    //ya tiene un rol
                    rol = roles.GetItemText(roles.Items[0]);
                }
                else
                {
                    //el combobox muestra el primer rol por default
                    roles.SelectedIndex = 0;
                }

                //libero
                reader.Close();
                //libero
                cmd.Dispose();

                return true;
            }
            
            //fallo
            MessageBox.Show("El usuario no tiene ningun rol habilitado para mostrar.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //libero
            reader.Close();
            //libero
            cmd.Dispose();
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rol = roles.GetItemText(roles.SelectedItem);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private bool clienteEliminado()
        {
            //consula
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.CLIENTE ";
            cmd.CommandText += "WHERE CLI_NOMBRE_USUARIO = '" + usr + "' AND ";
            cmd.CommandText += "CLI_ELIMINADO = 0";

            cmd.Connection = sqlCon;

            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                //libero
                cmd.Dispose();
                return false;
            }

            //aviso que el cliente esta eliminado
            MessageBox.Show("Cliente eliminado del sistema o no dado de alta por el administrador.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //libero
            cmd.Dispose();
            return true;
        }

        public DialogResult _ShowDialog()
        {
            //recupero los roles para el usuario
            if (recuperarRolesHabilitados())
            {
                if (rol != null)
                {
                    if (rol == "CLIENTE")
                    {
                        if (clienteEliminado())
                        {
                            return DialogResult.No;
                        }
                    }
                    
                    //como solo tiene uno, no mostramos el cuadro de seleccion
                    return DialogResult.Yes;
                }
                else
                {
                    //mostramos el cuadro de seleccion
                    return this.ShowDialog();
                }
            }

            return DialogResult.No;
        }
        
        public String getRol()
        {
            return rol;
        }
    }
}
