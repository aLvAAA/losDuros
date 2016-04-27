using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Devolucion
{
    public partial class DetallesDevolucion : Form
    {
        private decimal pnr;
        private GD2C2015DataSet.EncomiendaDataTable encomienda;

        public DetallesDevolucion(decimal pnr)
        {
            InitializeComponent();
            this.pnr = pnr;
        }

        private void DetallesDevolucion_Load(object sender, EventArgs e)
        {
            //Cargar encomienda
            GD2C2015DataSetTableAdapters.EncomiendaTableAdapter encomiendaAdapter = new GD2C2015DataSetTableAdapters.EncomiendaTableAdapter();
            encomienda = encomiendaAdapter.CompraTieneEncomienda(pnr);
            if (encomienda.Rows.Count == 0)
            {
                encomienda = null;
                label3.Hide();
                encomiendaCheck.Hide();
            }


            //Cargar lista de pasajes a la CheckListBox
            GD2C2015DataSetTableAdapters.PasajeTableAdapter pasajesAdapter = new GD2C2015DataSetTableAdapters.PasajeTableAdapter();
            GD2C2015DataSet.PasajeDataTable pasajeData = pasajesAdapter.ObtenerPasajesDeCompra(pnr);

            pasajesBox.DataSource = pasajeData;
            pasajesBox.DisplayMember = "NombreApellido";
            pasajesBox.ValueMember = "pasaje_id";
        }

        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            //Validar motivo
            String motivo = motivoBox.Text;
            if (string.IsNullOrWhiteSpace(motivo))
            {
                motivoBox.BackColor = Color.Red;
                return;
            }

            //Agregar devolucion por cada pasaje y para la encomienda
            GD2C2015DataSetTableAdapters.DevolucionTableAdapter devolucionAdapter = new GD2C2015DataSetTableAdapters.DevolucionTableAdapter();
            foreach (object item in pasajesBox.CheckedItems){
                DataRowView pasaje = (DataRowView)item;
                devolucionAdapter.Insert(pnr,DateTime.Now,motivo,(decimal)pasaje["pasaje_id"],null);
            }

            if (encomienda != null) devolucionAdapter.Insert(pnr, DateTime.Now, motivo, null, (decimal)encomienda[0]["encom_id"]);

            MessageBox.Show("Devolucion registrada correctamente", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            this.Close();
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
            motivoBox.Text = "";
            for (int i = 0; i < pasajesBox.Items.Count; i++)
            {
                pasajesBox.SetItemChecked(i, false);
            }
        }

        private void motivoBox_TextChanged(object sender, EventArgs e)
        {
            motivoBox.BackColor = Color.White;
        }
    }
}
