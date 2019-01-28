using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;


namespace DAL
{
    public class CMSDAL
    {
        public DataSet GetCMSDetails(CMSSchema objCMSSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[0].Value = objCMSSchema.MenuID;
                param[1] = new SqlParameter("@LangType", SqlDbType.VarChar);
                param[1].Value = objCMSSchema.LangType;
                param[2] = new SqlParameter("@isQuickMenu", SqlDbType.Bit);
                param[2].Value = objCMSSchema.IsQuickMenu;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetCMSControl", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet GetCMSMoreDetails(CMSSchema objCMSSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];

                param[0] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[0].Value = objCMSSchema.MenuID;
                param[1] = new SqlParameter("@LangType", SqlDbType.VarChar);
                param[1].Value = objCMSSchema.LangType;
                param[2] = new SqlParameter("@isQuickMenu", SqlDbType.Bit);
                param[2].Value = objCMSSchema.IsQuickMenu;
                param[3] = new SqlParameter("@MenuContentID", SqlDbType.Int);
                param[3].Value = objCMSSchema.MenucontentID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetCMSMoreControl", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }


        public DataSet GetLeftMenuDetails(CMSSchema objCMSSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[0].Value = objCMSSchema.MenuID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetLeftMenu", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
    }
}
