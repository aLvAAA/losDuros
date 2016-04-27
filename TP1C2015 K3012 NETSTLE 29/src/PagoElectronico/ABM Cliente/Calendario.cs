using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace PagoElectronico.ABM_Cliente
{
    public partial class Calendario : Form
    {
        private DateTime fecha;

        public Calendario()
        {
            InitializeComponent();
        }

        private void Calendario_Load(object sender, EventArgs e)
        {
            //fijo la fecha del archivo de configuracion
            DateTime time = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
            monthCalendar.TodayDate = time;
            monthCalendar.SelectionStart = time;
        }

        private void button_sel_Click(object sender, EventArgs e)
        {
            fecha = monthCalendar.SelectionRange.Start;
            
            //como seleccione una fecha quiero que al etornar el form devuleva yes
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public String getFecha()
        {
            return fecha.ToString("yyyy-MM-dd HH:MM:ss");
        }

        public DateTime getFechaDateTime()
        {
            return fecha;
        }
    }
}
