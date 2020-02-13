using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Micrositio_Acreditacion
{

    /// <summary>Configuracion de rutas</summary>
    public class RouteConfig
    {


        /// <summary>Registra el path de las rutas.</summary>
        /// <param name="routes">la ruta por defecto es Home Index (Controlador Metodo).</param>
        /// <example>
        ///   <code>public static void RegisterRoutes(RouteCollection routes)
        ///       {
        ///           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        ///
        ///           routes.MapRoute(
        ///               name: "Default",
        ///               url: "{controller}/{action}/{id}",
        ///               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        ///           );
        ///       }</code>
        /// </example>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
