using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Helper;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using BL;
using Schema;

namespace PMMYA.Admin.MenuManagement
{
    public partial class CreateMenu : System.Web.UI.Page
    {
        #region Public variable declaration
        //BL.BL MAHAITDBAccess;
        string valueid;
        string valuepid;
        string InsertQuery;
        DataSet ds;
        DataTable dt;
        MenuBL ObjmenuBL = new MenuBL();
        MenuSchema objMenuSchema = new MenuSchema();
        int result = 0;
        #endregion


        protected void Page_Init(object sender, EventArgs e)
        {
           // MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["User"] = Session["UserInRole"];
                BindParentDropBox();
                BindMenuType();
                if (Convert.ToString(Request.QueryString["action"]) == "edit" && Request.QueryString["action"] != null)
                {
                    valueid = Request.QueryString["shvid"];
                    valuepid = Request.QueryString["pid"];
                    try
                    {
                        //DataTable t_dt, t_dt1;
                        //SqlCommand t_SQLCmd = new SqlCommand();
                        //SqlCommand t_SQLCmd1 = new SqlCommand();
                        //t_SQLCmd.Parameters.Add("@MenuID", SqlDbType.Int);
                        //t_SQLCmd.Parameters["@MenuID"].Value = valueid;
                        objMenuSchema.Menuid = Convert.ToInt16(valueid);

                        string MenuID = GetMenuID(valuepid);
                        if (MenuID != "0")
                        {
                            drpMenu.SelectedValue = MenuID;
                            BindChildDropBox(MenuID);
                            drpSubMenu.SelectedValue = valuepid;
                            drpSubMenu.Visible = true;
                        }
                        else
                        {
                            drpMenu.SelectedValue = valuepid;
                            drpSubMenu.Visible = false;
                        }


                        ds = ObjmenuBL.GetPagedata(objMenuSchema);
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            drpMenuCategory.SelectedValue = dt.Rows[0]["MenuCategory"].ToString();
                            drpMenuType.SelectedValue = dt.Rows[0]["MenuType"].ToString();

                            txtMenuName.Text = dt.Rows[0]["MenuName"].ToString();
                            txtMenuName_LL.Text = dt.Rows[0]["MenuName_LL"].ToString();
                            txtMDesc.Text = dt.Rows[0]["MetaDescription"].ToString();
                            txtMDesc_LL.Text = dt.Rows[0]["MetaDescription_LL"].ToString();

                            txtPageHead.Text = dt.Rows[0]["PageHeading"].ToString();
                            txtPageHead_LL.Text = dt.Rows[0]["PageHeading_LL"].ToString();

                            txtPageTitle.Text = dt.Rows[0]["PageTitle"].ToString();
                            txtPageTitle_LL.Text = dt.Rows[0]["PageTitle_LL"].ToString();

                            txtMKeywords.Text = dt.Rows[0]["MetaKeywords"].ToString();

                            txtMKeyWords_LL.Text = dt.Rows[0]["MetaKeywords_LL"].ToString();
                            txtSequence.Text = dt.Rows[0]["SequenceNo"].ToString();

                            txtMTValue.Text = dt.Rows[0]["MenuTypeValue"].ToString();

                            // Added By K.P on 22-05-2018
                            txtMenuName_UL.Text = dt.Rows[0]["MenuName_UL"].ToString();
                            txtMDesc_UL.Text = dt.Rows[0]["MetaDescription_UL"].ToString();
                            txtMKeyWords_UL.Text = dt.Rows[0]["MetaKeywords_UL"].ToString();
                            txtPageHead_UL.Text = dt.Rows[0]["PageHeading_UL"].ToString();
                            txtPageTitle_UL.Text = dt.Rows[0]["PageTitle_UL"].ToString();
                            //End

                            if (Convert.ToString(dt.Rows[0]["IsNewFlag"]) == "True")
                            { chkIsNew.Checked = true; }
                            else
                            { chkIsNew.Checked = false; }

                            if (Convert.ToString(dt.Rows[0]["Active"]) == "True")
                            { chkActive.Checked = true; }
                            else
                            { chkActive.Checked = false; }

                            if (Convert.ToString(dt.Rows[0]["IsExternalLink"]) == "True")
                            { chkNewTab.Checked = true; }
                            else
                            { chkNewTab.Checked = false; }

                            if (Convert.ToString(dt.Rows[0]["ForMobileVersion"]) == "True")
                            { chkmobileversion.Checked = true; }
                            else
                            { chkmobileversion.Checked = false; }
                        }
                    }
                    catch (Exception eee)
                    { throw eee; }
                }
            }
        }

        private void BindMenuType()
        {
            try
            {              
                ds = ObjmenuBL.GetMenuType();
                dt = ds.Tables[0];
                drpMenuType.DataSource = dt.DefaultView;
                drpMenuType.DataBind();
                drpMenuType.Items.Insert(0, new ListItem("Select", "0"));
                drpMenuType.SelectedValue = "0";
            }
            catch (Exception ee)
            { throw ee; }
        }

        private void BindParentDropBox()
        {
            try
            {
                ds = ObjmenuBL.GetParentList();
                dt = ds.Tables[0];
                drpMenu.DataSource = dt.DefaultView;
                drpMenu.DataBind();
                drpMenu.Items.Insert(0, new ListItem("Select", "0"));
                drpMenu.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindChildDropBox(string Parent)
        {
            try
            {
                drpSubMenu.Items.Clear();
                objMenuSchema.Parentid = Convert.ToInt32(Parent);
                ds = ObjmenuBL.GetChildList(objMenuSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    drpSubMenu.DataSource = dt.DefaultView;
                    drpSubMenu.DataBind();
                    drpSubMenu.Items.Insert(0, new ListItem("Select", "0"));
                    drpSubMenu.SelectedValue = "0";
                    drpSubMenu.Visible = true;
                }
                else
                { drpSubMenu.Visible = false; }
            }
            catch (Exception ee)
            { throw ee; }
        }

        protected void drpMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindChildDropBox(drpMenu.SelectedValue);
        }

        protected void drpMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!drpMenuType.Items.FindByText("Select").Selected)
                {
                    if (!drpMenuType.Items.FindByText("Link").Selected)
                    {
                        GetPageUrl(drpMenuType.SelectedValue);
                    }
                    else
                    {
                        txtMTValue.Text = "";
                        txtMTValue.Enabled = true;
                    }
                }
                else
                {
                    Alert("Please select Menu Type");
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void GetPageUrl(string RowId)
        {
            try
            {
                objMenuSchema.Rowid = Convert.ToInt32(RowId);
                ds = ObjmenuBL.GetPageUrl(objMenuSchema);
                dt = ds.Tables[0];
                if (dt.Rows.Count == 1)
                {
                    txtMTValue.Text = dt.Rows[0]["PageUrl"].ToString();
                    txtMTValue.Enabled = false;
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        private void Alert(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "alert('" + msg + "');", true);
        }

        private void Clear()
        {
            txtMDesc.Text = "";
            txtMenuName.Text = "";
            txtMKeywords.Text = "";
            txtSequence.Text = "";
            drpMenu.SelectedValue = "0";
            txtMDesc_LL.Text = "";
            txtMDesc_UL.Text = "";
            txtMenuName_LL.Text = "";
            txtMenuName_UL.Text = "";
            txtMKeyWords_LL.Text = "";
            txtMKeyWords_UL.Text = "";
            txtMTValue.Text = "";
            if (drpMenuType.SelectedValue != "0")
            {
                drpMenuType.SelectedValue = "0";
            }

            if (drpMenuCategory.SelectedValue != "0")
            {
                drpMenuCategory.SelectedValue = "0";
            }

            if (drpMenu.SelectedValue != "0")
            {
                drpSubMenu.SelectedValue = "0";
            }

            chkIsNew.Checked = false;

            txtPageHead.Text = "";
            txtPageHead_LL.Text = "";
            txtPageHead_UL.Text = "";
            lblerror.Text = "";
        }

        #region for edit
        private string GetMenuID(string valuepid)
        {
            if (valuepid == "0")
            {              
                drpMenu.Visible = false;
                Label1.Visible = false;
            }
            objMenuSchema.Parentid = Convert.ToInt32(valuepid);
            ds = ObjmenuBL.GetMenuId(objMenuSchema);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ParentID"].ToString();
            }
            else
            {
                return "0";
            }
        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)   // Anand :- UspDMLMenuMaster
        {
            try
            {
                if (drpMenuCategory.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "message", "alert('Please Select Menu Category!!')", true);
                }
                else
                {
                    SqlCommand t_SQLCmd = new SqlCommand();
                    byte[] t_Image = new byte[fileMenu.PostedFile.ContentLength];
                    HttpPostedFile t_ImageReader = fileMenu.PostedFile;

                    t_ImageReader.InputStream.Read(t_Image, 0, (int)fileMenu.PostedFile.ContentLength);

                    objMenuSchema.MenuName = txtMenuName.Text;
                    objMenuSchema.MenuName_LL= txtMenuName_LL.Text;
                    objMenuSchema.MenuName_UL= txtMenuName_UL.Text;
                    objMenuSchema.IsNewflag= chkIsNew.Checked;
                    objMenuSchema.Active = chkActive.Checked;                   
                    objMenuSchema.IsEternalLink = chkNewTab.Checked;
                    objMenuSchema.MetaDescription = txtMDesc.Text;
                    objMenuSchema.MetaDescription_LL= txtMDesc_LL.Text;
                    objMenuSchema.MetaDescription_UL = txtMDesc_UL.Text;
                    objMenuSchema.MetaKeywords = txtMKeywords.Text;
                    objMenuSchema.MetaKeywords_LL = txtMKeyWords_LL.Text;
                    objMenuSchema.MetaKeywords_UL = txtMKeyWords_UL.Text;
                    objMenuSchema.MenuImage = t_Image;
                    objMenuSchema.SequenceNo = Convert.ToInt32(txtSequence.Text);
                    objMenuSchema.MenuCategory = drpMenuCategory.SelectedValue;
                    objMenuSchema.MenuType = Convert.ToInt32(drpMenuType.SelectedValue);
                    objMenuSchema.MenuTypeValue = txtMTValue.Text;

                    if (drpMenu.SelectedValue != "0")
                    {
                        if (drpSubMenu.SelectedValue != "0" && drpSubMenu.SelectedValue.Trim() != "")
                        {                          
                            objMenuSchema.Parentid= Convert.ToInt32(drpSubMenu.SelectedValue);
                        }
                        else
                        {
                            objMenuSchema.Parentid = Convert.ToInt32(drpMenu.SelectedValue);
                        }
                    }
                    else
                    {
                        objMenuSchema.Parentid = Convert.ToInt32(drpMenu.SelectedValue);
                    }

                    //t_SQLCmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier);
                    //t_SQLCmd.Parameters["@RoleID"].Value = DBNull.Value;

                    //t_SQLCmd.Parameters.Add("@CreatedBy", SqlDbType.Int);
                    //t_SQLCmd.Parameters["@CreatedBy"].Value = DBNull.Value;

                    objMenuSchema.PageHeading = txtPageHead.Text;
                    objMenuSchema.PageHeading_LL = txtPageHead_LL.Text;
                    objMenuSchema.PageHeading_UL = txtPageHead_UL.Text;
                    objMenuSchema.PageTitle = txtPageTitle.Text;
                    objMenuSchema.PageTitle_LL = txtPageTitle_LL.Text;
                    objMenuSchema.PageTitle_UL = txtPageTitle_UL.Text;
                    objMenuSchema.ForMobileVersion = chkmobileversion.Checked;

                    if (Request.QueryString["action"] == "edit")
                    {
                        valueid = Request.QueryString["shvid"];
                        //t_SQLCmd.Parameters.Add("@MenuID", SqlDbType.Int);
                        //t_SQLCmd.Parameters["@MenuID"].Value = valueid;
                        objMenuSchema.Menuid = Convert.ToInt32(valueid);
                        if (fileMenu.HasFile)
                        {

                            string filenameExt = fileMenu.FileName;
                            string fileExt = System.IO.Path.GetExtension(fileMenu.FileName);
                            objMenuSchema.FileExt = fileExt;
                            if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".PNG" || fileExt == ".png" || fileExt == ".bmp" || fileExt == ".tiff")
                            {
                                if (CommonFuntion.check_Extensions(filenameExt))
                                {
                                    Stream fs = null;
                                    fs = fileMenu.PostedFile.InputStream;
                                    BinaryReader br1 = new BinaryReader(fs);
                                    byte[] filebytes = fileMenu.FileBytes;
                                    if (CommonFuntion.isValidFile(filebytes, CommonFuntion.FileType.Image, fileMenu.PostedFile.ContentType))
                                    {
                                        String ext = fileMenu.FileName;
                                        String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                                        if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                                        {

                                            objMenuSchema.ActionType = "edit";                                         
                                            result = ObjmenuBL.SaveMenuDeatails(objMenuSchema);
                                            if (result != 0)
                                            {
                                                Clear();
                                                lblerror.Text = "";
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='MenuList.aspx'", true);
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error !!!')", true);
                                            }
                                        }
                                    }
                                    else
                                    { lblerror.Text = "Please Upload Image File only"; }
                                }
                                else
                                { lblerror.Text = "Please Upload Image File only"; }
                            }
                            else
                            { lblerror.Text = "Please Upload Image File only"; }
                        }
                        else
                        {
                            objMenuSchema.ActionType = "edit";                           
                            result = ObjmenuBL.SaveMenuDeatails(objMenuSchema);
                            if (result != 0)
                            {
                                Clear();
                                lblerror.Text = "";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='MenuList.aspx'", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error !!!')", true);
                            }
                        }
                    }
                    else
                    {
                        if (fileMenu.HasFile)
                        {
                            Stream fs = null;
                            fs = fileMenu.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(fs);
                            string filenameExt = fileMenu.FileName;

                            string fileExt = System.IO.Path.GetExtension(fileMenu.FileName);
                            objMenuSchema.FileExt = fileExt;
                            if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".PNG" || fileExt == ".png" || fileExt == ".bmp" || fileExt == ".tiff")
                            {
                                byte[] pdffile = fileMenu.FileBytes;
                                if (CommonFuntion.check_Extensions(filenameExt))
                                {
                                    if (CommonFuntion.isValidFile(pdffile, CommonFuntion.FileType.Image, fileMenu.PostedFile.ContentType))
                                    {
                                        String ext = fileMenu.FileName;
                                        String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                                        if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                                        {
                                            objMenuSchema.ActionType = "Insert";
                                            result = ObjmenuBL.SaveMenuDeatails(objMenuSchema);
                                            if (result != 0)
                                            {
                                                Clear();
                                                lblerror.Text = "";
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='MenuList.aspx'", true);
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error !!!')", true);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lblerror.Text = "Please Upload Image File only";
                                    }
                                }
                                else
                                {
                                    lblerror.Text = "Please Upload Image File only";
                                }
                            }
                            else
                            {
                                lblerror.Text = "Please Upload Image File only";
                            }
                        }
                        else
                        {
                            objMenuSchema.ActionType = "Insert";
                            result = ObjmenuBL.SaveMenuDeatails(objMenuSchema);
                            if (result != 0)
                            {
                                Clear();
                                lblerror.Text = "";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='MenuList.aspx'", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error !!!')", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            { throw ee; }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuList.aspx");
        }
    }
}