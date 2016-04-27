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
    public partial class ListaTotalFacturado : Form
    {
        private SqlConnection sqlCon = null;

        BindingSource bindingSource = null;

        private int mes1;

        private int mes2;

        private int mes3;

        public ListaTotalFacturado()
        {
            InitializeComponent();
        }

        public ListaTotalFacturado(SqlConnection sqlCon, String anio, String trimestre):this()
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

            //se carga el datagrid
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
            String conslt = "SELECT ";
            conslt += "TIPO_CTA,SUM(TRANS_COSTO) FROM NETSTLE.TIPOCUENTA ";
            conslt += "LEFT JOIN NETSTLE.CUENTA ON (CTA_TIPO = TIPO_CTA) ";
            conslt += "JOIN NETSTLE.TRANSACCION ON (TRANS_CTA_EMISORA = CTA_NUMERO) ";
            conslt += "WHERE YEAR(TRANS_FECHA_FACTURADA) = '" + textBox1.Text + "' AND ";
            conslt += "MONTH(TRANS_FECHA_FACTURADA) IN ('" + mes1 + "', '" + mes2 + "', '" + mes3 + "')";
            conslt += "GROUP BY TIPO_CTA ";
            conslt += "ORDER BY SUM(TRANS_COSTO) DESC";

            //a cargar el datagrid
            cargarDatagrid(conslt);

            //edito nombre de columnas del datagrid
            dataGridView.Columns[0].HeaderText = "Tipo de cuenta.";
            dataGridView.Columns[1].HeaderText = "Total facturado.";
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
