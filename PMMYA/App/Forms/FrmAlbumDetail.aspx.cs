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

namespace PMMYA.App.Forms
{
    public partial class FrmAlbumDetail : System.Web.UI.Page
    {
        #region Public variable declaration
        int _QueryString;
        string _id, _Status;
        ViewPhotoAlbumBL objViewPhotoAlbumBL = new ViewPhotoAlbumBL();
        ViewPhotoAlbumSchema objViewPhotoAlbumSchema = new ViewPhotoAlbumSchema();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _QueryString = this.Page.Request.QueryString.Count;
                CheckPageRequestStatus();
            }
        }

        private void CheckPageRequestStatus()
        {
            if (_QueryString > 0)
            {
                switch (Convert.ToString(_QueryString))
                {
                    case "1":
                        _Status = Request.QueryString["MODE"].ToString();
                        ViewState["_Status"] = _Status;

                        lblPhotoText.Text = "Enter Album Name: ";
                        lblPhotoUploadText.Text = "Upload Album Cover Photo";
                        break;
                    case "2":
                        _id = Request.QueryString["ID"].ToString();
                        _Status = Request.QueryString["MODE"].ToString();

                        ViewState["_id"] = _id;
                        ViewState["_Status"] = _Status;

                        lblPhotoText.Text = "Enter SubAlbum Name: ";
                        lblPhotoUploadText.Text = "Upload SubAlbum Cover Photo";
                        break;
                }
            }
        }

        protected void btnAddAlbumPhoto_Click(object sender, EventArgs e)
        {
            if ((txtAlbum.Text == "") || (!AlbumPhotoUpload.HasFile))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('All fields are mandatory!');", true);
                txtAlbum.Focus();
                return;
            }
            if (CheckValidAlbum() < 1)
            { return; }

            string InsertMode = string.Empty;
            int isinsert = 0;

            if (AlbumPhotoUpload.HasFile)
            {
                if (CommonFuntion.isValidFile(AlbumPhotoUpload.FileBytes, CommonFuntion.FileType.Image, AlbumPhotoUpload.PostedFile.ContentType))
                {
                    String ext = AlbumPhotoUpload.FileName;
                    String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                    if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png") { }
                    else { return; }
                }
                else { return; }
            }
            string filename = AlbumPhotoUpload.FileName;

            filename = filename.Substring(0, filename.IndexOf('.')) + "_" + System.DateTime.Now.ToString().Replace("/", "_") + System.IO.Path.GetExtension(AlbumPhotoUpload.FileName);
            filename = filename.Replace(":", "_");

            AlbumPhotoUpload.SaveAs(Server.MapPath("..\\PhotoAlbum") + "\\" + filename);
            InsertMode = Convert.ToString(ViewState["_Status"]).ToLower();
            switch (InsertMode)
            {
                case "album":
                    objViewPhotoAlbumSchema.ActionType = "album";
                    objViewPhotoAlbumSchema.Albumname = txtAlbum.Text.ToString();
                    objViewPhotoAlbumSchema.FileName = filename;
                    isinsert = objViewPhotoAlbumBL.DMLAlbumPhoto(objViewPhotoAlbumSchema);
                    if (isinsert > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Album Created!');", true);
                        Server.Transfer("FrmCreateAlbum.aspx", false);
                    }
                    break;

                case "subalbum":
                    objViewPhotoAlbumSchema.ActionType = "subalbum";
                    objViewPhotoAlbumSchema.Albumname = txtAlbum.Text.ToString();
                    objViewPhotoAlbumSchema.FileName = filename;
                    objViewPhotoAlbumSchema.Photoalbumid = Convert.ToInt32(ViewState["_id"]);
                    isinsert = objViewPhotoAlbumBL.DMLAlbumPhoto(objViewPhotoAlbumSchema);
                    if (isinsert > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sub Album Created!');", true);
                        Server.Transfer("FrmCreateAlbum.aspx", false);
                    }
                    break;
            }
        }
        private int CheckValidAlbum()
        {
            string InsertMode = string.Empty;
            DataSet ds = new DataSet();
            InsertMode = Convert.ToString(ViewState["_Status"]).ToLower();
            if (InsertMode == "album")
            {
                objViewPhotoAlbumSchema.ActionType = "album";
                objViewPhotoAlbumSchema.Name = txtAlbum.Text.ToString();
                ds = objViewPhotoAlbumBL.CheckValidAlbum(objViewPhotoAlbumSchema);
                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Album name already exist!');", true);
                    txtAlbum.Text = "";
                    return 0;
                }
                else
                { return 1; }
            }
            else if (InsertMode == "subalbum")
            {
                objViewPhotoAlbumSchema.ActionType = "subalbum";
                objViewPhotoAlbumSchema.Name = txtAlbum.Text.ToString();
                objViewPhotoAlbumSchema.Photoalbumid = Convert.ToInt32(ViewState["_id"]);
                ds = objViewPhotoAlbumBL.CheckValidAlbum(objViewPhotoAlbumSchema);

                if ((ds != null) && (ds.Tables.Count > 0))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SubAlbum name already exist!');", true);
                    txtAlbum.Text = "";
                    return 0;
                }
                else
                { return 1; }
            }
            return 0;
        }
    }
}