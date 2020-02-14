﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConnDB;
using Micrositio_Acreditacion.Models;
using System.Web.Services.Description;
using Micrositio_Acreditacion.Services;
using System.Web.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Micrositio_Acreditacion.Controllers
{
    /// <summary>
    ///   <para>controlador de Home</para>
    /// </summary>
    public class HomeController : Controller
    {

        //Data Source=DESKTOP-R3O9KAS;Initial Catalog=AcreHaberes;Integrated Security=True
        //TOKEN
        // string CuitSesion = "30709533769";
        //string RazSocial = "Nuestra empresa Argentina S.R.L";

        //LA MILAGROSA S.A.   30507164303
        //HUARPES S.R.L.    30681670595


        string CuitSesion = "30681670595";

        string RazonSocialSession = "HUARPES S.R.L.";


        // string RazSocial = "Nuestra empresa Argentina S.R.L";

        //TOKEN

        /// <summary>
        ///   <para>
        ///  connection string</para>
        /// </summary>
        string conection = Global.DecryptKeyBase64(WebConfigurationManager.ConnectionStrings[1].ConnectionString);



        /// <summary>  el data access</summary>
        DataAccess da = new DataAccess();

        /// <summary> log4net</summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(HomeController));


        /// <summary>requiere la url para setear el token obtenido.</summary>
        /// <param name="token">token.</param>
        /// <returns>vista index</returns>
        /// <example>
        ///   <code> public Empresa Request_Url(string token)
        ///         {
        ///
        ///             log.Info("Se ha generado el siguiente token" + token);
        ///             string url = WebConfigurationManager.AppSettings["PORTAL_API_URL"]+token;
        ///             WebRequest request = HttpWebRequest.Create(url);
        ///             try
        ///             {
        ///                 log.Info("entro al try con la url lista: " + url);
        ///                 WebResponse response = request.GetResponse();
        ///                 StreamReader reader = new StreamReader(response.GetResponseStream());
        ///                 string responseText = reader.ReadToEnd();
        ///                 JObject resultado = JObject.Parse(responseText);
        ///                 JToken success = resultado["Success"];
        ///
        ///
        ///                 log.Info(success.ToString());
        ///
        ///                 // en el caso que el token este con los datos solicitados
        ///                 if (success.ToString() == "True")
        ///                 {
        ///                     log.Info("Completo los datos");
        ///                     log.Info((string)resultado["razonsocial"]);
        ///                     log.Info((string)resultado["Cuit"]);
        ///                     return new Empresa()
        ///                     {
        ///                         Cuit = (string)resultado["CuitCuilCdi"],
        ///                         RazonSocial = (string)resultado["razonsocial"]
        ///                     };
        ///                 }</code>
        /// </example>
        public Empresa Request_Url(string token)
        {

            log.Info("Se ha generado el siguiente token" + token);
            string url = WebConfigurationManager.AppSettings["PORTAL_API_URL"]+token;
            WebRequest request = HttpWebRequest.Create(url);
            try
            {
                log.Info("entro al try con la url lista: " + url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseText = reader.ReadToEnd();
                JObject resultado = JObject.Parse(responseText);
                JToken success = resultado["Success"];

               
                log.Info(success.ToString());
               
                // en el caso que el token este con los datos solicitados
                if (success.ToString() == "True")
                {
                    log.Info("Completo los datos");
                    log.Info((string)resultado["razonsocial"]);
                    log.Info((string)resultado["Cuit"]);
                    return new Empresa()
                    {
                        Cuit = (string)resultado["CuitCuilCdi"],
                        RazonSocial = (string)resultado["razonsocial"]
                    };
                }

                //en el caso que el token vanga vacio
                else
                {
                    log.Info("success dio False");
                    // habilitar en testing en localhost
                    return new Empresa()
                    {

                        //LA MILAGROSA S.A.   30507164303
                        //HUARPES S.R.L.    30681670595

                        Cuit = "30681670595",
                        RazonSocial = "HUARPES S.R.L."
                    };
                }
            }
            catch (Exception error)
            {
               
                log.Info("ha ocurrido el siguiente error: " + error.Message);
                return new Empresa()
                {
                    //LA MILAGROSA S.A.   30507164303
                    //HUARPES S.R.L.    30681670595
                    // Cuit = "30681670595",
                    //RazonSocial = "HUARPES S.R.L."
                    Cuit = "30681670595",
                    RazonSocial = "HUARPES S.R.L."
                };
            }
           

        }



        /// <summary>inicia seion con el token especificado token.</summary>
        /// <param name="token">
        ///   <para>
        /// Recibe el token </para>
        ///   <para>Si esta lleno entonces setea la conexion comparando con la base de datos</para>
        ///   <para>sino redirecciona a httpnotfound</para>
        /// </param>
        /// <returns>vista index</returns>
        /// <example>
        ///   <code> public ActionResult Login(string token)
        ///         {
        ///             try
        ///             {
        ///                 Utilidades.SetCon(conection);
        ///             }
        ///             catch (Exception e)
        ///             {
        ///                 log.Info(e.Message);
        ///                 Global.setError(e.Message);
        ///                 throw;
        ///             }
        ///
        ///             Empresa empresa = Request_Url(token);
        ///
        ///             log.Info("los datos de la empresa son los siguientes: Cuit: " + empresa.Cuit + "Razon Social: " + empresa.RazonSocial);
        ///             if(empresa.Cuit != null)
        ///             {
        ///                 Global.setSession(empresa.Cuit,empresa.RazonSocial);
        ///
        ///                 if (Global.getSession() != "" || Global.getSession() != null)
        ///                 {
        ///                     Global.SetEmpresa(da.GetLocalEmpresa(Global.getSession()));
        ///
        ///                     if (Global.GetEmpresa().Cuit == "" || Global.GetEmpresa().Cuit == null)
        ///                     {
        ///                         Global.SetEmpresa(da.AddEmpresa());
        ///                     }
        ///
        ///                     if (Global.GetEmpresa() == null)
        ///                     {
        ///                         return View("Index");
        ///                     }
        ///                 }
        ///                 return View("Index");
        ///             }
        ///             else
        ///             {
        ///                 log.Info("El usuario no se ha podido logear");
        ///                 return HttpNotFound();
        ///             }
        ///
        ///         }</code>
        /// </example>
        public ActionResult Login(string token)
        {
            try
            {
                Utilidades.SetCon(conection);
            }
            catch (Exception e)
            {
                log.Info(e.Message);
                Global.setError(e.Message);
                throw;
            }

            Empresa empresa = Request_Url(token);
            log.Info("los datos de la empresa son los siguientes: Cuit: " + empresa.Cuit + "Razon Social: " + empresa.RazonSocial);
            if(empresa.Cuit != null)
            {
                Global.setSession(empresa.Cuit,empresa.RazonSocial);

                if (Global.getSession() != "" || Global.getSession() != null)
                {
                    Global.SetEmpresa(da.GetLocalEmpresa(Global.getSession()));


                    Global.SetEmpresa(da.AddEmpresa());

                    if (Global.GetEmpresa() == null)
                    {
                        return View("Index");
                    }
                }
                return View("Index");
            }
            else
            {
                log.Info("El usuario no se ha podido logear");
                return HttpNotFound();
            }
           
        }



        /// <summary>
        ///   <para>en index setea el tipo de acreditacion global en vacio </para>
        ///   <para>y la fecha en vacio.</para>
        ///   <para>si no se ha iniciado sesion pasa a login sin parametros para redirigir fuera de la pagina</para>
        /// </summary>
        /// <returns>vista index</returns>
        /// <example>
        ///   <code>public ActionResult Index()
        ///         {         
        ///             Global.SetGlobalAcreditacion("");
        ///             Global.setFecha("");
        ///             //En el caso que la variable de sesion este vacia redirige a la funcion de login()
        ///             if(Global.getSession() == null)
        ///             {
        ///                 Login("");
        ///             }
        ///             return View();
        ///         }</code>
        /// </example>
        public ActionResult Index()
        {         
            Global.SetGlobalAcreditacion("");
            Global.setFecha("");
            //En el caso que la variable de sesion este vacia redirige a la funcion de login()
            if(Global.getSession() == null)
            {
                Login("");
            }
            return View();
        }


        //[HttpPost]
        //public ActionResult Add(Empresa e)
        //{
        //    var emp = da.AddEmpresa(Global.getSession(), e);
        //    //emp = da.GetLocalEmpresa(emp.RazonSocial);
        //    da.EditEmpresa(e);
        //    return RedirectToAction("Index");
        //}


        //No se esta usando//    
        /// <summary>Guardars the edit. no usado</summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GuardarEdit(Empresa e)
        {
            da.EditEmpresa(e);
            
            return RedirectToAction("Edit","Home",e);
        }

        //No se esta usando//
        /// <summary>Edits the specified e.
        /// edit empresa no usado</summary>
        /// <param name="e">The e.</param>
        /// <param name="TipoAcred">The tipo acred.</param>
        /// <returns></returns>
        public ActionResult Edit(Empresa e,string TipoAcred)
        {

            if (Global.GetGlobalAcreditacion() == "" || Global.GetGlobalAcreditacion() == null)
            {
                Global.SetGlobalAcreditacion(TipoAcred);
            }
            else
            {
                if (Global.GetGlobalAcreditacion() != TipoAcred && TipoAcred != "")
                {
                    Global.SetGlobalAcreditacion(TipoAcred);
                }
            }
            Global.SetEmpresa(da.GetLocalEmpresa(e.CodEmp));

            return View(Global.GetEmpresa());
        }
        //No se esta usando//
        /// <summary>
        ///   <para>
        ///  Deletes the specified e.
        /// empresa no usado</para>
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns></returns>
        public ActionResult Delete(Empresa e)
        {
            e = da.GetLocalEmpresa(e.CodEmp);
            da.DeleteEmpresa(e);
            return RedirectToAction("Index");
        }



        /// <summary>realiza el cierre de sesion. limpia todas las variables globales de sesion de la empresa</summary>
        /// <example>
        ///   <code> public void Logout()
        ///         {
        ///             log.Info("Se ha terminado la sesion correctamente");
        ///             Global.setSession("", "");
        ///             Response.Redirect("https://www.bancosanjuan.com/EnModoOn/");
        ///             Response.End();
        ///         }</code>
        /// </example>
        public void Logout()
        {
            log.Info("Se ha terminado la sesion correctamente");
            Global.setSession("", "");
            Response.Redirect(WebConfigurationManager.AppSettings["logout"]);
            Response.End();
        }



        /// <summary>vista para seleccionar el convenio . potr defecto el preview eta en null y la carga masiva en false</summary>
        /// <returns>vista seleccionar convenio</returns>
        /// <example>
        ///   <code>  public ActionResult SeleccionarConvenioView()
        ///         {
        ///             Global.setPreview(null);
        ///             da.AceptCM(false);
        ///             return View();
        ///         }</code>
        /// </example>
        public ActionResult SeleccionarConvenioView()
        {
            Global.setPreview(null);
            da.AceptCM(false);
            return View();
        }


        /// <summary>redirecciona a vista serviciodatos</summary>
        /// <returns>vista servicio datos</returns>
        /// <example>
        ///   <code> public ActionResult ServicioDatos()
        ///         {
        ///             return View();
        ///         }</code>
        /// </example>
        public ActionResult ServicioDatos()
        {
            return View();
        }

    }
}