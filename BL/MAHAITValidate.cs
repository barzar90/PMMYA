using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace BL
{
    public class MAHAITValidate : System.Web.UI.Page
    {
        public static BL MAHAITDBAccess;

        public MAHAITValidate()
        {
        }

        public static void LoadProfile(string ServerPath)
        {
            if (HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString() != System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToString())
           {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
           }


            MAHAITDBAccess = new BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            MAHAITDBAccess.ServerPath = ServerPath;
            MAHAITDBAccess.UserName = HttpContext.Current.Profile.UserName;

            if (!Directory.Exists(MAHAITDBAccess.ServerPath))
            {
                Directory.CreateDirectory(MAHAITDBAccess.ServerPath);
            }
            //Added By K.P on 21-05-2018
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
            //End
        }
    }

    public class NameValue
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class MAHAITResponse
    {
        public string FieldName;
        public string Action;
        public string Message;
    }
}
