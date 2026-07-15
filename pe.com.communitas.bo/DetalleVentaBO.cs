using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class DetalleVentaBO
    {
        public int iddetvent { get; set; }
        public int idventa { get; set; }
        public int idprod { get; set; }
        public int canventa { get; set; }
        public decimal precuventa { get; set; }
        public decimal subtotventa { get; set; }

      public VentaBO idventa { get; set; }
      public ProductoBO idprod { get; set; }
    }
}
