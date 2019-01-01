using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App.Pdf.Fx
{
    public class DependencyInjector
    {
        public static System.Data.IDbConnection GetDbConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public static App.Pdf.Db.SQL GetDbQueries()
        {
            return new App.Pdf.Db.SqlMsSQL();
        }
    }
}