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

namespace PMMYA.Controls.WebSiteControls
{
    public partial class ViewVideoControl : System.Web.UI.UserControl
    {
        
        #region Public variable declaration
        AlbumBL objAlbumBL = new AlbumBL();
        AlbumSchema objAlbumSchema = new AlbumSchema();
        DataSet ds;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // DisplayAlbum();
               
            }
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            GetMotivationalVideo();
        }


        protected void GetMotivationalVideo()
        {

           // lblMotivational.Text = _MahaITUC.GetResourceValue("Common", "lblMotivational", "");
            objAlbumSchema.TypeId = 1;
            ds = objAlbumBL.GetVideosById(objAlbumSchema);
            LV_Events.DataSource = ds;
            LV_Events.DataBind();

        }
        
    }
}