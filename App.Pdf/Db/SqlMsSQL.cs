using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Pdf.Db
{
    public class SqlMsSQL : SQL
    {
        public string ReourceSQL
        {
            get
            {
                return "select CONCAT(TextKey,'_',Language) as [Text],Text as [Value] from TblResouces where Language in ('en',@language)";
            }
        }
    }
}