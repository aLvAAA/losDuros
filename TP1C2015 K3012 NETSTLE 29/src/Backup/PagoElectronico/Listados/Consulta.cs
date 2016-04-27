using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.Listados
{
    public partial class Consulta : Form
    {
        private SqlConnection sqlCon = null;

        private String anio = null;

        private String trimestre = null;

        public Consulta()
        {
            InitializeComponent();
        }

        public Consulta(SqlConnection sqlCon):this()
        {
            this.sqlCon = sqlCon;

            //se muestra 1er elemento en comboBoxs
            muestraComboBox();
        }

        void muestraComboBox()
        {
            comboBox_anios.SelectedIndex = 0;
            comboBox_trimestres.SelectedIndex = 0;
            comboBox_listados.SelectedIndex = 0;
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            this.anio = comboBox_anios.GetItemText(comboBox_anios.SelectedItem);

            this.trimestre = comboBox_trimestres.GetItemText(comboBox_trimestres.SelectedItem);

            if (comboBox_listados.GetItemText(comboBox_listados.SelectedItem) == "Clientes con más cuentas inhabilitadas")
            {
                //nueva instancia
                ListaInhabilitadas frmInha = new ListaInhabilitadas(sqlCon, anio, trimestre);

                frmInha.MdiParent = this.MdiParent;
                this.DialogResult = DialogResult.Yes;
                this.Close();

                frmInha.Show();
            }

            if (comboBox_listados.GetItemText(comboBox_listados.SelectedItem) == "Clientes con más comisiones facturadas")
            {
                //nueva instancia
                ListaFacturacion frmFact = new ListaFacturacion(sqlCon, anio, trimestre);

                frmFact.MdiParent = this.MdiParent;
                this.DialogResult = DialogResult.Yes;
                this.Close();

                frmFact.Show();
            }

            if (comboBox_listados.GetItemText(comboBox_listados.SelectedItem) == "Clientes con más transacciones entre cuentas propias")
            {
                //nueva instancia
                ListaTransaccion frmTran = new ListaTransaccion(sqlCon, anio, trimestre);

                frmTran.MdiParent = this.MdiParent;
                this.DialogResult = DialogResult.Yes;
                this.Close();

                frmTran.Show();
            }
            if (comboBox_listados.GetItemText(comboBox_listados.SelectedItem) == "Países con más movimientos")
            {
                ListaMovimientos frmMov = new ListaMovimientos(sqlCon, anio, trimestre);

                frmMov.MdiParent = this.MdiParent;
                this.DialogResult = DialogResult.Yes;
                this.Close();

                frmMov.Show();
            }
            if (comboBox_listados.GetItemText(comboBox_listados.SelectedItem) == "Total facturado por tipo de cuenta")
            {
                ListaTotalFacturado frmTot = new ListaTotalFacturado(sqlCon, anio, trimestre);

                frmTot.MdiParent = this.MdiParent;
                this.DialogResult = DialogResult.Yes;
                this.Close();

                frmTot.Show();
            }
        }

        
    }
}
