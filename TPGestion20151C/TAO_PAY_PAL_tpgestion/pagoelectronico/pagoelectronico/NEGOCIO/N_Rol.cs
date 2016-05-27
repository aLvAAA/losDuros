using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.DATOS;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.NEGOCIO
{
    class N_Rol
    {
        private E_Rol rol;

        public N_Rol()
        {
            rol = new E_Rol();
        }

        public void SetId(int id)
        {
            rol.Id = id;
        }

        public void SetNombre(string nombre)
        {
            rol.Nombre = nombre;
        }

        public void SetEstado(string estado)
        {
            rol.Estado = estado;
        }

        public char GetEstado()
        {
            return Convert.ToChar(D_Rol.GetEstado(rol).Rows[0][0]);
        }

        public void AgregarFuncionalidad(int cod)
        {
            rol.AgregarFuncionalidad(cod);
        }

        public E_Rol Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        //Insertar
        public int Insertar()
        {
            int rta;
            //rol.mostrarFuncionalidades();
            rta = D_Rol.Insertar(rol);
            //rta tiene el id del elemento insertado
            rol.Id = rta;
            if (rta != -1)
            {
                foreach (int funcId in rol.Funcionalidades)
                {
                    D_Rol.AgregarFuncionalidad(rol.Id, funcId);
                }

            }
            return rta;
        }

        //Editar
        public string Modificar()
        {
            return D_Rol.Modificar(rol);
        }

        //Agrega funcionalidad modificando rol
        public static string AgregarFuncionalidad(int codRol, int codFunc)
        {
            return D_Rol.AgregarFuncionalidad(codRol, codFunc);
        }

        //Quita funcionalidad modificando rol
        public static string QuitarFuncionalidad(int codRol, int codFunc)
        {
            return D_Rol.QuitarFuncionalidad(codRol, codFunc);
        }

        //Baja
        public string Baja()
        {
            return D_Rol.Baja(rol);
        }

        //Listado de todos los roles
        public static DataTable GetAllRoles()
        {
            return D_Rol.GetRoles();
        }

        //Busqueda de rol por filtros
        public static DataTable GetRoles(string filtroNombre, char estado, int codFunc)
        {
            return D_Rol.BuscarRoles(filtroNombre, estado, codFunc);
        }

        //Listado de todas las funcionalidades
        public static DataTable GetAllFuncionalidades()
        {
            return D_Rol.GetFuncionalidades();
        }

        //Listado funcionalidades de un rol
        public DataTable GetFuncionalidades()
        {
            return D_Rol.BuscarFuncionalidades(rol);
        }

        //Listado funcionalidaddes de un rol adaptado para usar desde frmfunc mas facil
        public static DataTable GetFuncionalidades(int codRol)
        {
            E_Rol rolAux = new E_Rol();
            rolAux.Id = codRol;
            return D_Rol.BuscarFuncionalidades(rolAux);
        }



    }
}
