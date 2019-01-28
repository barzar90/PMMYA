using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace PMMYA.Masters.WebAppForms
{
    public partial class AppForms : MAHAITMasterPage
    {
        public string FormTitle { get { return FormHeader.FormTitle; } set { FormHeader.FormTitle = value; } }

        protected void Page_Init(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == false)
            {
                System.Web.Security.FormsAuthentication.SignOut();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('सत्र कालावधी समाप्त!!');location.href=('~/Account/Login/Login.aspx')", true);

                return;
            }
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1;

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        private void checkAuthSessions()
        {

            if ((Session["AuthToken"] == null) || (Convert.ToString(Session["AuthToken"]) == string.Empty))
            {
                System.Web.Security.FormsAuthentication.SignOut();

               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('सत्र कालावधी समाप्त!!');location.href=('~/Account/Login/Login.aspx')", true);

                return;
            }
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                System.Web.Security.FormsAuthentication.SignOut();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('सत्र कालावधी समाप्त!!');location.href=('~/Account/Login/Login.aspx')", true);
             
                return;
            }

            if (Convert.ToString(Session["AuthToken"]) != Convert.ToString(Request.Cookies["AuthToken"].Value))
            {
                System.Web.Security.FormsAuthentication.SignOut();

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('सत्र कालावधी समाप्त!!');location.href=('~/Account/Login/Login.aspx')", true);
                return;
            }

        }


        private void guardCSRFNew()
        {


            if ((Convert.ToString(Session["hdnRandomToken"]) != string.Empty) || Session["hdnRandomToken"] !=null)
            {
                if (Convert.ToString(hdnRandomToken.Value) != Convert.ToString(Session["hdnRandomToken"]))
                {
                    HttpContext.Current.Profile.SetPropertyValue("RandomToken", string.Empty);
                    Response.Redirect("~/Account/Login/Login.aspx");
                }
                else
                {
                    HttpContext.Current.Profile.SetPropertyValue("RandomToken", Guid.NewGuid().ToString());
                    Session["hdnRandomToken"] = Convert.ToString(HttpContext.Current.Profile.GetPropertyValue("RandomToken"));
                    hdnRandomToken.Value = Convert.ToString(HttpContext.Current.Profile.GetPropertyValue("RandomToken"));
                }
            }
            else
            {
                HttpContext.Current.Profile.SetPropertyValue("RandomToken", Guid.NewGuid().ToString());
                Session["hdnRandomToken"] = Convert.ToString(HttpContext.Current.Profile.GetPropertyValue("RandomToken"));
                hdnRandomToken.Value = Convert.ToString(HttpContext.Current.Profile.GetPropertyValue("RandomToken"));
            }

           

            if (hdnRandomToken.Value == string.Empty || hdnRandomToken.Value == "")
            {
                System.Web.Security.FormsAuthentication.SignOut();
          }

        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["hdnRandomToken"] = null;
                 
            }


            checkAuthSessions();
            if (System.Configuration.ConfigurationManager.AppSettings["IsRandomCheck"].ToLower() == "yes")
            {
                guardCSRFNew();
            }
            Culture = FormHeader.SetCulture1.MAHAITCurrentCultureID;
            
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

    }
}