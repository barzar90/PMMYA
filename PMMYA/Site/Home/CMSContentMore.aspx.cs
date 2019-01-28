using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Site.Home
{
    public partial class CMSContentMore : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.QueryString["format"] != null)
            {
                if (Convert.ToString(Request.QueryString["format"]) == "print")
                {
                    MasterPageFile = "~/Masters/WebSiteMasters/SitePrint.Master";

                }
            }

            try
            {
                string[] currentMaster = this.Page.MasterPageFile.Split('.');
                string device = isMobileBrowser();
                if (device != string.Empty)
                {
                    this.Page.MasterPageFile = "~/Masters/WebSiteMasters/" + currentMaster[0] + device + currentMaster[1];
                }
            }
            finally
            {
            }

        }

        private string isMobileBrowser()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types
                string[] mobiles =
                    new[]
                {
                    "midp", "j2me", "avant", "docomo",
                    "novarra", "palmos", "palmsource",
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/",
                    "blackberry", "mib/", "symbian",
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio",
                    "SIE-", "SEC-", "samsung", "HTC",
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx",
                    "NEC", "philips", "mmm", "xx",
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java",
                    "pt", "pg", "vox", "amoi",
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo",
                    "sgh", "gradi", "jb", "dddi",
                    "moto"
                };

                //Loop through each item in the list created above 
                //and check if the header contains that text
                string UserAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToLower();
                if (UserAgent.Contains("iphone".ToLower()))
                {
                    return "phone";
                }
                if (UserAgent.Contains("ipad".ToLower()))
                {
                    return "tablet";
                }

                return string.Empty;
            }
            else
            {
                return string.Empty;
            }

        }
    }
}