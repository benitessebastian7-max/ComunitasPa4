using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class EmpleadoBO
    {
        public int idemp { get; set; }
        public string nomemp { get; set; }
        public string apepemp { get; set; }
        public string apememp { get; set; }
        public string numdocemp { get; set; }
        public DateTime fecnacemp { get; set; }
        public string diremp { get; set; }
        public string telemp { get; set; }
        public string coremp { get; set; }
        public DateTime fecinemp { get; set; }
        public string usuemp { get; set; }
        public string claemp {get; set; }
        public decimal sueldoemp { get; set; }
        public int numhoremp { get; set; }
        public bool estemp { get; set; }

        // claves foraneas
        public TipoDocumentoBO tipodocumento { get; set; }
        public RolBO rol { get; set; }
        public DistritoBO distrito { get; set; }
    }
}
