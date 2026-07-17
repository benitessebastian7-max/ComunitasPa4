using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace pe.com.communitas.ui.util
{
    public class Util
    {
        public static void MensajePersonalizado(Page page, string mensaje)
        {
            string script = $"alert('{mensaje.Replace("'", "\\'")}');";
            page.ClientScript.RegisterStartupScript(page.GetType(), "Mensaje",
                script, true);
        }
        /// <summary>
        /// Redirige a otra pagina dentro de la aplicacion
        /// </summary>
        public static void AbrirPagina(string url)
        {
            HttpContext.Current.Response.Redirect(url, true);
        }

    }
}