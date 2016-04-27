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

namespace AerolineaFrba.Abm_Viaje
{
    public partial class AltaViaje : Form
    {
        public AltaViaje()
        {
            InitializeComponent();
        }

        private void AltaViaje_Load(object sender, EventArgs e)
        {
            //Formato fechas
            salidaPicker.Format = DateTimePickerFormat.Custom;
            salidaPicker.CustomFormat = "dd/MM/yyyy HH:mm";
            llegadaPicker.Format = DateTimePickerFormat.Custom;
            llegadaPicker.CustomFormat = "dd/MM/yyyy HH:mm";  
        }

        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            bool valido = true;

            //Validar fechas
            TimeSpan diferenciaFechas = llegadaPicker.Value - salidaPicker.Value;
            if (diferenciaFechas.TotalMinutes < 0)
            {
                valido = false;
                MessageBox.Show("La fecha de llegada es anterior a la fecha de salida!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            if (diferenciaFechas.TotalMinutes > 24*60)
            {
                valido = false;
                MessageBox.Show("La diferencia entre dias no debe ser mayor a 24 horas!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            //Validar seleccion de ruta
            if (string.IsNullOrWhiteSpace(ruta.Text))
            {
                ruta.BackColor = Color.Red;
                valido = false;
            }

            //Validar seleccion de aeronave
            if (string.IsNullOrWhiteSpace(aeronave.Text))
            {
                aeronave.BackColor = Color.Red;
                valido = false;
            }

            decimal rutaDecimal,aeroDecimal;

            Decimal.TryParse(ruta.Text, out rutaDecimal);
            Decimal.TryParse(aeronave.Text, out aeroDecimal);

            //Tratar de insertar el viaje, sino mostrar el error que arrojo el stored procedure
            if (valido)
            {
                try
                {
                    GD2C2015DataSetTableAdapters.ViajeTableAdapter viajeAdapter = new GD2C2015DataSetTableAdapters.ViajeTableAdapter();
                    viajeAdapter.Insert(rutaDecimal, aeroDecimal, salidaPicker.Value, llegadaPicker.Value);
                }
                catch (SqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 15599:
                            MessageBox.Show("La ruta y la aeronave no ofrecen el mismo tipo de servicio!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        case 15600:
                            MessageBox.Show("La aeronave ya realiza otro viaje en esa fecha!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        case 15601:
                            MessageBox.Show("La aeronave no estará en servicio para la fecha de salida!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                    }
                }

                this.Close();
            }
            return;
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
            ruta.Text = "";
            aeronave.Text = "";
        }

        //Al seleccionar una ruta, mostrarla
        private void seleccionarRuta_Click(object sender, EventArgs e)
        {
            Abm_Ruta.listadoRuta a = new Abm_Ruta.listadoRuta((int)Abm_Ruta.listadoRuta.Operacion.Seleccion);
            a.ShowDialog();

            //Chequear que efectivamente se haya seleccionado una
            if (a.seleccion != -1)
            {
                //Chequear que este habilitada
                GD2C2015DataSetTableAdapters.RutaTableAdapter rutaAdapter = new GD2C2015DataSetTableAdapters.RutaTableAdapter();
                if (rutaAdapter.GetData().FindByruta_id(a.seleccion).Field<Boolean>("ruta_habilitada") == false)
                {
                    MessageBox.Show("La ruta no está habilitada!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                ruta.Text = a.seleccion.ToString();
                ruta.BackColor = Color.White;
            }
        }

        //Al seleccionar una nave, mostrarla
        private void seleccionarAeronave_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.listadoAeronave a = new Abm_Aeronave.listadoAeronave((int)Abm_Aeronave.listadoAeronave.Operacion.Seleccion);
            a.ShowDialog();

            //Chequear que efectivamente se haya seleccionado una
            if (a.seleccion != -1)
            {
                aeronave.Text = a.seleccion.ToString();
                aeronave.BackColor = Color.White;
            }
        }
    }
}
