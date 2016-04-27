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
    public partial class BajaAeronaveTipo : Form
    {
        private decimal id;

        private Abm_Aeronave.listadoAeronave caller;
        public BajaAeronaveTipo(decimal id,Abm_Aeronave.listadoAeronave caller)
        {
            InitializeComponent();
            this.id = id;
            this.caller = caller;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            //Validar que haya checkeado una
            if((!radioDefinitiva.Checked && !radioServicio.Checked)){
                    MessageBox.Show("Seleccione una opcion!");
                    return;
            }

            GD2C2015DataSetTableAdapters.AeronaveTableAdapter AeronaveAdapter = new GD2C2015DataSetTableAdapters.AeronaveTableAdapter();
            //Si es baja definitiva
            if (radioDefinitiva.Checked)
            {
                //Setear la baja definitiva en la aeronave
                AeronaveAdapter.BajaDefinitiva(id);

                //Si tiene viajes futuros, abrir form de Canelacion o Reasignacion
                if (AeronaveAdapter.TienePasajesVendidosAPartirDe(id, DateTime.Now)[0].Field<Decimal>("Numero") > 0)
                {
                    Abm_Aeronave.CancelarReasignarAeronave form = new Abm_Aeronave.CancelarReasignarAeronave(id, null, null);
                    form.Show();
                }

            }
            else
            {
                Abm_Aeronave.FueraDeServicioAeronave form = new Abm_Aeronave.FueraDeServicioAeronave(id);
                form.Show();
            }
            this.Close();
        }
    }
}
