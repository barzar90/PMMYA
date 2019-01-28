using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace PMMYA.Controls.AdminControls
{
    public partial class adminFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            MAHAITUserControl _MAHAITUC = new MAHAITUserControl();
            lbl_copyright.Text = _MAHAITUC.GetResourceValue("Common", "lbl_copyright", "");
            imgMahaIT_alt.Alt = _MAHAITUC.GetResourceValue("Common", "imgMahaIT_alt", "");

        }
    }
}