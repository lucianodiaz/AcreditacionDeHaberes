using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micrositio_Acreditacion.Models
{
    /// <summary></summary>
    public class Empleado
    {
        /// <summary>Gets o sets el Id.</summary>
        /// <value>Id.</value>
        public int Id { get; set; }
        /// <summary>Gets o sets el nombre.</summary>
        /// <value>Nombre.</value>
        public string Nombre { get; set; }
        /// <summary>Gets o sets el dni.</summary>
        /// <value>Dni.</value>
        public string Dni { get; set; }
        /// <summary>Gets o sets el cuil.</summary>
        /// <value>Cuil.</value>
        public string Cuil { get; set; }
        /// <summary>Gets o sets la sucursal.</summary>
        /// <value>Sucursal.</value>
        public string Sucursal { get; set; }
        /// <summary>Gets o sets la cuenta.</summary>
        /// <value>Cuenta.</value>
        public string Cuenta { get; set; }
        /// <summary>Gets o sets la fecha.</summary>
        /// <value>Fecha.</value>
        public string Fecha { get; set; }
        /// <summary>Gets o sets la fechaFormat.</summary>
        /// <value>fechaFormat.</value>
        public DateTime FechaFormat { get; set; }
        /// <summary>Gets o sets el importe.</summary>
        /// <value>Importe.</value>
        public string Importe { get; set; }
        /// <summary>Gets o sets el tipo cuenta.</summary>
        /// <value>tipoCuenta.</value>
        public string TipoCuenta { get; set; }
        /// <summary>Gets o sets el tipo acreditacion.</summary>
        /// <value>tipoAcreditacion.</value>
        public string TipoAcreditacion { get; set; }
        /// <summary>Gets o sets el cod emp.</summary>
        /// <value>codEmp</value>
        public string CodEmp { get; set; }
        /// <summary>Gets o sets el cbu.</summary>
        /// <value>CBU.</value>
        public string CBU { get; set; }
        /// <summary>Gets o sets un valor indicando si <see cref="Empleado"/> esta activo.</summary>
        /// <value>
        ///   <c>true</c> si esta activo; sino, <c>false</c>.</value>
        public bool Activo { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string EstadoCuenta { get; set; }
    }
}