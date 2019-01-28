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
using DAL;

namespace PMMYA.Site.Home
{
    public partial class FrmViewPhoto : MAHAITPage 
    {
        BL.BL MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                DisplayPhoto(id);
            }
        }

        private void DisplayPhoto(int PhotoSubAlbumID)
        {

            ViewPhotoAlbumBL objviewphotoalbumbl = new ViewPhotoAlbumBL();

            ViewPhotoAlbumSchema objPhotoalbumschema = new ViewPhotoAlbumSchema();
            objPhotoalbumschema.PhotoSubAlbumID= Convert.ToInt32(PhotoSubAlbumID);

            DataSet ds = new DataSet();
            ds = objviewphotoalbumbl.ViewPhotoAlbum(objPhotoalbumschema);
            lblAlbum.Text = GetResourceValue("Common", "lblAlbum", "");
            lvEventPhoto.DataSource = ds;
            lvEventPhoto.DataBind();
        }



    }
}