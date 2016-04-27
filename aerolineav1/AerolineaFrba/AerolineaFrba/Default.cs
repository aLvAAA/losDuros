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
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();
        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            Login_Form.Login a = new Login_Form.Login();
            a.Show();
            
        }

        private void btnLoginClie_Click(object sender, EventArgs e)
        {
            AerolineaFrba.Model.Usuario.admin = false;
            InicioCliente ic = new InicioCliente();
            ic.Show();
            
        }

    }
}
