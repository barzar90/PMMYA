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
    public class SearchBAL
    {
        #region Public variable declaration
        SearchDAL objSearchDAL = new SearchDAL();
        DataSet ds = new DataSet();
        #endregion

        public DataSet SearchDetails(SearchSchema objSearchSchema)
        {
            try
            {
                ds = objSearchDAL.SearchDetails(objSearchSchema);
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
