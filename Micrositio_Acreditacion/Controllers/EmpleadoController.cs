using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Micrositio_Acreditacion.Services;
using Micrositio_Acreditacion.Models;
using System.IO;
using System.Data;
using ConnDB;
using System.Web.Services.Description;
using PagedList;
using PagedList.Mvc;
namespace Micrositio_Acreditacion.Controllers
{
    /// <summary>
    ///   <para>Controlador Empleado</para>
    /// </summary>
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        /// <summary>
        ///   <para>
        /// declaracion instancia de DataAccess</para>
        /// </summary>
        DataAccess da = new DataAccess();

        /// <summary>
        ///   <para>
        ///  Declaracion Instancia de log4net </para>
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmpleadoController));



        /// <summary>Sets the acreditacion.</summary>
        /// <param name="acreditacion">acreditacion.</param>
        /// <example>
        ///   <code>  public void SetAcreditacion(string acreditacion)
        ///         {
        ///             if (acreditacion == null)
        ///             {
        ///                 acreditacion = "";
        ///             }
        ///             if (Global.GetGlobalAcreditacion() == "" or Global.GetGlobalAcreditacion() == null)
        ///             {
        ///                 if (acreditacion != "" or acreditacion != null)
        ///                 {
        ///                     Global.SetGlobalAcreditacion(acreditacion);
        ///                 }
        ///             }
        ///             else
        ///             {
        ///                 if (Global.GetGlobalAcreditacion() != acreditacion and acreditacion != "")
        ///                 {
        ///                     Global.SetGlobalAcreditacion(acreditacion);
        ///                 }
        ///             }
        ///         }</code>
        /// </example>
        public void SetAcreditacion(string acreditacion)
        {
            if (acreditacion == null)
            {
                acreditacion = "";
            }
            if (Global.GetGlobalAcreditacion() == "" || Global.GetGlobalAcreditacion() == null)
            {
                if (acreditacion != "" || acreditacion != null)
                {
                    Global.SetGlobalAcreditacion(acreditacion);
                }

            }
            else
            {
                if (Global.GetGlobalAcreditacion() != acreditacion && acreditacion != "")
                {
                    Global.SetGlobalAcreditacion(acreditacion);
                }
            }
        }

        /// <summary>
        ///   <para>
        /// Index devuelve vista principal.
        /// Ademas:</para>
        ///   <para>- setea Global acreditacion en vacio("")</para>
        ///   <para>-setea Global fecha en vacio("")</para>
        /// </summary>
        /// <returns>view Index</returns>
        /// <example>
        ///   <code>  public ActionResult Index()
        ///         {
        ///             Global.SetGlobalAcreditacion("");
        ///             Global.setFecha("");
        ///             return View();
        ///         }</code>
        /// </example>
        public ActionResult Index()
        {
            try
            {
                Global.SetGlobalAcreditacion("");
                Global.setFecha("");
                return View();
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
           
        }



        /// <summary>Cargar el empleados gral.</summary>
        /// <param name="acreditacion">The acreditacion.</param>
        /// <returns>view Indez y lista de empleados(true si es general)</returns>
        /// <example>
        ///   <code>public ActionResult CargarEmpleadosGral(string acreditacion)
        ///       {
        ///           SetAcreditacion(acreditacion);
        ///           return View(da.ListEmpleado(true).ToList());
        ///       }</code>
        /// </example>
        public ActionResult CargarEmpleadosGral(string acreditacion,string order)
        {
            SetAcreditacion(acreditacion);
            if (order == null)
            {
                return View(da.ListEmpleado(true, 0).ToList());
            }
            else
            {
                return View(da.ListEmpleado(true,Convert.ToInt32(order)).ToList());
            }
            
        }

        public ActionResult ResultadoSolicitudes()
        {
            //retorna vista
           
                
                return View(da.GetListado());
        }


        /// <summary>Setea la fecha en global y redirecciona segun se seleccione para que metodo se utilizara</summary>
        /// <param name="d">d (date)</param>
        /// <returns>redirecciona a cargaIndividual o CargaMaiva de acuerdo a la condicion</returns>
        /// <example>
        ///   <code>[HttpPost]
        ///   public ActionResult fechaEdit(DateTime d)
        ///   {
        ///
        ///       string fecha = d.ToString("ddMMyy").Trim();
        ///
        ///       Global.setFecha(fecha);
        ///
        ///       if(Global.GetCarga())
        ///       {
        ///           return RedirectToAction("CargaMasiva");
        ///       }
        ///       else
        ///       {
        ///           return RedirectToAction("CargaIndividual");
        ///       }
        ///
        ///   }</code>
        /// </example>
        [HttpPost]
        public ActionResult fechaEdit(DateTime d)
        {

            string fecha = d.ToString("ddMMyy").Trim();

            Global.setFecha(fecha);

            if(Global.GetCarga())
            {
                return RedirectToAction("CargaMasiva");
            }
            else
            {
                return RedirectToAction("CargaIndividual");
            }
            
        }



        /// <summary>Realiza el reporte de los datos de la empresa obtenida con el token</summary>
        /// <param name="TipoAcre">TipoAcre</param>
        /// <param name="emp">emp</param>
        /// <returns>
        ///   <para>vista</para>
        /// </returns>
        /// <example>
        ///   <code>Report</code>
        /// </example>
        public ActionResult Report(string TipoAcre, Empresa emp)
        {
            if (Global.GetGlobalAcreditacion() == "" || Global.GetGlobalAcreditacion() == null)
            {
                Global.SetGlobalAcreditacion(TipoAcre);
            }
            else
            {
                if (Global.GetGlobalAcreditacion() != TipoAcre && TipoAcre != "" && TipoAcre != null)
                {
                    Global.SetGlobalAcreditacion(TipoAcre);
                }
            }

            if (Global.GetEmpresa() == null)
            {
                if (emp.CodEmp != "" || emp.CodEmp != null)
                {
                    Global.SetEmpresa(da.GetLocalEmpresa(emp.CodEmp));
                }
            }
            else
            {
                if (emp.CodEmp != null && emp != null && emp.CodEmp != "")
                {
                    if (Global.GetEmpresa().CodEmp != emp.CodEmp)
                    {
                        Global.SetEmpresa(da.GetLocalEmpresa(emp.CodEmp));
                    }
                }
            }
            return View(da.ListEmpleadoReporte().ToList());
        }





        /// <summary>Genera un nuevo empleado</summary>
        /// <param name="e">e</param>
        /// <returns>vista empleadoGral + lista empleados</returns>
        /// <example>
        ///   <code>[HttpPost]
        ///        public ActionResult New(Empleado e)
        ///        {
        ///            e = da.AddNewEmpleado(e);
        ///            return View("CargarEmpleadosGral", da.ListEmpleado(true).ToList());
        ///        }</code>
        /// </example>
        [HttpPost]
        public ActionResult New(Empleado e)
        {
            
            e = da.AddNewEmpleado(e);
            return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
        }



        // validar cbu 
        
//        int[] VEC2 = new int[] { 3, 9, 7, 1, 3, 9, 7, 1, 3, 9, 7, 1, 3 };

//        bool valido = false;

//        int bloque1 = cbu.Substring(0, 7);

//        int digitoValidador = cbu.Substring(0, 7);

//        int bloque2 = cbu.Substring(8, 21);

//        int digitoValidador2 = cbu.Substring(21);

//        int acum = 0;


//         for (i = 0; i< 7; i++) {

//        acum += bloque1.Substring(i, i + 1) * VEC1[i];

//        }
//    string strAcum = (System.Convert.ToString((acum) + (''));

//    int digitoVCalculado1 = 10 - Convert.ToInt32(strAcum.length - 1);

//    valido = (digitoVCalculado1 == digitoValidador1);

//    acum = 0;

//    for (i = 0; i< 13; i++) {

//    acum += bloque2.substring(i, i + 1) * VEC2[i];
   
//}

//strAcum =  (System.Convert.ToString((acum) + (''));

//int digitoVCalculado2 = 10 - Convert.ToInt32(strAcum.length - 1);

//valido = (digitoVCalculado2 == digitoValidador2) && valido;

//  return valido;


//-----------------------------------------------------------------
//No se usa
//[HttpPost]
//public ActionResult Filter(string selector)
//{
//    switch (selector)
//    {
//        case "0":
//            return View("Index", da.ListEmpleadoFilterSuc(selector, Request.Form["sucursal"]));

//        case "1":
//            return View("Index", da.ListEmpleadoFilterSuc(selector, Request.Form["acreditacion"]));

//        case "2":
//            return View("Index", da.ListEmpleadoFilterSuc(selector, Request.Form["cuenta"]));

//        default:
//            return View("Index", da.ListEmpleadoFilterSuc(selector, Request.Form["sucursal"]));

//    }

//}



/// <summary>Edita el empleado</summary>
/// <param name="e">e</param>
/// <returns>view index con lista empleado</returns>
/// <example>
///   <code>  [HttpPost]
///         public ActionResult EditFunction(Empleado e)
///         {
///             da.EditEmpleado1to1(e);
///
///             if(e.Importe != null)
///             {
///                 if(Global.GetCarga())
///                 {
///                     return RedirectToAction("CargaMasivaResultado");
///                 }
///                 else
///                 {
///                     return RedirectToAction("CargaIndividual");
///                 }
///
///             }
///             else
///             {
///                 return View("CargarEmpleadosGral", da.ListEmpleado(true).ToList());
///             }
///
///             
///         }</code>
/// </example>
[HttpPost]
        public ActionResult EditFunction(Empleado e)
        {
            da.EditEmpleado1to1(e);

            if(e.Importe != null)
            {
                if(Global.GetCarga())
                {
                    return RedirectToAction("CargaMasivaResultado");
                }
                else
                {
                    return RedirectToAction("CargaIndividual");
                }
                
            }
            else
            {
                return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
            }
            
            //return RedirectToAction("Index", new { TipoAcred = Global.GetGlobalAcreditacion(), emp = Global.GetEmpresa() });
        }


        /// <summary>redirige a edit function</summary>
        /// <param name="e">e</param>
        /// <returns>vista editFunction</returns>
        /// <example>
        ///   <code> public ActionResult Edit(Empleado e)
        ///         {
        ///             e = da.GetEmpleado(e);
        ///             return View("EditFunction", e);
        ///         }</code>
        /// </example>
        public ActionResult Edit(Empleado e)
        {
            e = da.GetEmpleado(e);
            return View("EditFunction", e);
        }


        /// <summary>borra empleado de manera individual o multiple</summary>
        /// <param name="deleteInput">deleteinput</param>
        /// <returns>view cargaEmpleadosGral y lista de empleados</returns>
        /// <example>
        ///   <code>public ActionResult Delete(string deleteInput)
        ///        {
        ///            string[] ArrayId = deleteInput.Split(',');</code>
        /// </example>
        public ActionResult Delete(string deleteInput)
        {
            string[] ArrayId = deleteInput.Split(',');
            for (int i = 0; i < ArrayId.Length; i++)
            {
                Empleado e = new Empleado();
                e.Id = Convert.ToInt32(ArrayId[i]);
                e = da.GetEmpleado(e);
                da.DeleteEmpleado(e);
            }
            return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
        }

        /// <summary>
        ///   <para>
        /// selecciona el tipo de acreditacion y si la carga es individual o masiva</para>
        ///   <para>
        ///     <font color="#333333">redirecciona a sus vistas seleccionadas</font>
        ///   </para>
        /// </summary>
        /// <param name="acreditacion">acreditacion</param>
        /// <param name="radio">radio</param>
        /// <returns>vista</returns>
        /// <example>
        ///   <code>public ActionResult Selector(string acreditacion,string radio)
        ///        {
        ///
        ///            Global.setFecha("");
        ///            SetAcreditacion(acreditacion);
        ///
        ///            if(radio.ToLower() == "manual")
        ///            {
        ///                Global.setCarga(false);
        ///                return RedirectToAction("CargaIndividual");
        ///            }
        ///            else if(radio.ToLower() == "masiva")
        ///            {
        ///                Global.setCarga(true);
        ///                return RedirectToAction("CargaMasiva");
        ///            }
        ///
        ///            return RedirectToAction("Index", "Home");
        ///        }</code>
        /// </example>
        public ActionResult Selector(string acreditacion,string radio)
        {
            
            Global.setFecha("");
            SetAcreditacion(acreditacion);

            if(radio.ToLower() == "manual")
            {
                Global.setCarga(false);
                return RedirectToAction("CargaIndividual");
            }
            else if(radio.ToLower() == "masiva")
            {
                Global.setCarga(true);
                return RedirectToAction("CargaMasiva");
            }

            return RedirectToAction("Index", "Home");
        }





        /// <summary>Carga de empleado individual</summary>
        /// <returns>vista cargaIndividual + lista</returns>
        /// <example>
        ///   <code> public ActionResult CargaIndividual()
        ///         {
        ///             if(Global.getFecha() != "" and Global.getFecha() != null)
        ///             {
        ///                 da.AddEmpleadosAcreditacion();
        ///             }
        ///             return View(da.ListEmpleado(false).ToList());
        ///         }</code>
        /// </example>
        public ActionResult CargaIndividual()
        {
            if(Global.getFecha() != "" && Global.getFecha() != null)
            {
                da.AddEmpleadosAcreditacion();
            }
            return View(da.ListEmpleado(false,0).ToList());
        }



        /// <summary>Vista y seteo de carga masiva</summary>
        /// <returns>vista cargaMasiva</returns>
        /// <example>
        ///   <code>
        ///     public ActionResult CargaMasiva()
        ///         {
        ///             if (Global.getFecha() != "" and Global.getFecha() != null)
        ///             {
        ///                 da.AddEmpleadosAcreditacion();
        ///                 UpdateMasivo();
        ///             }
        ///             return View();
        ///         }
        ///
        /// </code>
        /// </example>
        public ActionResult CargaMasiva()
        {
            if (Global.getFecha() != "" && Global.getFecha() != null)
            {
                da.AddEmpleadosAcreditacion();
                UpdateMasivo();
            }
            return View();
        }



        /// <summary>acepta el archivo excel para ser visto en una grilla</summary>
        /// <returns>redirige a CargaMasivaResultado</returns>
        /// <example>
        ///   <code>public ActionResult AceptCargaMasiva()
        ///         {
        ///             Global.setPreview(null);
        ///             da.AceptCM(true);
        ///             return RedirectToAction("CargaMasivaResultado");
        ///         }</code>
        /// </example>
        public ActionResult AceptCargaMasiva()
        {
            try
            {
                Global.setPreview(null);
                da.AceptCM(true);
                return RedirectToAction("CargaMasivaResultado");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return RedirectToAction("CargaMasiva");
                throw;
            }
           
        }




        /// <summary>Cancela la carga masiva si hay problemas  con el archivo excel</summary>
        /// <returns>redirige a cargaMasiva</returns>
        /// <example>
        ///   <code>
        ///      public ActionResult CancelCargaMasiva()
        ///         {
        ///             Global.setPreview(null);
        ///             da.AceptCM(false);
        ///             return RedirectToAction("CargaMasiva");
        ///         }
        /// </code>
        /// </example>
        public ActionResult CancelCargaMasiva()
        {
            Global.setPreview(null);
            da.AceptCM(false);
            return RedirectToAction("CargaMasiva");
        }


        /// <summary>lista y muestra la carga masiva despues de procesar el excel</summary>
        /// <returns>vista CargamasivaResultado</returns>
        /// <example>
        ///   <code>    public ActionResult CargaMasivaResultado()
        ///         {
        ///             return View(da.ListEmpleado(false).ToList());
        ///         }
        /// </code>
        /// </example>
        public ActionResult CargaMasivaResultado()
        {
            return View(da.ListEmpleado(false,0).ToList());
        }



        /// <summary>resumen de los datos de la empresa tomada por el token</summary>
        /// <returns>vista resumen</returns>
        /// <example>
        ///   <code>  public ActionResult Resumen()
        ///         {
        ///             Global.setPreview(da.GetShortPreview());
        ///             return View();
        ///         }</code>
        /// </example>
        public ActionResult Resumen()
        {
            Global.setPreview(da.GetShortPreview());
            return View();
        }


        /// <summary>sselecciona los ingresados rechazados y aceptados</summary>
        /// <param name="a">a</param>
        /// <example>
        ///   <code>public void prueba(int a)
        ///      {
        ///          da.GenerarReportePreview(a);
        ///      }</code>
        /// </example>
        public void prueba(int a)
        {
            da.GenerarReportePreview(a);
        }



        /// <summary>carga el empleado de manera masiva ssegun el archivo excel</summary>
        /// <returns>vista</returns>
        /// <example>cargaMasiva
        /// <code>CargaMasivabackup</code></example>
        [HttpPost]
        public ActionResult CargaMasivabackup()
        {
            Global.DeleteAllFiles();
            string RutaArchivo = "";
            string Extencion = "";
            try
            {
                if (Request.Files["excel"] != null)
                {
                    Extencion = Path.GetExtension(Request.Files["excel"].FileName);
                    Extencion = Extencion.ToLower();
                }

                if (Extencion != ".xls" && Extencion != ".xlsx")
                {
                    return View("CargarEmpleadosGral", da.ListEmpleado(true,0).ToList());
                }

                string saveDir = Server.MapPath("~/uploads/");

                if(!System.IO.Directory.Exists(saveDir))
                {
                    System.IO.Directory.CreateDirectory(saveDir);
                }

                //string appPath = Request.PhysicalApplicationPath;
                RutaArchivo = saveDir + Server.HtmlEncode(Request.Files["excel"].FileName);//saveDir + Server.HtmlEncode(Request.Files["excel"].FileName);

                if (System.IO.File.Exists(RutaArchivo))
                {

                    System.IO.File.Delete(RutaArchivo);
                }

                try
                {
                    Request.Files["excel"].SaveAs(RutaArchivo);
                }
                catch (Exception e)
                {
                    Global.setError(e.Message);
                    throw;
                }
               

                Excel excel = new Excel();
                using (DataSet ldsExcel = Excel.GetDataTableExcel(RutaArchivo, Extencion))
                    {
                    if (!ldsExcel.Tables[0].Columns.Contains("NOMBRE"))
                    {
                        return View("CargarEmpleadosGral", da.ListEmpleado(true,0).ToList());
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("DNI"))
                    {
                        return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("CUIL"))
                    {
                        return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("SUCURSAL"))
                    {
                        return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("CUENTA"))
                    {
                        return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("TIPOCUENTA"))
                    {
                        return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("TIPOACREDITACION"))
                    {
                        return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                    }

                    List<string> ColQuitar = new List<string>();
                    for (int i = 0; i < ldsExcel.Tables[0].Columns.Count; i++)
                    {
                        string colname = ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper();
                        if (ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "NOMBRE" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "DNI" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "CUIL" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "SUCURSAL" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "CUENTA" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "TIPOCUENTA" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "TIPOACREDITACION")
                        {
                            //ldsExcel.Tables[0].Columns.RemoveAt(i);
                            ColQuitar.Add(ldsExcel.Tables[0].Columns[i].ColumnName);
                        }
                    }
                    //Si hay columnas a remover
                    if (ColQuitar.ToArray().Count() > 0)
                    {
                        foreach (string colu in ColQuitar.ToArray())
                        {
                            ldsExcel.Tables[0].Columns.Remove(colu);
                        }
                    }

                    try
                    {
                        excel.InsertarDatosExcel(ldsExcel, "Micrositio_Haberes" + Global.getSession() + Global.GetEmpresa().CodEmp + Global.GetGlobalAcreditacion());
                    }
                    catch (Exception e)
                    {
                        Global.setError(e.Message);
                        return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                        throw;
                    }
                    

                }
                string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}'", 1, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion());
                try
                {
                    Utilidades.Exec(CMD);
                    return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                }
                catch (Exception e)
                {
                    Global.setError(e.Message);
                    //return View("Error");
                    return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                    throw;
                }


            }
            catch (Exception e)
            {
                
                Global.setError(e.Message);
                return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                throw;
            }

        }




        /// <summary>realiza un update masivo de los empleados</summary>
        /// <returns>vista</returns>
        /// <example>
        ///   <code>UpdateMasivo</code>
        /// </example>
        [HttpPost]
        public ActionResult UpdateMasivo()
        {
            Global.DeleteAllFiles();
            string RutaArchivo = "";
            string Extencion = "";
            try
            {
                if (Request.Files["excel"] != null)
                {
                    Extencion = Path.GetExtension(Request.Files["excel"].FileName);
                    Extencion = Extencion.ToLower();
                }

                if (Extencion != ".xls" && Extencion != ".xlsx")
                {
                    return View("CargarEmpleadosGral", da.ListEmpleado(true, 0).ToList());
                }

                string saveDir = Server.MapPath("~/uploads/");
                if (!System.IO.Directory.Exists(saveDir))
                {
                    System.IO.Directory.CreateDirectory(saveDir);
                }


                string rutaDelArchivoAsubir = Server.HtmlEncode(Request.Files["excel"].FileName);

                string NombreArchivo = Path.GetFileName(rutaDelArchivoAsubir);
                //string appPath = Request.PhysicalApplicationPath;
                RutaArchivo = saveDir + NombreArchivo;//saveDir + Server.HtmlEncode(Request.Files["excel"].FileName);

                if (System.IO.File.Exists(RutaArchivo))
                {

                    System.IO.File.Delete(RutaArchivo);
                }

                Request.Files["excel"].SaveAs(RutaArchivo);
                Excel excel = new Excel();
                using (DataSet ldsExcel = Excel.GetDataTableExcel(RutaArchivo, Extencion))
                {
                    if (!ldsExcel.Tables[0].Columns.Contains("FECHA"))
                    {
                        return RedirectToAction("CargaMasiva");
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("DNI"))
                    {
                        return RedirectToAction("CargaMasiva");
                    }
                    if (!ldsExcel.Tables[0].Columns.Contains("IMPORTE"))
                    {
                        return RedirectToAction("CargaMasiva");
                    }

                    List<string> ColQuitar = new List<string>();
                    for (int i = 0; i < ldsExcel.Tables[0].Columns.Count; i++)
                    {
                        string colname = ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper();
                        if (ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "FECHA" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "DNI" &&
                            ldsExcel.Tables[0].Columns[i].ColumnName.ToUpper() != "IMPORTE")
                        {
                            //ldsExcel.Tables[0].Columns.RemoveAt(i);
                            ColQuitar.Add(ldsExcel.Tables[0].Columns[i].ColumnName);
                        }
                    }
                    //Si hay columnas a remover
                    if (ColQuitar.ToArray().Count() > 0)
                    {
                        foreach (string colu in ColQuitar.ToArray())
                        {
                            ldsExcel.Tables[0].Columns.Remove(colu);
                        }
                    }

                    excel.InsertarDatosExcel(ldsExcel, "Micrositio_Haberes" + "UPDATE" + Global.getSession() + Global.GetEmpresa().CodEmp + Global.GetGlobalAcreditacion());

                }
                string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}', '{4}'", 2, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(),Global.getFecha());
                try
                {
                    DataSet d = Utilidades.Exec(CMD);

                    Global.setPreview(da.GetPreview(d));

                    return RedirectToAction("CargaMasiva");
                }
                catch (Exception e)
                {
                    Global.setError(e.Message);
                    log.Error(e.Message);
                    return RedirectToAction("CargaMasiva");
                    throw;
                }
            }
            catch (Exception e)
            {
                Global.setError(e.Message);
                log.Error(e.Message);
                return RedirectToAction("CargaMasiva");
                throw;
            }
            
        }

        /// <summary>Genera el txt</summary>
        /// <example>
        ///   <code> public void GenerarTxt()
        ///         {
        ///             da.GenerarTxt(); 
        ///         }</code>
        /// </example>
        public void GenerarTxt()
        {
            da.GenerarTxt();
         
        }



        /// <summary>genera el analisis mensual del reporte segun el tipo de acreditacion</summary>
        /// <param name="acreditacion">acreditacion</param>
        /// <param name="i">i</param>
        /// <returns>vista</returns>
        /// <example>
        ///   <code>public ActionResult AnalisisReporte(string acreditacion, int? i)
        ///        {
        ///            SetAcreditacion(acreditacion);
        ///            return View(da.GetReporte("").ToList().ToPagedList(i ?? 1,6));
        ///        }</code>
        /// </example>
        public ActionResult AnalisisReporte(string acreditacion, int? i)
        {
            SetAcreditacion(acreditacion);
            return View(da.GetReporte("").ToList().ToPagedList(i ?? 1,6));
        }


        /// <summary>genera el reporte mensual en excel</summary>
        /// <param name="fecha">fecha</param>
        /// <returns>vista analisisReporte</returns>
        /// <example>
        ///   <code>[HttpPost]
        ///        public ActionResult GenerarReporte(string fecha)
        ///        {
        ///
        ///            da.GetReporte(fecha);
        ///            return RedirectToAction("AnalisisReporte");
        ///        }</code>
        /// </example>
        [HttpPost]
        public ActionResult GenerarReporte(string fecha)
        {

            da.GetReporte(fecha);
            return RedirectToAction("AnalisisReporte");
        }


        /// <summary>
        /// Manuals the PDF.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public FilePathResult manualPDF(string fileName)
        {
            return new FilePathResult(string.Format(@"~\Files\{0}", fileName + ".pdf"), "application/pdf");
        }

        /// <summary>
        /// Archivoes the excel.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public FilePathResult archivoExcel(string fileName)
        {
            return new FilePathResult(string.Format(@"~\Files\{0}", fileName + ".xlsx"), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }


    }
}
