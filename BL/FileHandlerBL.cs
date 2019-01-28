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
    public class FileHandlerBL
    {
        #region Public variable declaration
        FileHandlerDAL objfilehanlerDAL = new FileHandlerDAL();
        DataSet ds = new DataSet();
        
        #endregion

        public DataSet GetUploadFileList(FileHandlerSchema objFileHandlerSchema)
        {
            try
            {
                ds = objfilehanlerDAL.GetUploadFile(objFileHandlerSchema);
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

        public DataSet DisplayFileList(FileHandlerSchema objFileHandlerSchema)
        {
            try
            {
                ds = objfilehanlerDAL.DisplayFile(objFileHandlerSchema);
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
