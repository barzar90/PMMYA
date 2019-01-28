using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using BL;
using Schema;

namespace PMMYA.PublicApp.STD
{
    /// <summary>
    /// Summary description for ViewFile
    /// </summary>
    public class ViewFile : IHttpHandler
    {
        #region Public variable declaration
        FileHandlerSchema objFileHandlerSchema = new FileHandlerSchema();
        FileHandlerBL objFileHandlerBL = new FileHandlerBL();
        DataSet ds = null;
        #endregion
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                if (!String.IsNullOrEmpty(context.Request.QueryString["ID"]))
                {
                    if (context.Request.QueryString["ID"].Contains("alert('xss')") || context.Request.QueryString["ID"].Contains("xss") || context.Request.QueryString["ID"].Contains("%27"))
                    {
                        context.Response.Redirect("~/App_Error.aspx?ExceptionId='404'");

                    }
                    string t_FileID = context.Request.QueryString["ID"];
                    objFileHandlerSchema.RowID = Convert.ToInt32(t_FileID);
                    byte[] pict;
                    ds = objFileHandlerBL.GetUploadFileList(objFileHandlerSchema);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        pict = (byte[])ds.Tables[0].Rows[0]["ImageContent"];
                        MemoryStream ms = new MemoryStream(pict);
                        Image returnImage = Image.FromStream(ms);
                        returnImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                context.Response.Redirect("~/App_Error.aspx?ExceptionId='404'");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}