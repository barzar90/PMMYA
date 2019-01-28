using BL;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using LinqToExcel;
using PMMYA.SLExcelUtility;
using Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;
using Row = DocumentFormat.OpenXml.Spreadsheet.Row;

namespace PMMYA.Admin.MenuManagement
{
    public partial class LDMHome : System.Web.UI.Page
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
        private int BID = 0;
        private int DID = 0;
        private int CID = 0;
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
                var sessionDistrict = Session["LDM_DistrictId"];
                Session["User"] = Session["UserInRole"];
                Role = Convert.ToString(Session["UserRole"]);
                GetViewData(Convert.ToInt32(sessionDistrict));
                SearchCustomers(Convert.ToInt32(sessionDistrict));
            }
            Session["User"] = Session["UserInRole"];
            var ddnm = Session["LDM_DistrictId"];
            Role = Convert.ToString(Session["UserRole"]);
            GetViewData(Convert.ToInt32(ddnm));
            SearchCustomers(Convert.ToInt32(ddnm));
        }

        private void Alert(string msg)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msg", "alert('" + msg + "');", true);
        }

        public void GetViewData(int ddnm)
        {
            try
            {
                objLDMFunSchema.Districtid = ddnm;              
                ds = new DataSet();
                ds = objLDMFunBAL.GetGridViewData(objLDMFunSchema);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    dt = ds.Tables["Table"];
                    double ReqLoanAmnt = dt.AsEnumerable().Sum(row => row.Field<double>("ReqLoanAmnt"));
                    double SanctionAmnt = dt.AsEnumerable().Sum(row => row.Field<double>("SanctionAmnt"));
                    double DisbursedAmnt = dt.AsEnumerable().Sum(row => row.Field<double>("DisbursedAmnt"));
                    double LoanAmntOutStanding = dt.AsEnumerable().Sum(row => row.Field<double>("LoanAmntOutStanding"));

                    GridView1.FooterRow.HorizontalAlign = HorizontalAlign.Left;
                    GridView1.FooterRow.Style.Add("font-weight", "bold");
                    GridView1.FooterRow.Cells[0].Text = "Total";
                    //GridView1.FooterRow.Cells[0].ColumnSpan = 9;                 
                    GridView1.FooterRow.Cells[1].Text = "";
                    GridView1.FooterRow.Cells[2].Text = "";
                    GridView1.FooterRow.Cells[3].Text = "";
                    GridView1.FooterRow.Cells[4].Text = "";
                    GridView1.FooterRow.Cells[5].Text = "";
                    GridView1.FooterRow.Cells[6].Text = "";
                    GridView1.FooterRow.Cells[7].Text = "";
                    GridView1.FooterRow.Cells[8].Text = "";
                    //GridView1.FooterRow.Cells[9].Text = "";
                    GridView1.FooterRow.Cells[9].Text = ReqLoanAmnt.ToString("N2");
                    GridView1.FooterRow.Cells[10].Text = SanctionAmnt.ToString("N2");
                    GridView1.FooterRow.Cells[11].Text = "";
                    GridView1.FooterRow.Cells[12].Text = "";
                    GridView1.FooterRow.Cells[13].Text = "";
                    //GridView1.FooterRow.Cells[3].ColumnSpan = 3;
                    GridView1.FooterRow.Cells[14].Text = DisbursedAmnt.ToString("N2");
                    //GridView1.FooterRow.Cells[5].ColumnSpan = 1;
                    GridView1.FooterRow.Cells[15].Text = "";
                    GridView1.FooterRow.Cells[16].Text = LoanAmntOutStanding.ToString("N2");

                    GridView1.FooterRow.Cells[1].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[2].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[3].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[4].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[5].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[6].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[7].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[8].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[11].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[12].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[13].Style.Add("border", "none");
                    GridView1.FooterRow.Cells[15].Style.Add("border", "none");
                    //GridView1.FooterRow.Cells[16].Style.Add("border", "none");

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

        protected void btnImport_Click(object sender, EventArgs e)
        {

            HttpPostedFile filebase = excelFile.PostedFile;
            List<string> data1 = new List<string>();
            if (excelFile != null)
            {
                if (excelFile.PostedFile.ContentType == "application/vnd.ms-excel" || excelFile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = excelFile.FileName;
                    string targetpath = Server.MapPath("~/ExcelFiles/");
                    excelFile.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    string connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "ExcelTable");
                    DataTable dtable = ds.Tables["ExcelTable"];
                    ExcelQueryFactory excelFiledata = new ExcelQueryFactory(pathToExcelFile);
                    SLExcelData datar = (new SLExcelReader()).ReadExcel(filebase);
                    Session[SessionExcelData] = datar;
                    string userLdm = Session["User"].ToString();
                    foreach (List<string> d in datar.DataRows)
                    {
                        string BNM = d[1];
                        string DNM = d[16];
                        string CNM = d[19];
                        GetAllBankDetails(BNM);
                        GetAllDistrictDetails(DNM);
                        GetAllCategoryDetails(CNM);

                        //objLDMFunSchema.Sr_No = int.Parse(d[0]); 
                        objLDMFunSchema.BankName = d[1];
                        objLDMFunSchema.BankBranch = d[2];
                        objLDMFunSchema.IFSCCode = d[3];
                        objLDMFunSchema.App_Reg = d[4];
                        objLDMFunSchema.Loan_Category = d[5];
                        objLDMFunSchema.FirstName = d[6];
                        objLDMFunSchema.MiddleName = d[7];
                        objLDMFunSchema.LastName = d[8];
                        objLDMFunSchema.Gender = d[9];
                        objLDMFunSchema.MaritalStatus = d[10];
                        //objLDMFunSchema.Dob = DateTime.Parse(d[11]);
                        objLDMFunSchema.Dob = DateTime.FromOADate(double.Parse(d[11]));
                        objLDMFunSchema.Village = d[12];
                        objLDMFunSchema.Gram = d[13];
                        objLDMFunSchema.Tehsil = d[14];
                        objLDMFunSchema.Block = d[15];
                        objLDMFunSchema.District = d[16];
                        objLDMFunSchema.Religion = d[17];
                        objLDMFunSchema.Minority_Comm = d[18];
                        objLDMFunSchema.Social_Category = d[19];
                        objLDMFunSchema.Aadhar = d[20];
                        objLDMFunSchema.PAN = d[21];
                        objLDMFunSchema.Mobile = d[22];
                        objLDMFunSchema.Email = d[23];
                        objLDMFunSchema.ReqLoanAmnt = Convert.ToDouble(d[24]);
                        objLDMFunSchema.SanctionAmnt = Convert.ToDouble(d[25]);
                        //objLDMFunSchema.SanctionDate = DateTime.Parse(d[26]);
                        objLDMFunSchema.SanctionDate = DateTime.FromOADate(double.Parse(d[26]));
                        objLDMFunSchema.Business_Activity = d[27];
                        objLDMFunSchema.Type_Loan = d[28];
                        objLDMFunSchema.DisbursedAmnt = Convert.ToDouble(d[29]);
                        //objLDMFunSchema.DisburseDate = DateTime.Parse(d[30]);
                        objLDMFunSchema.DisburseDate = DateTime.FromOADate(double.Parse(d[30]));
                        objLDMFunSchema.LoanAmntOutStanding = Convert.ToDouble(d[31]);
                        objLDMFunSchema.AnualTarget = Convert.ToDouble(d[32]);
                        objLDMFunSchema.Districtid = GetAllDistrictDetails(DNM);
                        objLDMFunSchema.CategoryId = GetAllCategoryDetails(CNM); //Mahesh Category
                        objLDMFunSchema.BankId = GetAllBankDetails(BNM);
                        objLDMFunSchema.InsertDate = System.DateTime.Now;
                        objLDMFunSchema.InsertedBy = userLdm;

                        ds = objLDMFunBAL.LDMInsert(objLDMFunSchema);
                    }
                    //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    GridView1.DataSource = ds;
                    //    GridView1.DataBind();
                    //}
                    //else {
                    GridView1.DataSource = ds;
                    lblUploadError.Visible = false;
                    btnDownloadSpreadsheet.Visible = true;
                    // GridView1.DataBind();
                    //}
                }
                else
                {
                    lblUploadError.Visible = true;
                    lblUploadError.Text = "please select excell file.";
                }
            }

            object ddnm = Session["LDM_DistrictId"];
            GetViewData(Convert.ToInt32(ddnm));

        }

        private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            //if (cell.CellValue.InnerText == "")
            //{
            //    string emptymsg = "Required";
            //    var text = doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            //}
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }

        public string GetColumnName(string cellReference)
        {
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        public int ConvertColumnNameToNumber(string columnName)
        {
            Regex alpha = new Regex("^[A-Z]+$");
            if (!alpha.IsMatch(columnName))
            {
                throw new ArgumentException();
            }

            char[] colLetters = columnName.ToCharArray();
            Array.Reverse(colLetters);
            int convertedValue = 0;
            for (int i = 0; i < colLetters.Length; i++)
            {
                char letter = colLetters[i];
                int current = i == 0 ? letter - 65 : letter - 64; // ASCII 'A' = 65
                convertedValue += current * (int)Math.Pow(26, i);
            }
            return convertedValue;
        }

        public IEnumerator<Cell> GetExcelCellEnumerator(Row row)
        {
            int currentCount = 0;
            foreach (Cell cell in row.Descendants<Cell>())
            {
                string columnName = GetColumnName(cell.CellReference);
                int currentColumnIndex = ConvertColumnNameToNumber(columnName);
                for (; currentCount < currentColumnIndex; currentCount++)
                {
                    Cell emptycell = new Cell() { DataType = null, CellValue = new CellValue(string.Empty) };
                    yield return emptycell;
                }
                yield return cell;
                currentCount++;
            }
        }

        public string ReadExcelCell(Cell cell, WorkbookPart workbookPart)
        {
            CellValue cellValue = cell.CellValue;
            string text = (cellValue == null) ? cell.InnerText : cellValue.Text;
            string textEmail = (cellValue == null) ? cell.InnerText : cellValue.Text;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
            {
                text = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(Convert.ToInt32(cell.CellValue.Text)).InnerText;
            }
            return (text ?? string.Empty).Trim();
        }

        protected void btnDownloadSpreadsheet_Click(object sender, EventArgs e)
        {
            SLExcelData data = (SLExcelData)Session[SessionExcelData];
            if (data == null)
            {
                lblMsgDownload.Text = "File record does not exists.";
            }
            string path = Server.MapPath("~/Files");
            string fileName = "Spreadsheet.xlsx";
            string fullPath = Path.Combine(path, fileName);
            byte[] file = (new SLExcelWriter()).GenerateExcel(data);
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            //string filename = "Download_Excel_Report" + "_" + DateTime.Now.ToString().Replace("/", "-") + ".xls";
            //Response.AddHeader("Content-Disposition", "attachment; filename={0}, " + filename + "");
            Response.AddHeader("Content-Disposition", "attachment; filename=ExcelFile.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.BinaryWrite(file);
            Response.Flush();
            Response.Close();
            Response.End();

        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            var ddnm = Session["LDM_DistrictId"];
            SearchCustomers(Convert.ToInt32(ddnm));
        }

        protected void Search(object sender, EventArgs e)
        {
            var ddnm = Session["LDM_DistrictId"];
            SearchCustomers(Convert.ToInt32(ddnm));
        }

        private void SearchCustomers(int ddnm)
        {
            ds = new DataSet();
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                ds = objLDMFunBAL.SearchGridData(txtSearch.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblMessage.Visible = false;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            //ds = objLDMFunBAL.SearchGridData(txtSearch.Text.Trim());
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    lblMessage.Visible = false;
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //}
        }

        //Get Bank Id
        public int GetAllBankDetails(string BankName)
        {
            ds = new DataSet();
            ds = objLDMFunBAL.GetAllBank(BankName);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                int bid = Convert.ToInt32(dt.Rows[0]["Id"]);
                string bnm = dt.Rows[0]["BankName"].ToString();
                BankName = bnm;
                BID = bid;
            }
            return BID;
        }
        //Get District Id
        public int GetAllDistrictDetails(string DistrictName)
        {
            ds = new DataSet();
            ds = objLDMFunBAL.GetAllDistrict(DistrictName);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                int did = Convert.ToInt32(dt.Rows[0]["Districtcode"]);
                string dnm = dt.Rows[0]["DistrictName"].ToString();
                DistrictName = dnm;
                DID = did;
            }
            return DID;
        }

        //Get Category ID
        public int GetAllCategoryDetails(string CategoryName)
        {
            ds = new DataSet();
            ds = objLDMFunBAL.GetAllCategory(CategoryName);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                int cid = Convert.ToInt32(dt.Rows[0]["Id"]);
                string cnm = dt.Rows[0]["SocialCategory"].ToString();
                CategoryName = cnm;
                CID = cid;
            }
            return CID;
        }

        //Report export
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.Buffer = true;
            string filename = "State_Level_Report" + "_" + DateTime.Now.ToString().Replace("/", "-") + ".xls";
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            Response.ContentType = "application/ms-excel";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            //string ddnm = Session["User"].ToString();
            object ddnm = Session["LDM_DistrictId"];
            GetViewData(Convert.ToInt32(ddnm));
            DateTime dt = DateTime.Now;
            int senssionDate = Convert.ToInt32(dt.Year.ToString().Substring(2, 2).ToString());
            int ss = senssionDate + 1;
            //Change the Header Row back to white color
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //int columnscount = grdReport.Columns.Count;
            //int rowcount = grdReport.Rows.Count;
            //Applying stlye to gridview header cells
            for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
            {
                GridView1.HeaderRow.Cells[i].Style.Add("background-color", "#D4EED1");
            }
            GridView1.RenderControl(htw);
            //string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td><h4>Report </h4> </td><td></td><td><h4>" + DateTime.Now.ToString("d") + "</h4></td></tr></table>";
            string headerTable = @"<table width='100%' border='1' style='font-weight: bold; text-align: center; font-size: 15px; background: #D4EED1;'><tr><td rowspan=4>Sr No</td><td rowspan=4>District_Name</td><td rowspan=4>Annual Target</td><td colspan=12 >Pradhanmantri Mudra Bank Yojana FY" + DateTime.Now.Year + " - " + ss + ": Progress in Maharashtra, District-Wise</td><td rowspan=4>% of Achievement</td><td rowspan=4>Rank</td></tr>  <tr><td colspan=12>Achievement for FY" + DateTime.Now.Year + " - " + ss + "</td></tr>  <tr><td colspan=3>Shishu</td><td colspan=3>Kishore</td><td colspan=3>Tarun</td><td colspan=3>Total</td></tr><tr><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td>  <td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td><td>A/Cs</td><td>Sanct. Amt</td><td>Disbur. Amt</td>  </tr><tr><td>1</td><td>2</td><td>3</td><td>4</td><td>5</td><td>6</td><td>7</td><td>8</td><td>9</td><td>10</td><td>11</td><td>12</td><td>13</td><td>14</td><td>15</td><td>16</td><td>17</td></tr></table>";
            HttpContext.Current.Response.Write(headerTable);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}