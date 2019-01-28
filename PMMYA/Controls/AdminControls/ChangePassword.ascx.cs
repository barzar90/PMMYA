using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using Schema;
using BL;

namespace PMMYA.Controls.AdminControls
{
    public partial class ChangePassword : System.Web.UI.UserControl
    {
        public string LangID = "en-IN";
        #region Public variable declaration
        BL.BL MahaITLDBAccess;
        DataSet ds = new DataSet();
        LoginSchema OBJloginSchema = new LoginSchema();
        LoginBL ObjLoginBL = new LoginBL();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Random randomNo = new Random();
                //ViewState["_random"] = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(randomNo.Next().ToString(), "MD5");
                Random randomNo = new Random();
                ViewState["ChangePasswordLogAttempt"] = 0;
                ViewState["_random"] = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(randomNo.Next().ToString(), "MD5");
            }
            Button LoginButton = (Button)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("ChangePasswordPushButton");
            LoginButton.Attributes.Add("onclick", "javascript:return md5auth('" + Convert.ToString(ViewState["_random"]) + "');");

            Button CancelPushButton = (Button)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CancelPushButton");
            CancelPushButton.Attributes.Add("onclick", "javascript:return md5auth('" + Convert.ToString(ViewState["_random"]) + "');");
            // Added line for Post Method before that it was Get method
            ((System.Web.UI.HtmlControls.HtmlForm)this.Parent.Parent.Parent).Method = "Post";
        }

        public string CopmpareRandnoPwd(string strPassword)
        {
            string strHash = null;
            return strHash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToString(ViewState["_random"]) + strPassword, "MD5");
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            TextBox txtCurrentPassword = (TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword");
            string currentpassword = txtCurrentPassword.Text;
            TextBox txtNewPassword = (TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPassword");
            string newpassword = txtNewPassword.Text.ToUpper();

            TextBox txtConfirmNewPassword = (TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("ConfirmNewPassword");
            string confirmpassword = txtConfirmNewPassword.Text.ToUpper();

            Literal LitFailureText = (Literal)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("FailureText");

            if ((txtNewPassword.Text == "D41D8CD98F00B204E9800998ECF8427E") || (txtConfirmNewPassword.Text == "D41D8CD98F00B204E9800998ECF8427E"))
            {
                LitFailureText.Text = "Input should not be blank.";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('" + LitFailureText.Text + "');", true);
            }

            string Userid = Membership.GetUser().ProviderUserKey.ToString();
            // Comment by Anand Dated on 07-08-2018
            //SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@UserID", Userid);
            //cmd.Parameters.AddWithValue("@CurrentPassword", currentpassword);
            //cmd.Parameters.AddWithValue("@Newpassword", newpassword);
            //cmd.Parameters.AddWithValue("@Seed", Convert.ToString(ViewState["_random"]));

            if (Convert.ToInt16(ViewState["ChangePasswordLogAttempt"]) < 5)
            {
                ViewState["ChangePasswordLogAttempt"] = Convert.ToInt16(ViewState["ChangePasswordLogAttempt"]) + 1;
                if (currentpassword != newpassword)
                {
                    if (newpassword == confirmpassword)
                    {
                        //MOLDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.CommandText = "[uspChangePassword]";
                        //cmd.CommandTimeout = 1000;

                        //int result = (int)MOLDBAccess.ExecuteNonQuery(cmd);

                        OBJloginSchema.UserID = Userid;
                        OBJloginSchema.ChangedPassword = currentpassword;
                        OBJloginSchema.ConfirmPassword = newpassword;
                        OBJloginSchema.SessionID = Convert.ToString(ViewState["_random"]);

                        int result = ObjLoginBL.ChangePwd(OBJloginSchema);

                        if (result == 1)
                        {
                            LitFailureText.Text = "Changed Successfully";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('" + LitFailureText.Text + "'); window.location.href='ChangePassword.aspx';", true);
                        }
                        else
                        {
                            LitFailureText.Text = "InValid Credential";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('" + LitFailureText.Text + "'); window.location.href='ChangePassword.aspx';", true);
                        }
                    }
                    else
                    {
                        LitFailureText.Text = "New Password And Confirm New Password is not identical";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('" + LitFailureText.Text + "'); window.location.href='ChangePassword.aspx';", true);
                    }
                }
                else
                {
                    LitFailureText.Text = "Old Password And New Password are Same.Please try again..";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('" + LitFailureText.Text + "');", true);
                }
            }

        }

        protected void CancelPushButton_Click(object sender, EventArgs e)
        {
            TextBox txtCurrentPassword = (TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword");
            txtCurrentPassword.Text = "";
            TextBox txtNewPassword = (TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPassword");
            txtNewPassword.Text = "";
            TextBox txtConfirmNewPassword = (TextBox)ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("ConfirmNewPassword");
            txtConfirmNewPassword.Text = "";
            Response.Redirect("../Profiles/ChangePassword.aspx");
        }
    }
}