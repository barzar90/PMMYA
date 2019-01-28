using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace PMMYA.Controls.AdminControls
{
    public partial class adminHeader : MAHAITUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchBTN_Click(object sender, EventArgs e)
        {

            //this.Response.Redirect("search.aspx?q=" + searchTxtBox);
        }
        void Page_PreRender(Object o, EventArgs e)
        {
            btnHome.Text = GetResourceValue("Common", "btnHome", "");
            btnContactUs.Text = GetResourceValue("Common", "btnContactUs", "");
            //NationalEmblem_alt.Alt = GetResourceValue("Common", "NationalEmblem_alt", "");
            //lbl_headTitle.Text = GetResourceValue("Common", "lbl_headTitle", "");
           // lbl_navigation.Text = GetResourceValue("Common", "lbl_navigation", "");
            LoginStatus HeadLoginStatus = (LoginStatus)HeadLoginView.FindControl("HeadLoginStatus");
            HyperLink HyperLink1 = (HyperLink)HeadLoginView.FindControl("HyperLink1");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Site/Home/Index.aspx");
            Response.Redirect("~/1001/Home");

        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/1049/Contact-Us");
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //Response.Redirect("<a target='_blank' href='https://webmail.maharashtra.gov.in/'></a>");

            string redirect = "<script>window.open('https://webmail.maharashtra.gov.in/');</script>";
            Response.Write(redirect);
            //   Response.Redirect("https://webmail.maharashtra.gov.in/");
            // Response.Redirect("~/Account/Login/Login.aspx");
        }
    }
}