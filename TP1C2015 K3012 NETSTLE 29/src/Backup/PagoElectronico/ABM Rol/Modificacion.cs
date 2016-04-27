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
    public partial class Modificacion : Form
    {
        private SqlConnection sqlCon = null;

        public Modificacion()
        {
            InitializeComponent();
        }

        public Modificacion(SqlConnection sqlCon): this()
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
            //libero
            cmd.Dispose();
        }

        void recuperarFuncionalidadesRol(String rol)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT FUNCROL_FUNCIONALIDAD_NOMBRE FROM NETSTLE.FUNCIONALIDADXROL ";
            cmd.CommandText += "WHERE FUNCROL_NOMBRE_ROL = '" + rol + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego nuevo item
                    listBox_funcionalidad.Items.Add(reader.GetString(0));
                }
            }

            //libero
            reader.Close();
            //libero
            cmd.Dispose();
        }

        private void estaHabilitadoRol(String rol)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT ROL_HABILITADO FROM NETSTLE.ROL ";
            cmd.CommandText += "WHERE ROL_NOMBRE = '" + rol + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    if (reader.GetBoolean(0))
                    {
                        comboBox_habiltado.SelectedIndex = 0;
                        comboBox_habiltado.Enabled = false;
                    }
                    else
                    {
                        comboBox_habiltado.SelectedIndex = 1;
                        comboBox_habiltado.Enabled = true;
                    }
                }
            }

            //libero
            reader.Close();
            //libero
            cmd.Dispose();
        }

        private void button_sel_Click(object sender, EventArgs e)
        {
            //nueva instancia
            ABM_Rol.SeleccionRol frmSel = new ABM_Rol.SeleccionRol(sqlCon, "modificar");

            //muestro
            if (frmSel.MostrarSiEsNecesario() == DialogResult.Yes)
            {
                //muestro nombre en textbox
                textBox_nombre_rol.Text = frmSel.getRolSeleccionado();

                //limpio listbox para cargarles las nuevas funcionalidades
                listBox_funcionalidad.Items.Clear();

                //lleno el listbox con las funcionaldiades del rol
                recuperarFuncionalidadesRol(frmSel.getRolSeleccionado());

                //cambio item seleccionado del combobox segun este o no habilitado
                estaHabilitadoRol(frmSel.getRolSeleccionado());
            }

            //libero
            frmSel.Dispose();

            button_eliminar.Enabled = false;
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            if (textBox_nombre_rol.Text != "")
            {
                //limpio listbox para cargarles las nuevas funcionalidades
                listBox_funcionalidad.Items.Clear();

                //lleno el listbox con las funcionaldiades del rol
                recuperarFuncionalidadesRol(textBox_nombre_rol.Text);

                //cambio item seleccionado del combobox segun este o no habilitado
                estaHabilitadoRol(textBox_nombre_rol.Text);
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

        private void button_agregar_Click(object sender, EventArgs e)
        {
            if (textBox_nombre_rol.Text != "")
            {
                if (!funcionalidadEstaAñadida())
                {
                    //agrego
                    listBox_funcionalidad.Items.Add(comboBox_func.GetItemText(comboBox_func.SelectedItem));

                    errorProvider_listFunc.Clear();
                }
            }
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (listBox_funcionalidad.SelectedItem != null)
            {
                //elimino el itemo seleccionado del listbox y vuelvo a desabilitar el boton eliminar
                listBox_funcionalidad.Items.Remove(listBox_funcionalidad.SelectedItem);

                button_eliminar.Enabled = false;
            }
        }

        private void listBox_funcionalidad_Click(object sender, EventArgs e)
        {
            if (listBox_funcionalidad.SelectedItem != null)
            {
                button_eliminar.Enabled = true;
            }
        }

        private bool actualizarEstadoHabilitado()
        {
            //update
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.ROL SET ROL_HABILITADO = " + (comboBox_habiltado.SelectedIndex == 0 ? "1" : "0"); 
            cmd.CommandText += " WHERE ROL_NOMBRE = '" + textBox_nombre_rol.Text + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al actualizar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //libero
            cmd.Dispose();
            //exito
            return true;
        }

        private bool borrarFuncionalidadesRol()
        {
            //delete
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM NETSTLE.FUNCIONALIDADXROL ";
            cmd.CommandText += "WHERE FUNCROL_NOMBRE_ROL = '" + textBox_nombre_rol.Text + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                return false;
            }

            //libero
            cmd.Dispose();
            //exito
            return true;
        }

        private void guardarFuncionalidadesRol()
        {
            bool err_insert = false;

            for (int i = 0; i < listBox_funcionalidad.Items.Count; i++)
            {
                //insert
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
                MessageBox.Show("Se ha guardado la modificacion.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            if (listBox_funcionalidad.Items.Count != 0)
            {
                if (actualizarEstadoHabilitado()){

                    if (borrarFuncionalidadesRol()){

                        //
                        guardarFuncionalidadesRol();

                        //textbox vacio
                        textBox_nombre_rol.Text = "";

                        //mostramos por default el primer item
                        comboBox_func.SelectedIndex = 0;

                        //dejo el listbox sin ningun item
                        listBox_funcionalidad.Items.Clear();
                    }
                }
            }
            else
            {
                errorProvider_listFunc.SetError(listBox_funcionalidad, "Debe tener al menos una funcionalidad asignada al rol.");
                return;
            }
        }
    }
}
