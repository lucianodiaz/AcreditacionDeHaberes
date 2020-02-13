using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using NPOI.POIFS.FileSystem;
using NPOI.HPSF;
using System.IO;
using ADOX;
using ADODB;
using ConnDB;


namespace Micrositio_Acreditacion.Services
{
    /// <summary>
    ///   <para>funcion excel</para>
    /// </summary>
    public class Excel
    {
        /// <summary>  el log
        /// de error</summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Micrositio_Acreditacion.Services.Excel));

        /// <summary>arma la tabla excel</summary>
        /// <param name="strFileName">strfileName</param>
        /// <param name="extencion">extension</param>
        /// <returns>strTables</returns>
        /// <example>
        ///   <code>public static string[] GetTableExcel(string strFileName, string extencion)
        ///         {
        ///             string[] strTables = new string[100];
        ///             Catalog oCatlog = new Catalog();
        ///             ADOX.Table oTable = new ADOX.Table();
        ///             ADODB.Connection oConn = new ADODB.Connection();
        ///             if (extencion == ".xls")
        ///                 oConn.Open("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";", "", "", 0);
        ///             if (extencion == ".xlsx")
        ///             {
        ///                 try
        ///                 {
        ///                     oConn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + "; Jet OLEDB:Engine Type=5;Extended Properties='Excel 12.0;HDR=YES;IMEX=1';", "", "", 0);
        ///                 }
        ///                 catch (Exception e)
        ///                 {
        ///                     Global.setError(e.Message);
        ///                     log.Error(e.Message);
        ///                     throw;
        ///                 }
        ///
        ///             }
        ///
        ///
        ///             oCatlog.ActiveConnection = oConn;
        ///             if (oCatlog.Tables.Count > 0)
        ///             {
        ///                 int item = 0;
        ///                 foreach (ADOX.Table tab in oCatlog.Tables)
        ///                 {
        ///                     if (tab.Type == "TABLE")
        ///                     {
        ///                         strTables[item] = tab.Name;
        ///                         item++;
        ///                     }
        ///                 }
        ///             }
        ///             oConn.Close();
        ///             return strTables;
        ///         }</code>
        /// </example>
        public static string[] GetTableExcel(string strFileName, string extencion)
        {
            string[] strTables = new string[100];
            Catalog oCatlog = new Catalog();
            ADOX.Table oTable = new ADOX.Table();
            ADODB.Connection oConn = new ADODB.Connection();
            if (extencion == ".xls")
                oConn.Open("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";", "", "", 0);
            if (extencion == ".xlsx")
            {
                try
                {
                    oConn.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + "; Jet OLEDB:Engine Type=5;Extended Properties='Excel 12.0;HDR=YES;IMEX=1';", "", "", 0);
                }
                catch (Exception e)
                {
                    Global.setError(e.Message);
                    log.Error(e.Message);
                    throw;
                }

            }


            oCatlog.ActiveConnection = oConn;
            if (oCatlog.Tables.Count > 0)
            {
                int item = 0;
                foreach (ADOX.Table tab in oCatlog.Tables)
                {
                    if (tab.Type == "TABLE")
                    {
                        strTables[item] = tab.Name;
                        item++;
                    }
                }
            }
            oConn.Close();
            return strTables;
        }
        

        /// <summary>Gets la tabla de excel</summary>
        /// <param name="strFileName">strFileName</param>
        /// <param name="extencion">extencion</param>
        /// <returns>tables.datasset</returns>
        /// <example>
        ///   <code>public static DataSet GetDataTableExcel(string strFileName, string extencion)
        ///        {
        ///            OleDbConnection conn = new OleDbConnection();
        ///
        ///            if (extencion == ".xls")
        ///            {
        ///                conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");
        ///            }
        ///            if (extencion == ".xlsx")
        ///            {
        ///                conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + "; Jet OLEDB:Engine Type=5;Extended Properties='Excel 12.0;HDR=YES;IMEX=1';");
        ///            }
        ///            // try
        ///            {
        ///                conn.Open();
        ///                string[] tablas = GetTableExcel(strFileName, extencion);
        ///                string strQuery = "SELECT * FROM [" + tablas[0] + "]";
        ///
        ///                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
        ///
        ///                System.Data.DataSet ds = new System.Data.DataSet();
        ///
        ///                adapter.Fill(ds);
        ///                conn.Close();
        ///                return ds.Tables[0].DataSet;
        ///            }
        ///            catch (Exception e)
        ///            {
        ///                Global.setError(e.Message);
        ///                log.Error(e.Message);
        ///                return null;
        ///                throw;
        ///            }
        ///
        ///            //adapter.Dispose();
        ///
        ///
        ///        }</code>
        /// </example>
        public static DataSet GetDataTableExcel(string strFileName, string extencion)
        {
            OleDbConnection conn = new OleDbConnection();

            if (extencion == ".xls")
            {
                conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";");
            }
            if (extencion == ".xlsx")
            {
                conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + "; Jet OLEDB:Engine Type=5;Extended Properties='Excel 12.0;HDR=YES;IMEX=1';");
            }
            //
            try
            {
                conn.Open();
                string[] tablas = GetTableExcel(strFileName, extencion);
                string strQuery = "SELECT * FROM [" + tablas[0] + "]";

                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);

                System.Data.DataSet ds = new System.Data.DataSet();

                adapter.Fill(ds);
                conn.Close();
                return ds.Tables[0].DataSet;
            }
            catch (Exception e)
            {
                Global.setError(e.Message);
                log.Error(e.Message);
                return null;
                throw;
            }

            //adapter.Dispose();


        }


        /// <summary>Inserta los datos en un excel</summary>
        /// <param name="ldsData">lsdData</param>
        /// <param name="prefijo">prefijo.</param>
        /// <example>
        ///   <code>codigo</code>
        /// </example>
        public void InsertarDatosExcel(DataSet ldsData, string prefijo)
        {
            string[] campos = new string[100];
            string inCampos = "";
            string inValores = "";
            string InsertTotal = "";
            for (int c = 0; c < ldsData.Tables[0].Columns.Count; c++)
            {
                inCampos += "CAMPO" + (c + 1).ToString() + ",";
            }
            if (prefijo != null)
            {
                inCampos += "CAMPO40,";
            }
            inCampos = inCampos.Substring(0, inCampos.Length - 1);

            for (int f = 0; f < ldsData.Tables[0].Rows.Count; f++)
            {
                inValores = "";
                for (int c = 0; c < ldsData.Tables[0].Columns.Count; c++)
                {
                    inValores += "'" + ldsData.Tables[0].Rows[f][c].ToString().Replace("'", "''") + "',";
                }
                if (prefijo != null)
                {
                    inValores += "'" + prefijo + "',";
                }
                inValores = inValores.Substring(0, inValores.Length - 1);
                InsertTotal += "INSERT INTO DATOS (" + inCampos + ") VALUES (" + inValores + "); ";
            }
            if (prefijo != null)
            {
                InsertTotal = "DELETE FROM DATOS WHERE CAMPO40 = '" + prefijo + "'; " + InsertTotal;
            }
            else
            {
                InsertTotal = "DELETE FROM DATOS; " + InsertTotal;
            }
            try
            {
                Utilidades.Exec(InsertTotal);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw;
            }
        }



        /// <summary>Genera el archivo excel</summary>
        /// <param name="consultaSQL">la consulta SQL.</param>
        /// <param name="fileName">Nombre del archivo</param>
        /// <example>
        ///   <code>codigo</code>
        /// </example>
        public void GenerarExcel(string consultaSQL, string fileName)
        {

            DataSet ldsData = new DataSet();
            try
            {
                var workbook = new XSSFWorkbook(); //HSSFWorkbook();

                // Conn.ConsultaDB(consultaSQL, out ldsData);

                ldsData = Utilidades.Exec(consultaSQL);

                if (ldsData != null && ldsData.Tables.Count > 0)
                {
                    for (int h = 0; h < ldsData.Tables.Count; h++)
                    {
                        if (ldsData.Tables[h].Rows.Count > 0)
                        {
                            string tablename = ((ldsData.Tables[h].TableName == null || ldsData.Tables[h].TableName == "" || ldsData.Tables[h].TableName == "Table") ? "Hoja" + (h + 1).ToString() : ldsData.Tables[h].TableName);
                            for (int c = 0; c < ldsData.Tables[h].Columns.Count; c++)
                            {
                                if (ldsData.Tables[h].Columns[c].ToString().ToUpper() == "TABLENAME")
                                {
                                    tablename = ldsData.Tables[h].Rows[0][ldsData.Tables[h].Columns[c].ToString()].ToString();
                                    ldsData.Tables[h].Columns.RemoveAt(c);
                                }
                            }
                            #region generaExcelporHoja
                            var sheet = workbook.CreateSheet(tablename);

                            IFont font1 = workbook.CreateFont();
                            font1.Color = HSSFColor.Black.Index;
                            font1.Boldweight = (short)FontBoldWeight.Bold;
                            font1.FontHeightInPoints = 10;

                            ICellStyle styleMiddle = workbook.CreateCellStyle();
                            styleMiddle.Alignment = HorizontalAlignment.Center;
                            styleMiddle.VerticalAlignment = VerticalAlignment.Center;

                            styleMiddle.SetFont(font1);

                            if (ldsData != null && ldsData.Tables.Count > 0)
                            {
                                int cols = ldsData.Tables[h].Columns.Count;

                                if (ldsData.Tables[h].Rows.Count > 0)
                                {//                    int adic = 1;
                                    for (Int32 rowIndex = 0; rowIndex < ldsData.Tables[h].Rows.Count; rowIndex++)
                                    {
                                        int i = rowIndex;
                                        var row = sheet.CreateRow((i + 1));
                                        for (Int32 col = 0; col < cols; col++)
                                        {
                                            //Global.ManejarAlerta(row.ToString());

                                            if (ldsData.Tables[h].Rows[i][col].GetType() == Type.GetType("System.Int16"))
                                                row.CreateCell(col).SetCellValue(Convert.ToDouble(ldsData.Tables[h].Rows[i][col]));

                                            if (ldsData.Tables[h].Rows[i][col].GetType() == Type.GetType("System.Int32"))
                                                row.CreateCell(col).SetCellValue(Convert.ToDouble(ldsData.Tables[h].Rows[i][col]));

                                            if (ldsData.Tables[h].Rows[i][col].GetType() == Type.GetType("System.Decimal"))
                                                row.CreateCell(col).SetCellValue(Convert.ToDouble(ldsData.Tables[h].Rows[i][col]));

                                            if (ldsData.Tables[h].Rows[i][col].GetType() == Type.GetType("System.Int64"))
                                                row.CreateCell(col).SetCellValue(Convert.ToDouble(ldsData.Tables[h].Rows[i][col]));

                                            if (ldsData.Tables[h].Rows[i][col].GetType() == Type.GetType("System.Double"))
                                                row.CreateCell(col).SetCellValue(Convert.ToDouble(ldsData.Tables[h].Rows[i][col]));

                                            if (ldsData.Tables[h].Rows[i][col].GetType() == Type.GetType("System.DateTime"))
                                                row.CreateCell(col).SetCellValue(Convert.ToDateTime(ldsData.Tables[h].Rows[i][col]));

                                            if (ldsData.Tables[h].Rows[i][col].GetType() == Type.GetType("System.String"))
                                                row.CreateCell(col).SetCellValue(ldsData.Tables[h].Rows[rowIndex][col].ToString());
                                        }
                                    }
                                }
                                //                    bool ap = false;
                                //int mergeant = 0, 
                                if (ldsData.Tables[h].Rows.Count > 0)
                                {

                                    int c = 0;
                                    var header1 = sheet.CreateRow(0);

                                    for (c = 0; c < ldsData.Tables[h].Columns.Count; c++)
                                    {
                                        header1.CreateCell(c).SetCellValue(ldsData.Tables[h].Columns[c].ToString());
                                        header1.GetCell(c).CellStyle = styleMiddle;
                                    }
                                }
                                else
                                {
                                    var row = sheet.CreateRow(0);
                                    for (Int32 colu = 0; colu < cols; colu++)
                                    {
                                        row.CreateCell(colu).SetCellValue(ldsData.Tables[h].Columns[colu].ColumnName);
                                    }
                                }

                            }
                            #endregion
                        }
                        else
                        {
                            var sheet = workbook.CreateSheet("Tabla " + h.ToString());
                            var row = sheet.CreateRow(1);
                            row.CreateCell(0).SetCellValue("LA CONSULTA NO DEVOLVIO RESULTADOS");
                            var row1000 = sheet.CreateRow(1000);
                            row1000.CreateCell(0).SetCellValue(consultaSQL);
                        }
                    }
                    using (var exportData = new MemoryStream())
                    {
                        workbook.Write(exportData);
                        string saveAsFileName = fileName + ".xlsx";


                        string tmpfileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + "";
                        FileStream file = new FileStream(tmpfileName, FileMode.Create);
                        workbook.Write(file);
                        file.Close();

                        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
                        HttpContext.Current.Response.Clear();
                        //HttpContext.Current.Response.BinaryWrite(exportData.GetBuffer());
                        HttpContext.Current.Response.WriteFile(tmpfileName);
                        HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                        HttpContext.Current.Response.SuppressContent = true;
                        //HttpContext.Current.Response.End();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    var sheet = workbook.CreateSheet("Hoja 1");
                    var row = sheet.CreateRow(1);
                    row.CreateCell(0).SetCellValue("  LA CONSULTA NO DEVOLVIO RESULTADOS");
                    var row1000 = sheet.CreateRow(1000);
                    row1000.CreateCell(0).SetCellValue(consultaSQL);
                }

            }
            catch (Exception e)
            {
                Global.setError(e.Message);
                log.Error(e.Message);
            }
        }
    }
                

}