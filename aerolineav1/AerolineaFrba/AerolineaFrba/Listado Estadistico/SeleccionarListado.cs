using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class SeleccionarListado : Form
    {
        public SeleccionarListado()
        {
            InitializeComponent();
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            //Validar año
            String anioString = anio.Text;
            int anioInt = -1;
            if (!string.IsNullOrWhiteSpace(anioString) && !Int32.TryParse(anioString, out anioInt))
            {
                MessageBox.Show("El año es invalido!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            //Seleccionar semestre
            int semestre;
            if (semestreCombo.SelectedValue == "1") semestre = 1;
            else semestre = 2;

            //Pasar al siguiente form
            Listado_Estadistico.MostrarListado a = new Listado_Estadistico.MostrarListado(semestre, anioInt, listadoCombo.SelectedValue.ToString());
            a.Show();
            this.Close();
        }

        private void SeleccionarListado_Load(object sender, EventArgs e)
        {
            //Cargar semestres
            semestreCombo.DisplayMember = "Text";
            semestreCombo.ValueMember = "Value";

            var itemsSemestre = new[] { 
                new { Text = "1", Value = "1" }, 
                new { Text = "2", Value = "2" }
            };
            semestreCombo.DataSource = itemsSemestre;

            //Cargar tipo de listados
            listadoCombo.DisplayMember = "Text";
            listadoCombo.ValueMember = "Value";

            var itemsListado = new[] { 
                new { Text = "Destinos con mas pasajes comprados", Value = "pasajes_comprados" }, 
                new { Text = "Destinos con aeronaves mas vacias", Value = "aeronaves_vacias" },
                new { Text = "Clientes con mas puntos acumulados", Value = "puntos" }, 
                new { Text = "Destino con mas pasajes cancelados", Value = "pasajes_cancelados" },
                new { Text = "Aeronaves con mayor cantidad de dias fuera de servicio", Value = "aeronaves_servicio" },
            };
            listadoCombo.DataSource = itemsListado;
        }
    }
}
