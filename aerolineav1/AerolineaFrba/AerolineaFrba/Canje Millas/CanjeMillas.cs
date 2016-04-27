using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Canje_Millas
{
    public partial class CanjeMillas : Form
    {
        private GD2C2015DataSetTableAdapters.CanjeTableAdapter canjeAdapter;
        GD2C2015DataSetTableAdapters.ProductoTableAdapter productoAdapter;
        private GD2C2015DataSet.ProductoDataTable productoData;
        private decimal dni;
        private decimal cant;


        public CanjeMillas()
        {
            InitializeComponent();
        }

        private void CanjeMillas_Load(object sender, EventArgs e)
        {
            configurarDataGrid();
            canjeAdapter = new GD2C2015DataSetTableAdapters.CanjeTableAdapter();
            productoAdapter = new GD2C2015DataSetTableAdapters.ProductoTableAdapter();
            productoData = productoAdapter.GetData();
            updateData();
        }

        public void configurarDataGrid()
        {
            //Crear columnas
            DataGridViewTextBoxColumn idProducto = new DataGridViewTextBoxColumn();
            idProducto.Name = "Id";
            idProducto.Visible = false;
            productosGrid.Columns.Insert(0, idProducto);

            DataGridViewTextBoxColumn producto = new DataGridViewTextBoxColumn();
            producto.Name = "Producto";
            productosGrid.Columns.Insert(1, producto);

            DataGridViewTextBoxColumn millas = new DataGridViewTextBoxColumn();
            millas.Name = "Millas Necesarias";
            productosGrid.Columns.Insert(2, millas);

            DataGridViewTextBoxColumn stock = new DataGridViewTextBoxColumn();
            stock.Name = "stock";
            productosGrid.Columns.Insert(3, stock);

            DataGridViewButtonColumn seleccionarButtonColumn = new DataGridViewButtonColumn();
            seleccionarButtonColumn.Name = "Seleccionar";
            productosGrid.Columns.Insert(4, seleccionarButtonColumn);
        }
         public void updateData(){
             //Actualizar dataGrid
             productosGrid.Rows.Clear();
             GD2C2015DataSetTableAdapters.ProductoTableAdapter productoAdapter = new GD2C2015DataSetTableAdapters.ProductoTableAdapter();
            
            foreach (DataRow row in productoData.Rows)
            {
                productosGrid.Rows.Add(row.Field<Decimal>("prod_id"),
                                        row.Field<String>("prod_desc"),
                                        row.Field<Decimal>("prod_millas"),
                                        row.Field<Decimal>("prod_stock"));
            }
        }

         public void getFromDB()
         {
             productoData = productoAdapter.GetData();
             updateData();
         }

        private void productosGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Validar campos
            var senderGrid = (DataGridView)sender;

            if (!string.IsNullOrWhiteSpace(dniBox.Text) && !Decimal.TryParse(dniBox.Text, out dni))
            {
                dniBox.BackColor = Color.Red;
                return;
            }
            if (!string.IsNullOrWhiteSpace(cantidadBox.Text) && !Decimal.TryParse(cantidadBox.Text, out cant))
            {
                cantidadBox.BackColor = Color.Red;
                return;
            }
            
            GD2C2015DataSetTableAdapters.ClienteTableAdapter clienteAdapter = new GD2C2015DataSetTableAdapters.ClienteTableAdapter();
            GD2C2015DataSet.ClienteDataTable cliente = clienteAdapter.GetDataByDni(dni);
            decimal id = Convert.ToDecimal(senderGrid.Rows[e.RowIndex].Cells["id"].Value);
            decimal millas = Convert.ToDecimal(canjeAdapter.ConsultaMillas(dni));

            //Canjear
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //Validar que existe el cliente
                if (cliente.Rows.Count == 0)
                {
                    MessageBox.Show("El dni no corresponde con un cliente", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                //Validar canje
                decimal totalMillas = (Convert.ToDecimal(senderGrid.Rows[e.RowIndex].Cells["Millas Necesarias"].Value) * cant);
                
                if((Decimal)senderGrid.Rows[e.RowIndex].Cells["stock"].Value < cant)
                {
                    MessageBox.Show("El producto seleccionado no tiene stock", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if(millas < totalMillas)
                {
                    MessageBox.Show("No tiene suficientes millas para hacer el canje", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    canjeAdapter.Insert(id, cant, DateTime.Now, cliente[0].Field<Decimal>("cliente_id"), totalMillas);
                    productoAdapter.RestarStock(id,(int)cant);
                    MessageBox.Show("El canje se realizo exitosamente!", "Aerolinea", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    getFromDB();
                }
                                
            }
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dniBox.Text))
            {
                this.dni = Convert.ToDecimal(dniBox.Text);
                canjeAdapter = new GD2C2015DataSetTableAdapters.CanjeTableAdapter();

                lblTotalMillas.Visible = true;
                lblTotalMillas.Text = "Total Millas :" + canjeAdapter.ConsultaMillas(Convert.ToDecimal(dni)).ToString();
            }
            else dniBox.BackColor = Color.Red;
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            lblTotalMillas.Text = "";
            dniBox.Text = "";
            cantidadBox.Text = "";
            dniBox.BackColor= Color.White;
            cantidadBox.BackColor = Color.White;
        }
    }
}
