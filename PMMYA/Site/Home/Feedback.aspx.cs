using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.Configuration;
using Schema;
using BL;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text.RegularExpressions;

namespace PMMYA.Site.Home
{
    public partial class Feedback : MAHAITPage
    {
        #region Public variable declaration
        Feedback_BL objFeedback_BL = new Feedback_BL();
        FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        int result = 0;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        LoginBL loginBL = new LoginBL();
        DataTable dt;
        DataSet ds;
        #endregion

        #region PageEvents
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["format"] != null)
            {
                if (Convert.ToString(Request.QueryString["format"]) == "print")
                {
                    BreadCrum.Visible = false;
                }
            }
            if (!IsPostBack)
            {

                //For Numeric KeyPad in mobile, tablet
                if (MAHAITPage.isMobileBrowser() != string.Empty)
                {
                    txtMobile.Attributes.Add("type", "tel");
                }
                ViewState["IsRefresh"] = true;
            }

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            BindDistrict();
            lblDistrict.Text = _MahaITUC.GetResourceValue("FeedBack", "LblDistrict", "");
            lblFeedbackHeading.Text = _MahaITUC.GetResourceValue("FeedBack", "lblFeedbackHeading", "");
            lblName.Text = _MahaITUC.GetResourceValue("FeedBack", "lblName", "");
            lblEmail.Text = _MahaITUC.GetResourceValue("FeedBack", "lblEmail", "");
            lblMobile.Text = _MahaITUC.GetResourceValue("FeedBack", "lblMobile", "");
            lblSub.Text = _MahaITUC.GetResourceValue("FeedBack", "lblSub", "");
            btnSubmit.Text = _MahaITUC.GetResourceValue("FeedBack", "btnSubmit", "");
            btnReset.Text = _MahaITUC.GetResourceValue("FeedBack", "btnReset", "");
            lblFeedback.Text = _MahaITUC.GetResourceValue("FeedBack", "lblDescription", "");
            lblMandatory.Text = _MahaITUC.GetResourceValue("FeedBack", "lblMandatory", "");
            lblNote.Text= _MahaITUC.GetResourceValue("Common", "lblNote", "");
            Lblcaptcha.Text = _MahaITUC.GetResourceValue("Common", "Lblcaptcha", "");

            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() != Convert.ToString(ViewState["PreviousCulture"]))
            {
                ResetControls(false);
               // ShowData();
            }

            ViewState["PreviousCulture"] = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();

            if (ViewState["IsRefresh"] == null || Convert.ToBoolean(ViewState["IsRefresh"]))
            {
                ViewState["IsRefresh"] = false;
                //ucCaptcha.RefreshQuestion();
            }
        }
        #endregion

        #region Methods
        private void ShowData()
        {

            rfvName.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvName", "");
            RfvEmail.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "RfvEmail", "");
            revEmail.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "revEmail", "");
            rfvMobile.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvMobile", "");
            revMobile.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "revMobile", "");
            rfvddldistrict.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvDistrict", "");
            rfvFeedback.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvFeedback", "");
            rfvSubject.ErrorMessage = _MahaITUC.GetResourceValue("FeedBack", "rfvSubject", "");
            this.Page.Title = _MahaITUC.GetResourceValue("FeedBack", "PageTitle", "");
            
        }

        private void ResetControls(Boolean RefreshQuestion)
        {
            txtName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtMobile.Text = String.Empty;
            TxtSubject.Text = String.Empty;
            txtFeedback.Text = String.Empty;
            txtimgcode.Text = String.Empty;


        }

        private Boolean validatedata()
        {
            Boolean isvalid = true;
            string txtcap = "";
            if (txtimgcode.Text == null)
            {
                txtcap = _MahaITUC.GetResourceValue("FeedBack", "txtCaptcha", "");
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + txtcap + "');", true);
                isvalid = false;
            }
            return isvalid;
        }
        #endregion

        #region ButtonEvents
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (validatedata() == true)
                //{

                string msg = string.Empty;
                int conuter = 0;

                if (txtName.Text == "" && txtName.Text != null)
                {
                    msg +=  _MahaITUC.GetResourceValue("FeedBack", "rfvName", "");
                    conuter = 1;
                }

                if (txtEmail.Text == "" && txtEmail.Text != null)
                {
                    msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "RfvEmail", "");
                    conuter = 1;
                }

                //if (txtEmail.Text != "")
                //{
                //    Regex EmailMatch = new Regex("/^ ([/w -/.] +)@((/[[0-9]{1,3}/.[0-9]{1,3}/.[0-9]{1,3}/.)|(([/w -]+/.)+))([a - zA - Z]{2,4}|[0-9]{1,3})(/]?)$/");
                //    if (EmailMatch.IsMatch(txtEmail.Text))
                //    {

                //    }
                //    else
                //    {
                //        msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "ErrorValidEmail", "");
                //        conuter = 1;
                //    }
                //}

                //if (txtEmail.Text != "")
                //{
                //    Regex EmailMatch = new Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:/.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
                //    if (!EmailMatch.IsMatch(txtEmail.Text))
                //    {
                //        msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "ErrorValidEmail", "");
                //        conuter = 1;
                //    }
                //    //else
                //    //{
                      
                //    //}
                //}


                if (txtMobile.Text == "" && txtMobile.Text != null)
                {
                    msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "rfvMobile", "");
                    conuter = 1;
                }


                if (txtMobile.Text != "")
                {
                    Regex _MobileMatch = new Regex("^[789]\\d{9}$");
                    if (!_MobileMatch.IsMatch(txtMobile.Text))
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "ErrorValidMobile", "");
                        conuter = 1;
                    }
                }

                if (ddlDistrict.SelectedValue == "0")
                {
                    msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "rfvDistrict", "");
                    conuter = 1;
                }

                if (TxtSubject.Text == "" && TxtSubject.Text != null)
                {
                    msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "rfvSubject", "");
                    conuter = 1;
                }

                if (txtFeedback.Text == "" && txtFeedback.Text != null)
                {
                    msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "rfvFeedback", "");
                    conuter = 1;
                }

                if (txtimgcode.Text == "" && txtimgcode.Text != null)
                {
                    msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "txtCaptcha", "");
                    conuter = 1;
                }
                if (txtimgcode.Text != "")
                {
                    if (txtimgcode.Text != RemoveSpace(hdnCaptcha.Value.Trim().ToString()))
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("FeedBack", "txtCaptchavalid", "");
                        conuter = 1;
                    }
                }

                if (conuter == 0)
                {
                    string validate = "";

                    if (txtName.Text.Trim() == String.Empty)
                    {
                        validate = _MahaITUC.GetResourceValue("FeedBack", "rfvName", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + validate + "');", true);
                        txtName.Focus();
                        return;
                    }

                    if (txtFeedback.Text.Trim() == String.Empty)
                    {
                        validate = _MahaITUC.GetResourceValue("FeedBack", "rfvFeedback", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + validate + "');", true);
                        txtFeedback.Focus();
                        return;
                    }

                    if (txtimgcode.Text != RemoveSpace(hdnCaptcha.Value.Trim().ToString()))
                    {
                        validate = _MahaITUC.GetResourceValue("FeedBack", "txtCaptchavalid", "");
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + validate + "');", true);
                        return;
                    }

                    objFeedback_Schema.Name = txtName.Text.Trim();
                    objFeedback_Schema.Email = txtEmail.Text.Trim();
                    objFeedback_Schema.Contact = txtMobile.Text.Trim();
                    objFeedback_Schema.Subject = TxtSubject.Text.Trim();
                    objFeedback_Schema.Message = txtFeedback.Text.Trim();
                    objFeedback_Schema.Districtid = Convert.ToInt32(ddlDistrict.SelectedValue);


                    objFeedback_Schema.CreatedOn = DateTime.Now;
                    if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                    {
                        objFeedback_Schema.Langid = 2;
                    }
                    else if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                    {
                        objFeedback_Schema.Langid = 1;
                    }
                    else
                    {
                        objFeedback_Schema.Langid = 3;
                    }
                    result = objFeedback_BL.SaveFeedbackDeatails(objFeedback_Schema);
                    if (result > 0)
                    {
                        string mailcc = string.Empty;
                        string mailto = string.Empty;
                        string mailfrom = string.Empty;
                        string mailSubject = string.Empty;
                        string mailBody = string.Empty;
                        string Hostname = string.Empty;
                        string Port = string.Empty;

                        mailfrom = ConfigurationManager.AppSettings["FromEmail"]; //"rechargeme2016@gmail.com";
                        mailto = txtEmail.Text.Trim();
                        mailSubject = TxtSubject.Text.Trim();
                        mailBody = txtFeedback.Text.Trim();
                        Port = ConfigurationManager.AppSettings["port"];
                        Hostname = ConfigurationManager.AppSettings["host"];
                        objFeedback_Schema.Districtid = Convert.ToInt32(ddlDistrict.SelectedValue);
                        ds = objFeedback_BL.GetDPOEmail(objFeedback_Schema);
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            mailcc = dt.Rows[0]["Email_Id"].ToString();
                        }

                        SendEmail(mailfrom, mailto, mailSubject, mailBody, Hostname, Port, mailcc, "");

                        string savemsg = "";
                        savemsg = _MahaITUC.GetResourceValue("FeedBack", "Savemessage", "");
                        string msgheader = _MahaITUC.GetResourceValue("Common", "ErrorHeader", "");
                        //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('" + savemsg + "');", true);
                        System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alertPopup('" + msgheader + "','" + savemsg + "');", true);

                    }
                    ResetControls(true);
                }

                else
                {
                    string msgheader = _MahaITUC.GetResourceValue("Common", "ErrorHeader", "");
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alertPopup('" + msgheader + "','" + msg + "');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "alert('" + ex.Message + "')", true);
                return;
            }
            finally
            {
            }
        }

        private string RemoveSpace(string Captchastr)
        {
            StringBuilder sb = new StringBuilder();
            char[] longChars = Captchastr.ToCharArray();

            int spaceCount = 0;

            //Using standard method with no library help
            for (int i = 0; i < longChars.Length; i++)
            {
                //If space then keep a count and move on until nonspace char is found
                if (longChars[i] == 32)
                {
                    spaceCount++;
                    continue;
                }

                //If more than one space then append a single space  
                if (spaceCount > 1 && sb.Length > 0)
                    sb.Append("");

                //Append the non space character
                sb.Append(longChars[i]);

                //Reset the space count
                spaceCount = 1;
            }
            return sb.ToString();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetControls(true);
        }
        #endregion

        #region SendEmail
        private void SendEmail(string From, string To, string Subject, string Message, string hostAddress, string portaddress, string cc, string bcc)
        {
            String SMTP_HOST_NAME = ConfigurationManager.AppSettings["host"];
            String SMTP_AUTH_USER = ConfigurationManager.AppSettings["FromEmail"];
            String SMTP_AUTH_PWD = ConfigurationManager.AppSettings["EmailPassword"];
            String SMTP_AUTH_RECIPIENT = To;

            try
            {

                SmtpClient client = new SmtpClient();

                client.Port = 465;
                client.Host = SMTP_HOST_NAME;
                client.EnableSsl = true;
                client.Timeout = 10000;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(SMTP_AUTH_USER, SMTP_AUTH_PWD);

                MailMessage mm = new MailMessage(SMTP_AUTH_USER, SMTP_AUTH_RECIPIENT, Subject, Message);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

                client.Send(mm);

                
                lbl_msg.Text = "Email sent";
            }
            catch (Exception ex)
            {
                lbl_msg.Text = ex.ToString();
            }
        }
        #endregion

        private String GetURL(String strURLPath)
        {
            String strOrgUrl = Request.Url.OriginalString;
            String strPathQuery = Request.Url.PathAndQuery;
            String strSiteUrl = String.Empty;

            strSiteUrl = strOrgUrl.Replace(HttpUtility.UrlDecode(strPathQuery), string.Empty);
            if (strOrgUrl == strSiteUrl)
            {
                strSiteUrl = strOrgUrl.Replace(strPathQuery, string.Empty);
            }

            strURLPath = strURLPath.Replace("~", strSiteUrl);

            return strURLPath;
        }

        public void BindDistrict()
        {

            //if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            //{
            //    objFeedback_Schema.Langid = 1;
            //}
            //else
            //{
            //    objFeedback_Schema.Langid = 2;
            //}

            objFeedback_Schema.Langid = 1;

            ds = new DataSet();
            ds = objFeedback_BL.GetDistrict(objFeedback_Schema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlDistrict.DataSource = ds;
                ddlDistrict.DataTextField = "Districtname";
                ddlDistrict.DataValueField = "Districtcode";
                ddlDistrict.DataBind();
                if (objFeedback_Schema.Langid == 1)
                {
                    ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDistrict.SelectedValue = "0";
                }
                //else
                //{
                //    ddlDistrict.Items.Insert(0, new ListItem("--निवडा--", "0"));
                //    ddlDistrict.SelectedValue = "0";
                //}

            }
            else
            {
                if (objFeedback_Schema.Langid == 1)
                {
                    ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDistrict.SelectedValue = "0";
                }
                //else
                //{
                //    ddlDistrict.Items.Insert(0, new ListItem("--निवडा--", "0"));
                //    ddlDistrict.SelectedValue = "0";
                //}
            }
        }
    }
}