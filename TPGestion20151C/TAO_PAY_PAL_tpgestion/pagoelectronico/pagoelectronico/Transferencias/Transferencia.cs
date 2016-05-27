using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PagoElectronico.NEGOCIO;
using System.Configuration;

namespace PagoElectronico.Transferencias
{

    public partial class Transferencia : Form
    {
        private int user;
        private DateTime fechaApp = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaActual"]);

        public int User
        {
            get { return user; }
            set { user = value; }
        }

        public Transferencia(int user)
        {
            this.user = user;
            InitializeComponent();
            this.mostrarListadoCuentas();

        }

        private void mostrarListadoCuentas()
        {
            System.Console.WriteLine(user);
            DataTable tablaDeDatos = N_Transferencia.listarCuentas(user);

            foreach (DataRow r in tablaDeDatos.Rows)
            {

                formListadoCuentasOrigen.Rows.Add(r.ItemArray);
                //formListadoCuentas.Rows.Add(r[1], r[2], r[3], r[4], r[5], r[6]);
            }
        }

        private void formListadoCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtNumCuentaOrigen.Text = this.formListadoCuentasOrigen.CurrentRow.Cells[0].Value.ToString();

        }

        private void listadoCuetasDestino_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNumCuentaDestino.Text = this.formListadoCuentasOrigen.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnBuscarCuenta_Click(object sender, EventArgs e)
        {
            gridCuentaDestino.DataSource = null;
            gridCuentaDestino.Rows.Clear();
            try
            {
                string estado = null;
                if (txtNumCuentaDestino.Text == "")
                {
                    MessageBox.Show("Ingrese la informacion necesaria", "Campos vacios", MessageBoxButtons.OK);
                }
                else
                {
                    if (txtNumCuentaDestino.Text.Length < 16)
                    {
                        estado = "Deben ser 16 digitos el numero de la tarjeta";
                    }
                    else
                    {
                        estado = N_Transferencia.validarBusquedaDeCuenta(txtNumCuentaDestino.Text);
                        if (estado.Equals("ok", StringComparison.OrdinalIgnoreCase))
                        {
                            DataTable tbCuetaDestino = N_Transferencia.buscarCuenta(txtNumCuentaDestino.Text);

                            foreach (DataRow r in tbCuetaDestino.Rows)
                            {
                                gridCuentaDestino.Rows.Add(r.ItemArray);
                            }
                        }
                    }
                }
                if (estado != null)
                {
                    if (!estado.Equals("ok", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(estado, "Resultado de cuenta");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            string estado;

            if (txtNumCuentaOrigen.Text == "" || txtNumCuentaDestino.Text == "")
            {
                MessageBox.Show("Ingrese las cuentas de origen y destino", "Campos vacios", MessageBoxButtons.OK);
            }
            else
            {
                if (txtNumCuentaOrigen.Text.Length < 16 || txtNumCuentaDestino.Text.Length < 16)
                {
                    estado = "Deben ser 16 digitos el numero de la cuenta";
                }
                else
                {

                    if (txtImporte.Text == "")
                    {
                        estado = "Deben ingresar un Importe";
                    }
                    else
                    {
                        // Llamar Objeto De Negocio
                        estado = N_Transferencia.RealizarTransferencia(txtNumCuentaOrigen.Text, txtNumCuentaDestino.Text, txtImporte.Text, fechaApp);

                    }
                }
                if (estado.Equals("ok", StringComparison.OrdinalIgnoreCase))
                {
                    btLimpiar.PerformClick(); // hace un clic al boton limpiar del alta ...
                    MessageBox.Show("Transferencia Existosa", "Resultado de Asociacion de Tarjeta");
                }
                else
                {
                    MessageBox.Show(estado, "Resultado de cuenta");
                    btLimpiar.PerformClick();
                }
            }


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNumCuentaDestino_TextChanged(object sender, EventArgs e)
        {
            txtNumCuentaDestino.MaxLength = 16;
        }

        private void gridCuentaDestino_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNumCuentaOrigen_TextChanged(object sender, EventArgs e)
        {
            txtNumCuentaOrigen.MaxLength = 16;
        }

        private void btVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumCuentaDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }

        private void txtNumCuentaOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigito(e);
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Vista.SoloDigitoDecimal(e, txtImporte);
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            txtImporte.Text = "";
            txtNumCuentaOrigen.Text = "";
            txtNumCuentaDestino.Text = "";
            gridCuentaDestino.DataSource = null;
            gridCuentaDestino.Rows.Clear();
            formListadoCuentasOrigen.DataSource = null;
            formListadoCuentasOrigen.Rows.Clear();
            this.mostrarListadoCuentas();

        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
