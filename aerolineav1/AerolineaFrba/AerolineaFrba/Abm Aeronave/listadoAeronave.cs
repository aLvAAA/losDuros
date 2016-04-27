using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class listadoAeronave : Form
    {
        public enum Operacion {Baja,Modificacion,Seleccion};
        public decimal seleccion;
        private int operacion;
        private GD2C2015DataSetTableAdapters.AeronaveTableAdapter AeronaveAdapter;
        private GD2C2015DataSet.AeronaveDataTable AeronaveData;

        public listadoAeronave(int operacion)
        {
            InitializeComponent();
            this.operacion = operacion;
            this.seleccion = -1;
        }

        private void listadoRol_Load(object sender, EventArgs e)
        {
            
            //Cargar tipos de servicio
            GD2C2015DataSetTableAdapters.ServicioTableAdapter servicioAdapter = new GD2C2015DataSetTableAdapters.ServicioTableAdapter();
            GD2C2015DataSet.ServicioDataTable servicioData = servicioAdapter.GetData();
            servicioDrop.DataSource = servicioData;
            servicioDrop.DisplayMember = "servicio_descripcion";
            servicioDrop.ValueMember = "servicio_id";


            GD2C2015DataSetTableAdapters.TipoButacaTableAdapter tipoButacaAdapter = new GD2C2015DataSetTableAdapters.TipoButacaTableAdapter();
            GD2C2015DataSet.TipoButacaDataTable tipoButacaData = tipoButacaAdapter.GetData();
           
            servicioDrop.SelectedIndex = -1;

            //Carga lista de Aeronaves
            configurarDataGrid();
            AeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            AeronaveData = AeronaveAdapter.GetAeronavesHabilitadas();
            updateData();
        
        }
        private void limpiar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtKG.Text = "";
            txtFabricante.Text = "";
            txtModelo.Text = "";

            servicioDrop.SelectedIndex = -1;

            getFromDB();
        }

        public void configurarDataGrid()
        {
            //Crear columnas
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "Id";
            dataGridView1.Columns.Insert(0, id);
            id.Visible = false;

            DataGridViewTextBoxColumn matricula  = new DataGridViewTextBoxColumn();
            matricula.Name = "Matricula";
            dataGridView1.Columns.Insert(1, matricula);

            DataGridViewTextBoxColumn fabricante  = new DataGridViewTextBoxColumn();
            fabricante.Name = "Fabricante";
            dataGridView1.Columns.Insert(2, fabricante);

            DataGridViewTextBoxColumn modelo = new DataGridViewTextBoxColumn();
            modelo.Name = "Modelo";
            dataGridView1.Columns.Insert(3, modelo);

            DataGridViewTextBoxColumn servicio = new DataGridViewTextBoxColumn();
            servicio.Name = "Servicio";
            dataGridView1.Columns.Insert(4, servicio);

            DataGridViewTextBoxColumn KGDisponibles = new DataGridViewTextBoxColumn();
            KGDisponibles.Name = "KGDisponibles";
            dataGridView1.Columns.Insert(5, KGDisponibles);

            DataGridViewTextBoxColumn totalButacas = new DataGridViewTextBoxColumn();
            totalButacas.Name = "Total Butacas";
            dataGridView1.Columns.Insert(6, totalButacas);

            DataGridViewButtonColumn seleccionarButtonColumn = new DataGridViewButtonColumn();
            seleccionarButtonColumn.Name = "Seleccionar";
            dataGridView1.Columns.Insert(7, seleccionarButtonColumn);
        }
         public void updateData(){
             dataGridView1.Rows.Clear();

            //Cargar datos
            GD2C2015DataSetTableAdapters.ServicioTableAdapter servicioAdapter = new GD2C2015DataSetTableAdapters.ServicioTableAdapter();
            foreach (DataRow row in AeronaveData.Rows)
            {
                
                dataGridView1.Rows.Add(row.Field<Decimal>("aero_id"),
                                        row.Field<String>("aero_matricula"),
                                        row.Field<String>("aero_fabricante"),
                                        row.Field<String>("aero_modelo"),
                                        servicioAdapter.GetData().FindByservicio_id(row.Field<Decimal>("servicio"))["servicio_descripcion"],
                                        row.Field<Decimal>("aero_kg_disp"),
                                        row.Field<int>("Total Butacas"));
         
            }
        }

         public void getFromDB()
         {
             AeronaveData = AeronaveAdapter.GetAeronavesHabilitadas();
             updateData();
         }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (operacion == (int)Operacion.Baja)
                {
                    Abm_Aeronave.BajaAeronaveTipo a = new Abm_Aeronave.BajaAeronaveTipo((decimal)AeronaveData[e.RowIndex]["aero_id"], this);
                    a.Show();
                }
                else if (operacion == (int)Operacion.Modificacion)
                {
                    Abm_Aeronave.ModificacionAeronave a = new Abm_Aeronave.ModificacionAeronave((decimal)AeronaveData[e.RowIndex]["aero_id"], this);
                    a.Show();
                }
                else{
                    this.seleccion = (decimal)AeronaveData[e.RowIndex]["aero_id"];
                    this.Close();
                }
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            AeronaveData = AeronaveAdapter.GetAeronavesHabilitadas();
            List<DataRow> filasAEliminar = new List<DataRow>();
            
            String matricula = txtMatricula.Text;
            if (!string.IsNullOrWhiteSpace(matricula))
            {
                    foreach (DataRow row in AeronaveData.Rows)
                    {
                        if (row.Field<String>("aero_matricula") != matricula) filasAEliminar.Add(row);
                    }
             
                //Eliminar las filtradas
                foreach (DataRow row in filasAEliminar)
                {
                    row.Delete();
                }

                AeronaveData.AcceptChanges();
                updateData();
                return;
            }
            //Buscar por otros parametros
            else
            {
                String fabricante = txtFabricante.Text;
                String modelo = txtModelo.Text;
                decimal servicio = servicioDrop.SelectedIndex != -1 ? (decimal)servicioDrop.SelectedValue : -1;

                //Validar kilos disponibles
                String kgString = txtKG.Text;
                decimal kg;
                if (string.IsNullOrWhiteSpace(kgString)) kg = -1;
                else if (!Decimal.TryParse(kgString, out kg))
                {
                    MessageBox.Show("Los kilos deben ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                //Buscar y actualizar listado
                AeronaveData = AeronaveAdapter.BuscarAeronaves(modelo,fabricante,servicio,kg);
                updateData();
                return;
            }
            
        }
    }
}
