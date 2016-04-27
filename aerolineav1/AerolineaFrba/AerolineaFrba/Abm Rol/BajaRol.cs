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
    public partial class BajaRol : Form
    {
        private decimal id;
        private Abm_Rol.listadoRol caller;
        public BajaRol(decimal id,Abm_Rol.listadoRol caller)
        {
            InitializeComponent();
            this.id = id;
            this.caller = caller;
        }
        
        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            //Eliminar rol
            GD2C2015DataSetTableAdapters.RolTableAdapter rolAdapter = new GD2C2015DataSetTableAdapters.RolTableAdapter();
            rolAdapter.Delete(id);

            caller.updateData();
            this.Close();
        }
    }
}
