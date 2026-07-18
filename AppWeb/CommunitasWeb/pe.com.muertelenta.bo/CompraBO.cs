using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class CompraBO
    {
        public int codigocompra { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }

        public ProveedorBO proveedor { get; set; }
        public List<DetalleCompraBO> detalles { get; set; }

        public CompraBO()
        {
            proveedor = new ProveedorBO();
            detalles = new List<DetalleCompraBO>();
        }

        public decimal subtotal { get; set; }
    }
}
