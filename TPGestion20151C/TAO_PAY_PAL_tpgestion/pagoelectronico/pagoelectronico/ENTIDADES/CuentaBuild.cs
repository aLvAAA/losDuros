using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    class CuentaBuild
    {
        private Cuenta cuenta;

        internal Cuenta Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

/*        public CuentaBuild numCuenta(int numCuenta){
            cuenta.NumCuenta = numCuenta;
            return this;
        }
*/
        public CuentaBuild suPais(String suPais)        {
            cuenta.Pais = suPais;
            return this;
        }

        public CuentaBuild suMoneda(String suMoneda){
            cuenta.TipoMoneda = suMoneda;
            return this;
        }

        public CuentaBuild fechaApertura(DateTime fecha)
        {
            cuenta.FechaApertura = fecha;
            return this;
        }

        public CuentaBuild(String tipoCuenta)
        {
            this.cuenta = new Cuenta();
            cuenta.TipoCuenta = tipoCuenta;
        }

        public Cuenta build(){
            return cuenta;
        }

    }
}
