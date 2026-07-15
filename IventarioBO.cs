using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class IventarioBO
    {
        public int idinv { get; set; }
        public int stockdis { get; set; }
        public int stockmin { get; set; }
        public DateTime fecact { get; set; }
        public bool estinv { get; set; }

        // clave foranea
        public ProductoBO producto { get; set; }
    }
}
