using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using BL;
using DAL;
using System;
using Schema;
using System.Collections;

namespace BL
{
   public class DropDownBindBL
    {

        #region Public variable declaration
        DropdownBindDAL objdropdownBindDAL = new DropdownBindDAL();
        DataSet ds = new DataSet();
        #endregion

        public DataSet BindState(DropDownnSchema objDropDownnSchema)
        {
            try
            {
                ds = objdropdownBindDAL.BindState(objDropDownnSchema);
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


        //public static string ArrayList BindDistrict(int StateID, string langid)
        //{

        //    try
        //    {

        //        list = BindDistrict(StateID, langid);
        //        return list;
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        list = null;
        //    }
        //}



        public DataSet PopulateBankDetails(DropDownnSchema objDropDownnSchema)
        {
            try
            {
                ds = objdropdownBindDAL.BindState(objDropDownnSchema);
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
