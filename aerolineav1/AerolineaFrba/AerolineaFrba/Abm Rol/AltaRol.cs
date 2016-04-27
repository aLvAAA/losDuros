using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            //Cargar lista de funcionalidades a la CheckListBox
            GD2C2015DataSetTableAdapters.FuncionalidadTableAdapter funcionalidadAdapter = new GD2C2015DataSetTableAdapters.FuncionalidadTableAdapter();
            GD2C2015DataSet.FuncionalidadDataTable funcionalidadData = funcionalidadAdapter.GetData();

            funcionalidadesBox.DataSource = funcionalidadData;
            funcionalidadesBox.DisplayMember = "func_desc";
            funcionalidadesBox.ValueMember = "func_id";
        }
        
        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            //Validar nombre
            String nombre = nombreBox.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                nombreBox.BackColor = Color.Red;
                return;
            }

            GD2C2015DataSetTableAdapters.RolTableAdapter rolAdapter = new GD2C2015DataSetTableAdapters.RolTableAdapter();
            rolAdapter.Insert(nombre);
            decimal id = rolAdapter.GetData().Last().rol_id;

            //Por cada funcionalidad checkeada
            foreach (object item in funcionalidadesBox.CheckedItems){
                DataRowView funcionalidad = (DataRowView)item;

                //Agregar nueva fila en FuncionalidadXRol
                GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter fxrAdapter = new GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter();
                fxrAdapter.Insert((decimal)funcionalidad["func_id"],id);
            }

            this.Close();
        }

        //Limpiar
        private void limpiar_Click(object sender, EventArgs e)
        {
            nombreBox.Text = "";
            for (int i = 0; i < funcionalidadesBox.Items.Count; i++)
            {
                funcionalidadesBox.SetItemChecked(i, false);
            }
        }

        private void nombreBox_TextChanged(object sender, EventArgs e)
        {
            nombreBox.BackColor = Color.White;
        }
    }
}
