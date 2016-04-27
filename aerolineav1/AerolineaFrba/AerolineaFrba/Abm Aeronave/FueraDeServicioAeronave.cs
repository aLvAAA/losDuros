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
    public partial class FueraDeServicioAeronave : Form
    {
        private decimal id;

        private Abm_Aeronave.listadoAeronave caller;
        public FueraDeServicioAeronave(decimal id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FueraDeServicioForm_Load(object sender, EventArgs e)
        {
            //Formato Fecha            
            inicioPicker.Format = DateTimePickerFormat.Custom;
            inicioPicker.CustomFormat = "dd/MM/yyyy HH:mm";

            finPicker.Format = DateTimePickerFormat.Custom;
            finPicker.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siguiente_Click(object sender, EventArgs e)
        { 
            //Validar fechas
            if (inicioPicker.Value > finPicker.Value)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la de reinicio!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Setear la baja por fuera de servicio en la aeronave
            GD2C2015DataSetTableAdapters.AeronaveTableAdapter AeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();   
            AeronaveAdapter.FueraDeServicio(id,inicioPicker.Value,finPicker.Value);

            //Si tiene viajes comprendidos en esas fechas, abrir form de Canelacion o Reasignacion
            if (AeronaveAdapter.TienePasajesVendidosAPartirDe(id, DateTime.Now)[0].Field<Decimal>("Numero") > 0)
            {
                Abm_Aeronave.CancelarReasignarAeronave form = new Abm_Aeronave.CancelarReasignarAeronave(id, inicioPicker.Value, finPicker.Value);
                form.Show();
            }
            this.Close();
        }
    }
}
