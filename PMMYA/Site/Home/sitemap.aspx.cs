using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace PMMYA.Site.Home
{
    public partial class sitemap : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string culture = Request.QueryString["culture1"];

            if (culture != null)
            {
                if (culture == "en-US")
                {
                    Session["CurrentCulture"] = "en-US";
                }

                if (culture == "mr-IN")
                {
                    Session["CurrentCulture"] = "mr-IN";
                }

            }

        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            Hashtable controls = new Hashtable();
           // controls.Add(lbl_sitemap, "lbl_sitemap");
           
            ((PageBase)Page).SetUICulture(controls);
           
        }
    }
}