using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class AppErrorDAL
    {
        public int SaveAppErrorLog(AppErrorSchema objapperrorschema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                                 new SqlParameter("@ErrorCode",objapperrorschema.ErrorCode == null ? (object)DBNull.Value : objapperrorschema.ErrorCode),
                                new SqlParameter("@Message",objapperrorschema.Message == null ? (object)DBNull.Value : objapperrorschema.Message),
                                new SqlParameter("@Type",objapperrorschema.Type == null ? (object)DBNull.Value : objapperrorschema.Type),
                                new SqlParameter("@StackTrace",objapperrorschema.StackTrace == null ? (object)DBNull.Value : objapperrorschema.StackTrace),
                                new SqlParameter("@InnerException",objapperrorschema.InnerException == null ? (object)DBNull.Value : objapperrorschema.InnerException),
                                new SqlParameter("@HtmlError",objapperrorschema.HtmlError == null ? (object)DBNull.Value : objapperrorschema.HtmlError),
                                new SqlParameter("@UserIp",objapperrorschema.UserIp == null ? (object)DBNull.Value : objapperrorschema.UserIp),
                                new SqlParameter("@Browser",objapperrorschema.Browser == null ? (object)DBNull.Value : objapperrorschema.Browser),
                                new SqlParameter("@BrowserVersion",objapperrorschema.BrowserVersion == null ? (object)DBNull.Value : objapperrorschema.BrowserVersion)
                        };

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "InsertErrorLog", param);
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }

        public DataSet GetErrorLogList(AppErrorSchema objapperrorschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@errorId", System.Data.SqlDbType.NVarChar);
                param[0].Value = objapperrorschema.ErrorId;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetErrorLog", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
    }
}
