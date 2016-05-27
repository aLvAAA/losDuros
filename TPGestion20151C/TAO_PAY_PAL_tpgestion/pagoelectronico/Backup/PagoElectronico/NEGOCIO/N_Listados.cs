using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PagoElectronico.DATOS;

namespace PagoElectronico.NEGOCIO
{
    class N_Listados
    {
        
        public static DataTable GenerarListado(int trim, int año, string nroListado)
        {
            return D_Listados.GetListado(trim, año, nroListado);
        }
    }
}
