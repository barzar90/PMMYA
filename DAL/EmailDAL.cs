using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using System.Data.SqlClient;
using Helper;

namespace DAL
{

    public class EmailDAL
    {
        #region Public variable declaration         
        EmailSchema ObjEmailSchema = new EmailSchema();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetEmailDetails(EmailSchema ObjEmailSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@ApplicationID", SqlDbType.VarChar);
                param[0].Value = ObjEmailSchema.ApplicationID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetEmailIDDetails", param))
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
