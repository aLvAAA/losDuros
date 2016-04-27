using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class listadoCiudad : Form
    {
        //Modo de operacion: true -> Baja / false -> Modificacion
        private bool BAJA;
        private GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter;
        private GD2C2015DataSet.CiudadDataTable ciudadData;

        public listadoCiudad(bool baja)
        {
            InitializeComponent();
            this.BAJA = baja;
        }

        private void listadoCiudad_Load(object sender, EventArgs e)
        {
            //Carga lista de roles
            updateData();

            //Agrega columna de seleccion
            DataGridViewButtonColumn seleccionarButtonColumn = new DataGridViewButtonColumn();
            seleccionarButtonColumn.Name = "Seleccionar";

            if (listado.Columns["Seleccionar"] == null)
            {
                listado.Columns.Insert(2, seleccionarButtonColumn);
            }
        
        }
        private void limpiar_Click(object sender, EventArgs e)
        {
            nombreBox.Text = "";
        }
        
        //Actualiza el listado
        public void updateData()
        {
            ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();
            ciudadData = ciudadAdapter.GetData();

            listado.DataSource = ciudadData;
        }

        //Click en el listado
        private void listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //Si se produjo en la columna de seleccion
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //Segun el modo de operacion, llamar a uno u otro form
                if (BAJA)
                {
                    Abm_Ciudad.BajaCiudad a = new Abm_Ciudad.BajaCiudad((decimal)ciudadData[e.RowIndex]["ciudad_id"], this);
                    a.Show();
                }
                else
                {
                    Abm_Ciudad.ModificacionCiudad a = new Abm_Ciudad.ModificacionCiudad((decimal)ciudadData[e.RowIndex]["ciudad_id"], this);
                    a.Show();
                }
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            //Buscar por nombre
            string nombre = nombreBox.Text;
            ciudadData = ciudadAdapter.GetDataBy(nombre);

            listado.DataSource = ciudadData;
        }

    }
}
