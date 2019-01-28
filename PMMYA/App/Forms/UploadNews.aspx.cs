using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Helper;
using AjaxControlToolkit;
using System.Security.Cryptography;
using System.Text;
using BL;
using Schema;

namespace PMMYA.App.Forms
{
    public partial class UploadNews : System.Web.UI.Page
    {
        #region Public variable declaration
      
        UploadNewsBL objUploadNewsBL = new UploadNewsBL();
        UploadNewsSchema objUploadNewsSchema = new UploadNewsSchema();
        string serverpath = "../../site/Upload/pdf/";
        Label lbl_ID;
        TextBox txt_News, txt_News_LL, txt_News_UL;
        Label lbl_News;

        TextBox txt_URL, txt_URLID,txtDate;
        Label lbl_URL;
        CheckBox Chk;
        RequiredFieldValidator reqFildVdtr;
        FileUpload filUplod;
        FileUpload file_Upload_URL, file_Upload_URLID;
        int LangID = 0, retrnVal;
        bool isValid = false;
        int isAdd = 0;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
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

            if (!IsPostBack)
            {               
                BindGrid();
            }
        }

        public void BindGrid()
        {
            try
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
                DataSet ds = new DataSet();
                ds = objUploadNewsBL.GetUploadNewsDetails();
                Session["News"] = ds;
                dg_PDF.DataSource = ds;
                dg_PDF.DataBind();
                lbl_Error.Text = ""; 
            }
            catch (Exception ex) { }
        }

        private void Insert_Update_Dataset(Object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            DataSet ds = (DataSet)Session["News"];
            DataRow DR = null;

            txt_News = (TextBox)(e.Item.FindControl("txt_News"));
            txt_News_LL = (TextBox)(e.Item.FindControl("txt_News_LL"));
            txt_News_UL = (TextBox)(e.Item.FindControl("txt_News_UL"));
            txt_URL = (TextBox)(e.Item.FindControl("txt_URL"));
            file_Upload_URL = (FileUpload)(e.Item.FindControl("UploadFile"));
            txtDate = (TextBox)(e.Item.FindControl("txt_CreatedDate"));
            DateTime date = Convert.ToDateTime(txtDate.Text);
            if (e.CommandName == "Add")
            {
                try
                {
                    if (Allow_To_Add_Update(1) == true)
                    {
                        objUploadNewsSchema.News = txt_News.Text.Trim();
                        objUploadNewsSchema.News_LL = txt_News_LL.Text.Trim();
                        objUploadNewsSchema.News_UL = txt_News_UL.Text.Trim();
                        objUploadNewsSchema.LangID = LangID;
                        objUploadNewsSchema.Is_Active = true;
                        objUploadNewsSchema.CreatedDate = date;
                        objUploadNewsSchema.ActionType = "Insert";

                        if (txt_URL.Visible == true)
                        {
                            objUploadNewsSchema.IsLink = true;
                            objUploadNewsSchema.URL = txt_URL.Text.Trim();
                            retrnVal = objUploadNewsBL.SaveUploadNewsDetails(objUploadNewsSchema);
                            if (retrnVal != 0)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Added Successfully');", true);
                            }
                        }
                        else if (file_Upload_URL.Visible == true)
                        {
                            if (file_Upload_URL.HasFile)
                            {
                                objUploadNewsSchema.IsLink = false;
                                if (isValidAttachmentFile(file_Upload_URL))
                                {
                                    string filename = Path.GetFileName(file_Upload_URL.FileName);
                                    file_Upload_URL.SaveAs(Server.MapPath("../../Site/Upload/Pdf/") + filename);
                                    string path = "../../Site/Upload/Pdf/";
                                    objUploadNewsSchema.URL = path + filename;  
                                }
                                else 
                                    objUploadNewsSchema.URL = DBNull.Value.ToString();
                            }
                            else
                            {
                                objUploadNewsSchema.IsLink = false;
                                objUploadNewsSchema.URL = DBNull.Value.ToString();
                            }
                            retrnVal = objUploadNewsBL.SaveUploadNewsDetails(objUploadNewsSchema);
                            if (retrnVal != 0)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Added Successfully');", true);
                            }

                        }
                        else
                        { }

                        BindGrid();
                    }
                }
                catch (Exception ex) { }
            }
            else if (e.CommandName == "Update")
            {
                string HrfUrl = string.Empty;
                string ImageUrl = string.Empty;
                try
                {
                    if (Allow_To_Add_Update(0) == true)
                    {
                        lbl_ID = (Label)(e.Item.FindControl("lbl_ID"));
                        
                        objUploadNewsSchema.News = txt_News.Text.Trim();
                        objUploadNewsSchema.News_LL = txt_News_LL.Text.Trim();
                        objUploadNewsSchema.News_UL = txt_News_UL.Text.Trim();
                        objUploadNewsSchema.ID = !string.IsNullOrWhiteSpace(lbl_ID.Text) ? Convert.ToInt32(lbl_ID.Text) : 0;
                        objUploadNewsSchema.LangID = LangID;
                        objUploadNewsSchema.CreatedDate = date;
                        objUploadNewsSchema.ActionType = "Update";
                        if (txt_URL.Visible == true)
                        {
                            objUploadNewsSchema.IsLink = true;
                            objUploadNewsSchema.URL = txt_URL.Text.Trim();
                            HrfUrl = "URL=@URL,";
                        }
                        else
                        {
                            objUploadNewsSchema.IsLink = false;
                            if (file_Upload_URL.HasFile)
                            {                                
                                if (isValidAttachmentFile(file_Upload_URL))
                                {
                                    string filename = Path.GetFileName(file_Upload_URL.FileName);
                                    file_Upload_URL.SaveAs(Server.MapPath("../../Site/Upload/Pdf/") + filename);
                                    string path = "../../Site/Upload/Pdf/";
                                   
                                    objUploadNewsSchema.URL = path + filename;
                                    HrfUrl = "URL=@URL,";
                                }
                            }
                        }
                        retrnVal= objUploadNewsBL.SaveUploadNewsDetails(objUploadNewsSchema);
                        if (retrnVal.ToString() == "1")
                        { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Record Updated SucessFully');", true); }
                        else { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Record Not Updated');", true); }

                        dg_PDF.EditItemIndex = -1;
                        BindGrid();
                    }
                }
                catch (Exception ex) { }
            }
        }

        private bool Allow_To_Add_Update(int isAdd)
        {
            if (txt_News.Text == "")
            {
                lbl_Error.Text = "Please Enter News";
            }
            else
            {
                isValid = true;
                lbl_Error.Text = "";
            }
            return isValid;
        }
        protected void dg_PDF_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dg_PDF.EditItemIndex = -1;
            BindGrid();
        }

        protected void dg_PDF_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                lbl_ID = (Label)(e.Item.FindControl("lbl_ID"));                
                objUploadNewsSchema.ID = !string.IsNullOrWhiteSpace(lbl_ID.Text) ? Convert.ToInt32(lbl_ID.Text) : 0;
                objUploadNewsSchema.ActionType = "Delete";
                int result = objUploadNewsBL.SaveUploadNewsDetails(objUploadNewsSchema);
                if (result > 0)
                { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('Record Deleted SucessFully');", true); }
                BindGrid();
            }
            catch (Exception ex) { }
        }

        protected void dg_PDF_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dg_PDF.EditItemIndex = e.Item.ItemIndex;
            BindGrid();
        }

        protected void dg_PDF_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                Insert_Update_Dataset(source, e);
            }
        }

        protected void dgev_PDF_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DataSet ds = (DataSet)Session["News"];
                DataRow[] DR;

                txt_News = (TextBox)(e.Item.FindControl("txt_News"));
                txt_News_LL = (TextBox)(e.Item.FindControl("txt_News_LL"));
                txt_News_UL = (TextBox)(e.Item.FindControl("txt_News_UL"));
                txt_URL = (TextBox)(e.Item.FindControl("txt_URL"));
                lbl_ID = (Label)(e.Item.FindControl("lbl_ID"));

                DR = ds.Tables[0].Select("ID=" + lbl_ID.Text.Trim());

                txt_News.Text = DR[0]["News"].ToString();
                txt_News_LL.Text = DR[0]["News_LL"].ToString();
                txt_URL.Text = DR[0]["URL"].ToString();
            }
            if (e.Item.ItemIndex >= 0)
            {
                Label lblIsNew = (Label)e.Item.FindControl("lblIsNew");
                CheckBox chknew = (CheckBox)e.Item.FindControl("Chkstatus");
                Label Label1 = (Label)e.Item.FindControl("Label1");

                if (lblIsNew.Text == "False")
                {
                    chknew.Checked = false;
                }
                else
                {
                    chknew.Checked = true;
                }
            }
        }

        protected void chkFt_URL_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            DataGridItem Item = (DataGridItem)chk.Parent.Parent;
            txt_URLID = (TextBox)(Item.FindControl("txt_URL"));
            file_Upload_URLID = (FileUpload)(Item.FindControl("UploadFile"));
            if (chk.Checked == true)
            {
                txt_URLID.Visible = true;
                file_Upload_URLID.Visible = false;
            }
            else
            {
                txt_URLID.Visible = false;
                file_Upload_URLID.Visible = true;
            }
        }

        protected void chkEd_URL_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            DataGridItem Item1 = (DataGridItem)chk.Parent.Parent;
            txt_URLID = (TextBox)(Item1.FindControl("txt_URL"));
            file_Upload_URLID = (FileUpload)(Item1.FindControl("UploadFile"));
            if (chk.Checked == true)
            {
                txt_URLID.Visible = true;
                file_Upload_URLID.Visible = false;
            }
            else
            {
                txt_URLID.Visible = false;
                file_Upload_URLID.Visible = true;
            }
        }
        protected void chkbox_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox chknew = (CheckBox)dg_PDF.FindControl("Chkstatus");
            CheckBox chk = (CheckBox)sender;
            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandType = CommandType.Text;
            string key = ((CheckBox)sender).Attributes["key"];
            string update = string.Empty;

            if (chk.Checked == true)
            {
                objUploadNewsSchema.IsNew = true;
                objUploadNewsSchema.ID = !string.IsNullOrWhiteSpace(key) ? Convert.ToInt32(key) : 0; ;
            }
            else
            {
                objUploadNewsSchema.IsNew = false;
                objUploadNewsSchema.ID = !string.IsNullOrWhiteSpace(key) ? Convert.ToInt32(key) : 0; ;
            }
            objUploadNewsSchema.ActionType = "OnCheckChange";
            objUploadNewsBL.SaveUploadNewsDetails(objUploadNewsSchema);
            BindGrid();
        }
        protected void dg_PDF_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            Insert_Update_Dataset(source, e);
        }
        protected void chk_Is_Active_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            DataGridItem Item = (DataGridItem)chk.Parent.Parent;
            lbl_ID = (Label)(Item.FindControl("lbl_ID"));
            

            objUploadNewsSchema.Is_Active = chk.Checked;
            objUploadNewsSchema.ID = !string.IsNullOrWhiteSpace(lbl_ID.Text) ? Convert.ToInt32(lbl_ID.Text.Trim()) : 0;
            objUploadNewsSchema.LangID = LangID;
            objUploadNewsSchema.ActionType = "ActiveCheckChange";
            objUploadNewsBL.SaveUploadNewsDetails(objUploadNewsSchema);
            
            //conn.Close();
            dg_PDF.EditItemIndex = -1;
            BindGrid();

            dg_PDF.EditItemIndex = -1;
            BindGrid();
        }
        private bool isValidAttachmentFile(FileUpload FileUploader)
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

                    String ext = FileUploader.FileName;
                    String extention = ext.Substring(ext.IndexOf(".") + 1, 3);
                    if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Image, FileUploader.PostedFile.ContentType))
                    {
                        if (extention.ToLower() == "jpg" || extention.ToLower() == "jpeg" || extention.ToLower() == "bmp" || extention.ToLower() == "gif" || extention.ToLower() == "png")
                            isValid = true;

                    }
                    else if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.PDF, FileUploader.PostedFile.ContentType))
                    {
                        if (extention.ToLower() == "pdf")
                            isValid = true;
                    }
                    else if (CommonFuntion.isValidFile(bytfile, CommonFuntion.FileType.Video, FileUploader.PostedFile.ContentType))
                    {
                        if (extention.ToLower() == "avi" || extention.ToLower() == "3gp" || extention.ToLower() == "mp4" || extention.ToLower() == "mpg" || extention.ToLower() == "flv" || extention.ToLower() == "wmv")
                            isValid = true;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('InValid File');", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Alert", "alert('File is InValid');", true);
            }
            return isValid;
        }

        private bool isValidFile(FileUpload FileUploader)
        {
            bool retnVal = false;
            string extEng = Path.GetFileName(FileUploader.FileName).Substring(Path.GetFileName(FileUploader.FileName).IndexOf(".") + 1, 3);
            if (FileUploader.HasFile)
                if (CommonFuntion.isValidFile(FileUploader.FileBytes, CommonFuntion.FileType.PDF, ".pdf"))
                    if ((extEng.ToLower() == "pdf"))
                        retnVal = true;
                    else
                        retnVal = false;
                else
                    retnVal = false;
            else
                retnVal = true;

            return retnVal;
        }
    }
}