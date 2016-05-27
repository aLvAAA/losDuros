using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PagoElectronico.ENTIDADES;
using PagoElectronico.DATOS;


namespace PagoElectronico.NEGOCIO
{
    public class N_Cuenta
    {
        public static void cargarComboboxCategoria(ComboBox c, string categoria, string categoria2)
        {
            DataTable dt = new DataTable();
            dt = D_Cuenta.cargarCombobox("categoria");
            int cant = dt.Rows.Count;
            for (int i = 0; i < cant; i++)
            {
                if (dt.Rows[i][0].ToString() == categoria || dt.Rows[i][0].ToString() == categoria2)
                {
                    dt.Rows[i].Delete();
                }
            }
            c.DataSource = dt;
            c.ValueMember = "";
            c.DisplayMember = "cat_descripcion";
        }

        public static void Actualizar_Cuentas_al_Dia_de_Hoy(DateTime fecha)
        {
            D_Cuenta.ActualizarCuentas(fecha);
        }

        public static void Mostrar_Cuentas_Un_Cliente(int id, DataGridView cuentas)
        {
            DataTable dt = new DataTable();
            dt = D_Cuenta.MostrarCuentasUnCliente(id);
            if (dt.Rows.Count > 0)
            {
                cuentas.DataSource = dt;
                for (int i = 0; i < cuentas.Rows.Count; i++)
                {
                    string estado = cuentas.Rows[i].Cells[4].Value.ToString();
                    if (estado == "1")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
                    }
                    else if (estado == "2")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    }
                    else if (estado == "3")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    }
                }
                cuentas.Columns.RemoveAt(4);
            }
            else
            {
                MessageBox.Show("No tiene cuentas aun, vaya a crear una", "Resultado Carga de cuentas");
            }
        }

        public static void Mostrar_Cuentas_X_Filtro(DataGridView cuentas, string id, string name, string ape, string cate, string estado)
        {
            DataTable dt = new DataTable();
            dt = D_Cuenta.MostrarCuentasXFiltros(name, ape, id, estado, cate);
            if (dt.Rows.Count > 0)
            {
                cuentas.DataSource = dt;
                for (int i = 0; i < cuentas.Rows.Count; i++)
                {
                    string state = cuentas.Rows[i].Cells[5].Value.ToString();
                    if (state == "1")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
                    }
                    else if (state == "2")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    }
                    else if (state == "3")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    }
                }
                cuentas.Columns.RemoveAt(5);
            }
            else
            {
                MessageBox.Show("No existen cuentas con esos parametros", "Resultado Carga de cuentas");
            }


        }

        public static void Mostrar_Cuentas_Globales(DataGridView cuentas)
        {
            DataTable dt = new DataTable();
            dt = D_Cuenta.MostrarCuentasMuchosClientes();
            if (dt.Rows.Count > 0)
            {
                string estado;
                cuentas.DataSource = dt;
                for (int i = 0; i < cuentas.Rows.Count; i++)
                {
                    estado = cuentas.Rows[i].Cells[5].Value.ToString();
                    if (estado == "1")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
                    }
                    else if (estado == "2")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                    }
                    else if (estado == "3")
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        cuentas.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;
                    }
                }
                cuentas.Columns.RemoveAt(5);
            }
            else
            {
                MessageBox.Show("No existen cuentas en el sistema", "Resultado Carga de cuentas");
            }

        }

        public static void Buscar_Clientes_por_Filtro(string nom, string ape, string mail, string doc, string nrodoc, DataGridView clientes, Button irAlta)
        {
            DataTable dt = new DataTable();
            dt = D_Cuenta.Lista_Clientes_con_Filtro(nom, ape, mail, doc, nrodoc);
            if (dt.Rows.Count > 0)
            {
                clientes.DataSource = dt;
                irAlta.Enabled = true;
            }
            else
            {
                irAlta.Enabled = false;
                MessageBox.Show("No existen clientes con esos parametros", "Resultado de busqueda de clientes");
                clientes.DataSource = null;
            }
        }

        public static void Buscar_Clientes_Globales(DataGridView clientes, Button irAlta)
        {
            DataTable dt = new DataTable();
            dt = D_Cuenta.Lista_Clientes();
            if (dt.Rows.Count > 0)
            {
                clientes.DataSource = dt;
                irAlta.Enabled = true;
            }
            else
            {
                irAlta.Enabled = false;
                MessageBox.Show("No existen clientes", "Resultado de busqueda de clientes");
                clientes.DataSource = null;
            }
        }

        public static void Cargar_Comboboxs_Admin(ComboBox pais1, ComboBox mone1,ComboBox cat3, ComboBox est3, ComboBox doc4)
        {            
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();

            dt2 = D_Cuenta.cargarCombobox("categoria");
            dt3 = D_Cuenta.cargarCombobox("paises");
            dt4 = D_Cuenta.cargarCombobox("monedas");
            dt5 = D_Cuenta.cargarCombobox("estados");
            dt6 = D_Cuenta.cargarCombobox("documento");
                        
            pais1.DataSource = dt3;
            pais1.ValueMember = "";
            pais1.DisplayMember = "pais_descripcion";

            mone1.DataSource = dt4;
            mone1.ValueMember = "";
            mone1.DisplayMember = "tm_descripcion";
                        
            cat3.DataSource = dt2;
            cat3.ValueMember = "";
            cat3.DisplayMember = "cat_descripcion";

            est3.DataSource = dt5;
            est3.ValueMember = "";
            est3.DisplayMember = "estado_descricion";

            doc4.DataSource = dt6;
            doc4.ValueMember = "";
            doc4.DisplayMember = "td_descripcion";

        }

        public static void Cargar_Combobox_Cliente(ComboBox pais1, ComboBox mone1)
        {
            DataTable dt1 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
                        
            dt3 = D_Cuenta.cargarCombobox("paises");
            dt4 = D_Cuenta.cargarCombobox("monedas");
            
            pais1.DataSource = dt3;
            pais1.ValueMember = "";
            pais1.DisplayMember = "pais_descripcion";

            mone1.DataSource = dt4;
            mone1.ValueMember = "";
            mone1.DisplayMember = "tm_descripcion";
        }

        public static void Alta_Cuenta(Button alta, int id, DateTime fecha, string categoria, string pais, string moneda, int suscrip)
        {
            string mensaje = D_Cuenta.Alta_Cuenta(id, fecha, categoria, pais, moneda, suscrip);
            if (mensaje == "OK")
            {
                MessageBox.Show("Cuenta Creada", "Resultado de Alta Cuenta");
                alta.Enabled = false;
            }
            else
            {
                MessageBox.Show(mensaje, "Resultado de Alta Cuenta");
            }
        }

        public static void Editar_Cuenta(Button edicion, Int64 cuenta, DateTime fecha, string categoria, int suscrip)
        {
            string mensaje = D_Cuenta.Editar_Cuenta(fecha, cuenta, categoria, suscrip);
            if (mensaje == "OK")
            {
                MessageBox.Show("Edicion correcta de cuenta", "Resultado de Edicion de cuenta");
                edicion.Enabled = false;
            }
            else
            {
                MessageBox.Show("no se pudo editar la cuenta", "Resultaado de edicion de cuenta");
            }
        }

        public static void Baja_Cuenta(Int64 cuenta, DateTime fecha)
        {
            string mensaje = D_Cuenta.Baja_Cuenta(cuenta, fecha);
            if (mensaje == "OK")
            {
                MessageBox.Show("Cuenta dado de Baja", "Resultado de Baja de Cuenta");
            }
            else
            {
                MessageBox.Show("Tiene que pagar todas las transacciones antes de dar de baja", "Resultado de Baja de Cuenta");
            }
        }
                
    }
}
