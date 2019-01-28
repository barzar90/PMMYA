using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;


namespace DAL
{
    public class FeedbackDAL
    {
        SqlConnection conn;
        SqlTransaction objTran;
        Int64 intCount;

        //public Int64 SaveFeedback(Feedback_Schema objFeedback_Schema)
        //{
        //    try
        //    {
        //        conn = SQLHelper.OpenConnection();
        //        objTran = conn.BeginTransaction();

        //        SqlParameter[] cmmParameters = new SqlParameter[6];
        //        cmmParameters[0] = new SqlParameter("@Feedback_ID", SqlDbType.BigInt);
        //        cmmParameters[0].Value = objFeedback_Schema.Feedback_ID;
        //        cmmParameters[0].Direction = ParameterDirection.InputOutput;
        //        cmmParameters[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
        //        cmmParameters[1].Value = objFeedback_Schema.Name;
        //        cmmParameters[2] = new SqlParameter("@Mobile", SqlDbType.VarChar);
        //        cmmParameters[2].Value = objFeedback_Schema.Mobile;
        //        cmmParameters[3] = new SqlParameter("@Email_ID", SqlDbType.VarChar);
        //        cmmParameters[3].Value = objFeedback_Schema.Email_ID;
        //        cmmParameters[4] = new SqlParameter("@Feedback", SqlDbType.NVarChar);
        //        cmmParameters[4].Value = objFeedback_Schema.Feedback;
        //        cmmParameters[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        //        cmmParameters[5].Value = objFeedback_Schema.CreatedOn.ToString("dd MMM, yyyy");

        //        intCount = SQLHelper.ExecuteNonQuery(conn, objTran, CommandType.StoredProcedure, "spFeedbackAdd", cmmParameters);
        //        foreach (SqlParameter param in cmmParameters)
        //        {
        //            if (param.ParameterName == "@Feedback_ID")
        //            {
        //                intCount = (Int64)param.Value;
        //                break;
        //            }
        //        }
        //        objTran.Commit();

        //        return intCount;
        //    }
        //    catch (Exception)
        //    {
        //        objTran.Rollback();
        //        return 0;
        //    }
        //    finally
        //    {
        //        SQLHelper.CloseConnection(conn);
        //        intCount = 0;
        //    }
        //}

        public int SaveFeedbackDeatails(FeddbackSchema objFeedback_Schema)
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
                             new SqlParameter("@Name",objFeedback_Schema.Name== null ? (object)DBNull.Value : objFeedback_Schema.Name),
                             new SqlParameter("@contact",objFeedback_Schema.Contact == null ? (object)DBNull.Value : objFeedback_Schema.Contact),
                             new SqlParameter("@Subject",objFeedback_Schema.Subject == null ? (object)DBNull.Value : objFeedback_Schema.Subject),
                             new SqlParameter("@Email",objFeedback_Schema.Email == null ? (object)DBNull.Value : objFeedback_Schema.Email),
                             new SqlParameter("@Message",objFeedback_Schema.Message == null ? (object)DBNull.Value : objFeedback_Schema.Message),
                             new SqlParameter("@LangID",objFeedback_Schema.Langid == 0 ? 0 : objFeedback_Schema.Langid),
                             new SqlParameter("@districtID",objFeedback_Schema.Districtid == 0 ? 0 : objFeedback_Schema.Districtid)
                        };

                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "[Usp_DMLFeedbactDetails]", param);
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


        public DataSet GetDistrict(FeddbackSchema objFeedback_Schema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Langid", SqlDbType.Int);
                param[0].Value = objFeedback_Schema.Langid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetDistrict", param))
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


        public DataSet GetDPOEmail(FeddbackSchema objFeedback_Schema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@DistrictId", SqlDbType.Int);
                param[0].Value = objFeedback_Schema.Districtid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetDPOEmail", param))
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


        public DataSet GetComplaintsDetails()
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
               

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetComplaintDetails", null))
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
