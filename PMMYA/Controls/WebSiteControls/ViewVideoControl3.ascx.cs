using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Schema;
using DAL;
using System.Data;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class ViewVideoControl3 : System.Web.UI.UserControl
    {
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            DisplayPhoto();
        }
        private void DisplayPhoto()
        {
            //lblPhoto.Text = _MahaITUC.GetResourceValue("Common", "lblPhoto", "");
            ViewPhotoAlbumBL objviewphotoalbumbl = new ViewPhotoAlbumBL();
            ViewPhotoAlbumSchema objPhotoalbumschema = new ViewPhotoAlbumSchema();
            DataSet ds = new DataSet();
            ds = objviewphotoalbumbl.DisplayPhoto();
            lvEventPhoto.DataSource = ds;
            lvEventPhoto.DataBind();
        }
    }
}