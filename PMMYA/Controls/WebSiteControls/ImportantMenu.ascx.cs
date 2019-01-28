using System;
using System.Web;
using System.Configuration;
using System.IO;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class ImportantMenu : System.Web.UI.UserControl
    {
        public string LangID = "en-IN";
        public string RenderDevice { get; set; }

        private void BindMenu()
        {
            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {

                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "ImportantLink_Mr.xml");
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Importantmenu1.InnerHtml = UserMenu;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "ImportantLink_En.xml");
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Importantmenu1.InnerHtml = UserMenu;
                }
                else
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "ImportantLink_Ur.xml");
                    UserMenu = UserMenu.Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Importantmenu1.InnerHtml = UserMenu;
                }
            }
            finally
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindMenu();
        }
    }
}