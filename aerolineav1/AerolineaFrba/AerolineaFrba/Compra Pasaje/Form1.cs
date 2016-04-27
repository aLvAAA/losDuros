using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AerolineaFrba.Compra_Pasaje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            //Formato Fecha
            salidaPicker.Format = DateTimePickerFormat.Custom;
            salidaPicker.CustomFormat = "dd/MM/yyyy HH:mm";

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
        private void button1_Click(object sender, EventArgs e)
        {
            //Validar ciudades
            if (origenDrop.SelectedValue.GetHashCode() == destinoDrop.SelectedValue.GetHashCode())
            {
                MessageBox.Show("La ciudad de destino y de origen no pueden ser las mismas!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Buscar aeronave
            GD2C2015DataSetTableAdapters.AeronaveTableAdapter aeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            GD2C2015DataSet.AeronaveDataTable aeronaveData = aeronaveAdapter.GetDataByFechaDeViaje(salidaPicker.Value, (decimal)origenDrop.SelectedValue, (decimal)destinoDrop.SelectedValue);
            if (aeronaveData.Count == 0)
            {
                MessageBox.Show("No se encontró el viaje!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Compra_Pasaje.Form2 a = new Compra_Pasaje.Form2(aeronaveData);
            a.Show();

            this.Close();
        }
    }
}
