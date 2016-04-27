using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class listadoRuta : Form
    {
        //Modo de operacion
        public enum Operacion {Baja,Modificacion,Seleccion};
        public decimal seleccion;
        private int operacion;
        private GD2C2015DataSetTableAdapters.RutaTableAdapter rutaAdapter;
        private GD2C2015DataSet.RutaDataTable rutaData;

        public listadoRuta(int operacion)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.seleccion = -1;
        }

        private void listadoRol_Load(object sender, EventArgs e)
        {
            //Cargar ciudades
            GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();
            GD2C2015DataSet.CiudadDataTable ciudadData = ciudadAdapter.GetData();
            GD2C2015DataSet.CiudadDataTable ciudadData2 = ciudadAdapter.GetData();

            origenDrop.DataSource = ciudadData;
            destinoDrop.DataSource = ciudadData2;
            origenDrop.DisplayMember = "ciudad_desc";
            origenDrop.ValueMember = "ciudad_id";
            destinoDrop.DisplayMember = "ciudad_desc";
            destinoDrop.ValueMember = "ciudad_id";

            //Cargar tipos de servicio
            GD2C2015DataSetTableAdapters.ServicioTableAdapter servicioAdapter = new GD2C2015DataSetTableAdapters.ServicioTableAdapter();
            GD2C2015DataSet.ServicioDataTable servicioData = servicioAdapter.GetData();
            servicioDrop.DataSource = servicioData;
            servicioDrop.DisplayMember = "servicio_descripcion";
            servicioDrop.ValueMember = "servicio_id";

            servicioDrop.SelectedIndex = -1;
            origenDrop.SelectedIndex = -1;
            destinoDrop.SelectedIndex = -1;

            //Carga lista de rutas
            configurarDataGrid();
            rutaAdapter = new GD2C2015DataSetTableAdapters.RutaTableAdapter();
            rutaData = rutaAdapter.GetData();
            updateData();
        
        }
        private void limpiar_Click(object sender, EventArgs e)
        {
            nombreBox.Text = "";
            basePasaje.Text = "";
            baseKG.Text = "";
            servicioDrop.SelectedIndex = -1;
            origenDrop.SelectedIndex = -1;
            destinoDrop.SelectedIndex = -1;
        }

        public void configurarDataGrid()
        {
            //Crear columnas
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Código";
            listado.Columns.Insert(0, idColumn);

            DataGridViewTextBoxColumn origen = new DataGridViewTextBoxColumn();
            origen.Name = "Origen";
            listado.Columns.Insert(1, origen);

            DataGridViewTextBoxColumn destino = new DataGridViewTextBoxColumn();
            destino.Name = "Destino";
            listado.Columns.Insert(2, destino);

            DataGridViewTextBoxColumn servicio = new DataGridViewTextBoxColumn();
            servicio.Name = "Servicio";
            listado.Columns.Insert(3, servicio);

            DataGridViewTextBoxColumn precioBase = new DataGridViewTextBoxColumn();
            precioBase.Name = "Base Pasaje";
            listado.Columns.Insert(4, precioBase);

            DataGridViewTextBoxColumn precioKG = new DataGridViewTextBoxColumn();
            precioKG.Name = "Base KG";
            listado.Columns.Insert(5, precioKG);

            DataGridViewCheckBoxColumn habilitado = new DataGridViewCheckBoxColumn();
            habilitado.Name = "Habilitado";
            listado.Columns.Insert(6, habilitado);

            DataGridViewButtonColumn seleccionarButtonColumn = new DataGridViewButtonColumn();
            seleccionarButtonColumn.Name = "Seleccionar";
            listado.Columns.Insert(7, seleccionarButtonColumn);
        }

        public void updateData(){
             listado.Rows.Clear();

            //Cargar datos
            GD2C2015DataSetTableAdapters.ServicioTableAdapter servicioAdapter = new GD2C2015DataSetTableAdapters.ServicioTableAdapter();
            GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();
            foreach (DataRow row in rutaData.Rows)
            {
                if (ciudadAdapter.GetData().FindByciudad_id(row.Field<Decimal>("ruta_origen")) != null &&
                    ciudadAdapter.GetData().FindByciudad_id(row.Field<Decimal>("ruta_destino")) != null)
                    listado.Rows.Add(row.Field<Decimal>("ruta_id"),
                                            ciudadAdapter.GetData().FindByciudad_id(row.Field<Decimal>("ruta_origen"))["ciudad_desc"],
                                            ciudadAdapter.GetData().FindByciudad_id(row.Field<Decimal>("ruta_destino"))["ciudad_desc"],
                                            servicioAdapter.GetData().FindByservicio_id(row.Field<Decimal>("ruta_servicio"))["servicio_descripcion"],
                                            row.Field<Decimal>("ruta_precio_base").ToString(),
                                            row.Field<Decimal>("ruta_precio_base_KG").ToString(),
                                            row.Field<Boolean>("ruta_habilitada"));
            }
        }

        //Actualizar listado
        public void getFromDB()
        {
            rutaData = rutaAdapter.GetData();
            updateData();
        }

        //Ante un click, segun el modo de operacion, mostrar un form
        private void listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (operacion == (int)Operacion.Baja)
                {
                    Abm_Ruta.BajaRuta a = new Abm_Ruta.BajaRuta((decimal)rutaData[e.RowIndex]["ruta_id"], this);
                    a.Show();
                }
                else if (operacion == (int)Operacion.Modificacion)
                {
                    Abm_Ruta.ModificacionRuta a = new Abm_Ruta.ModificacionRuta((decimal)rutaData[e.RowIndex]["ruta_id"], this);
                    a.Show();
                }
                else{
                    this.seleccion = (decimal)rutaData[e.RowIndex]["ruta_id"];
                    this.Close();
                }
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            rutaData = rutaAdapter.GetData();
            List<DataRow> filasAEliminar = new List<DataRow>();

            //Buscar por codigo (no busca por las demas)
            String codigoString = nombreBox.Text;
            decimal codigo;
            if (!string.IsNullOrWhiteSpace(codigoString))
            {
                if (Decimal.TryParse(codigoString, out codigo))
                {
                    foreach (DataRow row in rutaData.Rows)
                    {
                        if (row.Field<Decimal>("ruta_id") != codigo) filasAEliminar.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("El codigo debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    nombreBox.BackColor = Color.Red;
                    return;
                }

                //Eliminar las filtradas
                foreach (DataRow row in filasAEliminar)
                {
                    row.Delete();
                }

                rutaData.AcceptChanges();
                updateData();
                return;
            }
            //Buscar por otros parametros
            else
            {
                decimal origen = origenDrop.SelectedIndex != -1? (decimal)origenDrop.SelectedValue:-1;
                decimal destino = destinoDrop.SelectedIndex != -1 ? (decimal)destinoDrop.SelectedValue : -1;
                decimal servicio = servicioDrop.SelectedIndex != -1 ? (decimal)servicioDrop.SelectedValue : -1;
                
                //Validar precio pasaje
                String pasajeString = basePasaje.Text;
                decimal pasaje;
                if (string.IsNullOrWhiteSpace(pasajeString)) pasaje = -1;
                else if(!Decimal.TryParse(pasajeString, out pasaje))
                {
                    MessageBox.Show("El precio base por pasaje debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    baseKG.BackColor = Color.Red;
                    return;
                }

                //Validar precio kilo
                String kgString = baseKG.Text;
                decimal kg;
                if (string.IsNullOrWhiteSpace(kgString)) kg = -1;
                else if (!Decimal.TryParse(kgString, out kg))
                {
                    MessageBox.Show("El precio base por Kg debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    baseKG.BackColor = Color.Red;
                    return;
                }

                //Buscar y actualizar listado
                rutaData = rutaAdapter.GetDataBy(origen,destino,servicio,pasaje,kg);
                updateData();
                return;
            }
            
        }
    }
}
