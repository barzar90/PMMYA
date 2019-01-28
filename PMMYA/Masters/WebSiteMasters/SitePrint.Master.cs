using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace PMMYA.Masters.WebSiteMasters
{
    public partial class SitePrint : MAHAITMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void Page_PreRender(Object o, EventArgs e)
        {
            MAHAITUserControl _mahaitUC = new MAHAITUserControl();
            MaharashtraLogo_alt.Alt = _mahaitUC.GetResourceValue("Common", "btnContactUs", "");
            NationalEmblem_alt.Alt = _mahaitUC.GetResourceValue("Common", "NationalEmblem_alt", "");
            lbl_headTitle.Text = _mahaitUC.GetResourceValue("Common", "lbl_headTitle", "");
        }
    }
}