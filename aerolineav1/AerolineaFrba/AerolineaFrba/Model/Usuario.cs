using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AerolineaFrba.Model
{
    class Usuario
    {
        public static Boolean admin;
        private string nombre { get; set; }
        private string password { get; set; }

        public Usuario(string n, string p)
        {
            //Validar parametros
            if (n != "" && p != "")
            {
                this.nombre = n;
                this.password = p;
            }
            else throw new Exception();
        }

        public bool intentarLogin()
        {
            GD2C2015DataSetTableAdapters.UsuarioTableAdapter usrAdapter = new GD2C2015DataSetTableAdapters.UsuarioTableAdapter();
            
            //Hashear contraseña
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] hashValue;
            hashValue = mySHA256.ComputeHash(GetBytes(password));

            //Llamar al stored procedure y devolver resultado
            return Convert.ToBoolean(usrAdapter.IntentarLogin(nombre, hashValue));  
        }

        //Obtiene bytes de un string
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
