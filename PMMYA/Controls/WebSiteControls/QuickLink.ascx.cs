using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;


namespace PMMYA.Controls.WebSiteControls
{
    public partial class QuickLink : System.Web.UI.UserControl
    {
        public string LangID = "en-IN";
        public string RenderDevice { get; set; }

        private void BindMenu()
        {
            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "QuickLink_Mr.xml");
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Quickmenu1.InnerHtml = UserMenu;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "QuickLink_En.xml");
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Quickmenu1.InnerHtml = UserMenu;
                }
                else
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "QuickLink_Ur.xml");
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Quickmenu1.InnerHtml = UserMenu;
                }
            }
            finally
            {
            }
        }

        void Page_PreRender(Object o, EventArgs e)
        {
            BindMenu();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}