using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Schema;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class LastReviewedDate : System.Web.UI.UserControl
    {
        #region Public variable declaration
        public int MenuID = 0;
        public int ContentID = 0;
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        BannerBL objBannerBL = new BannerBL();
        DataSet ds;
        DataTable dt;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblReviewDate.Text = GetLatestReviewedDate().ToString("dd/MM/yyyy");
            }
        }

        private DateTime GetLatestReviewedDate()
        {
            try
            {
                SetLastUpdatedReview();

                if (ContentID != 0)
                {
                    objBannerControlSchema.ContentID = ContentID;
                    ds = objBannerBL.GetLastReviewDate(objBannerControlSchema);
                    dt = ds.Tables[0];
              
                    if (dt.Rows.Count == 0)
                    {
                        return System.DateTime.Now;
                    }
                    if (Convert.ToString(dt.Rows[0]["CreatedOn"]) == string.Empty)
                    {
                        return System.DateTime.Now;
                    }
                    else
                    {
                        return Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    }
                }
                else
                {
                    if (MenuID == 0)
                    {
                        objBannerControlSchema.MenuID = 0;
                    }
                    else
                    {
                        objBannerControlSchema.MenuID = MenuID;
                    }
                  
                    ds = objBannerBL.GetLastReviewDate(objBannerControlSchema);
                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["LastUpdated"] == null)
                        {
                            return DateTime.Now;
                        }
                        return Convert.ToDateTime(dt.Rows[0]["LastUpdated"]);
                    }
                    else
                    {
                        return DateTime.Now;
                    }
                }
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
            finally
            {
                dt = null;
            }
        }

        private void SetLastUpdatedReview()
        {
            try
            {

                if (this.Page.RouteData.Values["MenuID"] != null)
                {
                    if (Int32.TryParse(this.Page.RouteData.Values["MenuID"].ToString(), out MenuID) == false)
                    {
                        MenuID = 0;
                    }
                }
                else if (this.Request.QueryString["MenuID"] != null)
                {
                    if (Int32.TryParse(this.Request.QueryString["MenuID"].ToString(), out MenuID) == false)
                    {
                        MenuID = 0;
                    }
                }

                if (this.Page.RouteData.Values["ContentID"] != null)
                {
                    if (Int32.TryParse(this.Page.RouteData.Values["ContentID"].ToString(), out ContentID) == false)
                    {
                        ContentID = 0;
                    }
                }
                else if (this.Request.QueryString["ContentID"] != null)
                {
                    if (Int32.TryParse(this.Request.QueryString["ContentID"].ToString(), out ContentID) == false)
                    {
                        ContentID = 0;
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblReviewDate1.Text = _MahaITUC.GetResourceValue("Common", "lblReviewDate", "");


            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                //lblReviewDate1.Text = "शेवटचे पुनरावलोकन:";
                lblReviewDate.Text = GetLatestReviewedDate().ToString("dd/MM/yyyy").Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                //lblReviewDate1.Text = "Last Reviewed:";
                lblReviewDate.Text = GetLatestReviewedDate().ToString("dd/MM/yyyy");
            }
            else
            {
                lblReviewDate.Text = GetLatestReviewedDate().ToString("dd/MM/yyyy").Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
               //lblReviewDate.Text = GetLatestReviewedDate().ToString("dd/MM/yyyy");
            }
        }
    }
}