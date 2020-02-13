using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micrositio_Acreditacion.Models
{
    /// <summary>Modelo TipoAcreditacion</summary>
    public class TipoAcreditacion
    {
        /// <summary>Gets o sets el Id.</summary>
        /// <value>Id.</value>
        public int Id { get; set; }
        /// <summary>Gets o sets el codigo.</summary>
        /// <value>Codigo.</value>
        public string Codigo { get; set; }
        /// <summary>Gets o sets la denominacion.</summary>
        /// <value>Denominacion.</value>
        public string Denominacion { get; set; }
        /// <summary>Gets o sets la denominacion reducida.</summary>
        /// <value>DenoReducida.</value>
        public string DenoReducida { get; set; }

    }
}