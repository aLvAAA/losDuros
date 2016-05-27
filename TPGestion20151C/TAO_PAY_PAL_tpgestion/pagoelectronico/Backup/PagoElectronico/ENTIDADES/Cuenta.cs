using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    class Cuenta
    {
        private int numCuenta;
        private String pais;
        private String tipoCuenta;
        private String tipoMoneda;
        private DateTime fechaApertura;

        public Cuenta(){
        }

        public int NumCuenta
        {
            get { return numCuenta; }
            set { numCuenta = value; }
        }

        public String Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public String TipoMoneda
        {
            get { return tipoMoneda; }
            set { tipoMoneda = value; }
        }

        public DateTime FechaApertura
        {
            get { return fechaApertura; }
            set { fechaApertura = value; }
        }

        public String TipoCuenta
        {
            get { return tipoCuenta; }
            set { tipoCuenta = value; }
        }

    }
}
