using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.NetworkInformation;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using Schema;
using BL;
using System.Security.Cryptography;

namespace PMMYA.Controls.AdminControls
{
    public partial class Login : System.Web.UI.UserControl
    {

        public string LangID = "en-IN";      
        DataSet ds = new DataSet();
        LoginSchema OBJloginSchema = new LoginSchema();
        LoginBL ObjLoginBL = new LoginBL();

        protected void Page_Init(object sender, EventArgs e)
        {

            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "no-cache");
            Response.Expires = -1;
            //for (int i = 0; i < Session.Count - 1; i++)
            //{
            //    if (!(Session.Keys[i] == "CaptchaImageText"))
            //    {
            //        Session[Session.Keys[i]] = null;                   
            //    }
            //}
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                HttpContext.Current.Profile.SetPropertyValue("RandomToken", string.Empty);
                HttpContext.Current.Profile.SetPropertyValue("AuthToken", string.Empty);
                Random randomNo = new Random();
                ViewState["LogAttempt"] = 0;
                ViewState["_random"] = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(randomNo.Next().ToString(), "MD5");
            }
            Button LoginButton = (Button)LoginUser.FindControl("LoginButton");
            LoginButton.Attributes.Add("onclick", "javascript:return md5auth('" + Convert.ToString(ViewState["_random"]) + "');");

            Button ForgotPassword = (Button)LoginUser.FindControl("ForgotPassword");
            ForgotPassword.Attributes.Add("onclick", "javascript:return md5auth('" + Convert.ToString(ViewState["_random"]) + "');");
        }

        protected void ClearCookies()
        {
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                HttpCookie myCookie = default(HttpCookie);
                myCookie = Request.Cookies[i];
                myCookie.Value = string.Empty;
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Set(myCookie);
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string DepartmentName = string.Empty;
            Label lblLoginPnl = (Label)LoginUser.FindControl("lblLoginPanel");
            Label lblUserName = (Label)LoginUser.FindControl("UserNameLabel");
            Label lblPassword = (Label)LoginUser.FindControl("PasswordLabel");
            Label lblRememberMe = (Label)LoginUser.FindControl("RememberMeLabel");
            Button _btlLogin = (Button)LoginUser.FindControl("LoginButton");
            Button _btnForgotPassword = (Button)LoginUser.FindControl("ForgotPassword");
            RequiredFieldValidator _UserNameRequired = (RequiredFieldValidator)LoginUser.FindControl("UserNameRequired");
            RequiredFieldValidator _PasswordRequired = (RequiredFieldValidator)LoginUser.FindControl("PasswordRequired");

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString().ToLower() == Convert.ToString("mr-IN").ToLower())
            {
                lblLogin.Text = "लॉग इन";
                lblUserName.Text = "वापरकर्त्याचे नाव";
                lblPassword.Text = "पासवर्ड";
                lblRememberMe.Text = "मला लॉगड इन राहु द्या...";
                lblLoginPnl.Text = "लेखा माहिती";
                _btlLogin.Text = "लॉग इन";
                _btnForgotPassword.Text = "पासवर्ड विसरलात";
                _UserNameRequired.ErrorMessage = "कृपया वापरकर्त्याचे नाव बरोबर लिहावे";
                _PasswordRequired.ErrorMessage = "कृपया पासवर्ड बरोबर लिहावा";
                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameMarathi"].ToString();
                Page.Title = _btlLogin.Text + "-" + DepartmentName;
            }
            else
            {
                lblLogin.Text = "Log In";
                lblUserName.Text = "User Name";
                lblPassword.Text = "Password";
                lblRememberMe.Text = "Keep me logged in...";
                lblLoginPnl.Text = "Account Information";
                _btlLogin.Text = "Login";
                _btnForgotPassword.Text = "Forgot Password";
                _UserNameRequired.ErrorMessage = "User Name is required.";
                _PasswordRequired.ErrorMessage = "Password is required.";
                DepartmentName = System.Configuration.ConfigurationManager.AppSettings["DepartmentNameEnglish"].ToString();
                Page.Title = _btlLogin.Text + "-" + DepartmentName;
            }
        }

        public string CopmpareRandnoPwd(string strPassword)
        {
            string strHash = null;
            return strHash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToString(ViewState["_random"]) + strPassword, "MD5");
        }

        protected void CreateLoginAudit(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            TextBox txtimgcode1 = (TextBox)LoginUser.FindControl("txtimgcode");
            HiddenField hdnCaptcha = (HiddenField)LoginUser.FindControl("hdnCaptcha");
            if (txtimgcode1.Text == RemoveSpace(hdnCaptcha.Value.Trim().ToString()))
            {

                TextBox _Username = (TextBox)LoginUser.FindControl("UserName");
                TextBox _Password = (TextBox)LoginUser.FindControl("Password");
                MembershipUser user = Membership.GetUser(_Username.Text);

                if (user != null)
                {
                    string strPassword = string.Empty;
                    OBJloginSchema.UserName = _Username.Text;
                    strPassword = ObjLoginBL.GetUserPassword(OBJloginSchema);

                    //Added Mahesh Patel on 27-12-2018
                    int ldmDistrictId = 0;
                    ldmDistrictId = ObjLoginBL.GetUserPasswordLDM(OBJloginSchema);

                    if ((CopmpareRandnoPwd(strPassword) == _Password.Text))
                    {
                        string strAuthToken = Guid.NewGuid().ToString();
                        HttpContext.Current.Profile.SetPropertyValue("AuthToken", strAuthToken);
                        Response.Cookies.Add(new HttpCookie("AuthToken", strAuthToken));
                        e.Authenticated = true;
                        Session["AuthToken"] = strAuthToken;
                        Session["User"] = _Username;
                        Session["LDM_DistrictId"] = ldmDistrictId;
                    }
                    else
                    {
                        txtimgcode1.Text = string.Empty;
                    }
           
                }
            }
            else
            {
                txtimgcode1.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Incorrect Captcha Value !! Try again.');", true);
            }
        }

        private string RemoveSpace(string Captchastr)
        {
            StringBuilder sb = new StringBuilder();
            char[] longChars = Captchastr.ToCharArray();

            int spaceCount = 0;

            //Using standard method with no library help
            for (int i = 0; i < longChars.Length; i++)
            {
                //If space then keep a count and move on until nonspace char is found
                if (longChars[i] == 32)
                {
                    spaceCount++;
                    continue;
                }

                //If more than one space then append a single space  
                if (spaceCount > 1 && sb.Length > 0)
                    sb.Append("");

                //Append the non space character
                sb.Append(longChars[i]);

                //Reset the space count
                spaceCount = 1;
            }
            return sb.ToString();
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        protected void RedirectUser(object sender, EventArgs e)
        {
            TextBox userName = (TextBox)LoginUser.FindControl("UserName");
            MembershipUser user = Membership.GetUser(userName.Text);

            Session["UserInRole"] = user.ToString();
            Session["UserRole"] = Roles.GetRolesForUser(userName.Text)[0].ToLower();
                      
            if (user != null)
            {
                if (Convert.ToString(Roles.GetRolesForUser(userName.Text)[0]).ToLower() == "cmsuser")
                {                  
                    Response.Redirect("~/Admin/MenuManagement/MenuList.aspx");
                }
                else if (Convert.ToString(Roles.GetRolesForUser(userName.Text)[0]).ToLower() == "webmaster")
                {
                    Response.Redirect("~/Management/access/users.aspx");
                }
                else if (Convert.ToString(Roles.GetRolesForUser(userName.Text)[0]).ToLower() == "admin")
                {
                    Response.Redirect("~/Admin/MenuManagement/MenuList.aspx");
                }
                //Manish 16-11-18
                else if (Convert.ToString(Roles.GetRolesForUser(userName.Text)[0]).ToLower() == "ldm")
                {
                    Response.Redirect("~/Admin/MenuManagement/LdmDashboard.aspx");
                    //Response.Redirect("~/Admin/MenuManagement/LDMHome.aspx");
                }
                else if (Convert.ToString(Roles.GetRolesForUser(userName.Text)[0]).ToLower() == "rjd")
                {
                    Response.Redirect("~/Site/Home/HomeAdmin.aspx");
                }
                else if (Convert.ToString(Roles.GetRolesForUser(userName.Text)[0]).ToLower() == "ssk")
                {
                    Response.Redirect("~/Site/Home/HomeAdmin.aspx");
                }
                else
                {
                    Response.Redirect("~/Site/Home/Index.aspx");
                }


            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            InsertUserSession();
        }

        protected void LoginUser_ForgotPassword(object sender, EventArgs e)
        {
            TextBox userName = (TextBox)LoginUser.FindControl("UserName");
            if (userName.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Please enter user name ');", true);
                return;
            }
            MembershipUser user = Membership.GetUser(userName.Text);
            if (user != null)
            {
                string t_Passsword;
                string t_username;

                t_Passsword = user.ResetPassword();
                t_username = userName.Text;


                OBJloginSchema.UserName = userName.Text.Trim();
                OBJloginSchema.Password = EncryptMD5(t_Passsword);

                ObjLoginBL.LoginUser_ForgotPassword(OBJloginSchema);

                //MahaITLDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                ObjLoginBL.SendEmailuser("forgotpassword_user", "", Membership.GetUser(userName.Text).Email.ToString(), "", t_Passsword, t_username);

                Label t_PasswordSent = (Label)LoginUser.FindControl("PasswordSent");
                t_PasswordSent.Text = "Password Sent to Registered Mail address"; //GetResourceValue("General", "lblPasswordSent", "Password Sent to Registered Mail address");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('Invalid UserName');", true);
            }
        }
        public string EncryptMD5(string strPassword)
        {
            string strHash = null;
            string strPass = strPassword;
            return strHash = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strPass, "MD5");
        }

        public void InsertUserSession()
        {
            try
            {
                if (Convert.ToInt16(ViewState["LogAttempt"]) < 3)
                {
                    ViewState["LogAttempt"] = Convert.ToInt16(ViewState["LogAttempt"]) + 1;

                    if (LoginUser.UserName == string.Empty) return;
                    //MahaITLDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.Parameters.AddWithValue("@UserSessionID ", Guid.Empty);
                    //cmd.Parameters.AddWithValue("@UserID ", new Guid(Membership.GetUser(LoginUser.UserName).ProviderUserKey.ToString()));
                    //cmd.Parameters.AddWithValue("@IPSecurities ", getAllAuditParameter());
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "[uspInsertUserLog]";
                    //cmd.CommandTimeout = 1000;
                    //MahaITLDBAccess.ExecuteNonQuery(cmd);

                    OBJloginSchema.Usersessionid = Guid.Empty;
                    OBJloginSchema.User_id = new Guid(Membership.GetUser(LoginUser.UserName).ProviderUserKey.ToString());
                    OBJloginSchema.IPAddress = getAllAuditParameter();

                    ObjLoginBL.InsertLog(OBJloginSchema);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Message", "alert('More than 3 attempts of Login is invalid.');", true);

                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                ds = null;
            }
        }

        public string getAllAuditParameter()
        {
            string ipaddress;
            ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (((ipaddress == "") || (ipaddress == null)))
            {
                ipaddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            string[] computer_name;
            computer_name = ipaddress.Split('.');
            string ipnmname = "IP Address: " + ipaddress + "Machine Name: " + computer_name[0].ToUpper();

            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((nic.OperationalStatus == OperationalStatus.Up))
                {
                    macAddresses = (macAddresses + nic.GetPhysicalAddress().ToString());
                    // Gets the description of the interface.
                    macAddresses = (macAddresses + (" Card Desc: " + nic.Description));
                    // Gets the identifier of the network adapter.
                    macAddresses = (macAddresses + (" ID: " + nic.Id));
                    // Local Area Nework'
                    macAddresses = (macAddresses + (" <br>NetWork Name: " + nic.Name));
                    break;
                }
            }
            return (ipnmname + (" MacAddres: " + macAddresses));
        }
    }
}