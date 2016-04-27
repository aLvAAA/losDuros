using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_destino
{
    public partial class SeleccionarAeronave : Form
    {
        public SeleccionarAeronave()
        {
            InitializeComponent();
        }

        private void SeleccionarAeronave_Load(object sender, EventArgs e)
        {
            //Cargar ciudades
            GD2C2015DataSetTableAdapters.CiudadTableAdapter ciudadAdapter = new GD2C2015DataSetTableAdapters.CiudadTableAdapter();
            GD2C2015DataSet.CiudadDataTable ciudadData = ciudadAdapter.GetData();
            GD2C2015DataSet.CiudadDataTable ciudadData2 = ciudadAdapter.GetData();

            origenDrop.DataSource = ciudadData;
            destinoDrop.DataSource = ciudadData2;
            origenDrop.DisplayMember = "ciudad_desc";
            origenDrop.ValueMember = "ciudad_id";
            destinoDrop.DisplayMember = "ciudad_desc";
            destinoDrop.ValueMember = "ciudad_id";
        }

        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            //Validar matricula
            String matriculaString = matriculaBox.Text;
            if (string.IsNullOrWhiteSpace(matriculaString))
            {matriculaBox.BackColor = Color.Red;
                return;
            }

            //Validar ciudades
            if (origenDrop.SelectedValue.GetHashCode() == destinoDrop.SelectedValue.GetHashCode())
            {
                MessageBox.Show("La ciudad de destino y de origen no pueden ser las mismas!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Buscar aeronave
            GD2C2015DataSetTableAdapters.AeronaveTableAdapter aeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            GD2C2015DataSet.AeronaveDataTable aeronaveData = aeronaveAdapter.GetDataBy(matriculaString, (decimal)origenDrop.SelectedValue, (decimal)destinoDrop.SelectedValue);
            if (aeronaveData.Count == 0)
            {
                MessageBox.Show("No se encontró el viaje!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Registro_destino.RegistrarLlegada a = new Registro_destino.RegistrarLlegada(aeronaveData[0].aero_id,aeronaveData[0].Field<Decimal>("viaje_id"));
            a.Show();
            this.Close();
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
            matriculaBox.Text = "";
        }

        private void matriculaBox_TextChanged(object sender, EventArgs e)
        {
            matriculaBox.BackColor = Color.White;
        }
    }
}
