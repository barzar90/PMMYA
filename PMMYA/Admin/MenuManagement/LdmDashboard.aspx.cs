using BL;
using Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Admin.MenuManagement
{
    public partial class LdmDashboard : System.Web.UI.Page
    {
        #region Default
        private LDMFunSchema objLDMFunSchema = new LDMFunSchema();
        private LDMFunBAL objLDMFunBAL = new LDMFunBAL();
        private Feedback_BL objFeedback_BL = new Feedback_BL();
        private FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        private DataTable dt;
        private DataSet ds;
        private int result = 0;
        public const string SessionExcelData = "SessionExcelData";
        private string Role = string.Empty;
        public static int ddnm_static;
        public static int ddnm_static_District;
        private int LangID = 0;
        //private string sqlQuery;
        //private SqlConnection conn;
        private string spAction;
        #endregion

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"].Value != string.Empty)
                {
                    if ((Session["AuthToken"].ToString() != Request.Cookies["AuthToken"].Value))
                    {
                        Session.Abandon();
                        Session.Clear();
                        Session.RemoveAll();// Abandon the current session
                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1); // Clear the ASP.NET_SessionId cookie
                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddDays(-1); // Clear the Auth token                      
                        ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "alert('Your login session has expired!-GC!');location.href=('Login.aspx')", true);
                        return;
                    }
                }
                object ddnm = Session["LDM_DistrictId"];
                if (Convert.ToInt32(ddnm) == 100)
                {
                    grdAppFrm.Visible = true;
                    lblAppliedForm.Visible = true;
                }
                else
                {
                    grdAppFrm.Visible = false;
                    lblAppliedForm.Visible = false;

                }
                GetLDMContentShishu(Convert.ToInt32(ddnm));
                GetLDMContentKishore(Convert.ToInt32(ddnm));
                GetLDMContentTarun(Convert.ToInt32(ddnm));

                ddnm_static = Convert.ToInt32(ddnm);
                Role = Convert.ToString(Session["UserRole"]);
                GetBestFiveBanks();

                object ddnmdist = Session["LDM_DistrictId"];
                ddnm_static_District = Convert.ToInt32(ddnmdist);
                GetBestFiveDistricts();

                grdBindApplicationForm();


            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (LangID == 1)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";

            }
            else if (LangID == 3)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
            }
            else
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";

            }

            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            das_Shishu.Text = _MahaITUC.GetResourceValue("PhSecond", "das_Shishu", "");
            das_Kishore.Text = _MahaITUC.GetResourceValue("PhSecond", "das_Kishore", "");
            das_Tarun.Text = _MahaITUC.GetResourceValue("PhSecond", "das_Tarun", "");
        }

        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = HttpContext.GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        //Mahesh Added by kamlakar start

        public void grdBindApplicationForm()
        {
            objLDMFunSchema.ActionType = null;
            objLDMFunSchema.ApplicationID = 0;
            objLDMFunSchema.Status = null;
            ds = new DataSet();
            ds = objLDMFunBAL.GetApplicationForm(objLDMFunSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMessage.Visible = false;
                grdAppFrm.DataSource = ds;
                grdAppFrm.DataBind();
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Empty Does Not Exists";
            }
        }

        protected void grdAppFrm_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {           
            if (e.Row.RowType == DataControlRowType.DataRow && grdAppFrm.EditIndex == e.Row.RowIndex)
            {
                //e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                //e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                //// e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdAppFrm, "Select$" + e.Row.RowIndex);
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlStatus = (e.Row.FindControl("ddlAction") as DropDownList);
                    if (ddlStatus != null)
                    {
                        ddlStatus.Items.Add(new ListItem("Sanction", "1"));
                        ddlStatus.Items.Add(new ListItem("Rejected", "2"));
                        ddlStatus.Items.Add(new ListItem("Panding", "3"));
                        ddlStatus.DataValueField = "ID";
                        ddlStatus.DataTextField = "Text";
                        ddlStatus.DataBind();
                    }
                }
            }
        }

        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drp = (DropDownList)sender;
            GridViewRow gv = (GridViewRow)drp.NamingContainer;
            if (gv != null)
            {
                if ((gv.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlModel = (DropDownList)gv.FindControl("ddlAction");
                    ddlModel.Items.Add(new ListItem("Sanction", "1"));
                    ddlModel.Items.Add(new ListItem("Rejected", "2"));
                    ddlModel.Items.Add(new ListItem("Panding", "3"));
                    ddlModel.DataValueField = "Id";
                    ddlModel.DataTextField = "Text";
                    ddlModel.DataBind();
                }
            }
            int index = gv.RowIndex;
            DropDownList DropDownList1 = (DropDownList)grdAppFrm.Rows[index].FindControl("ddlAction");
            if (DropDownList1.SelectedItem.Text == "Sanction")
            {
                GridViewRow rows = grdAppFrm.Rows[gv.RowIndex];
                DropDownList ddlStatus = (DropDownList)rows.FindControl("ddlAction");
                string dropdownvalue = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Value;
                string dropdowntext = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Text;
                string applicationId = (grdAppFrm.Rows[gv.RowIndex].FindControl("ctl00") as TextBox).Text;                
                spAction = "Update";              
                UpdateBindApplicationForm(spAction, applicationId, dropdowntext);
            }
            else if (DropDownList1.SelectedItem.Text == "Rejected")
            {
                GridViewRow rows = grdAppFrm.Rows[gv.RowIndex];
                DropDownList ddlStatus = (DropDownList)rows.FindControl("ddlAction");
                string dropdownvalue = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Value;
                string dropdowntext = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Text;
                string applicationId = (grdAppFrm.Rows[gv.RowIndex].FindControl("ctl00") as TextBox).Text;
                spAction = "Update";
                //SelectBindApplicationForm(spAction, applicationId, dropdowntext);
                UpdateBindApplicationForm(spAction, applicationId, dropdowntext);       
            }
            else
            {
                GridViewRow rows = grdAppFrm.Rows[gv.RowIndex];
                DropDownList ddlStatus = (DropDownList)rows.FindControl("ddlAction");
                string dropdownvalue = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Value;
                string dropdowntext = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Text;
                string applicationId = (grdAppFrm.Rows[gv.RowIndex].FindControl("ctl00") as TextBox).Text;
                spAction = "Update";
                //SelectBindApplicationForm(spAction, applicationId, dropdowntext);
                UpdateBindApplicationForm(spAction, applicationId, dropdowntext);              
            }
        }

        protected void grdAppFrm_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAppFrm.EditIndex = -1;
            grdBindApplicationForm();
        }

        protected void grdAppFrm_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAppFrm.EditIndex = e.NewEditIndex;
            grdBindApplicationForm();
        }

        protected void grdAppFrm_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdAppFrm.Rows[e.RowIndex];
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlAction");
            string dropdownvalue = (grdAppFrm.Rows[e.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Value;
            string dropdowntext = (grdAppFrm.Rows[e.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Text;
            string applicationId = (grdAppFrm.Rows[e.RowIndex].FindControl("ctl00") as TextBox).Text;
            spAction = "Update";
            UpdateBindApplicationForm(spAction, applicationId, dropdowntext);
        }

        public void UpdateBindApplicationForm(string spAction, string appId, string status)
        {
            ds = new DataSet();
            ds = objLDMFunBAL.UpdateApplicationForm(spAction, appId, status);
            grdAppFrm.EditIndex = -1;
            grdBindApplicationForm();
            //Mahesh Patel Code error
            //if (ds.Tables.Count != 0)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        lblMessage.Visible = false;
            //        grdAppFrm.DataSource = ds;
            //        grdAppFrm.DataBind();
            //    }
            //    else
            //    {
            //        lblMessage.Visible = true;
            //        lblMessage.Text = "Empty Does Not Exists";
            //    }
            //}            
        }

        public void SelectBindApplicationForm(string spAction, string appId, string status)
        {
            ds = new DataSet();
            ds = objLDMFunBAL.SelectApplicationForm(spAction, appId, status);
            dt = ds.Tables["Table"];
            StringBuilder html = new StringBuilder();
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }
            html.Append("</table>");
            string body = PopulateBody("Username", "Title", "Url", html.ToString());
            SendHtmlFormattedEmail("er.mahesh90@gmail.com", "Pradhan Mantri Mudra Yojna Loan Applied Status", body);
            grdAppFrm.EditIndex = -1;
            grdBindApplicationForm();
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("mahaitmahesh@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress("er.mahesh90@gmail.com"));
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = Convert.ToBoolean("true")
                };
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential
                {
                    //Sendername add kiya h
                    UserName = "mahaitmahesh@gmail.com",
                    Password = "barzar90"
                };
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        private string PopulateBody(string userName, string title, string url, string description)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate/LdmEmailTemplate.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{Title}", title);
            body = body.Replace("{Url}", url);
            body = body.Replace("{Description}", description);
            return body;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            string filename = "LDM_Form_Excel_File" + "_" + DateTime.Now.ToString().Replace("/", "-") + ".xls";
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/ms-excel";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdAppFrm.AllowPaging = false;
            //var ddnm = Session["LDM_DistrictId"];
            //GetBankViewReport(Convert.ToInt32(ddnm));
            DropDownList drp = (DropDownList)sender;
            GridViewRow gv = (GridViewRow)drp.NamingContainer;
            string dropdownvalue = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Value;
            string dropdowntext = (grdAppFrm.Rows[gv.RowIndex].FindControl("ddlAction") as DropDownList).SelectedItem.Text;
            string applicationId = (grdAppFrm.Rows[gv.RowIndex].FindControl("ctl00") as TextBox).Text;
            spAction = "Select";
            SelectBindApplicationForm(spAction, applicationId, dropdowntext);
            DateTime datetime = DateTime.Now;
            int senssionDate = Convert.ToInt32(datetime.Year.ToString().Substring(2, 2).ToString());
            int ss = senssionDate + 1;
            grdAppFrm.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int i = 0; i < grdAppFrm.HeaderRow.Cells.Count; i++)
            {
                grdAppFrm.HeaderRow.Cells[i].Text = "";
            }
            grdAppFrm.RenderControl(htw);
            string headerTable = @"<table style='font - weight: bold; text - align: center; font - size: 15px; background: #D4EED1;' border='1' width='100%'><tbody><tr><td colspan='33'>Pradhan Mantri Mudra Yojana LDM Form Excel File" + DateTime.Now.Year + " - " + ss + "</td></tr><tr><td>Sr. No.</td><td>Name of the Bank</td><td>Name of Bank Branch</td><td>Branch IFSC Code</td><td>Application/reg istration Number</td><td>Loan Category under PMMY (e.g. Shishu/Kishor/ Tarun)</td><td>Applicant's First name</td><td>Middle name</td><td>Last Name</td><td>Gender</td><td>Matiral Status</td><td>Date of Birth (MM/DD /YYYY)</td><td>Village/L ocality name</td><td>Gram Panchayat/A rea</td><td>Tehsil/W ard</td><td>Block</td><td>District</td><td>Religion</td><td>If Minority Communi ty then pl. specify (Buddhist /Sikh/Jai n/Muslim /Christia n/Zoroas trians)</td><td>Social Categor y</td><td>Aadhar no.</td><td>PAN Card No.</td><td>Mobile Number</td><td>Email Address</td><td>Loan Amount Requeste d</td><td>Sanction ed Amount</td><td>Sanction ed Date (MM/DD /YYYY)</td><td>Name of Business Activity</td><td>Type of Loan (e.g. CC/OD/T erm Loan etc)</td><td>Disbursed amount</td><td>Date of Disburse ment (MM/DD /YYYY)</td><td>Amou nt of Loan Outsta nding as on</td><td>Annual Target</td></tr></tbody></table>";
            HttpContext.Current.Response.Write(headerTable);
            Response.Write(sw.ToString());
            Response.End();
        }

        //Mahesh Added by kamlakar End    

        [WebMethod]
        public static List<Data> GetBestFiveBanks()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            LDMFunSchema objLDMFunSchema = new LDMFunSchema();
            LDMFunBAL objLDMFunBAL = new LDMFunBAL();
            objLDMFunSchema.Districtid = Convert.ToInt32(ddnm_static);
            ds = objLDMFunBAL.GetTopBestBank(objLDMFunSchema);
            dt = ds.Tables[0];
            List<Data> dataList = new List<Data>();
            string cat = "";
            int val = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cat = dr[0].ToString();
                val = Convert.ToInt32(dr[1]);
                dataList.Add(new Data(cat, val));
            }
            //string str = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
            //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            //string bankdata = JsonConvert.DeserializeObject(str.ToString()).ToString();
            return dataList;
        }

        [WebMethod]
        public static List<Data> GetBestFiveDistricts()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            LDMFunSchema objLDMFunSchema = new LDMFunSchema();
            LDMFunBAL objLDMFunBAL = new LDMFunBAL();
            objLDMFunSchema.Districtid = Convert.ToInt32(ddnm_static_District);
            ds = objLDMFunBAL.GetTopBestDistrict(objLDMFunSchema);
            dt = ds.Tables[0];
            List<Data> dataListDist = new List<Data>();
            string cat = "";
            int val = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cat = dr[0].ToString();
                val = Convert.ToInt32(dr[1]);
                dataListDist.Add(new Data(cat, val));
            }
            return dataListDist;
        }

        public void GetLDMContentShishu(int ddnm)
        {
            try
            {
                objLDMFunSchema.Districtid = ddnm;
                ds = new DataSet();
                ds = objLDMFunBAL.GetLDMContentShishu(objLDMFunSchema);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ShishuApplicationNum.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShiAccount"]));
                    ShishuSanctionAmt.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShiSanctionAmnt"]));
                    ShishuDisburseAmt.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["ShiDisbursedAmnt"]));
                }
                else
                {
                    ShishuApplicationNum.Text = "Information not Available !!!";
                }
            }
            finally
            {

            }
        }

        public void GetLDMContentKishore(int ddnm)
        {
            try
            {
                objLDMFunSchema.Districtid = ddnm;
                ds = new DataSet();
                ds = objLDMFunBAL.GetLDMContentKishore(objLDMFunSchema);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    KishoreApplicationNum.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["KisAccount"]));
                    KishoreSanctionAmt.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["KisSanctionAmnt"]));
                    KishoreDisburseAmt.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["KisDisbursedAmnt"]));
                }
                else
                {
                    KishoreApplicationNum.Text = "Information not Available !!!";
                }
            }
            finally
            {

            }
        }

        public void GetLDMContentTarun(int ddnm)
        {
            try
            {
                objLDMFunSchema.Districtid = ddnm;
                ds = new DataSet();
                ds = objLDMFunBAL.GetLDMContentTarun(objLDMFunSchema);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    TarunApplicationNum.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["TarAccount"]));
                    TarunSanctionAmt.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["TarSanctionAmnt"]));
                    TarunDisburseAmt.Text = HttpUtility.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["TarDisbursedAmnt"]));
                }
                else
                {
                    TarunApplicationNum.Text = "Information not Available !!!";
                }
            }
            finally
            {

            }
        }

      
    }
}