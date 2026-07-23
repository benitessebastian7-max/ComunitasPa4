using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.inf.security
{
    public static class Encryptor
    {
        //agregamos un metodo para cifrar un texto plano y convertirloa Base64
        public static string Encrypt(string plaintext)
        {
            //convertimos el texto a un arreglo de bytes usando UTF8
            byte[] data = Encoding.UTF8.GetBytes(plaintext);
            //transformamos los bytes a una cadena Base64
            return Convert.ToBase64String(data);
        }

        //agregamos un metodo para descifrar el texto convertido a base 64
        public static string Decrypt(string ciphertext)
        {
            //convertimos la cadena Base64 a un arreglo de bytes
            byte[] data = Convert.FromBase64String(ciphertext);
            //transformamos los bytes nuevamente a texto usando UTF8
            return Encoding.UTF8.GetString(data);
        }

    }
}
