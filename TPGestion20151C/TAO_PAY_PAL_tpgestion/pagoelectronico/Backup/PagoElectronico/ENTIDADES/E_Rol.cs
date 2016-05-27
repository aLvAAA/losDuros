using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ENTIDADES
{
    class E_Rol
    {
        private int id;
        private string nombre;
        private List<int> funcionalidades;
        private string estado;


        public E_Rol()
        {
            id = 0;
            nombre = "";
            funcionalidades = new List<int>();
            estado = "";
        }

        public E_Rol(string nombre, List<int> funcionalidades, string estado)
        {
            this.Nombre = nombre;
            this.funcionalidades = funcionalidades;
            this.estado = estado;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }

        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public List<int> Funcionalidades
        {
            get { return funcionalidades; }
            set { funcionalidades = value; }
        }

        public void AgregarFuncionalidad(int codFunc)
        {
            funcionalidades.Add(codFunc);
        }

        public void mostrarFuncionalidades()
        {
            MessageBox.Show("Entidad: " + nombre);
            MessageBox.Show("Estado: " + estado);
            foreach (int codFunc in funcionalidades)
            {
                MessageBox.Show("codf: " + codFunc);
            }
        }
    }
}
