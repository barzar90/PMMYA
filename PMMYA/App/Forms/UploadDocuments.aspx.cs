using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Schema;
using Helper;
using System.IO;
using AjaxControlToolkit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using BL;

namespace PMMYA.App.Forms
{
    public partial class UploadDocuments : System.Web.UI.Page
    {
        #region Public variable declaration    
        int LangID = 0;
        DataSet ds;
        bool _IsSelect = true;
        UploadDocumentSchema objUploadDocumentSchema = new UploadDocumentSchema();
        UploadDocumentBL objUploadDocumentBL = new UploadDocumentBL();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                BindDDl();
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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                LangID = 2;
            }
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
            {
                LangID = 1;
            }
            else
            {
                LangID = 3;
            }
               
        }

        public void Gridbind(string DocType)
        {          
            objUploadDocumentSchema.Actiontype = "Gridbind";
            objUploadDocumentSchema.Documenttype = new Guid(DocType);
            ds = objUploadDocumentBL.GetUploadDocumentDetails(objUploadDocumentSchema);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                grdupload.DataSource = ds.Tables[0];
                grdupload.DataBind();
            }
            else
            {
                grdupload.DataSource = null;
                grdupload.DataBind();
            }
        }

        private bool isValidAttachmentFile(FileUpload FileUploader)
        {
            bool isValid = false;
            HttpPostedFile file = FileUploader.PostedFile;
            byte[] document = new byte[file.ContentLength];
            file.InputStream.Read(document, 0, file.ContentLength);
            System.UInt32 mimetype;
            FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
            System.IntPtr mimeTypePtr = new IntPtr(mimetype);
            string mime = Marshal.PtrToStringUni(mimeTypePtr);
            Marshal.FreeCoTaskMem(mimeTypePtr);
            if (mime == "image/jpeg" || mime == "image/bmp" || mime == "image/gif" || mime == "image/png")
            {
                if ((FileUploader.HasFile))
                    if (CommonFuntion.check_Extensions(FileUploader.FileName))
                    {
                        Stream fs = null;
                        fs = FileUploader.PostedFile.InputStream;

                        BinaryReader br1 = new BinaryReader(fs);
                        byte[] bytfile = br1.ReadBytes(FileUploader.PostedFile.ContentLength);

                        if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, FileUploader.PostedFile.ContentType))
                            isValid = true;
                        else
                        {
                            isValid = false;
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Image file is in wrong format.');", true);
                        }
                    }
            }
            else
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Image file is in wrong format.');", true);
            return isValid;
        }

        protected void SaveTODB()
        {
            try
            {
                DateTime date = Convert.ToDateTime(txtCreatedDate.Text);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;

                string MBSize = (FileUploadEng.PostedFile.ContentLength / 1048576.00).ToString("f2");

                if (HDNUpdate.Value != null && HDNUpdate.Value != "")
                {
                    objUploadDocumentSchema.Documentid = new Guid (HDNUpdate.Value);
                    objUploadDocumentSchema.Actiontype = "Insert";
                }
                else
                {                   
                    objUploadDocumentSchema.Actiontype = "Insert";
                }

                objUploadDocumentSchema.Title = txtTitle.Text.Trim().Replace("'", "''");
                objUploadDocumentSchema.Title_LL = Convert.ToString(txtTitleLL.Text);
                objUploadDocumentSchema.Title_UL= Convert.ToString(txtTitleUL.Text);
                objUploadDocumentSchema.Description = Convert.ToString(txtDescription.Text);
                objUploadDocumentSchema.Description_LL = Convert.ToString(txtDescriptionLL.Text);
                objUploadDocumentSchema.Description_UL= Convert.ToString(txtDescriptionUL.Text);

                objUploadDocumentSchema.DocumentPath = FileUploadEng.FileName;

                if (FileUploadMar.HasFile)
                {
                    objUploadDocumentSchema.DocumentPath_LL = FileUploadMar.FileName;
                }              
                else
                {
                    objUploadDocumentSchema.DocumentPath_LL = FileUploadEng.FileName;
                }

                if (UploadImage.HasFile)
                {
                    objUploadDocumentSchema.DocumentImage = UploadImage.FileName;
                }

                objUploadDocumentSchema.Documenttype = new Guid(Tr0.Visible == true ? ddlsubType0.SelectedValue : ddlDocumentType.SelectedValue);
                objUploadDocumentSchema.Createddate = Convert.ToDateTime(date.ToString("yyyy-MM-dd"));
                objUploadDocumentSchema.Createdby = HttpContext.Current.Profile.UserName;
                objUploadDocumentSchema.Size = MBSize;
                objUploadDocumentSchema.SeasonId = 0;
                objUploadDocumentSchema.Isctive = (chkActive.Checked) ? true : false;

                int result = objUploadDocumentBL.DMLUploadDocument(objUploadDocumentSchema);

                if (result > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Save SucessFully !!!')", true);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { HDNUpdate.Value = ""; }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string qryInsert = string.Empty;
            Page.Validate("VC");
            if (!Page.IsValid)
                return;
            if (!FileUploadEng.HasFile)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Please Select File !!!!')", true);
                return;
            }

            try
            {
                if (isValidFile() && isValidImageAttachmentFile(UploadImage))
                {
                    string Filepath = Server.MapPath("../../Site/Upload/Pdf/");
                    FileUploadEng.SaveAs(Filepath + FileUploadEng.FileName);
                    if (FileUploadMar.HasFile)
                    {
                        FileUploadMar.SaveAs(Filepath + FileUploadMar.FileName);
                    }
                    if (FileUploadUr.HasFile)
                    {
                        FileUploadUr.SaveAs(Filepath + FileUploadUr.FileName);
                    }
                       
                    string imagefilepath = Server.MapPath("../../Site/Upload/Images/");
                    UploadImage.SaveAs(imagefilepath + UploadImage.FileName);
                    SaveTODB();
                }
                else
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Please Select Valid PDF/Image File For Upload !!!!')", true); return;
            }
            catch (Exception ex) { throw ex; }
            finally { ClearControls(); }
        }

        private bool isValidFile()
        {
            bool retnVal = false;
            string extEng = Path.GetFileName(FileUploadEng.FileName).Substring(Path.GetFileName(FileUploadEng.FileName).IndexOf(".") + 1, 3);
            string extMar = FileUploadMar.HasFile ? Path.GetFileName(FileUploadMar.FileName).Substring(Path.GetFileName(FileUploadMar.FileName).IndexOf(".") + 1, 3) : extEng;
            if (CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.PDF, ".pdf"))
                if (FileUploadMar.HasFile)
                    if (CommonFuntion.isValidFile(FileUploadMar.FileBytes, CommonFuntion.FileType.PDF, ".pdf"))
                        if (extEng.ToLower() == "pdf")
                            retnVal = true;
                        else
                            retnVal = false;
                    else
                        retnVal = false;
                else
                    retnVal = true;
            else
                retnVal = false;

            return retnVal;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Gridbind();
            ClearControls();
            ddlDocumentType.SelectedIndex = 0;
        }

        protected void grdupload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string pdfName;
            try
            {
                if (e.CommandName == "delete")
                {
                    objUploadDocumentSchema.Actiontype = "Delete";
                    objUploadDocumentSchema.Documentid = new Guid(e.CommandArgument.ToString());
                    int retnval = objUploadDocumentBL.DMLUploadDocument(objUploadDocumentSchema);
                    if (retnval > 0)
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Record Deleted SucessFully !!!')", true);

                    txtCreatedDate.Text = "";
                    if (ddlsubType0.SelectedIndex > 0)
                        Gridbind(ddlsubType0.SelectedValue);
                    else
                        Gridbind(ddlDocumentType.SelectedValue);
                }
                else if (e.CommandName.ToLower() == "view")
                {
                    objUploadDocumentSchema.Actiontype = "RowCommand_View";
                    objUploadDocumentSchema.Documentid = new Guid(e.CommandArgument.ToString());
                    ds = objUploadDocumentBL.GetUploadDocumentDetails(objUploadDocumentSchema);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        txtCreatedDate.Text = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                        txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                        txtTitleLL.Text = ds.Tables[0].Rows[0]["Title_LL"].ToString();
                        txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                        txtDescriptionLL.Text = ds.Tables[0].Rows[0]["Description_LL"].ToString();
                        chkActive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                        HDNUpdate.Value = e.CommandArgument.ToString();
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            finally { ds = null; }

        }

        protected void grdupload_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdupload.PageIndex = e.NewPageIndex;
            if (ddlsubType0.SelectedIndex > 0)
                Gridbind(ddlsubType0.SelectedValue);
            else
                Gridbind(ddlDocumentType.SelectedValue);
        }

        private void ClearControls()
        {
            txtCreatedDate.Text = "";
            txtTitle.Text = "";
            txtTitleLL.Text = "";
            txtTitleUL.Text = "";
            txtDescription.Text = "";
            txtDescriptionLL.Text = "";
            txtDescriptionUL.Text = "";
            grdupload.DataSource = null;
            grdupload.DataBind();
            ddlsubType0.Items.Clear();
            ddlDocumentType.SelectedIndex = 0;
            HDNUpdate.Value = "";
            chkActive.Checked = false;
        }

        private bool isValidImageAttachmentFile(FileUpload FileUploader)
        {
            bool isValid = false;

            if ((FileUploader.HasFile))
            {
                if (CommonFuntion.check_Extensions(FileUploader.FileName))
                {
                    Stream fs = null;
                    fs = FileUploader.PostedFile.InputStream;

                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] bytfile = br1.ReadBytes(FileUploader.PostedFile.ContentLength);

                    if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, FileUploader.PostedFile.ContentType))
                    {
                        String ext = FileUploader.FileName;
                        String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                        if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png") { isValid = true; }
                        else { isValid = false; }
                    }
                    else
                    { isValid = false; }
                }
                else { isValid = false; }
            }
            return isValid;
        }

        protected void grdupload_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

        private void BindDDl()
        {            
            Guid EId = new Guid("B9E6F5E0-0A53-423E-9B62-69D55A5932EE");
            objUploadDocumentSchema.Enumarationvalueid = EId;
            objUploadDocumentSchema.Actiontype = "BindDDl";
            ds = objUploadDocumentBL.GetUploadDocumentDetails(objUploadDocumentSchema);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlDocumentType.DataSource = ds.Tables[0];
                ddlDocumentType.DataTextField = "EnumerationValue";
                ddlDocumentType.DataValueField = "EnumerationValueID";
                ddlDocumentType.DataBind();
            }
            ddlDocumentType.Items.Insert(0, "-Select-");
        }

        protected void ddlsubType0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsubType0.SelectedIndex > 0)
                Gridbind(ddlsubType0.SelectedValue);
        }

        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDocumentType.SelectedIndex > 0)
            {
                Guid EId = new Guid(ddlDocumentType.SelectedValue);
                objUploadDocumentSchema.Actiontype = "SelIndChange";
                objUploadDocumentSchema.Parent_Enumarationvalueid = EId;
                ds = objUploadDocumentBL.GetUploadDocumentDetails(objUploadDocumentSchema);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlsubType0.DataSource = ds.Tables[0];
                    ddlsubType0.DataTextField = "EnumerationValue";
                    ddlsubType0.DataValueField = "EnumerationValueID";
                    ddlsubType0.DataBind();
                    Tr0.Visible = true;
                }
                else
                {
                    Tr0.Visible = false;
                }
                ddlsubType0.Items.Insert(0, "-Select-");
                Gridbind(ddlDocumentType.SelectedValue);
            }
            else
            {
                ddlsubType0.DataSource = null;
                ddlsubType0.DataBind();

            }
        }
    }
}