using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using BL;
using Schema;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class NewsControl : System.Web.UI.UserControl
    {
        #region Public variable declaration
        BL.BL MAHAITDBAccess;
        private Boolean _ShowMoreNewsOnNewsItem;
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        BannerBL objBannerBL = new BannerBL();
        DataSet ds;
        DataTable dt;
        #endregion

        public Boolean ShowMoreNewsOnNewsItem
        {
            get { return _ShowMoreNewsOnNewsItem; }
            set { _ShowMoreNewsOnNewsItem = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            GetNews();
            MAHAITUserControl _MAHAITUC = new MAHAITUserControl();
            lblNews.Text = _MAHAITUC.GetResourceValue("Common", "lblNews", "");
            //Label lbTemp = (Label)RptrWhatsNew.FindControl("lnkmore");
            //lbTemp.Text = _MAHAITUC.GetResourceValue("Common", "lblNewsMore", "");
        }

        private void GetNews()
        {
            try
            {
                SqlCommand cmdBanner = new SqlCommand();
                cmdBanner.CommandType = CommandType.Text;

                if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "mr-IN")
                {
                    MAHAITDBAccess.LangID = "2";
                }
                else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
                {
                    MAHAITDBAccess.LangID = "1";
                }
                else
                {
                    MAHAITDBAccess.LangID = "3";
                }
                string langid = MAHAITDBAccess.LangID.ToString();
                objBannerControlSchema.LangId = Convert.ToInt32(langid);
                objBannerControlSchema.NewsCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["NewsCount"].ToString());
                ds = objBannerBL.GetNews(objBannerControlSchema);
                dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        RptrWhatsNew.DataSource = dt;
                        RptrWhatsNew.DataBind();
                        //int i = 0;
                        //int test = 1 / i;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {


            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RptrWhatsNew_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        

    }
}