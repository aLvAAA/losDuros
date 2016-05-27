using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;
using PagoElectronico.DATOS;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.NEGOCIO
{
    public class N_Cliente
    {
        public static void InicializarFechasCliente(DateTimePicker d1, DateTimePicker d2, DateTime fecha)
        {
            d1.MaxDate = fecha.AddYears(-18);
            d1.MinDate = fecha.AddYears(-150);
            d2.MaxDate = fecha.AddYears(-18);
            d2.MinDate = fecha.AddYears(-150);
        }
                
        public static bool Registrar_Cliente(E_Usuario u, E_Cliente c)
        {
            string rta = D_Cliente.Alta_Cliente(u, c);
            if (rta != "OK")
            {
                MessageBox.Show(rta, "Error de registro de cliente");
                return false;
            }
            else
            {
                MessageBox.Show("Felicidades usted ya es miembro del sistema", "Resultado del Registro");
                return true;
            }
        }

        public static void Cargar_Datos_Cliente(Label l1, TextBox t1, TextBox t2, TextBox t3, TextBox t4,
             TextBox t5, TextBox t6, TextBox t7, TextBox t8, ComboBox c1, ComboBox c2, DateTimePicker d1, int id)
        {
            try
            {
                l1.Text = id.ToString();
                DataRow r = D_Cliente.Datos_Clientes_Para_Edicion(id);
                t1.Text = r[0].ToString();
                t2.Text = r[1].ToString();
                c1.Text = r[2].ToString();
                t3.Text = r[3].ToString();
                t4.Text = r[4].ToString();
                d1.Value = Convert.ToDateTime(r[5]);
                c2.Text = r[6].ToString();
                t5.Text = r[7].ToString();
                t6.Text = r[8].ToString();
                t7.Text = r[9].ToString();
                t8.Text = r[10].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Carga de Datos");
            }
        }

        public static bool Editar_Cliente(E_Cliente c)
        {
            string rta = D_Cliente.Editar_Cliente(c);
            if (rta != "OK")
            {
                MessageBox.Show("Error: " + rta, "Resultado de la edicion");
                return false;
            }
            else
            {
                MessageBox.Show("Edicion de Cliente Satisfactoria!!!", "Resultado de Edicion");
                return true;
            }
        }

        public static void Habilitar(int id)
        {
            string rta = D_Cliente.Habilitar_Deshabiitar_Cliente(id, "Habilitar");
            if (rta == "OK") MessageBox.Show("Habilitacion de cliente satisfactoria", "Resultado de Habilitacion de cliente");
        }

        public static void Inhabilitar(int id)
        {
            string rta = D_Cliente.Habilitar_Deshabiitar_Cliente(id, "Deshabilitacion");
            if (rta == "OK") MessageBox.Show("Deshabilitacion de cliente satisfactoria", "Resultado de Habilitacion de cliente");
        }

        public static void Listado_Clientes(E_Cliente c, DataGridView d)
        {
            //d.DataSource = null;
            d.DataSource = D_Cliente.Listar_Clientes(c);
            //d.RowHeadersVisible = false;
            for (int i = 0; i < d.Rows.Count; i++)
            {
                if (d.Rows[i].Cells[11].Value.ToString() == "A")
                {
                    d.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (d.Rows[i].Cells[11].Value.ToString() == "I")
                {
                    d.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    d.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
            d.Columns.RemoveAt(11);
        }

        public static bool Username_Duplicado(string username)
        {
            string rta = D_Cliente.Verificar_Username(username);
            if (rta != "OK")
            {
                return true;
            }
            else { return false; }
        }

        public static string GetSHA256(string texto)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string HashString = string.Empty;
            foreach (byte x in hash)
            {
                HashString += String.Format("{0:x2}", x);
            }
            return HashString;
        }

        public static void CargarTipoDocumentos(ComboBox cb1, ComboBox cb2, ComboBox cb3)
        {
            DataTable dt1 = new DataTable();
            dt1 = D_Cliente.Cargar_Cmb("documento");

            cb1.DataSource = dt1;
            cb1.ValueMember = "";
            cb1.DisplayMember = "td_descripcion";

            cb2.DataSource = dt1;
            cb2.ValueMember = "";
            cb2.DisplayMember = "td_descripcion";

            cb3.DataSource = dt1;
            cb3.ValueMember = "";
            cb3.DisplayMember = "td_descripcion";
        }

        public static void CargarPaises(ComboBox cb1, ComboBox cb2)
        {
            DataTable dt1 = new DataTable();
            dt1 = D_Cliente.Cargar_Cmb("paises");

            cb1.DataSource = dt1;
            cb1.ValueMember = "";
            cb1.DisplayMember = "pais_descripcion";

            cb2.DataSource = dt1;
            cb2.ValueMember = "";
            cb2.DisplayMember = "pais_descripcion";
        }

        public static bool Esta_Cliente_Habilitado(int id)
        {
            return D_Cliente.Estado_Cliente(id);
        }
    }
}
