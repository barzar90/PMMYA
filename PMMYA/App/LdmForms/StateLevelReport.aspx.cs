﻿using BL;
using Schema;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.App.LdmForms
{
    public partial class StateLevelReport : System.Web.UI.Page
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
                // Session["User"] = hdnSession.Text;
                //string ddnm = Session["User"].ToString();
                var ddnm = Session["LDM_DistrictId"];
                Role = Convert.ToString(Session["UserRole"]);
                GetStateViewReport(Convert.ToInt32(ddnm));
                SearchState(Convert.ToInt32(ddnm));
            }
        }

        //Report State
        public void GetStateViewReport(int ddnm)
        {
            try
            {
                objLDMFunSchema.Districtid = ddnm;

                objLDMFunSchema.ShiLoanCategory = "Shishu";
                objLDMFunSchema.KisLoanCategory = "Kishore";
                objLDMFunSchema.TarLoanCategory = "Tarun";

                ds = new DataSet();
                ds = objLDMFunBAL.GetStateViewReport(objLDMFunSchema);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    grdReport.DataSource = ds;
                    grdReport.DataBind();

                    dt = ds.Tables["Table"];
                    //decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Price"));
                    //GridView1.FooterRow.Cells[1].Text = "Total";
                    //GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    //GridView1.FooterRow.Cells[2].Text = total.ToString("N2");

                    double AnnualTarget = dt.AsEnumerable().Sum(row => row.Field<double>("AnnualTarget"));
                    double ShiACs = dt.AsEnumerable().Sum(row => row.Field<double>("ShiA/Cs"));
                    double ShiSanAmt = dt.AsEnumerable().Sum(row => row.Field<double>("ShiSanAmt"));
                    double ShiDisAmt = dt.AsEnumerable().Sum(row => row.Field<double>("ShiDisAmt"));
                    double KisACs = dt.AsEnumerable().Sum(row => row.Field<double>("KisA/Cs"));
                    double KisSanAmt = dt.AsEnumerable().Sum(row => row.Field<double>("KisSanAmt"));
                    double KisDisAmt = dt.AsEnumerable().Sum(row => row.Field<double>("KisDisAmt"));
                    double TarACs = dt.AsEnumerable().Sum(row => row.Field<double>("TarA/Cs"));
                    double TarSanAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TarSanAmt"));
                    double TarDisAmt = dt.AsEnumerable().Sum(row => row.Field<double>("TarDisAmt"));
                    double ShiACsTotalACs = dt.AsEnumerable().Sum(row => row.Field<double>("ShiACsTotalACs"));
                    double KisSanTotalACs = dt.AsEnumerable().Sum(row => row.Field<double>("KisSanTotalACs"));
                    double TarDisTotalACs = dt.AsEnumerable().Sum(row => row.Field<double>("TarDisTotalACs"));
                    double ofAchievement = dt.AsEnumerable().Sum(row => row.Field<double>("ofAchievement"));
                    int Rank = dt.Columns.IndexOf("Rank");

                    grdReport.FooterRow.Style.Add("font-weight", "bold");
                    grdReport.FooterRow.HorizontalAlign = HorizontalAlign.Left;
                    grdReport.FooterRow.Cells[0].Text = "Total";
                    //grdReport.FooterRow.Cells[0].ColumnSpan = 2;
                    grdReport.FooterRow.Cells[1].Text = "";
                    grdReport.FooterRow.Cells[2].Text = AnnualTarget.ToString("N2");
                    grdReport.FooterRow.Cells[3].Text = ShiACs.ToString("N2");
                    grdReport.FooterRow.Cells[4].Text = ShiSanAmt.ToString("N2");
                    grdReport.FooterRow.Cells[5].Text = ShiDisAmt.ToString("N2");
                    grdReport.FooterRow.Cells[6].Text = KisACs.ToString("N2");
                    grdReport.FooterRow.Cells[7].Text = KisSanAmt.ToString("N2");
                    grdReport.FooterRow.Cells[8].Text = KisDisAmt.ToString("N2");
                    grdReport.FooterRow.Cells[9].Text = TarACs.ToString("N2");
                    grdReport.FooterRow.Cells[10].Text = TarSanAmt.ToString("N2");
                    grdReport.FooterRow.Cells[11].Text = TarDisAmt.ToString("N2");
                    grdReport.FooterRow.Cells[12].Text = ShiACsTotalACs.ToString("N2");
                    grdReport.FooterRow.Cells[13].Text = KisSanTotalACs.ToString("N2");
                    grdReport.FooterRow.Cells[14].Text = TarDisTotalACs.ToString("N2");
                    grdReport.FooterRow.Cells[15].Text = ofAchievement.ToString("N2");
                    grdReport.FooterRow.Cells[16].Text = "";

                    grdReport.FooterRow.Cells[0].Style.Add("border", "none");
                    grdReport.FooterRow.Cells[1].Style.Add("border", "none");
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
            grdReport.PageIndex = e.NewPageIndex;
            //string ddnm = Session["User"].ToString();
            var ddnm = Session["LDM_DistrictId"];
            SearchState(Convert.ToInt32(ddnm));
        }

        protected void Search(object sender, EventArgs e)
        {
            //string ddnm = Session["User"].ToString();
            var ddnm = Session["LDM_DistrictId"];
            SearchState(Convert.ToInt32(ddnm));
        }

        private void SearchState(int ddnm)
        {
            objLDMFunSchema.Districtid = ddnm;
            ds = new DataSet();
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                ds = objLDMFunBAL.SearchStateGridData(txtSearch.Text.Trim(), objLDMFunSchema);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    grdReport.DataSource = ds;
                    grdReport.DataBind();
                }
            }
            ds = objLDMFunBAL.SearchStateGridData(txtSearch.Text.Trim(), objLDMFunSchema);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    lblMessage.Visible = false;
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //}
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ClearContent();
                Response.Buffer = true;
                string filename = "State_Level_Report" + "_" + DateTime.Now.ToString().Replace("/", "-") + ".xls";
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
                Response.ContentType = "application/ms-excel";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grdReport.AllowPaging = false;
                //string ddnm = Session["User"].ToString();
                var ddnm = Session["LDM_DistrictId"];
                GetStateViewReport(Convert.ToInt32(ddnm));
                DateTime dt = DateTime.Now;
                int senssionDate = Convert.ToInt32(dt.Year.ToString().Substring(2, 2).ToString());
                int ss = senssionDate + 1;                
                grdReport.HeaderRow.Style.Add("background-color", "#FFFFFF");
                //int columnscount = grdReport.Columns.Count;
                //int rowcount = grdReport.Rows.Count;                
                for (int i = 0; i < grdReport.HeaderRow.Cells.Count; i++)
                {
                    grdReport.HeaderRow.Cells[i].Text = "";                    
                }                
                grdReport.RenderControl(htw);                
                string headerTable = @"<table width='100%' border='1' style='font-weight: bold; text-align: center; font-size: 15px; background: #D4EED1;'><tr><td rowspan=4>Sr No</td><td rowspan=4>District_Name</td><td rowspan=4>Annual Target</td><td colspan=12 >Pradhanmantri Mudra Bank Yojana FY" + DateTime.Now.Year + " - " + ss + ": Progress in Maharashtra, State-Wise</td><td rowspan=4>% of Achievement</td><td rowspan=4>Rank</td></tr>  <tr><td colspan=12>Achievement for FY" + DateTime.Now.Year + " - " + ss + "</td></tr>  <tr><td colspan=3>Shishu</td><td colspan=3>Kishore</td><td colspan=3>Tarun</td><td colspan=3>Total</td></tr><tr><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td>  <td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td>  </tr><tr><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td><td>11</td><td>12</td><td>13</td><td>14</td><td>15</td><td>16</td><td>17</td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                Response.Write(sw.ToString());
                //Response.Flush();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                //Response.Close();
                Response.Flush();
                Response.Clear();

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
                
                //Response.Close();
                //Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ex)
            {             
            }
            finally
            {             
            }
        }
    }
}