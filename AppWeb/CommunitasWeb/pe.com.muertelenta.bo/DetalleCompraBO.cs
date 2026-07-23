using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class DetalleCompraBO
    {
        public int codigodetalle { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal subtotal { get; set; }

        public int codigocompra { get; set; }
        public int codigoproducto { get; set; }

        public ProductoBO producto { get; set; }
    }
}