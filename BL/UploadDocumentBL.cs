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
    public class UploadDocumentBL
    {
        #region Public variable declaration
        UploadDocumentDAL objUploadDocumentDAL = new UploadDocumentDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetUploadPDFDetails(UploadDocumentSchema objUploadDocumentSchema)
        {
            try
            {
                ds = objUploadDocumentDAL.GetUploadPDFDetails(objUploadDocumentSchema);
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

        public int DMLUploadPdf(UploadDocumentSchema objUploadDocumentSchema)
        {
            try
            {
                result = objUploadDocumentDAL.DMLUploadPdf(objUploadDocumentSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetUploadDocumentDetails(UploadDocumentSchema objUploadDocumentSchema)
        {
            try
            {
                ds = objUploadDocumentDAL.GetUploadDocumentDetails(objUploadDocumentSchema);
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

        public int DMLUploadDocument(UploadDocumentSchema objUploadDocumentSchema)
        {
            try
            {
                result = objUploadDocumentDAL.DMLUploadDocument(objUploadDocumentSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
}
