using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    public class E_Tarjeta
    {
        #region Atributos
        private int _tar_id;
        private string _tarCodigo;
        private int _tar_user_id;
        private string _tarEmisor;
        private DateTime _tarFechaEmision;
        private DateTime _tarFechaVencimiento;
        private string _tarSeguridad;
        private string _tarSeguridadNueva;
        #endregion

        #region Contructor
        public E_Tarjeta()
        {
            _tarSeguridad = "";
            _tarSeguridadNueva = "";
        }
        public E_Tarjeta(string emisor, DateTime fechaEmision, DateTime fechaVencimiento, string seguridad)
        {
            _tarEmisor = emisor;
            _tarFechaEmision = fechaEmision;
            _tarFechaVencimiento = fechaVencimiento;
            _tarSeguridad = seguridad;
        }
        #endregion

        #region Encapsulamiento
        public int id
        {
            set { _tar_id = value; }
            get { return _tar_id; }
        }

        public string Codigo
        {
            set { _tarCodigo = value; }
            get { return _tarCodigo; }
        }

        public int user_id
        {
            set { _tar_user_id = value; }
            get { return _tar_user_id; }
        }

        public string emisor
        {
            set { _tarEmisor = value; }
            get { return _tarEmisor; }
        }

        public DateTime fechaEmision
        {
            set { _tarFechaEmision = value; }
            get { return _tarFechaEmision; }
        }

        public DateTime fechaVencimiento
        {
            set { _tarFechaVencimiento = value; }
            get { return _tarFechaVencimiento; }
        }

        public string seguridad
        {
            set { _tarSeguridad = value; }
            get { return _tarSeguridad; }
        }

        public string seguridadNueva
        {
            set { _tarSeguridadNueva = value; }
            get { return _tarSeguridadNueva; }
        }

        #endregion
    }
}
