using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cliente
{
    public partial class NuevaContraseña : Form
    {
        private String psw = null;

        public NuevaContraseña()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            psw = textBox_psw.Text;
            this.DialogResult = DialogResult.Yes;
        }

        public String getContraseña()
        {
            return psw;
        }
    }
}
