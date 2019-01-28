using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Schema;
using Helper;


namespace DAL
{
    public class DAL_Errorlog
    {
        SqlConnection con;
        int inserterror;

        public int ErrorlogDl(Entity_tblErrorLog tblErrorLog)
        {
            try
            {
                con = SQLHelper.OpenConnection();

                SqlParameter[] param = new SqlParameter[9];

                param[0] = new SqlParameter("@ErrorCode", SqlDbType.VarChar);
                param[0].Value = tblErrorLog.ErrorCode;

                param[1] = new SqlParameter("@Message", SqlDbType.VarChar);
                param[1].Value = tblErrorLog.Message;

                param[2] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[2].Value = tblErrorLog.Type;

                param[3] = new SqlParameter("@StackTrace", SqlDbType.VarChar);
                param[3].Value = tblErrorLog.StackTrace;

                param[4] = new SqlParameter("@InnerException", SqlDbType.VarChar);
                param[4].Value = tblErrorLog.InnerException;

                param[5] = new SqlParameter("@HtmlError", SqlDbType.VarChar);
                param[5].Value = tblErrorLog.HtmlError;

                param[6] = new SqlParameter("@UserIp", SqlDbType.VarChar);
                param[6].Value = tblErrorLog.UserIp;

                param[7] = new SqlParameter("@Browser", SqlDbType.VarChar);
                param[7].Value = tblErrorLog.Browser;

                param[8] = new SqlParameter("@BrowserVersion", SqlDbType.VarChar);
                param[8].Value = tblErrorLog.BrowserVersion;

                //inserterror = SQLHelper.ExecuteNonQuery(con, null, CommandType.StoredProcedure, "InsertErrorLog", param);
                //inserterror = Convert.ToInt32 (SQLHelper.ExecuteScalar(con, null, "InsertErrorLog", param));

                inserterror = Convert.ToInt32(SQLHelper.ExecuteScalar(con, null, CommandType.StoredProcedure, "InsertErrorLog", param));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQLHelper.CloseConnection(con);
            }
            return inserterror;
        }
    }
}
