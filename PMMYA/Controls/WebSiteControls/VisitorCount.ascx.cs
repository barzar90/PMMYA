using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net.NetworkInformation;
using BL;
using Schema;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class VisitorCount : System.Web.UI.UserControl
    {

        #region Public variable declaration
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        BannerBL objBannerBL = new BannerBL();
        DataTable dt;
        DataSet ds;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion

        private void BindControl()
        {         
            try
            {
                BL.BL MAHAITDBAccess = ((MAHAITMasterPage)this.Page.Master).MAHAITDBAccess;
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                if (Convert.ToString(Session["VisitorId"]) == "" || Convert.ToString(Session["VisitorId"]) == null)
                {
                    objBannerControlSchema.UserName = MAHAITDBAccess.UserName;
                    Session["VisitorId"] = MAHAITDBAccess.UserName;
                }
                else
                {
                    objBannerControlSchema.UserName = Convert.ToString(Session["VisitorId"]);                   
                }


                ds = objBannerBL.GetVisitorCount(objBannerControlSchema);
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
                

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        string no = dt.Rows[0]["TOTALCOUNT"].ToString();
                        string todaycount = dt.Rows[0]["TodayVisit"].ToString();


                        lblTotalVisitHeading.Text = _MahaITUC.GetResourceValue("Common", "lblTotalVisitor", "");
                        lblTodayVisitHeading.Text = _MahaITUC.GetResourceValue("Common", "lblTodaysVisitor", "");
                        //lblStartDate.Text = _MahaITUC.GetResourceValue("Common", "lblStartDate", "");


                        if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                        {
                            lblCounter.Text = no.ToString();
                            lbltodayCount.Text = todaycount.ToString();
                        }
                        else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
                        {
                            lblCounter.Text = no.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
                            lbltodayCount.Text = todaycount.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
                        }
                        else
                        {
                            lblCounter.Text = no.Replace("0", "०").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
                            lbltodayCount.Text = todaycount.Replace("0", "0").Replace("1", "१").Replace("2", "२").Replace("3", "३").Replace("4", "४").Replace("5", "५").Replace("6", "६").Replace("7", "७").Replace("8", "८").Replace("9", "९");
                        }
                    }
                }
            }
            finally
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            BindControl();
        }
    }
}