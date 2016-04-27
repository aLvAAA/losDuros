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
    public partial class DetalleCanje : Form
    {
        private string dni;
        private GD2C2015DataSetTableAdapters.CanjeTableAdapter CanjeAdapter;
        GD2C2015DataSet.CanjeDataTable CanjeData;

        public DetalleCanje(string dni)
        {
            InitializeComponent();
            this.dni = dni;
        }

        private void DetalleCanje_Load(object sender, EventArgs e)
        {
            //Cargar canjes
            CanjeAdapter = new GD2C2015DataSetTableAdapters.CanjeTableAdapter();
            CanjeData = CanjeAdapter.GetCanjesPorDni(Convert.ToDecimal(dni));
            if (CanjeData.Rows.Count > 0)
            {
                CanjeData.Columns.Remove("cliente");
                CanjeData.Columns.Remove("producto");
                CanjeData.Columns.Remove("canje_cantidad");
                CanjeData.Columns.Remove("canje_fecha");
                millasGrid.DataSource = CanjeData;
            }
        }
    }
}
