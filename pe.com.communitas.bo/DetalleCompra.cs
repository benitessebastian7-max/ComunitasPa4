using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class DetalleCompraBO
    {
        public int iddetcomp { get; set; }
        public int idcompra { get; set; }
        public int idprod { get; set; }
        public int cancompra { get; set; }
        public decimal precucomp { get; set; }
        public decimal subtotcomp { get; set; }

      public CompraBO idcompra { get; set; }
      public ProductoBO idprod { get; set; }
    }
}
