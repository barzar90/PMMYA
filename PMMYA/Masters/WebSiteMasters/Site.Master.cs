using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PMMYA.Controls.WebSiteControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Text;
using BL;

namespace PMMYA.Masters.WebSiteMasters
{
    public partial class Site : MAHAITMasterPage 
    {
        LastReviewedDate objLastReviewedDate = new LastReviewedDate();
        SetCulture objSetCulture = new SetCulture();
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ToString());

        protected void Page_Init(object sender, EventArgs e)
        {
           
            if (Request.Cookies[".ASPXANONYMOUS"] != null)
            {
                HttpCookie myCookie = new HttpCookie(".ASPXANONYMOUS");
                Request.Cookies[".ASPXANONYMOUS"].Value = "";
            }
            Response.Cookies[".ASPXAUTH"].Value = String.Empty;
            Response.Cookies.Remove(".ASPXAUTH");
            Request.Cookies.Remove(".ASPXAUTH");
        }

        protected void Page_Load(object sender, EventArgs e)
        {    
            Culture = HeaderMain1.SetCulture1.MAHAITCurrentCultureID;
            HeaderMain1.SetCulture1.ButtonClickedLarger += new EventHandler(SetCulture1_ButtonClickedLarger);
            HeaderMain1.SetCulture1.ButtonClickedLarge += new EventHandler(SetCulture1_ButtonClickedLarge);
            HeaderMain1.SetCulture1.ButtonClickedMedium += new EventHandler(SetCulture1_ButtonClickedMedium);
            HeaderMain1.SetCulture1.ButtonClickedSmall += new EventHandler(SetCulture1_ButtonClickedSmall);
            HeaderMain1.SetCulture1.ButtonClickedSmallest += new EventHandler(SetCulture1_ButtonClickedSmallest);
            HeaderMain1.SetCulture1.ButtonClickedABlack += new EventHandler(SetCulture1_ButtonClickedContrast);
            HeaderMain1.SetCulture1.ButtonClickedAWhite += new EventHandler(SetCulture1_ButtonClickedWhite);
            HeaderMain1.SetCulture1.ButtonClickedCultureSheet += new EventHandler(SetCulture1_ButtonClickedCultureSheet);

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
            {
                Link.Href = @"../../Styles/LayoutMR.css";
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                Link.Href = @"../../Styles/LayoutEN.css";
            }
            else
            {
                Link.Href = @"../../Styles/LayoutUR.css";
            }
                
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

        protected void SetCulture1_ButtonClickedLarger(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "larger");
        }

        protected void SetCulture1_ButtonClickedLarge(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "large");
        }
        protected void SetCulture1_ButtonClickedMedium(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "medium");
        }

        protected void SetCulture1_ButtonClickedSmall(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "small");
        }
        protected void SetCulture1_ButtonClickedSmallest(object sender, System.EventArgs e)
        {
            divnew.Attributes.Remove("class");
            divnew.Attributes.Add("class", "smaller");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
        }

        private void handleImproperSessionTermination()
        {

            if (string.IsNullOrEmpty(Session["User"].ToString()))
            {
                Session.RemoveAll();
                Session.Clear();
                Session.Abandon();
                HandleSessionFixation();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('Session has been Expired!!!');location.href=('Login.aspx')", true);
                return;
            }
        }


        private void checkAuthSessions()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Session.RemoveAll();
                Session.Clear();
                Session.Abandon();
                HandleSessionFixation();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('Session has been Expired!!!');location.href=('../InstituteDetails/TrustLogin.aspx')", true);

                return;
            }

            if (Session["UserName"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Session.RemoveAll();
                    Session.Clear();
                    Session.Abandon();
                    HandleSessionFixation();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('Session has been Expired!!!');location.href=('../InstituteDetails/TrustLogin.aspx')", true);
                    return;
                }
            }

        }

        private void showContent()
        {

            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

            string LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();

            string siteUrl = string.Empty;
            //siteUrl = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["SiteUrl"]);
            siteUrl = Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty);
            int MenuID = 0;

            if (this.Page.RouteData.Values["MenuID"] != null)
                Int32.TryParse(this.Page.RouteData.Values["MenuID"].ToString(), out MenuID);
            else
                if (Request.QueryString["MenuID"] != null)
                    Int32.TryParse(this.Request.QueryString["MenuID"].ToString(), out MenuID);

            SqlCommand t_SQLCmd = new SqlCommand();
            if (MenuID != 0)
            {
                string qry_Select = "";
                t_SQLCmd.Parameters.Add("@MenuID", SqlDbType.Int);
                t_SQLCmd.Parameters["@MenuID"].Value = MenuID;
                if (Convert.ToString(LangID).ToLower() == Convert.ToString("mr-IN").ToLower())
                    qry_Select = @"Exec spGetPrevNextMenu @MenuID";
                else
                    qry_Select = @"Exec spGetPrevNextMenu @MenuID";

                if (qry_Select != "")
                {
                    t_SQLCmd.CommandText = qry_Select;
                    DataSet ds = MAHAITDBAccess.ExecuteDataSet(t_SQLCmd);
                    if (ds != null)
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            //if (ds.Tables[2].Rows.Count > 0)
                            //{
                            DataRow dr1 = ds.Tables[0].Rows[0];
                            String strPrevURL = String.Empty, strPrevMenuName = String.Empty, strNextURL = String.Empty, strNextMenuName = String.Empty;

                            if (LangID == "en-IN")
                            {
                                strPrevURL = dr1["URL_Prev"].ToString().Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                                strPrevMenuName = dr1["MenuName_Prev"].ToString();
                                strNextURL = dr1["URL_Next"].ToString().Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                                strNextMenuName = dr1["MenuName_Next"].ToString();
                            }
                            else
                            {
                                strPrevURL = dr1["URL_LL_Prev"].ToString().Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                                strPrevMenuName = dr1["MenuName_LL_Prev"].ToString();
                                strNextURL = dr1["URL_LL_Next"].ToString().Replace("~", HttpUtility.UrlDecode(Request.Url.OriginalString).Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
                                strNextMenuName = dr1["MenuName_LL_Next"].ToString();
                            }
                            PMMYA.Masters.WebSiteMasters.Site masterPg = (PMMYA.Masters.WebSiteMasters.Site)this.Page.Master;                        
                        }
                }
            }
        }

        void Page_PreRender(Object o, EventArgs e)
        {
            showContent();
        }
    }
}