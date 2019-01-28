using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using BL;
using Schema;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Collections;
using Helper;
using System.Xml;
using System.Net.Mail;
using System.Net;

namespace PMMYA.Site.Home
{
    public partial class Index : System.Web.UI.Page
    {
        UserShema objUserShema = new UserShema();
        UserDataBL objUserDataBL = new UserDataBL();
        int LangID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        //public JsonResult VerifyBarcode(string Sel_Barcode)
        //{
        //}
        //[System.Web.Services.WebMethod]
        //public int saveData(string name, string mobile, string description, string loantype, string amount)

        //{

        //    try

        //    {
        //        int result = 1;
        //        //UserShema userShema = new UserShema();
        //        //UserDataBL objUserDataBL = new UserDataBL();
        //        //userShema.Name = name;
        //        //userShema.Mobile = mobile;
        //        //userShema.Description = description;
        //        //userShema.Loantype = loantype;
        //        //userShema.Amount = amount;
        //        //result = objUserDataBL.insertUserData(userShema);


        //        return result;

        //    }


        //    catch

        //    {
        //        return 0;


        //    }

        //}
        protected void Page_PreRender(Object sender, EventArgs e)
        {
            if (LangID == 1)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";

            }
            //Added By K.p
            else if (LangID == 3)
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";
            }
            else
            {
                Page.MetaDescription = "";
                Page.MetaKeywords = "";

            }

            MAHAITUserControl _MahaITUC = new MAHAITUserControl();
            lblWelcomeMsg.Text = _MahaITUC.GetResourceValue("Common", "WelcomeMsg", "");
            Session["WelcomeMsg"] = lblWelcomeMsg.Text;
        }



        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = HttpContext.GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        [System.Web.Services.WebMethod()]
        //public static string MudraUserDetails(string name, string mobile, string BusinessPurpose, string loantype, string amount)   
        public static string MudraUserDetails(string name, string mobile, string BusinessPurpose, string Email)
        {
            UserShema objUserShema = new UserShema();
            UserDataBL objUserDataBL = new UserDataBL();
            string mudraresult = string.Empty;
            int result = 0;
            SendSMS objSendSMS = new SendSMS();
            int LangID = 0;
            objUserShema.Name = name;
            objUserShema.Mobile = mobile;
            //if (!string.IsNullOrEmpty(amount))
            //{
            //    objUserShema.Amount = Convert.ToDecimal(amount);
            //}
            //else
            //{
            //    objUserShema.Amount = 0;
            //}

            //objUserShema.Loantype = Convert.ToInt32(loantype);
            objUserShema.Email = Email;
            objUserShema.Buspurpose = Convert.ToInt32(BusinessPurpose);
            objUserShema.Applicant_SessionId = System.Web.HttpContext.Current.Session.SessionID;
            result = objUserDataBL.insertUserData(objUserShema);
            if (result == 1)
            {
                mudraresult = "success";
                if (objUserShema.Mobile.ToString() != "" || objUserShema.Mobile.ToString() != string.Empty)
                {
                    objSendSMS.SMSSend(objUserShema.Mobile, "", "welcome");
                }
                if (objUserShema.Email.ToString() != "" || objUserShema.Email.ToString() != string.Empty)
                {
                    SendEamil(objUserShema.Email.ToString());
                }
            }
            else
            {
                mudraresult = "Failed";
            }
            return mudraresult;
        }

        public static void SendEamil(string ToEmail)
        {
            try
            {
                string t_XMLName = HttpContext.Current.Server.MapPath("~/APP_Data/MailConfig.XML");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(t_XMLName);
                XmlNode xnod = xmlDoc.DocumentElement;
                XmlNodeList nodeList = xnod.SelectNodes("Mail");

                foreach (XmlNode _node in nodeList)
                {
                    string SMTPstr = string.Empty, Portstr = string.Empty, FromEamil = string.Empty, To = string.Empty, Subject = string.Empty, Body = string.Empty, BodyU = string.Empty, FromEmailPwd = string.Empty;

                    SMTPstr = _node.SelectSingleNode("host").InnerText.Trim();
                    Portstr = _node.SelectSingleNode("port").InnerText.Trim();
                    FromEamil = _node.SelectSingleNode("from").InnerText.Trim();
                    FromEmailPwd = _node.SelectSingleNode("pwd").InnerText.Trim();

                    if (_node.Attributes["Profile"].Value.ToString().ToLower() == "welcome")
                    {
                        To = ToEmail.ToString().Trim();
                        Subject = _node.SelectSingleNode("subject").InnerText.Trim();
                        Body = _node.SelectSingleNode("body").InnerText.Trim();
                    }

                    if (To.ToString() != "" || To.ToString().Trim() != string.Empty)
                    {
                        using (MailMessage mm = new MailMessage(FromEamil, To))
                        {
                            mm.Subject = Subject;
                            mm.Body = Body;
                            mm.IsBodyHtml = true;
                            using (SmtpClient smtp = new SmtpClient())
                            {
                                smtp.Host = SMTPstr;
                                smtp.EnableSsl = true;
                                NetworkCredential NetworkCred = new NetworkCredential();
                                NetworkCred.UserName = FromEamil;//"rechargeme2016@gmail.com ";
                                NetworkCred.Password = FromEmailPwd;//"Pass@123";
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = Convert.ToInt16(Portstr);
                                smtp.TargetName = "STARTTLS/smtp.gmail.com";
                                smtp.Send(mm);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Added by Manish


        [System.Web.Services.WebMethod]
        public static ArrayList PopulateDistrict(int StateID)
        {
            string Langid;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
            {
                Langid = "1";

            }
            else { Langid = "2"; }
            ArrayList list = new ArrayList();
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {

                //String strConnString = ConfigurationManager
                //    .ConnectionStrings["conString"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LangID", Langid);
                    cmd.Parameters.AddWithValue("@StateID", StateID);
                    cmd.CommandText = "[Sp_BindDistrictDropDown]";
                    cmd.Connection = objConn;
                    //objConn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["Districtname"].ToString(),
                       sdr["Districtcode"].ToString()
                        ));
                    }
                    objConn.Close();
                    return list;
                }

            }

            catch (Exception ex)
            { }
            return list;
        }

        [System.Web.Services.WebMethod]
        public static ArrayList PopulateSubDistrict(int DistrictID)
        {
            string Langid;
            if (System.Threading.Thread.CurrentThread.CurrentCulture.ToString() == "en-IN")
            {
                Langid = "1";

            }
            else { Langid = "2"; }
            ArrayList list = new ArrayList();
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {





                //String strConnString = ConfigurationManager
                //    .ConnectionStrings["conString"].ConnectionString;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LangID", Langid);
                    cmd.Parameters.AddWithValue("@DistrictID", DistrictID);
                    cmd.CommandText = "[Sp_BindSubDistrictDropDown]";
                    cmd.Connection = objConn;
                    //objConn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["SubDistrictname"].ToString(),
                       sdr["SubDistrictcode"].ToString()
                        ));
                    }
                    objConn.Close();
                    return list;
                }

            }

            catch (Exception ex)
            { }
            return list;
        }


        [System.Web.Services.WebMethod()]
        //public static string MudraUserDetails(string name, string mobile, string BusinessPurpose, string loantype, string amount)   
        public static string CheckDuplicate(string MobileNo)
        {
            UserShema objUserShema = new UserShema();
            UserDataBL objUserDataBL = new UserDataBL();
            string mudraresult = string.Empty;
            int result = 0;
            objUserShema.Mobile = MobileNo;
            result = objUserDataBL.CheckDuplicate(objUserShema);
            if (result > 0)
            {
                mudraresult = "success";               
            }
            else
            {
                mudraresult = "Failed";
            }
            return mudraresult;
        }



        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static DropDownnSchema[] PopulateBank(int TalukaID)
        {
            string conn = ConfigurationManager.ConnectionStrings["Local"].ToString();
            DataTable dt = new DataTable();
            List<DropDownnSchema> custList = new List<DropDownnSchema>();
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("SP_PopulateBankDetails", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TalukaID", TalukaID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        DropDownnSchema cust = new DropDownnSchema();
                        cust.BankName = dtrow["BankName"].ToString();
                        cust.BranchAddress = dtrow["BranchAddress"].ToString();
                        cust.BranchManagerName = dtrow["BranchManagerName"].ToString();
                        cust.BranchTelNowithSTDcode = dtrow["BranchTelNowithSTDcode"].ToString();
                        custList.Add(cust);
                    }
                }
            }
            return custList.ToArray();
        }


        [WebMethod]
        public static string GetCustomers(string TalukaID)
        {
            //DataTable dt = new DataTable();
            //dt.TableName = "Customers";
            //dt.Columns.Add("CustomerID", typeof(string));
            //dt.Columns.Add("ContactName", typeof(string));
            //dt.Columns.Add("City", typeof(string));
            //DataRow dr1 = dt.NewRow();
            //dr1["CustomerID"] = 1;
            //dr1["ContactName"] = "Customer1";
            //dr1["City"] = "City1";
            //dt.Rows.Add(dr1);
            //DataRow dr2 = dt.NewRow();
            //dr2["CustomerID"] = 2;
            //dr2["ContactName"] = "Customer2";
            //dr2["City"] = "City2";
            //dt.Rows.Add(dr2);
            //DataRow dr3 = dt.NewRow();
            //dr3["CustomerID"] = 3;
            //dr3["ContactName"] = "Customer3";
            //dr3["City"] = "City3";
            //dt.Rows.Add(dr3);
            //DataRow dr4 = dt.NewRow();
            //dr4["CustomerID"] = 4;
            //dr4["ContactName"] = "Customer4";
            //dr4["City"] = "City4";
            //dt.Rows.Add(dr4);
            //DataRow dr5 = dt.NewRow();
            //dr5["CustomerID"] = 5;
            //dr5["ContactName"] = "Customer5";
            //dr5["City"] = "City5";
            //dt.Rows.Add(dr5);


            string conn = ConfigurationManager.ConnectionStrings["Local"].ToString();
            DataTable dt = new DataTable();
            //List<DropDownnSchema> custList = new List<DropDownnSchema>();
            using (SqlConnection con = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("SP_PopulateBankDetails", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TalukaID", TalukaID);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);

                }
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds.GetXml();
        }
    }
}