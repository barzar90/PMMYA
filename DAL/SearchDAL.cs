using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class SearchDAL
    {

        #region Public variable declaration
        //DataSet ds;
        #endregion


        public DataSet SearchDetails(SearchSchema objSearchSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                var param = new SqlParameter[]
                            {
                             new SqlParameter("@LangID",objSearchSchema.LangID== 0 ? 0  : objSearchSchema.LangID),
                             new SqlParameter("@Keyword",objSearchSchema.Keyword== null ? (object)DBNull.Value : objSearchSchema.Keyword),
                        };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "spSearchSite", param))
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
