using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Schema;


namespace PMMYA.Controls.WebSiteControls
{
    public partial class MudraData : System.Web.UI.UserControl
    {
        UserShema objUserShema = new UserShema();
        UserDataBL objUserDataBL = new UserDataBL();
        int result = 0;
        string mudraresult = "";
        //public event EventHandler ButtonClickedSubmit;

        protected void Page_Load(object sender, EventArgs e)
        {
            string str = "abc";
            Response.Write(str);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objUserShema.Name = name.Text;
                objUserShema.Mobile = MobileNo.Text;
                objUserShema.Amount = Amount.Text;
                objUserShema.Loantype = ddlloantype.SelectedValue;
                objUserShema.Description = Description.Text;
                result = objUserDataBL.insertUserData(objUserShema);

            }
            catch (Exception )
            {

            }
        }

        [System.Web.Services.WebMethod]
        public string MudraUserDetails(string name, string mobile, string description, string loantype, string amount)
        {
            objUserShema.Name = name;
            objUserShema.Mobile = mobile;
            objUserShema.Amount = description;
            objUserShema.Loantype = loantype;
            objUserShema.Description = amount;
            result = objUserDataBL.insertUserData(objUserShema);
            if (result == 1)
            {
                mudraresult = "success";
            }
            else
            {
                mudraresult = "Failed";

            }
            return mudraresult;
        }


        //public void RaiseButtonClickSubmit(object sender, EventArgs e)
        //{
        //    if (ButtonClickedSubmit != null)
        //    {
        //        ButtonClickedSubmit(sender, e);
        //    }
        //}
    }
}