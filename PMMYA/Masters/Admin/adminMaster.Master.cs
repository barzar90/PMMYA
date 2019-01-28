using System;
using System.Web.UI.HtmlControls;
using PMMYA.Controls.WebSiteControls;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using BL;

namespace PMMYA.Masters.Admin
{
    public partial class adminMaster : MAHAITMasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

 
        void SetCulture1_ButtonClickedCultureSheet(object sender, EventArgs e)
        {
            HtmlLink Link = FindControl("CultureSheet") as HtmlLink;
            if (Link == null) return;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            //if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-GB").ToLower())
            {
                Link.Href = @"../../Styles/LayoutMR.css";
            }
            else
            {
                Link.Href = @"../../Styles/LayoutEN.css";
            }
        }
        protected void SetCulture1_ButtonClickedBrightest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "larger");
        }
        protected void SetCulture1_ButtonClickedBright(object sender, System.EventArgs e)
        {

            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "large");

        }
        protected void SetCulture1_ButtonClickedNormal(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "medium");

        }
        protected void SetCulture1_ButtonClickedDark(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "small");

        }
        protected void SetCulture1_ButtonClickedDarkest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "smaller");

        }
        protected void SetCulture1_ButtonClickedWhite(object sender, System.EventArgs e)
        {
            HtmlLink link = FindControl("mystylesheet") as HtmlLink;
            link.Href = @"../../styles/Layout.css";
        }
        protected void SetCulture1_ButtonClickedContrast(object sender, System.EventArgs e)
        {
            HtmlLink Link = FindControl("MyStyleSheet") as HtmlLink;
            Link.Href = @"../../Styles/LayoutBlack.css";

        }
    }
}