using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Rol
{
    public partial class SeleccionRol : Form
    {
        private SqlConnection sqlCon = null;

        private String stringRol = null;

        private bool noHayRolParaSeleccionar = false;

        public SeleccionRol()
        {
            InitializeComponent();
        }

        public SeleccionRol(SqlConnection sqlCon, String msg): this()
        {
            this.sqlCon = sqlCon;

            //seleccione el rol que desea + msg
            label1.Text += " " + msg;

            //cargo roles
            if (!cargarRoles((msg == "eliminar") ? true : false))
            {
                //aviso
                MessageBox.Show("No existe actualmente ningun rol para " + msg, "Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                noHayRolParaSeleccionar = true;
            }
        }

        private bool cargarRoles(bool soloHabilitados)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT ROL_NOMBRE FROM NETSTLE.ROL";
            cmd.Connection = sqlCon;

            //importante
            if (soloHabilitados) cmd.CommandText += " WHERE ROL_HABILITADO = 1";

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego nuevo item
                    comboBox_roles.Items.Add(reader.GetString(0));
                }

                //mostramos por default el primer item
                comboBox_roles.SelectedIndex = 0;

                //libero
                reader.Close();

                //exito
                return true;
            }

            //libero
            reader.Close();
            //libero
            cmd.Dispose();

            //no hay roles
            return false;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (comboBox_roles.SelectedItem != null)
            {
                //recupero el iten seleccionado, para luego poder devolverlo con el get
                stringRol = comboBox_roles.GetItemText(comboBox_roles.SelectedItem);
            }

            //cierro
            this.Close();
        }

        private void ABM_SeleccionRol_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = (stringRol != null) ? DialogResult.Yes : DialogResult.No;
        }

        public DialogResult MostrarSiEsNecesario(){

            if (noHayRolParaSeleccionar)
            {
                return DialogResult.No;
            }
            else
            {
                return this.ShowDialog();
            }
        }

        public String getRolSeleccionado()
        {
            return stringRol;
        }
    }
}
