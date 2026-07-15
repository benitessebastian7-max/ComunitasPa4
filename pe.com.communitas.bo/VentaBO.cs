using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class VentaBO
    {
        public int idventa { get; set; }
        public DateTime fecventa { get; set; }
        public decimal totalventa { get; set; }
        public bool estventa { get; set; }

        // claves foraneas
        public EmpleadoBO empleado { get; set; }
        public ClienteBO cliente { get; set; }
        public TipoPagoBO tipopago { get; set; }
    }
}
