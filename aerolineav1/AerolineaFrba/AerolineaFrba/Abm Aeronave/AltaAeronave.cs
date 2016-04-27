using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class AltaAeronave : Form
    {
        public decimal nuevoID = -1;
        public AltaAeronave()
        {
            InitializeComponent();
        }
   
        private void AltaRol_Load(object sender, EventArgs e)
        {

            //Cargar tipos de servicio
            GD2C2015DataSetTableAdapters.ServicioTableAdapter servicioAdapter = new GD2C2015DataSetTableAdapters.ServicioTableAdapter();
            GD2C2015DataSet.ServicioDataTable servicioData = servicioAdapter.GetData();
            servicioDrop.DataSource = servicioData;
            servicioDrop.DisplayMember = "servicio_descripcion";
            servicioDrop.ValueMember = "servicio_id";
        }
        
        //Guardar
        private void button1_Click(object sender, EventArgs e)
        {
            //Validar            
            String kgDisponiblesString = txtKG.Text;
            decimal kgDisponibles;
            if (string.IsNullOrWhiteSpace(kgDisponiblesString) || !Decimal.TryParse(kgDisponiblesString, out kgDisponibles))
            {
                MessageBox.Show("El valor de kg Disponibles debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtKG.BackColor = Color.Red;
                return;
            }

            String pasilloString = txtPasillo.Text;
            decimal pasillo;
            if (string.IsNullOrWhiteSpace(pasilloString) || !Decimal.TryParse(pasilloString, out pasillo))
            {
                MessageBox.Show("La cantidad de butacas debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPasillo.BackColor = Color.Red;
                return;
            }

            String ventanillaString = txtVentanilla.Text;
            decimal ventanilla;
            if (string.IsNullOrWhiteSpace(ventanillaString) || !Decimal.TryParse(ventanillaString, out ventanilla))
            {
                MessageBox.Show("La cantidad de butacas debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtVentanilla.BackColor = Color.Red;
                return;
            }

            String matricula = txtMatricula.Text;
            if (string.IsNullOrWhiteSpace(matricula)){

                txtMatricula.BackColor = Color.Red;
                return;
            }
            
            
            String modelo = txtModelo.Text;
            if (string.IsNullOrWhiteSpace(modelo)){

                txtModelo.BackColor = Color.Red;
                return;
            }

            String fabricante = txtFabricante.Text;
            if (string.IsNullOrWhiteSpace(fabricante)){

                txtFabricante.BackColor = Color.Red;
                return;
            }
            

            GD2C2015DataSetTableAdapters.AeronaveTableAdapter AeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            try
            {
                AeronaveAdapter.AgregarAeronave(matricula, modelo, fabricante, (decimal)servicioDrop.SelectedValue, kgDisponibles, ventanilla, pasillo);
                MessageBox.Show("La operacion se ha realizado correctamente", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                nuevoID = AeronaveAdapter.GetId(matricula)[0].Field<decimal>("aero_id");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 40001)
                {
                    MessageBox.Show("Ya existe una Aeronave con esa matricula", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }                
            }
            this.Close();
        }

        //Limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtModelo.Text = "";
            txtFabricante.Text = "";
            txtKG.Text = "";
            txtPasillo.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtMatricula.BackColor = Color.White;
        }

            
        private void servicioDrop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            txtModelo.BackColor = Color.White;
        }

        private void txtFabricante_TextChanged(object sender, EventArgs e)
        {
            txtFabricante.BackColor = Color.White;
        }

        private void txtKG_TextChanged(object sender, EventArgs e)
        {
            txtKG.BackColor = Color.White;
        }

        private void txtButacas_TextChanged(object sender, EventArgs e)
        {
            txtPasillo.BackColor = Color.White;
        }
    }
}
