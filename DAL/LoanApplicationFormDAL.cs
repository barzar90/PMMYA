using Helper;
using Schema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class LoanApplicationFormDAL
    {




        public DataSet GetDetails(LoanApplicatinFormSchema objLoanApplicatinFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                var param = new SqlParameter[]
                            {
                             new SqlParameter("@Application_ID",objLoanApplicatinFormSchema.Application_ID),

                        };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "SP_GetdetailsfromPMMY_APP_LOAN_FORM", param))
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
