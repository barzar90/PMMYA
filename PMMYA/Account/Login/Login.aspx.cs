using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMMYA.Masters;
using System.Web.Security;
using System.Web.Profile;

namespace PMMYA.Account.Login
{
    public partial class Login : System.Web.UI.Page
    {

        string UserRegistration = System.Configuration.ConfigurationManager.AppSettings["SelfUserRegistration"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            Control HeaderMain = (Control)Master.FindControl("HeaderMain1");
            //  HeaderMain.Visible = false;
            Control HeaderMain_topLinks = (Control)HeaderMain.FindControl("topLinks");
            HeaderMain_topLinks.Visible = false;
            try
            {
                if (hdnDisplayReg.Value == "1" && UserRegistration == "Yes")
                {
                    ctrlLogin.Visible = false;
                    //ctrlRegistration.Visible = true;
                }
                else
                {
                    ctrlLogin.Visible = true;
                    //ctrlRegistration.Visible = false;
                }                
            }

            finally
            {

            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {

        }

        protected void HandleSessionFixation()
        {
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                HttpCookie myCookie = default(HttpCookie);
                myCookie = Request.Cookies[i];
                myCookie.Value = string.Empty;
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Set(myCookie);
            }
        }

        protected void lbtnRegister_Click(object sender, EventArgs e)
        {
            if (UserRegistration == "Yes")
            {
                hdnDisplayReg.Value = "1";
                ctrlLogin.Visible = false;
                //ctrlRegistration.Visible = true;
            }
        }

    }
}