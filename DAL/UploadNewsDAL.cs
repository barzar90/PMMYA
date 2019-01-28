using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;
using Schema;

namespace DAL
{
    public class UploadNewsDAL
    {
        public DataSet GetUploadNews()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetUploadNews",null))
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

        public int SaveUploadNews(UploadNewsSchema obuploadnewsschema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            int result = 0;

                            if (obuploadnewsschema.ActionType == "Delete")
                            {
                                  var param = new SqlParameter[]
                                     {
                                       new SqlParameter("@ActionType",obuploadnewsschema.ActionType == null ? (object)DBNull.Value : obuploadnewsschema.ActionType),
                                       new SqlParameter("@ID",obuploadnewsschema.ID == 0 ? 0 : obuploadnewsschema.ID)
                                     };
                                result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLUploadNews", param);
                            }
                            else
                            {
                                    var param = new SqlParameter[]
                                        {
                                            new SqlParameter("@News",obuploadnewsschema.News == null ? (object)DBNull.Value : obuploadnewsschema.News),
                                             new SqlParameter("@News_LL",obuploadnewsschema.News_LL == null ? (object)DBNull.Value : obuploadnewsschema.News_LL),
                                             new SqlParameter("@News_UL",obuploadnewsschema.News_UL == null ? (object)DBNull.Value : obuploadnewsschema.News_UL),
                                             new SqlParameter("@URL",obuploadnewsschema.URL == null ? (object)DBNull.Value : obuploadnewsschema.URL),
                                             new SqlParameter("@langid",obuploadnewsschema.LangID == 0 ? 0 : obuploadnewsschema.LangID),
                                             new SqlParameter("@Is_Active",obuploadnewsschema.Is_Active == false ? Convert.ToBoolean(0) : obuploadnewsschema.Is_Active),
                                             new SqlParameter("@CreatedDate",obuploadnewsschema.CreatedDate == null ? (object)DBNull.Value : obuploadnewsschema.CreatedDate.ToString()),
                                             new SqlParameter("@IsLink",obuploadnewsschema.IsLink == false ? Convert.ToBoolean(0) : obuploadnewsschema.IsLink),
                                             new SqlParameter("@ActionType",obuploadnewsschema.ActionType == null ? (object)DBNull.Value : obuploadnewsschema.ActionType),
                                             new SqlParameter("@ID",obuploadnewsschema.ID == 0 ? 0 : obuploadnewsschema.ID),
                                             new SqlParameter("@IsNew",obuploadnewsschema.IsNew == false ? Convert.ToBoolean(0) : obuploadnewsschema.IsNew)
                                        
                                        };

                                result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLUploadNews", param);
                            }                     
                            if (result == 1)
                            {
                                objTran.Commit();
                                return result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return 0;
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return 0;
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return 0;
            }
            finally
            {

            }
        }


        public DataSet GetNews(UploadNewsSchema obuploadnewsschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                var param = new SqlParameter[]
                           {
                               new SqlParameter("@Para",obuploadnewsschema.Para == null ? (object)DBNull.Value : obuploadnewsschema.Para),
                               new SqlParameter("@Search",obuploadnewsschema.Search == null ? (object)DBNull.Value : obuploadnewsschema.Search),
                             };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_Getnews", param))
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
