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
    public partial class BajaRuta : Form
    {
        private decimal id;
        private Abm_Ruta.listadoRuta caller;
        public BajaRuta(decimal id,Abm_Ruta.listadoRuta caller)
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
            //Eliminar rol
            GD2C2015DataSetTableAdapters.RutaTableAdapter rutaAdapter = new GD2C2015DataSetTableAdapters.RutaTableAdapter();
            rutaAdapter.Delete(id);

            caller.getFromDB();
            this.Close();
        }
    }
}
