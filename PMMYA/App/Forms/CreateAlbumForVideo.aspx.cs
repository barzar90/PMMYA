using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Helper;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.Cryptography;
using BL;
using Schema;

namespace PMMYA.App.Forms
{
    public partial class CreateAlbumForVideo : System.Web.UI.Page
    {
        #region Public variable declaration
        Label ID, Name, TypeId; TextBox txtPhotoName, txtPhotoNameLL; FileUpload FileUpload;       
        DataSet ds;
        DataTable dt;
        AlbumBL objAlbumBL = new AlbumBL();
        AlbumSchema objAlbumSchema = new AlbumSchema();
        string videopath = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
        [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
        [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
        System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
        System.UInt32 dwMimeFlags,
        out System.UInt32 ppwzMimeOut,
        System.UInt32 dwReserverd);  

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ext = null; ;
                byte[] t_Image = null;
                Double FileSize = 0;
                

                if (ddlFileType.SelectedIndex == 1)
                {
                    videopath = Server.MapPath("../../Site/Upload/Video/Motivational/");
                }
                else
                {
                    videopath = Server.MapPath("../../Site/Upload/Video/SuccessStories/");
                }

                if (uploadVideo.HasFile)
                {
                    string videofile = uploadVideo.FileName;
                    double filesize = (double)uploadVideo.FileBytes.Length;
                    double fileinMB = filesize / (1024 * 1024);
                }

                //if (ddlFileType.SelectedValue == "1")
                //{
                //    if (uploadVideo.HasFile)
                //    {
                //        string fileextension = System.IO.Path.GetExtension(uploadVideo.FileName);
                //        if (fileextension.ToUpper() != ".MP3")
                //        {
                //            ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Invalid Audio File');", true);
                //            uploadVideo.Focus();
                //            return;
                //        }
                //    }
                //}
                if (ddlFileType.SelectedValue == "1"  || ddlFileType.SelectedValue=="2")
                {
                    Stream fs = null;
                    fs = uploadVideo.PostedFile.InputStream;
                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] bytes = br1.ReadBytes(uploadVideo.PostedFile.ContentLength);
                    if (CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Video, uploadVideo.PostedFile.ContentType))
                    {
                        String extention = Path.GetExtension(uploadVideo.FileName);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File Is InValid , Kindly Upload avi/mpg/mpg/flv/wmv/mp4 Formatted file.');", true); return;
                    }
                }


                if (uploadImage.HasFile)
                {

                    if (uploadImage.HasFile)
                    {
                        if (isValidAttachmentPhoto(uploadImage))
                        {
                            ext = System.IO.Path.GetExtension(uploadImage.FileName);
                            t_Image = uploadImage.FileBytes;
                            FileSize = uploadImage.PostedFile.ContentLength / 1024;

                            if (Convert.ToInt32(SavetoDB()) == 1)
                            {
                                ext = uploadImage.FileName;
                                String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                                if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                                {
                                    uploadImage.PostedFile.SaveAs(videopath + uploadImage.FileName);
                                    uploadVideo.PostedFile.SaveAs(videopath + uploadVideo.FileName);
                                    ddlFileType.SelectedValue = "Select";
                                    ClearControls();
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Upload File Successfully');", true);
                                }
                                else
                                {
                                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Invalid Image File!!!!');", true);
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Invalid Image File');", true); ;
                            return;
                        }
                    }


                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { }
        }

        private int SavetoDB()
        {
            int retval = 0;
            string path;
            try
            {
                if (ddlFileType.SelectedIndex == 1)
                {
                    path = ("../../Site/Upload/Video/Motivational/");
                }
                else
                {
                    path = ("../../Site/Upload/Video/SuccessStories/");
                }


                objAlbumSchema.VideoName = txtVideoTitle.Text.Trim();
                objAlbumSchema.VideoNameLL = txtVideoTitleLL.Text.Trim();
                objAlbumSchema.VideoNameUL= txtVideoTitleUL.Text.Trim();
                objAlbumSchema.Description = txtDescription.Text.Trim();
                objAlbumSchema.DescriptionLL = txtDescriptionLL.Text.Trim();
                objAlbumSchema.DescriptionUL= txtDescriptionUL.Text.Trim();
                objAlbumSchema.VideoPath = path + uploadVideo.FileName;
                objAlbumSchema.ImagePath = path + uploadImage.FileName;
                objAlbumSchema.Type = ddlFileType.SelectedValue;
                objAlbumSchema.CreatedBy =Convert.ToString(new Guid());
                objAlbumSchema.IPAddress = IPAddress();
                objAlbumSchema.Flag = "Add";
                retval = objAlbumBL.SaveVideo(objAlbumSchema);
            }
            catch (Exception ex)
            {
                retval = 0;
            }
            finally { }
            return retval;
        }

        private string IPAddress()
        {
            string strIPAddress;
            strIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIPAddress == null)
                strIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            return strIPAddress;
        }

        protected void DG_Photo_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            DG_Photo.EditItemIndex = -1;
            BindVideos();
        }

        protected void DG_Photo_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            SqlCommand t_SQLCmd = new SqlCommand();
            String strSQL = string.Empty;
            int isdelete;
            ID = (Label)(e.Item.FindControl("lblID"));

            objAlbumSchema.VideoID = Convert.ToInt32(ID.Text);
            objAlbumSchema.Actiontype = "PHOTO_DELETE";

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                isdelete = objAlbumBL.DMLAlbhumForVideo(objAlbumSchema);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Video Deleted successfully!');", true);
            }
            BindVideos();
        }

        protected void DG_Photo_EditCommand(object source, DataGridCommandEventArgs e)
        {
            DG_Photo.EditItemIndex = e.Item.ItemIndex;
            BindVideos();
        }

        protected void DG_Photo_ItemCommand(object source, DataGridCommandEventArgs e)
        {
        }

        protected void DG_Photo_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header)
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataSet ds = (DataSet)ViewState["video"];
                    DataRow[] DR;
                    ID = (Label)(e.Item.FindControl("lblID"));
                    DR = ds.Tables[0].Select("VideoID=" + ID.Text.Trim());
                    Name = (Label)(e.Item.FindControl("lblName"));
                }

            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DataSet ds = (DataSet)ViewState["video"];
                DataRow[] DR;
                txtPhotoName = (TextBox)(e.Item.FindControl("txtName"));
                ID = (Label)(e.Item.FindControl("lblID"));
                DR = ds.Tables[0].Select("VideoID=" + ID.Text.Trim());
                txtPhotoName.Text = DR[0]["Videoname"].ToString();
            }
        }

        protected void DG_Photo_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                string path = string.Empty;
                FileUpload  = (FileUpload)(e.Item.FindControl("FileUpload2"));
                txtPhotoName = (TextBox)(e.Item.FindControl("txtName"));
                txtPhotoNameLL = (TextBox)(e.Item.FindControl("txtNameLL"));
                SqlCommand t_SQLCmd = new SqlCommand();
                String strSQL = string.Empty;
                ID = (Label)(e.Item.FindControl("lblID"));
                TypeId= (Label)(e.Item.FindControl("lblTypes"));



                FileUpload UpdatedVideoFile = (FileUpload)(e.Item.FindControl("FileUpload2"));
                Stream fs = null;
                fs = UpdatedVideoFile.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] bytes = br1.ReadBytes(UpdatedVideoFile.PostedFile.ContentLength);

                //if (CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Video, uploadVideo.PostedFile.ContentType))
                //{
                //    String extention = Path.GetExtension(uploadVideo.FileName);
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File Is InValid , Kindly Upload avi/mpg/mpg/flv/wmv/mp4 Formatted file.');", true); return;
                //}
               


                if (isValidAttachmentFile(FileUpload) == true)
                {
                    if (TypeId.Text == "1")
                    {
                        path = "../../Site/Upload/Video/Motivational/";
                        videopath = Server.MapPath("../../Site/Upload/Video/Motivational/");
                        objAlbumSchema.Actiontype = "PHOTO_UPDATE";
                    }
                    else
                    {
                        path = "../../Site/Upload/Video/SuccessStories/";
                        videopath = Server.MapPath("../../Site/Upload/Video/SuccessStories/");
                        objAlbumSchema.Actiontype = "PHOTO_UPDATE";
                    }


                    UpdatedVideoFile.PostedFile.SaveAs(videopath + UpdatedVideoFile.FileName);
                    objAlbumSchema.VideoName = txtPhotoName.Text.ToString();
                    objAlbumSchema.VideoNameLL = txtPhotoNameLL.Text.ToString();
                    objAlbumSchema.VideoPath = path + FileUpload.FileName;
                    objAlbumSchema.VideoID = Convert.ToInt32(ID.Text);
                    int isinsert = objAlbumBL.DMLAlbhumForVideo(objAlbumSchema);

                    if (isinsert > 0)
                    {
                        ClearControls();
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('File Saved Sucessfully!!!');", true);
                    }
                        
                }
                else
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "alert('Selected File is Invalid; Please select Valid File!!!');", true);
                DG_Photo.EditItemIndex = -1;
                BindVideos();
            }
        }

        private void BindVideos()
        {
            objAlbumSchema.Type = ddlFileType.SelectedValue;
            ds = objAlbumBL.GetVideos(objAlbumSchema);
            ViewState["video"] = ds;
            DG_Photo.DataSource = ds;
            DG_Photo.DataBind();
        }

        private bool isValidAttachmentFile(FileUpload FileUploader)
        {
            bool isValid = false;
            if ((FileUploader.HasFile))
                if (CommonFuntion.check_Extensions(FileUploader.FileName))
                {
                    Stream fs = null;
                    fs = FileUploader.PostedFile.InputStream;
                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] bytfile = br1.ReadBytes(FileUploader.PostedFile.ContentLength);
                    String ext = FileUploader.FileName;
                    String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                    if (extention.ToLower() == "mp3" || extention.ToLower() == "avi" || extention.ToLower() == "mp4" || extention.ToLower() == "flv" || extention.ToLower() == "mp4" || extention.ToLower() == "mp3")
                        isValid = true;
                    else
                        isValid = false;
                }
            return isValid;
        }

        private bool isValidAttachmentPhoto(FileUpload FileUploader)
        {
            bool isValid = false;
            if ((FileUploader.HasFile))
            {
                if (CommonFuntion.check_Extensions(FileUploader.FileName))
                {

                    Stream fs = null;
                    fs = FileUploader.PostedFile.InputStream;
                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] bytes = FileUploader.FileBytes;

                    if (CommonFuntion.isValidFile(bytes, CommonFuntion.FileType.Image, FileUploader.PostedFile.ContentType))
                    {
                        String ext = FileUploader.FileName;
                        String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                        if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png") { isValid = true; }
                        else { isValid = false; }
                    }
                    else
                    {
                        isValid = false;
                    }
                }

                else
                {
                }
            }

            return isValid;
        }


        private void ClearControls()
        {
            txtDescription.Text = "";
            txtDescriptionLL.Text = "";
            txtDescriptionUL.Text = "";
            //txtPhotoName.Text = "";
            txtVideoTitle.Text = "";
            txtVideoTitleLL.Text = "";
            txtVideoTitleUL.Text = "";
        }


        protected void ddlFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVideos();
        }

    }
}