using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace BL
{
    public class MAHAITWebServices : System.Web.Services.WebService
    {
        public BL MAHAITDBAccess;

        public MAHAITWebServices()
        {

            MAHAITDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            MAHAITDBAccess.ServerPath = Server.MapPath("..\\App_Data\\" + HttpContext.Current.Profile.UserName);
            MAHAITDBAccess.UserName = HttpContext.Current.Profile.UserName;

            if (!Directory.Exists(MAHAITDBAccess.ServerPath))
            {
                Directory.CreateDirectory(MAHAITDBAccess.ServerPath);
            }

            if (HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString() != System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToString())
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
            }

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
            {
                MAHAITDBAccess.LangID = "2";
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
            {
                MAHAITDBAccess.LangID = "1";
            }
            else
            {
                MAHAITDBAccess.LangID = "3";
            }
        }
    }
}
