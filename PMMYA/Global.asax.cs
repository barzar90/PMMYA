using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Security.Principal;
using BL;
using System.Net.Http;
using System.Net;
using System.Configuration;
using System.Web.Configuration;

namespace PMMYA
{
    public class Global : HttpApplication
    {
        #region Public variable declaration

        #endregion

        protected void Application_Start(object sender, EventArgs e)
        {

         

            RegisterRoutes(RouteTable.Routes);

            string generateXMLPath = Server.MapPath("~/Scripts/GenerateXML.xml");
            DataSet ds = new DataSet("NewDataSet");
            ds.ReadXml(generateXMLPath);

            DataRow dr;

            dr = ds.Tables[0].NewRow();
            dr[0] = "<";
            ds.Tables[0].Rows.Add(dr);

            dr = ds.Tables[0].NewRow();
            dr[0] = ">";
            ds.Tables[0].Rows.Add(dr);

            for (int i = 65; i <= 90; i++)
            {
                dr = ds.Tables[0].NewRow();
                dr[0] = "&#" + i.ToString() + ";";
                ds.Tables[0].Rows.Add(dr);
            }

            for (int i = 97; i <= 122; i++)
            {
                dr = ds.Tables[0].NewRow();
                dr[0] = "&#" + i.ToString() + ";";
                ds.Tables[0].Rows.Add(dr);
            }

            Application["dtXML"] = ds.Tables[0];
        }

        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            try
            {
                DataSet t_ds;
                GlobalBAL ObjGlobalBAL = new GlobalBAL();
                t_ds = ObjGlobalBAL.GetRegisterRoutesData();

                foreach (DataRow row_T in t_ds.Tables[0].Rows)
                {
                    if (Convert.ToString(row_T["MenuTypeValue"]).Contains("~/"))
                    {
                        routeCollection.MapPageRoute(Convert.ToString(row_T["MenuID"]) + "_ME", "{MenuID}/" + Convert.ToString(row_T["MenuName"]).TrimStart().TrimEnd().Replace(" ", "-"), Convert.ToString(row_T["MenuTypeValue"]));
                        routeCollection.MapPageRoute(Convert.ToString(row_T["MenuID"]) + "_MM", "{MenuID}/" + Convert.ToString(row_T["MenuName_LL"]).TrimStart().TrimEnd().Replace(" ", "-"), Convert.ToString(row_T["MenuTypeValue"]));
                        routeCollection.MapPageRoute(Convert.ToString(row_T["MenuID"]) + "_MU", "{MenuID}/" + Convert.ToString(row_T["MenuName_UL"]).TrimStart().TrimEnd().Replace(" ", "-"), Convert.ToString(row_T["MenuTypeValue"]));
                    }
                }

                foreach (DataRow row_QM in t_ds.Tables[1].Rows)
                {
                    if (Convert.ToString(row_QM["MenuTypeValue"]).Contains("~/"))
                    {
                        routeCollection.MapPageRoute(Convert.ToString(row_QM["QuickMenuID"]) + "_QME", "{MenuID}/{QuickMenuID}/" + Convert.ToString(row_QM["QuickMenuName"]).TrimStart().TrimEnd().Replace(" ", "-"), Convert.ToString(row_QM["MenuTypeValue"]));
                        routeCollection.MapPageRoute(Convert.ToString(row_QM["QuickMenuID"]) + "_QMM", "{MenuID}/{QuickMenuID}/" + Convert.ToString(row_QM["QuickMenuName_LL"]).TrimStart().TrimEnd().Replace(" ", "-"), Convert.ToString(row_QM["MenuTypeValue"]));
                    }
                }

                foreach (DataRow row_MCT in t_ds.Tables[2].Rows)
                {
                    routeCollection.MapPageRoute(Convert.ToString(row_MCT["MenuContentID"]) + "_MCE", "{MenuID}/{ContentID}/" + Convert.ToString(row_MCT["PageTitle"]).TrimStart().TrimEnd().Replace(" ", "-"), "~/Site/Home/CMSContentMore.aspx");
                    routeCollection.MapPageRoute(Convert.ToString(row_MCT["MenuContentID"]) + "_MCM", "{MenuID}/{ContentID}/" + Convert.ToString(row_MCT["PageTitle_LL"]).TrimStart().TrimEnd().Replace(" ", "-"), "~/Site/Home/CMSContentMore.aspx");
                    //Added By K.P on 22-05-2018
                    routeCollection.MapPageRoute(Convert.ToString(row_MCT["MenuContentID"]) + "_MCM", "{MenuID}/{ContentID}/" + Convert.ToString(row_MCT["PageTitle_UL"]).TrimStart().TrimEnd().Replace(" ", "-"), "~/Site/Home/CMSContentMore.aspx");
                    //End
                }

                foreach (DataRow row_QMCT in t_ds.Tables[3].Rows)
                {
                    routeCollection.MapPageRoute(Convert.ToString(row_QMCT["QuickContentID"]) + "_QMCE", "{MenuID}/{QuickMenuID}/{QuickContentID}/" + Convert.ToString(row_QMCT["PageTitle"]).TrimStart().TrimEnd().Replace(" ", "-"), "~/Site/Home/CMSContentMore.aspx");
                    routeCollection.MapPageRoute(Convert.ToString(row_QMCT["QuickContentID"]) + "_QMCM", "{MenuID}/{QuickMenuID}/{QuickContentID}/" + Convert.ToString(row_QMCT["PageTitle_LL"]).TrimStart().TrimEnd().Replace(" ", "-"), "~/Site/Home/CMSContentMore.aspx");
                    //Added By K.P on 22-05-2018
                    routeCollection.MapPageRoute(Convert.ToString(row_QMCT["QuickContentID"]) + "_MCM", "{MenuID}/{ContentID}/" + Convert.ToString(row_QMCT["PageTitle_UL"]).TrimStart().TrimEnd().Replace(" ", "-"), "~/Site/Home/CMSContentMore.aspx");
                    //End
                }

            }
            catch (Exception ee)
            {
            }
            finally
            {
            }
        }

        // Added By Anand Dated on 04-01-2018
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Set("Server", "My httpd server");            
            Response.Headers.Remove("X-AspNet-Version");
            Response.Headers.Remove("X-AspNetMvc-Version");
        }
        //End

        protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            //Remove the "Server" HTTP Header from response
            HttpApplication app = sender as HttpApplication;
            if (null != app && null != app.Request && !app.Request.IsLocal &&
                null != app.Context && null != app.Context.Response)
            {
                NameValueCollection headers = app.Context.Response.Headers;
                if (null != headers)
                {
                    headers.Remove("Server");
                }
            }

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Response.Cookies[".ASPXANONYMOUS"].Path = "/App_Data/";
           // Response.Cookies["ASP.NET_SessionId"].Path = AppDomain.CurrentDomain.BaseDirectory;
            //Response.Cookies["ASP.NET_SessionId"].Secure = true;

        }

        private bool IsUrlValid(string url)
        {

            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        // XSS vulnerabilities  points
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            if (HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToLower().Contains("10.195.33.75")|| HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToLower().Contains("localhost") || HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToLower().Contains("117.255.216.196") || HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToLower().Contains("mahamudra"))
            {

                HttpContext.Current.Response.AddHeader("x-frame-options", "SAMEORIGIN");

                var application = sender as HttpApplication;
                if (application != null && application.Context != null)
                {
                    application.Context.Response.Headers.Remove("Server");
                }

                if (Application["dtXML"] == null)
                {
                    string generateXMLPath = Server.MapPath("~/Scripts/GenerateXML.xml");
                    DataSet ds = new DataSet("NewDataSet");
                    ds.ReadXml(generateXMLPath);

                    DataRow dr;
                    for (int i = 65; i <= 90; i++)
                    {
                        dr = ds.Tables[0].NewRow();
                        dr[0] = "&#" + i.ToString() + ";";
                        ds.Tables[0].Rows.Add(dr);
                    }

                    for (int i = 97; i <= 122; i++)
                    {
                        dr = ds.Tables[0].NewRow();
                        dr[0] = "&#" + i.ToString() + ";";
                        ds.Tables[0].Rows.Add(dr);
                    }

                    dr = ds.Tables[0].NewRow();
                    dr[0] = "ErrorCode";
                    ds.Tables[0].Rows.Add(dr);

                    Application["dtXML"] = ds.Tables[0];
                }
                DataTable dt = (DataTable)Application["dtXML"];
                foreach (DataRow dr1 in dt.Rows)
                {
                    if (Request.Url.OriginalString.Contains(dr1[0].ToString().Replace("'", String.Empty)))
                    {
                        Response.Redirect("~/App_Error.aspx?ExceptionId=0");
                        break;
                    }
                }
            }
            else
            {
                Response.Redirect("~/ErrorPage/App_Error.html");
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        // Get the stored user-data, in this case, our roles
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();
            if (ex == null || ex.Message.StartsWith("File") || (ex.Message.ToLower().Contains("file") && ex.Message.ToLower().Contains("does not exist")))
            {
                return;
            }
            App_Error _App_Error = new App_Error();
            try
            {
                int ExceptionId = _App_Error.SetErrorLog((HttpException)ex, Request.UserHostAddress, Request.Browser.Browser, Request.Browser.Version);
                Server.ClearError();
                //Response.Redirect("~/App_Error.aspx?ExceptionId=" + ExceptionId);
                Response.Redirect("~/ErrorPage/App_Error.html");

            }
            finally
            {
                _App_Error.Dispose();
                ex = null;
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        private void Application_EndRequest(object sender, EventArgs e)
        {
            //var sessionCookieKey = Response.Cookies.AllKeys.SingleOrDefault(c => c.ToLower() == "asp.net_sessionid");
            //var sessionCookie = Response.Cookies.Get(sessionCookieKey);
            //if (sessionCookie != null)
            //{
            //    sessionCookie.Secure = false;
            //}
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {  
            /// only apply session cookie persistence to requests requiring session information
            //if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
            //{
            //    var sessionState = ConfigurationManager.GetSection("system.web/sessionState") as SessionStateSection;
            //    var cookieName = sessionState != null && !string.IsNullOrEmpty(sessionState.CookieName) ? sessionState.CookieName : "ASP.NET_SessionId";

            //    var timeout = sessionState != null ? sessionState.Timeout : TimeSpan.FromMinutes(20);

            //    /// Ensure ASP.NET Session Cookies are accessible throughout the subdomains.
            //    if (Request.Cookies[cookieName] != null && Session != null && Session.SessionID != null)
            //    {  
            //            Response.Cookies[cookieName].Secure = true;
            //            Response.Cookies[cookieName].Path = Request.ApplicationPath + "App_Data/";
            //            Response.Cookies[cookieName].Expires = DateTime.Now.Add(timeout);
            //    }
            //}

            #region session cookie

            //if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)

            //{


            //    /// Ensure ASP.NET Session Cookies are accessible throughout the subdomains.

            //    if (Request.Cookies["ASP.NET_SessionId"] != null && Session != null && Session.SessionID != null)
            //    {

            //        Response.Cookies["ASP.NET_SessionId"].Value = Session.SessionID;
            //        // Response.Cookies["ASP.NET_SessionId"].Domain = ".know24.net"; // the full stop prefix denotes all sub domains

            //        Response.Cookies["ASP.NET_SessionId"].Path = Request.ApplicationPath; //default session cookie path root         

            //    }

            //}

            #endregion
        }
    }
}