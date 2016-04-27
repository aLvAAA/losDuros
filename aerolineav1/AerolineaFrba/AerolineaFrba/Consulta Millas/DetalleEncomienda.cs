using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Consulta_Millas
{
    public partial class DetalleEncomienda : Form
    {
        private string dni;
        private GD2C2015DataSetTableAdapters.EncomiendaTableAdapter EncomiendaAdapter;
        GD2C2015DataSet.EncomiendaDataTable EncomiendaData;

        public DetalleEncomienda(string dni)
        {
            InitializeComponent();
            this.dni = dni;
        }

        private void DetalleEncomienda_Load(object sender, EventArgs e)
        {
            //Cargar encomiendas
            EncomiendaAdapter = new GD2C2015DataSetTableAdapters.EncomiendaTableAdapter();
            EncomiendaData = EncomiendaAdapter.MillasDeEncomiendas(Convert.ToDecimal(dni));
            if (EncomiendaData.Rows.Count > 0)
            {
                EncomiendaData.Columns.Remove("viaje_id");
                EncomiendaData.Columns.Remove("encom_precio");
                EncomiendaData.Columns.Remove("encom_KG");
                EncomiendaData.Columns.Remove("compra_id");
                encomiendasGrid.DataSource = EncomiendaData;
            }
        }
    }
}
