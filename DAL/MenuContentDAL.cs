using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class MenuContentDAL
    {

        public DataSet GetMenuContentDetails(MenuContentSchema objmenucontentschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MenuContentID", SqlDbType.VarChar);
                param[0].Value = objmenucontentschema.MenuContentID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetMenucontent", param))
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

        public int SaveMenuContentDeatails(MenuContentSchema objmenucontentschema)
        {
            try
            {

                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        try
                        {
                            var param = new SqlParameter[]
                            {
                                new SqlParameter("@MenuID",objmenucontentschema.MenuID == 0 ? 0 : objmenucontentschema.MenuID),
                                new SqlParameter("@MenuContentID",objmenucontentschema.MenuContentID == 0 ? 0 : objmenucontentschema.MenuContentID),
                                new SqlParameter("@PageTitle",objmenucontentschema.PageTitle == null ? (object)DBNull.Value : objmenucontentschema.PageTitle),
                                new SqlParameter("@PageTitle_LL",objmenucontentschema.PageTitle_LL == null ? (object)DBNull.Value : objmenucontentschema.PageTitle_LL),
                                new SqlParameter("@PageTitle_UL",objmenucontentschema.PageTitle_UL == null ? (object)DBNull.Value : objmenucontentschema.PageTitle_UL),
                                new SqlParameter("@ShortDescription",objmenucontentschema.ShortDescription == null ? (object)DBNull.Value : objmenucontentschema.ShortDescription),
                                new SqlParameter("@ShortDescription_LL",objmenucontentschema.ShortDescription_LL == null ? (object)DBNull.Value : objmenucontentschema.ShortDescription_LL),
                                new SqlParameter("@ShortDescription_UL",objmenucontentschema.ShortDescription_UL == null ? (object)DBNull.Value : objmenucontentschema.ShortDescription_UL),
                                new SqlParameter("@LongDescription",objmenucontentschema.LongDescription == null ? (object)DBNull.Value : objmenucontentschema.LongDescription),
                                new SqlParameter("@LongDescription_LL",objmenucontentschema.LongDescription_LL == null ? (object)DBNull.Value : objmenucontentschema.LongDescription_LL),
                                new SqlParameter("@LongDescription_UL",objmenucontentschema.LongDescription_UL == null ? (object)DBNull.Value : objmenucontentschema.LongDescription_UL),
                                new SqlParameter("@SequenceNo",objmenucontentschema.SequenceNo == 0 ? 0 : objmenucontentschema.SequenceNo),
                                new SqlParameter("@IsApprove",objmenucontentschema.IsApprove == false ? Convert.ToBoolean(0) : objmenucontentschema.IsApprove),
                                new SqlParameter("@CreatedBy",objmenucontentschema.CreatedBy == null ? (object)DBNull.Value : objmenucontentschema.CreatedBy),
                                new SqlParameter("@UpdatedBy",objmenucontentschema.UpdatedBy == null ? (object)DBNull.Value : objmenucontentschema.UpdatedBy),
                                new SqlParameter("@IsActive",objmenucontentschema.IsActive == false ? Convert.ToBoolean(0) : objmenucontentschema.IsActive),
                                new SqlParameter("@ActionType",objmenucontentschema.ActionType == null ? (object)DBNull.Value : objmenucontentschema.ActionType)
                        };

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "usp_Addupdatemenucontent", param);
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


        public DataSet GetMenuContentList(MenuContentSchema objmenucontentschema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@MenuID", SqlDbType.VarChar);
                param[0].Value = objmenucontentschema.MenuID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetMenuContentList", param))
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

        public int DMLMenuContentList(MenuContentSchema objmenucontentschema)
        {
            try
            {
                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                            var param = new SqlParameter[]
                            {
                                new SqlParameter("@MenuContentID",objmenucontentschema.MenuContentID == 0 ? 0 : objmenucontentschema.MenuContentID)                           
                             };

                            int result = SQLHelper.ExecuteNonQuery(objConn, null, CommandType.StoredProcedure, "Usp_DMLMenuContentList", param);
                            if (result == 1)
                            {                             
                                return result;
                            }
                            else
                            {
                                return 0;
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
    }
}
