using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class VentaBO
    {
        public int codigoventa { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }

        public EmpleadoBO empleado { get; set; }
        public ClienteBO cliente { get; set; }
        public TipoPagoBO tipopago { get; set; }

        public List<DetalleVentaBO> detalles { get; set; }

        public VentaBO()
        {
            empleado = new EmpleadoBO();
            cliente = new ClienteBO();
            tipopago = new TipoPagoBO();
            detalles = new List<DetalleVentaBO>();
        }

        public decimal subtotal { get; set; }
    }
}
