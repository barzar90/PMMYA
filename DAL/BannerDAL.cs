using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class BannerDAL
    {


        public DataSet GetBannerContentDetails(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FileType", SqlDbType.VarChar);
                param[0].Value = objBannerControlSchema.FileType;
                param[1] = new SqlParameter("@LangType", SqlDbType.VarChar);
                param[1].Value = objBannerControlSchema.LangType;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetBannerControl", param))
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

        public DataSet GetKeyPersonDetails(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@FileType", SqlDbType.VarChar);
                param[0].Value = objBannerControlSchema.FileType;
                param[1] = new SqlParameter("@LangType", SqlDbType.VarChar);
                param[1].Value = objBannerControlSchema.LangType;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspKeyPerson", param))
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

        public DataSet GetLastReviewDate(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ContentID", SqlDbType.Int);
                param[0].Value = objBannerControlSchema.ContentID;
                param[1] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[1].Value = objBannerControlSchema.MenuID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_LastReviewDateControl", param))
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

        public DataSet GetNews(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@NewsCount", SqlDbType.Int);
                param[0].Value = objBannerControlSchema.NewsCount;
                param[1] = new SqlParameter("@LangId", SqlDbType.Int);
                param[1].Value = objBannerControlSchema.LangId;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "UspNewsControl", param))
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

        public DataSet GetMarquee(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Para", SqlDbType.Int);
                param[0].Value = objBannerControlSchema.NewsCount;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetForMarquee", param))
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


        public DataSet GetUCBreadCrumData(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[0].Value = objBannerControlSchema.MenuID;
                param[1] = new SqlParameter("@ContentID", SqlDbType.Int);
                param[1].Value = objBannerControlSchema.ContentID;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "procGetBreadCrumData", param))
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

        public DataSet GetUCBreadCrumDataforQuickMenu(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MenuID", SqlDbType.Int);
                param[0].Value = objBannerControlSchema.MenuID;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "procGetBreadCrumofQuickMenuData", param))
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

        public DataSet GetVisitorCount(BannerControlSchema objBannerControlSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar);
                param[0].Value = objBannerControlSchema.UserName;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "SP_VISITORCOUNT", param))
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
