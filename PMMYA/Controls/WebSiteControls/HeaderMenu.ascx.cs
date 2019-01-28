using System;
using System.Web;
using System.IO;
using System.Configuration;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class HeaderMenu : MAHAITUserControl
    {

        public string LangID = "en-IN";
        public string RenderDevice { get; set; }

        private void BindHeader()
        {
            try
            {
                //Added By K.P 2018
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "MainMenu_Mr.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    UserMenu = UserMenu.Replace("&amp;", "&");
                    smoothmenu1.InnerHtml = UserMenu;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "MainMenu_En.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    UserMenu = UserMenu.Replace("&amp;", "&");
                    smoothmenu1.InnerHtml = UserMenu;
                }
                else 
                {
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "MainMenu_Ur.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    UserMenu = UserMenu.Replace("&amp;", "&");
                    smoothmenu1.InnerHtml = UserMenu;
                }

            }
            finally
            { }
        }

        void Page_PreRender(Object o, EventArgs e)
        {
            BindHeader();
        }
    }
}