using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Micrositio_Acreditacion
{
    /// <summary>Inicia la aplicacion</summary>
    public class MvcApplication : System.Web.HttpApplication
    {

        /// <summary>Inicia la aplicacion.</summary>
        /// <example>
        ///   <code> protected void Application_Start()
        ///         {
        ///             AreaRegistration.RegisterAllAreas();
        ///             RouteConfig.RegisterRoutes(RouteTable.Routes);
        ///         }</code>
        /// </example>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
