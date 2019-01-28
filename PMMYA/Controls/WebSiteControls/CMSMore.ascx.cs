using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using BL;
using Schema;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class CMSMore : System.Web.UI.UserControl
    {
        #region Public variable declaration
        public BL.BL MAHAITDBAccess;
        public bool isQuickMenu = false;
        public int MenuID = 0;
        public int ContentID = 0;
        public string PageTile, MetaDescription, MetaKeywords = "";
        SqlCommand t_SQLCmd = null;
        DataSet ds = null;
        public string LangID = "en-IN";
        public Boolean HideShortDescription { get; set; }
        private string KeywordChange = "";
        string SearchString = string.Empty;
        CMSBL objCMSBL = new CMSBL();
        CMSSchema objCMSSchema = new CMSSchema();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["format"] != null)
            {
                if (Convert.ToString(Request.QueryString["format"]) == "print")
                {
                    BreadCrum.Visible = false;
                }
            }
        }


        private void showContent()
        {

            LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();

            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

            if (Request.QueryString["Keyword"] != null)
            {
                hdn_keyword.Value = Request.QueryString["Keyword"];
            }

            if (hdn_keyword.Value != string.Empty)
            {
                KeywordChange = Convert.ToString(hdn_keyword.Value);
                SearchString = "<span style='background:yellow;'>" + KeywordChange + "</span>";
            }

            //TODO Check Why "MenuID" contain "Images", should contain int only

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

            //------------

            t_SQLCmd = new SqlCommand();
            if (ContentID != 0)
            {
             
                objCMSSchema.MenucontentID= ContentID;
                objCMSSchema.MenuID = MenuID;
                objCMSSchema.IsQuickMenu = false;
                objCMSSchema.LangType = Convert.ToString(LangID).ToLower();
                ds = objCMSBL.GetCMSMoreDetails(objCMSSchema);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            lblHeading.Text = Convert.ToString(ds.Tables[0].Rows[0]["PageTitle"]);
                            PageTile = Convert.ToString(ds.Tables[0].Rows[0]["PageTitle"]);

                            if (ds.Tables[1].Rows.Count > 0)
                            {
                                MetaDescription = Convert.ToString(ds.Tables[1].Rows[0]["MetaDescription"]) != "" ? Convert.ToString(ds.Tables[1].Rows[0]["MetaDescription"]) : "";
                                MetaKeywords = Convert.ToString(ds.Tables[1].Rows[0]["MetaKeywords"]) != "" ? Convert.ToString(ds.Tables[1].Rows[0]["MetaKeywords"]) : "";
                            }

                            this.Page.Title = PageTile;
                            this.Page.MetaDescription = MetaDescription;
                            this.Page.MetaKeywords = MetaKeywords;

                            StringBuilder contentHtml = new StringBuilder();
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                contentHtml.Append("<div class='archive-more'>");
                                if (Convert.ToString(dr["ShortDescription"]) != "" || Convert.ToString(dr["LongDescription"]) != "")
                                {
                                    contentHtml.Append("<p> ");
                                    contentHtml.Append(Convert.ToString(dr["ShortDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty)));
                                    contentHtml.Append("</p> ");
                                    contentHtml.Append(Convert.ToString(dr["LongDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty)));
                                }
                                else
                                {
                                    contentHtml.Append("Information not Available !!!");
                                }
                                contentHtml.Append("</div>");
                            }

                            if (KeywordChange != "")
                            {
                                CMSContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(Regex.Replace(contentHtml.ToString(), KeywordChange, SearchString, RegexOptions.IgnoreCase)));
                            }
                            else
                            {
                                CMSContent.InnerHtml = HttpUtility.HtmlDecode(Convert.ToString(contentHtml));
                            }
                            if (KeywordChange != "")
                            {
                                lblHeading.Text.Replace(KeywordChange, SearchString);
                                PageTile.Replace(KeywordChange, SearchString);
                                MetaDescription.Replace(KeywordChange, SearchString);
                                MetaKeywords.Replace(KeywordChange, SearchString);
                            }
                        }
                    }
                    else
                    {
                        CMSContent.InnerHtml = "Web site Content Under Departmental Aproval !!!";
                    }
               
            }
        }
    }
}