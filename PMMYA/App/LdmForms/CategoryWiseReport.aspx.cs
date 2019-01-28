using BL;
using Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.App.LdmForms
{
    public partial class CategoryWiseReport : System.Web.UI.Page
    {
        #region Public variable declaration
        private LDMFunSchema objLDMFunSchema = new LDMFunSchema();
        private LDMFunBAL objLDMFunBAL = new LDMFunBAL();
        private Feedback_BL objFeedback_BL = new Feedback_BL();
        private FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        private DataTable dt;
        private DataSet ds;
        private int result = 0;
        public const string SessionExcelData = "SessionExcelData";        
        private string Role = string.Empty;
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
                var ddnm = Session["LDM_DistrictId"];
                Role = Convert.ToString(Session["UserRole"]);
                GetSocialCategoryViewReport(Convert.ToInt32(ddnm));
                SearchSocialCategory(Convert.ToInt32(ddnm));
            }
            //var ddnmm = Session["User"];
            var ddnmm = Session["LDM_DistrictId"];
            Role = Convert.ToString(Session["UserRole"]);
            GetSocialCategoryViewReport(Convert.ToInt32(ddnmm));
            SearchSocialCategory(Convert.ToInt32(ddnmm));
        }

        public void GetSocialCategoryViewReport(int ddnm)
        {
            try
            {
                objLDMFunSchema.Districtid = ddnm;

                objLDMFunSchema.ShiLoanCategory = "Shishu";
                objLDMFunSchema.KisLoanCategory = "Kishore";
                objLDMFunSchema.TarLoanCategory = "Tarun";
                ds = new DataSet();
                ds = objLDMFunBAL.GetSocialCategoryViewReport(objLDMFunSchema);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    grdReportCategory.DataSource = ds;
                    grdReportCategory.DataBind();
                    dt = ds.Tables["Table"];                           
                    int ShiACs = dt.AsEnumerable().Sum(row => row.Field<int>("ShiA/Cs"));
                    double ShiSanAmt = dt.AsEnumerable().Sum(row => row.Field<double>("ShiSanAmt"));
                    double ShiDisAmt = dt.AsEnumerable().Sum(row => row.Field<double>("ShiDisAmt"));
                    double ShiOutstandingAmt = dt.AsEnumerable().Sum(row => row.Field<double>("ShiOutstandingAmt"));                    
                    int KisACs = dt.AsEnumerable().Sum(row => row.Field<int>("KisA/Cs"));
                    double KisSanAmt = dt.AsEnumerable().Sum(row => row.Field<double>("KisSanAmt"));
                    double KisDisAmt = dt.AsEnumerable().Sum(row => row.Field<double>("KisDisAmt"));
                    double KisOutstandingAmt = dt.AsEnumerable().Sum(row => row.Field<double>("KisOutstandingAmt"));                    
                    int TarACs = dt.AsEnumerable().Sum(row => row.Field<int>("TarA/Cs"));
                    double TarSanAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TarSanAmt"));
                    double TarDisAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TarDisAmt"));
                    double TarOutstandingAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TarOutstandingAmt"));                    
                    int ShiACsTotalACs = dt.AsEnumerable().Sum(row => row.Field<int>("ShiACsTotalACs"));
                    double KisSanTotalACs = dt.AsEnumerable().Sum(row => row.Field<double>("KisSanTotalACs"));
                    double TarDisTotalACs = dt.AsEnumerable().Sum(row => row.Field<double>("TarDisTotalACs"));
                    double TotalOutstandingAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TotalOutstandingAmt"));                    
                    grdReportCategory.FooterRow.Style.Add("font-weight", "bold");
                    grdReportCategory.FooterRow.HorizontalAlign = HorizontalAlign.Left;
                    grdReportCategory.FooterRow.Cells[0].Text = "Total";                    
                    //grdReportCategory.FooterRow.Cells[1].Text = "";
                    grdReportCategory.FooterRow.Cells[2].Text = ShiACs.ToString("N2");
                    grdReportCategory.FooterRow.Cells[3].Text = ShiSanAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[4].Text = ShiDisAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[5].Text = ShiOutstandingAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[6].Text = KisACs.ToString("N2");
                    grdReportCategory.FooterRow.Cells[7].Text = KisSanAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[8].Text = KisDisAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[9].Text = KisOutstandingAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[10].Text = TarACs.ToString("N2");
                    grdReportCategory.FooterRow.Cells[11].Text = TarSanAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[12].Text = TarDisAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[13].Text = TarOutstandingAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[14].Text = ShiACsTotalACs.ToString("N2");
                    grdReportCategory.FooterRow.Cells[15].Text = KisSanTotalACs.ToString("N2");
                    grdReportCategory.FooterRow.Cells[16].Text = TarDisTotalACs.ToString("N2");
                    grdReportCategory.FooterRow.Cells[17].Text = TotalOutstandingAmt.ToString("N2");
                    grdReportCategory.FooterRow.Cells[0].Style.Add("border", "none");
                    grdReportCategory.FooterRow.Cells[1].Style.Add("border", "none");
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Empty Does Not Exists";
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            grdReportCategory.PageIndex = e.NewPageIndex;
            var ddnm = Session["LDM_DistrictId"];
            SearchSocialCategory(Convert.ToInt32(ddnm));
        }

        protected void Search(object sender, EventArgs e)
        {
            var ddnm = Session["LDM_DistrictId"];            
            SearchSocialCategory(Convert.ToInt32(ddnm));
        }

        private void SearchSocialCategory(int ddnm)
        {
            objLDMFunSchema.Districtid = ddnm;
            ds = new DataSet();
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                ds = objLDMFunBAL.SearchSocialCategoryGridData(txtSearch.Text.Trim(), objLDMFunSchema);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    grdReportCategory.DataSource = ds;
                    grdReportCategory.DataBind();
                }
            }
            //ds = objLDMFunBAL.SearchSocialCategoryGridData(txtSearch.Text.Trim(), objLDMFunSchema);           
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            string filename = "Category_Wise_Report" + "_" + DateTime.Now.ToString().Replace("/", "-") + ".xls";
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/ms-excel";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdReportCategory.AllowPaging = false;
            var ddnm = Session["LDM_DistrictId"];
            GetSocialCategoryViewReport(Convert.ToInt32(ddnm));
            DateTime datetime = DateTime.Now;
            int senssionDate = Convert.ToInt32(datetime.Year.ToString().Substring(2, 2).ToString());
            int ss = senssionDate + 1;
            grdReportCategory.HeaderRow.Style.Add("background-color", "#FFFFFF");
            
            for (int i = 0; i < grdReportCategory.HeaderRow.Cells.Count; i++)
            {
                grdReportCategory.HeaderRow.Cells[i].Text = "";
            }
            grdReportCategory.RenderControl(htw);            
            string headerTable = @"<table style='font - weight: bold; text - align: center; font - size: 15px; background: #D4EED1;' border='1' width='100%'><tbody><tr><td colspan='18'>Pradhanmantri Mudra Bank Yojana FY" + DateTime.Now.Year + " - " + ss + ": Progress in Maharashtra, Category-Wise</td></tr><tr><td rowspan='4'>Sr No</td><td rowspan='4'>Category</td></tr><tr><td colspan='4'>Shishu</td><td colspan='4'>Kishore</td><td colspan='4'>Tarun</td><td colspan='4'>Total</td></tr><tr><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>Outstanding Amt (Principal)</td><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>Outstanding Amt (Principal)</td>  <td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>Outstanding Amt (Principal)</td>  <td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>Outstanding Amt (Principal)</td></tr><tr><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td><td>11</td><td>12</td><td>13</td><td>14</td><td>15</td><td>16</td></tr></tbody></table>";
            HttpContext.Current.Response.Write(headerTable);
            Response.Write(sw.ToString());
            Response.End();
        }

    }
}