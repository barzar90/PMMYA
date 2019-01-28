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
    public partial class OtherMenu : System.Web.UI.UserControl
    {
        public string LangID = "en-IN";
        public string RenderDevice { get; set; }

        private void BindMenu()
        {
            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {

                    lblHeading.Text = "Other Link"; //TODO Marathi
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Other_Mr.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Othermenu1.InnerHtml = UserMenu;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    lblHeading.Text = "Other Link";
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Other_En.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Othermenu1.InnerHtml = UserMenu;
                }
                else
                {
                    lblHeading.Text = "Other Link";
                    string UserMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Other_Ur.xml");
                    UserMenu = UserMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Othermenu1.InnerHtml = UserMenu;
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