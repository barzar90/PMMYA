using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Schema;
using System.Data;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class Videoplaycontrol2 : System.Web.UI.UserControl
    {
        #region Public variable declaration
        AlbumBL objAlbumBL = new AlbumBL();
        AlbumSchema objAlbumSchema = new AlbumSchema();
        DataSet ds;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Page_PreRender(Object sender, EventArgs e)
        {
            GetSuccessStoriesVideo();
        }


        protected void GetSuccessStoriesVideo()
        {
            //lblSuccessStories.Text = _MahaITUC.GetResourceValue("Common", "lblSuccessStories", "");
            objAlbumSchema.TypeId = 2;
            ds = objAlbumBL.GetVideosById(objAlbumSchema);
            LV_Events.DataSource = ds;
            LV_Events.DataBind();

        }
    }
}