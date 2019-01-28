using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;
namespace DAL
{
    public class SMSDAL
    {
        public void InsertSMSLog(string MobileNo, string Status, string ServerResponse, string Error)
        {
            try
            {
                SqlConnection objConn = SQLHelper.OpenConnection();
                try
                {
                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                    param[0].Value = MobileNo;
                    param[1] = new SqlParameter("@Status", SqlDbType.VarChar);
                    param[1].Value = Status;
                    param[2] = new SqlParameter("@ServerResponse", SqlDbType.VarChar);
                    param[2].Value = ServerResponse;
                    param[3] = new SqlParameter("@ErrorText", SqlDbType.VarChar);
                    param[3].Value = Error;

                    SQLHelper.ExecuteNonQuery(objConn, null, CommandType.StoredProcedure, "Usp_InsertSMSLog", param);


                }
                catch (Exception ex)
                {

                }
                finally
                {
                    SQLHelper.CloseConnection(objConn);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
