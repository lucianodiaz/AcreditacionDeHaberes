using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micrositio_Acreditacion.Models
{
    /// <summary>Modelo Empresa</summary>
    public class Empresa
    {
        /// <summary>Gets o sets el Id.</summary>
        /// <value>Id.</value>
        public int Id { get; set; }
        /// <summary>Gets o sets el cuit.</summary>
        /// <value>Cuit.</value>
        public string Cuit { get; set; }
        /// <summary>Gets o sets la razon social.</summary>
        /// <value>RazonSocial</value>
        public string RazonSocial { get; set; }
        /// <summary>Gets o sets el domicilio.</summary>
        /// <value>Domicilio.</value>
        public string Domicilio { get; set; }
        /// <summary>Gets o sets el numero de cta.</summary>
        /// <value>NumeroDeCta.</value>
        public string NumeroDeCta { get; set; }
        /// <summary>Gets o sets el email.</summary>
        /// <value>Email.</value>
        public string Email { get; set; }
        /// <summary>Gets o sets el telefono.</summary>
        /// <value>Telefono.</value>
        public string Telefono { get; set; }
        /// <summary>Gets o sets el codigo empresa.</summary>
        /// <value>CodEmp.</value>
        public string CodEmp { get; set; }
        /// <summary>Gets o sets el numero de convenio.</summary>
        /// <value>nConvenio.</value>
        public string nConvenio { get; set; }
        /// <summary>Gets o sets el tipo cuenta.</summary>
        /// <value>TipoCuenta.</value>
        public string TipoCuenta { get; set; }
        /// <summary>Gets o sets el tipo acreditacion.</summary>
        /// <value>TipoAcreditacion.</value>
        public string TipoAcreditacion { get; set; }
        /// <summary>Gets o sets la sucursal.</summary>
        /// <value>Sucursal.</value>
        public string Sucursal { get; set; }
        //menu        
        /// <summary>
        /// Gets or sets the menu.
        /// </summary>
        /// <value>
        /// The menu.
        /// </value>
        public int Menu { get; set; }
    }
}