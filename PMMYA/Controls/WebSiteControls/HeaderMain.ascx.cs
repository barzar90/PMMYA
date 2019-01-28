using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class HeaderMain : MAHAITUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Page_PreRender(Object o, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
            {
                searchTxtBox.DestinationLanguage = TextBoxServerControl.TextBoxControl.SupportedLanguages.ENGLISH;
                searchTxtBox.CDACDestinationLanguage = TextBoxServerControl.TextBoxControl.CDACSupportedLanguages.ENGLISH;
            }
            else
            {
                searchTxtBox.DestinationLanguage = TextBoxServerControl.TextBoxControl.SupportedLanguages.ENGLISH;
                searchTxtBox.CDACDestinationLanguage = TextBoxServerControl.TextBoxControl.CDACSupportedLanguages.MARATHI;
            }

            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            searchTxtBox.Text = _MahaITUC.GetResourceValue("Common", "searchTxtBox", "");
            lblSearchBTN.InnerText = _MahaITUC.GetResourceValue("Common", "lblSearchBTN", "");
            Search_btn.Text = _MahaITUC.GetResourceValue("Common", "Search_btn", "");


            Button btnlogin = (Button)HeadLoginView.FindControl("btnlogin");
            if (btnlogin != null)
            {
                btnlogin.Text = _MahaITUC.GetResourceValue("Common", "btnlogin", "");
            }
            else
            {
                LoginStatus HeadLoginStatus = (LoginStatus)HeadLoginView.FindControl("HeadLoginStatus");
                HeadLoginStatus.LogoutText = _MahaITUC.GetResourceValue("Common", "HeadLoginStatus", "");
            }

            //lbl_headTitle.Text = _MahaITUC.GetResourceValue("Common", "lbl_headTitle", "");
            lbl_skipToNav.Text = _MahaITUC.GetResourceValue("Common", "lbl_skipToNav", "");
            lbl_skipToContent.Text = _MahaITUC.GetResourceValue("Common", "lbl_skipToContent", "");
        }

        protected void Search_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/Home/SearchSite.aspx?Keyword=" + searchTxtBox.Text + "");
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login/Login.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/Home/Index.aspx");
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Site/Home/contactUs.aspx");
        }

    }
}