using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BL;
using Schema;
using DAL;

namespace PMMYA.Site.Home
{
    public partial class FrmMotivational : System.Web.UI.Page
    {
        #region Public variable declaration
        AlbumBL objAlbumBL = new AlbumBL();
        AlbumSchema objAlbumSchema = new AlbumSchema();
        DataSet ds;
        CMSBL objCMSBL = new CMSBL();
        CMSSchema objCMSSchema = new CMSSchema();
        int menuid = 0;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMotivationalVideo();
            }
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            lblMotivational.Text = _MahaITUC.GetResourceValue("Common", "lblMotivational", "");
            menuid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Motivational"]);
            BindLeftMenu(menuid);
            //GetMotivationalVideo();
        }

        public void BindLeftMenu(int menuid)
        {
            try
            {

                string LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
                objCMSSchema.MenuID = Convert.ToInt32(menuid);
                ds = objCMSBL.GetLeftMenuDetails(objCMSSchema);
                if (ds.Tables.Count > 0)
                {
                    PContent.Visible = true;
                    LeftMenuContent.Visible = true;
                    PContent.InnerHtml = "<ul class='quick-links'>";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (LangID == "en-IN")
                        {
                            PContent.InnerHtml += "<li><a href=" + HttpUtility.HtmlDecode(Convert.ToString(dr["ShortDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))) + ">" + dr["MenuName"] + "</a></li>";
                        }
                        else if (LangID == "mr-IN")
                        {
                            PContent.InnerHtml += "<li><a href=" + HttpUtility.HtmlDecode(Convert.ToString(dr["ShortDescription_LL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))) + ">" + dr["MenuName_LL"] + "</a></li>";
                        }
                        else
                        {
                            PContent.InnerHtml += "<li><a href=" + HttpUtility.HtmlDecode(Convert.ToString(dr["ShortDescription_UL"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty))) + ">" + dr["MenuName_UL"] + "</a></li>";
                        }
                    }
                    PContent.InnerHtml += "</ul>";
                }
                else
                {
                    PContent.Visible = false;
                    LeftMenuContent.Visible = false;
                }
            }
            finally
            {

            }
        }

        protected void GetMotivationalVideo()
        {
            objAlbumSchema.TypeId = 1;
            ds = objAlbumBL.GetAllVideosById(objAlbumSchema);
            LV_Events.DataSource = ds;
            LV_Events.DataBind();

        }
    }
}