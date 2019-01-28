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
using System.Text;
using System.Xml;
using System.Configuration;
using BL;
using Schema;

namespace PMMYA.Site.Home
{
    public partial class FrmViewSubAlbum : MAHAITPage 
    {
        #region Public variable declaration
        CMSBL objCMSBL = new CMSBL();
        CMSSchema objCMSSchema = new CMSSchema();
        DataSet ds = null;
        int menuid = 0;
        public string LangID = "en-IN";
        BannerBL objBannerBL = new BannerBL();
        BannerControlSchema objBannerControlSchema = new BannerControlSchema();
        string sitemapmsg = "";
        string HomepagePath = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {          
            DisplaySubAlbum();
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            menuid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PhotoGalleryId"]);
            BindLeftMenu(menuid);
            BindControl(menuid);
        }
        private void DisplaySubAlbum()
        {
            SqlCommand t_SQLCmd = new SqlCommand();
            ViewPhotoAlbumBL objviewphotoalbumbl = new ViewPhotoAlbumBL();
            DataSet ds = new DataSet();
            ds = objviewphotoalbumbl.ViewSubAlbum();
            lblAlbum.Text=GetResourceValue("Common", "lblAlbum", "");
            LV_Events.DataSource = ds;
            LV_Events.DataBind();
        }

        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label IsAlbum;
            Image image;
            Literal litral;
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                IsAlbum = (Label)e.Item.FindControl("Label1");
                image = (Image)e.Item.FindControl("Image1");
                litral = (Literal)e.Item.FindControl("Literal2");

                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
                string AlbumNmae = rowView["AlbumName"].ToString();
                if (AlbumNmae == string.Empty || AlbumNmae == "" || AlbumNmae == null)
                {
                    IsAlbum.Visible = false;
                }
                else
                {
                    IsAlbum.Visible = true;
                    image.Visible = false;
                    litral.Visible = false;
                }
            }

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

        private void BindControl(int menuid)
        {
            LangID = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
            string siteUrl = string.Empty;           
            siteUrl = HttpUtility.UrlDecode(Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty));
            try
            {
               objBannerControlSchema.MenuID = menuid;
               objBannerControlSchema.ContentID = 0;
               ds = objBannerBL.GetUCBreadCrumData(objBannerControlSchema);
               
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder tHtml = new StringBuilder();
                    string strPrint = "";
                    tHtml.AppendLine("<ul class='breadcrumb'>");

                    if (LangID == "en-IN")
                    {
                        sitemapmsg = GetResourceValue("Common", "SitemapMsg", "");
                        HomepagePath= GetResourceValue("Common", "HomepagePath", "");
                        tHtml.AppendLine("<li><b>"+ sitemapmsg +"</b></li>");
                        tHtml.AppendLine("<li><a href='" + siteUrl + "/"+ HomepagePath + "</a></li>");
                    }
                    else if (LangID == "mr-IN")
                    {
                        sitemapmsg = GetResourceValue("Common", "SitemapMsg", "");
                        HomepagePath = GetResourceValue("Common", "HomepagePath", "");
                        tHtml.AppendLine("<li><b>" + sitemapmsg + "</b></li>");
                        tHtml.AppendLine("<li><a href='" + siteUrl + "/" + HomepagePath + "</a></li>");
                    }
                    else
                    {
                        tHtml.AppendLine("<li><b>" + sitemapmsg + "</b></li>");
                        HomepagePath = GetResourceValue("Common", "HomepagePath", "");
                        tHtml.AppendLine("<li><a href='" + siteUrl + "/" + HomepagePath + "</a></li>");
                    }

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i == ds.Tables[0].Rows.Count - 1)
                        {
                            if (LangID == "en-IN")
                            {
                                tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["menuname"] + "</li>");
                               

                            }
                            else if (LangID == "mr-IN")
                            {
                                tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["menuname_ll"] + "</li>");
                               
                            }
                            else
                            {
                                tHtml.AppendLine("<li>" + ds.Tables[0].Rows[i]["MenuName_UL"] + "</li>");                               
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
    }
}
