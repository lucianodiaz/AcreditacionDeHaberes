using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micrositio_Acreditacion.Models
{
    public class ListadoSolicitudesMuni
    {
        public int id { get; set; }
        public string cuit { get; set; }
        public string cuenta { get; set; }
        public string fecha { get; set; }
        public string nombreArchivo { get; set; }

    }
}