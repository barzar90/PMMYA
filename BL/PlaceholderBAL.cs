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
    public class PlaceholderBAL
    {
        #region Public variable declaration
        PlaceholderDAL objplaceholderDAL = new PlaceholderDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetPlaceHolderContentDetails(PlaceHolderSchema objPlaceHolderSchema)
        {
            try
            {
                ds = objplaceholderDAL.GetPlaceHolderContentDetails(objPlaceHolderSchema);
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


        public int SavePlaceHolderContentDeatails(PlaceHolderSchema objPlaceHolderSchema)
        {
            try
            {
                result = objplaceholderDAL.SavePlaceHolderContentDeatails(objPlaceHolderSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataSet GetPlaceHolderList()
        {
            try
            {
                ds = objplaceholderDAL.GetPlaceHolderList();
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

        public int DMLPlaceHolderList(PlaceHolderSchema objPlaceHolderSchema)
        {
            try
            {
                result = objplaceholderDAL.DMLPlaceHolderList(objPlaceHolderSchema);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
