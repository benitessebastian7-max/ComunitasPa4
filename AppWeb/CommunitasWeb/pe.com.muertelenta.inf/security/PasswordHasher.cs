using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.inf.security
{
    public static class PasswordHasher
    {
        //generamos una funcion que permita un hash seguro de la contraseña usando algoritmo
        //SAH256, esto ideal para almacenar contraseñas en una base e datos
            public static string HashPassword(string password)
            {
                using (var sha = SHA256.Create())
                {
                    //convertimos la contraseña a bytes usando UTF8
                    var bytes = Encoding.UTF8.GetBytes(password);
                    //calculamos el hash de los bytes
                    var hash = sha.ComputeHash(bytes);
                    //convertimos el hash en una cadena hexadecimal en minusculas
                    return BitConverter.ToString(hash).Replace("-", "").ToLower();
                }
            }

            //creamos una funcion para verificar si una contraseña ingresada coincide con el hash
            //almacenado, se vuelve a hashear la contraseña ingresada
            public static bool VerifyPassword(string password, string hash)
            {
                //generamos el hash de la contraseña ingresada
                string newhash = HashPassword(password);
                //comparamos el hash generado con el has almacenado
                return newhash == hash;
            }
        }

    }

