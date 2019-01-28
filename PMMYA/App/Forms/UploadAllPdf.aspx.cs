using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Schema;
using System.Text;
using Helper;
using AjaxControlToolkit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using BL;


namespace PMMYA.App.Forms
{
    public partial class UploadAllPdf : MAHAITPage
    {
        #region Public variable declaration    
        bool _IsSelect = true;
        int LangID = 0;
        DataSet ds;   
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
                LangID = 2;
            else if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower() == Convert.ToString("en-IN").ToLower())
                LangID = 1;
            else
                LangID = 3;
        }

        public void Gridbind(string DocType)
        {
            Guid docid = new Guid(DocType.ToString());
            objUploadDocumentSchema.ChkArchive = chkArchive.Checked;
            objUploadDocumentSchema.Documenttype = docid;
            objUploadDocumentSchema.Actiontype = "Gridbind";
            ds = objUploadDocumentBL.GetUploadPDFDetails(objUploadDocumentSchema);
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

            if (mime =="application/pdf")
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                string MBSize = (FileUploadEng.PostedFile.ContentLength / 1048576.00).ToString("f2");

                if (HDNUpdate.Value != null && HDNUpdate.Value != "")
                {
                    objUploadDocumentSchema.Documentid = new Guid(HDNUpdate.Value);
                    objUploadDocumentSchema.Actiontype = "Insert";
                }
                else
                {
                    objUploadDocumentSchema.Actiontype = "Insert";
                }

                objUploadDocumentSchema.Subject = txtSub.Text.Trim() != string.Empty ? txtSub.Text.Trim().Replace("'", "''") : string.Empty;
                objUploadDocumentSchema.Subject_LL = Convert.ToString(txtsubLL.Text != string.Empty ? txtsubLL.Text : string.Empty);
                objUploadDocumentSchema.Subject_UL = Convert.ToString(txtsubUL.Text != string.Empty ? txtsubUL.Text : string.Empty);

                objUploadDocumentSchema.DocumentPath = FileUploadEng.FileName;

                if (FileUploadMar.HasFile)
                {
                    objUploadDocumentSchema.DocumentPath_LL = FileUploadMar.FileName;
                }
                else
                {
                    objUploadDocumentSchema.DocumentPath_LL = FileUploadEng.FileName;
                }
                if (FileUploadUrdu.HasFile)
                {
                    objUploadDocumentSchema.DocumentPath_UL = FileUploadUrdu.FileName;
                }
                else
                {
                    objUploadDocumentSchema.DocumentPath_UL = FileUploadEng.FileName;
                }

                if (Tr0.Visible == true)
                {
                    objUploadDocumentSchema.Documenttype = new Guid(ddlsubType0.SelectedValue);
                }
                else
                {
                    objUploadDocumentSchema.Documenttype = new Guid(ddlDocumentType.SelectedValue);
                }

                objUploadDocumentSchema.Createdby = HttpContext.Current.Profile.UserName;

                objUploadDocumentSchema.Size = MBSize;
                objUploadDocumentSchema.SeasonId =0;
                objUploadDocumentSchema.Isctive = false;
                objUploadDocumentSchema.IsArchive = chkArchive.Checked;
                int result = objUploadDocumentBL.DMLUploadPdf(objUploadDocumentSchema);

                if (result>0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Save SucessFully !!!')", true);
                }
            }
            catch (Exception ex) { throw ex; }
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
                if (isValidFile())
                {
                    string Filepath = Server.MapPath("../../Site/Upload/Pdf/");
                    FileUploadEng.SaveAs(Filepath + FileUploadEng.FileName);
                    if (FileUploadMar.HasFile)
                    {
                        FileUploadMar.SaveAs(Filepath + FileUploadMar.FileName);
                    }

                    if (FileUploadUrdu.HasFile)
                    {
                        FileUploadUrdu.SaveAs(Filepath + FileUploadUrdu.FileName);
                    }

                        SaveTODB();
                }
                else
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Please Select Valid File For Upload !!!!')", true); return;
            }
            catch (Exception ex) { throw ex; }
            finally { ClearControls(); }
        }

        private bool isValidFile()
        {
            bool retnVal = false;
          
            string extEng = Path.GetFileName(FileUploadEng.FileName).Substring(Path.GetFileName(FileUploadEng.FileName).IndexOf(".") + 1, 3);
            string extMar = FileUploadMar.HasFile ? Path.GetFileName(FileUploadMar.FileName).Substring(Path.GetFileName(FileUploadMar.FileName).IndexOf(".") + 1, 3) : extEng;
            if (CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.PDF, ".pdf") || CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.XLS, ".application/vnd.ms-excel") || CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.XLSX, ".application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
            {
                if ((FileUploadMar.HasFile) && (FileUploadEng.HasFile))
                {
                    if ((CheckuploadedfileMIME(FileUploadMar))&&(CheckuploadedfileMIME(FileUploadEng)))
                    {
                    if (CommonFuntion.isValidFile(FileUploadMar.FileBytes, CommonFuntion.FileType.PDF, ".pdf") || CommonFuntion.isValidFile(FileUploadMar.FileBytes, CommonFuntion.FileType.XLS, ".application/vnd.ms-excel") || CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.XLSX, ".application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                    {
                        if ((extEng.ToLower() == "pdf" || extEng.ToLower() == "xls" || extEng.ToLower() == "xlsx") && (extMar.ToLower() == "pdf" || extMar.ToLower() == "xls" || extMar.ToLower() == "xlsx"))
                            retnVal = true;
                        else
                            retnVal = false;
                    }
                    }
                    else
                    {
                        retnVal = false;
                    }
                }
                else
                {
                    if (FileUploadEng.HasFile)
                    
                    {
                        if ((CheckuploadedfileMIME(FileUploadEng)))
                        {
                            if (CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.PDF, ".pdf") || CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.XLS, ".application/vnd.ms-excel") || CommonFuntion.isValidFile(FileUploadEng.FileBytes, CommonFuntion.FileType.XLSX, ".application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                            {
                                if ((extEng.ToLower() == "pdf" || extEng.ToLower() == "xls" || extEng.ToLower() == "xlsx") && (extMar.ToLower() == "pdf" || extMar.ToLower() == "xls" || extMar.ToLower() == "xlsx"))
                                    retnVal = true;
                                else
                                    retnVal = false;
                            }
                        }
                        else
                        {
                            retnVal = false;
                        }
                    }

                    else if (FileUploadMar.HasFile)
                    {
                        if ((CheckuploadedfileMIME(FileUploadMar)))
                        {
                            if (CommonFuntion.isValidFile(FileUploadMar.FileBytes, CommonFuntion.FileType.PDF, ".pdf") || CommonFuntion.isValidFile(FileUploadMar.FileBytes, CommonFuntion.FileType.XLS, ".application/vnd.ms-excel") || CommonFuntion.isValidFile(FileUploadMar.FileBytes, CommonFuntion.FileType.XLSX, ".application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"))
                            {
                                if ((extEng.ToLower() == "pdf" || extEng.ToLower() == "xls" || extEng.ToLower() == "xlsx") && (extMar.ToLower() == "pdf" || extMar.ToLower() == "xls" || extMar.ToLower() == "xlsx"))
                                    retnVal = true;
                                else
                                    retnVal = false;
                            }
                        }
                        else
                        {
                            retnVal = false;
                        }

                    }
                    else
                    {
                        if ((FileUploadEng.HasFile) && (FileUploadMar.HasFile))
                        {
                            retnVal = false;
                        }

                    }
                }
            }
            else
            {
                retnVal = false;
            }

            return retnVal;
        }

        private bool CheckuploadedfileMIME(FileUpload Fileuploader)
        {
            bool checkreturn = false;

            if (!HasSpecialCharacters(Fileuploader.FileName))
            {
                if (Fileuploader.HasFile)
                {
                    HttpPostedFile file = Fileuploader.PostedFile;
                    byte[] document = new byte[file.ContentLength];
                    file.InputStream.Read(document, 0, file.ContentLength);
                    System.UInt32 mimetype;
                    FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                    System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                    string mime = Marshal.PtrToStringUni(mimeTypePtr);
                    Marshal.FreeCoTaskMem(mimeTypePtr);
                    if (mime =="application/pdf" || mime == "application/vnd.ms-excel" || mime == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    {
                        checkreturn = true;
                    }
                    else
                    {
                        checkreturn = false;
                    }

                }
            }

            return checkreturn;
        }

        



        public static bool HasSpecialCharacters(string str)
        {

            var list = new[] { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "\"" };
            return list.Any(str.Contains);
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
            ddlDocumentType.SelectedIndex = 0;
        }

        protected void grdupload_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string pdfName;
            try
            {
                if (e.CommandName == "delete1")
                {
                    objUploadDocumentSchema.Documentid = new Guid(e.CommandArgument.ToString());
                    objUploadDocumentSchema.Actiontype = "Delete";
                    int retnval = objUploadDocumentBL.DMLUploadPdf(objUploadDocumentSchema);
                    if (retnval > 0)
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "Failure", "alert('Record Deleted SucessFully !!!')", true);

                    if (Tr0.Visible == true)
                        Gridbind(ddlsubType0.SelectedValue);
                    else
                        Gridbind(ddlDocumentType.SelectedValue);
                }
                else if (e.CommandName.ToLower() == "view")
                {
                    objUploadDocumentSchema.Documentid = new Guid(e.CommandArgument.ToString());
                    objUploadDocumentSchema.Actiontype = "RowCommand_View";
                    ds = objUploadDocumentBL.GetUploadPDFDetails(objUploadDocumentSchema);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {        
                        txtSub.Text = ds.Tables[0].Rows[0]["subject"].ToString();
                        txtsubLL.Text = ds.Tables[0].Rows[0]["subject_LL"].ToString();
                        chkArchive.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsArchive"].ToString());
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
            if (Tr0.Visible == true)
                Gridbind(ddlsubType0.SelectedValue);
            else
                Gridbind(ddlDocumentType.SelectedValue);
        }

        private void ClearControls()
        {
            txtSub.Text = "";
            txtsubLL.Text = "";
            ddlsubType0.Items.Clear();
            ddlDocumentType.SelectedIndex = 0;
            grdupload.DataSource = null;
            grdupload.DataBind();
            chkArchive.Checked = false;
        }

        protected void ddlsubType0_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkArchive.Checked = false;
            if (ddlsubType0.SelectedIndex > 0)
                Gridbind(ddlsubType0.SelectedValue);
            
        }

        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkArchive.Checked = false;
            if (ddlDocumentType.SelectedIndex > 0)
            {             
                Guid EId = new Guid(ddlDocumentType.SelectedValue);
                objUploadDocumentSchema.Enumarationvalueid = EId;
                objUploadDocumentSchema.Actiontype = "SelIndChange";
                ds = objUploadDocumentBL.GetUploadPDFDetails(objUploadDocumentSchema);

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

        private void BindDDl()
        {           
            Guid EId = new Guid("B9E6F5E0-0A53-423E-9B62-69D55A5932EE");
            objUploadDocumentSchema.Enumarationvalueid = EId;
            objUploadDocumentSchema.Actiontype = "BindDDl";
            ds = objUploadDocumentBL.GetUploadPDFDetails(objUploadDocumentSchema);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddlDocumentType.DataSource = ds.Tables[0];
                ddlDocumentType.DataTextField = "EnumerationValue";
                ddlDocumentType.DataValueField = "EnumerationValueID";
                ddlDocumentType.DataBind();
            }
            ddlDocumentType.Items.Insert(0, "-Select-");
        }

        protected void chkArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (Tr0.Visible == true)
                Gridbind(ddlsubType0.SelectedValue);
            else
                Gridbind(ddlDocumentType.SelectedValue);
        }

    }
}