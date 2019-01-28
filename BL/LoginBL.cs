using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Schema;
using DAL;
using System.Web;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace BL
{
    public class LoginBL
    {
        LoginDAL objLoginDAL;
        DataSet ds;
        LoginSchema r_objLoginSchema = new LoginSchema();
        StringBuilder Return_Message = new StringBuilder();
        DataSet res_user;
        string res_user1;
        int returnval;

        public DataSet GetUsername(LoginSchema r_objLoginSchema)
        {
            try
            {
                objLoginDAL = new LoginDAL();
                res_user = objLoginDAL.CheckUsername(r_objLoginSchema);
                return res_user;


            }
            catch (Exception e)
            { return null; }
            finally
            {
                objLoginDAL = null;
                r_objLoginSchema = null;
                ds = null;
                res_user = null;
            }
        }

        public DataSet GetUsernameforchangepassword(LoginSchema r_objLoginSchema)
        {
            try
            {
                objLoginDAL = new LoginDAL();
                res_user = objLoginDAL.CheckUsernameforchangepassword(r_objLoginSchema);
                return res_user;


            }
            catch (Exception e)
            { return null; }
            finally
            {
                objLoginDAL = null;
                r_objLoginSchema = null;
                ds = null;
                res_user = null;
            }
        }

        public string GetUrl(LoginSchema r_objLoginSchema)
        {
            try
            {
                objLoginDAL = new LoginDAL();
                ds = objLoginDAL.GetUrl(r_objLoginSchema);
                res_user1 = ds.Tables[0].Rows[0][0].ToString();

                return res_user1;
            }
            catch (Exception e) { return null; }
            finally
            {
                objLoginDAL = null;
                r_objLoginSchema = null;
                ds = null;
                res_user1 = null;
            }
        }

        public int insertSession(LoginSchema r_objLoginSchema)
        {
            try
            {

                objLoginDAL = new LoginDAL();
                returnval = objLoginDAL.insertSession(r_objLoginSchema);


                return returnval;
            }
            catch (Exception e) { return 0; }
            finally
            {
                objLoginDAL = null;
                r_objLoginSchema = null;
                returnval = 0;
            }
        }

        public int insertAttemptBAL(LoginSchema r_objLoginSchema)
        {
            try
            {

                objLoginDAL = new LoginDAL();
                returnval = objLoginDAL.IncreaseAttemptCount(r_objLoginSchema);


                return returnval;
            }
            catch (Exception e) { return 0; }
            finally
            {
                objLoginDAL = null;
                r_objLoginSchema = null;
                returnval = 0;
            }
        }

        public int LogoutSession(string str)
        {
            try
            {

                objLoginDAL = new LoginDAL();
                returnval = objLoginDAL.LogoutSession(str);


                return returnval;
            }
            catch (Exception e) { return 0; }
            finally
            {
                objLoginDAL = null;
                str = null;

            }
        }

        public int ForceChangePasswordBL(LoginSchema r_objLoginSchema)
        {
            try
            {

                objLoginDAL = new LoginDAL();
                returnval = objLoginDAL.ForceChangePasswordDAL(r_objLoginSchema);


                return returnval;
            }
            catch (Exception e) { return 0; }
            finally
            {
                objLoginDAL = null;
                returnval = 0;

            }
        }

        public DataSet GetEmailIDbyUserID(LoginSchema objLoginSchmema)
        {
            try
            {
                objLoginDAL = new LoginDAL();
                ds = objLoginDAL.GetEmailIDbyUserID(objLoginSchmema);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                objLoginDAL = null;
                ds = null;
            }
        }

        public DataSet GetEmailIDbyEmailID(LoginSchema objLoginSchmema)
        {
            try
            {
                ds = new DataSet();
                objLoginDAL = new LoginDAL();
                ds = objLoginDAL.GetEmailIDbyEmailID(objLoginSchmema);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                objLoginDAL = null;
                ds = null;
            }
        }

        public string SetForgotPassword(LoginSchema objLoginSchema)
        {
            string result;
            try
            {
                objLoginDAL = new LoginDAL();
                result = objLoginDAL.SetForgotPassword(objLoginSchema);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet CheckForgotPwdToken(LoginSchema objLoginSchema)
        {
            try
            {

                objLoginDAL = new LoginDAL();
                ds = objLoginDAL.CheckForgotPwdToken(objLoginSchema);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objLoginDAL = null;
                ds = null;
            }

        }

        public int ChangeResetPasswordSVT(LoginSchema objLoginSchema)
        {
            int result;
            try
            {
                objLoginDAL = new LoginDAL();
                result = objLoginDAL.ChangeResetPasswordSVT(objLoginSchema);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Login Control
        // Added By KP on 18-05-2018//
        public string GetUserPassword(LoginSchema r_objLoginSchema)
        {
            try
            {
                string password;
                objLoginDAL = new LoginDAL();
                password = objLoginDAL.GetUserPassword(r_objLoginSchema);
                return password;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                objLoginDAL = null;
                r_objLoginSchema = null;
                ds = null;
                res_user1 = null;
            }
        }

        // Added Mahesh Patel on 18-05-2018//
        public int GetUserPasswordLDM(LoginSchema r_objLoginSchema)
        {
            try
            {
                int password;
                objLoginDAL = new LoginDAL();
                password = objLoginDAL.GetUserPasswordLDM(r_objLoginSchema);
                return password;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                objLoginDAL = null;
                r_objLoginSchema = null;
                ds = null;
                res_user1 = null;
            }
        }


        public int UpdateUserPassword(LoginSchema objLoginSchema)
        {
            int result;
            try
            {
                objLoginDAL = new LoginDAL();
                result = objLoginDAL.ChangeResetPasswordSVT(objLoginSchema);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendEmailuser(string MailProfile, string _From, string _To, string _Subject, string _Body, string _BodyU)
        {
            string SMTPstr = string.Empty, Portstr = string.Empty, From = string.Empty, To = string.Empty, Subject = string.Empty, Body = string.Empty, BodyU = string.Empty;
            string t_XMLName = HttpContext.Current.Server.MapPath("~/APP_Data/MailConfig.XML");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(t_XMLName);
            XmlNode xnod = xmlDoc.DocumentElement;
            XmlNodeList nodeList = xnod.SelectNodes("Mail");

            foreach (XmlNode _node in nodeList)
            {
                string Profile = _node.Attributes["Profile"].Value.ToString();
                if (_node.Attributes["Profile"].Value.ToString().ToLower() == MailProfile.Split('_')[0].ToLower())
                {
                    SMTPstr = _node.SelectSingleNode("host").InnerText.Trim();
                    Portstr = _node.SelectSingleNode("port").InnerText.Trim();
                    From = _node.SelectSingleNode("from").InnerText.Trim();
                    To = _node.SelectSingleNode("to").InnerText.Trim();
                    Subject = _node.SelectSingleNode("subject").InnerText.Trim();
                    //Body = _node.SelectSingleNode("body").InnerText.Trim();

                    XmlElement e = (XmlElement)_node;
                    Body = e.GetElementsByTagName(MailProfile.Split('_')[1].ToLower())[0].InnerText;
                }
            }


            if (MailProfile.Split('_')[0].ToLower() == "society")
            {
                string[] _body = _Body.Split('|');

                Body = Body.Replace("#UserName", _body[0]);
                Body = Body.Replace("#SocietyName", "'" + _body[1] + "'");
                Body = Body.Replace("#RegistrationDT", _body[2]);
                Body = Body.Replace("#TRNID", _body[3]);
            }

            if (MailProfile.Split('_')[0].ToLower() == "forgotpassword")
            {

                string[] _body = _Body.Split('|');
                string[] _bodyU = _BodyU.Split('|');
                Body = Body.Replace("#UserName", _bodyU[0]);
                Body = Body.Replace("#TRNID", _body[0]);
            }

            if (_To != string.Empty)
            {
                To = _To;
            }
            SendEmail(From, To, Subject, Body, SMTPstr, Portstr, "", "");
        }

        //private void SendEmail(string From, string To, string Subject, string Message, string hostAddress, string portaddress, string cc, string bcc)
        //{
        //    try
        //    {
        //        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(From, To, Subject, Message);

        //        if (cc != string.Empty)
        //            message.CC.Add(cc);
        //        if (bcc != string.Empty)
        //            message.Bcc.Add(bcc);
        //        SmtpClient client = new SmtpClient(hostAddress, Convert.ToInt32(portaddress));
        //        client.Send(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void SendEmail(string From, string To, string Subject, string Message, string hostAddress, string portaddress, string cc, string bcc)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(From, To, Subject, Message);

                if (cc != string.Empty)
                    message.CC.Add(cc);
                if (bcc != string.Empty)
                    message.Bcc.Add(bcc);
                SmtpClient client = new SmtpClient(hostAddress, Convert.ToInt32(portaddress));
                //client.Send(message);


                //client.Host = ConfigurationManager.AppSettings["host"];
                client.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = From;//"rechargeme2016@gmail.com ";
                NetworkCred.Password = "Pass@123";//"Pass@123";
                client.UseDefaultCredentials = true;
                client.Credentials = NetworkCred;
                client.Port = Convert.ToInt16(ConfigurationManager.AppSettings["port"]);
                client.TargetName = "STARTTLS/smtp.gmail.com";
                client.Send(message);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertLog(LoginSchema objLoginSchema)
        {
            int result;
            try
            {
                objLoginDAL = new LoginDAL();
                result = objLoginDAL.InsertLog(objLoginSchema);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int LoginUser_ForgotPassword(LoginSchema objLoginSchema)
        {
            int result;
            try
            {
                objLoginDAL = new LoginDAL();
                result = objLoginDAL.UpdateUserPassword(objLoginSchema);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Added by Anand Dated on 07-08-2018
        public int ChangePwd(LoginSchema objLoginSchema)
        {
            int result;
            try
            {
                objLoginDAL = new LoginDAL();
                result = objLoginDAL.ChangePwd(objLoginSchema);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //End 07-08-2018

        #endregion
    }
}
