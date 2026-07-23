using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace pe.com.communitas.dal
{
    public class ConexionDAL
    {
        //cadena de conexion -> conectarte con el Servidor SQL Server
        //Tipos de Conxiones: Autentificacion de Windows y Autenficacion SQL
        //Autenticacion Windows
        //SQL Server Standard, Developer, Profesional o Enterprise
        //private string cadena = "Data Source=.; Initial Catalog=bdmuertelenta20261; Integrated Security=True; TrustServerCertificate=True;";
        //SQL Express
        //private string cadena = "Data Source=DESKTOP-SI1HCLT; Initial Catalog=bdmuertelenta20261; Integrated Security=True; TrustServerCertificate=True;";
        //Autenticacion SQL
        //SQL Server Standard, Developer, Profesional o Enterprise
        //private string cadena = "Data Source=.; Initial Catalog=bdmuertelenta20261; User ID=sa; Password=sql TrustServerCertificate=True;";
        //SQL Express
        //private string cadena = "Data Source=DESKTOP-SI1HCLT; Initial Catalog=bdmuertelenta20261; User ID=sa; Password=sql TrustServerCertificate=True;";

        //Data Source: es el nombre del servidor SQL
        //Initial Catalog: es el nombre de la base de datos a la cual nos vamos a conectar
        //Integrated Security: autenticacion que se realiza con las credenciales de Windows
        //User ID: es el usuario del SQL Server, previamente creado
        //Password: la clave del usuario SQL Server
        //TrustServerCertificate: es una opcion de seguridad donde se acepta o no el certificado de seguridad

        //Proveedores para poder conectarse con SQL Server mediante ADO.Net
        //System.Data.SqlClient: proveedor clasico
        //Microsoft.Data.SqlClient: el proveedor moderno y recomendado

        //cadena de conexion
        private string cadena = "Data Source=.; Initial Catalog=EI5447CommunitasBD; Integrated Security=True; TrustServerCertificate=True;";

        //creamos un objeto de tipo SqlConnection
        private SqlConnection xcon;

        //creamos una funcion para poder conectarnos
        public SqlConnection Conectar()
        {
            try
            {
                //instanciamos la cadena de conexion
                xcon = new SqlConnection(cadena);
                //abrimos la conexion
                xcon.Open();
                //devolvemos la conexion
                return xcon;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                return null;
            }
        }

        //creamos un procedimiento para cerrar la conexion
        public void CerrarConexion()
        {
            //cerramos la conexion
            xcon.Close();
            //liberamos los recursos
            xcon.Dispose();
        }
    }
}
