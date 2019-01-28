using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Schema;
using BL;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class UCBreadCrum : System.Web.UI.UserControl
    {
        #region Public variable declaration
        public BL.BL MAHAITDBAccess;
        public int MenuID = 0;
        DataSet ds = null;
        public string LangID = "en-IN";
        public bool isQuickMenu = false;
        public bool isMoreContent { get; set; }
        public int ContentID = 0;
        BannerBL objBannerBL = new BannerBL();
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        string sitemapmsg = "";
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        string HomepagePath = "";
        #endregion

        private void BindControl()
        {
            LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
            string siteUrl = string.Empty;

            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

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

            siteUrl = HttpUtility.UrlDecode(Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
            try
            {
                if (isQuickMenu == false)
                {
                    objBannerControlSchema.MenuID = MenuID;
                    objBannerControlSchema.ContentID = ContentID;
                    ds = objBannerBL.GetUCBreadCrumData(objBannerControlSchema);
                }

                if (isQuickMenu == true)
                {
                    objBannerControlSchema.MenuID = MenuID;
                    ds= objBannerBL.GetUCBreadCrumDataforQuickMenu(objBannerControlSchema);
                }

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder tHtml = new StringBuilder();
                    string strPrint = "";

                   
                    tHtml.AppendLine("<ul class='breadcrumb'>");
                    
                    if (LangID == "en-IN")
                    {
                        sitemapmsg = _MahaITUC.GetResourceValue("Common", "SitemapMsg", "");
                        HomepagePath = _MahaITUC.GetResourceValue("Common", "HomepagePath", "");
                        tHtml.AppendLine("<li><b>" + sitemapmsg + "</b></li>");
                        tHtml.AppendLine("<li><a href='" + siteUrl + "/" + HomepagePath + "</a></li>");
                    }
                    else if (LangID == "mr-IN")
                    {
                        sitemapmsg = _MahaITUC.GetResourceValue("Common", "SitemapMsg", "");
                        HomepagePath = _MahaITUC.GetResourceValue("Common", "HomepagePath", "");
                        tHtml.AppendLine("<li><b>" + sitemapmsg + "</b></li>");
                        tHtml.AppendLine("<li><a href='" + siteUrl + "/" + HomepagePath + "</a></li>");
                    }
                    else
                    {
                        sitemapmsg = _MahaITUC.GetResourceValue("Common", "SitemapMsg", "");
                        HomepagePath = _MahaITUC.GetResourceValue("Common", "HomepagePath", "");
                        tHtml.AppendLine("<li><b>" + sitemapmsg + "</b></li>");
                        tHtml.AppendLine("<li><a href='" + siteUrl + "/" + HomepagePath + "</a></li>");
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == ds.Tables[0].Rows.Count - 1)
                        {
                            if (LangID == "en-IN")
                            {
                                tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["menuname"] + "</li>");
                                if (isMoreContent == false)
                                {
                                    strPrint = "<ul class='print'><li><a target='_blank' href='" + siteUrl + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "?format=print'></a></li></ul>";
                                }
                                else
                                {
                                    strPrint = "<ul class='print'><li><a target='_blank' href='" + siteUrl + "/" + MenuID + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "?format=print'></a></li></ul>";
                                }


                            }
                            else if (LangID == "mr-IN")
                            {
                                tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["menuname_ll"] + "</li>");
                                if (isMoreContent == false)
                                {
                                    strPrint = "<ul class='print'><li><a target='_blank' href='" + siteUrl + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "?format=print'></a></li></ul>";
                                }
                                else
                                {
                                    strPrint = "<ul class='print'><li><a target='_blank' href='" + siteUrl + "/" + MenuID + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "?format=print'></a></li></ul>";
                                }
                            }
                            else
                            {
                                tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["MenuName_UL"] + "</li>");
                                if (isMoreContent == false)
                                {
                                    strPrint = "<ul class='print'><li><a target='_blank' href='" + siteUrl + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "?format=print'></a></li></ul>";
                                }
                                else
                                {
                                    strPrint = "<ul class='print'><li><a target='_blank' href='" + siteUrl + "/" + MenuID + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "?format=print'></a></li></ul>";
                                }
                            }
                        }
                        else
                        {
                            if (LangID == "en-IN")
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["ParentID"]) != "0")
                                {
                                    tHtml.AppendLine("<li><a href='" + siteUrl + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "'>" + ds.Tables[0].Rows[i]["menuname"] + "</a></li>");
                                }
                                else
                                {
                                    tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["menuname"] + "</li>");
                                }
                            }
                            else if (LangID == "mr-IN")
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["ParentID"]) != "0")
                                {
                                    tHtml.AppendLine("<li><a href='" + siteUrl + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "'>" + ds.Tables[0].Rows[i]["menuname_ll"] + "</a></li>");
                                }
                                else
                                {
                                    tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["menuname_LL"] + "</li>");
                                }
                            }
                            else
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[i]["ParentID"]) != "0")
                                {
                                    tHtml.AppendLine("<li><a href='" + siteUrl + "/" + Convert.ToString(ds.Tables[0].Rows[i]["MenuID"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["menuname"]).Replace(" ", "-") + "'>" + ds.Tables[0].Rows[i]["MenuName_UL"] + "</a></li>");
                                }
                                else
                                {
                                    tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["MenuName_UL"] + "</li>");
                                }
                            }
                        }
                    }
                    tHtml.AppendLine("</ul>");

                    tHtml.AppendLine(strPrint);

                    breadcrumb.InnerHtml = tHtml.ToString();

                }

            }
            catch (Exception ee)
            {

            }
            finally
            {
                ds = null;
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindControl();
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}


    }
}