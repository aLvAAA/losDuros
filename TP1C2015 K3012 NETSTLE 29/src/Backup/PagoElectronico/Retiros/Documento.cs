using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Retiros
{
    public partial class Documento : Form
    {
        private String doc = null;

        public Documento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doc = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        public String getNroDocumento()
        {
            return doc;
        }
    }
}
