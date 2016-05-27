using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.NEGOCIO;

namespace PagoElectronico.ABM_Rol
{
    public partial class frmAbmRol : Form
    {
        public frmAbmRol()
        {
            InitializeComponent();

        }

        private void frmAbmRol_Load(object sender, EventArgs e)
        {
            //this.Top = 0;
            //this.Left = 0;
            MostrarRoles();

            //Cargo combo de filtros de busqueda en listado
            cmbFiltroFuncionalidadL.DataSource = N_Rol.GetAllFuncionalidades();
            cmbFiltroFuncionalidadL.DisplayMember = "Descripcion";
            cmbFiltroFuncionalidadL.ValueMember = "ID";
            cmbFiltroFuncionalidadL.SelectedIndex = -1;

            //Cargo combos de modificacion
            cmbRolesM.DataSource = N_Rol.GetAllRoles();
            cmbRolesM.DisplayMember = "Descripcion";
            cmbRolesM.ValueMember = "ID";

            cmbFuncionalidadesM.DataSource = N_Rol.GetAllFuncionalidades();
            cmbFuncionalidadesM.DisplayMember = "Descripcion";
            cmbFuncionalidadesM.ValueMember = "ID";

            //cmbEstadoM.SelectedIndex = -1;
        }

        //Muestrra mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "ABM ROL", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Muestra mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "ABM ROL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        #region Pestaña de Alta
        private void btnLimpiarAlta_Click(object sender, EventArgs e)
        {
            txtNombreRolA.Text = "";
            cmbEstadoA.SelectedIndex = 0;
            foreach (DataGridViewRow row in dgvFuncionalidadesA.Rows)
            {
                row.Cells["chkFunc"].Value = false;
            }
        }

        private void dgvFuncionalidadesA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvFuncionalidadesA.Columns["chkFunc"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvFuncionalidadesA.Rows[e.RowIndex].Cells["chkFunc"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            //Si estan los datos completos y correctos hago el alta
            if (AltaValida())
            {
                N_Rol rol = new N_Rol();
                rol.SetNombre(txtNombreRolA.Text);
                rol.SetEstado(cmbEstadoA.Text);
                foreach (DataGridViewRow row in dgvFuncionalidadesA.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["chkFunc"].Value))
                    {
                        rol.AgregarFuncionalidad(Convert.ToInt32(row.Cells[1].Value));
                    }
                }
                //Dar de alta
                if (rol.Insertar() != -1)
                {
                    //Alta exitosa
                    MessageBox.Show("Alta exitosa");
                }
                else
                {
                    //Error de alta
                    MessageBox.Show("El rol ya existe", "Atencion");
                }
                btnLimpiarAlta_Click(null, null);
            }
            else
            {
                MessageBox.Show("Completar nombre", "Atencion");
            }
        }

        private bool AltaValida()
        {
            if (txtNombreRolA.Text == "") return false;
            return true;
        }

        private void txtNombreRolA_KeyPress(object sender, KeyPressEventArgs e)
        {
            soloTexto(sender, e);

        }

        #endregion

        #region Pestaña de Modificacion
        private void btnLimpiarM_Click(object sender, EventArgs e)
        {
            cmbRolesM.SelectedIndex = -1;
            txtNombreRolM.Text = "";
            dgvRolFuncionalidadM.DataSource = null;
            cmbEstadoM.SelectedIndex = -1;
            //cmbFuncionalidadesM.SelectedIndex = 0;
        }
        #endregion

        #region Pestaña de Baja

        private void btnBuscarB_Click(object sender, EventArgs e)
        {
            tc_ABMRol.SelectedIndex = 0;
        }

        private void btnBajaRolB_Click(object sender, EventArgs e)
        {
            //Si hay un rol seleccionado
            if (lblIdRolB.Text != "")
            {
                string Rpta = "";
                try
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Realmente desea dar de baja el rol seleccionado?", "Atencion",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        N_Rol rol = new N_Rol();
                        rol.SetId(Convert.ToInt32(lblIdRolB.Text));

                        Rpta = rol.Baja();

                        if (Rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se deshabilito el rol correctamente");
                            lblIdRolB.Text = "";
                            lblNombreRolB.Text = "";
                            lblEstadoB.Text = "";
                            dgvFuncionalidadesB.DataSource = null;
                        }
                        else
                        {
                            this.MensajeError(Rpta);
                        }
                    }

                }
                catch
                    (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un rol", "Info");
            }


        }

        private void btnCancelarB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Pestaña Listado
        private void btnLimpiarL_Click(object sender, EventArgs e)
        {
            txtFiltroNombreL.Text = "";
            cmbFiltroFuncionalidadL.SelectedIndex = -1;
            cmbFiltroEstadoL.SelectedIndex = -1;
        }

        //Muestra roles segun donde este parado
        private void MostrarRoles()
        {
            dgvRolesL.DataSource = N_Rol.GetAllRoles();
        }

        private void MostrarFuncionalidades()
        {
            //Creo un rol con el id para luego cargar funcionalidades
            N_Rol rol = new N_Rol();
            rol.SetId(Convert.ToInt32(dgvRolesL.CurrentRow.Cells[0].Value));

            //muestro las funcionalidades del rol seleccionado
            dgvFuncionalidadesL.DataSource = rol.GetFuncionalidades();

        }


        private void btnBuscarL_Click(object sender, EventArgs e)
        {
            string nombre;
            char estado = ' ';
            int codFunc = 0;

            nombre = txtFiltroNombreL.Text;
            if (cmbFiltroEstadoL.SelectedIndex >= 0)
                estado = Convert.ToChar(cmbFiltroEstadoL.Text);
            if (cmbFiltroFuncionalidadL.SelectedIndex >= 0)
                codFunc = Convert.ToInt32(cmbFiltroFuncionalidadL.SelectedValue);

            //Aplicar los filtros
            dgvRolesL.DataSource = N_Rol.GetRoles(nombre, estado, codFunc);
        }

        private void btnBajaL_Click(object sender, EventArgs e)
        {
            //Si hay alguno seleccionado
            if (dgvRolesL.RowCount > 0)
            {
                //MessageBox.Show("Seleccion: " + dgvRolesL.CurrentRow.Cells[1].Value);

                if (dgvRolesL.CurrentRow.Cells[2].Value.ToString() == "N")
                {
                    MessageBox.Show("El rol seleccionado ya esta dado de baja", "Info");
                }
                else
                {
                    //Muestro lo seleccionado
                    lblIdRolB.Text = dgvRolesL.CurrentRow.Cells[0].Value.ToString();
                    lblEstadoB.Text = dgvRolesL.CurrentRow.Cells[2].Value.ToString();
                    lblNombreRolB.Text = dgvRolesL.CurrentRow.Cells[1].Value.ToString();

                    tc_ABMRol.SelectedIndex = 3;
                }

            }
            else
            {
                MessageBox.Show("Seleccione rol");
            }

        }

        private void dgvRolesL_SelectionChanged(object sender, EventArgs e)
        {
            MostrarFuncionalidades();
        }

        #endregion


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Seleccion de menu
        private void tc_ABMRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Menu Listado
            if (tc_ABMRol.SelectedIndex == 0)
                MostrarRoles();
            //Menu Alta
            if (tc_ABMRol.SelectedIndex == 1)
            {
                dgvFuncionalidadesA.DataSource = N_Rol.GetAllFuncionalidades();
                cmbEstadoA.SelectedIndex = 0;
            }

            //Menu Modificacion
            if (tc_ABMRol.SelectedIndex == 2)
            {
                cmbRolesM.DataSource = N_Rol.GetAllRoles();
                btnLimpiarM_Click(null, null);


            }

            //Menu Baja
            if (tc_ABMRol.SelectedIndex == 3)
            {
                if (lblIdRolB.Text != "")
                {
                    //Creo un rol con el id a dar de baja
                    N_Rol rol = new N_Rol();
                    rol.SetId(Convert.ToInt32(lblIdRolB.Text));

                    //Cargo las funcionalidades a mostrar
                    dgvFuncionalidadesB.DataSource = rol.GetFuncionalidades();
                }

            }

        }

        private void soloTexto(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;

            }
        }

        private void cmbRolesM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRolesM.SelectedIndex >= 0)
            {
                N_Rol rol = new N_Rol();
                rol.SetId(Convert.ToInt32(cmbRolesM.SelectedValue));

                //Cargo las funcionalidades a mostrar
                dgvRolFuncionalidadM.DataSource = rol.GetFuncionalidades();

                //lblIdRolM.Text = cmbRolesM.SelectedValue.ToString();
                txtNombreRolM.Text = cmbRolesM.Text;

                cmbEstadoM.Text = Convert.ToString(rol.GetEstado());

            }

        }

        private void btn_AgregarFuncionalidadM_Click(object sender, EventArgs e)
        {
            if (cmbRolesM.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione rol a modificar");
            }
            else
            {
                if (BuscarTextoDgv(cmbFuncionalidadesM.Text, "Descripcion", dgvRolFuncionalidadM))
                {
                    MessageBox.Show("El rol ya posee esa funcionalidad");
                }
                else
                {
                    N_Rol.AgregarFuncionalidad(Convert.ToInt32(cmbRolesM.SelectedValue), Convert.ToInt32(cmbFuncionalidadesM.SelectedValue));
                    cmbRolesM_SelectedIndexChanged(null, null);
                }
            }

        }


        //Busca texto en un datagrid
        bool BuscarTextoDgv(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;

            foreach (DataGridViewRow row in grid.Rows)
            {
                string texto = Convert.ToString(row.Cells[Columna].Value);
                if (TextoABuscar == texto) encontrado = true;
            }
            return encontrado;
        }

        private void dgvRolFuncionalidadM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRolFuncionalidadM.Columns[e.ColumnIndex].Name == "btn_quitarFuncionalidad")
            {
                N_Rol.QuitarFuncionalidad(Convert.ToInt32(cmbRolesM.SelectedValue),
                    Convert.ToInt32(dgvRolFuncionalidadM.Rows[e.RowIndex].Cells["ID"].Value));
                cmbRolesM_SelectedIndexChanged(null, null);
            }

        }

        private void btnModificarRolM_Click(object sender, EventArgs e)
        {
            if (cmbRolesM.SelectedIndex >= 0)
            {
                N_Rol rol = new N_Rol();
                rol.SetId(Convert.ToInt32(cmbRolesM.SelectedValue));
                rol.SetNombre(txtNombreRolM.Text);

                //MessageBox.Show("Estado nuevo:: " + cmbEstadoM.Text);
                rol.SetEstado(cmbEstadoM.Text);

                rol.Modificar();

                cmbRolesM.DataSource = N_Rol.GetAllRoles();

                MessageBox.Show("Rol guardado correctamente", "Info");

                btnLimpiarM_Click(null, null);
            }
            else
            {
                MessageBox.Show("Seleccione un rol a modificar", "Ayuda");
            }
           

        }

        private void btnVerRolesL_Click(object sender, EventArgs e)
        {
            MostrarRoles();
        }

    }
}
