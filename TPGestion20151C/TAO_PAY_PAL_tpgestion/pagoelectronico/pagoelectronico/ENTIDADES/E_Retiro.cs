using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    public class E_Retiro
    {
        #region Atributos
        private int _id;
        private int _dni;
        private long _cta;
        private DateTime _fecha;
        private string _banco;
        private double _monto;
        #endregion

        public E_Retiro()
        {
            _monto = 0;
            _dni = 0;
        }

        #region Encapsulamiento
        public int dni
        {
            set { _dni = value; }
            get { return _dni; }
        }
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public long cuenta
        {
            set { _cta = value; }
            get { return _cta; }
        }
        public DateTime fecha
        {
            set { _fecha = value; }
            get { return _fecha; }
        }
        public string banco
        {
            set { _banco = value; }
            get { return _banco; }
        }
        public double monto
        {
            set { _monto = value; }
            get { return _monto; }
        }
        #endregion
    }
}
