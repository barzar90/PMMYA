using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class UserDAL
    {
        DataSet ds;
        SqlConnection con;
        int returnval;
        SqlTransaction objTran;

        public int insertUserData(UserShema objUserShema)
        {
            
            try
            {
                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {                       
                            var param = new SqlParameter[]
                            {
                             new SqlParameter("@Name",objUserShema.Name == null ? (object)DBNull.Value: objUserShema.Name),
                             new SqlParameter("@MobileNo",objUserShema.Mobile == null ? (object)DBNull.Value: objUserShema.Mobile),
                             //new SqlParameter("@LoanType",objUserShema.Loantype == 0 ? 0 : objUserShema.Loantype),
                             //new SqlParameter("@Amount",objUserShema.Amount == 0 ? 0 : objUserShema.Amount),
                             new SqlParameter("@EmailID",objUserShema.Email == null ? (object)DBNull.Value : objUserShema.Email),
                             new SqlParameter("@BusPurpose ",objUserShema.Buspurpose == 0 ? 0 : objUserShema.Buspurpose),
                             new SqlParameter("@Applicant_SessionId",objUserShema.Applicant_SessionId == null ? (object)DBNull.Value: objUserShema.Applicant_SessionId),
                            };
                            int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "sp_InsertUSerData", param);
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

        public int CheckDuplicate(UserShema objUserShema)
        {

            try
            {
                using (SqlConnection objConn = SQLHelper.OpenConnection())
                {
                    using (SqlTransaction objTran = objConn.BeginTransaction())
                    {
                        var param = new SqlParameter[]
                        {   
                             new SqlParameter("@Mobile",objUserShema.Mobile == null ? (object)DBNull.Value: objUserShema.Mobile),
                             new SqlParameter("@OutValue",  SqlDbType.Int, 2, ParameterDirection.Output, true, 0, 0, "OutValue", DataRowVersion.Current,"")
                        };

                        int result = SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_CheckMobile", param);
                        int count = Convert.ToInt32(param[1].Value);
                        return count;
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
