using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using BL;
using DAL;
using System;
using Schema;

namespace BL
{
    public class CMSBL
    {

        #region Public variable declaration
        CMSDAL objCMSDAL = new CMSDAL();
        DataSet ds = new DataSet();
        #endregion

        public DataSet GetCMSDetails(CMSSchema objCMSSchema)
        {
            try
            {
                ds = objCMSDAL.GetCMSDetails(objCMSSchema);
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

        public DataSet GetCMSMoreDetails(CMSSchema objCMSSchema)
        {
            try
            {
                ds = objCMSDAL.GetCMSMoreDetails(objCMSSchema);
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

        public DataSet GetLeftMenuDetails(CMSSchema objCMSSchema)
        {
            try
            {
                ds = objCMSDAL.GetLeftMenuDetails(objCMSSchema);
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
