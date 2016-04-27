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
    public partial class BajaCiudad : Form
    {
        private decimal id;
        private Abm_Ciudad.listadoCiudad caller;
        public BajaCiudad(decimal id,Abm_Ciudad.listadoCiudad caller)
        {
            InitializeComponent();
            this.id = id;
            this.caller = caller;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            //Eliminar
            GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();
            ciudadAdapter.Delete(id);

            caller.updateData();
            this.Close();
        }
    }
}
