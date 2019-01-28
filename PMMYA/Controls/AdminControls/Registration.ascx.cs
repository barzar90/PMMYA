using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace PMMYA.Controls.AdminControls
{
    public partial class Registration : System.Web.UI.UserControl
    {
        BL.BL MAHAITDBAccess;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            Button btnCreate = (Button)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CreateUserButton");
            btnCreate.Attributes.Add("onclick", "javascript:return md5auth();");
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            UpdatePassword();
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);

        }

        /// <summary>
        /// Update the password using md5 for the created user.
        /// </summary>
        private void UpdatePassword()
        {
            TextBox Password = (TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Password");
            MAHAITDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@UserName ", RegisterUser.UserName);
            cmd.Parameters.AddWithValue("@Password ", Password.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[uspUpdateUserPassword]";
            cmd.CommandTimeout = 1000;
            MAHAITDBAccess.ExecuteNonQuery(cmd);
        }

        public string EncryptMD5(string strPassword)
        {
            string strHash = null;
            string strPass = strPassword;
            return strHash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strPass, "MD5");
        }
    }
}