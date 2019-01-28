using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class AuditTrailDAL
    {

        public DataSet GetAuditTrail()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetUserSession", null))
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
