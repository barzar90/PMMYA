using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Schema;
using Helper;
using System.Configuration;

namespace DAL
{
    public class GlobalDAL
    {
        #region Public variable declaration
        DataSet ds;
        #endregion

        public DataSet GetRegisterRoutesData()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[0];

                using (ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspGetRegisterRouteData", null))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {                
                throw ex;                
            }
            finally
            {            
                SQLHelper.CloseConnection(objConn);
                ds = null;
            }
        }


       
    }
}
