using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMYA.Controls.AdminControls
{
    public partial class UserProfile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Profile.IsAnonymous == false)
                {
                    txtLastName.Text = HttpContext.Current.Profile.GetPropertyValue("lastName").ToString();
                    txtFirstName.Text = HttpContext.Current.Profile.GetPropertyValue("firstName").ToString();
                    txtPhone.Text = HttpContext.Current.Profile.GetPropertyValue("phoneNumber").ToString();
                    txtBirthDate.Text = Convert.ToDateTime(HttpContext.Current.Profile.GetPropertyValue("birthDate")).ToShortDateString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.Profile.IsAnonymous == false)
            {
                HttpContext.Current.Profile.SetPropertyValue("lastName", txtLastName.Text);
                HttpContext.Current.Profile.SetPropertyValue("firstName", txtFirstName.Text);
                HttpContext.Current.Profile.SetPropertyValue("phoneNumber", txtPhone.Text);
                HttpContext.Current.Profile.SetPropertyValue("birthDate", DateTime.Parse(txtBirthDate.Text));
            }
            Response.Redirect("ShowProfile.aspx");
        }
    }
}