using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Helper;
using System.IO;
using System.Text;
using BL;
using Schema;

namespace PMMYA.Admin.MenuManagement
{
    public partial class AddMenuContent : System.Web.UI.Page
    {
        #region Public variable declaration
       // BL.BL MAHAITDBAccess;
        MenuContentBL objmenuContentBL = new MenuContentBL();
        MenuContentSchema ObjmenuContentSchema = new MenuContentSchema();
        DataTable dt;
        DataSet ds;
        #endregion

        protected void Page_InIt(object sender, EventArgs e)
        {
           // MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string abc = Request.QueryString["shvid"];
            if (!IsPostBack)
            {
                #region For Edit
                if (Request.QueryString["Mode"] == "Edit" && Request.QueryString["Mode"] != null)
                {
                    try
                    {
                        ObjmenuContentSchema.MenuContentID = Convert.ToInt32(Request.QueryString["shvid"]);
                        ds = objmenuContentBL.GetMenuContentDetails(ObjmenuContentSchema);
                        dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {

                            txtPageTitle.Text = dt.Rows[0]["PageTitle"].ToString();
                            txtPageTitle_LL.Text = dt.Rows[0]["PageTitle_LL"].ToString();
                            txtPageTitle_UL.Text = dt.Rows[0]["PageTitle_UL"].ToString();
                            txtEditor2.Text = HttpUtility.HtmlDecode(dt.Rows[0]["ShortDescription"].ToString());
                            txtEditor1.Text = HttpUtility.HtmlDecode(dt.Rows[0]["ShortDescription_LL"].ToString());
                            txtEditor3.Text = HttpUtility.HtmlDecode(dt.Rows[0]["LongDescription"].ToString());
                            txtEditor4.Text = HttpUtility.HtmlDecode(dt.Rows[0]["LongDescription_LL"].ToString());
                            txtEditor5.Text = HttpUtility.HtmlDecode(dt.Rows[0]["ShortDescription_UL"].ToString());
                            txtEditor6.Text = HttpUtility.HtmlDecode(dt.Rows[0]["LongDescription_UL"].ToString());
                            txtSequenceNo.Text = dt.Rows[0]["SequenceNo"].ToString();
                            if (Convert.ToString(dt.Rows[0]["IsApprove"]) == "True")
                            {
                                chkIsApprove.Checked = true;
                            }
                            else
                            {
                                chkIsApprove.Checked = false;
                            }

                            if (Convert.ToString(dt.Rows[0]["Active"]) == "True")
                            {
                                chkActive.Checked = true;
                            }
                            else
                            {
                                chkActive.Checked = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                #endregion
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {

            try
            {
                PMMYA.WebServices.validateHtml objvalid = new WebServices.validateHtml();
                bool flg = true;

                if (txtEditor3.Text.ToString() == "" || txtEditor3.Text.ToString() == string.Empty || txtEditor4.Text.ToString() == "" || txtEditor4.Text.ToString() == string.Empty || txtEditor6.Text.ToString() == "" || txtEditor6.Text.ToString() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert(' Please Long Description !!!');window.location.href='MenuContentList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true);
                    return;
                }
                if ((!objvalid.ValidateHTML(txtEditor1.Text)) || (!objvalid.ValidateHTML(txtEditor2.Text)) || (!objvalid.ValidateHTML(txtEditor3.Text)) || (!objvalid.ValidateHTML(txtEditor4.Text)) || (!objvalid.ValidateHTML(txtEditor5.Text)) || (!objvalid.ValidateHTML(txtEditor6.Text)))
                {
                    flg = false;
                    txtEditor4.Text = "";
                }
                if (flg)
                {
                    if (UploadFile.HasFile)
                    {
                        if (SaveUpload() == false)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Invalid Files !!!');window.location.href='MenuContentList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true);                           
                            Clear();
                            return;
                        }
                    }


                    SqlCommand t_SQLCmd = new SqlCommand();

                    ObjmenuContentSchema.PageTitle = txtPageTitle.Text;
                    ObjmenuContentSchema.PageTitle_LL = txtPageTitle_LL.Text;
                    ObjmenuContentSchema.PageTitle_UL = txtPageTitle_UL.Text;
                    ObjmenuContentSchema.ShortDescription = txtEditor2.Text;
                    ObjmenuContentSchema.ShortDescription_LL = txtEditor1.Text;
                    ObjmenuContentSchema.ShortDescription_UL = txtEditor5.Text;
                    ObjmenuContentSchema.LongDescription = txtEditor3.Text;
                    ObjmenuContentSchema.LongDescription_LL = txtEditor4.Text;
                    ObjmenuContentSchema.LongDescription_UL = txtEditor6.Text;

                    if (txtSequenceNo.Text.ToString() != "" || txtSequenceNo.Text.ToString() != string.Empty)
                    {
                        ObjmenuContentSchema.SequenceNo = Convert.ToInt32(txtSequenceNo.Text);
                    }
                    else
                    {
                        ObjmenuContentSchema.SequenceNo = 0;
                    }
                    ObjmenuContentSchema.MenuID = Convert.ToInt32(Request.QueryString["MenuID"]);

                    if (Request.QueryString["Mode"] == "Edit")
                    {
                        ObjmenuContentSchema.UpdatedBy = "";
                    }
                    else
                    {
                        ObjmenuContentSchema.CreatedBy = "";
                    }
                    ObjmenuContentSchema.IsApprove = chkIsApprove.Checked;
                    ObjmenuContentSchema.IsActive = chkActive.Checked;


                    if (Request.QueryString["Mode"] == "Edit")
                    {

                        ObjmenuContentSchema.MenuContentID = Convert.ToInt32(Request.QueryString["shvid"]);
                        ObjmenuContentSchema.ActionType = "Edit";
                    }
                    else
                    {
                        ObjmenuContentSchema.ActionType = "Insert";
                    }
                    int result = objmenuContentBL.SaveMenuContentDeatails(ObjmenuContentSchema);
                   
                    if (result != 0)
                    {
                        string MenuId = Request.QueryString["MenuID"].ToString();
                        Clear();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully !!!');window.location.href='MenuContentList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true);
                    }
                    else
                    { ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data Not Saved !!!');window.location.href='MenuContentList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true); }
                }
                else
                { ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Invalid input !!!');window.location.href='MenuContentList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true); }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Insert Data !!!');window.location.href='MenuContentList.aspx?MenuID=" + Request.QueryString["MenuID"] + "';", true);
            }
        }

        private void Clear()
        {
            txtEditor1.Text = "";
            txtEditor2.Text = "";
            txtPageTitle.Text = "";
            txtPageTitle_LL.Text = "";
            txtPageTitle_UL.Text = "";
            txtSequenceNo.Text = "";
            txtEditor3.Text = "";
            txtEditor4.Text = "";
            txtEditor5.Text = "";
            txtEditor6.Text = "";
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuContentList.aspx?MenuID=" + Request.QueryString["MenuID"]);
        }

        private bool SaveUpload()
        {
            bool retnVal = false;
            lblmsg.Text = "";
            lblmsg.Text = "";
            int result = 0;
            HttpFileCollection fileCollection = Request.Files;
            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile1 = fileCollection[i];
                Stream fs = null;
                fs = uploadfile1.InputStream;// PhotoUpload.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] bytfile = br1.ReadBytes(fileCollection[i].ContentLength);

                if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, ".jpg") || CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, ".bmp") || CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, ".jpeg") || CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, ".png") || CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.PDF, ".pdf") || CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Video, ".mp3") || CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Video, ".mp4") || CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Video, ".avi"))
                { result = 1; }
                else
                { return false; }
            }

            for (int i = 0; i < fileCollection.Count; i++)
            {
                HttpPostedFile uploadfile1 = fileCollection[i];
                string fileNames = Path.GetFileName(uploadfile1.FileName);
                if (CommonFuntion.check_Extensions(fileNames) == true)
                {
                    if (uploadfile1.ContentLength > 0)
                    {
                        string ext = fileNames.ToString();
                        String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                        SqlCommand t_SQLCmd = new SqlCommand();
                        String strSQL = string.Empty;
                        string filename = string.Empty;

                        filename = fileNames;
                        filename = filename.Substring(0, filename.IndexOf('.')) + "_" + System.DateTime.Now.ToString().Replace("/", "_") + System.IO.Path.GetExtension(fileNames);
                        filename = filename.Replace(":", "_");
                        if (extention.ToLower() == "pdf")
                        {
                            uploadfile1.SaveAs(Server.MapPath("../../Site/Upload/Pdf/" + fileNames));
                        }
                        else if (extention.ToLower() == "jpg" || extention.ToLower() == "bmp" || extention.ToLower() == "jpeg" || extention.ToLower() == "png")
                        {
                            uploadfile1.SaveAs(Server.MapPath("../../Site/Upload/Images/" + fileNames));
                        }
                        else if (extention.ToLower() == "mp4" || extention.ToLower() == "mp3" || extention.ToLower() == "avi" || extention.ToLower() == "png")
                        {
                            uploadfile1.SaveAs(Server.MapPath("../../Site/Upload/Video/" + fileNames));
                        }
                    }
                }
            }
            if (result == 1)
            {
                retnVal = true;
            }
            return retnVal;
        }

    }
}