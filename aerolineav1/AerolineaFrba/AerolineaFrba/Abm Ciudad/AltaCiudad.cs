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
    public partial class AltaCiudad : Form
    {
        public AltaCiudad()
        {
            InitializeComponent();
        }

        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            //Validar nombre
            String nombre = nombreBox.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                nombreBox.BackColor = Color.Red;
                return;
            }

            //Insertar nueva ciudad
            GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();
            ciudadAdapter.Insert(nombre);

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
