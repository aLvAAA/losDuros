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
    public partial class Form5 : Form
    {
        private decimal viaje_id,kilos,comprador_id;
        private GD2C2015DataSet.PasajeDataTable pasajes;
        GD2C2015DataSetTableAdapters.TarjetaTableAdapter tarjetasAdapter;
                
        public Form5(GD2C2015DataSet.PasajeDataTable pasajes, decimal kilos,decimal viaje_id,decimal comprador_id)
        {
            InitializeComponent();
            this.pasajes = pasajes;
            this.kilos = kilos;
            this.viaje_id = viaje_id; 
            this.comprador_id = comprador_id;
            tarjetasAdapter = new GD2C2015DataSetTableAdapters.TarjetaTableAdapter();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            //Mostrar opcion de efectivo, si es admin
            if (AerolineaFrba.Model.Usuario.admin)
            {
                efectivoLabel.Visible = true;
                efectivoCheck.Visible = true;
            }

            //Formato fecha
            vencimientoPicker.Format = DateTimePickerFormat.Custom;
            vencimientoPicker.CustomFormat = "dd/MM/yyyy HH:mm";
            
            //Cargar valores para tipo
            tipoCombo.DisplayMember = "Text";
            tipoCombo.ValueMember = "Value";
            var items = new[] { 
                new { Text = "Credito", Value = "Credito" }, 
                new { Text = "Debito", Value = "Debito" }
            };
            tipoCombo.DataSource = items;

            //Si ya hay una tarjeta asociada al comprador, cargar sus datos
            GD2C2015DataSet.TarjetaDataTable tarjetaData = tarjetasAdapter.GetDataByCliente(comprador_id);
            if (tarjetaData.Rows.Count != 0)
            {
                numeroText.Text = tarjetaData[0]["tarjeta_numero"].ToString();
                codigoText.Text = tarjetaData[0]["tarjeta_codigo"].ToString();
                vencimientoPicker.Value = tarjetaData[0].Field<DateTime>("tarjeta_vencimiento");
                tipoCombo.SelectedValue = tarjetaData[0]["tarjeta_tipo"].ToString();
            } 
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            //Si es en efectivo, agregar la compra
            if (efectivoCheck.Checked)
            {
                generarCompra(null, null);
                return;
            }

            //sino, validar datos de tarjeta
            String numeroString = numeroText.Text;
            int numero;
            if (string.IsNullOrWhiteSpace(numeroString) || !Int32.TryParse(numeroString, out numero))
            {
                MessageBox.Show("El numero no es valido!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                numeroText.BackColor = Color.Red;
                return;
            }

            String codigo = codigoText.Text;
            if (string.IsNullOrWhiteSpace(codigo))
            {
                codigoText.BackColor = Color.Red;
                return;
            }

            DateTime vencimiento = vencimientoPicker.Value;
            if(vencimiento == null || vencimiento < DateTime.Now){
                MessageBox.Show("La fecha de vencimiento no es valida!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            String cuotasString = cuotasText.Text;
            int cuotas;
            if (string.IsNullOrWhiteSpace(cuotasString) || !Int32.TryParse(cuotasString, out cuotas))
            {
                MessageBox.Show("El numero de cuotas no es valido!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cuotasText.BackColor = Color.Red;
                return;
            }

            //Si el comprador ya tenia una tarjeta, actualizar sus datos, sino agregarla
            GD2C2015DataSetTableAdapters.TarjetaTableAdapter tarjetasAdapter = new GD2C2015DataSetTableAdapters.TarjetaTableAdapter();
            GD2C2015DataSet.TarjetaDataTable clienteData = tarjetasAdapter.GetDataByCliente(comprador_id);               
            if (clienteData.Count != 0)
                tarjetasAdapter.Update(numero, codigo, vencimiento, tipoCombo.SelectedValue.ToString(),comprador_id);
            else tarjetasAdapter.InsertarTarjeta(numero, codigo, vencimiento, tipoCombo.SelectedValue.ToString(), comprador_id);

            generarCompra(numero,cuotas);
        }

        //Inserta la compra en la base
        private void generarCompra(decimal? numero,int? cuotas)
        {
            decimal precio = 0;
            decimal precioPasaje = 0;
            decimal precioEncomienda = 0;
            GD2C2015DataSetTableAdapters.EncomiendaTableAdapter encomiendasAdapter = new GD2C2015DataSetTableAdapters.EncomiendaTableAdapter();
            GD2C2015DataSetTableAdapters.ViajeTableAdapter viajesAdapter = new GD2C2015DataSetTableAdapters.ViajeTableAdapter();
            GD2C2015DataSetTableAdapters.CompraTableAdapter compraAdapter = new GD2C2015DataSetTableAdapters.CompraTableAdapter();

            //Calcular el precio de la encomienda
            if (kilos != 0)
            {
                precioEncomienda = (decimal)encomiendasAdapter.CalcularPrecioEncomienda(viaje_id, kilos);
                precio += precioEncomienda;
            }
            
            //Calcular el precio de los pasajes
            if (pasajes != null)
            {
                precioPasaje = (decimal) viajesAdapter.CalcularPrecioPasaje(viaje_id);
                foreach (DataRow pasaje in pasajes.Rows)
                {
                    precio += precioPasaje;
                }
            }

            //Insertar compra segun si es en efectivo o no, y obtener su id
            decimal idCompra;
            if(numero != null) idCompra = (decimal)compraAdapter.InsertQuery(DateTime.Now, precio, cuotas, comprador_id, comprador_id);
            else idCompra = (decimal)compraAdapter.InsertQuery(DateTime.Now, precio, null, comprador_id, null);

            //Insertar encomienda y pasajes
            if (kilos != 0) encomiendasAdapter.Insert(viaje_id, precioEncomienda, kilos, idCompra);
            if (pasajes != null)
            {
                GD2C2015DataSetTableAdapters.PasajeTableAdapter pasajeAdapter = new GD2C2015DataSetTableAdapters.PasajeTableAdapter();

                foreach (DataRow pasaje in pasajes.Rows)
                {
                    pasajeAdapter.Insert(viaje_id, pasaje.Field<Decimal>("pasaje_butaca"), pasaje.Field<Decimal>("pasaje_cliente"), idCompra, precioPasaje);
                }
            }

            MessageBox.Show("Su PNR es: "+idCompra, "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        //Deshabilitar o habilitar datos de tarjeta, segun si se checkea el pago en efectivo
        private void efectivoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (efectivoCheck.Checked)
            {
                numeroText.Enabled = false;
                codigoText.Enabled = false;
                vencimientoPicker.Enabled = false;
                tipoCombo.Enabled = false;
                cuotasText.Enabled = false;
            }
            else
            {
                numeroText.Enabled = true;
                codigoText.Enabled = true;
                vencimientoPicker.Enabled = true;
                tipoCombo.Enabled = true;
                cuotasText.Enabled = true;
            }
        }
    }
}
