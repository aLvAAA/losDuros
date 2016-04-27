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
    public partial class AltaRuta : Form
    {
        public AltaRuta()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
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

            //Cargar tipos de servicio
            GD2C2015DataSetTableAdapters.ServicioTableAdapter servicioAdapter = new GD2C2015DataSetTableAdapters.ServicioTableAdapter();
            GD2C2015DataSet.ServicioDataTable servicioData = servicioAdapter.GetData();
            servicioDrop.DataSource = servicioData;
            servicioDrop.DisplayMember = "servicio_descripcion";
            servicioDrop.ValueMember = "servicio_id";
        }
        
        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            //Validar codigo
            String codigoString = codigoBox.Text;
            decimal codigo;
            if (string.IsNullOrWhiteSpace(codigoString) || !Decimal.TryParse(codigoString, out codigo))
            {
                MessageBox.Show("El codigo debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                codigoBox.BackColor = Color.Red;
                return;
            }

            //Validar ciudades
            if (origenDrop.SelectedValue.GetHashCode() == destinoDrop.SelectedValue.GetHashCode())
            {
                MessageBox.Show("La ciudad de destino y de origen no pueden ser las mismas!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Validar precio pasaje
            String pasajeString = basePasaje.Text;
            decimal pasaje;
            if (string.IsNullOrWhiteSpace(pasajeString) || !Decimal.TryParse(pasajeString, out pasaje))
            {
                MessageBox.Show("El precio base por pasaje debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                basePasaje.BackColor = Color.Red;
                return;
            }

            //Validar precio kilo
            String kgString = baseKG.Text;
            decimal kg;
            if (string.IsNullOrWhiteSpace(kgString) || !Decimal.TryParse(kgString, out kg))
            {
                MessageBox.Show("El precio base por Kg debe ser un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                baseKG.BackColor = Color.Red;
                return;
            }

            
            //Chequear que el codigo no exista
            GD2C2015DataSetTableAdapters.RutaTableAdapter rutaAdapter = new GD2C2015DataSetTableAdapters.RutaTableAdapter();
            foreach (DataRow row in rutaAdapter.GetData().Rows)
            {
                if ((decimal)row["ruta_id"] == codigo)
                {
                    MessageBox.Show("El codigo ya existe!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

            rutaAdapter.Insertar(codigo,(decimal)origenDrop.SelectedValue,(decimal)destinoDrop.SelectedValue,(decimal)servicioDrop.SelectedValue,pasaje,kg);

            this.Close();
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
            codigoBox.Text = "";
            basePasaje.Text = "";
            baseKG.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            codigoBox.BackColor = Color.White;
        }
        
        private void basePasaje_TextChanged(object sender, EventArgs e)
        {
            basePasaje.BackColor = Color.White;
        }

        private void baseKG_TextChanged(object sender, EventArgs e)
        {
            baseKG.BackColor = Color.White;
        }
    }
}
