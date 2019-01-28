using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;
using System.Security.Cryptography;

namespace DAL
{
    public class DL: IDisposable
    {
        private SqlConnection Connection { get; set; }
        private SqlTransaction Transaction { get; set; }
        private string ApplicationID { get; set; }

        public DataSet ActiveDocument { get; set; }
        public int SerialNumberLength { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public string ServerPath { get; set; }

        public DL(string APPID)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings[APPID].ConnectionString;
            //string connString = DecryptText(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationSettings.AppSettings["APPID"].ToString()].ToString(), "SilverAmreli");
            ApplicationID = APPID;
            //ServerPath = serverPath;

            if (!string.IsNullOrEmpty(connString))
            {
                Connection = new SqlConnection(connString);
            }
        }


        [Obsolete]
        private string GetConnectionString(string appId)
        {
            XmlDocument document = new XmlDocument();
            if (File.Exists(ServerPath + "\\App_Data\\" + appId + ".Config"))
            {
                document.Load(ServerPath + "\\App_Data\\" + appId + ".Config");
                XmlElement APP = (XmlElement)document.FirstChild;
                if (APP != null)
                    return DecodeFrom64(APP.InnerText);
            }
            return string.Empty;
        }

        [Obsolete]
        private XmlElement GetAPPNode(string appId, XmlElement config)
        {
            foreach (XmlElement element in config.ChildNodes)
            {
                if (element.Name.Equals("APP"))
                {
                    if (element.GetAttribute("ID").Equals(appId))
                        return element;
                }
            }

            return null;
        }

        public SqlDataReader ExecuteReader(SqlCommand Command)
        {
            // Create a clone of a sqlcommand object
            SqlDataReader reader;
            SqlCommand t_Cmd = Command.Clone();
            t_Cmd.Connection = this.Connection;
            if (Connection.State == ConnectionState.Closed)
            {
                t_Cmd.Connection.Open();
            }
            t_Cmd.Connection = this.Connection;
            reader = t_Cmd.ExecuteReader();
            t_Cmd.Dispose();
            return reader;
        }


        /// <summary>
        /// Executes a Query(Use this method to execute Select query or Mix Mode query)
        /// </summary>
        public DataSet ExecuteDataSet(SqlCommand Command)
        {
            DataSet t_Return;

            // Create a clone of a sqlcommand object
            SqlCommand t_Cmd = Command.Clone();
            t_Cmd.Connection = this.Connection;
            t_Return = new DataSet();
            SqlDataAdapter t_Sda = new SqlDataAdapter(t_Cmd);
            t_Sda.Fill(t_Return);

            t_Cmd.Dispose();
            t_Sda.Dispose();
            return t_Return;
        }

        public DataSet ExecuteDataSet(OleDbCommand Command, string ExcelFilePath)
        {
            DataSet t_Return;
            DataTable dt;

            // Create a clone of a sqlcommand object
            string excelConnStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'", ExcelFilePath);
            OleDbConnection conn = new OleDbConnection(excelConnStr);
            conn.Open();
            Command.Connection = conn;
            DbDataReader dr = Command.ExecuteReader();
            dt = new DataTable();
            t_Return = new DataSet();
            dt.Load(dr);
            t_Return.Tables.Add(dt);
            conn.Close();

            Command.Dispose();
            conn.Dispose();
            dt.Dispose();
            dr.Dispose();
            return t_Return;
        }

        public object ExecuteScalar(SqlCommand Command)
        {
            object t_Return;

            SqlCommand t_Cmd = Command.Clone();
            this.Connection.Open();
            t_Cmd.Connection = this.Connection;

            t_Return = t_Cmd.ExecuteScalar();
            this.Connection.Close();
            return t_Return;
        }

        /// <summary>
        /// Executes a NonQuery(Use it to execute Insert,update and delete command)
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCommand Command)
        {
            //Boolean result = false;
            int rowsAffected = 0;

            // Create a clone of a sqlcommand object
            SqlCommand t_Cmd = Command.Clone();
            t_Cmd.Connection = this.Connection;
            if (Connection.State == ConnectionState.Closed)
            {
                t_Cmd.Connection.Open();
            }
            t_Cmd.Transaction = this.Connection.BeginTransaction();
            try
            {
                rowsAffected = t_Cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    t_Cmd.Transaction.Commit();
                    //result = true;
                }
                else
                {
                    t_Cmd.Transaction.Rollback();
                    //result = false;
                }
                t_Cmd.Connection.Close();
            }
            catch (Exception ex1)
            {
                t_Cmd.Transaction.Rollback();
                throw ex1;
            }

            t_Cmd.Dispose();
            return rowsAffected;
        }

        public void GetDocument(string[] DocumentTables, string KeyValue)
        {
            string t_CMD = "";
            int I = -1;
            ActiveDocument = null;
            ActiveDocument = new DataSet();

            foreach (string t_String in DocumentTables)
            {
                t_CMD = t_CMD + "Select * From " + t_String + " Where TransactionID = '" + KeyValue + "' Order BY RowID;";
            }

            SqlDataAdapter daDocument = new SqlDataAdapter(t_CMD, Connection);
            daDocument.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            daDocument.Fill(ActiveDocument);

            foreach (string t_String in DocumentTables)
            {
                I++;

                ActiveDocument.Tables[I].TableName = t_String;
            }
        }

        public void ReadFromFile(string FileName)
        {
            ActiveDocument = new DataSet();

            ActiveDocument.ReadXml(ServerPath + "\\" + FileName, XmlReadMode.Auto);

            foreach (DataTable dt in ActiveDocument.Tables)
            {
                dt.Columns["RowID"].AutoIncrement = false;
            }
        }

        public void WriteToFile(string FileName)
        {
            ActiveDocument.WriteXml(ServerPath + "\\" + FileName, XmlWriteMode.WriteSchema);
        }
      

        public void SetFieldValue(string TableName, int RowNo, string FieldName, string FieldValue)
        {
            if (!FieldName.ToUpper().Equals("ROWID") && !FieldName.ToUpper().Equals("TransactionID") && !FieldName.ToUpper().Equals("ACTIVE"))
            {
                DataColumn dc1 = ActiveDocument.Tables[TableName].Columns[FieldName];

                if (dc1.Expression == "")
                {

                    if (ActiveDocument.Tables[TableName].Rows.Count >= (RowNo + 1))
                    {
                        if (FieldValue == "" || FieldValue == null)
                        {
                            if (dc1.DataType == typeof(int) || dc1.DataType == typeof(Int16) || dc1.DataType == typeof(Int32) || dc1.DataType == typeof(Int64) || dc1.DataType == typeof(Double)
                                || dc1.DataType == typeof(uint) || dc1.DataType == typeof(UInt16) || dc1.DataType == typeof(UInt32) || dc1.DataType == typeof(UInt64)
                                || dc1.DataType == typeof(decimal) || dc1.DataType == typeof(Decimal) || dc1.DataType == typeof(Single))
                            {
                                if (dc1.AutoIncrement == false)
                                {
                                    ActiveDocument.Tables[TableName].Rows[RowNo][FieldName] = 0;
                                }
                            }
                            else
                            {
                                ActiveDocument.Tables[TableName].Rows[RowNo][FieldName] = DBNull.Value;
                            }
                        }
                        else
                        {
                            ActiveDocument.Tables[TableName].Rows[RowNo][FieldName] = FieldValue;  //drNew[FieldName] = FieldValue;
                        }
                    }
                    else
                    {
                        // RowNo doesnot exist.New row should be created

                        foreach (DataColumn dc in ActiveDocument.Tables[TableName].Columns)
                        {
                            if (dc.DataType == typeof(int) || dc.DataType == typeof(Int16) || dc.DataType == typeof(Int32) || dc.DataType == typeof(Int64) || dc.DataType == typeof(Double)
                                 || dc.DataType == typeof(uint) || dc.DataType == typeof(UInt16) || dc.DataType == typeof(UInt32) || dc.DataType == typeof(UInt64)
                                || dc.DataType == typeof(decimal) || dc.DataType == typeof(Decimal) || dc.DataType == typeof(Single))
                            {
                                if (dc.AutoIncrement == false)
                                {
                                    dc.DefaultValue = 0;
                                }
                            }
                        }

                        DataRow drNew = ActiveDocument.Tables[TableName].NewRow();

                        if (FieldValue == "" || FieldValue == null)
                        {
                            if (dc1.DataType == typeof(int) || dc1.DataType == typeof(Int16) || dc1.DataType == typeof(Int32) || dc1.DataType == typeof(Int64) || dc1.DataType == typeof(Double)
                                || dc1.DataType == typeof(uint) || dc1.DataType == typeof(UInt16) || dc1.DataType == typeof(UInt32) || dc1.DataType == typeof(UInt64)
                                || dc1.DataType == typeof(decimal) || dc1.DataType == typeof(Decimal) || dc1.DataType == typeof(Single))
                            {
                                if (dc1.AutoIncrement == false)
                                {
                                    drNew[FieldName] = 0;
                                }
                            }
                            else
                            {
                                drNew[FieldName] = DBNull.Value;
                            }
                        }
                        else
                        {
                            drNew[FieldName] = FieldValue;
                        }


                        ActiveDocument.Tables[TableName].Rows.Add(drNew);
                    }
                }
            }
        }

        public void SetFieldValue(string TableName, Int16 RowNo, string FieldName, DateTime FieldValue)
        {
            SetFieldValue(TableName, RowNo, FieldName, FieldValue.ToString("yyyy-MM-dd"));
        }

        public Boolean SaveDocument(string FormGroup, string Template, bool HasProc)
        {
            Boolean result = true;
            string newTransactionId = "";

            ActiveDocument.Tables[0].Rows[0]["Active"] = true;

            this.Connection.Open();

            Transaction = this.Connection.BeginTransaction();

            try
            {
                if (Convert.ToInt32(ActiveDocument.Tables[0].Rows[0]["RowID"]) == 0) // If it is Insert Case
                {
                    // Generate a New TransactionID
                    newTransactionId = GetTransactionId(ActiveDocument.Tables[0].Rows[0]["PreFix"].ToString(), this.UserName, this.SerialNumberLength);

                    if (!string.IsNullOrEmpty(newTransactionId))
                        ActiveDocument.Tables[0].Rows[0]["TransactionID"] = newTransactionId;
                    else
                    {
                        Transaction.Rollback();
                        //this.Connection.Close();
                        result = false;
                    }

                }

                if (result)
                {
                    if (InsertDocument())
                    {

                        if (HasProc)
                        {
                            SqlCommand t_TranId_CMD = new SqlCommand();

                            t_TranId_CMD.Connection = this.Connection;
                            t_TranId_CMD.CommandType = CommandType.StoredProcedure;
                            t_TranId_CMD.CommandText = FormGroup + "__" + Template;
                            t_TranId_CMD.Transaction = this.Transaction;

                            // Adding the SP parameters to the collection
                            t_TranId_CMD.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 250);

                            t_TranId_CMD.Parameters["@TransactionID"].Value = newTransactionId;
                            t_TranId_CMD.ExecuteNonQuery();
                        }

                        Transaction.Commit();
                        result = true;
                    }
                    else
                    {
                        Transaction.Rollback();
                        result = false;
                    }
                    //this.Connection.Close();
                }

            }
            catch (Exception ex1)
            {
                Transaction.Rollback();
                //this.Connection.Close();
                //result = false;
                throw ex1;
            }

            return result;



        }

        private string GetTransactionId(string prefix, string userId, int serialNumberLength)
        {
            string newTransactionId = string.Empty;

            SqlCommand t_TranId_CMD = new SqlCommand();

            t_TranId_CMD.Connection = this.Connection;
            t_TranId_CMD.CommandType = CommandType.StoredProcedure;
            t_TranId_CMD.CommandText = "GenerateSerialNo";
            t_TranId_CMD.Transaction = this.Transaction;

            // Adding the SP parameters to the collection
            t_TranId_CMD.Parameters.Add("@Prefix", SqlDbType.NVarChar, 250);
            t_TranId_CMD.Parameters.Add("@LastusedBy", SqlDbType.NVarChar, 250);
            t_TranId_CMD.Parameters.Add("@Length", SqlDbType.Int);
            t_TranId_CMD.Parameters.Add("@NextSerialNumber", SqlDbType.NVarChar, 500).Direction = ParameterDirection.Output;

            // Assigning values to the SP Parameters
            t_TranId_CMD.Parameters["@Prefix"].Value = prefix;
            t_TranId_CMD.Parameters["@LastusedBy"].Value = userId;
            t_TranId_CMD.Parameters["@Length"].Value = serialNumberLength;

            if (t_TranId_CMD.ExecuteNonQuery() > 0)
            {
                newTransactionId = t_TranId_CMD.Parameters["@NextSerialNumber"].Value.ToString();
            }

            return newTransactionId;



        }

        private bool InsertDocument()
        {
            // Flag to identify whether all operations are sucessful or not. Set to true initially which will be set to false if any error occurs
            Boolean result = true;

            // Declare four string builder objects for Insert ,Update Delete And value fields
            StringBuilder t_InsertRecord = new StringBuilder();
            StringBuilder t_UpdateRecord = new StringBuilder();
            StringBuilder t_ValueFields = new StringBuilder();
            StringBuilder t_DeleteRecord = new StringBuilder();


            string t_MasterRef = "";
            string t_CMD = "";

            Boolean t_First = false;
            Boolean t_MasterTable = true;

            Boolean t_IsNewDocument = string.IsNullOrEmpty(ActiveDocument.Tables[0].Rows[0]["RowID"].ToString()) || (Convert.ToInt64(ActiveDocument.Tables[0].Rows[0]["RowID"].ToString()) == 0);
            Boolean t_IsNewRow = false;

            t_MasterRef = ActiveDocument.Tables[0].Rows[0]["TransactionID"].ToString();
            foreach (DataTable dtTable in ActiveDocument.Tables)
            {
                t_InsertRecord.Clear();
                t_UpdateRecord.Clear();
                t_DeleteRecord.Clear();
                t_ValueFields.Clear();
                t_First = true;


                // In this section developer has tried to construct Insert update and delete queries dynamically
                t_InsertRecord.Append("Insert Into "); t_InsertRecord.Append(dtTable.TableName); t_InsertRecord.Append("(");
                t_UpdateRecord.Append("Update "); t_UpdateRecord.Append(dtTable.TableName); t_UpdateRecord.Append(" Set ");
                t_DeleteRecord.Append("Delete "); t_DeleteRecord.Append(dtTable.TableName);

                foreach (DataColumn dcColumn in dtTable.Columns)
                {
                    if (!dcColumn.ColumnName.ToUpper().Equals("ROWID"))
                    {
                        if (!t_First)
                        {
                            t_InsertRecord.Append(",");
                            t_UpdateRecord.Append(",");
                            t_ValueFields.Append(",");
                        }

                        t_InsertRecord.Append(dcColumn.ColumnName);
                        t_UpdateRecord.Append(dcColumn); t_UpdateRecord.Append(" = @"); t_UpdateRecord.Append(dcColumn);
                        t_ValueFields.Append("@" + dcColumn);

                        t_First = false;
                    }
                }

                t_InsertRecord.Append(") Values("); t_InsertRecord.Append(t_ValueFields.ToString()); t_InsertRecord.Append(")");
                t_UpdateRecord.Append(" Where TransactionID=@TransactionID And RowID=@RowID");
                t_DeleteRecord.Append(" Where TransactionID=@TransactionID And Active=0");

                // End of Dynamic construction of queries

                // Scanning each row of Current DataTable Assigning values to Insert,update & delete queries using cmd.Parameters.Add()

                foreach (DataRow drRow in dtTable.Rows)
                {
                    t_IsNewRow = (String.IsNullOrEmpty(drRow["RowID"].ToString()) || Convert.ToInt64(drRow["RowID"].ToString()) == 0) || t_IsNewDocument;

                    drRow["TransactionID"] = t_MasterRef;

                    if (t_IsNewRow)
                    {
                        t_CMD = t_InsertRecord.ToString();
                        drRow["CreatedBy"] = UserName;
                        drRow["CreatedOn"] = DateTime.Now;
                        drRow["AlteredBy"] = DBNull.Value;
                        drRow["AlteredOn"] = DBNull.Value;
                    }
                    else
                    {
                        t_CMD = t_UpdateRecord.ToString();
                        drRow["CreatedBy"] = DBNull.Value;
                        drRow["CreatedOn"] = DBNull.Value;
                        drRow["AlteredBy"] = UserName;
                        drRow["AlteredOn"] = DateTime.Now;
                    }

                    SqlCommand t_SQLCmd = new SqlCommand(t_CMD, Connection);
                    t_SQLCmd.Transaction = this.Transaction;

                    foreach (DataColumn dcColumn in dtTable.Columns)
                    {
                        switch (dcColumn.DataType.Name)
                        {
                            case "Int32": t_SQLCmd.Parameters.Add("@" + dcColumn.ColumnName, SqlDbType.Int); break;
                            case "String": t_SQLCmd.Parameters.Add("@" + dcColumn.ColumnName, SqlDbType.NVarChar); break;
                            case "DateTime": t_SQLCmd.Parameters.Add("@" + dcColumn.ColumnName, SqlDbType.DateTime); break;
                            case "Boolean": t_SQLCmd.Parameters.Add("@" + dcColumn.ColumnName, SqlDbType.Bit); break;
                            case "Decimal": t_SQLCmd.Parameters.Add("@" + dcColumn.ColumnName, SqlDbType.Decimal); break;
                            case "Double": t_SQLCmd.Parameters.Add("@" + dcColumn.ColumnName, SqlDbType.Float); break;
                            default: t_SQLCmd.Parameters.Add("@" + dcColumn.ColumnName, SqlDbType.NVarChar); break;
                        }

                        // Assignment of values to Parameters of query
                        t_SQLCmd.Parameters["@" + dcColumn.ColumnName].Value = drRow[dcColumn.ColumnName];
                    }

                    // If Execution of query fails then result should be false;
                    if (t_SQLCmd.ExecuteNonQuery() != 1)
                        result = false;
                }

                if (!t_MasterTable)
                {
                    SqlCommand t_DeleteCommand = new SqlCommand(t_DeleteRecord.ToString(), Connection);
                    t_DeleteCommand.Transaction = this.Transaction;
                    t_DeleteCommand.Parameters.Add("@TransactionID", SqlDbType.VarChar);

                    t_DeleteCommand.Parameters["@TransactionID"].Value = t_MasterRef;

                    t_DeleteCommand.ExecuteNonQuery();

                }
                t_MasterTable = false;
            }

            return result;
        }

        /// <summary>
        /// This method will Decode a Base64 string.
        /// </summary>
        /// <param name="m_enc">The String containing the characters 
        /// to be decoded.</param>
        /// <returns>A String containing the results of decoding the
        /// specified sequence of bytes.</returns>
        private static string DecodeFrom64(string m_enc)
        {
            byte[] encodedDataAsBytes =
            System.Convert.FromBase64String(m_enc);
            string returnValue =
            System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public void Dispose()
        {
            /********
             * Close Connections & Release Memory
             *******/
            if (this.Connection.State == ConnectionState.Open)
            {
                this.Connection.Close();
            }
            this.Connection = null;


        }


        #region "Decrypt Connection String"
        private static string DecryptText(string Text, string Key)
        {
            return Decrypt(Text, Key);
        }

        /// <summary>
        /// Decrypts the specified STR text.
        /// </summary>
        /// <param name="strText">The STR text.</param>
        /// <param name="sDecrKey">The s decr key.</param>
        /// <returns>Representing Decrypted Text</returns>
        /// <remarks></remarks>
        private static string Decrypt(string strText, string sDecrKey)
        {
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[strText.Length + 1];

            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }



        #endregion
    }
}
