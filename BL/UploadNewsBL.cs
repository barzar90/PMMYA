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
    public class UploadNewsBL
    {
        #region Public variable declaration
        UploadNewsDAL objuploadnewsDAL = new UploadNewsDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetUploadNewsDetails()
        {
            try
            {
                ds = objuploadnewsDAL.GetUploadNews();
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

        public int SaveUploadNewsDetails(UploadNewsSchema objuploadnewsSchema)
        {
            try
            {
                result = objuploadnewsDAL.SaveUploadNews(objuploadnewsSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetNews(UploadNewsSchema objuploadnewsSchema)
        {
            try
            {
                ds = objuploadnewsDAL.GetNews(objuploadnewsSchema);
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
