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
    public partial class ModificacionRuta : Form
    {
        private decimal id;
        private Abm_Ruta.listadoRuta caller;
        public ModificacionRuta(decimal id, Abm_Ruta.listadoRuta caller)
        {
            InitializeComponent();
            this.id = id;
            this.caller = caller;
        }
        
        private void ModificacionRuta_Load(object sender, EventArgs e)
        {
            //Obtener ruta
            GD2C2015DataSetTableAdapters.RutaTableAdapter rutaAdapter = new GD2C2015DataSetTableAdapters.RutaTableAdapter();
            GD2C2015DataSet.RutaDataTable rutaData = rutaAdapter.GetData();
            GD2C2015DataSet.RutaRow ruta = rutaData.FindByruta_id(id);

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

            //Cargar valores
            codigoBox.Text = id.ToString();
            origenDrop.SelectedValue = (decimal)ruta["ruta_origen"];
            destinoDrop.SelectedValue = (decimal)ruta["ruta_destino"];
            servicioDrop.SelectedValue = (decimal)ruta["ruta_servicio"];
            basePasaje.Text = ruta["ruta_precio_base"].ToString();
            baseKG.Text = ruta["ruta_precio_base_KG"].ToString();
            habilitadoCheck.Checked = (bool)ruta["ruta_habilitada"];
        }

        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
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

            //Modificar
            GD2C2015DataSetTableAdapters.RutaTableAdapter rutaAdapter = new GD2C2015DataSetTableAdapters.RutaTableAdapter();
            rutaAdapter.Update((decimal)origenDrop.SelectedValue,(decimal)destinoDrop.SelectedValue,(decimal)servicioDrop.SelectedValue,pasaje,kg,habilitadoCheck.Checked,id);
            caller.getFromDB();
            this.Close();
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
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
