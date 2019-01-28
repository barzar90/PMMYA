using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Resources;
using System.Web;
using System.Data.OleDb;
using System.Net.Mail;
using DAL;

namespace BL
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string ColumnCaption { get; set; }
        public XmlNode FieldInfo { get; set; }
    }

    public class ColumnGroup
    {
        public string GroiupHeading { get; set; }
        public int Columns { get; set; }
    }



    public class BL : IDisposable
    {
        public DataSet ActiveDocument { get { return applicationDL.ActiveDocument; } set { applicationDL.ActiveDocument = value; } }
        public int SerialNumberLength { get { return applicationDL.SerialNumberLength; } set { applicationDL.SerialNumberLength = value; } }
        public string UserName { get { return applicationDL.UserName; } set { applicationDL.UserName = value; } }
        public string IPAddress { get { return applicationDL.IPAddress; } set { applicationDL.IPAddress = value; } }
        public string MacAddress { get { return applicationDL.MacAddress; } set { applicationDL.MacAddress = value; } }
        public string ServerPath { get { return applicationDL.ServerPath; } set { applicationDL.ServerPath = value; } }
        public string LangID { get; set; }

        public string ActiveXML;
        public bool HasErrors = false;

        private DL applicationDL;

        private SqlCommand ValidateCommadText(SqlCommand Commad)
        {
            if (Commad.CommandText.ToString().Contains("'"))
            {
                // throw new Exception("Sql Query contain single Quote !!!");
            }
            else
            {
                return Commad;
            }
            return Commad;
        }

        public List<MAHAITResponse> ValidationResponse = new List<MAHAITResponse>();
        XmlDocument XMLForm = new XmlDocument();

        public BL(string appId)
        {
            applicationDL = new DL(appId);
        }


        public SqlDataReader ExecuteReader(SqlCommand Command)
        {
            return applicationDL.ExecuteReader(ValidateCommadText(Command));
        }


        /// <summary>
        /// Executes a Query(Use this method to execute Select query or Mix Mode query)
        /// </summary>
        public DataSet ExecuteDataSet(SqlCommand Command)
        {
            return applicationDL.ExecuteDataSet(ValidateCommadText(Command));
        }

        public object ExecuteScalar(SqlCommand Command)
        {
            return applicationDL.ExecuteScalar(ValidateCommadText(Command));
        }
        /// <summary>
        /// Executes a NonQuery(Use it to execute Insert,update and delete command)
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCommand Command)
        {
            return applicationDL.ExecuteNonQuery(ValidateCommadText(Command));
        }


        public DataSet ExecuteDataSet(OleDbCommand Command, string ExcelFilePath)
        {
            return applicationDL.ExecuteDataSet(Command, ExcelFilePath);
        }

        public void GetDocument(string[] DocumentTables, string KeyValue)
        {
            applicationDL.GetDocument(DocumentTables, KeyValue);
        }

        public void ReadFromFile(string FileName)
        {
            ActiveXML = FileName;
            applicationDL.ReadFromFile(FileName);
        }

        public void WriteToFile(string FileName)
        {
            applicationDL.WriteToFile(FileName);
        }

        public void SetFieldValue(string TableName, int RowNo, string FieldName, string FieldValue)
        {
            applicationDL.SetFieldValue(TableName, RowNo, FieldName, FieldValue);
        }

        public Boolean SaveDocument(string FormGroup, string Template, bool HasProc)
        {
            return applicationDL.SaveDocument(FormGroup, Template, HasProc);
        }

        public void Dispose()
        {
            applicationDL.Dispose();
        }

        public void SaveToActiveFile()
        {
            WriteToFile(ActiveXML);
        }

        public void SendErrorMessage(string TableName, string ColumnName, string Message)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "ERR";
            t_NewResponse.Message = Message;
            HasErrors = true;
            ValidationResponse.Add(t_NewResponse);
        }

        public void SendException(string Exception)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = "";
            t_NewResponse.Action = "EXCEPTION";
            t_NewResponse.Message = Exception;
            HasErrors = true;
            ValidationResponse.Add(t_NewResponse);
        }

        public void AssignValue(string TableName, string ColumnName, string Value)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "ASV";
            t_NewResponse.Message = Value;

            ValidationResponse.Add(t_NewResponse);
        }

        public void AssignValueToParent(string TableName, string ColumnName, string Value)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = TableName + "__" + ColumnName;
            t_NewResponse.Action = "ASVTP";
            t_NewResponse.Message = Value;

            ValidationResponse.Add(t_NewResponse);
        }

        public void AssignTransactionID(string TransactionID)
        {
            MAHAITResponse t_NewResponse = new MAHAITResponse();

            t_NewResponse.FieldName = "TRNID";
            t_NewResponse.Action = "TRNID";
            t_NewResponse.Message = TransactionID;

            ValidationResponse.Add(t_NewResponse);
        }

        public string GetDescription(string FieldName, string TableName, string CodeField, string IDValue, bool HasLangId)
        {
            string t_Ret = "";
            DataTable t_DT;

            SqlCommand t_SQLCmd = new SqlCommand();
            t_SQLCmd.CommandText = "Select " + FieldName + " From " + TableName + " Where " + CodeField + " = @ID";

            if (HasLangId)
            {
                t_SQLCmd.CommandText = t_SQLCmd.CommandText + " And LangID =  " + LangID;
            }

            t_SQLCmd.Parameters.Add("@ID", SqlDbType.NVarChar);

            t_SQLCmd.Parameters["@ID"].Value = IDValue;

            t_DT = ExecuteDataSet(t_SQLCmd).Tables[0];

            if (t_DT.Rows.Count >= 1)
            {
                t_Ret = t_DT.Rows[0][0].ToString();
            }

            return t_Ret;
        }

        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = HttpContext.GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }

        //public DataTable GetRegion(string p_LevelID)
        //{


        //    DataTable t_Return;
        //    DataRow t_dr;
        //    SqlCommand t_SQLCmd = new SqlCommand();
        //    t_SQLCmd.CommandText = "Select * From MstRegion where LangID = @LangID and LevelID=@LevelID";
        //    t_SQLCmd.Parameters.Add("@LangID", System.Data.SqlDbType.Int);
        //    t_SQLCmd.Parameters.Add("@LevelID", System.Data.SqlDbType.VarChar);

        //    t_SQLCmd.Parameters["@LangID"].Value = LangID;
        //    t_SQLCmd.Parameters["@LevelID"].Value = p_LevelID;

        //    t_Return = applicationDL.ExecuteDataSet(t_SQLCmd).Tables[0];
        //    if (LangID == "1")
        //    {
        //        t_dr = t_Return.NewRow();
        //        t_dr["RegionName"] = "Select";
        //        t_dr["RegionID"] = "-1";
        //    }
        //    else
        //    {
        //        t_dr = t_Return.NewRow();
        //        t_dr["RegionName"] = "निवडा";
        //        t_dr["RegionID"] = "-1";
        //    }
        //    t_Return.Rows.InsertAt(t_dr, 0);
        //    t_Return.AcceptChanges();
        //    return t_Return;
        //}

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
                //Body = Body.Replace("#SocietyName", "'" + _body[1] + "'");
                //Body = Body.Replace("#RegistrationDT", _body[2]);
                Body = Body.Replace("#TRNID", _body[0]);
            }

            if (_To != string.Empty)
            {
                To = _To;
            }

            //if (MailProfile.Split('_')[0].ToLower() == "forgotpassword")
            //{
            //    To = _To;
            //}

            SendEmail(From, To, Subject, Body, SMTPstr, Portstr, "", "");
        }

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
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
