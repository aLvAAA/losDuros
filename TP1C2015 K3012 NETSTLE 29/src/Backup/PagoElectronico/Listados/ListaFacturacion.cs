using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.Listados
{
    public partial class ListaFacturacion : Form
    {
        private SqlConnection sqlCon = null;

        private int mes1;

        private int mes2;

        private int mes3;

        BindingSource bindingSource = null;

        public ListaFacturacion()
        {
            InitializeComponent();
        }

        public ListaFacturacion(SqlConnection sqlCon, String anio, String trimestre):this()
        {
            this.sqlCon = sqlCon;

            this.DialogResult = DialogResult.Yes;

            textBox1.Text = anio;

            textBox2.Text = trimestre;

            //se guardan los meses
            guardarTrimestre(trimestre);

            //nuevo
            bindingSource = new BindingSource();
            //
            dataGridView.DataSource = bindingSource;

            //se carga el dataGrid
            buscar();
        }

        private void guardarTrimestre(String trimestre)
        {
            if (trimestre == "De Enero a Marzo")
            {
                this.mes1 = 1;
                this.mes2 = 2;
                this.mes3 = 3;
            }
            if (trimestre == "De Abril a Junio")
            {
                this.mes1 = 4;
                this.mes2 = 5;
                this.mes3 = 6;
            }
            if (trimestre == "De Julio a Septiembre")
            {
                this.mes1 = 7;
                this.mes2 = 8;
                this.mes3 = 9;
            } 
            if (trimestre == "De Octubre a Diciembre")
            {
                this.mes1 = 10;
                this.mes2 = 11;
                this.mes3 = 12;
            }
        }

        private void buscar()
        {
            String conslt = "SELECT TOP 5 ";
            conslt += "CLI_NOMBRE,CLI_NRO_DOCUMENTO, ";
            conslt += "COUNT(*) FROM NETSTLE.FACTURA,NETSTLE.ITEMFACTURA,NETSTLE.CLIENTE ";
            conslt += "WHERE FACT_NUMERO = ITEM_NRO_FACTURA AND FACT_NRO_DOC_CLI = CLI_NRO_DOCUMENTO AND FACT_TIPO_DOC_CLI = CLI_TIPO_DOCUMENTO AND ";
            conslt += "YEAR(FACT_FECHA) = '" + textBox1.Text +  "' AND ";
            conslt += "MONTH(FACT_FECHA) IN ('" + mes1 + "', '" + mes2 + "', '" + mes3 + "')";
            conslt += "GROUP BY CLI_NOMBRE,CLI_NRO_DOCUMENTO ";
            conslt += "ORDER BY 3 DESC ";

            //a cargar el datagrid
            cargarDatagrid(conslt);

            //edito nombre de columnas del datagrid
            dataGridView.Columns[0].HeaderText = "Nombre del cliente.";
            dataGridView.Columns[1].HeaderText = "Número de documento.";
            dataGridView.Columns[2].HeaderText = "Cantidad de comisioines facturadas.";
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

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            //cierro
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        
    }
}
