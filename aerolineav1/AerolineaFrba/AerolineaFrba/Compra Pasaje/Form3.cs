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
    public partial class Form3 : Form
    {
        private int pasajeros;
        private decimal viaje_id,kilos;
        private GD2C2015DataSet.ButacaDataTable butacaData;
        private GD2C2015DataSetTableAdapters.ClienteTableAdapter clientesAdapter;
        public Form3(int pasajeros, decimal kilos,decimal viaje_id)
        {
            InitializeComponent();
            this.pasajeros = pasajeros;
            this.kilos = kilos;
            this.viaje_id = viaje_id;
            clientesAdapter = new GD2C2015DataSetTableAdapters.ClienteTableAdapter();         
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            listado.AutoGenerateColumns = false;

            //Configurar columnas
            listado.ColumnCount = 8;
            listado.Columns[0].Name = "cliente_dni";
            listado.Columns[0].HeaderText = "Documento";
            listado.Columns[0].DataPropertyName = "cliente_dni";

            listado.Columns[1].HeaderText = "Nombre";
            listado.Columns[1].Name = "cliente_nombre";
            listado.Columns[1].DataPropertyName = "cliente_nombre";

            listado.Columns[2].Name = "cliente_apellido";
            listado.Columns[2].HeaderText = "Apellido";
            listado.Columns[2].DataPropertyName = "cliente_apellido";

            listado.Columns[3].Name = "cliente_mail";
            listado.Columns[3].HeaderText = "Mail";
            listado.Columns[3].DataPropertyName = "cliente_mail";

            listado.Columns[4].HeaderText = "Direccion";
            listado.Columns[4].Name = "cliente_direccion";
            listado.Columns[4].DataPropertyName = "cliente_direccion";

            listado.Columns[5].Name = "cliente_telefono";
            listado.Columns[5].HeaderText = "Telefono";
            listado.Columns[5].DataPropertyName = "cliente_telefono";

            listado.Columns[6].Name = "tipo_butaca";
            listado.Columns[6].HeaderText = "Tipo";
            listado.Columns[6].DataPropertyName = "tipo_butaca";

            listado.RowCount = pasajeros;

            //Agregar columnda de fecha de nacimiento
            CalendarColumn calendar = new CalendarColumn();
            calendar.Name = "cliente_fecha_nac";
            calendar.HeaderText = "Fecha de Nacimiento";
            calendar.DataPropertyName = "cliente_fecha_nac";
            listado.Columns.Insert(4, calendar);

            //Agregar columna de butacas
            DataGridViewComboBoxColumn butacaColumn = new DataGridViewComboBoxColumn();
            butacaColumn.Name = "Butaca";

            GD2C2015DataSetTableAdapters.ButacaTableAdapter butacaAdapter = new GD2C2015DataSetTableAdapters.ButacaTableAdapter();
            butacaData = butacaAdapter.GetDataByViaje(viaje_id);
            
            if (listado.Columns["DataGridViewComboBoxColumn "] == null)
            {
                listado.Columns.Insert(7, butacaColumn);
            }

            foreach (DataGridViewRow row in listado.Rows)
            {
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells["Butaca"]);
                cell.DataSource = butacaData;
                cell.DisplayMember = "butaca_numero";
                cell.ValueMember = "butaca_id";
            }
            listado.CellEndEdit += new DataGridViewCellEventHandler(listado_CellEndEdit);
          }

        //Al editarse una celda
        private void listado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Si es de la columna de butacas, cargar su tipo en la columna de tipo
            if (e.ColumnIndex == 7)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)listado.Rows[e.RowIndex].Cells["Butaca"];

                if (cb.Value != null)
                {
                    GD2C2015DataSetTableAdapters.TipoButacaTableAdapter tipoButacaAdapter = new GD2C2015DataSetTableAdapters.TipoButacaTableAdapter();
                    GD2C2015DataSet.TipoButacaRow tipoButaca = tipoButacaAdapter.GetData().FindByt_butaca_id(butacaData.FindBybutaca_id((decimal)cb.Value).Field<Decimal>("butaca_tipo"));
                    listado.Rows[e.RowIndex].Cells["tipo_butaca"].Value = tipoButaca.Field<String>("t_butaca_descripcion");
                    listado.Invalidate();
                }
            }
            //Si es de la columna de dni, completar el resto de la fila
            else if (e.ColumnIndex == 0)
            {
                //Validar dni
                DataGridViewTextBoxCell dni = (DataGridViewTextBoxCell)listado.Rows[e.RowIndex].Cells[0];
                decimal dniParse;    
                if (dni.Value == null|| !Decimal.TryParse(dni.Value.ToString(), out dniParse)) return;

                //Buscar cliente
                GD2C2015DataSet.ClienteDataTable clienteData = clientesAdapter.GetDataByDni(dniParse);
                if (clienteData.Count != 0)
                {
                    GD2C2015DataSet.ClienteRow cliente = clienteData[0];
                
                    listado.Rows[e.RowIndex].Cells["cliente_nombre"].Value = cliente.Field<String>("cliente_nombre");
                    listado.Rows[e.RowIndex].Cells["cliente_apellido"].Value = cliente.Field<String>("cliente_apellido");
                    listado.Rows[e.RowIndex].Cells["cliente_mail"].Value = cliente.Field<String>("cliente_mail");
                    listado.Rows[e.RowIndex].Cells["cliente_direccion"].Value = cliente.Field<String>("cliente_dir");
                    listado.Rows[e.RowIndex].Cells["cliente_telefono"].Value = cliente.Field<decimal>("cliente_tel").ToString();
                    listado.Rows[e.RowIndex].Cells["cliente_fecha_nac"].Value = cliente.Field<DateTime>("cliente_fecha_nac").ToString();
                }
            }
        }
        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siguiente_Click(object sender, EventArgs e)
        {
            //Por cada fila
            GD2C2015DataSet.PasajeDataTable pasajes = new GD2C2015DataSet.PasajeDataTable();
            foreach (DataGridViewRow row in listado.Rows)
            {
                //Validar celdas
                decimal dni;
                if (row.Cells["cliente_dni"].Value == null || !Decimal.TryParse(row.Cells["cliente_dni"].Value.ToString(), out dni))
                {
                    MessageBox.Show("El dni de la fila "+row.Index+" es invalido!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                string nombreString;
                if (row.Cells["cliente_nombre"].Value == null) nombreString = null;
                else nombreString = row.Cells["cliente_nombre"].Value.ToString();

                string apellidoString;
                if (row.Cells["cliente_apellido"].Value == null) apellidoString = null;
                else apellidoString = row.Cells["cliente_apellido"].Value.ToString();

                string mailString;
                if (row.Cells["cliente_mail"].Value == null) mailString = null;
                else mailString = row.Cells["cliente_mail"].Value.ToString();

                string direccionString;
                if (row.Cells["cliente_direccion"].Value == null) direccionString = null;
                else direccionString = row.Cells["cliente_direccion"].Value.ToString();

                decimal telefono = 0;
                if (row.Cells["cliente_telefono"].Value == null || !Decimal.TryParse(row.Cells["cliente_telefono"].Value.ToString(), out telefono))
                {
                    MessageBox.Show("El telefono de la fila " + row.Index + 1 + " no es un numero!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                DateTime fechaNac = DateTime.Parse(row.Cells["cliente_fecha_nac"].Value.ToString());

                decimal butaca = 0;
                if (row.Cells["Butaca"].Value == null || !Decimal.TryParse(row.Cells["Butaca"].Value.ToString(), out butaca))
                {
                    MessageBox.Show("Por favor seleccione una butaca!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                //Si existe, actualizar su informacion
                decimal id;
                if (clientesAdapter.GetDataByDni(dni).Count == 0)
                    id = (decimal) clientesAdapter.InsertQuery1(nombreString, apellidoString, dni, mailString, direccionString, telefono, fechaNac);
                //sino, agregarlo
                else
                    id = (decimal) clientesAdapter.UpdateClientePorDni(nombreString, apellidoString, mailString, direccionString, (int)telefono,fechaNac, dni);

                //Chequear que el pasajero no este realizando otro viaje
                GD2C2015DataSetTableAdapters.ViajeTableAdapter viajeAdapter = new GD2C2015DataSetTableAdapters.ViajeTableAdapter();
                int i = (int)viajeAdapter.ObtenerViajesSolapantes(id, viaje_id);
                   
                if (i > 0)
                {
                    MessageBox.Show("El pasajero "+nombreString+" "+apellidoString +" ya realiza otro viaje en esa fecha!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                //Cargar informacion en el dataTable a pasar al form siguiente 
                GD2C2015DataSet.PasajeRow pasaje = pasajes.NewPasajeRow();
                pasaje["viaje_id"] = viaje_id;
                pasaje["pasaje_butaca"] = butaca;
                pasaje["pasaje_cliente"] = id;
              
                pasajes.Rows.Add(pasaje);   
            }

            Compra_Pasaje.Comprador a = new Compra_Pasaje.Comprador(pasajes, kilos, viaje_id);
            a.Show();
            this.Close();
        }
    }
}
