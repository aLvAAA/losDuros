using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    public class E_Saldo
    {
        // Atributos
        private string _idCli;
        private string _cta;
        private string _nombre;
        private string _apellido;
        private string _mail;
        private string _tipoDoc;
        private string _nroDoc;
        private string _moneda;

        // Contructor
        public E_Saldo()
        {
            _idCli = "";
            _nombre = "";
            _apellido = "";
            _mail = "";
            _tipoDoc = "Pasaporte";
            _nroDoc = "";
            _cta = "";
            _moneda = "dolares";
        }

        //Getters & Setters
        public string id
        {
            set { _idCli = value; }
            get { return _idCli; }
        }
        public string cta
        {
            set { _cta = value; }
            get { return _cta; }
        }
        public string nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
        }
        public string apellido
        {
            set { _apellido = value; }
            get { return _apellido; }
        }
        public string mail
        {
            set { _mail = value; }
            get { return _mail; }
        }
        public string tipoDoc
        {
            set { _tipoDoc = value; }
            get { return _tipoDoc; }
        }
        public string nroDoc
        {
            set { _nroDoc = value; }
            get { return _nroDoc; }
        }
        public string moneda
        {
            set { _moneda = value; }
            get { return _moneda; }
        }
    }
}
