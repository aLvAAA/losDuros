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
    public partial class ModificacionRol : Form
    {
        private decimal id;
        private Abm_Rol.listadoRol caller;
        private GD2C2015DataSetTableAdapters.RolTableAdapter rolAdapter;

        public ModificacionRol(decimal id,Abm_Rol.listadoRol caller)
        {
            InitializeComponent();
            this.id = id;
            this.caller = caller;
        }

        private void ModificacionRol_Load(object sender, EventArgs e)
        {
            rolAdapter = new GD2C2015DataSetTableAdapters.RolTableAdapter();

            //Cargar lista de funcionalidades a la CheckListBox
            GD2C2015DataSetTableAdapters.FuncionalidadTableAdapter funcionalidadAdapter = new GD2C2015DataSetTableAdapters.FuncionalidadTableAdapter();
            GD2C2015DataSet.FuncionalidadDataTable funcionalidadData = funcionalidadAdapter.GetData();

            funcionalidadesBox.DataSource = funcionalidadData;
            funcionalidadesBox.DisplayMember = "func_desc";
            funcionalidadesBox.ValueMember = "func_id";

            //Cargar nombre
            GD2C2015DataSet.RolRow rol = rolAdapter.GetData().FindByrol_id(id);
            nombreBox.Text = rol["rol_desc"].ToString();

            //Cargar habilitado
            habilitadoCheck.Checked = (bool)rol["rol_habilitado"];

            //Cargar funcionalidades
            GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter fxrAdapter = new GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter();
            GD2C2015DataSet.FuncionalidadXRolDataTable fxrData = fxrAdapter.GetDataBy(id);

            foreach (DataRow row in fxrData.Rows)
            {
                funcionalidadesBox.SetItemChecked((int)row.Field<Decimal>("func_id") - 1, true);
            }
        }
        
        //Guardar
        private void guardar_Click(object sender, EventArgs e)
        {
            String nombre = nombreBox.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                nombreBox.BackColor = Color.Red;
                return;
            }

            GD2C2015DataSetTableAdapters.RolTableAdapter rolAdapter = new GD2C2015DataSetTableAdapters.RolTableAdapter();
            rolAdapter.Update(nombre,habilitadoCheck.Checked,id);

            GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter fxrAdapter = new GD2C2015DataSetTableAdapters.FuncionalidadXRolTableAdapter();
            fxrAdapter.Delete(id);

            //Por cada funcionalidad checkeada
            foreach (object item in funcionalidadesBox.CheckedItems)
            {
                DataRowView funcionalidad = (DataRowView)item;

                //Agregar nueva fila en FuncionalidadXRol
                fxrAdapter.Insert((decimal)funcionalidad["func_id"], id);
            }

            caller.updateData();
            this.Close();
        }

        //Limpiar
        private void button2_Click_1(object sender, EventArgs e)
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
