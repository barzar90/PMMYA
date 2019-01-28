using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;
using System.Web.Script.Services;
using System.Text.RegularExpressions;

namespace PMMYA.WebServices
{
    /// <summary>
    /// Summary description for validateHtml
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
    public class validateHtml : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public  bool ValidateHTML(string editorContent)
        {
            bool flag = true;
            string str = HttpUtility.HtmlDecode(editorContent);
            using (StreamReader r = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/WebServices/XSS_Cheat_Sheet.txt"), Encoding.Default))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (str.ToLower().Trim().Contains(line.ToLower().Trim()))
                        {
                            flag = false;
                            break;

                        }
                        
                    }
                }

            }
            return flag;
        }


    }
}
