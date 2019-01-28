using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class FileHandlerDAL
    {
        public DataSet GetUploadFile(FileHandlerSchema objfilehandlerschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowId", System.Data.SqlDbType.Int);
                param[0].Value = objfilehandlerschema.RowID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_ViewFile", param))
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

        public DataSet DisplayFile(FileHandlerSchema objfilehandlerschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@RowId", System.Data.SqlDbType.Int);
                param[0].Value = objfilehandlerschema.RowID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_DisplayFile", param))
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
