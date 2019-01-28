
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using Schema;

namespace DAL
{
    public class ContactUsDAL
    {
        public DataSet GetDPODetails(ContactUsSchema ObjContactUsSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@LangID", SqlDbType.Int);
                param[0].Value = ObjContactUsSchema.Langid;
               
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetDPODetails", param))
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
