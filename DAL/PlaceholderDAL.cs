using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class PlaceholderDAL
    {

        public DataSet GetPlaceHolderContentDetails(PlaceHolderSchema objPlaceHolderSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@PlaceHolderID", SqlDbType.Int);
                param[0].Value = objPlaceHolderSchema.PlaceholderId;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetPlaceHolderContent", param))
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

        public int SavePlaceHolderContentDeatails(PlaceHolderSchema objPlaceHolderSchema)
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
                                new SqlParameter("@PlaceHolderID",objPlaceHolderSchema.PlaceholderId == 0 ? 0 : objPlaceHolderSchema.PlaceholderId),
                                new SqlParameter("@ActionType",objPlaceHolderSchema.ActionType == null ? (object)DBNull.Value : objPlaceHolderSchema.ActionType),
                                new SqlParameter("@PlaceHolderName",objPlaceHolderSchema.PlaceHolderName == null ? (object)DBNull.Value : objPlaceHolderSchema.PlaceHolderName),
                                new SqlParameter("@ShortDescription",objPlaceHolderSchema.ShortDescription == null ? (object)DBNull.Value : objPlaceHolderSchema.ShortDescription),
                                new SqlParameter("@ShortDescription_LL",objPlaceHolderSchema.ShortDescription_LL == null ? (object)DBNull.Value : objPlaceHolderSchema.ShortDescription_LL),
                                new SqlParameter("@ShortDescription_UL",objPlaceHolderSchema.ShortDescription_UL == null ? (object)DBNull.Value : objPlaceHolderSchema.ShortDescription_UL),
                                new SqlParameter("@UpdatedBy",objPlaceHolderSchema.UpdatedBy == null ? (object)DBNull.Value : objPlaceHolderSchema.UpdatedBy),
                                new SqlParameter("@CreatedBy",objPlaceHolderSchema.CreatedBy == null ? (object)DBNull.Value : objPlaceHolderSchema.CreatedBy),
                                new SqlParameter("@IsApprove",objPlaceHolderSchema.IsApprove == false ? Convert.ToBoolean(0) : objPlaceHolderSchema.IsApprove),
                                new SqlParameter("@IsActive",objPlaceHolderSchema.IsActive == false ? Convert.ToBoolean(0) : objPlaceHolderSchema.IsActive),

                        };

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_DMLPlaceHolderContent", param);
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

        public DataSet GetPlaceHolderList()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_GetPlaceHolderList", null))
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

        public int DMLPlaceHolderList(PlaceHolderSchema objPlaceHolderSchema)
        {
            try
            {
                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    var param = new SqlParameter[]
                    {
                                new SqlParameter("PlaceHolderID",objPlaceHolderSchema.PlaceholderId == 0 ? 0 : objPlaceHolderSchema.PlaceholderId)
                     };

                    int result = SQLHelper.ExecuteNonQuery(objConn, null, CommandType.StoredProcedure, "Usp_DMLPlaceHolderList", param);
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
