using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class EmpleadoBO
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public string numerodocumento { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fechaingreso { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public decimal sueldo { get; set; }
        public int numerohoras { get; set; }
        public bool estado { get; set; }

        // claves foráneas
        public TipoDocumentoBO tipodocumento { get; set; }
        public RolBO rol { get; set; }
        public DistritoBO distrito { get; set; }
    }
}
