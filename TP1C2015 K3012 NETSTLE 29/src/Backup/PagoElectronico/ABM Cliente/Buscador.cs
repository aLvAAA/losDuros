using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Cliente
{
    public partial class Buscador : Form
    {
        private SqlConnection sqlCon = null;

        private String tipoDocumento = null;

        private String nroDocumento = null;

        BindingSource bindingSource = null;

        private bool buscarEliminados = false;

        public Buscador()
        {
            InitializeComponent();
        }

        public Buscador(SqlConnection sqlCon, bool buscarEliminados):this()
        {
            this.sqlCon = sqlCon;

            //voy a buscar eliminados en la seccion modificacion de cliente
            this.buscarEliminados = buscarEliminados;

            //agrego un item que me perimita buscar por todos los tipos de documentos
            comboBox_tipoDoc.Items.Add("Todos");

            //lleno el combobox tipo documentos
            recuperarTipoDocumentos();

            //para que cuando cierre sin seleccionar yo pueda informar al form que lo llamo que el usr no hiso nada
            this.DialogResult = DialogResult.No;

            //nuevo
            bindingSource = new BindingSource();
            //
            dataGridView.DataSource = bindingSource;
        }

        void recuperarTipoDocumentos()
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TIPO_DOCUMENTO FROM NETSTLE.TIPODOCUMENTO";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox_tipoDoc.Items.Add(reader.GetString(0));
                }

                comboBox_tipoDoc.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            //
            comboBox_tipoDoc.SelectedIndex = 0;

            //limpio texbox
            textBox_nombre.Text = "";
            textBox_apellido.Text = "";
            textBox_email.Text = "";
            textBox_nroDoc.Text = "";
        }

        private void cargarDatagrid(String consulta)
        {
            //nuevo
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            //consulta para llenar el datagrid
            dataAdapter.SelectCommand = new SqlCommand();
            dataAdapter.SelectCommand.CommandText = consulta;
            dataAdapter.SelectCommand.Connection = sqlCon;

            //nuevo
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            //nueva
            DataTable tabla = new DataTable();
            //
            bindingSource.DataSource = tabla;
            
            //cargamos el datagrid
            dataAdapter.Fill(tabla);

            //libero
            dataAdapter.Dispose();
            //libero
            commandBuilder.Dispose();
            //libero
            tabla.Dispose();
        }

        private void buscar()
        {
            String conslt = "SELECT ";
            conslt += "CLI_NRO_DOCUMENTO,";
            conslt += "CLI_TIPO_DOCUMENTO,";
            conslt += "CLI_NOMBRE,";
            conslt += "CLI_APELLIDO,";
            conslt += "CLI_MAIL FROM NETSTLE.CLIENTE";

            String filtro = "";
            if (textBox_nombre.Text != "")
            {
                filtro = "CLI_NOMBRE LIKE '%" + textBox_nombre.Text + "%'";
            }

            if (textBox_apellido.Text != "")
            {
                filtro += (filtro != "") ? " AND " : "";
                filtro += "CLI_APELLIDO LIKE '%" + textBox_apellido.Text + "%'";
            }

            if (textBox_email.Text != "")
            {
                filtro += (filtro != "") ? " AND " : "";
                filtro += "CLI_MAIL LIKE '%" + textBox_email.Text + "%'";
            }

            if (textBox_nroDoc.Text != "")
            {
                filtro += (filtro != "") ? " AND " : "";
                filtro += "CLI_NRO_DOCUMENTO = " + textBox_nroDoc.Text + "";
            }

            if (comboBox_tipoDoc.SelectedIndex != 0)
            {
                filtro += (filtro != "") ? " AND " : "";
                filtro += "CLI_TIPO_DOCUMENTO = '" + comboBox_tipoDoc.GetItemText(comboBox_tipoDoc.SelectedItem) + "'";
            }

            //le agrego filtros?
            if (filtro != "")
            {
                conslt += " WHERE " + filtro;
            }

            //busco solo los clientes que estan sin eliminar?
            if (!buscarEliminados)
            {
                if (filtro != "")
                {
                    //no muestra clientes eliminados
                    conslt += " AND CLI_ELIMINADO = 0";
                }
                else
                {
                    //no muestra clientes eliminados
                    conslt += " WHERE CLI_ELIMINADO = 0";
                }
            }

            //a cargar el datagrid
            cargarDatagrid(conslt);

            //edito nombre de columnas del datagrid
            dataGridView.Columns[0].HeaderText = "Nro de Doc.";
            dataGridView.Columns[1].HeaderText = "Tipo de Doc.";
            dataGridView.Columns[2].HeaderText = "Nombre";
            dataGridView.Columns[3].HeaderText = "Apellido";
            dataGridView.Columns[4].HeaderText = "Mail";  
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void Buscador_Load(object sender, EventArgs e)
        {
            buscar();
        }

        private void textBox_nroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //recupero tipo documento
                tipoDocumento = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                //recupero nro documento
                nroDocumento = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

                //si se apreto doble click sobre una fila vacia
                if (tipoDocumento == "" || nroDocumento == "") return;

                //cierro
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        public String getClienteTipoDocumento()
        {
            return tipoDocumento;
        }

        public String getClienteNroDocumento()
        {
            return nroDocumento;
        }  
    }
}
