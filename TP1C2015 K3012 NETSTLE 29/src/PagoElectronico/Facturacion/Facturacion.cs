using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PagoElectronico.Facturacion
{
    public partial class Facturacion : Form
    {
        private SqlConnection sqlCon = null;

        private BindingSource bindingSource = null;
        
        private String usuario = null;

        private String nroDoc = null;

        private String tipoDoc = null;

        public Facturacion()
        {
            InitializeComponent();
        }

        public Facturacion(SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
        }

        public Facturacion(SqlConnection sqlCon, String usuario):this()
        {
            this.sqlCon = sqlCon;
            this.usuario = usuario;

            //nuevo
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;

            //muestro las transacciones
            cargarTransacciones(usuario);

            //desactivo boton
            button_buscar.Enabled = false;
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

        void cargarTransacciones(String nroDoc, String tipoDoc)
        {
            //identificacion de cliente
            String consulta = null;

            consulta += "SELECT TRANS_CTA_EMISORA,TRANS_DESCRIPCION,TRANS_COSTO,TRANS_TIPO_MONEDA FROM NETSTLE.TRANSACCION WHERE TRANS_PENDIENTE = 1 AND ";
            consulta += "TRANS_CTA_EMISORA IN (SELECT CTA_NUMERO FROM NETSTLE.CUENTA WHERE CTA_NRO_DOC_CLIENTE = " + nroDoc + " AND ";
            consulta += "CTA_TIPO_DOC_CLIENTE = '" + tipoDoc + "')";

            //cargo
            cargarDatagrid(consulta);

            //edito nombre de columnas del datagrid
            dataGridView.Columns[0].HeaderText = "Nro de Cuenta";
            dataGridView.Columns[1].HeaderText = "Descripcion";
            dataGridView.Columns[2].HeaderText = "Costo";
            dataGridView.Columns[3].HeaderText = "Moneda";
        }

        void cargarTransacciones(String usuario)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CLI_NRO_DOCUMENTO,CLI_TIPO_DOCUMENTO FROM NETSTLE.CLIENTE WHERE CLI_NOMBRE_USUARIO = '" + usuario + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    nroDoc = reader.GetDecimal(0).ToString();
                    tipoDoc = reader.GetString(1);
                }
            }

            //libero
            reader.Dispose();
            cmd.Dispose();

            if (nroDoc != null)
            {
                //cargo las transacciones
                cargarTransacciones(nroDoc,tipoDoc);
            }
        }

        private void actualizarEstadoCuentas()
        {
            //update
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            //update
            cmd.CommandText = "UPDATE NETSTLE.CUENTA SET CTA_ESTADO = 'HABILITADA',CTA_FECHA_APERTURA = (CASE WHEN CTA_FECHA_APERTURA IS NULL THEN " + "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + " ELSE CTA_FECHA_APERTURA END) ";
            cmd.CommandText += "WHERE CTA_ESTADO IN ('PENDIENTE_DE_ACTIVACION','INHABILITADA') AND ";
            cmd.CommandText += "CTA_NRO_DOC_CLIENTE = " + nroDoc + " AND ";
            cmd.CommandText += "CTA_TIPO_DOC_CLIENTE = '" + tipoDoc + "'"; 
            cmd.Connection = sqlCon;

            //ejecuto
            cmd.ExecuteNonQuery();

            //libero
            cmd.Dispose();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            ABM_Cliente.Buscador frmBusc = new ABM_Cliente.Buscador(sqlCon, false);

            if (frmBusc.ShowDialog() == DialogResult.Yes)
            {
                //cargo las transacciones para ese cliente
                cargarTransacciones(nroDoc = frmBusc.getClienteNroDocumento(), tipoDoc = frmBusc.getClienteTipoDocumento());
            }

            //libero
            frmBusc.Dispose();
        }

        private void crearFactura()
        {
            //inserto factura
            SqlCommand cmd = new SqlCommand();

            //fecha del archivo de configuracion
            DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

            //inserto cliente
            cmd.CommandText = "INSERT INTO NETSTLE.FACTURA(FACT_NRO_DOC_CLI,FACT_TIPO_DOC_CLI,FACT_FECHA) ";
            cmd.CommandText += "VALUES(" + nroDoc + ",'" + tipoDoc + "', " + "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + ")";
            cmd.Connection = sqlCon;

            if (cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al crear la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Factura generada.", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarEstadoCuentas();
                bindingSource.DataSource = null;
            }

            //libero
            cmd.Dispose();
        }

       
        private void button_facturar_Click(object sender, EventArgs e)
        {
            if (nroDoc != null)
            {
                if (dataGridView.RowCount > 1)
                {
                    crearFactura();
                }
            }
        }
    }
}
