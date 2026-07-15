using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class LibroAutorBO
    {
        public int idlibroautor { get; set; }
        public bool estlibroautor { get; set; }

        // claves foraneas
        public AutorBO autor { get; set; }
        public ProductoBO producto { get; set; }
    }
}
