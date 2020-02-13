using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micrositio_Acreditacion.Models
{
    /// <summary>Modelo Preview</summary>
    public class Preview
    {
        /// <summary>Gets o sets los ingresados.</summary>
        /// <value>ingresados.</value>
        public string ingresados { get; set; }
        /// <summary>Gets o sets el monto ingresado.</summary>
        /// <value> Montoingresado.</value>
        public string Montoingresado { get; set; }
        /// <summary>Gets o sets los aceptados.</summary>
        /// <value> aceptados.</value>
        public string aceptados { get; set; }
        /// <summary>Gets o sets el montoa ceptados.</summary>
        /// <value> Montoaceptados.</value>
        public string Montoaceptados { get; set; }
        /// <summary>Gets o sets los rechazados.</summary>
        /// <value> rechazados.</value>
        public string rechazados { get; set; }
        /// <summary>Gets o sets el monto rechazados.</summary>
        /// <value> Montorechazados.</value>
        public string Montorechazados { get; set; }
        /// <summary>Gets o sets la fecha.</summary>
        /// <value>fecha.</value>
        public string fecha { get; set; }
    }
}