using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class ProductoBO
    {
        public int codigo { get; set; }
        public string isbn { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public decimal preciocompra { get; set; }
        public decimal precioventa { get; set; }
        public DateTime fechapublicacion { get; set; }
        public bool estado { get; set; }

        // claves foráneas
        public ProveedorBO proveedor { get; set; }
        public CategoriaBO categoria { get; set; }
        public EditorialBO editorial { get; set; }
    }
}
