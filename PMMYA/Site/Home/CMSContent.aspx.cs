using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Site.Home
{
    public partial class CMSContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UserControl breadcrum = (UserControl)(CmsContent.FindControl("BreadCrum"));
            if (Request.QueryString["format"] != null)
                if (Convert.ToString(Request.QueryString["format"]) == "print")
                    breadcrum.Visible = false;
        }
    }
}