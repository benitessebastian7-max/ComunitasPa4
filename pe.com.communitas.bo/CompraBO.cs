using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class CompraBO
    {
        public int idcompra { get; set; }
        public DateTime feccompra { get; set; }
        public decimal totalcompra { get; set; }
        public bool estcompra { get; set; }

        // clave foranea
        public ProveedorBO proveedor { get; set; }
    }
}
