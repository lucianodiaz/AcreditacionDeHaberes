using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ConnDB
{
    public class Utilidades
    {
        static string sqlCon;
        public static void SetCon( string con)
        {
            
            sqlCon = con;
        }

        public static DataSet Exec(string CMD)
        {
            
            SqlConnection Con = new SqlConnection(sqlCon);
        
            Con.Open();
        
            DataSet ds = new DataSet();
            SqlDataAdapter SDA = new SqlDataAdapter(CMD, Con);

            SDA.Fill(ds);

            Con.Close();
            return ds;
        }
    }
}
