using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ModificacionAeronave : Form
    {
        private decimal id;
        private Abm_Aeronave.listadoAeronave caller;
        public ModificacionAeronave(decimal id, Abm_Aeronave.listadoAeronave caller)
        {
            InitializeComponent();
            this.id = id;
            this.caller = caller;
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            GD2C2015DataSetTableAdapters.AeronaveTableAdapter AeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            GD2C2015DataSet.AeronaveDataTable AeronaveData = AeronaveAdapter.GetData();
            GD2C2015DataSet.AeronaveRow Aeronave = AeronaveData.FindByaero_id(id);


            //Cargar tipos de servicio
            GD2C2015DataSetTableAdapters.ServicioTableAdapter servicioAdapter = new GD2C2015DataSetTableAdapters.ServicioTableAdapter();
            GD2C2015DataSet.ServicioDataTable servicioData = servicioAdapter.GetData();
            servicioDrop.DataSource = servicioData;
            servicioDrop.DisplayMember = "servicio_descripcion";
            servicioDrop.ValueMember = "servicio_id";

            //Cargar valores
            txtMatricula.Text = Aeronave["aero_matricula"].ToString();
            servicioDrop.SelectedValue = (decimal)Aeronave["servicio"];
            txtModelo.Text = Aeronave["aero_modelo"].ToString();
            txtFabricante.Text = Aeronave["aero_fabricante"].ToString();
            txtKG.Text = Aeronave["aero_kg_disp"].ToString();
            
        }
        
        //Guardar
        private void button1_Click(object sender, EventArgs e)
        {            
            String kgString = txtKG.Text;
            decimal kg;
            if (string.IsNullOrWhiteSpace(kgString) || !Decimal.TryParse(kgString, out kg))
            {
                MessageBox.Show("El valor de Kg debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtKG.BackColor = Color.Red;
                return;
            }
            String modelo = txtModelo.Text; 
            if (string.IsNullOrWhiteSpace(modelo))
            {
                txtModelo.BackColor = Color.Red;
                return;
            }
            String fabricante = txtFabricante.Text; 
            if (string.IsNullOrWhiteSpace(fabricante))
            {
                txtFabricante.BackColor = Color.Red;
                return;
            }
            GD2C2015DataSetTableAdapters.AeronaveTableAdapter AeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            AeronaveAdapter.UpdateAeronave(modelo, fabricante, (decimal)servicioDrop.SelectedValue, kg, id);
            caller.getFromDB();
            this.Close();
        }

        //Limpiar
        private void button2_Click(object sender, EventArgs e)
        {
            txtFabricante.Text = "";
            txtModelo.Text = "";
            txtKG.Text = "";

        }
    }
}
