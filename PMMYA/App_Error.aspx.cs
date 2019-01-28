using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using BL;
using Schema;

namespace PMMYA
{
    public partial class App_Error : MAHAITPage
    {
        protected HttpException ex = null;
        AppErrorBL objappErrorBL = new AppErrorBL();
        AppErrorSchema objAppErrorSchema = new AppErrorSchema();

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //}

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            lUhHo.Text = GetResourceValue("Common", "App_Error_Head", "");
            lText.Text = GetResourceValue("Common", "App_Error_Text", "");
            bReport.Text = GetResourceValue("Common", "App_Error_ReportUs", "");

            //if (Request.QueryString["ErrorCode"] == null) return;
            //if (Request.QueryString["ErrorCode"] != string.Empty)
            //{
            //    lblErrorMessage.Text = GetResourceValue("AppError", Convert.ToString(Request.QueryString["ErrorCode"]), "");
            //}
        }

        //public HttpStatusCode GetHeaders(string url)
        //{
        //    HttpStatusCode result = default(HttpStatusCode);

        //    var request = HttpWebRequest.Create(url);
        //    request.Method = "HEAD";
        //    using (var response = request.GetResponse() as HttpWebResponse)
        //    {
        //        if (response != null)
        //        {
        //            result = response.StatusCode;
        //            response.Close();
        //        }
        //    }

        //    return result;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["User"] = null;      
                this.lExceptionId.Text = Convert.ToString(Request.QueryString["ExceptionId"]);
                if (this.lExceptionId.Text != string.Empty)
                {
                    Session.Clear();
                    Session.Abandon();
                    Session.RemoveAll();
                }
            }
        }

        public int SetErrorLog(HttpException exception, string userIp, string browser, string browserVersion)
        {
            objAppErrorSchema.ErrorCode = exception.ErrorCode.ToString();
            objAppErrorSchema.Message = exception.Message;
            objAppErrorSchema.Type = exception.GetType().ToString();
            objAppErrorSchema.StackTrace = exception.StackTrace;
            objAppErrorSchema.InnerException = Convert.ToString(exception.InnerException);
            objAppErrorSchema.HtmlError = (exception.GetHtmlErrorMessage() == null) ? string.Empty : exception.GetHtmlErrorMessage();
            objAppErrorSchema.UserIp = userIp;
            objAppErrorSchema.Browser = browser;
            objAppErrorSchema.BrowserVersion = browserVersion;

            int exceptionId;
            try
            {
                exceptionId = objappErrorBL.SaveAppErrorDeatails(objAppErrorSchema);
            }
            catch (Exception ex)
            {
                exceptionId = -1;
                throw ex;
            }
            finally
            {
                
            }

            return exceptionId;
        }

        private DataTable GetErrorLog(string strExceptionID)
        {
            DataSet source;
            objAppErrorSchema.ErrorId = !string.IsNullOrWhiteSpace(this.lExceptionId.Text) ? Convert.ToInt32(this.lExceptionId.Text) : 0; 
            source = objappErrorBL.GetErrorLogList(objAppErrorSchema);

            return source.Tables[0];
        }

        //private void checkAuthSessions()
        //{

        //    if ((Session["AuthToken"] == null) || (Convert.ToString(Session["AuthToken"]) == string.Empty))
        //    {
        //        System.Web.Security.FormsAuthentication.SignOut();

        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('सत्र कालावधी समाप्त!!');location.href=('~/Account/Login/Login.aspx')", true);

        //        return;
        //    }
        //    if (!HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        System.Web.Security.FormsAuthentication.SignOut();

        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('सत्र कालावधी समाप्त!!');location.href=('~/Account/Login/Login.aspx')", true);

        //        return;
        //    }

        //    if (Convert.ToString(Session["AuthToken"]) != Convert.ToString(Request.Cookies["AuthToken"].Value))
        //    {
        //        System.Web.Security.FormsAuthentication.SignOut();

        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MyScript", "alert('सत्र कालावधी समाप्त!!');location.href=('~/Account/Login/Login.aspx')", true);

        //        return;
        //    }



        //}

        //protected void Page_Unload(object sender, EventArgs e)
        //{
            // Response.Write("hello");
       // }

        protected void bReport_Click(object sender, EventArgs e)
        {
            string body;

            DataTable source;

            try
            {
                if (this.lExceptionId.Text.Length == 0) { return; }

                source = GetErrorLog(this.lExceptionId.Text);

                if (source == null) { return; }

                if (source.Rows.Count > 0)
                {
                    body = string.Format(@"
                            <html>
                            <body>
                                <h1>An Error Has Occurred!</h1>
                                <table cellpadding=""5"" cellspacing=""0"" border=""1"">
                                <tr>
                                <td text-align: right;font-weight: bold"">URL:</td>
                                <td>{0}</td>
                                </tr>
                                <tr>
                                <td text-align: right;font-weight: bold"">Error Code:</td>
                                <td>{1}</td>
                                </tr>
                                <tr>
                                <td text-align: right;font-weight: bold"">Exception Type:</td>
                                <td>{2}</td>
                                </tr>
                                <tr>
                                <td text-align: right;font-weight: bold"">Message:</td>
                                <td>{3}</td>
                                </tr>
                                <tr>
                                <td text-align: right;font-weight: bold"">Stack Trace:</td>
                                <td>{4}</td>
                                </tr>
                                <tr>
                                <td text-align: right;font-weight: bold"">Inner Exception:</td>
                                <td>{5}</td>
                                </tr> 
                                <tr>
                                <td text-align: right;font-weight: bold"">User Ip:</td>
                                <td>{6}</td>
                                </tr>
                                <tr>
                                <td text-align: right;font-weight: bold"">Browser:</td>
                                <td>{7}</td>
                                </tr> 
                                <tr>
                                <td text-align: right;font-weight: bold"">Browser Version:</td>
                                <td>{8}</td>
                                </tr> 
                                </table>
                            </body>
                            </html>",
                                    Request.RawUrl, source.Rows[0]["ErrorCode"], source.Rows[0]["Type"], source.Rows[0]["Message"],
                                    source.Rows[0]["StackTrace"].ToString().Replace(Environment.NewLine, "<br />"), source.Rows[0]["InnerException"],
                                    source.Rows[0]["UserIp"], source.Rows[0]["Browser"], source.Rows[0]["BrowserVersion"]);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}