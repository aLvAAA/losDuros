using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class listadoRol : Form
    {
        //Modo de operacion
        private bool BAJA;
        private GD2C2015DataSetTableAdapters.RolTableAdapter rolAdapter;
        private GD2C2015DataSet.RolDataTable rolData;

        public listadoRol(bool baja)
        {
            InitializeComponent();
            this.BAJA = baja;
        }

        private void listadoRol_Load(object sender, EventArgs e)
        {
            //Cargar lista de funcionalidades a la CheckListBox
            GD2C2015DataSetTableAdapters.FuncionalidadTableAdapter funcionalidadAdapter = new GD2C2015DataSetTableAdapters.FuncionalidadTableAdapter();
            GD2C2015DataSet.FuncionalidadDataTable funcionalidadData = funcionalidadAdapter.GetData();

            funcionalidadesBox.DataSource = funcionalidadData;
            funcionalidadesBox.DisplayMember = "func_desc";
            funcionalidadesBox.ValueMember = "func_id";

            //Carga lista de roles
            updateData();

            //Agrega columna de seleccion
            DataGridViewButtonColumn seleccionarButtonColumn = new DataGridViewButtonColumn();
            seleccionarButtonColumn.Name = "Seleccionar";

            if (listado.Columns["Seleccionar"] == null)
            {
                listado.Columns.Insert(3, seleccionarButtonColumn);
            }
        
        }
        private void limpiar_Click(object sender, EventArgs e)
        {
            nombreBox.Text = "";
            for (int i = 0; i < funcionalidadesBox.Items.Count; i++)
            {
                funcionalidadesBox.SetItemChecked(i, false);
            }
        }
    
        //Actualizar listado
        public void updateData()
        {
            rolAdapter = new GD2C2015DataSetTableAdapters.RolTableAdapter();
            rolData = rolAdapter.GetData();

            listado.DataSource = rolData;
        }

        //Manejar el click de una fila, segun el modo de operacion
        private void listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (BAJA)
                {
                    Abm_Rol.BajaRol a = new Abm_Rol.BajaRol((decimal)rolData[e.RowIndex]["rol_id"], this);
                    a.Show();
                }
                else
                {
                    Abm_Rol.ModificacionRol a = new Abm_Rol.ModificacionRol((decimal)rolData[e.RowIndex]["rol_id"], this);
                    a.Show();
                }
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            //Buscar por nombre
            string nombre = nombreBox.Text;
            rolData = rolAdapter.GetDataBy(nombre);
            
            //Chequear que posean las funcionalidades
            GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter funcionalidadXRolAdapter = new GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter();
            GD2C2015DataSet.FuncionalidadXRolDataTable funcionalidadXRolData = funcionalidadXRolAdapter.GetData();

            List<DataRow> filasAEliminar = new List<DataRow>();
            
            foreach (DataRow row in rolData.Rows)
            {
                decimal id = (decimal)row["rol_id"];

                //Por cada funcionalidad seleccionada, chequear que la implemente, sino marcar para borrar
                foreach (object item in funcionalidadesBox.CheckedItems)
                {
                    DataRowView funcionalidad = (DataRowView)item;
                    if (!funcionalidadXRolData.Any(dataRow => dataRow.Field<decimal>("rol_id") == id && dataRow.Field<decimal>("func_id") == (decimal)funcionalidad["func_id"]))
                        filasAEliminar.Add(row);
                }

            }

            //Eliminar las filtradas
            foreach(DataRow row in filasAEliminar){
                row.Delete();
            }
            rolData.AcceptChanges();

            //Mostrar las restantes
            listado.DataSource = rolData;
        }

    }
}
