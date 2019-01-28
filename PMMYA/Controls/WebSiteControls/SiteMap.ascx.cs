using System;
using System.Web;
using System.IO;
using System.Configuration;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class SiteMap : System.Web.UI.UserControl
    {
        public string LangID = "en-IN";
        public string RenderDevice { get; set; }
        MAHAITUserControl _MAHAITUC = new MAHAITUserControl();

        private void BindMenu()
        {
            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    lblHeading.Text = _MAHAITUC.GetResourceValue("Common", "lblsitemap", "");

                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "SiteMap_Mr.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Sitemap1.InnerHtml = UserMenu;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    lblHeading.Text = _MAHAITUC.GetResourceValue("Common", "lblsitemap", "");
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "SiteMap_En.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Sitemap1.InnerHtml = UserMenu;
                }
                else
                {
                    lblHeading.Text = _MAHAITUC.GetResourceValue("Common", "lblsitemap", "");
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "SiteMap_Ur.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Sitemap1.InnerHtml = UserMenu;
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