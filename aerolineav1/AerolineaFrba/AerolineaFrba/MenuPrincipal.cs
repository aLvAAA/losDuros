using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultaSaldo_Click(object sender, EventArgs e)
        {

        }

        private void operacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rolAlta_Click(object sender, EventArgs e)
        {
            Abm_Rol.AltaRol a = new Abm_Rol.AltaRol();
            a.Show();
        }

        private void bajaRol_Click(object sender, EventArgs e)
        {
            Abm_Rol.listadoRol a = new Abm_Rol.listadoRol(true);
            a.Show();
        }

        private void modificacionRol_Click(object sender, EventArgs e)
        {
            Abm_Rol.listadoRol a = new Abm_Rol.listadoRol(false);
            a.Show();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.AltaCiudad a = new Abm_Ciudad.AltaCiudad();
            a.Show();
        }

        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.listadoCiudad a = new Abm_Ciudad.listadoCiudad(true);
            a.Show();
        }

        private void modificacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Abm_Ciudad.listadoCiudad a = new Abm_Ciudad.listadoCiudad(false);
            a.Show();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Abm_Ruta.AltaRuta a = new Abm_Ruta.AltaRuta();
            a.Show();
        }

        private void bajaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Abm_Ruta.listadoRuta a = new Abm_Ruta.listadoRuta((int)Abm_Ruta.listadoRuta.Operacion.Baja);
            a.Show();
        }

        private void modificacionToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Abm_Ruta.listadoRuta a = new Abm_Ruta.listadoRuta((int)Abm_Ruta.listadoRuta.Operacion.Modificacion);
            a.Show();
        }

        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Viaje.AltaViaje a = new Abm_Viaje.AltaViaje();
            a.Show();
        }

        private void pasajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_Pasaje.Form1 a = new Compra_Pasaje.Form1();
            a.Show();
        }

        private void registroDeLlegadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_destino.SeleccionarAeronave a = new Registro_destino.SeleccionarAeronave();
            a.Show();
        }

        private void consultarMillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Millas.ConsultaMillas cm = new Consulta_Millas.ConsultaMillas();
            cm.Show();
        }

        private void devolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Devolucion.IngresoPNR a = new Devolucion.IngresoPNR();
            a.Show();
        }

        private void listadoEstadistico_Click(object sender, EventArgs e)
        {
            Listado_Estadistico.SeleccionarListado a = new Listado_Estadistico.SeleccionarListado();
            a.Show();
        }

        private void cerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void canjearMillasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canje_Millas.CanjeMillas a = new Canje_Millas.CanjeMillas();
            a.Show();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.AltaAeronave a = new Abm_Aeronave.AltaAeronave();
            a.Show();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.listadoAeronave a = new Abm_Aeronave.listadoAeronave((int)Abm_Aeronave.listadoAeronave.Operacion.Baja);
            a.Show();
        }

        private void modificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Aeronave.listadoAeronave a = new Abm_Aeronave.listadoAeronave((int)Abm_Aeronave.listadoAeronave.Operacion.Modificacion);
            a.Show();
        }

    }
}
