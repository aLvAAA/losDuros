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
    public partial class Form2 : Form
    {
        private GD2C2015DataSet.AeronaveDataTable viajes;
        public Form2(GD2C2015DataSet.AeronaveDataTable viajes)
        {
            InitializeComponent();
            this.viajes = viajes;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            listado.AutoGenerateColumns = false;

            //Configurar columnas
            listado.ColumnCount = 5;

            listado.Columns[0].Name = "aero_matricula";
            listado.Columns[0].HeaderText = "Matricula";
            listado.Columns[0].DataPropertyName = "aero_matricula";

            listado.Columns[1].HeaderText = "aero_modelo";
            listado.Columns[1].Name = "Modelo";
            listado.Columns[1].DataPropertyName = "aero_modelo";

            listado.Columns[2].Name = "servicio_descripcion";
            listado.Columns[2].HeaderText = "Servicio";
            listado.Columns[2].DataPropertyName = "servicio_descripcion";

            listado.Columns[3].HeaderText = "butacasDisponibles";
            listado.Columns[3].Name = "butacasDisponibles";
            listado.Columns[3].DataPropertyName = "butacasDisponibles";

            listado.Columns[4].Name = "kilosDisponibles";
            listado.Columns[4].HeaderText = "kilosDisponibles";
            listado.Columns[4].DataPropertyName = "kilosDisponibles";
            
            listado.DataSource = viajes;

            //Columna de seleccion
            DataGridViewButtonColumn seleccionarButtonColumn = new DataGridViewButtonColumn();
            seleccionarButtonColumn.Name = "Seleccionar";

            if (listado.Columns["Seleccionar"] == null)
            {
                listado.Columns.Insert(5, seleccionarButtonColumn);
            }
        }

        //Seleccion de viaje
        private void listado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int pasajes = 0;
                decimal kilos = 0;

                //Validar numero de pasajes
                if (!string.IsNullOrWhiteSpace(pasajesBox.Text) && !Int32.TryParse(pasajesBox.Text, out pasajes) || pasajes < 0)
                {
                    pasajesBox.BackColor = Color.Red;
                    return;
                }

                //Validar kilos
                if (!string.IsNullOrWhiteSpace(kilosBox.Text) && !Decimal.TryParse(kilosBox.Text, out kilos) || kilos < 0)
                {
                    kilosBox.BackColor = Color.Red;
                    return;
                }

                if (pasajes == 0 && kilos == 0)
                {
                    pasajesBox.BackColor = Color.Red;
                    kilosBox.BackColor = Color.Red;
                    return;
                }

                if(pasajes > viajes[e.RowIndex].Field<int>("butacasDisponibles")){
                    MessageBox.Show("No hay suficientes butacas en el vuelo seleccionado!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                if(kilos > viajes[e.RowIndex].Field<decimal>("kilosDisponibles")){
                    MessageBox.Show("No hay suficiente espacio para la encomienda en el vuelo seleccionado!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                
                //Si es solo una encomienda, dirigirlo al formulario de compra
                if (pasajes == 0)
                {
                    Compra_Pasaje.Comprador a = new Compra_Pasaje.Comprador(null, kilos, viajes[e.RowIndex].Field<decimal>("viaje_id"));
                    a.Show();
                    this.Close();
                    return;
                }

                //Si no, al de pasajeros
                Compra_Pasaje.Form3 b = new Compra_Pasaje.Form3(pasajes,kilos,viajes[e.RowIndex].Field<decimal>("viaje_id"));
                b.Show();
                this.Close();
            }
        }

        private void pasajesBox_TextChanged(object sender, EventArgs e)
        {
            pasajesBox.BackColor = Color.White;
            kilosBox.BackColor = Color.White;
        }

        private void encomiendaBox_TextChanged(object sender, EventArgs e)
        {
            pasajesBox.BackColor = Color.White;
            kilosBox.BackColor = Color.White;
        }

        private void previo_Click(object sender, EventArgs e)
        {
            Compra_Pasaje.Form1 a = new Compra_Pasaje.Form1();
            a.Show();
            this.Close();
        }

    }
}
