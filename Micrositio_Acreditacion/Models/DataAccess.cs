using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConnDB;
using System.Data;
using System.Data.SqlClient;
using Micrositio_Acreditacion.Services;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Micrositio_Acreditacion.Models
{
    /// <summary></summary>
    public class DataAccess
    {
        /// <summary>
        /// El log4net
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Micrositio_Acreditacion.Models.DataAccess));

        /// <summary>
        ///   <para>
        ///  The providersiempre null</para>
        /// </summary>
        private IFormatProvider provider;
        /// <summary>
        /// El formato de la fecha
        /// </summary>
        string Format = "ddMMyy";



        /// <summary>añade una nueva 
        /// 
        /// </summary>
        /// <returns>new empresa</returns>
        /// <example>
        ///   <code>public Empresa AddEmpresa()
        ///        {
        ///
        ///            try
        ///            {
        ///                //selector, Cuit, razon social, Domicilio, NumCuenta, Email, telefono, CuitSession, codEmpstring CMD = string.Format("exec SP_abm_empresa '{0}','{1}','{2}','{3}','{4}'", 1,Global.getSession(),Global.getRSSession().ToUpper(), Global.getSession(), "");
        ///                DataSet ds = Utilidades.Exec(CMD);
        ///
        ///                return new Empresa()
        ///                {
        ///                    Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
        ///                    Cuit = ds.Tables[0].Rows[0]["CUIT"].ToString().Trim().ToUpper(),
        ///                    RazonSocial = ds.Tables[0].Rows[0]["RaSoc"].ToString().Trim().ToUpper(),
        ///                    CodEmp = ds.Tables[0].Rows[0]["CodEmpresa"].ToString().Trim().ToUpper(),
        ///                    nConvenio = ds.Tables[0].Rows[0]["nConvenio"].ToString(),
        ///                    NumeroDeCta = ds.Tables[0].Rows[0]["NumCuenta"].ToString(),
        ///                    TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString(),
        ///                    Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString()
        ///                };
        ///
        ///            }
        ///            catch (Exception)
        ///            {
        ///                return null;
        ///                throw;
        ///            }
        ///
        ///
        ///
        ///
        ///
        ///        }</code>
        /// </example>
        public Empresa AddEmpresa()
        {

            try
            {
                //selector, Cuit, razon social, Domicilio, NumCuenta, Email, telefono, CuitSession, codEmp
                string CMD = string.Format("EXEC SP_abm_empresa '{0}','{1}','{2}','{3}','{4}'", 1,Global.getSession(),Global.getRSSession().ToUpper(), Global.getSession(), "");
                DataSet ds = Utilidades.Exec(CMD);

                return new Empresa()
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
                    Cuit = ds.Tables[0].Rows[0]["CUIT"].ToString().Trim().ToUpper(),
                    RazonSocial = ds.Tables[0].Rows[0]["RaSoc"].ToString().Trim().ToUpper(),
                    CodEmp = ds.Tables[0].Rows[0]["CodEmpresa"].ToString().Trim().ToUpper(),
                    nConvenio = ds.Tables[0].Rows[0]["nConvenio"].ToString(),
                    NumeroDeCta = ds.Tables[0].Rows[0]["NumCuenta"].ToString(),
                    TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString(),
                    Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString()
                };
    
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
           

          


        }


        /// <summary>reliza el get de empresa</summary>
        /// <param name="Cuit">cuit</param>
        /// <returns>new empresa e</returns>
        /// <example>
        ///   <code>
        ///  public Empresa GetLocalEmpresa(string Cuit)
        ///         {
        ///             try
        ///             {
        ///                 string CMD = string.Format("Select * from Empresas where CUIT = '{0}'", Cuit);
        ///                 DataSet ds = Utilidades.Exec(CMD);
        ///
        ///                 return new Empresa()
        ///                 {
        ///                     Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
        ///                     Cuit = ds.Tables[0].Rows[0]["CUIT"].ToString().Trim().ToUpper(),
        ///                     RazonSocial = ds.Tables[0].Rows[0]["RaSoc"].ToString().Trim().ToUpper(),
        ///                     CodEmp = ds.Tables[0].Rows[0]["CodEmpresa"].ToString().Trim().ToUpper(),
        ///                     nConvenio = ds.Tables[0].Rows[0]["nConvenio"].ToString(),
        ///                     NumeroDeCta = ds.Tables[0].Rows[0]["NumCuenta"].ToString(),
        ///                     TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString(),
        ///                     Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString()
        ///
        ///                 };
        ///             }
        ///             catch (Exception)
        ///             {
        ///                 return new Empresa()
        ///                 { };
        ///                 throw;
        ///             }
        ///         }</code>
        /// </example>
        public Empresa GetLocalEmpresa(string Cuit)
        {
            try
            {
                string CMD = string.Format("Select * from Empresas where CUIT = '{0}'", Cuit);
                DataSet ds = Utilidades.Exec(CMD);

                return new Empresa()
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
                    Cuit = ds.Tables[0].Rows[0]["CUIT"].ToString().Trim().ToUpper(),
                    RazonSocial = ds.Tables[0].Rows[0]["RaSoc"].ToString().Trim().ToUpper(),
                    CodEmp = ds.Tables[0].Rows[0]["CodEmpresa"].ToString().Trim().ToUpper(),
                    nConvenio = ds.Tables[0].Rows[0]["nConvenio"].ToString(),
                    NumeroDeCta = ds.Tables[0].Rows[0]["NumCuenta"].ToString(),
                    TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString(),
                    Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString()
                   
                };
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                return new Empresa()
                { };
                throw;
            }
        }

        //no utilizable


        public List<Empresa> ListEmpresa()
        {
            string CMD = string.Format("Select * from Empresas where cuitSession = '{0}'", Global.getSession());
            DataSet ds = Utilidades.Exec(CMD);
            List<Empresa> empNew = new List<Empresa>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var empresa = new Empresa()
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString().Trim()),
                    Cuit = ds.Tables[0].Rows[i]["CUIT"].ToString().Trim(),
                    RazonSocial = ds.Tables[0].Rows[i]["RaSoc"].ToString().Trim().ToUpper(),
                    Domicilio = ds.Tables[0].Rows[i]["Dom"].ToString().Trim().ToUpper(),
                    NumeroDeCta = ds.Tables[0].Rows[i]["NumCuenta"].ToString().Trim().ToUpper(),
                    Email = ds.Tables[0].Rows[i]["email"].ToString().Trim().ToUpper(),
                    Telefono = ds.Tables[0].Rows[i]["telefono"].ToString().Trim().ToUpper(),
                    CodEmp = ds.Tables[0].Rows[i]["CodEmpresa"].ToString().Trim().ToUpper()
                };
                empNew.Add(empresa);
            }
            return empNew;
        }


        //no utilizable

        public void EditEmpresa(Empresa e)
        {
            try
            {
                string CMD = string.Format("EXEC SP_abm_empresa '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", 2, e.Cuit, e.RazonSocial, e.Domicilio.ToUpper(), e.NumeroDeCta, e.Email.ToUpper(), e.Telefono, Global.getSession(), e.CodEmp);
                DataSet ds = Utilidades.Exec(CMD);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //no utilizable

        public void DeleteEmpresa(Empresa e)
        {
            try
            {
                string CMD = string.Format("EXEC SP_abm_empresa '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", 3, e.Cuit, e.RazonSocial, e.Domicilio.ToUpper(), e.NumeroDeCta, e.Email.ToUpper(), e.Telefono, Global.getSession(), e.CodEmp);
                DataSet ds = Utilidades.Exec(CMD);
            }
            catch (Exception err)
            {
                Global.setError(err.Message);
            }
        }



        /// <summary>lista las sucursales</summary>
        /// <returns>lista de sucursales</returns>
        /// <example>
        ///   <code> ListBoxSuc()
        /// </code>
        /// </example>
        public List<Sucursales> ListBoxSuc()
        {
            try
            {
                string CMD = string.Format("Select * from Sucursales order by CODIGO");

                DataSet ds = Utilidades.Exec(CMD);
                List<Sucursales> sucNew = new List<Sucursales>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    var sucursal = new Sucursales()
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString().Trim()),
                        Sucursal = ds.Tables[0].Rows[i]["CODIGO"].ToString().Trim().ToUpper(),
                        Descripcion = ds.Tables[0].Rows[i]["DESCRIPCION"].ToString().Trim().ToUpper()
                    };
                    sucNew.Add(sucursal);
                }
                return sucNew;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
            
        }


        /// <summary>lista el tipo de acreditacion</summary>
        /// <returns>lista tipo acreditacion</returns>
        /// <example>
        ///   <code>code</code>
        /// </example>
        public List<TipoAcreditacion> ListBoxAcre()
        {

            try
            {
                //ds.Tables[0].Rows.Count;
                string CMD = string.Format("Select * from TipoAcre order by Cod");

                DataSet ds = Utilidades.Exec(CMD);
                List<TipoAcreditacion> acreNew = new List<TipoAcreditacion>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var acreditacion = new TipoAcreditacion()
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString().Trim()),
                        Codigo = ds.Tables[0].Rows[i]["Cod"].ToString().Trim().ToUpper(),
                        Denominacion = ds.Tables[0].Rows[i]["Deno"].ToString().Trim().ToUpper(),
                        DenoReducida = ds.Tables[0].Rows[i]["Denored"].ToString().Trim().ToUpper(),
                    };
                    acreNew.Add(acreditacion);
                }
                return acreNew;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
           
        }




        /// <summary>lista el tipo de cuenta</summary>
        /// <returns>lista de tipo cuenta</returns>
        /// <example>coding
        /// <code></code></example>
        public List<TipoCuenta> ListBoxCuenta()
        {
            try
            { //ds.Tables[0].Rows.Count;
            string CMD = string.Format("Select * from TipoCuenta order by Id");

            DataSet ds = Utilidades.Exec(CMD);
            List<TipoCuenta> cueNew = new List<TipoCuenta>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var cuenta = new TipoCuenta()
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString().Trim()),
                    Denominacion = ds.Tables[0].Rows[i]["Deno"].ToString().Trim().ToUpper()
                };
                cueNew.Add(cuenta);
            }
            return cueNew;

            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
           
        }




        /// <summary>lista los empleados</summary>
        /// <param name="general">if set to <c>true</c> [Trae lista empleados general]<c>false</c>.  [Trae lista empleados individual o masiva]</param>
        /// <returns>lista empleados</returns>
        /// <example>coding
        /// <code></code></example>
        public List<Empleado> ListEmpleado(bool general,int order)
        {
            if(general)
            {
                string CMD = string.Format("exec SP_filer_empleados '{0}','{1}','{2}'", Global.GetEmpresa().CodEmp, order,Global.GetGlobalAcreditacion());
                DataSet ds = Utilidades.Exec(CMD);

                List<Empleado> empNew = new List<Empleado>();

                if (ds.Tables[0].Rows.Count == 0)
                {
                    log.Error("No se ha llenado la tabla");
                    return new List<Empleado>()
                    {
                    };
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    var empleado = new Empleado()
                    {
                        Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]),
                        Nombre = ds.Tables[0].Rows[i]["NombreEmp"].ToString().Trim().ToUpper(),
                        Dni = ds.Tables[0].Rows[i]["DNI"].ToString().Trim().ToUpper(),
                        Cuil = ds.Tables[0].Rows[i]["Cuil"].ToString().Trim().ToUpper(),
                        Sucursal = ds.Tables[0].Rows[i]["SucCod"].ToString().Trim().ToUpper(),
                        Cuenta = ds.Tables[0].Rows[i]["Cue"].ToString().Trim().ToUpper(),
                        Fecha = ""/*ds.Tables[0].Rows[i]["FechaAcred"].ToString().Trim().ToUpper()*/,
                        /*FechaFormat = DateTime.ParseExact(ds.Tables[0].Rows[i]["FechaAcred"].ToString().Trim(), Format, CultureInfo.InvariantCulture),*/
                        Importe = ""/*ds.Tables[0].Rows[i]["Importe"].ToString().Trim().ToUpper()*/,
                        TipoCuenta = ds.Tables[0].Rows[i]["TipoCue"].ToString().Trim().ToUpper(),
                        TipoAcreditacion = ds.Tables[0].Rows[i]["TipoAcre"].ToString().Trim().ToUpper(),
                        CodEmp = ds.Tables[0].Rows[i]["CodEmp"].ToString().Trim().ToUpper(),
                        Activo = Convert.ToBoolean(ds.Tables[0].Rows[i]["activo"].ToString()),
                        CBU = ds.Tables[0].Rows[i]["CBU"].ToString(),
                        EstadoCuenta = ds.Tables[0].Rows[i]["EstadoCuenta"].ToString()
                    };
                    empNew.Add(empleado);
                }
                return empNew;
            }
            else
            {
                string CMD = string.Format("SELECT * FROM EmpleadosAcreditacion where CodEmp = '{0}' and TipoAcre = '{1}' and Fecha = '{2}' and activo = 1 order by NombreEmp", Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(),Global.getFecha());
                DataSet ds = Utilidades.Exec(CMD);

                List<Empleado> empNew = new List<Empleado>();

                if (ds.Tables[0].Rows.Count == 0)
                {
                    log.Error("No se ha llenado la tabla");
                    return new List<Empleado>()
                    {
                    };
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        var empleado = new Empleado()
                        {
                            Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]),
                            Nombre = ds.Tables[0].Rows[i]["NombreEmp"].ToString().Trim().ToUpper(),
                            Dni = ds.Tables[0].Rows[i]["DNI"].ToString().Trim().ToUpper(),
                            Cuil = ds.Tables[0].Rows[i]["Cuil"].ToString().Trim().ToUpper(),
                            Sucursal = ds.Tables[0].Rows[i]["SucCod"].ToString().Trim().ToUpper(),
                            Cuenta = ds.Tables[0].Rows[i]["Cue"].ToString().Trim().ToUpper(),
                            Fecha = ds.Tables[0].Rows[i]["Fecha"].ToString().Trim().ToUpper(),
                            FechaFormat = DateTime.ParseExact(ds.Tables[0].Rows[i]["Fecha"].ToString().Trim(), Format, CultureInfo.InvariantCulture),
                            Importe = ds.Tables[0].Rows[i]["Importe"].ToString().Trim().ToUpper(),
                            TipoCuenta = ds.Tables[0].Rows[i]["TipoCue"].ToString().Trim().ToUpper(),
                            TipoAcreditacion = ds.Tables[0].Rows[i]["TipoAcre"].ToString().Trim().ToUpper(),
                            CodEmp = ds.Tables[0].Rows[i]["CodEmp"].ToString().Trim().ToUpper(),
                            Activo = Convert.ToBoolean(ds.Tables[0].Rows[i]["activo"].ToString()),
                            CBU = ds.Tables[0].Rows[i]["CBU"].ToString()
                        };
                        empNew.Add(empleado);
                    }
                    catch (Exception e)
                    {
                        empNew = null;
                        log.Error(e.Message);
                        throw;
                    }
                   
                }
                return empNew;
            }
           
           
        }


        /// <summary>lista el empleado para el reporte</summary>
        /// <returns>lista empleado</returns>
        /// <example>code
        /// <code></code></example>
        public List<Empleado> ListEmpleadoReporte()
        {
            string CMD = string.Format("SELECT * FROM Empleados where CodEmp = '{0}' and TipoAcre = '{1}' and FechaAcred = '{2}' order by NombreEmp", Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(),Global.getFecha());
            DataSet ds = Utilidades.Exec(CMD);

            List<Empleado> empNew = new List<Empleado>();

            if (ds.Tables[0].Rows.Count == 0)
            {
                return new List<Empleado>()
                {
                };
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                var empleado = new Empleado()
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]),
                    Nombre = ds.Tables[0].Rows[i]["NombreEmp"].ToString().Trim().ToUpper(),
                    Dni = ds.Tables[0].Rows[i]["DNI"].ToString().Trim().ToUpper(),
                    Cuil = ds.Tables[0].Rows[i]["Cuil"].ToString().Trim().ToUpper(),
                    Sucursal = ds.Tables[0].Rows[i]["SucCod"].ToString().Trim().ToUpper(),
                    Cuenta = ds.Tables[0].Rows[i]["Cue"].ToString().Trim().ToUpper(),
                    Fecha = ds.Tables[0].Rows[i]["Fecha"].ToString().Trim().ToUpper(),
                    FechaFormat = DateTime.ParseExact(ds.Tables[0].Rows[i]["Fecha"].ToString().Trim(), Format, CultureInfo.InvariantCulture),
                    Importe = ds.Tables[0].Rows[i]["Importe"].ToString().Trim().ToUpper(),
                    TipoCuenta = ds.Tables[0].Rows[i]["TipoCue"].ToString().Trim().ToUpper(),
                    TipoAcreditacion = ds.Tables[0].Rows[i]["TipoAcre"].ToString().Trim().ToUpper(),
                    CodEmp = ds.Tables[0].Rows[i]["CodEmp"].ToString().Trim().ToUpper()
                };
                empNew.Add(empleado);
            }
            return empNew;

        }


        /// <summary>alta de empleado</summary>
        /// <param name="e">e</param>
        /// <returns>new Empleado</returns>
        /// <example>
        ///   <code>public Empleado AddNewEmpleado(Empleado e)
        ///         {
        ///             if (e.Fecha == null)
        ///             {
        ///                 e.Fecha = "";
        ///             }
        ///             else
        ///             {
        ///                 //setea la fecha
        ///                 e.Fecha = e.FechaFormat.ToString("ddMMyy").Trim();
        ///             }
        ///
        ///
        ///
        ///
        ///             if(e.Importe == null)
        ///             {
        ///                 e.Importe = "";
        ///             }
        ///             // 0 NEW - 1 EDIT - 2 NEW MASIVO - 3 UPDATE MASIVO - 4 DELETEstring CMD = string.Format
        ///     ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}'",0,e.Nombre.ToUpper(),e.Dni,e.Cuil,e.Sucursal,e.Cuenta,e.Fecha, e.Importe, e.TipoCuenta,Global.GetGlobalAcreditacion(),e.CBU,true,Global.GetEmpresa().CodEmp,"");
        ///             try
        ///             {
        ///                 DataSet ds = Utilidades.Exec(CMD);
        ///                 return new Empleado()
        ///                 {
        ///                     Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
        ///                     Nombre = ds.Tables[0].Rows[0]["NombreEmp"].ToString().Trim().ToUpper(),
        ///                     Dni = ds.Tables[0].Rows[0]["DNI"].ToString().Trim().ToUpper(),
        ///                     Cuil = ds.Tables[0].Rows[0]["Cuil"].ToString().Trim().ToUpper(),
        ///                     Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString().Trim().ToUpper(),
        ///                     Cuenta = ds.Tables[0].Rows[0]["Cue"].ToString().Trim().ToUpper(),
        ///                     Fecha = ""/*ds.Tables[0].Rows[0]["Fecha"].ToString().Trim().ToUpper()*/,
        ///                     /*FechaFormat = e.FechaFormat,*/
        ///                     Importe = ""/*ds.Tables[0].Rows[0]["Importe"].ToString().Trim().ToUpper()*/,
        ///                     TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString().Trim().ToUpper(),
        ///                     TipoAcreditacion = ds.Tables[0].Rows[0]["TipoAcre"].ToString().Trim().ToUpper(),
        ///                     CodEmp = ds.Tables[0].Rows[0]["CodEmp"].ToString().Trim().ToUpper(),
        ///                     Activo = Convert.ToBoolean(ds.Tables[0].Rows[0]["activo"].ToString()),
        ///                     CBU = ds.Tables[0].Rows[0]["CBU"].ToString()
        ///                 };
        ///             }
        ///             catch (Exception)
        ///             {
        ///                 return new Empleado()
        ///                 {
        ///                 };
        ///                 throw;
        ///             }
        ///
        ///         }</code>
        /// </example>
        public Empleado AddNewEmpleado(Empleado e)
        {
            if (e.Fecha == null)
            {
                e.Fecha = "";
            }
            else
            {
                //setea la fecha
                e.Fecha = e.FechaFormat.ToString("ddMMyy").Trim();
            }
               

           

            if(e.Importe == null)
            {
                e.Importe = "";
            }
            // 0 NEW - 1 EDIT - 2 NEW MASIVO - 3 UPDATE MASIVO - 4 DELETE
            string CMD = string.Format
    ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'",0,e.Nombre.ToUpper(),e.Dni,e.Cuil,"", e.Importe,Global.GetGlobalAcreditacion(),e.CBU,true,Global.GetEmpresa().CodEmp,"");
            try
            {
                DataSet ds = Utilidades.Exec(CMD);
                return new Empleado()
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
                    Nombre = ds.Tables[0].Rows[0]["NombreEmp"].ToString().Trim().ToUpper(),
                    Dni = ds.Tables[0].Rows[0]["DNI"].ToString().Trim().ToUpper(),
                    Cuil = ds.Tables[0].Rows[0]["Cuil"].ToString().Trim().ToUpper(),
                    Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString().Trim().ToUpper(),
                    Cuenta = ds.Tables[0].Rows[0]["Cue"].ToString().Trim().ToUpper(),
                    Fecha = ""/*ds.Tables[0].Rows[0]["Fecha"].ToString().Trim().ToUpper()*/,
                    /*FechaFormat = e.FechaFormat,*/
                    Importe = ""/*ds.Tables[0].Rows[0]["Importe"].ToString().Trim().ToUpper()*/,
                    TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString().Trim().ToUpper(),
                    TipoAcreditacion = ds.Tables[0].Rows[0]["TipoAcre"].ToString().Trim().ToUpper(),
                    CodEmp = ds.Tables[0].Rows[0]["CodEmp"].ToString().Trim().ToUpper(),
                    Activo = Convert.ToBoolean(ds.Tables[0].Rows[0]["activo"].ToString()),
                    CBU = ds.Tables[0].Rows[0]["CBU"].ToString(),
                    EstadoCuenta = ds.Tables[0].Rows[0]["EstadoCuenta"].ToString()

                };
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new Empleado()
                {
                };
                throw;
            }
           
        }



        /// <summary>Hace un get a un empleado</summary>
        /// <param name="e">e</param>
        /// <returns>new empleado</returns>
        /// <example>
        ///   <code> public Empleado GetEmpleado(Empleado e)
        ///         {
        ///             if(e.Fecha != null && e.Fecha != "")
        ///             {
        ///                 e.Fecha = e.FechaFormat.ToString("ddMMyy").Trim();
        ///             }
        ///
        ///             string CMD = string.Format("Select * from Empleados where Id = '{0}' and TipoAcre = (select Cod from TipoAcre where Deno = '{1}')", e.Id, Global.GetGlobalAcreditacion());
        ///             DataSet ds = Utilidades.Exec(CMD);
        ///             return new Empleado()
        ///             {
        ///                 Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
        ///                 Nombre = ds.Tables[0].Rows[0]["NombreEmp"].ToString().Trim().ToUpper(),
        ///                 Dni = ds.Tables[0].Rows[0]["DNI"].ToString().Trim().ToUpper(),
        ///                 Cuil = ds.Tables[0].Rows[0]["Cuil"].ToString().Trim().ToUpper(),
        ///                 Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString().Trim().ToUpper(),
        ///                 Cuenta = ds.Tables[0].Rows[0]["Cue"].ToString().Trim().ToUpper(),
        ///                 Fecha = ""/*ds.Tables[0].Rows[0]["FechaAcred"].ToString().Trim().ToUpper()*/,
        ///                 //FechaFormat = DateTime.ParseExact(ds.Tables[0].Rows[0]["FechaAcred"].ToString().Trim(), Format, provider),
        ///                 Importe = ""/*ds.Tables[0].Rows[0]["Importe"].ToString().Trim().ToUpper()*/,
        ///                 TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString().Trim().ToUpper(),
        ///                 TipoAcreditacion = ds.Tables[0].Rows[0]["TipoAcre"].ToString().Trim().ToUpper(),
        ///                 CodEmp = ds.Tables[0].Rows[0]["CodEmp"].ToString().Trim().ToUpper(),
        ///                 Activo = Convert.ToBoolean(ds.Tables[0].Rows[0]["activo"].ToString()),
        ///                 CBU = ds.Tables[0].Rows[0]["CBU"].ToString()
        ///             };
        ///         }</code>
        /// </example>
        public Empleado GetEmpleado(Empleado e)
        {
            if(e.Fecha != null && e.Fecha != "")
            {
                e.Fecha = e.FechaFormat.ToString("ddMMyy").Trim();
            }
            
            string CMD = string.Format("Select * from Empleados where Id = '{0}' and TipoAcre ='{1}'", e.Id, Global.GetGlobalAcreditacion());
            try
            {
                DataSet ds = Utilidades.Exec(CMD);
                return new Empleado()
            {
                Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
                Nombre = ds.Tables[0].Rows[0]["NombreEmp"].ToString().Trim().ToUpper(),
                Dni = ds.Tables[0].Rows[0]["DNI"].ToString().Trim().ToUpper(),
                Cuil = ds.Tables[0].Rows[0]["Cuil"].ToString().Trim().ToUpper(),
                Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString().Trim().ToUpper(),
                Cuenta = ds.Tables[0].Rows[0]["Cue"].ToString().Trim().ToUpper(),
                Fecha = ""/*ds.Tables[0].Rows[0]["FechaAcred"].ToString().Trim().ToUpper()*/,
                //FechaFormat = DateTime.ParseExact(ds.Tables[0].Rows[0]["FechaAcred"].ToString().Trim(), Format, provider),
                Importe = ""/*ds.Tables[0].Rows[0]["Importe"].ToString().Trim().ToUpper()*/,
                TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString().Trim().ToUpper(),
                TipoAcreditacion = ds.Tables[0].Rows[0]["TipoAcre"].ToString().Trim().ToUpper(),
                CodEmp = ds.Tables[0].Rows[0]["CodEmp"].ToString().Trim().ToUpper(),
                Activo = Convert.ToBoolean(ds.Tables[0].Rows[0]["activo"].ToString()),
                CBU = ds.Tables[0].Rows[0]["CBU"].ToString(),
                EstadoCuenta = ds.Tables[0].Rows[0]["EstadoCuenta"].ToString()
                };
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                return null;
            }

           
        }




        /// <summary>determina si el parametro enviado  es numeric.</summary>
        /// <param name="Expression">expression.</param>
        /// <returns>
        ///   <c>true</c> si la expression es numeric; en otro caso, <c>false</c>.</returns>
        /// <example>
        ///   <code>  public bool IsNumeric(object Expression)
        ///         {
        ///
        ///             bool isNum;
        ///
        ///             double retNum;
        ///
        ///             isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        ///
        ///             return isNum;
        ///
        ///         }</code>
        /// </example>
        public bool IsNumeric(object Expression)
        {

            bool isNum;

            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            return isNum;

        }



        /// <summary>edita el empleado</summary>
        /// <param name="e">e</param>
        /// <example>
        /// <code>coding</code></example>
        public void EditEmpleado1to1(Empleado e)
        {
            DataAccess ds1 = new DataAccess();
            Global.SetSucursal(ds1.ListBoxSuc());
            var sucursal = Global.GetSucursal();


            

            string CMD;
            try
            {
                if (e.Nombre == null)
            {
                if (e.Importe == "" || e.Importe == null || !IsNumeric(e.Importe))
                {
                    //if (GetEmpleado(e).Importe.ToString().Replace(',', '.') == "0.00" || GetEmpleado(e).Importe.ToString().Replace(',', '.') == null)
                    //{
                    //    e.Importe = GetEmpleado(e).Importe.ToString().Replace(',', '.');
                    //}

                    e.Importe = "0.00";
                }
                //e.Fecha = e.FechaFormat.ToString("ddMMyyyy").Trim();
                //string CMD2 = string.Format("Exec SP_CompareDates");

                //DataSet ds2 = Utilidades.Exec(CMD2);
                //DateTime dt = Convert.ToDateTime(ds2.Tables[0].Rows[0][0]);
                //if (e.Fecha == "01010001" || e.FechaFormat <= dt)
                //{
                //    e.Fecha = GetEmpleado(e).Fecha;
                //}

                // 0 NEW - 1 EDIT - 2 NEW MASIVO - 3 UPDATE MASIVO - 4 DELETE
                 CMD = string.Format
                ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'", 3, "", e.Dni,e.Cuil, Global.getFecha(), e.Importe, Global.GetGlobalAcreditacion(),"","", Global.GetEmpresa().CodEmp, "");

            }
            else
            {
                //s = sucursal[sucursal.FindIndex(x => x.Sucursal.ToString().StartsWith(e.Sucursal))].Descripcion;
                CMD = string.Format
               ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'", 1, e.Nombre.ToUpper(), e.Dni, e.Cuil, "", "",Global.GetGlobalAcreditacion(), e.CBU, e.Activo, Global.GetEmpresa().CodEmp, e.Id);

            }

            
                DataSet ds = Utilidades.Exec(CMD);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            //return new Empleado()
            //{
            //    Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]),
            //    Nombre = ds.Tables[0].Rows[0]["NombreEmp"].ToString().Trim().ToUpper(),
            //    Dni = ds.Tables[0].Rows[0]["DNI"].ToString().Trim().ToUpper(),
            //    Cuil = ds.Tables[0].Rows[0]["Cuil"].ToString().Trim().ToUpper(),
            //    Sucursal = ds.Tables[0].Rows[0]["SucCod"].ToString().Trim().ToUpper(),
            //    Cuenta = ds.Tables[0].Rows[0]["Cue"].ToString().Trim().ToUpper(),
            //    Fecha = ds.Tables[0].Rows[0]["FechaAcred"].ToString().Trim().ToUpper(),
            //    FechaFormat = DateTime.ParseExact(ds.Tables[0].Rows[0]["FechaAcred"].ToString().Trim(), Format, CultureInfo.InvariantCulture),
            //    Importe = ds.Tables[0].Rows[0]["Importe"].ToString().Trim().ToUpper(),
            //    TipoCuenta = ds.Tables[0].Rows[0]["TipoCue"].ToString().Trim().ToUpper(),
            //    TipoAcreditacion = ds.Tables[0].Rows[0]["TipoAcre"].ToString().Trim().ToUpper(),
            //    CodEmp = ds.Tables[0].Rows[0]["CodEmp"].ToString().Trim().ToUpper(),
            //};
        }



        /// <summary>Lista el empleado filtrado por sucursales</summary>
        /// <param name="selector">selector.</param>
        /// <param name="consulta">consulta.</param>
        /// <returns>lista empleados</returns>
        /// <example>
        ///   <code>
        /// coding
        /// </code>
        /// </example>
        public List<Empleado> ListEmpleadoFilterSuc(string selector, string consulta)
        {
            
            string CMD = string.Format("Exec SP_filer_empleados '{0}','{1}','{2}'", Global.GetEmpresa().Cuit,selector,consulta);
            DataSet ds = Utilidades.Exec(CMD);
            List<Empleado> empNew = new List<Empleado>();
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var empleado = new Empleado()
                {
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"]),
                    Nombre = ds.Tables[0].Rows[i]["NombreEmp"].ToString().Trim().ToUpper(),
                    Dni = ds.Tables[0].Rows[i]["DNI"].ToString().Trim().ToUpper(),
                    Cuil = ds.Tables[0].Rows[i]["Cuil"].ToString().Trim().ToUpper(),
                    Sucursal = ds.Tables[0].Rows[i]["SucCod"].ToString().Trim().ToUpper(),
                    Cuenta = ds.Tables[0].Rows[i]["Cue"].ToString().Trim().ToUpper(),
                    Fecha = ds.Tables[0].Rows[i]["Fecha"].ToString().Trim(),
                    FechaFormat = DateTime.ParseExact(ds.Tables[0].Rows[i]["Fecha"].ToString().Trim(),Format,provider),
                    Importe = ds.Tables[0].Rows[i]["Importe"].ToString().Trim().ToUpper(),
                    TipoCuenta = ds.Tables[0].Rows[i]["TipoCue"].ToString().Trim().ToUpper(),
                    TipoAcreditacion = ds.Tables[0].Rows[i]["TipoAcre"].ToString().Trim().ToUpper(),
                    CodEmp = ds.Tables[0].Rows[i]["CodEmp"].ToString().Trim().ToUpper(),
                    EstadoCuenta = ds.Tables[0].Rows[i]["EstadoCuenta"].ToString()
                };
                empNew.Add(empleado);
            }
            return empNew;

        }


        /// <summary>Actualiza el estado de el empleado a  inactivo</summary>
        /// <param name="e">e</param>
        /// <example>
        ///   <code> public void DeleteEmpleado(Empleado e)
        ///         {
        ///             string CMD = string.Format
        ///             ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}'", 4, e.Nombre.ToUpper(), e.Dni, e.Cuil, e.Sucursal.ToUpper(), e.Cuenta, e.Fecha, e.Importe, e.TipoCuenta.ToUpper(), Global.GetGlobalAcreditacion(),e.CBU,e.Activo, Global.GetEmpresa().CodEmp, e.Id);
        ///             DataSet ds = Utilidades.Exec(CMD);
        ///         }</code>
        /// </example>
        public void DeleteEmpleado(Empleado e)
        {
            string CMD = string.Format
            ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'", 4, e.Nombre.ToUpper(), e.Dni, e.Cuil, e.Fecha, e.Importe, Global.GetGlobalAcreditacion(),e.CBU,e.Activo, Global.GetEmpresa().CodEmp, e.Id);
            DataSet ds = Utilidades.Exec(CMD);
        }



        /// <summary>Agrega empleado a la parte de acreditaccion</summary>
        /// <example>
        ///   <code>  public void AddEmpleadosAcreditacion()
        ///         {
        ///             string CMD = string.Format
        ///             ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}'", 2, "", "","", "", "", Global.getFecha(), "", "", Global.GetGlobalAcreditacion(), "", "", Global.GetEmpresa().CodEmp, null);
        ///             try
        ///             {
        ///                 DataSet ds = Utilidades.Exec(CMD);
        ///             }
        ///             catch(Exception e)
        ///             {
        ///                 Global.setError(e.Message);
        ///             }
        ///
        ///         }</code>
        /// </example>
        public void AddEmpleadosAcreditacion()
        {
            string CMD = string.Format
            ("exec SP_abm_empleado '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'", 2, "", "","", Global.getFecha(), "",Global.GetGlobalAcreditacion(), "", "", Global.GetEmpresa().CodEmp, null);
            try
            {
                DataSet ds = Utilidades.Exec(CMD);
            }
            catch(Exception e)
            {
                Global.setError(e.Message);
                log.Error(e.Message);
            }
           
        }



        /// <summary>muestra los ingresados aceptados y rechazados de el archivo excel</summary>
        /// <param name="d">d</param>
        /// <returns>new Preview</returns>
        /// <example>
        ///   <code> public Preview GetPreview(DataSet d)
        ///         {
        ///             return new Preview()
        ///             {
        ///                 ingresados = d.Tables[0].Rows[0]["Ingresados"].ToString(),
        ///                 aceptados = d.Tables[1].Rows[0]["Aceptados"].ToString(),
        ///                 rechazados = d.Tables[2].Rows[0]["Rechazada"].ToString(),
        ///                 Montoingresado = d.Tables[3].Rows[0]["Totali"].ToString(),
        ///                 Montoaceptados = d.Tables[4].Rows[0]["Totala"].ToString(),
        ///                 Montorechazados = d.Tables[5].Rows[0]["Totalr"].ToString()
        ///             };
        ///         }</code>
        /// </example>
        public Preview GetPreview(DataSet d)
        {
            return new Preview()
            {
                ingresados = d.Tables[0].Rows[0]["Ingresados"].ToString(),
                aceptados = d.Tables[1].Rows[0]["Aceptados"].ToString(),
                rechazados = d.Tables[2].Rows[0]["Rechazada"].ToString(),
                Montoingresado = d.Tables[3].Rows[0]["Totali"].ToString(),
                Montoaceptados = d.Tables[4].Rows[0]["Totala"].ToString(),
                Montorechazados = d.Tables[5].Rows[0]["Totalr"].ToString()
            };
        }


        /// <summary>
        ///   <para>
        /// hace el preview corto para la acreditacion mensual</para>
        ///   <para>Muestra el total de ingresados y la suma de los importes</para>
        /// </summary>
        /// <returns>new preview</returns>
        /// <example>
        ///   <code>   public Preview GetShortPreview()
        ///         {
        ///             string CMD = string.Format("select COUNT(*) as 'Aceptados' from EmpleadosAcreditacion where Fecha = '{0}' and CodEmp = '{1}' and TipoAcre = (select Cod from TipoAcre where Deno = '{2}' and Importe > 0)", Global.getFecha(),Global.GetEmpresa().CodEmp,Global.GetGlobalAcreditacion());
        ///             DataSet d = Utilidades.Exec(CMD);
        ///
        ///             string CMD2 = string.Format("SELECT SUM(cast(IMPORTE as numeric(18,2))) as 'Totala' from EmpleadosAcreditacion where Fecha = '{0}' and CodEmp = '{1}' and TipoAcre = (select Cod from TipoAcre where Deno = '{2}')", Global.getFecha(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion());
        ///             DataSet ds = Utilidades.Exec(CMD2);
        ///             return new Preview()
        ///             {
        ///                 aceptados = d.Tables[0].Rows[0]["Aceptados"].ToString(), 
        ///                 Montoaceptados = ds.Tables[0].Rows[0]["Totala"].ToString()
        ///             };
        ///         }</code>
        /// </example>
        public Preview GetShortPreview()
        {
            string CMD = string.Format("select COUNT(*) as 'Aceptados' from EmpleadosAcreditacion where Fecha = '{0}' and CodEmp = '{1}' and TipoAcre ='{2}' and Importe > 0", Global.getFecha(),Global.GetEmpresa().CodEmp,Global.GetGlobalAcreditacion());
            DataSet d = Utilidades.Exec(CMD);

            string CMD2 = string.Format("SELECT SUM(cast(Importe as numeric(18,2))) as 'Totala' from EmpleadosAcreditacion where Fecha = '{0}' and CodEmp = '{1}' and TipoAcre = '{2}'", Global.getFecha(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion());
            DataSet ds = Utilidades.Exec(CMD2);
            return new Preview()
            {
                aceptados = d.Tables[0].Rows[0]["Aceptados"].ToString(), 
                Montoaceptados = ds.Tables[0].Rows[0]["Totala"].ToString()
            };
        }



        /// <summary>Acepta la carga maiva</summary>
        /// <param name="s">if set to <c>true</c> [carga masiva con fecha de acreditacion].</param>
        /// <example>
        ///   <code>      public void AceptCM(bool s)
        ///         {
        ///             if(s)
        ///             {
        ///                 string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}', '{4}'", 3, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());
        ///                 DataSet ds = Utilidades.Exec(CMD);
        ///             }
        ///             else
        ///             {
        ///                 string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}', '{4}'",4, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());
        ///
        ///                 DataSet ds = Utilidades.Exec(CMD);
        ///             }
        ///         }</code>
        /// </example>
        public void AceptCM(bool s)
        {
            if(s)
            {
                string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}', '{4}'", 3, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());
                DataSet ds = Utilidades.Exec(CMD);
            }
            else
            {
                string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}', '{4}'",4, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());

                DataSet ds = Utilidades.Exec(CMD);
            }
        }

        /// <summary>Acepta la carga masiva para construir los campos de ingresados aceptados y rechazados</summary>
        /// <param name="selector">selector</param>
        /// <example>
        ///   <code>public void AceptCM(bool s)
        ///   {
        ///       if(s)
        ///       {
        ///           string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}', '{4}'", 3, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());
        ///           DataSet ds = Utilidades.Exec(CMD);
        ///       }
        ///       else
        ///       {
        ///           string CMD = string.Format("Exec SP_CargaMasiva_Empleados '{0}','{1}','{2}','{3}', '{4}'",4, Global.getSession(), Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());
        ///
        ///           DataSet ds = Utilidades.Exec(CMD);
        ///       }
        ///   }</code>
        /// </example>
        public void GenerarReportePreview(int selector)
        {
            string CMD;
            Excel ex = new Excel();
            switch (selector)
            {
                case 1:
                    CMD = string.Format("Select FECHA,DNI,IMPORTE from AcreditacionesError");
                    ex.GenerarExcel(CMD, "Ingresados");
                    break;
                case 2:
                    CMD = string.Format("Select FECHA,DNI,IMPORTE from AcreditacionesError WHERE Error is null");
                    ex.GenerarExcel(CMD, "Aceptados");
                    break;
                case 3:
                    CMD = string.Format("Select FECHA,DNI,IMPORTE,Error from AcreditacionesError WHERE Error is not null");
                    ex.GenerarExcel(CMD, "Rechazados");
                    break;
            }
        }


        /// <summary>Genera el archivo txt</summary>
        /// <example>
        ///   <code>codigo</code>
        /// </example>
        public void GenerarTxt()
        { 
            string CMD = string.Format("Exec SP_ArchivoSalida '{0}','{1}','{2}'", Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());
            DataSet ds = Utilidades.Exec(CMD);
            string nombreArchivo = "";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                nombreArchivo = ds.Tables[0].Rows[0]["Titulo"].ToString() + ".TXT";

                if (!ds.Tables[0].Columns.Contains("Registro"))
                {
                    log.Error("No se encuentra la columna REGISTRO");
                    return;
                }
                string tmpFile = Path.GetTempPath() + ".txt";
                StreamWriter sw = new StreamWriter(tmpFile, false, Encoding.Default);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sw.WriteLine(ds.Tables[0].Rows[i]["Registro"].ToString());
                }
                sw.Close();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.WriteFile(tmpFile);
                HttpContext.Current.Response.End();
            }
    }



        /// <summary>Gets the reporte.</summary>
        /// <param name="fecha">The fecha.</param>
        /// <returns>new Preview</returns>
        public List<Preview> GetReporte(string fecha)
        {
            if(fecha == "")
            {
                string CMD = string.Format("exec SP_Reporte '{0}','{1}','{2}','{3}'", 0, Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), "");
                try
                {
                    DataSet ds = Utilidades.Exec(CMD);
                    List<Preview> empNew = new List<Preview>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var preview = new Preview()
                        {
                            ingresados = ds.Tables[0].Rows[i]["cantidad"].ToString(),
                            Montoaceptados = ds.Tables[0].Rows[i]["importe"].ToString(),
                            fecha = ds.Tables[0].Rows[i]["Fecha"].ToString()
                        };
                        empNew.Add(preview);
                    }
                    return empNew;
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                    throw;
                }
            }
            else
            {
                string CMD = string.Format("exec SP_Reporte '{0}','{1}','{2}','{3}'", 1, Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), fecha);
                try
                {
                    DataSet ds = Utilidades.Exec(CMD);
                    Excel ex = new Excel();
                    ex.GenerarExcel(CMD, "Reporte_"+fecha);
                    return null;
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                    throw;
                }
            }
           
               


                //string CMD = string.Format("exec SP_reporte '{0}','{1}','{2}','{4}'", 0, Global.GetEmpresa().CodEmp, Global.GetGlobalAcreditacion(), Global.getFecha());
                //DataSet ds = Utilidades.Exec(CMD);
                //return null;

        }
    }

}