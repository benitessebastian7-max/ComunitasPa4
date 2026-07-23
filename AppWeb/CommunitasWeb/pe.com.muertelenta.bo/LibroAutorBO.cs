using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class LibroAutorBO
    {
        public int codigo { get; set; }
        public bool estado { get; set; }

        // claves foráneas
        public AutorBO autor { get; set; }
        public ProductoBO producto { get; set; }
    }
}
