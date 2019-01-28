using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class FooterMenu : MAHAITUserControl //: System.Web.UI.UserControl
    {

        public string RenderDevice { get; set; }

        private void BindMenu()
        {
            try
            {
                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                {

                    string FooterMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Footer_Mr.xml");
                    FooterMenu = FooterMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Footermenu1.InnerHtml = FooterMenu;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                {
                    string FooterMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Footer_En.xml");
                    FooterMenu = FooterMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Footermenu1.InnerHtml = FooterMenu;
                }
                else
                {
                    string FooterMenu = File.ReadAllText(Server.MapPath(ConfigurationManager.AppSettings["DirectoryPath"] + "XmlMenu/") + "Footer_Ur.xml");
                    FooterMenu = FooterMenu.Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                    Footermenu1.InnerHtml = FooterMenu;
                }
            }
            finally
            { }
        }

        protected void Page_PreRender(Object o, EventArgs e)
        {
            BindMenu();
            //lbl_copyright.Text = GetResourceValue("Common", "lbl_copyright", "");
            
            lblDevelopedby.Text= GetResourceValue("Common", "lblDevelopedby", "");
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}