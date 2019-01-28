using System;
using System.Web;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BL
{
    public class MAHAITPage : System.Web.UI.Page
    {
        public const string PostBackEventTarget = "__EVENTTARGET";
        public const string LanguageDropDownID = "SetCulture1$LinkButton1";

        public MAHAITPage()
        {
        }

        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = GetGlobalResourceObject(ResourceFile, ResourceKey);
            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        protected override void InitializeCulture()
        {
            ///<remarks><REMARKS>
            ///Check if PostBack occured. Cannot use IsPostBack in this method
            ///as this property is not set yet.
            ///</remarks>
            ///

            if (HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString() == "")
            {
            }

            if (Request[PostBackEventTarget] != null)
            {
                string controlID = Request[PostBackEventTarget];
                if (controlID.EndsWith(LanguageDropDownID))
                {
                    if (HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString() == "mr-IN")
                        HttpContext.Current.Profile.SetPropertyValue("Selectedlanguage", "en-IN");
                    else
                        HttpContext.Current.Profile.SetPropertyValue("Selectedlanguage", "mr-IN");

                    SetCulture(HttpContext.Current.Profile.GetPropertyValue("Selectedlanguage").ToString());
                }
            }
        }

        private void SetCulture(string NewCulture)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(NewCulture);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(NewCulture);
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.QueryString["format"] != null)
                if (Convert.ToString(Request.QueryString["format"]) == "print")
                    MasterPageFile = "~/Masters/WebSiteMasters/SitePrint.Master";
        }
        public void SetUICulture(Hashtable controls)
        {
            //string cultureName = null;
            try
            {
                //cultureName = (string)Session["CurrentCulture"];
                //Page.UICulture = cultureName;

                foreach (DictionaryEntry entry in controls)
                {
                    switch (entry.Key.GetType().ToString())
                    {
                        case "System.Web.UI.WebControls.Button":
                            ((Button)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.WebControls.Label":
                            ((Label)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.RadioButtonList":
                            ((RadioButtonList)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.RadioButton":
                            ((RadioButton)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.WebControls.LinkButton":
                            ((LinkButton)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.WebControls.DataControlFieldHeaderCell":
                            ((DataControlFieldHeaderCell)entry.Key).Text = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;
                        case "System.Web.UI.HtmlControls.HtmlGenericControl":
                            ((HtmlGenericControl)entry.Key).InnerHtml = GetGlobalResourceObject("Resource", entry.Value.ToString()).ToString();
                            break;

                    }
                }

            }
            catch (Exception ex)
            {
            }

        }

        public static string isMobileBrowser()
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
                else if (UserAgent.Contains("ipad".ToLower()))
                {
                    return "tablet";
                }
                else if (UserAgent.Contains("android".ToLower()))
                {
                    if (UserAgent.Contains("mobile".ToLower()))
                    {
                        return "phone";
                    }
                    else if (UserAgent.Contains("Nexus".ToLower()))
                    {
                        return "phone";
                    }
                    else
                    {
                        return "tablet";
                    }
                }
                else
                {
                    foreach (string s in mobiles)
                    {
                        if (UserAgent.ToLower().Contains(s.ToLower()))
                        {
                            return "phone";
                        }
                    }
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
