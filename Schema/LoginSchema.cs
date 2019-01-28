using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class LoginSchema
    {
        private string username;
        private string password;
        private string urllogin;
        private string userid;
        private string sessionid;
        private string ipaddress;
        private string changedpassword;
        private string _EmailId1;
        private string confirmPassword;
        private string forgotPasswordToken;
        private int queryNo;
        private Guid usersessionid;
        private Guid user_id;
        public string getAllAuditParameter;

        public int QueryNo
        {
            get { return queryNo; }
            set { queryNo = value; }
        }

        public string ForgotPasswordToken
        {
            get { return forgotPasswordToken; }
            set { forgotPasswordToken = value; }
        }
        public string EmailId1
        {
            get { return _EmailId1; }
            set { _EmailId1 = value; }
        }
        //public string EmailId
        //{
        //    get { return emailId; }
        //    set { emailId = value; }
        //}
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }

        private string mobileNo;

        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }

        public string SessionID
        {
            get { return sessionid; }

            set { sessionid = value; }
        }

        public string IPAddress
        {
            get { return ipaddress; }

            set { ipaddress = value; }
        }

        public string UserName
        {

            get { return username; }

            set { username = value; }

        }

        public string Password
        {

            get { return password; }

            set { password = value; }

        }

        public string Url
        {
            get { return urllogin; }

            set { urllogin = value; }
        }
        public string UserID
        {
            get { return userid; }

            set { userid = value; }
        }

        public string ChangedPassword
        {
            get { return changedpassword; }

            set { changedpassword = value; }
        }

        public string GetAllAuditParameter
        {
            get { return getAllAuditParameter; }

            set { getAllAuditParameter = value; }
        }

        public Guid Usersessionid
        {
            get { return usersessionid; }

            set { usersessionid = value; }
        }

        public Guid User_id
        {
            get { return user_id; }

            set { user_id = value; }
        }
    }
}
