using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Controls.WebSiteControls
{
    public partial class LDM_Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"].Value != string.Empty)
                {
                    if ((Session["AuthToken"].ToString() != Request.Cookies["AuthToken"].Value))
                    {
                        Session.Abandon();
                        Session.Clear();
                        Session.RemoveAll();// Abandon the current session
                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1); // Clear the ASP.NET_SessionId cookie
                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddDays(-1); // Clear the Auth token                      
                        ScriptManager.RegisterStartupScript(this, GetType(), "MyScript", "alert('Your login session has expired!-GC!');location.href=('Login.aspx')", true);
                        return;
                    }
                }
                var ddnm = Session["User"];
                var AdminVisible = Session["LDM_DistrictId"];

                if (Convert.ToInt32(AdminVisible) == 100)
                {
                    lnk_ldmfrm.Visible = true;
                }
                else
                {
                    lnk_ldmfrm.Visible = false;
                }
                Session["User"] = Session["UserInRole"];
            }
        }

        protected void lnk_ldmfrm_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MenuManagement/LDMHome.aspx");
        }

        #region Reports
        //protected void lnk_statelvlrep_Click(object sender, EventArgs e)
        //{                      
        //    Response.Redirect("~/App/LdmForms/StateLevelReport.aspx");            
        //}
        protected void lnk_distlvlrep_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/LdmForms/DistrictLevelReport.aspx");
        }
        protected void lnk_bankwiserep_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/LdmForms/BankWiseReport.aspx");            
        }
        protected void lnk_SocialCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/LdmForms/CategoryWiseReport.aspx");
        }
        #endregion

        #region Best Performance
        protected void lnk_distperformance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/LdmForms/BestTopDistrictPerformance.aspx");
        }
        protected void lnk_bankperformance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/App/LdmForms/BestTopBankPerformance.aspx");
        }

        #endregion

        #region Useful Link
        //protected void lnk_SIDBI_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("<a href='https://sidbi.in/index.php'></a>");
        //}
        //protected void lnk_StandupIndia_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("https://www.standupmitra.in/");            
        //}
        //protected void lnk_UdyamiMitra_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("https://www.udyamimitra.in/");        
        //}
        #endregion

        protected void lnk_dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MenuManagement/LDMDashboard.aspx");
        }
    }
}