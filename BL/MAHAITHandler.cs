using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace BL
{


     public class MAHAITHandler : IHttpHandler
    {
        BL MAHAITDBAccess;


        public MAHAITHandler()
        {
            MAHAITDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            MAHAITDBAccess.UserName = HttpContext.Current.Profile.UserName;

            if (HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString() != System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToString())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
            }

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
            {
                MAHAITDBAccess.LangID = "2";
            }
            else
            {
                MAHAITDBAccess.LangID = "1";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
        }
    }
}
