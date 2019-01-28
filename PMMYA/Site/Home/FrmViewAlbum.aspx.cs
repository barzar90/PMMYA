using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BL;
using Schema;

namespace PMMYA.Site.Home
{
    public partial class FrmViewAlbum : MAHAITPage
    {
        #region Public variable declaration
        //BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
        CMSBL objCMSBL = new CMSBL();
        CMSSchema objCMSSchema = new CMSSchema();
        int menuid = 0;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        DataSet ds;
        ViewPhotoAlbumBL objviewphotoalbumBL = new ViewPhotoAlbumBL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                menuid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PhotoGalleryId"]);
                BindLeftMenu(menuid);
                DisplayAlbum();
            }
        }
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            menuid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PhotoGalleryId"]);
            BindLeftMenu(menuid);
            lblAlbum.Text = GetResourceValue("Common", "lblAlbum", "");
        }
        private void DisplayAlbum()
        {
            ds = objviewphotoalbumBL.DisplayAlbum();          
            LV_Events.DataSource = ds;
            LV_Events.DataBind();
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

    }
}