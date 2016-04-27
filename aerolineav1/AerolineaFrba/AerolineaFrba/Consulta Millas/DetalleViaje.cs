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
    public partial class DetalleViaje : Form
    {
        private string dni;
        private GD2C2015DataSetTableAdapters.PasajeTableAdapter PasajeAdapter;
        GD2C2015DataSet.PasajeDataTable PasajeData;

        public DetalleViaje(string dni)
        {
            InitializeComponent();
            this.dni = dni;
        }

        private void DetalleViaje_Load(object sender, EventArgs e)
        {
            //Cargar Millas
            PasajeAdapter = new GD2C2015DataSetTableAdapters.PasajeTableAdapter();
            PasajeData = PasajeAdapter.MillasDeViajes(Convert.ToDecimal(dni));
            if (PasajeData.Rows.Count > 0)
            {
                PasajeData.Columns.Remove("viaje_id");
                PasajeData.Columns.Remove("pasaje_butaca");
                PasajeData.Columns.Remove("pasaje_precio");
                PasajeData.Columns.Remove("pasaje_cliente");
                PasajeData.Columns.Remove("compra_id");
                viajesGrid.DataSource = PasajeData;
            }
        }
    }
}
