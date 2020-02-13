using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micrositio_Acreditacion.Models
{
    /// <summary>Modelo Sucursales</summary>
    public class Sucursales
    {
        /// <summary>Gets o sets el Id.</summary>
        /// <value>Id.</value>
        public int Id { get; set; }

        /// <summary>Gets o sets la sucursal.</summary>
        /// <value>Sucursal.</value>
        public string Sucursal { get; set; } //Codigo de sucursal 001 002 003 etc

        /// <summary>Gets o sets la descripcion.</summary>
        /// <value>Descripcion.</value>
        public string Descripcion { get; set; }
    }
}