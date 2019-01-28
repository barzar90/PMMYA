using DAL;
using System;
using System.Data;

namespace BL
{
    public class AuditTrailBL
    {
        #region Public variable declaration
        AuditTrailDAL objAuditTrailDAL = new AuditTrailDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetAuditTrail()
        {
            try
            {
                ds = objAuditTrailDAL.GetAuditTrail();
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
