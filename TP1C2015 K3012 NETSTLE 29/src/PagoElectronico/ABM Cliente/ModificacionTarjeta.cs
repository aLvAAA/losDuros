using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PagoElectronico.ABM_Cliente
{
    public partial class ModificacionTarjeta : Form
    {
        private SqlConnection sqlCon = null;

        private string nroTarjeta = null;

        public ModificacionTarjeta()
        {
            InitializeComponent();
        }

        public ModificacionTarjeta(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;
        }

        void cargaDatosTarjeta() 
        {
            // carga de emisores
            cargarEmisores(comboBox_emisores);

            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT TAR_EMISOR,";
            cmd.CommandText += "TAR_FECHA_VENCIMIENTO,";
            cmd.CommandText += "TAR_ELIMINADA ";
            cmd.CommandText += "FROM NETSTLE.TARJETA WHERE ";
            cmd.CommandText += "TAR_NUMERO = '" + nroTarjeta + "'";
            cmd.Connection = sqlCon;
            
            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //limpio por las dudas
                    textBox_tarjeta.Text = "";
                    textBox_fech_ven.Text = "";

                    //muestro numero de tarjeta
                    textBox_tarjeta.Text = "'" + nroTarjeta + "'";

                    //muestro seleccionado el emisor de la tarjeta en el combobox
                    for (int i = 0; i < comboBox_emisores.Items.Count; i++)
                    {
                        if (comboBox_emisores.Items[i].ToString() == reader.GetString(0))
                        {
                            comboBox_emisores.SelectedIndex = i;
                            break;
                        };
                    }
                    
                    //fecha vencimiento 
                    textBox_fech_ven.Text = reader.GetDateTime(1).ToString("yyyy-MM-dd HH:MM:ss");
                    
                    //si la tarjeta está inhabilitada
                    if (reader.GetBoolean(2))
                    {
                        //habilito combobox para que pueda hablitarlo
                        comboBox_habilitada.Enabled = true;

                        //muestra no
                        comboBox_habilitada.SelectedIndex = 1;
                    }
                    else
                    {
                        //muestra si
                        comboBox_habilitada.SelectedIndex = 0;
                    }
                }
            }
            
            //libero
            reader.Close();
            cmd.Dispose();
        }

        void cargarEmisores(ComboBox comboBox)
        {
            //limpio por las dudas
            comboBox.Items.Clear();

            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT EMISOR_DESC FROM NETSTLE.EMISOR";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //agrego
                    comboBox.Items.Add(reader.GetString(0));
                }

                comboBox.SelectedIndex = 0;
            }

            //libero
            reader.Close();
            cmd.Dispose();
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            //nueva instancia
            SeleccionTarjeta frmTar = new SeleccionTarjeta(sqlCon);

            //muestro
            if (frmTar.ShowDialog() == DialogResult.Yes)
            {
                //recupero tarjeta
                nroTarjeta = frmTar.getTarjetaSeleccionada();
                errorProvider_tarjeta.Clear();

                //inhabilito combobox_habilitida
                comboBox_habilitada.Enabled = false;

                //cargo los datos de la tarjeta
                cargaDatosTarjeta();
            }
            //libero
            frmTar.Dispose();  
        }

        private void button_fecha_Click_1(object sender, EventArgs e)
        {
            //nueva instancia
            Calendario frmCal = new Calendario();

            //muestro
            if (frmCal.ShowDialog() == DialogResult.Yes)
            {
                DateTime time = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

                if (frmCal.getFechaDateTime() > time)
                {
                    //recupero fecha
                    textBox_fech_ven.Text = frmCal.getFecha();
                    errorProvider_fecha.Clear();
                }
                else
                {
                    // no pudo haber vencido ayer
                    MessageBox.Show("No es una fecha de vencimiento valida", "Fecha De Vencimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            //libero
            frmCal.Dispose();
        }

        private void textBox_tarjeta_TextChanged(object sender, EventArgs e)
        {
            errorProvider_tarjeta.Clear();
        }

        private void textBox_fech_ven_TextChanged(object sender, EventArgs e)
        {
            errorProvider_fecha.Clear();
        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            bool vacio = false;

            if (textBox_tarjeta.Text == "")
            {
                errorProvider_tarjeta.SetError(textBox_tarjeta, "Por favor seleccione una tarjeta.");
                vacio = true;
            }

            if (textBox_fech_ven.Text == "")
            {
                errorProvider_fecha.SetError(textBox_fech_ven, "Por favor ingrese una fecha de vencimiento.");
                vacio = true;
            }

            //me las tomo?
            if (vacio) return;

            //actualizo
            actualizarTarjeta();

            //limpo
            textBox_tarjeta.Text = "";
            textBox_fech_ven.Text = "";
            comboBox_habilitada.Enabled = false;
            comboBox_emisores.SelectedIndex = 0;
        }

        private void actualizarTarjeta()
        {
            //update
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE NETSTLE.TARJETA SET ";
            cmd.CommandText += "TAR_EMISOR = '" + comboBox_emisores.GetItemText(comboBox_emisores.SelectedItem) + "',";
            cmd.CommandText += "TAR_FECHA_VENCIMIENTO = CONVERT(DATETIME,'" + textBox_fech_ven.Text + "',121)";
            cmd.CommandText += "WHERE TAR_NUMERO = " + textBox_tarjeta.Text;
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() < 1)
            {
                //fallo
                MessageBox.Show("Error al actualizar la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //exito
                MessageBox.Show("Se ha guardado la modificacion.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //libero
            cmd.Dispose();
        }
        
    }
}
