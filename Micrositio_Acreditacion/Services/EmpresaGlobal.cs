using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Micrositio_Acreditacion.Models;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Web.Configuration;
namespace Micrositio_Acreditacion.Services
{
    /// <summary>
    ///   <para>Variables globales</para>
    /// </summary>
    public static class Global
    {
        static Empresa empresa;

        /// <summary>
        ///   <para>
        ///  lista sucursales global</para>
        /// </summary>
        static List<Sucursales> sucursales;
        /// <summary>  el tipo acreditacion global</summary>
        static List<TipoAcreditacion> acredi;
        /// <summary>  el tipo de cuenta global</summary>
        static List<TipoCuenta> cuenta;

        static string TipoAcreditacion ="";
        static string Session;

        static string error = "";

        static string fechaAcreditacion = "";

        static string razonSocial = "";

        static bool Cargamasiva;

        static Preview preview = null;

        //no se usa
        /// <summary>
        ///   <para>
        /// Gets the image.
        /// </para>
        /// </summary>
        /// <returns>image</returns>
        /// 

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Global));

        public static string getImage()
        {
            string image = WebConfigurationManager.AppSettings["image"];

            return image;
        }

        /// <summary>Sets el preview.</summary>
        /// <param name="p">The p.</param>
        public static void setPreview(Preview p)
        {
            preview = p;
        }

        /// <summary>Gets el preview.</summary>
        /// <returns>preview</returns>
        public static Preview getPreview()
        {
            return preview;
        }

        /// <summary>Sets la carga.</summary>
        /// <param name="masiva">if set to <c>true</c> [masiva] else [update].</param>
        public static void setCarga(bool masiva)
        {
            Cargamasiva = masiva;
        }

        /// <summary>Gets la carga.</summary>
        /// <returns>Cargamassiva</returns>
        public static bool GetCarga()
        {
            return Cargamasiva;
        }

        /// <summary>Sets la fecha.</summary>
        /// <param name="fecha"> fecha.</param>
        public static void setFecha(string fecha)
        {
            fechaAcreditacion = fecha;
        }

        /// <summary>Gets la fecha.</summary>
        /// <returns>fechaAcreditacion</returns>
        public static string getFecha()
        {
            return fechaAcreditacion;
        }

        /// <summary>Formatea la fecha</summary>
        /// <returns>fechaAcreditacion</returns>
        public static string FechaForm()
        {
            if(fechaAcreditacion != null && fechaAcreditacion != "")
            {
                DateTime d = DateTime.ParseExact(fechaAcreditacion, "ddMMyy", CultureInfo.InvariantCulture);
                string f = d.ToString("yyyy-MM-dd");
                return f;
            }
            else
            {
                return fechaAcreditacion;
            }
          
        }

        /// <summary>Sets la session cuit y razon social .</summary>
        /// <param name="s">s.</param>
        /// <param name="rs">rs.</param>
        public static void setSession(string s, string rs)
        {
            Session = s;
            razonSocial = rs;
        }

        /// <summary>Gets la session cuit.</summary>
        /// <returns>Session</returns>
        public static string getSession()
        {
            return Session;
        }

        /// <summary>Gets la session razon social.</summary>
        /// <returns>razonSocial</returns>
        public static string getRSSession()
        {
            return razonSocial;
        }

        /// <summary>Sets el mensaje de error error.</summary>
        /// <param name="msg"> msg.</param>
        public static void setError(string msg)
        {
            if(msg != null)
            {
                error = msg;
            }
            
        }

        /// <summary>Gets el menaje de error.</summary>
        /// <returns>error</returns>
        public static string getError()
        {
            return error;
        }
        /// <summary>Sets la variable  global tipo acreditacion.</summary>
        /// <param name="a">a.</param>
        public static void SetGlobalAcreditacion(string a)
        {
            TipoAcreditacion = a;
        }

        /// <summary>Gets la variable global tipo acreditacion.</summary>
        /// <returns>TipoAcreditacion</returns>
        public static string GetGlobalAcreditacion()
        {
            return TipoAcreditacion;
        }

        /// <summary>Sets la empresa.</summary>
        /// <param name="e"> e.</param>
        public static void SetEmpresa(Empresa e)
        {
            empresa = e;
        }

        /// <summary>Gets la empresa.</summary>
        /// <returns>empresa</returns>
        public static Empresa GetEmpresa()
        {
            return empresa;
        }

        /// <summary>Sets la sucursal.</summary>
        /// <param name="s">s.</param>
        public static void SetSucursal(List<Sucursales> s)
        {
            sucursales = s;
        }

        /// <summary>Gets la sucursal.</summary>
        /// <returns>sucursales</returns>
        public static List<Sucursales>  GetSucursal()
        {
            return sucursales;
        }

        /// <summary>Sets el tipo acreditacion.</summary>
        /// <param name="t">t</param>
        public static void setAcreditacion(List<TipoAcreditacion> t)
        {
            acredi = t;
        }

        /// <summary>Gets el tipo  acreditacion.</summary>
        /// <returns>acredi</returns>
        public static List<TipoAcreditacion> GetAcreditacion()
        {
            return acredi;
        }

        /// <summary>Sets la cuenta.</summary>
        /// <param name="c"> c</param>
        public static void setCuenta(List<TipoCuenta> c)
        {
            cuenta = c;
        }

        /// <summary>Gets la cuenta.</summary>
        /// <returns>cuenta//tipo de cuenta</returns>
        public static List<TipoCuenta> GetCuenta()
        {
            return cuenta;
        }

        /// <summary>Deletes all files. para excel</summary>
        public static void DeleteAllFiles()
        {
            //System.IO.DirectoryInfo di = new DirectoryInfo(@"c:\app\");

            //foreach (FileInfo file in di.GetFiles())
            //{
            //    if (file.Exists)
            //    {
            //        file.Refresh();
            //        file.Delete();
            //    }

            //}
            //foreach (DirectoryInfo dir in di.GetDirectories())
            //{
            //    if (dir.Exists)
            //    {
            //        dir.Delete(true);
            //    }

            //}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public static string DecryptKeyBase64(string clave)
        {

            string Password = clave.Substring(clave.IndexOf("Password=")+9);
            Password = Password.Substring(0, Password.IndexOf(";"));

            try
            {
                string result;
                if (Password != null)
                {
                    var encoder = new System.Text.UTF8Encoding();
                    var utf8Decode = encoder.GetDecoder();

                    byte[] cadenaByte = Convert.FromBase64String(Password);
                    int charCount = utf8Decode.GetCharCount(cadenaByte, 0, cadenaByte.Length);
                    char[] decodedChar = new char[charCount];
                    utf8Decode.GetChars(cadenaByte, 0, cadenaByte.Length, decodedChar, 0);
                    result = new String(decodedChar);
                }
                else
                {
                    result = "";
                }

              clave = clave.Replace(Password,result);
                return clave;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return "";

        }

    }
}