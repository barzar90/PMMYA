using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema;
using DAL;

namespace BL
{
   

    public class EmailBL
    {
        #region Public variable declaration
        EmailDAL ObjEmailDAL = new EmailDAL();
        EmailSchema ObjEmailSchema = new EmailSchema();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetEmailDetails(EmailSchema ObjEmailSchema)
        {
            try
            {
                ds = ObjEmailDAL.GetEmailDetails(ObjEmailSchema);
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
