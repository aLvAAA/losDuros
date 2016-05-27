using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PagoElectronico.DATOS;
using PagoElectronico.ENTIDADES;

namespace PagoElectronico.NEGOCIO
{
    class N_Login
    {
        public bool ValidarUsuario(E_Login user) // (JON)
        {
            return new D_Login().ValidarUsuario(user);
        }
        public bool TieneMasDeUnRol(E_Login user) // (JON)
        {
            return new D_Login().TieneMasDeUnRol(user);
        }

        public static int IdentificarUsuario(E_Login u)
        {
            int id = 0;
            DataTable dt = new DataTable();
            dt = D_Login.ObtenerIDUsuario(u);
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0][0]);
            }
            return id;
        }
    }
}
