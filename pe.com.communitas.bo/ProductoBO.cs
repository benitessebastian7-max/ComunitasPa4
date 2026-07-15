using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class ProductoBO
    {
        public int idprod { get; set; }
        public string isbnprod { get; set; }
        public string titprod { get; set; }
        public string descprod {get; set; }
        public decimal preccompprod { get; set; }
        public decimal precventprod { get; set; }
        public DateTime fecpubprod { get; set; }
        public bool estprod { get; set; }

        // claves foraneas
        public ProveedorBO proveedor { get; set; }
        public CategoriaBO categoria { get; set; }
        public EditorialBO editorial { get; set; }
    }
}
