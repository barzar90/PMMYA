using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Data;
using DAL;

namespace BL
{
   

    public class SendSMS
    {
        #region Public variable declaration
        SMSDAL objSMSDAL = new SMSDAL();
        #endregion

        public String SMSSend(string mobileNo, string ApplicationId, string smstype)
        {
            String responseFromServer = string.Empty;
            String Status = string.Empty;
            try
            {
                /* Added by Anand For SMS Send Dated on 02-08-2018*/

                string t_XMLName = HttpContext.Current.Server.MapPath("~/APP_Data/SMSConfig.XML");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(t_XMLName);
                XmlNode xnod = xmlDoc.DocumentElement;
                XmlNodeList nodeList = xnod.SelectNodes("SMS");

                string username = string.Empty, password = string.Empty, senderid = string.Empty, message = string.Empty, secureKey = string.Empty, server = string.Empty;

                foreach (XmlNode _node in nodeList)
                {
                    server = _node.SelectSingleNode("server").InnerText.Trim();
                    username = _node.SelectSingleNode("username").InnerText.Trim();
                    password = _node.SelectSingleNode("password").InnerText.Trim();
                    senderid = _node.SelectSingleNode("senderid").InnerText.Trim();
                    secureKey = _node.SelectSingleNode("key").InnerText.Trim();

                    if (_node.Attributes["Profile"].Value.ToString().ToLower() == "welcomesms" && smstype.ToString().ToLower() == "welcome")
                    {
                        message = _node.SelectSingleNode("content").InnerText.Trim();
                    }

                    if (_node.Attributes["Profile"].Value.ToString().ToLower() == "applicationsms" && smstype.ToString().ToLower() == "application")
                    {
                        message = _node.SelectSingleNode("content").InnerText.Trim();
                        message = message.Replace("#ApplicationID", ApplicationId);
                    }
                }

                // End 02-08-2018


                //Latest Generated Secure Key
                Stream dataStream;
                //string SMSServer = string.Empty;
                //SMSServer = System.Configuration.ConfigurationManager.AppSettings["SMSServer"].ToString();
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;                                   //forcing .Net framework to use TLSv1.2
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://164.100.129.141/esms/sendsmsrequest");

                request.ProtocolVersion = HttpVersion.Version10;
                request.KeepAlive = false;
                request.ServicePoint.ConnectionLimit = 1;

                //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
                ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";

                request.Method = "POST";
                System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                String encryptedPassword = encryptedPasswod(password);
                String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
                String smsservicetype = "singlemsg"; //For single message.

                String query = "username=" + Uri.EscapeDataString(username.Trim()) +
                    "&password=" + Uri.EscapeDataString(encryptedPassword) +

                    "&smsservicetype=" + Uri.EscapeDataString(smsservicetype) +

                    "&content=" + Uri.EscapeDataString(message.Trim()) +

                    "&mobileno=" + Uri.EscapeDataString(mobileNo) +

                    "&senderid=" + Uri.EscapeDataString(senderid.Trim()) +
                  "&key=" + Uri.EscapeDataString(NewsecureKey.Trim());

                byte[] byteArray = Encoding.ASCII.GetBytes(query);

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                dataStream = request.GetRequestStream();

                dataStream.Write(byteArray, 0, byteArray.Length);

                dataStream.Close();

                WebResponse response = request.GetResponse();

                Status = ((HttpWebResponse)response).StatusDescription;

                dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                responseFromServer = reader.ReadToEnd();

                reader.Close();

                dataStream.Close();

                response.Close();

                objSMSDAL.InsertSMSLog(mobileNo, Status, responseFromServer, "");


            }
            catch (Exception Ex)
            {
                objSMSDAL.InsertSMSLog(mobileNo, Status, responseFromServer, Ex.StackTrace.ToString());
            }
            return responseFromServer;
        }

        protected String encryptedPasswod(String password)
        {

            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result = System.Text.Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {

                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();

        }
        protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);

            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }



    }
    class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
        {
            return true;
        }
    }
}
