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
using BL;
using Schema;

namespace PMMYA.Admin.MenuManagement
{
    public partial class AddPlaceHolderContent : System.Web.UI.Page
    {
        #region Public variable declaration
        //BL.BL MAHAITDBAccess;
        DataSet ds;
        DataTable dt;
        PlaceHolderSchema objPlaceHolderSchema = new PlaceHolderSchema();
        PlaceholderBAL objPlaceholderBAL = new PlaceholderBAL();
        #endregion

        protected void Page_InIt(object sender, EventArgs e)
        {
            //MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region For Edit
                if (Request.QueryString["Mode"] == "Edit" && Request.QueryString["Mode"] != null)
                {
                    try
                    {
                        objPlaceHolderSchema.PlaceholderId= Convert.ToInt32(Request.QueryString["shvid"]);
                        ds = objPlaceholderBAL.GetPlaceHolderContentDetails(objPlaceHolderSchema);
                        dt = ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            txtPageTitle.Text = dt.Rows[0]["PlaceHolderName"].ToString();
                            txtEditor1.Text = HttpUtility.HtmlDecode(dt.Rows[0]["ShortDescription"].ToString());
                            txtEditor2.Text = HttpUtility.HtmlDecode(dt.Rows[0]["ShortDescription_LL"].ToString());
                            txtEditor3.Text = HttpUtility.HtmlDecode(dt.Rows[0]["ShortDescription_UL"].ToString());
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
                    { throw ex; }
                }
                #endregion
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                PMMYA.WebServices.validateHtml objvalid = new WebServices.validateHtml();

                if (txtEditor1.Text.ToString() == "" || txtEditor1.Text.ToString() == string.Empty || txtEditor2.Text.ToString() == "" || txtEditor2.Text.ToString() == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Fill All Data !!!');window.location.href='PlaceHolderList.aspx';", true);
                    return;
                }
                if (!objvalid.ValidateHTML(txtEditor1.Text) || (!objvalid.ValidateHTML(txtEditor2.Text)))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Invalid Input !!!');window.location.href='PlaceHolderList.aspx';", true);
                    return;
                }
                if (UploadFile.HasFile)
                {
                    if (SaveUpload() == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Invalid Files !!!');window.location.href='PlaceHolderList.aspx';", true);
                        Clear();
                        return;
                    }
                }


                objPlaceHolderSchema.PlaceHolderName = txtPageTitle.Text;
                objPlaceHolderSchema.ShortDescription = txtEditor1.Text;
                objPlaceHolderSchema.ShortDescription_LL = txtEditor2.Text;
                objPlaceHolderSchema.ShortDescription_UL = txtEditor3.Text;

                if (Request.QueryString["Mode"] == "Edit")
                {
                    objPlaceHolderSchema.UpdatedBy = "";
                }
                else
                {
                    objPlaceHolderSchema.CreatedBy = "";
                }

                objPlaceHolderSchema.IsApprove = chkIsApprove.Checked;
                objPlaceHolderSchema.IsActive = chkActive.Checked;

            
                if (Request.QueryString["Mode"] == "Edit")
                {
                    objPlaceHolderSchema.PlaceholderId = Convert.ToInt32(Request.QueryString["shvid"]);
                    objPlaceHolderSchema.ActionType = "Edit";
                }
                else
                {
                    objPlaceHolderSchema.ActionType = "Insert";
                }
                int result = objPlaceholderBAL.SavePlaceHolderContentDeatails(objPlaceHolderSchema);
                if (result != 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Data saved Successfully !!!');window.location.href='PlaceHolderList.aspx'", true); Clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Data Not saved !!!')window.location.href='PlaceHolderList.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Clear()
        {
            txtEditor1.Text = "";
            txtEditor2.Text = "";
            txtEditor3.Text = "";
            txtPageTitle.Text = "";
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlaceHolderList.aspx", true);
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
            { retnVal = true; }
            return retnVal;
        }
    }
}