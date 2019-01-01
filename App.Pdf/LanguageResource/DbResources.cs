using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dapper;
using System.Web.Mvc;
using App.Pdf.Fx;
using App.Pdf.Db;

namespace App.Pdf.LanguageResource
{
    public class DbResources
    {
        IDbConnection con = DependencyInjector.GetDbConnection();
        SQL SQL = DependencyInjector.GetDbQueries();
        public List<SelectListItem> GetResourcesForLanguage(string language)
        {
            return con.Query<SelectListItem>(SQL.ReourceSQL, new { language = language }).ToList();
        }
    }
}