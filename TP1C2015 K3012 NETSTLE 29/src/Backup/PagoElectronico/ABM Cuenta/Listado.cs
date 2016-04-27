using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class Listado : Form
    {
        private SqlConnection sqlCon = null;

        private BindingSource bindingSource = null;

        private String numeroCuenta = null;

        private String usuario = null;

        private bool mostrarPendientesDeActivacion = true;

        private bool soloHabilitadas = false;

        public Listado()
        {
            InitializeComponent();
        }

        public Listado(SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
        }

        public Listado(bool soloHabilitadas, SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;
            this.soloHabilitadas = soloHabilitadas;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
        }

        public Listado(SqlConnection sqlCon, bool mostrarPendientesDeActivacion):this()
        {
            this.sqlCon = sqlCon;
            this.mostrarPendientesDeActivacion = mostrarPendientesDeActivacion;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
        }

        public Listado(SqlConnection sqlCon, String usuario, bool mostrarPendientesDeActivacion):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;
            this.mostrarPendientesDeActivacion = mostrarPendientesDeActivacion;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
        }

        public Listado(SqlConnection sqlCon, String usuario):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
        }

        public Listado(bool soloHabilitadas, SqlConnection sqlCon, String usuario):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;
            this.soloHabilitadas = soloHabilitadas;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
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

        private void Buscador_Load(object sender, EventArgs e)
        {
            //identificacion de cliente
            String consulta = null;

            consulta = "SELECT CTA_NUMERO,CTA_TIPO,CTA_PAIS,CTA_ESTADO FROM NETSTLE.CUENTA WHERE CTA_ESTADO != 'CERRADA'";

            if (!mostrarPendientesDeActivacion)
            {
                consulta += "AND CTA_ESTADO != 'PENDIENTE_DE_ACTIVACION'";
            }

            if (soloHabilitadas)
            {
                consulta += "AND CTA_ESTADO = 'HABILITADA'";
            }

            if (usuario != null)
            {
                consulta += " AND CTA_NUMERO IN (SELECT CTA_NUMERO FROM NETSTLE.CLIENTE";
                consulta += " JOIN NETSTLE.CUENTA ON (CTA_NRO_DOC_CLIENTE = CLI_NRO_DOCUMENTO AND CTA_TIPO_DOC_CLIENTE = CLI_TIPO_DOCUMENTO)";
                consulta += " WHERE CLI_NOMBRE_USUARIO = '" + usuario + "')";
            }

            //cargo
            cargarDatagrid(consulta);

            //edito nombre de columnas del datagrid
            dataGridView.Columns[0].HeaderText = "Numero de cuenta";
            dataGridView.Columns[1].HeaderText = "Tipo";
            dataGridView.Columns[2].HeaderText = "Pais";
            dataGridView.Columns[3].HeaderText = "Estado";
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //recupero numero de cuenta
                numeroCuenta = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

                //si se apreto doble click sobre una fila vacia
                if (numeroCuenta == "") return;

                //cierro
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        public String getNumeroDeCuenta()
        {
            return numeroCuenta;
        }        
    }
}
