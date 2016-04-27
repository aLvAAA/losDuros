using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Acerca
{
    public partial class Acerca : Form
    {
        public Acerca()
        {
            InitializeComponent();
        }

        private void Acerca_Load(object sender, EventArgs e)
        {
            label_m.Location = new Point(label_m.Location.X,200);
            label_n.Location = new Point(label_n.Location.X,200+35);
            label_s.Location = new Point(label_s.Location.X,200+35+35);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (label_m.Location.Y > 27)
            {
                label_m.Location = new Point(label_m.Location.X, label_m.Location.Y - 5);
                label_n.Location = new Point(label_n.Location.X, label_n.Location.Y - 5);
                label_s.Location = new Point(label_s.Location.X, label_s.Location.Y - 5);
            }
        }
    }
}
