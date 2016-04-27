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

namespace PagoElectronico
{
    public partial class frm_programa : Form
    {
        private SqlConnection sqlCon = null;

        private String usuario = null;

        private String rol = null;

        public frm_programa()
        {
            InitializeComponent();
        }
        
        public frm_programa(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;
        }

        void activarMenuSegunRol(String rol)
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT FUNCROL_FUNCIONALIDAD_NOMBRE FROM NETSTLE.FUNCIONALIDADXROL WHERE ";
            cmd.CommandText += "FUNCROL_NOMBRE_ROL = '" + rol + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    switch(reader.GetString(0)){

                        case "ABM_ROL": menu.Items[0].Enabled = true; break;

                        case "ABM_CLIENTE": menu.Items[1].Enabled = true; break;

                        case "ESTADISTICAS": menu.Items[9].Enabled = true; break;

                        case "ABM_CUENTA": menu.Items[2].Enabled = true; break;

                        case "CONSULTA_SALDO": menu.Items[4].Enabled = true; break;

                        case "FACTURACION": menu.Items[5].Enabled = true; break;

                        case "TARJETA_CREDITO": menu.Items[3].Enabled = true; break;

                        case "DEPOSITO": menu.Items[6].Enabled = true; break;

                        case "RETIRO": menu.Items[7].Enabled = true; break;

                        case "TRANSFERENCIA": menu.Items[8].Enabled = true; break;

                        case "CAMBIO_ROL": menu.Items[10].Enabled = true; break;
                        
                        default: /*nada*/ break;
                    }
                }

                //guardo rol
                this.rol = rol;
            }
            else
            {
                //fallo
                MessageBox.Show("Error al leer el campo FUNCROL_FUNCIONALIDAD_NOMBRE en la tabla FUNCIONALIDADXROL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            //libero
            reader.Close();
            //libero
            cmd.Dispose();
        }

        private void activarCambioRol()
        {
            //consula sql
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.ROLXUSUARIO WHERE ";
            cmd.CommandText += "ROLUSR_NOMBRE_USUARIO = '" + usuario + "'";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() > 1)
            {
                //activo pestaño menu
                menu.Items[10].Enabled = true;
            }

            //libero
            cmd.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //creo instancia de nueva ventana
            Login.frm_login frmLogin = new Login.frm_login(sqlCon);;

            //llamo
            if (frmLogin.ShowDialog() == DialogResult.Yes)
            {
                //activo menu
                activarMenuSegunRol(frmLogin.GetRolUsuario());

                //guardo el usuario
                usuario = frmLogin.GetUsuario();

                //veo de activar pestaña cambio rol
                activarCambioRol();
            }
            else
            {
                this.Close();
            }

            //libero
            frmLogin.Dispose();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Rol.Alta frmAlta = new ABM_Rol.Alta(sqlCon);

            frmAlta.MdiParent = this;
            frmAlta.Show();
        }

        private void modificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Rol.Modificacion frmMod = new ABM_Rol.Modificacion(sqlCon);

            frmMod.MdiParent = this;
            frmMod.Show();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM_Rol.SeleccionRol frmSel = new ABM_Rol.SeleccionRol(sqlCon, "eliminar");

            //muestro
            if (frmSel.MostrarSiEsNecesario() == DialogResult.Yes)
            {
                //update
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UPDATE NETSTLE.ROL SET ROL_HABILITADO = 0 WHERE ";
                cmd.CommandText += "ROL_NOMBRE = '" + frmSel.getRolSeleccionado() + "'";
                cmd.Connection = sqlCon;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    //fallo
                    MessageBox.Show("Error al eliminar el rol" + frmSel.getRolSeleccionado(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //exito
                    MessageBox.Show("Se elimino el rol " + frmSel.getRolSeleccionado(), "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //libero
                cmd.Dispose();
            }

            //libero
            frmSel.Dispose();
        }

        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //nueva instancia
            ABM_Cliente.Buscador frmBusc = new ABM_Cliente.Buscador(sqlCon,false);

            //muestro
            if (frmBusc.ShowDialog() == DialogResult.Yes){

                //update
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UPDATE NETSTLE.CLIENTE SET CLI_ELIMINADO = 1 WHERE ";
                cmd.CommandText += "CLI_NRO_DOCUMENTO = " + frmBusc.getClienteNroDocumento() + "AND ";
                cmd.CommandText += "CLI_TIPO_DOCUMENTO = '" + frmBusc.getClienteTipoDocumento() + "'";
                cmd.Connection = sqlCon;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    //fallo
                    MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //exito
                    MessageBox.Show("Se elimino el cliente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //libero
                cmd.Dispose();
            }

            //libero
            frmBusc.Dispose();
        }

        private void modificacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ABM_Cliente.Modificacion frmMod = new ABM_Cliente.Modificacion(sqlCon);

            frmMod.MdiParent = this;
            frmMod.Show();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ABM_Cliente.Alta frmAlta = new ABM_Cliente.Alta(sqlCon);

            frmAlta.MdiParent = this;
            frmAlta.Show();
        }

        private void cambioDeRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //creo instancia de nueva ventana
            Login.SeleccionRol frmRol = new Login.SeleccionRol(sqlCon, usuario);

            //muestro para que el usuario seleccione el rol
            if (frmRol._ShowDialog() == DialogResult.Yes)
            {
                //inhabilito todas las pestañas
                for (int i = 0; i < menu.Items.Count; i++)
                {
                    menu.Items[i].Enabled = false;
                }

                //activo pestaña cambio de rol
                menu.Items[10].Enabled = true;

                //activo pestañas segun rol
                activarMenuSegunRol(frmRol.getRol());
            }

            //libero
            frmRol.Dispose();

            //cierro todas las ventanas
            this.MdiChildren.OfType<Form>().ToList().ForEach(x => x.Close());
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ABM_Cuenta.Alta frmAlta = null;

            if (rol == "ADMINISTRADOR")
            {
                frmAlta = new ABM_Cuenta.Alta(sqlCon);
            }
            else if (rol == "CLIENTE")
            {
                frmAlta = new ABM_Cuenta.Alta(sqlCon,usuario);
            }
            else
            {
                //fallo
                MessageBox.Show("Funcionalidad no soportada para este rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAlta.MdiParent = this;
            frmAlta.Show();
        }

        private void bajaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //nueva instancia
            ABM_Cuenta.Listado frmBusc = null;

            if (rol == "ADMINISTRADOR")
            {
                frmBusc = new ABM_Cuenta.Listado(sqlCon);
            }
            else if (rol == "CLIENTE")
            {
                frmBusc = new ABM_Cuenta.Listado(sqlCon,usuario);
            }
            else
            {
                //fallo
                MessageBox.Show("Funcionalidad no soportada para este rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
                
            //muestro
            if (frmBusc.ShowDialog() == DialogResult.Yes)
            {
                //update
                SqlCommand cmd = new SqlCommand();

                //fecha del archivo de configuracion
                DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);

                cmd.CommandText = "UPDATE NETSTLE.CUENTA SET CTA_ESTADO = 'CERRADA',CTA_FECHA_CIERRE = " + "CONVERT(DATETIME,'" + fecha.ToString("yyyy-MM-dd HH:MM:ss") + "',121)" + " WHERE ";
                cmd.CommandText += "CTA_NUMERO = " + frmBusc.getNumeroDeCuenta() + " AND ";
                cmd.CommandText += "(SELECT COUNT(*) FROM NETSTLE.TRANSACCION WHERE TRANS_PENDIENTE = 1 AND TRANS_CTA_EMISORA = CTA_NUMERO) = 0";
                cmd.Connection = sqlCon;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    //fallo
                    MessageBox.Show("No se puede eliminar la cuenta porque tiene transacciones pendientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //exito
                    MessageBox.Show("Se elimino la cuenta correctamente.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //libero
                cmd.Dispose();
            }

            //libero
            frmBusc.Dispose();
        }

        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depositos.Deposito frmDepo = new Depositos.Deposito(sqlCon,usuario);

            frmDepo.MdiParent = this;
            frmDepo.Show();
        }

        private void retiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Retiros.Retiro frmReti = new Retiros.Retiro(sqlCon, usuario);

            frmReti.MdiParent = this;
            frmReti.Show();
        }

        private void modificacionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ABM_Cuenta.Modificacion frmMod = null;

            if (rol == "ADMINISTRADOR")
            {
                frmMod = new ABM_Cuenta.Modificacion(sqlCon);
            }
            else if (rol == "CLIENTE")
            {
                frmMod = new ABM_Cuenta.Modificacion(sqlCon, usuario);
            }
            else
            {
                //fallo
                MessageBox.Show("Funcionalidad no soportada para este rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmMod.MdiParent = this;
            frmMod.Show();
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.Facturacion frmFac = null;

            if (rol == "ADMINISTRADOR")
            {
                frmFac = new Facturacion.Facturacion(sqlCon);
            }
            else if (rol == "CLIENTE")
            {
                frmFac = new Facturacion.Facturacion(sqlCon, usuario);
            }
            else
            {
                //fallo
                MessageBox.Show("Funcionalidad no soportada para este rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmFac.MdiParent = this;
            frmFac.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca.Acerca frmAcerca = new Acerca.Acerca();

            frmAcerca.ShowDialog();
            frmAcerca.Dispose();
        }

        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transferencias.Transferencia frmTransf = new Transferencias.Transferencia(sqlCon,usuario);

            frmTransf.MdiParent = this;
            frmTransf.Show();
        }

        private void saldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Saldos.Consulta frmSaldo = null;

            if (rol == "ADMINISTRADOR")
            {
                frmSaldo = new Consulta_Saldos.Consulta(sqlCon);
            }
            else if (rol == "CLIENTE")
            {
                frmSaldo = new Consulta_Saldos.Consulta(sqlCon, usuario);
            }
            else
            {
                //fallo
                MessageBox.Show("Funcionalidad no soportada para este rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmSaldo.MdiParent = this;
            frmSaldo.Show();
        }

        private void altaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ABM_Cliente.AltaTarjeta frmAlta = new ABM_Cliente.AltaTarjeta(sqlCon);

            frmAlta.MdiParent = this;
            frmAlta.Show();
        }

        private void bajaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ABM_Cliente.DesvinculacionTarjeta frmMod = new ABM_Cliente.DesvinculacionTarjeta(sqlCon);

            frmMod.MdiParent = this;
            frmMod.Show();
        }

        private void modificacionToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ABM_Cliente.ModificacionTarjeta frmMod = new ABM_Cliente.ModificacionTarjeta(sqlCon);

            frmMod.MdiParent = this;
            frmMod.Show();
        }

        private void estadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listados.Consulta frmCons = new Listados.Consulta(sqlCon);

            frmCons.MdiParent = this;

            frmCons.Show();
        }
    }
}
