using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    public class E_Usuario
    {
        private int _id;
        private string _username;
        private string _password;
        private string _rol;
        private DateTime _fechaCreacion;
        private DateTime _fechaUltimaModificacion;
        private string _preguntaSecreta;
        private string _respuestaSecreta;

        public E_Usuario() { }
        public E_Usuario(string t1, string t2, DateTime t3)
        {
            _username = t1;
            _password = t2;
            _fechaCreacion = t3;
        }

        public int id 
        {
            set { _id = value; }
            get { return _id; }
        }
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string pass
        {
            get { return _password; }
            set { _password = value; }
        }
        public string rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
        public DateTime fechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
        public DateTime fechaUltimaModificacion
        {
            get { return _fechaUltimaModificacion; }
            set { _fechaUltimaModificacion = value; }
        }
        public string preguntaSecreta
        {
            get { return _preguntaSecreta; }
            set { _preguntaSecreta = value; }
        }
        public string respuestaSecreta
        {
            get { return _respuestaSecreta; }
            set { _respuestaSecreta = value; }
        }
    }
}
