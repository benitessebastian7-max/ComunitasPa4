using System;
using System.Collections.Generic;
using System.Text;

namespace pe.com.communitas.bo
{
    public class ClienteBO
    {
        public int idcli { get; set; }
        public string nomcli { get; set; }
        public string apepcli { get; set; }
        public string apemcli { get; set; }
        public string numdoccli { get; set; }
        public DateTime fecnaccli { get; set; }
        public string dircli { get; set; }
        public string telcli { get; set; }
        public string corcli { get; set; }
        public bool estcli { get; set; }

        // claves foraneas
        public TipoDocumentoBO tipodocumento { get; set; }
        public DistritoBO distrito { get; set; }
    }
}
