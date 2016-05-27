using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    public class E_Cliente
    {
        #region Atributos
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _tipoDocDesc;
        private int _nroDoc;
        private string _pais;
        private string _domCalle;
        private int _domNro;
        private int _domPiso;
        private string _domDepto;
        private DateTime _fechaNacimiento;
        private string _mail;
        #endregion


        #region Constructor


        public E_Cliente()
        {
            _id = 0;
            _nombre = "";
            _apellido = "";
            _tipoDocDesc = "";
            _nroDoc = 0;
            _pais = "";
            _domCalle = "";
            _domNro = 0;
            _domPiso = 0;
            _domDepto = "";
            _mail = "";
        }

        #endregion


        #region Encapsulamiento

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string tipoDocDesc
        {
            get { return _tipoDocDesc; }
            set { _tipoDocDesc = value; }
        }
        public int nroDoc
        {
            get { return _nroDoc; }
            set { _nroDoc = value; }
        }
        public string pais
        {
            get { return _pais; }
            set { _pais = value; }
        }
        public string domCalle
        {
            get { return _domCalle; }
            set { _domCalle = value; }
        }
        public int domNro
        {
            get { return _domNro; }
            set { _domNro = value; }
        }
        public int domPiso
        {
            get { return _domPiso; }
            set { _domPiso = value; }
        }
        public string domDepto
        {
            get { return _domDepto; }
            set { _domDepto = value; }
        }
        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        #endregion
    }
}
