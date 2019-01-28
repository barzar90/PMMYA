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
    /// Summary description for DisplayFile
    /// </summary>
    public class DisplayFile : IHttpHandler
    {

        #region Public variable declaration
        FileHandlerSchema objFileHandlerSchema = new FileHandlerSchema();
        FileHandlerBL objFileHandlerBL = new FileHandlerBL();
        DataSet ds = null;
        #endregion

        public DisplayFile()
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                if (!String.IsNullOrEmpty(context.Request.QueryString["ID"]))
                {
                    string t_FileID = context.Request.QueryString["ID"];

                    byte[] pict;

                    objFileHandlerSchema.RowID = Convert.ToInt32(t_FileID);
                    ds = objFileHandlerBL.DisplayFileList(objFileHandlerSchema);

                    context.Response.ContentType = ds.Tables[0].Rows[0]["FileType"].ToString();
                    pict = (byte[])ds.Tables[0].Rows[0]["FileContent"];

                    string FileType = context.Request.QueryString["FileType"];

                    if (FileType == "Home Banner" || FileType == "Home Banner DOC" || FileType == "Home Banner DOM")
                    {
                        String langid = context.Request.QueryString["LangID"].ToString();
                        if (langid.ToLower() == Convert.ToString("mr-IN").ToLower())
                        {
                            if (ds.Tables[0].Rows[0]["ImageType"] != DBNull.Value)
                            {
                                context.Response.ContentType = ds.Tables[0].Rows[0]["ImageType"].ToString();
                                pict = (byte[])ds.Tables[0].Rows[0]["ImageContent"];
                            }
                        }
                        MemoryStream ms = new MemoryStream(pict);
                        Image returnImage = Image.FromStream(ms);
                        returnImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    }
                    else
                    {
                        switch (ds.Tables[0].Rows[0]["Category"].ToString())
                        {
                            case "15":
                            case "17":
                            case "18":
                            case "27":
                            case "28":
                                MemoryStream ms = new MemoryStream(pict);
                                Image returnImage = Image.FromStream(ms);
                                returnImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                                break;

                            case "13":
                            case "16":
                                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                                context.Response.Cache.SetLastModified(DateTime.Now);

                                context.Response.AppendHeader("Content-Type", ds.Tables[0].Rows[0]["FileType"].ToString());
                                context.Response.AppendHeader("Content-Length", (pict).Length.ToString());
                                context.Response.BinaryWrite(pict);
                                break;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
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