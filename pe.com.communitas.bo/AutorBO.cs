using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class AutorBO
    {
        public int idautor { get; set; }
        public string nomautor { get; set; }
        public string apepautor { get; set; }
        public string apemautor { get; set; }
        public bool estautor { get; set; }

        // clave foranea
        public PaisBO pais { get; set; }
    }
}
