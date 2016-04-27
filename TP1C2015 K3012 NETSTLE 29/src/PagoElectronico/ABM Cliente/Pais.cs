using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoElectronico.ABM_Cliente
{
    public partial class Pais : Form
    {
        private SqlConnection sqlCon = null;

        private String pais = null;

        public Pais()
        {
            InitializeComponent();
        }

        public Pais(SqlConnection sqlCon): this()
        {
            this.sqlCon = sqlCon;
        }

        private bool existePais(String pais)
        {
            //consulta
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT COUNT(*) FROM NETSTLE.PAIS WHERE UPPER(PAIS_NOMBRE) LIKE UPPER('%" + pais + "%')";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("Ya existe un pais con ese nombre", "Pais", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //libero
                cmd.Dispose();
                return true;
            }
            else
            {
                //libero
                cmd.Dispose();
                //no existe
                return false;
            }
        }

        private bool insertarNuevoPais(String pais)
        {
            //inset
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO NETSTLE.PAIS (PAIS_NOMBRE) VALUES('" + pais + "')";
            cmd.Connection = sqlCon;

            //ejecuto
            if ((Int32)cmd.ExecuteNonQuery() > 0)
            {
                //libero
                cmd.Dispose();
                return true;
            }
            else
            {
                //fallo
                MessageBox.Show("Error al insertar en la tabla PAIS.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //libero
                cmd.Dispose();
                return false;
            }
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (textBox_pais.Text != "")
            {
                if (!existePais(textBox_pais.Text))
                {
                    if (insertarNuevoPais(textBox_pais.Text))
                    {
                        pais = textBox_pais.Text;

                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                }
            }
        }

        public String getNuevoPais()
        {
            return pais;
        }
    }
}
