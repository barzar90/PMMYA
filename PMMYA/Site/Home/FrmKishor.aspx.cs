using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Net;
using System.Data;
using Schema;
using BL;
using System.Configuration;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;

namespace PMMYA.Site.Home
{
    public partial class FrmKishor : System.Web.UI.Page
    {
        #region Public variable declaration
        ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
        ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
        Feedback_BL objFeedback_BL = new Feedback_BL();
        FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        DataTable dt;
        DataSet ds;
        EmailBL objemail = new EmailBL();
        EmailSchema ObjEmailSchema = new EmailSchema();
        SendSMS objSendSMS = new SendSMS();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Request.QueryString["ApplicationId"]) != null || Convert.ToString(Request.QueryString["ApplicationId"]) != "")
                {
                    string Applicationid = string.Empty;
                    Applicationid = Request.QueryString["ApplicationId"];
                    // Applicationid = "1809105054028051007";
                    GetApplicationDetails(Applicationid);
                    ConvertToPDF(Applicationid);
                }
                else
                {
                    Server.Transfer("FrmShishu.aspx");
                }


            }
        }
        private void GetApplicationDetails(string ApplicationId)
        {
            objApplicationFormSchema.ApplicationID = ApplicationId;
            ds = objApplicationFormBAL.GetLoanApplicationDetail(objApplicationFormSchema);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblEnterpriseName.Text = Convert.ToString("-");
                LblApplicationSrNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApplicationId"]);
                LblBranchName.Text = Convert.ToString(ds.Tables[0].Rows[0]["BranchName"]);
                lblEnterpriseName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstHolderName"]);
                lblNameofEnterprise.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstHolderName"]);
                LblLoanType.Text = Convert.ToString(ds.Tables[0].Rows[0]["MudraLoanType"]);
                //lblFirstHolderFatherName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FaterOrHusbandName"]);
                lblConstitution.Text = Convert.ToString(ds.Tables[0].Rows[0]["ConstitutionName"]);
                //LblResidentialAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["ResidentialAddress"]);
                //LblResidentialAddType.Text = Convert.ToString(ds.Tables[0].Rows[0]["ResiAddrType"]);
                LblBusinessAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusinessAddress"]);
                LblBusinessAddType.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusiAddrType"]);
                //lblDOB.Text = Convert.ToString(ds.Tables[0].Rows[0]["DOB"]);
                //lblAge.Text = Convert.ToString(ds.Tables[0].Rows[0]["Age"]);
                //LblGender.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                //LblEducationQualification.Text = Convert.ToString(ds.Tables[0].Rows[0]["EduQualification"]);
                //lblIdproofVoterNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_VoterIDNo"]);
                //lblIdproofAadharNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_AadharNo"]);
                //lblIdproofDLN.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_DrivingLicNo"]);
                //lblIdproofother.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycID_OtherIDNo"]);
                //lblAddproofVoterNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_VoterIDNo"]);
                //LblAddAadharNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_AadharNo"]);
                //LblAddproofDLN.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_DrivingLicNo"]);
                //LblAddproofOther.Text = Convert.ToString(ds.Tables[0].Rows[0]["KycAddr_OtherIDNo"]);
                LblTelephoneNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["TelPhNo"]);
                LblMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                LblEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailId"]);
                LblLineofBusiness.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusinessType"]);
                //LblPeriod.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtBusinessPeriod"]);
                //lblAnnualSalesExisting.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnnualSaleExt"]);
                //lblAnnualSalesProposed.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnnualSaleProp"]);
                //LblExperience.Text = Convert.ToString(ds.Tables[0].Rows[0]["BusinessExperience"]);
                LblSocialCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["SocialCategory"]);
                // lblMinority.Text = Convert.ToString(ds.Tables[0].Rows[0]["MinorityCommunity"]);
                //lblLoanCCOD.Text = Convert.ToString(ds.Tables[0].Rows[0]["MinorityCommunity"]);
                //lblBankLoanType.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankLoanType"]);
                //lblLoanCCOD.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankLoanType"]);
                //lblLoanAmountReq.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoanAmount"]);
                //LblMudraLoanType.Text = Convert.ToString(ds.Tables[0].Rows[0]["MudraLoanType"]);
                //LblLoanccodtermAmmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoanAmount"]);
                //LblLoanAmountExisting.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtLoanAmount"]);
                //LblExistingLoanType.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtAccountType"]);
                //LblExistingBankNameAdd.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtBankName"]); //+ "; Branch Name:-"+ Convert.ToString(ds.Tables[0].Rows[0]["ExtBankBranch"]);
                //LblExistingAccountNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtBankAccNo"]);
                //LblLoanAmountExisting.Text = Convert.ToString(ds.Tables[0].Rows[0]["ExtLoanAmount"]);
            }


        }

        private void ConvertToPDF(string ApplicationId)

        {
            string imagepath = Server.MapPath("~/Images"); Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //string fromusername = ConfigurationManager.AppSettings["userNameEmail"];
            //string Tousername = ConfigurationManager.AppSettings["TouserName"];
            //string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            //string cc1username = ConfigurationManager.AppSettings["NotificationtoDepartment1"];
            //string cc2username = ConfigurationManager.AppSettings["NotificationtoDepartment2"];
            using (MemoryStream memoryStream = new MemoryStream())
            {
                iTextSharp.text.Image addLogo = default(iTextSharp.text.Image);
                // iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
                addLogo = iTextSharp.text.Image.GetInstance(imagepath + "/logo.png");

                iTextSharp.text.Image BankLogo = default(iTextSharp.text.Image);
                // iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(imagepath + "/mudra.jpg");
                BankLogo = iTextSharp.text.Image.GetInstance(imagepath + "/logo.png");
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);


                // addLogo.SetAbsolutePosition(0, docWorkingDocument.PageSize.Height - 100)

                pdfDoc.Open();
                addLogo.ScaleToFit(128, 37);
                addLogo.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                pdfDoc.Add(addLogo);

                htmlparser.Parse(sr);

                pdfDoc.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();

                // Added by Anand Dated on 04-10-2018

                ObjEmailSchema.ApplicationID = ApplicationId;
                string Mobile = string.Empty;

                ds = new DataSet();
                ds = objemail.GetEmailDetails(ObjEmailSchema);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string t_XMLName = HttpContext.Current.Server.MapPath("~/APP_Data/MailConfig.XML");
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(t_XMLName);
                    XmlNode xnod = xmlDoc.DocumentElement;
                    XmlNodeList nodeList = xnod.SelectNodes("Mail");

                    Mobile = ds.Tables[0].Rows[0]["MobileNo"].ToString().Trim();

                    objSendSMS.SMSSend(Mobile, ObjEmailSchema.ApplicationID, "application");

                    foreach (XmlNode _node in nodeList)
                    {
                        String SMTPstr = string.Empty, Portstr = string.Empty, FromEamil = string.Empty, To = string.Empty, Subject = string.Empty, Body = string.Empty, BodyU = string.Empty, FromEmailPwd = string.Empty;

                        //SMTPstr = _node.SelectSingleNode("host").InnerText.Trim();
                        //Portstr = _node.SelectSingleNode("port").InnerText.Trim();
                        //FromEamil = _node.SelectSingleNode("from").InnerText.Trim();
                        //FromEmailPwd = _node.SelectSingleNode("pwd").InnerText.Trim();

                        String SMTP_HOST_NAME = ConfigurationManager.AppSettings["host"];
                        String SMTP_AUTH_USER = ConfigurationManager.AppSettings["FromEmail"];
                        String SMTP_AUTH_PWD = ConfigurationManager.AppSettings["EmailPassword"];

                        if (_node.Attributes["Profile"].Value.ToString().ToLower() == "pmmycustomer")
                        {
                            To = ds.Tables[0].Rows[0]["CustEmailID"].ToString().Trim();

                            Subject = _node.SelectSingleNode("subject").InnerText.Trim();
                            Body = _node.SelectSingleNode("body").InnerText.Trim();

                            Subject = Subject.Replace("#ApplicationID", ds.Tables[0].Rows[0]["ApplicationID"].ToString().Trim());
                            Subject = Subject.Replace("#LoanType", ds.Tables[0].Rows[0]["LoanType"].ToString().Trim());

                            Body = Body.Replace("#ApplicantName", ds.Tables[0].Rows[0]["ApplicantName"].ToString().Trim());
                            Body = Body.Replace("#ApplicationID", ds.Tables[0].Rows[0]["ApplicationID"].ToString().Trim());
                            Body = Body.Replace("#LoanType", ds.Tables[0].Rows[0]["LoanType"].ToString().Trim());
                            Body = Body.Replace("#ApplicationDate", ds.Tables[0].Rows[0]["ApplicationDate"].ToString().Trim());
                        }

                        if (_node.Attributes["Profile"].Value.ToString().ToLower() == "pmmydpo")
                        {
                            To = ds.Tables[0].Rows[0]["DPOEmailID"].ToString().Trim();
                            //To = "se1.mahait@mahait.org";
                            Subject = _node.SelectSingleNode("subject").InnerText.Trim();
                            Body = _node.SelectSingleNode("body").InnerText.Trim();

                            Subject = Subject.Replace("#ApplicationID", ds.Tables[0].Rows[0]["ApplicationID"].ToString().Trim());
                            Subject = Subject.Replace("#LoanType", ds.Tables[0].Rows[0]["LoanType"].ToString().Trim());

                            Body = Body.Replace("#ApplicantName", ds.Tables[0].Rows[0]["ApplicantName"].ToString().Trim());
                            Body = Body.Replace("#ApplicationID", ds.Tables[0].Rows[0]["ApplicationID"].ToString().Trim());
                            Body = Body.Replace("#LoanType", ds.Tables[0].Rows[0]["LoanType"].ToString().Trim());
                        }

                        if (_node.Attributes["Profile"].Value.ToString().ToLower() == "pmmybank")
                        {
                            To = ds.Tables[0].Rows[0]["BankEmailID"].ToString().Trim();
                            //To = "se1.mahait@mahait.org";
                            Subject = _node.SelectSingleNode("subject").InnerText.Trim();
                            Body = _node.SelectSingleNode("body").InnerText.Trim();

                            Subject = Subject.Replace("#ApplicationID", ds.Tables[0].Rows[0]["ApplicationID"].ToString().Trim());
                            Subject = Subject.Replace("#LoanType", ds.Tables[0].Rows[0]["LoanType"].ToString().Trim());

                            Body = Body.Replace("#ApplicantName", ds.Tables[0].Rows[0]["ApplicantName"].ToString().Trim());
                            Body = Body.Replace("#ApplicationID", ds.Tables[0].Rows[0]["ApplicationID"].ToString().Trim());
                            Body = Body.Replace("#LoanType", ds.Tables[0].Rows[0]["LoanType"].ToString().Trim());
                        }

                        if (To.ToString() != "" || To.ToString().Trim() != string.Empty)
                        {
                            SmtpClient client = new SmtpClient();
                            client.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                            client.Host = SMTP_HOST_NAME;

                            client.EnableSsl = true;
                            client.Timeout = 600000;

                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new System.Net.NetworkCredential(SMTP_AUTH_USER, SMTP_AUTH_PWD);

                            MailMessage mm = new MailMessage(SMTP_AUTH_USER, To, Subject, Body);
                            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "" + Convert.ToString(ApplicationId) + ".pdf"));
                            mm.IsBodyHtml = true;
                            mm.BodyEncoding = UTF8Encoding.UTF8;
                            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                            { return true; };

                            client.Send(mm);

                            //using (MailMessage mm = new MailMessage(FromEamil, To))
                            //{
                            //    mm.Subject = Subject;
                            //    mm.Body = Body;
                            //    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "" + Convert.ToString(ApplicationId) + ".pdf"));
                            //    mm.IsBodyHtml = true;
                            //    using (SmtpClient smtp = new SmtpClient())
                            //    {
                            //        smtp.Host = SMTPstr;
                            //        smtp.EnableSsl = true;
                            //        NetworkCredential NetworkCred = new NetworkCredential();
                            //        NetworkCred.UserName = FromEamil;//"rechargeme2016@gmail.com ";
                            //        NetworkCred.Password = FromEmailPwd;//"Pass@123";
                            //        smtp.UseDefaultCredentials = true;
                            //        smtp.Credentials = NetworkCred;
                            //        smtp.Port = Convert.ToInt16(Portstr);
                            //        smtp.TargetName = "STARTTLS/smtp.gmail.com";
                            //        //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                            //        //{ return true; };
                            //        smtp.Send(mm);

                            //    }
                            //}
                        }
                    }

                    

                    Response.Redirect("FrmPMMYLoanForm.aspx");
                }
                //End  04-10-2018
            }
        }
    }
}