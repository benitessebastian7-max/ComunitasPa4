using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class AutorBO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public bool estado { get; set; }

        // clave foránea
        public PaisBO pais { get; set; }
    }
}
