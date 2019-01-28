using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace PMMYA.Site.Home
{
    public partial class WebPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // to get the query string data from url rewrite

            int MenuID = Convert.ToInt32(Request.QueryString["source"]);
            int ContentID = Convert.ToInt32(Request.QueryString["psource"]);

            if (Request.QueryString["source"] != null)
            {
                //to bind the cms content
                CmsContent.isQuickMenu = false;
                CmsContent.MenuID = MenuID;
                CmsContent.MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
                CmsContent.LangID = "en-IN";

                CmsContentMore.Visible = false;
            }

            if (Request.QueryString["psource"] != null)
            {
                //to bind the cms content more
                CmsContentMore.isQuickMenu = false;
                CmsContentMore.ContentID = Convert.ToInt32(ContentID);
                CmsContentMore.MAHAITDBAccess = ((MAHAITMasterPage)this.Master).MAHAITDBAccess;
                CmsContentMore.LangID = "en-IN";

                CmsContent.Visible = false;
            }
        }
    }
}