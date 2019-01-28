using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using DAL;
using System.Data;

namespace BL
{
  public class LoanApplicationFormBL
    {

        #region Public variable declaration
        LoanApplicationFormDAL objLoanApplicationFormDAL = new LoanApplicationFormDAL();
        DataSet ds = new DataSet();
        #endregion

        public DataSet SearchDetails(LoanApplicatinFormSchema objLoanApplicatinFormSchema)
        {
            try
            {
                ds = objLoanApplicationFormDAL.GetDetails(objLoanApplicatinFormSchema);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }
    }
}
