using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using PagoElectronico.DATOS;
using System.Globalization;

namespace PagoElectronico.NEGOCIO
{
    class N_Transferencia
    {
        public static DataTable listarCuentas(int cliente)
        {
            return new D_Transferencia().ListarCuentas(cliente);
        }

        public static string validarBusquedaDeCuenta(String numCuenta)
        {
            return new D_Transferencia().validarExistenciaCuenta(numCuenta);
        }

        public static DataTable buscarCuenta(String numCuenta)
        {
            return new D_Transferencia().buscarCuenta(numCuenta);
        }

        public static string RealizarTransferencia(String numCtaOrigem, String numCtaDestino,
                                                 String Importe, DateTime fechaApp)
        {

            return new D_Transferencia().RealizarTransferencia(numCtaOrigem, numCtaDestino, Importe, fechaApp);

        }

        public static void validarCuentaDestino(DataTable tbCtaDestino, Int64 numCuentaDestino)
        {
            string respuesta = "SinEstado";
            Int64 numAuxiliar = -1;
            foreach (DataRow r in tbCtaDestino.Rows)
            {
                numAuxiliar = Convert.ToInt64(r[0]);
                if (numAuxiliar == numCuentaDestino)
                {
                    respuesta = Convert.ToString(r[4]);
                }

            }
            if (!respuesta.Equals("habilitada", StringComparison.OrdinalIgnoreCase))
            {
                if (!respuesta.Equals("inhabilitada", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Estado de Cuenta no Permitido");
                }
            }
            if (respuesta.Equals("SinEstado", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Cuenta no encontrada");
            }

        }

        public static Double validarImporteDeTranf(DataTable tbCtaOrigen, String numCuentaOrigen, string importe)
        {


            Int64 numCtaOrigen = Convert.ToInt64(numCuentaOrigen);
            Double saldoCta = N_Transferencia.validarCuentaOrigen(tbCtaOrigen, numCtaOrigen);
            Double importeNuevo = double.Parse(importe, CultureInfo.InvariantCulture);
            //importeNuevo = Math.Round(importeNuevo, 2, MidpointRounding.AwayFromZero);
            if (importeNuevo == 0)
            {
                throw new Exception("importe igual a Cero");
            }
            else
            {
                if (saldoCta == 0 || saldoCta < importeNuevo)
                {
                    throw new Exception("Saldo Insuficiente");
                }
            }
            return importeNuevo;
        }

        public static Double validarCuentaOrigen(DataTable tbCtaOrigen, Int64 numCuentaOrigen)
        {
            Double saldoCta = 0;
            int cantTransferencias = 0;
            String estadoCta = "Cuenta no esta Habilitada";
            foreach (DataRow r in tbCtaOrigen.Rows)
            {
                Int64 auxNumCtaOrigen = Convert.ToInt64(r[0]);
                if (auxNumCtaOrigen == numCuentaOrigen)
                {
                    saldoCta = Convert.ToDouble(r[7]);
                    cantTransferencias = Convert.ToInt16(r[6]);
                    estadoCta = Convert.ToString(r[4]);
                }

            }

            if (cantTransferencias > 5)
            {
                throw new Exception("excede la cantidad de posible de transferencias");
            }

            if (!estadoCta.Equals("habilitada", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Cuenta " + estadoCta);
            }
            return saldoCta;
        }

    }
}
