using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    class E_TransfCta
    {
        private long idCta;

        public long IdCta
        {
            get { return idCta; }
            set { idCta = value; }
        }
        private String estadoCta;

        public String EstadoCta
        {
            get { return estadoCta; }
            set { estadoCta = value; }
        }
        private String categoriaCta;

        public String CategoriaCta
        {
            get { return categoriaCta; }
            set { categoriaCta = value; }
        }
        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

    }
}
