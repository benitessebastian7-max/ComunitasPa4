using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class InventarioBO
    {
        public int codigo { get; set; }
        public int stockdisponible { get; set; }
        public int stockminimo { get; set; }
        public DateTime fechaactualizacion { get; set; }
        public bool estado { get; set; }

        // clave foránea
        public ProductoBO producto { get; set; }
    }
}
