using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using Schema;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class CMS : System.Web.UI.UserControl
    {
        #region Public variable declaration
        public BL.BL MAHAITDBAccess;
        public bool isQuickMenu = false;
        public int MenuID = 0;
        public string PageTile, MetaDescription, MetaKeywords = "";
        DataSet ds = null;
        public string LangID = "en-IN";
        private string KeywordChange = "";
        string SearchString = string.Empty;
        CMSBL objCMSBL = new CMSBL();
        CMSSchema objCMSSchema = new CMSSchema();
        int rowscount = 0;
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

            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

            LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();

            if (Request.QueryString["Keyword"] != null)
            {
                hdn_keyword.Value = Request.QueryString["Keyword"];
            }

            if (hdn_keyword.Value != string.Empty)
            {
                KeywordChange = Convert.ToString(hdn_keyword.Value);
                SearchString = "<span style='background:yellow;'>" + KeywordChange + "</span>";
            }

            string siteUrl = string.Empty;
            siteUrl = Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty);
            int tempMenuID = 0;
            if (Int32.TryParse(this.Page.RouteData.Values["MenuID"].ToString(), out tempMenuID))
            {
                MenuID = Convert.ToInt32(this.Page.RouteData.Values["MenuID"].ToString());
            }
            else if (this.Request.QueryString["MenuID"] != null)
            {
                if (Int32.TryParse(this.Request.QueryString["MenuID"].ToString(), out tempMenuID))
                {
                    MenuID = Convert.ToInt32(this.Request.QueryString["MenuID"].ToString());
                }
            }

            //if (this.Page.RouteData.Values["MenuID"] != null)
            //{
            //    MenuID = Convert.ToInt32(this.Page.RouteData.Values["MenuID"].ToString());
            //}
            //else
            //{
            //    MenuID = Convert.ToInt32(this.Request.QueryString["MenuID"].ToString());
            //}

            if (MenuID != 0)
            {



                objCMSSchema.MenuID = MenuID;

                //To Bind Menu
                BindLeftMenu(objCMSSchema.MenuID);

            




                objCMSSchema.LangType = Convert.ToString(LangID).ToLower();
                objCMSSchema.IsQuickMenu = false;
                ds = objCMSBL.GetCMSDetails(objCMSSchema);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {

                        if (objCMSSchema.MenuID != 1030)
                        {
                            lblHeading.Text = Convert.ToString(ds.Tables[0].Rows[0]["PageHeading"]);
                            lblHeading.Visible = true;
                        }
                        PageTile = Convert.ToString(ds.Tables[0].Rows[0]["PageTitle"]);
                        MetaDescription = Convert.ToString(ds.Tables[0].Rows[0]["MetaDescription"]);

                        MetaKeywords = Convert.ToString(ds.Tables[0].Rows[0]["MetaKeywords"]);
                        string DepartmentName = string.Empty;
                        if (Convert.ToString(LangID).ToLower() == Convert.ToString("mr-IN").ToLower())
                        {
                            DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameMarathi"].ToString();
                        }
                        else if (Convert.ToString(LangID).ToLower() == Convert.ToString("en-IN").ToLower())
                        {
                            DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameEnglish"].ToString();
                        }
                        else
                        {
                            DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameUrdu"].ToString();
                        }
                        this.Page.Title = PageTile + "-" + DepartmentName;
                        this.Page.MetaDescription = MetaDescription;
                        this.Page.MetaKeywords = MetaKeywords;

                        StringBuilder contentHtml = new StringBuilder();

                        if (rowscount != 0)
                        {

                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                contentHtml.Append("<div class='col-xs-12 col-sm-9 col-md-9 col-lg-9 border-l'> ");
                                contentHtml.Append("<div class='archive'>");
                                if (Convert.ToString(dr["PageTitle"]) != string.Empty)
                                {
                                    contentHtml.Append("<h2>");
                                    contentHtml.Append(Convert.ToString(dr["PageTitle"]));
                                    contentHtml.Append("</h2>");
                                }


                                contentHtml.Append("<div>");

                                if (Convert.ToString(dr["ShortDescription"]) != "")
                                {
                                    contentHtml.Append(Convert.ToString(dr["ShortDescription"]));
                                }
                                else
                                {
                                    if (Convert.ToString(dr["LongDescription"]) != "")
                                    {
                                        contentHtml.Append(Convert.ToString(dr["LongDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty)));
                                    }
                                    else
                                    {
                                        contentHtml.Append("Information not Available !!!");
                                    }

                                }
                                contentHtml.Append("</div>");

                                if (Convert.ToString(dr["ShortDescription"]) != "")
                                {
                                    if (LangID == "en-IN")
                                    {
                                        contentHtml.Append("<a class='read_more' href='" + siteUrl + "/" + dr["MenuID"] + "/" + Convert.ToString(dr["MenuContentID"]) + "/" + Convert.ToString(dr["Title"]).Replace(" ", "-") + "'> More " + Convert.ToString(dr["PageTitle"]) + " </a>");
                                    }
                                    else
                                    {
                                        contentHtml.Append("<a class='read_more' href='" + siteUrl + "/" + dr["MenuID"] + "/" + Convert.ToString(dr["MenuContentID"]) + "/" + Convert.ToString(dr["Title"]).Replace(" ", "-") + "'> अधिक " + Convert.ToString(dr["PageTitle"]) + "</a>");
                                    }

                                }

                                contentHtml.Append("</div>");
                                contentHtml.Append("</div>");
                            }

                        }
                        else
                        {
                            foreach (DataRow dr in ds.Tables[1].Rows)
                            {
                                contentHtml.Append("<div class='col-xs-12 col-sm-12 col-md-12 col-lg-12'> ");
                                contentHtml.Append("<div class='archive'>");
                                if (Convert.ToString(dr["PageTitle"]) != string.Empty)
                                {
                                    contentHtml.Append("<h2>");
                                    contentHtml.Append(Convert.ToString(dr["PageTitle"]));
                                    contentHtml.Append("</h2>");
                                }

                               
                                contentHtml.Append("<div>");

                                if (Convert.ToString(dr["ShortDescription"]) != "")
                                {
                                    contentHtml.Append(Convert.ToString(dr["ShortDescription"]));
                                }
                                else
                                {
                                    if (Convert.ToString(dr["LongDescription"]) != "")
                                    {
                                        contentHtml.Append(Convert.ToString(dr["LongDescription"]).Replace("~", Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty)));
                                    }
                                    else
                                    {
                                        contentHtml.Append("Information not Available !!!");
                                    }

                                }
                                contentHtml.Append("</div>");

                                if (Convert.ToString(dr["ShortDescription"]) != "")
                                {
                                    if (LangID == "en-IN")
                                    {
                                        contentHtml.Append("<a class='read_more' href='" + siteUrl + "/" + dr["MenuID"] + "/" + Convert.ToString(dr["MenuContentID"]) + "/" + Convert.ToString(dr["Title"]).Replace(" ", "-") + "'> More " + Convert.ToString(dr["PageTitle"]) + " </a>");
                                    }
                                    else
                                    {
                                        contentHtml.Append("<a class='read_more' href='" + siteUrl + "/" + dr["MenuID"] + "/" + Convert.ToString(dr["MenuContentID"]) + "/" + Convert.ToString(dr["Title"]).Replace(" ", "-") + "'> अधिक " + Convert.ToString(dr["PageTitle"]) + "</a>");
                                    }

                                }

                                contentHtml.Append("</div>");
                                contentHtml.Append("</div>");
                            }

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

            }
            else
            {
                CMSContent.InnerHtml = "Error !!!";
            }
        }

        void Page_PreRender(Object o, EventArgs e)
        {
            showContent();
        }


        private void BindLeftMenu(int menuid)
        {
            try
            {
                string LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
                objCMSSchema.MenuID = Convert.ToInt32(menuid);
                ds = objCMSBL.GetLeftMenuDetails(objCMSSchema);
                if (ds.Tables.Count > 0)
                {
                    rowscount = ds.Tables[0].Rows.Count;
                   

                       PContent.Visible = true;
                    LeftMenuContent.Visible = true;
                    PContent.InnerHtml = "<div class='col-xs-12 col-sm-4 col-md-4 col-lg-3'><ul class='quick-links'>";
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
                    PContent.InnerHtml += "</ul> </div>";
                }
                else
                {
                    divContent.Attributes["class"] = "col-xs-12 col-sm-12 col-md-12 col-lg-12 brd-left pleft25";

                    //PContent.InnerHtml = "Information not Available !!!";
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