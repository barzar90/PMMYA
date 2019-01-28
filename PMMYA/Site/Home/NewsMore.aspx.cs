using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BL;
using Schema;

namespace PMMYA.Site.Home
{
    public partial class NewsMore : System.Web.UI.Page
    {
        #region Public variable declaration
        int LangID = 0;
        DataSet ds;
        DataTable dt;
        UploadNewsSchema objUploadNewsSchema = new UploadNewsSchema();
        UploadNewsBL objUploadNewsBL = new UploadNewsBL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvNews.Visible = false;
                BindGrid();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
                Session["LangId"] = LangID;
                if (txtSearch.Text == string.Empty)
                {
                    BindGrid();
                }
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                LangID = 1;
                Session["LangId"] = LangID;
                if (txtSearch.Text == string.Empty)
                {
                    BindGrid();
                }
            }
            else
            {
                LangID = 3;
                Session["LangId"] = LangID;
                if (txtSearch.Text == string.Empty)
                {
                    BindGrid();
                }
            }

            MAHAITUserControl _mahaITUC = new MAHAITUserControl();
            lblSearch.Text = _mahaITUC.GetResourceValue("Common", "lblKeywordsearch", "").ToString();
            lblNews.Text = _mahaITUC.GetResourceValue("Common", "lblNews", "").ToString();
            btnSearch.Text = _mahaITUC.GetResourceValue("Common", "Search_btn", "").ToString();
            Reset();
        }

        private void BindGrid()
        {
            try
            {
                objUploadNewsSchema.Para = "Select_News";
                ds = objUploadNewsBL.GetNews(objUploadNewsSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    gvNews.DataSource = dt;
                    gvNews.DataBind();
                    gvNews.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        private void BindGridSearch()
        {
            try
            {              
                objUploadNewsSchema.Para = "Search_News";
                objUploadNewsSchema.Search = txtSearch.Text;
                ds = objUploadNewsBL.GetNews(objUploadNewsSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    gvNews.DataSource = dt;
                    gvNews.DataBind();
                    gvNews.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        private void Reset()
        {
            txtSearch.Text = "";
        }

        private void ShowMessage(string Message)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Alert", "alert('" + Message + "');", true);
        }

        protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            if (txtSearch.Text != "")
                BindGrid();
            else
                BindGridSearch();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != string.Empty)
                {
                    BindGridSearch();
                }
                else
                {
                    ShowMessage("Please Enter A KeyWord To Search");
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                objUploadNewsSchema.Para = "Search_News";
                objUploadNewsSchema.Search = txtSearch.Text;
                ds = objUploadNewsBL.GetNews(objUploadNewsSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    gvNews.DataSource = dt;
                    gvNews.DataBind();
                    gvNews.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}