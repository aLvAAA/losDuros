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

namespace AerolineaFrba.Registro_destino
{
    public partial class RegistrarLlegada : Form
    {
        private decimal aeronave_id,viaje_id;
        public RegistrarLlegada(decimal aeronave_id,decimal viaje_id)
        {
            InitializeComponent();
            this.aeronave_id = aeronave_id;
            this.viaje_id = viaje_id;
        }

        private void RegistrarLlegada_Load(object sender, EventArgs e)
        {
            //Formato fecha
            llegadaPicker.Format = DateTimePickerFormat.Custom;
            llegadaPicker.CustomFormat = "dd/MM/yyyy HH:mm";

            //Cargar datos de la aeronave
            GD2C2015DataSetTableAdapters.AeronaveTableAdapter aeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            GD2C2015DataSet.AeronaveDataTable aeronaveData = aeronaveAdapter.GetDataBy1(aeronave_id);
            datosAeronave.DataSource = aeronaveData;
        }

        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            //Validar fecha de llegada
            if (llegadaPicker.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha no puede ser futura!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            GD2C2015DataSetTableAdapters.ViajeTableAdapter viajeAdapter = new GD2C2015DataSetTableAdapters.ViajeTableAdapter();

            //Registrar fecha de llegada o mostrar error arrojado por la base
            try
            {
                viajeAdapter.registrarLlegada(viaje_id, llegadaPicker.Value);
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 40001:
                        MessageBox.Show("La fecha ingresada es anterior a la fecha de salida!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    default:
                        MessageBox.Show(ex.Message, "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                }
            }
            this.Close();
        }

        //Previo
        private void previo_Click(object sender, EventArgs e)
        {
            Registro_destino.SeleccionarAeronave a = new Registro_destino.SeleccionarAeronave();
            a.Show();
            this.Close();
        }

    }
}
