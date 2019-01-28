using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class FormHeader : MAHAITUserControl
    {
        static int count = 0;

        Hashtable controls = new Hashtable();

        public string FormTitle { get { return lblTitle.Text; } set { lblTitle.Text = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["User"] = Session["UserInRole"];

            if (HttpContext.Current.Profile.IsAnonymous == true)
            {

            }
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            Search_btn.Text = GetResourceValue("Common", "Search_btn", "");
            Button btnlogin = (Button)HeadLoginView.FindControl("btnlogin");
            if (btnlogin != null)
            {
                btnlogin.Text = GetResourceValue("Common", "btnlogin", "");
            }
            else
            {
                LoginStatus HeadLoginStatus = (LoginStatus)HeadLoginView.FindControl("HeadLoginStatus");;
                HeadLoginStatus.LogoutText = GetResourceValue("Common", "HeadLoginStatus", "");
                LinkButton lnkchangepassword = (LinkButton)HeadLoginView.FindControl("lnk_changepassword");
                lnkchangepassword.Text = GetResourceValue("Common", "HyperLink1", "");
            }
            btnHome.Text = GetResourceValue("Common", "btnHome", "");
            btnContactUs.Text = GetResourceValue("Common", "btnContactUs", "");
            //lbl_headTitle.Text = GetResourceValue("Common", "lbl_headTitle", "");
           // NationalEmblem_alt.Alt = GetResourceValue("Common", "NationalEmblem_alt", "");

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login/Login.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/1001/Home");
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/1114/Contact-us");
        }

        protected void lnk_changepassword_Click(object sender, EventArgs e)
        {         
            Response.Redirect("~/Account/Login/ChangePassword.aspx");
        }
        protected void HeadLoginStatus_LoggedOut(object sender, EventArgs e)
        {
            //Added by Anand Dated on 08-08-2018 
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }

            Response.Redirect("~/Account/Login/Login.aspx");
            //End 08-08-2018 
        }
    }
}