using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text;
using System.IO;
using System.Net;
using System.Web.Security;
using Helper;
using System.Security.Cryptography;
using BL;
using Schema;

namespace PMMYA.Admin.MenuManagement
{
    public partial class MenuList : System.Web.UI.Page
    {
        #region Public variable declaration
        //BL.BL MAHAITDBAccess;
        string _MenuName;
        string _isNewFlag;
        DataTable dt;
        MenuSchema objMenuSchema = new MenuSchema();
        MenuBL objMenuBL = new MenuBL();
        DataSet ds;
        string Role = string.Empty;
        #endregion

        public string MenuName
        {
            get { return _MenuName; }
            set { _MenuName = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {               
                if (Session["User"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"].Value != string.Empty)
                {
                    if ((Session["AuthToken"].ToString() != Request.Cookies["AuthToken"].Value))
                    {
                        Session.Abandon();
                        Session.Clear();
                        Session.RemoveAll();// Abandon the current session


                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1); // Clear the ASP.NET_SessionId cookie
                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddDays(-1); // Clear the Auth token                      
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "alert('Your login session has expired!-GC!');location.href=('Login.aspx')", true);

                        return;
                    }

                }

                //Role = Convert.ToString(Session["UserRole"]);
                //if (Role == "admin")
                //{
                //    btnPublish.Visible = true;
                //    btnGenSiteMap.Visible = true;
                //    //btnAddMenu.Visible = false;
                //    //btnAddPlaceholder.Visible = false;
                //    //btnPlaceHolderList.Visible = false;
                //}
                //else
                //{
                //    btnPublish.Visible = false;
                //    btnGenSiteMap.Visible = false;
                //   // btnAddMenu.Visible = true;
                //   // btnAddPlaceholder.Visible = true;
                //   // btnPlaceHolderList.Visible = true;
                //}


                BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                objMenuSchema.ActionType = "BindGrid";
                objMenuSchema.Menuid = 0;
                objMenuSchema.MenuCategory = "";
                ds = objMenuBL.GetMenuListDetails(objMenuSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdManuList.DataSource = dt.DefaultView;
                    grdManuList.DataBind();
                }
                else
                {
                    grdManuList.DataSource = null;
                    grdManuList.DataBind();
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
            }
        }

        protected void grdManuList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                try
                {
                    objMenuSchema.Menuid= Convert.ToInt32(e.CommandArgument);
                    int result = objMenuBL.DMLMenuListDetails(objMenuSchema);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Menu deleted Succesfully !!!')", true);
                        BindGrid();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "Alert", "alert('Error !!!')", true);
                    }
                }
                catch (Exception ee)
                { throw ee; }
            }
        }

        public String GetSiteURL()
        {
            return Request.Url.OriginalString.Replace(HttpUtility.UrlDecode(Request.Url.PathAndQuery), string.Empty);
        }

        //New Code
        protected void btnPublish_Click(object sender, EventArgs e)
        {

            getEnglishMenu(); // For English
            getMarathiMenu(); // For Marathi 
            getUrduMenu();  // For Urdu

            getEnglishFooterMenu(); // for English
            getMarathiFooterMenu(); // For Marathi
            getUrduFooterMenu();


            getEnglishOtherMenu(); // For English
            getMarathiOtherMenu(); // For Marathi
            getUrduOtherMenu();

            GetEnglishQuickMenu();// For English
            GetMarathiQuickMenu();// For Marathi
            GetUrduQuickMenu();

            getQuickLinkEnglishMenu(); // For English Quick Link
            getQuickLinkMarathiMenu(); // For Marathi Quick Link

            getMobileQuickLinkEnglishMenu();
            getMobileQuickLinkMarathiMenu();
            getMobileQuickLinkUrduMenu();

            getImportantLinkEnglishMenu(); // For English Important Link
            getImportantLinkMarathiMenu(); // For Marathi Important Link
            getImportantLinkUrduMenu();

            System.Web.HttpRuntime.UnloadAppDomain();
            Alert("Menu Published Successfully.");

        }

        private void Alert(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + msg + "');", true);
        }


        #region Main Menu 
        private void getEnglishMenu()
        {
            objMenuSchema.ActionType = "GetEnglishMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "MM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul class='nav navbar-nav'>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];

                    _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown' href='#'>" + row["MenuName"].ToString() + "<span class='caret'></span></a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "'>" + row["MenuName"] + _isNewFlag + "</a>");
                        }
                        else if (Convert.ToBoolean(row["IsExternalLink"]) == false && row["MenuType"].ToString() == "2")
                        {
                            sb.Append(" <li><a href='" + row["MenuTypeValue"] + "'>" + row["MenuName"] + _isNewFlag + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a  href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName"] + _isNewFlag + "</a>");
                        }
                    }
                    sb.Append("\t" + AddEnMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "MainMenu_En.xml");
            }
        }

        private void getMarathiMenu()
        {
            objMenuSchema.ActionType = "GetMarathiMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "MM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul class='nav navbar-nav'>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append("<li class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown' href='#'>" + row["MenuName_LL"].ToString() + "<span class='caret'></span></a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "'>" + row["MenuName_LL"] + _isNewFlag + "</a>");
                        }
                        else if (Convert.ToBoolean(row["IsExternalLink"]) == false && row["MenuType"].ToString() == "2")
                        {
                            sb.Append(" <li><a href='" + row["MenuTypeValue"] + "'>" + row["MenuName_LL"] + _isNewFlag + "</a>");
                        }

                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_LL"] + _isNewFlag + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "MainMenu_Mr.xml");
            }

        }

        private void getUrduMenu()
        {
            objMenuSchema.ActionType = "GetUrduMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "MM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];

                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul class='nav navbar-nav'>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append("<li class='dropdown'><a class='dropdown-toggle' data-toggle='dropdown' href='#'>" + row["MenuName_UL"].ToString() + "<span class='caret'></span></a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "'>" + row["MenuName_UL"] + _isNewFlag + "</a>");
                        }
                        else if (Convert.ToBoolean(row["IsExternalLink"]) == false && row["MenuType"].ToString() == "2")
                        {
                            sb.Append(" <li><a href='" + row["MenuTypeValue"] + "'>" + row["MenuName_UL"] + _isNewFlag + "</a>");
                        }

                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_UL"] + _isNewFlag + "</a>");
                        }
                    }
                    sb.Append("\t" + AddUrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "MainMenu_Ur.xml");
            }
        }
        #endregion

        #region Footer Menu 
        private void getEnglishFooterMenu()
        {
            objMenuSchema.ActionType = "GetEnglishFooterMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "FM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];

                DataView dvMenu = new DataView(dt);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul class='list-inline'>");
                foreach (DataRowView row in dvMenu)
                {
                    if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                    {
                        sb.Append("<li><a target='_blank' title='External Website that opens in a new window' style='color:#fff !important' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName"] + "</a>/</li>");
                    }
                    else
                    {
                        sb.Append("<li><a  style='color:#fff !important' href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName"] + "</a>/</li>");
                    }
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "Footer_En.xml");
            }
        }

        private void getMarathiFooterMenu()
        {
            objMenuSchema.ActionType = "GetMarathiFooterMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "FM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul class='list-inline'>");
                foreach (DataRowView row in dvMenu)
                {
                    if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                    {
                        sb.Append("<li><a target='_blank' title='External Website that opens in a new window' style='color:#fff !important' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_LL"] + "</a> /</li>");
                    }
                    else
                    {
                        sb.Append("<li><a style='color:#fff !important' href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_LL"] + "</a> /</li>");
                    }
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "Footer_Mr.xml");
            }
        }

        private void getUrduFooterMenu()
        {
            objMenuSchema.ActionType = "GetUrduFooterMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "FM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];

                DataView dvMenu = new DataView(dt);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul class='list-inline'>");
                foreach (DataRowView row in dvMenu)
                {
                    if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                    {
                        sb.Append("<li><a target='_blank' title='External Website that opens in a new window' style='color:#fff !important' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_UL"] + "</a>/</li>");
                    }
                    else
                    {
                        sb.Append("<li><a style='color:#fff !important' href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_UL"] + "</a>/</li>");
                    }
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "Footer_Ur.xml");
            }
        }
        #endregion

        #region Child Menu 
        private string AddEnMenuChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul class='dropdown-menu' role='menu'>");
                foreach (DataRowView childView in viewItem)
                {
                    DataView vwNested = new DataView(table, "ParentID = " + childView["MenuID"].ToString(), "", DataViewRowState.OriginalRows);
                    // Added by vaibhav
                    _isNewFlag = IsNewFlag(childView["IsNewFlag"].ToString());

                    if (vwNested.Count > 0)
                    {
                        sb.Append(" <li class='dropdown-submenu'><a href='#'>" + childView["MenuName"].ToString() + _isNewFlag + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddEnMenuChildItems(table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                        {
                            //sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName"] + _isNewFlag + "</a>");
                            sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "'>" + childView["MenuName"] + _isNewFlag + "</a>");
                            sb.Append("\n");
                            sb.Append("\t" + AddEnMenuChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                            sb.Append("</li>");
                        }
                        else
                        {
                            String strQuerystr = childView["MenuTypeValue"].ToString();
                            if (strQuerystr.Contains("?") == true)
                            {
                                String[] strArr = strQuerystr.Split(new char[] { '?' });
                                if (strArr.Length > 1)
                                {
                                    strQuerystr = "?" + strArr[1];
                                    strQuerystr = strQuerystr.Replace("&", "&amp;");
                                    sb.Append("\t" + " <li><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + strQuerystr + "'>" + childView["MenuName"] + _isNewFlag + "</a>");
                                }
                                else
                                {
                                    sb.Append("\t" + " <li><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName"] + _isNewFlag + "</a>");
                                }
                            }
                            else
                            {
                                sb.Append("\t" + " <li><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName"] + _isNewFlag + "</a>");
                            }
                            sb.Append("\n");
                            sb.Append("\t" + AddEnMenuChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                            sb.Append("</li>");
                        }
                    }
                }
                sb.AppendLine("\t" + "</ul>");
                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        private string AddMrMenuChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul class='dropdown-menu' role='menu'>");
                foreach (DataRowView childView in viewItem)
                {
                    DataView vwNested = new DataView(table, "ParentID = " + childView["MenuID"].ToString(), "", DataViewRowState.OriginalRows);
                    // Added by vaibhav
                    _isNewFlag = IsNewFlag(childView["IsNewFlag"].ToString());

                    if (vwNested.Count > 0)
                    {
                        sb.Append(" <li class='dropdown-submenu'><a href='#'>" + childView["MenuName_LL"].ToString() + _isNewFlag + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrMenuChildItems(table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                        {
                            //sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName_LL"] + _isNewFlag + "</a>");
                            sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "'>" + childView["MenuName_LL"] + _isNewFlag + "</a>");
                            sb.Append("\n");
                            sb.Append("\t" + AddMrMenuChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                            sb.Append("</li>");
                        }
                        else
                        {
                            String strQuerystr = childView["MenuTypeValue"].ToString();
                            if (strQuerystr.Contains("?") == true)
                            {
                                String[] strArr = strQuerystr.Split(new char[] { '?' });
                                if (strArr.Length > 1)
                                {
                                    strQuerystr = "?" + strArr[1];
                                    strQuerystr = strQuerystr.Replace("&", "&amp;");
                                    sb.Append("\t" + " <li><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + strQuerystr + "'>" + childView["MenuName_LL"] + _isNewFlag + "</a>");
                                }
                                else
                                {
                                    sb.Append("\t" + " <li><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_LL"] + _isNewFlag + "</a>");
                                }
                            }
                            else
                            {
                                sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_LL"] + _isNewFlag + "</a>");
                            }
                            sb.Append("\n");
                            sb.Append("\t" + AddMrMenuChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                            sb.Append("</li>");
                        }
                    }
                }
                sb.AppendLine("\t" + "</ul>");

                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        private string AddUrMenuChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul class='dropdown-menu' role='menu'>");
                foreach (DataRowView childView in viewItem)
                {
                    DataView vwNested = new DataView(table, "ParentID = " + childView["MenuID"].ToString(), "", DataViewRowState.OriginalRows);
                    // Added by vaibhav
                    _isNewFlag = IsNewFlag(childView["IsNewFlag"].ToString());

                    if (vwNested.Count > 0)
                    {
                        sb.Append(" <li class='dropdown-submenu'><a href='#'>" + childView["MenuName_UL"].ToString() + _isNewFlag + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddUrMenuChildItems(table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                        {
                            //sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName_LL"] + _isNewFlag + "</a>");
                            sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "'>" + childView["MenuName_UL"] + _isNewFlag + "</a>");
                            sb.Append("\n");
                            sb.Append("\t" + AddUrMenuChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                            sb.Append("</li>");
                        }
                        else
                        {
                            String strQuerystr = childView["MenuTypeValue"].ToString();
                            if (strQuerystr.Contains("?") == true)
                            {
                                String[] strArr = strQuerystr.Split(new char[] { '?' });
                                if (strArr.Length > 1)
                                {
                                    strQuerystr = "?" + strArr[1];
                                    strQuerystr = strQuerystr.Replace("&", "&amp;");
                                    sb.Append("\t" + " <li><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + strQuerystr + "'>" + childView["MenuName_UL"] + _isNewFlag + "</a>");
                                }
                                else
                                {
                                    sb.Append("\t" + " <li><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_UL"] + _isNewFlag + "</a>");
                                }
                            }
                            else
                            {
                                sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_UL"] + _isNewFlag + "</a>");
                            }
                            sb.Append("\n");
                            sb.Append("\t" + AddUrMenuChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                            sb.Append("</li>");
                        }
                    }
                }
                sb.AppendLine("\t" + "</ul>");

                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        #endregion

        #region Other Menu 
        private void getEnglishOtherMenu()
        {
            objMenuSchema.ActionType = "GetEnglishOtherMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "OM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='verticalmenu' class='glossymenu'> ");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName"] + _isNewFlag + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName"] + _isNewFlag + "</a>");
                        }
                    }
                    sb.Append("\t" + AddEnOtherChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "Other_En.xml");
            }
        }

        private void getMarathiOtherMenu()
        {
            objMenuSchema.ActionType = "GetMarathiOtherMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "OM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];

                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='verticalmenu' class='glossymenu'> ");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    // Added by vaibhav
                    _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_LL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_LL"] + _isNewFlag + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_LL"] + _isNewFlag + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrOtherChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");

                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "Other_Mr.xml");
            }
        }

        private void getUrduOtherMenu()
        {
            objMenuSchema.ActionType = "GetUrduOtherMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "OM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='verticalmenu' class='glossymenu'> ");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_UL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_UL"] + _isNewFlag + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_UL"] + _isNewFlag + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrOtherChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");

                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "Other_Ur.xml");
            }
        }

        #endregion

        #region Other Child Menu 
        private string AddEnOtherChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li class='lastChild'><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddEnOtherChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li class='lastChild'><a  href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddEnOtherChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");
                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        private string AddMrOtherChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li class='lastChild'><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName_LL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrOtherChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li class='lastChild'><a href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_LL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrOtherChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");

                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        private string AddUrOtherChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li class='lastChild'><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName_UL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrOtherChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li class='lastChild'><a href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_UL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrOtherChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");

                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }
        #endregion

        protected void grdManuList_delete(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void grdManuList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdManuList.PageIndex = e.NewPageIndex;
            grdManuList.DataBind();
            BindGrid();
        }

        #region Quick Menu 

        private void GetEnglishQuickMenu()
        {

            objMenuSchema.ActionType = "GetEnglishQuickMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataView dvQuickMn = new DataView(ds.Tables[1]);
                    dvQuickMn.RowFilter = "MenuID =" + dr["MenuID"];
                    if (dvQuickMn.ToTable().Rows.Count > 0)
                    {
                        sb.AppendLine("<Menu id='" + dr["MenuID"] + "'>");
                        DataView dvMenu = new DataView(dvQuickMn.ToTable());
                        dvMenu.RowFilter = "ParentID = 0";

                        DataView viewItem = new DataView(dvQuickMn.ToTable());
                        foreach (DataRowView row in dvMenu)
                        {
                            viewItem.RowFilter = "ParentID = " + row["QuickMenuID"];

                            _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());
                            if (viewItem.ToTable().Rows.Count > 0)
                            {
                                sb.Append(" <li><a href='#'>" + row["QuickMenuName"].ToString() + "</a>");
                            }
                            else
                            {
                                if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                                {
                                    sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?QuickMenuID=" + row["QuickMenuID"] + "'>" + row["QuickMenuName"] + _isNewFlag + "</a>");
                                }
                                else
                                {
                                    sb.Append(" <li><a  href='" + UrlBuilding(Convert.ToString(row["QuickMenuID"]), Convert.ToString(row["QuickMenuName"])) + "'>" + row["QuickMenuName"] + _isNewFlag + "</a>");
                                }
                            }
                            sb.Append("\t" + AddEnChildItems(dvMenu.Table, Convert.ToInt32(row["QuickMenuID"])));
                            sb.Append("</li>");
                            sb.Append("\n");
                        }

                        sb.AppendLine("</Menu>");
                    }
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickMenu_En.xml");
            }
        }

        private void GetMarathiQuickMenu()
        {
            objMenuSchema.ActionType = "GetMarathiQuickMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataView dvQuickMn = new DataView(ds.Tables[1]);
                    dvQuickMn.RowFilter = "MenuID =" + dr["MenuID"];


                    if (dvQuickMn.ToTable().Rows.Count > 0)
                    {
                        sb.AppendLine("<Menu id='" + dr["MenuID"] + "'>");
                        DataView dvMenu = new DataView(dvQuickMn.ToTable());
                        dvMenu.RowFilter = "ParentID = 0";


                        DataView viewItem = new DataView(dvQuickMn.ToTable());
                        foreach (DataRowView row in dvMenu)
                        {
                            viewItem.RowFilter = "ParentID = " + row["QuickMenuID"];
                            _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                            if (viewItem.ToTable().Rows.Count > 0)
                            {
                                sb.Append(" <li><a href='#'>" + row["QuickMenuName_LL"].ToString() + "</a>");
                            }
                            else
                            {
                                if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                                {
                                    sb.Append(" <li><a href='" + row["MenuTypeValue"] + "?QuickMenuID=" + row["QuickMenuID"] + "'>" + row["QuickMenuName_LL"] + _isNewFlag + "</a>");
                                }
                                else
                                {
                                    sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["QuickMenuID"]), Convert.ToString(row["QuickMenuName_LL"])) + "'>" + row["QuickMenuName_LL"] + _isNewFlag + "</a>");
                                }
                            }
                            sb.Append("\t" + AddMrChildItems(dvMenu.Table, Convert.ToInt32(row["QuickMenuID"])));
                            sb.Append("</li>");
                            sb.Append("\n");
                        }
                        sb.AppendLine("</Menu>");
                    }
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickMenu_Mr.xml");
            }
        }

        private void GetUrduQuickMenu()
        {
            objMenuSchema.ActionType = "GetUrduQuickMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataView dvQuickMn = new DataView(ds.Tables[1]);
                    dvQuickMn.RowFilter = "MenuID =" + dr["MenuID"];


                    if (dvQuickMn.ToTable().Rows.Count > 0)
                    {
                        sb.AppendLine("<Menu id='" + dr["MenuID"] + "'>");
                        DataView dvMenu = new DataView(dvQuickMn.ToTable());
                        dvMenu.RowFilter = "ParentID = 0";


                        DataView viewItem = new DataView(dvQuickMn.ToTable());
                        foreach (DataRowView row in dvMenu)
                        {
                            viewItem.RowFilter = "ParentID = " + row["QuickMenuID"];
                            _isNewFlag = IsNewFlag(row["IsNewFlag"].ToString());

                            if (viewItem.ToTable().Rows.Count > 0)
                            {
                                sb.Append(" <li><a href='#'>" + row["QuickMenuName_UL"].ToString() + "</a>");
                            }
                            else
                            {
                                if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                                {
                                    sb.Append(" <li><a href='" + row["MenuTypeValue"] + "?QuickMenuID=" + row["QuickMenuID"] + "'>" + row["QuickMenuName_UL"] + _isNewFlag + "</a>");
                                }
                                else
                                {
                                    sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["QuickMenuID"]), Convert.ToString(row["QuickMenuName_UL"])) + "'>" + row["QuickMenuName_UL"] + _isNewFlag + "</a>");
                                }
                            }
                            sb.Append("\t" + AddMrChildItems(dvMenu.Table, Convert.ToInt32(row["QuickMenuID"])));
                            sb.Append("</li>");
                            sb.Append("\n");
                        }
                        sb.AppendLine("</Menu>");
                    }
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickMenu_Ur.xml");
            }
        }

        #endregion

        #region Quick Child Menu 
        private string AddEnChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li><a href='" + childView["MenuTypeValue"] + "?QuickMenuID=" + childView["QuickMenuID"] + "'>" + childView["QuickMenuName"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddEnChildItems(viewItem.Table, Convert.ToInt32(childView["QuickMenuID"])));
                        sb.Append("\n");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["QuickMenuID"]), Convert.ToString(childView["QuickMenuName"])) + "'>" + childView["QuickMenuName"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddEnChildItems(viewItem.Table, Convert.ToInt32(childView["QuickMenuID"])));
                        sb.Append("\n");
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");

                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }
     
        private string AddMrChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li><a href='" + childView["MenuTypeValue"] + "?QuickMenuID=" + childView["QuickMenuID"] + "'>" + childView["QuickMenuName_LL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrChildItems(viewItem.Table, Convert.ToInt32(childView["QuickMenuID"])));
                        sb.Append("\n");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["QuickMenuID"]), Convert.ToString(childView["QuickMenuName_LL"])) + "'>" + childView["QuickMenuName_LL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrChildItems(viewItem.Table, Convert.ToInt32(childView["QuickMenuID"])));
                        sb.Append("\n");
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");

                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        private string AddUrChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li><a href='" + childView["MenuTypeValue"] + "?QuickMenuID=" + childView["QuickMenuID"] + "'>" + childView["QuickMenuName_UL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrChildItems(viewItem.Table, Convert.ToInt32(childView["QuickMenuID"])));
                        sb.Append("\n");
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["QuickMenuID"]), Convert.ToString(childView["QuickMenuName_UL"])) + "'>" + childView["QuickMenuName_UL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddMrChildItems(viewItem.Table, Convert.ToInt32(childView["QuickMenuID"])));
                        sb.Append("\n");
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");

                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }
        #endregion

        #region  Function which returns Quick Menu
        private string GetEnQuickMenuByMenuID(int MenuID)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(File.ReadAllText(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickMenu_En.xml").ToString());

                XmlNodeList xnList = xml.SelectNodes("/ul/Menu[@id='" + MenuID.ToString() + "']");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (XmlNode xn in xnList)
                {

                    sb.Append(xn.InnerXml.ToString());

                }
                sb.AppendLine("</ul>");
                return sb.ToString();
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        private string GetMrQuickMenuByMenuID(int MenuID)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(File.ReadAllText(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickMenu_Mr.xml").ToString());

                XmlNodeList xnList = xml.SelectNodes("/ul/Menu[@id='" + MenuID.ToString() + "']");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (XmlNode xn in xnList)
                {
                    sb.Append(xn.InnerXml.ToString());
                }
                sb.AppendLine("</ul>");
                return sb.ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }

        private string GetGrQuickMenuByMenuID(int MenuID)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(File.ReadAllText(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickMenu_Gr.xml").ToString());

                XmlNodeList xnList = xml.SelectNodes("/ul/Menu[@id='" + MenuID.ToString() + "']");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul id='nav'>");
                foreach (XmlNode xn in xnList)
                {
                    sb.Append(xn.InnerXml.ToString());
                }
                sb.AppendLine("</ul>");
                return sb.ToString();
            }
            catch (Exception ex)
            { throw ex; }
        }
        #endregion

        #region Generate SiteMap
        protected void btnGenSiteMap_Click(object sender, EventArgs e)
        {
            try
            {
                SiteMap();
                SiteMap_Mr();
                SiteMap_Gr();
                Alert("Sitemap Generated Successfully.");
            }
            catch (Exception ex)
            { throw ex; }
        }

        private void SiteMap()
        {
            objMenuSchema.ActionType = "SiteMap";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul >");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddSiteMapChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "SiteMap_En.xml");
            }
        }

        private void SiteMap_Mr()
        {
            objMenuSchema.ActionType = "SiteMap_Mr";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul >");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_LL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_LL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_LL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddSiteMapChildItems_Mr(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "SiteMap_Mr.xml");
            }

        }

        private void SiteMap_Gr()
        {
            objMenuSchema.ActionType = "SiteMap_Ur";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul >");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_UL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_UL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_UL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddSiteMapChildItems_Ur(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "SiteMap_Ur.xml");
            }

        }
        #endregion

        #region Site Map Child Item
        private string AddSiteMapChildItems(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddSiteMapChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddSiteMapChildItems(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");
                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        private string AddSiteMapChildItems_Mr(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName_LL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddSiteMapChildItems_Mr(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_LL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddSiteMapChildItems_Mr(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");
                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }

        private string AddSiteMapChildItems_Ur(DataTable table, int menuid)
        {
            DataView viewItem = new DataView(table);
            viewItem.RowFilter = "ParentID = " + menuid;
            StringBuilder sb = new StringBuilder();
            if (viewItem.ToTable().Rows.Count > 0)
            {
                sb.Append("\n");
                sb.AppendLine("\t" + "<ul>");
                foreach (DataRowView childView in viewItem)
                {
                    if (Convert.ToBoolean(childView["IsExternalLink"]) == true)
                    {
                        sb.Append("\t" + " <li><a target='_blank' title='External Website that opens in a new window' href='" + childView["MenuTypeValue"] + "?MenuID=" + childView["MenuID"] + "'>" + childView["MenuName_UL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddSiteMapChildItems_Mr(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                    else
                    {
                        sb.Append("\t" + " <li><a href='" + UrlBuilding(Convert.ToString(childView["MenuID"]), Convert.ToString(childView["MenuName"])) + "'>" + childView["MenuName_UL"] + "</a>");
                        sb.Append("\n");
                        sb.Append("\t" + AddSiteMapChildItems_Mr(viewItem.Table, Convert.ToInt32(childView["MenuID"])));
                        sb.Append("</li>");
                    }
                }
                sb.AppendLine("\t" + "</ul>");
                return sb.ToString();
            }
            else
                return sb.Append("\n").ToString();
        }
        #endregion

        //Url Building 
        private string UrlBuilding(string first, string second)
        {
            return "~/" + first + "/" + second.TrimStart().TrimEnd().Replace("'", "''").Replace(" ", "-");
        }

        #region QuickLinkMenu
        private void getQuickLinkEnglishMenu()
        {
            objMenuSchema.ActionType = "GetQuickLinkEnglishMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "QM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            { 
            dt = ds.Tables[0];
            DataView dvMenu = new DataView(dt);
            dvMenu.RowFilter = "ParentID = 0";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            foreach (DataRowView row in dvMenu)
            {
                DataView viewItem = new DataView(dt);
                viewItem.RowFilter = "ParentID = " + row["MenuID"];
                if (viewItem.ToTable().Rows.Count > 0)
                {
                    sb.Append(" <li><a href='#'>" + row["MenuName"].ToString() + "</a>");
                }
                else
                {
                    if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                    {
                        sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName"] + "</a>");
                    }
                    else
                    {
                        sb.Append(" <li><a  href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName"] + "</a>");
                    }
                }
                sb.Append("\t" + AddEnMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                sb.Append("</li>");
            }
            sb.Append("\n");
            sb.AppendLine("</ul>");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sb.ToString());
            xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickLink_En.xml");
            }
        }
      
        private void getQuickLinkMarathiMenu()
        {
            objMenuSchema.ActionType = "GetQuickLinkMarathiMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "QM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_LL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_LL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_LL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickLink_Mr.xml");
            }
        }

        private void getQuickLinkUrduMenu()
        {
            objMenuSchema.ActionType = "GetQuickLinkUrduMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "QM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_UL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_UL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_UL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "QuickLink_Ur.xml");
            }
        }
        #endregion

        #region Mobile QuickLink Menu
        private void getMobileQuickLinkEnglishMenu()
        {
            objMenuSchema.ActionType = "GetMobileQuickLinkEnglishMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "QM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a  href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddEnMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "MobileQuickLink_En.xml");
            }
        }
 
        private void getMobileQuickLinkMarathiMenu()
        {
            objMenuSchema.ActionType = "GetMobileQuickLinkMarathiMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "QM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_LL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_LL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_LL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "MobileQuickLink_Mr.xml");
            }
        }
     
        private void getMobileQuickLinkUrduMenu()
        {
            objMenuSchema.ActionType = "GetMobileQuickLinkUrduMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "QM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];

                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_UL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_UL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_UL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "MobileQuickLink_Ur.xml");
            }
        }
        #endregion

        #region Important Menu
        private void getImportantLinkEnglishMenu()
        {

            objMenuSchema.ActionType = "GetImportantLinkEnglishMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "IM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];

                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a  href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddEnMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "ImportantLink_En.xml");
            }
        }
  
        private void getImportantLinkMarathiMenu()
        {
            objMenuSchema.ActionType = "GetImportantLinkMarathiMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "IM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_LL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_LL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_LL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "ImportantLink_Mr.xml");
            }
        }

        private void getImportantLinkUrduMenu()
        {
            objMenuSchema.ActionType = "GetImportantLinkUrduMenu";
            objMenuSchema.Menuid = 0;
            objMenuSchema.MenuCategory = "IM";
            ds = objMenuBL.GetMenuListDetails(objMenuSchema);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
                DataView dvMenu = new DataView(dt);
                dvMenu.RowFilter = "ParentID = 0";
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (DataRowView row in dvMenu)
                {
                    DataView viewItem = new DataView(dt);
                    viewItem.RowFilter = "ParentID = " + row["MenuID"];
                    if (viewItem.ToTable().Rows.Count > 0)
                    {
                        sb.Append(" <li><a href='#'>" + row["MenuName_UL"].ToString() + "</a>");
                    }
                    else
                    {
                        if (Convert.ToBoolean(row["IsExternalLink"]) == true)
                        {
                            sb.Append(" <li><a target='_blank' title='External Website that opens in a new window' href='" + row["MenuTypeValue"] + "?MenuID=" + row["MenuID"] + "'>" + row["MenuName_UL"] + "</a>");
                        }
                        else
                        {
                            sb.Append(" <li><a href='" + UrlBuilding(Convert.ToString(row["MenuID"]), Convert.ToString(row["MenuName"])) + "'>" + row["MenuName_UL"] + "</a>");
                        }
                    }
                    sb.Append("\t" + AddMrMenuChildItems(dvMenu.Table, Convert.ToInt32(row["MenuID"])));
                    sb.Append("</li>");
                }
                sb.Append("\n");
                sb.AppendLine("</ul>");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
                xmlDoc.Save(Server.MapPath("~/Admin/MenuManagement/XmlMenu/") + "ImportantLink_Ur.xml");
            }
        }

        #endregion

        public string IsNewFlag(string isNewFilag)
        {
            if (isNewFilag == "True")
            { return " <img src='../../Images/gif_new.gif'/>"; }
            else
            { return ""; }
        }
    }
}