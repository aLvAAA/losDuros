using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.Consulta_Saldos
{
    public partial class Estado : Form
    {
        private SqlConnection sqlCon = null;

        BindingSource bindingSource1 = null;
        
        BindingSource bindingSource2 = null;

        BindingSource bindingSource3 = null;
        
        public Estado()
        {
            InitializeComponent();
        }

        public Estado(SqlConnection sqlCon, String cuenta): this()
        {
            this.sqlCon = sqlCon;

            this.DialogResult = DialogResult.Yes;

            textBox1.Text = cuenta;

            recuperarSaldo(cuenta);

            //nuevos
            bindingSource1 = new BindingSource();
            dataGridView1.DataSource = bindingSource1;

            bindingSource2 = new BindingSource();
            dataGridView2.DataSource = bindingSource2;

            bindingSource3 = new BindingSource();
            dataGridView3.DataSource = bindingSource3;

            //se cargan dataGrids
            buscar1();
            buscar2();
            buscar3();
        }

        private void recuperarSaldo(String cuenta)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CTA_SALDO ";
            cmd.CommandText += "FROM NETSTLE.CUENTA WHERE ";
            cmd.CommandText += "CTA_NUMERO = " + cuenta;
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    //limpio por las dudas
                    textBox2.Text = "";

                    //cargo saldo
                    textBox2.Text = reader.GetDecimal(0).ToString();
                } 
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void buscar1()
        {
            String conslt = "SELECT TOP 5 DEP_CODIGO, ";
            conslt += "DEP_FECHA, ";
            conslt += "DEP_IMPORTE ";
            conslt += " FROM NETSTLE.CUENTA,NETSTLE.DEPOSITO ";
            conslt += "WHERE CTA_NUMERO = DEP_NRO_CUENTA AND CTA_NUMERO = '" + textBox1.Text + "' ";
            conslt += "ORDER BY DEP_FECHA DESC ";

            //a cargar el datagrid
            cargarDatagrid1(conslt);

            //edito nombre de columnas del datagrid
            dataGridView1.Columns[0].HeaderText = "Código de depósito.";
            dataGridView1.Columns[1].HeaderText = "Fecha de depósito.";
            dataGridView1.Columns[2].HeaderText = "Importe.";
        }

        private void buscar2()
        {
            String conslt = "SELECT TOP 5 RET_CODIGO, ";
            conslt += "RET_FECHA, ";
            conslt += "RET_IMPORTE ";
            conslt += " FROM NETSTLE.CUENTA,NETSTLE.RETIRO ";
            conslt += "WHERE CTA_NUMERO = RET_NRO_CUENTA AND CTA_NUMERO = '" + textBox1.Text + "' ";
            conslt += "ORDER BY RET_FECHA DESC ";

            //a cargar el datagrid
            cargarDatagrid2(conslt);

            //edito nombre de columnas del datagrid
            dataGridView2.Columns[0].HeaderText = "Código de retiro.";
            dataGridView2.Columns[1].HeaderText = "Fecha de retiro.";
            dataGridView2.Columns[2].HeaderText = "Importe.";
        }

        private void buscar3()
        {
            String conslt = "SELECT TOP 10 TRANSF_CODIGO, ";
            conslt += "TRANSF_FECHA, ";
            conslt += "TRANSF_IMPORTE, ";
            conslt += "TRANSF_CTA_DESTINO ";
            conslt += " FROM NETSTLE.CUENTA,NETSTLE.TRANSFERENCIA ";
            conslt += "WHERE CTA_NUMERO = TRANSF_CTA_ORIGEN AND CTA_NUMERO = '" + textBox1.Text + "' ";
            conslt += "ORDER BY TRANSF_FECHA DESC ";

            //a cargar el datagrid
            cargarDatagrid3(conslt);

            //edito nombre de columnas del datagrid
            dataGridView3.Columns[0].HeaderText = "Código de transferencia.";
            dataGridView3.Columns[1].HeaderText = "Fecha de transferencia";
            dataGridView3.Columns[2].HeaderText = "Importe.";
            dataGridView3.Columns[3].HeaderText = "Cuenta destino.";
        }

        private void cargarDatagrid1(String consulta)
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
            bindingSource1.DataSource = tabla;

            //cargamos el datagrid
            dataAdapter.Fill(tabla);

            //libero
            dataAdapter.Dispose();
            //libero
            commandBuilder.Dispose();
            //libero
            tabla.Dispose();
        }

        private void cargarDatagrid2(String consulta)
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
            bindingSource2.DataSource = tabla;

            //cargamos el datagrid
            dataAdapter.Fill(tabla);

            //libero
            dataAdapter.Dispose();
            //libero
            commandBuilder.Dispose();
            //libero
            tabla.Dispose();
        }

        private void cargarDatagrid3(String consulta)
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
            bindingSource3.DataSource = tabla;

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
