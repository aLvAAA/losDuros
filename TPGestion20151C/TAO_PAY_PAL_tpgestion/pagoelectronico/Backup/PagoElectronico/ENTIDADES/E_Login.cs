using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.ENTIDADES
{
    public class E_Login
    {
        #region Atributos
        private string _username;
        private string _password;
        #endregion

        #region Constructor
        public E_Login(string username, string password)
        {
            _username = username;
            _password = password;
        }
        #endregion

        #region Encapsulamiento
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        #endregion
    }
}
