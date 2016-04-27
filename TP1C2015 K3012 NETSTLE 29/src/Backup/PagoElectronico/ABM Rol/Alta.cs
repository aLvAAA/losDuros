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
    public partial class Alta : Form
    {
        private SqlConnection sqlCon = null;

        public Alta()
        {
            InitializeComponent();
        }

        public Alta(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;

            recuperarFuncionalidades();
        }

        void recuperarFuncionalidades()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT FUNC_NOMBRE FROM NETSTLE.FUNCIONALIDAD";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox_func.Items.Add(reader.GetString(0));
                }

                comboBox_func.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void listBox_funcionalidad_Click(object sender, EventArgs e)
        {
            if (listBox_funcionalidad.SelectedItem != null)
            {
                button_eliminar.Enabled = true;
            }
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (listBox_funcionalidad.SelectedItem != null)
            {
                //elimino el item seleccionado del listbox y vuelvo a desabilitar el boton eliminar
                listBox_funcionalidad.Items.Remove(listBox_funcionalidad.SelectedItem);

                button_eliminar.Enabled = false;
            }
        }

        private void limpiar()
        {
            //textbox vacio
            textBox_nombre_rol.Text = "";

            //mostramos por default el primer item
            comboBox_func.SelectedIndex = 0;

            //dejo el listbox sin ningun item
            listBox_funcionalidad.Items.Clear();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private bool existeRolConEseNombre()
        {
            //comsulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.ROL WHERE ";
            cmd.CommandText += "ROL_NOMBRE = '" + textBox_nombre_rol.Text + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                //le aviso al usr
                MessageBox.Show("Ya existe un rol con el nombre " + textBox_nombre_rol.Text, "Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //libero
                cmd.Dispose();
                return true;
            }

            //libero
            cmd.Dispose();
            //no existe
            return false;
        }

        private bool guardarRol()
        {
            //comsulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO NETSTLE.ROL (ROL_NOMBRE, ROL_HABILITADO) ";
            cmd.CommandText += "VALUES('" + textBox_nombre_rol.Text + "',1)";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla ROL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return false;
            }

            //libero
            cmd.Dispose();
            return true;
        }

        private void guardarFuncionalidadesRol()
        {
            bool err_insert = false;

            for (int i = 0; i < listBox_funcionalidad.Items.Count; i++)
            {
                //comsulta
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO NETSTLE.FUNCIONALIDADXROL (FUNCROL_NOMBRE_ROL, FUNCROL_FUNCIONALIDAD_NOMBRE) ";
                cmd.CommandText += "VALUES('" + textBox_nombre_rol.Text + "','" + listBox_funcionalidad.GetItemText(listBox_funcionalidad.Items[i]) + "')";
                cmd.Connection = sqlCon;

                if (cmd.ExecuteNonQuery() != 1)
                {
                    //fallo
                    MessageBox.Show("Error al insertar en la tabla FUNCIONALIDADXROL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    err_insert = true;
                    //libero
                    cmd.Dispose();
                    break;
                }

                //libero
                cmd.Dispose();
            }
            if (!err_insert)
            {
                MessageBox.Show("Rol creado con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            bool vacio = false;
            //me fijo que los campos no esten vacios
            if (textBox_nombre_rol.Text == "")
            {
                errorProvider_Nombre.SetError(textBox_nombre_rol, "Por favor ingrese un nombre para el rol.");
                vacio = true;
            }

            if (listBox_funcionalidad.Items.Count == 0)
            {
                errorProvider_listFunc.SetError(listBox_funcionalidad, "Debe tener al menos una funcionalidad asignada para el rol.");
                vacio = true;
            }

            if (vacio) return;

            if (!existeRolConEseNombre())
            {
                if (guardarRol())
                {
                    guardarFuncionalidadesRol();
                    limpiar();
                }
            }
        }

        private bool funcionalidadEstaAñadida()
        {
            for (int i = 0; i < listBox_funcionalidad.Items.Count; i++)
            {
                if (comboBox_func.GetItemText(comboBox_func.SelectedItem) == listBox_funcionalidad.GetItemText(listBox_funcionalidad.Items[i]))
                {
                    //ya existe en el listbox
                    return true;
                }
            }
            //no esta
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!funcionalidadEstaAñadida())
            {
                //agrego
                listBox_funcionalidad.Items.Add(comboBox_func.GetItemText(comboBox_func.SelectedItem));

                errorProvider_listFunc.Clear();
            }
        }

        private void textBox_nombre_rol_TextChanged(object sender, EventArgs e)
        {
            errorProvider_Nombre.Clear();
        }
    }
}
