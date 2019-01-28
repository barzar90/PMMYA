using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using DAL;

namespace BL
{
    public class GlobalBAL
    {

        #region Public variable declaration
        int iResult = 0;
        string strResult = "";
        DataSet ds;
        GlobalDAL ObjGlobalDAL = new GlobalDAL();
        #endregion

        public DataSet GetRegisterRoutesData()
        {
            try
            {
                ds = new DataSet();
                ds = ObjGlobalDAL.GetRegisterRoutesData();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;              
            }
        }

    }
}
