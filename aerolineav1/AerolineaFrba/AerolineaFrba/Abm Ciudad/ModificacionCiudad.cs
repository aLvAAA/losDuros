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
    public partial class ModificacionCiudad : Form
    {
        private decimal id;
        private Abm_Ciudad.listadoCiudad caller;
        private GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter;

        public ModificacionCiudad(decimal id,Abm_Ciudad.listadoCiudad caller)
        {
            InitializeComponent();
            this.id = id;
            this.caller = caller;
        }

        private void ModificacionCiudad_Load(object sender, EventArgs e)
        {
            ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();

            //Cargar nombre
            GD2C2015DataSet.CiudadRow ciudad = ciudadAdapter.GetData().FindByciudad_id(id);
            nombreBox.Text = ciudad["ciudad_desc"].ToString();
        }

        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            String nombre = nombreBox.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                nombreBox.BackColor = Color.Red;
                return;
            }

            GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();
            ciudadAdapter.Update(nombre, id);

            caller.updateData();
            this.Close();
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
            nombreBox.Text = "";
        }

        private void nombreBox_TextChanged(object sender, EventArgs e)
        {
            nombreBox.BackColor = Color.White;
        }
    }
}
