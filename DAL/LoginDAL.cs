using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class LoginDAL
    {
        DataSet ds;
        SqlConnection login_conn;
        int returnval;
        SqlTransaction objTran;
      
             
        public DataSet CheckUsername(LoginSchema objLoginSchema)
        {
            try
            {
                
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                string user_names = "select UserID,PasswordChanged,Password,Attempt from UserMaster where username='" + objLoginSchema.UserName.ToString() + "' and IsActive='1'";
                ds = HelperCls.ExecuteDataset(login_conn, null, CommandType.Text, user_names);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                HelperCls.CloseConnection(login_conn);
                ds = null;
            }
        }
        public DataSet CheckUsernameforchangepassword(LoginSchema objLoginSchema)
        {
            try
            {
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                string user_names = "select UserID,PasswordChanged,Password,Attempt from UserMaster where userId='" + objLoginSchema.UserID.ToString() + "' and IsActive='1'";
                ds = HelperCls.ExecuteDataset(login_conn, null, CommandType.Text, user_names);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                HelperCls.CloseConnection(login_conn);
                ds = null;
            }
        }
        public DataSet GetUrl(LoginSchema objLoginSchema)
        {
            try
            {
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                string user_names = "select UserTypeUrl from UserType,UserMaster where UserType.UsertypeID=UserMaster.UserTypeID and UserMaster.UserID='" + objLoginSchema.UserID + "'";
                ds = HelperCls.ExecuteDataset(login_conn, null, CommandType.Text, user_names);
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                HelperCls.CloseConnection(login_conn);
                ds = null;
            }
        }
        public int insertSession(LoginSchema objLoginSchema)
        {
            try
            {
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                objTran = login_conn.BeginTransaction();
                string user_names = "insert into UserSession ([UserID],[SessionID],[LoggedInAt],[LoggedFrom]) values(CAST('" + objLoginSchema.UserID + "'as uniqueidentifier),'" + objLoginSchema.SessionID + "',GetDate(),'" + objLoginSchema.IPAddress + "')";
                returnval = HelperCls.ExecuteNonQuery(login_conn, objTran, CommandType.Text, user_names);

                return returnval;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                objTran.Commit();
                HelperCls.CloseConnection(login_conn);
                returnval = 0;
            }
        }
        public int LogoutSession(string str)
        {
            try
            {
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                objTran = login_conn.BeginTransaction();
                string user_names = "update UserSession set LoggedOutAt=GetDate() where SessionID='" + str + "'";
                returnval = HelperCls.ExecuteNonQuery(login_conn, objTran, CommandType.Text, user_names);

                return returnval;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                objTran.Commit();
                HelperCls.CloseConnection(login_conn);
                returnval = 0;
            }
        }
        public int ForceChangePasswordDAL(LoginSchema objLoginSchmema)
        {
            try
            {
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                objTran = login_conn.BeginTransaction();
                string user_names = "update UserMaster set Password='" + objLoginSchmema.ChangedPassword + "',PasswordChanged='1' where UserID='" + objLoginSchmema.UserID + "'  COLLATE SQL_Latin1_General_CP1_CS_AS";
                returnval = HelperCls.ExecuteNonQuery(login_conn, objTran, CommandType.Text, user_names);

                return returnval;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                objTran.Commit();
                HelperCls.CloseConnection(login_conn);
                returnval = 0;
            }
        }
        public DataSet GetEmailIDbyUserID(LoginSchema objLoginSchmema)
        {
            try
            {
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                objTran = login_conn.BeginTransaction();
                string user_names = " Select UM.EmailId as EmailId,UM.MobileNo as MobileNo,UM.UserID as UserID,UM.UsertypeID as UsertypeID, " +
                " UM.Username as UserName,UM.Password as UPassword,PasswordChanged,IsActive,IsLoggedin from UserMaster UM inner join EmployeeMaster EM on UM.UserID=EM.UserID " +

                " where UM.EmailId='" + objLoginSchmema.EmailId1 + "' ";
                ds = HelperCls.ExecuteDataset(login_conn, objTran, CommandType.Text, user_names);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objTran.Commit();
                HelperCls.CloseConnection(login_conn);
                ds = null;
            }
        }
        public DataSet GetEmailIDbyEmailID(LoginSchema objLoginSchmema)
        {
            try
            {
                ds = new DataSet();
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                StringBuilder var1 = new StringBuilder();
                SqlParameter[] _param = new SqlParameter[4];
                _param[0] = new SqlParameter("@EmailID", SqlDbType.VarChar);
                _param[0].Value = objLoginSchmema.EmailId1;

                _param[1] = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
                _param[1].Value = DBNull.Value;

                _param[2] = new SqlParameter("@QueryNo", SqlDbType.Int);
                _param[2].Value = 1;

                _param[3] = new SqlParameter("@ForgetPasswordToken", SqlDbType.VarChar);
                _param[3].Value = "ForgetPAsswordToken";


                SqlCommand command = new SqlCommand();

                command.CommandText = "sp_GetUserDetailsForForgotPassword";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                ds = HelperCls.ExecuteDataset(login_conn, null, command.CommandType, command.CommandText, _param);

                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                HelperCls.CloseConnection(login_conn);
                ds = null;
            }
        }
        public string SetForgotPassword(LoginSchema objLoginSchema)
        {
            try
            {
                ds = new DataSet();
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                StringBuilder var1 = new StringBuilder();
                SqlParameter[] _param = new SqlParameter[4];
                _param[0] = new SqlParameter("@EmailID", SqlDbType.VarChar);
                _param[0].Value = objLoginSchema.EmailId1;

                _param[1] = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
                _param[1].Value = new Guid(objLoginSchema.UserID);

                _param[2] = new SqlParameter("@QueryNo", SqlDbType.Int);
                _param[2].Value = 2;

                _param[3] = new SqlParameter("@ForgetPasswordToken", SqlDbType.VarChar);
                _param[3].Value = "ForgetPAsswordToken";

                SqlCommand command = new SqlCommand();

                command.CommandText = "sp_GetUserDetailsForForgotPassword";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                ds = HelperCls.ExecuteDataset(login_conn, null, CommandType.StoredProcedure, command.CommandText, _param);
                string result = ds.Tables[0].Rows[0][0].ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                HelperCls.CloseConnection(login_conn);

                // login_conn.Dispose();
            }
        }
        public DataSet CheckForgotPwdToken(LoginSchema objLoginSchmema)
        {
            try
            {
                ds = new DataSet();
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                StringBuilder var1 = new StringBuilder();
                SqlParameter[] _param = new SqlParameter[4];
                _param[0] = new SqlParameter("@EmailID", SqlDbType.VarChar);
                _param[0].Value = objLoginSchmema.EmailId1;

                _param[1] = new SqlParameter("@UserID", SqlDbType.VarChar);
                _param[1].Value = objLoginSchmema.UserID;

                _param[2] = new SqlParameter("@QueryNo", SqlDbType.Int);
                _param[2].Value = 3;

                _param[3] = new SqlParameter("@ForgetPasswordToken", SqlDbType.VarChar);
                _param[3].Value = "ForgetPAsswordToken";


                SqlCommand command = new SqlCommand();

                command.CommandText = "sp_GetUserDetailsForForgotPassword";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                ds = HelperCls.ExecuteDataset(login_conn, null, command.CommandType, command.CommandText, _param);

                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                HelperCls.CloseConnection(login_conn);
                ds = null;
            }
        }
        public int ChangeResetPasswordSVT(LoginSchema objLoginSchema)
        {
            try
            {
                ds = new DataSet();
                login_conn = new SqlConnection();
                login_conn = HelperCls.OpenConnection();
                StringBuilder var1 = new StringBuilder();
                SqlParameter[] _param = new SqlParameter[3];
                _param[0] = new SqlParameter("@EmailID", SqlDbType.VarChar);
                _param[0].Value = objLoginSchema.EmailId1;

                _param[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                _param[1].Value = objLoginSchema.Password;

                _param[2] = new SqlParameter("@ForgetPasswordToken", SqlDbType.VarChar);
                _param[2].Value = objLoginSchema.ForgotPasswordToken;

                SqlCommand command = new SqlCommand();

                command.CommandText = "Proc_AdminUserRegistration";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                int result = HelperCls.ExecuteNonQuery(login_conn, null, CommandType.StoredProcedure, command.CommandText, _param);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                login_conn.Close();

                login_conn.Dispose();
            }
        }
        public int IncreaseAttemptCount(LoginSchema objLoginSchema)
        {
            login_conn = new SqlConnection();
            login_conn = HelperCls.OpenConnection();
            SqlParameter[] _param = new SqlParameter[2];
            try
            {

                //_param[0] = new SqlParameter("@UserID", SqlDbType.VarChar);
                //_param[0].Value = Convert.ToString(objLoginSchema.UserID);

                _param[0] = new SqlParameter("@QueryNo", SqlDbType.Int);
                _param[0].Value = (objLoginSchema.QueryNo);

                _param[1] = new SqlParameter("@UserName", SqlDbType.VarChar);
                _param[1].Value = Convert.ToString(objLoginSchema.UserName);
                _param[1].Size = 50;

                SqlCommand command = new SqlCommand();
                command.CommandText = "SP_GetLogin";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                int result = HelperCls.ExecuteNonQuery(login_conn, null, CommandType.StoredProcedure, command.CommandText, _param);
                return result;

            }

            catch (Exception Ex)
            {
                throw Ex;

            }
            finally
            {
                login_conn.Close();

                login_conn.Dispose();
            }
        }

        #region Login Control
        // Added By KP on 18-05-2018//
        public string GetUserPassword(LoginSchema objLoginSchema)
        {
            try
            {
                ds = new DataSet();
                string password;
                login_conn = new SqlConnection();
                login_conn = SQLHelper.OpenConnection();
               
                SqlParameter[] _param = new SqlParameter[1];
                _param[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
                _param[0].Value = objLoginSchema.UserName;
                _param[0].Size = 50;

                SqlCommand command = new SqlCommand();

                command.CommandText = "[uspGetUserPassword]";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;

                password = HelperCls.ExecuteScalar(login_conn, null, command.CommandType, command.CommandText, _param).ToString();
                            

                return password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQLHelper.CloseConnection(login_conn);

                 login_conn.Dispose();
            }
        }

        //added Mahesh Patel on 27-12-2018
        public int GetUserPasswordLDM(LoginSchema objLoginSchema)
        {
            try
            {
                ds = new DataSet();
                int password;
                login_conn = new SqlConnection();
                login_conn = SQLHelper.OpenConnection();

                SqlParameter[] _param = new SqlParameter[1];
                _param[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
                _param[0].Value = objLoginSchema.UserName;
                _param[0].Size = 50;

                SqlCommand command = new SqlCommand();

                command.CommandText = "[uspGetUserLDMPassword]";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;

                password = Convert.ToInt32(HelperCls.ExecuteScalar(login_conn, null, command.CommandType, command.CommandText, _param));

                return password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SQLHelper.CloseConnection(login_conn);

                login_conn.Dispose();
            }
        }

        public int UpdateUserPassword(LoginSchema objLoginSchema)
        {
            login_conn = new SqlConnection();
            login_conn = SQLHelper.OpenConnection();
            SqlParameter[] _param = new SqlParameter[2];
            try
            {
                _param[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
                _param[0].Value = (objLoginSchema.UserName);

                _param[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                _param[1].Value = Convert.ToString(objLoginSchema.Password);

                SqlCommand command = new SqlCommand();
                command.CommandText = "uspUpdateUserPassword";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                int result = HelperCls.ExecuteNonQuery(login_conn, null, CommandType.StoredProcedure, command.CommandText, _param);
                return result;

            }

            catch (Exception Ex)
            {
                throw Ex;

            }
            finally
            {
                login_conn.Close();

                login_conn.Dispose();
            }
        }

        public int InsertLog(LoginSchema objLoginSchema)
        {
            login_conn = new SqlConnection();
            login_conn = SQLHelper.OpenConnection();
            SqlParameter[] _param = new SqlParameter[3];
            try
            {
                _param[0] = new SqlParameter("@UserSessionID", SqlDbType.UniqueIdentifier);
                _param[0].Value = (objLoginSchema.Usersessionid);

                _param[1] = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
                _param[1].Value = objLoginSchema.User_id;

                _param[2] = new SqlParameter("@IPSecurities", SqlDbType.VarChar);
                _param[2].Value = Convert.ToString(objLoginSchema.IPAddress);

                SqlCommand command = new SqlCommand();
                command.CommandText = "uspInsertUserLog";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                int result = HelperCls.ExecuteNonQuery(login_conn, null, CommandType.StoredProcedure, command.CommandText, _param);
                return result;

            }

            catch (Exception Ex)
            {
                throw Ex;

            }
            finally
            {
                login_conn.Close();

                login_conn.Dispose();
            }
        }

        // Added by Anand Dated on 07-08-2018
        public int ChangePwd(LoginSchema objLoginSchema)
        {
            login_conn = new SqlConnection();
            login_conn = SQLHelper.OpenConnection();
            SqlParameter[] _param = new SqlParameter[4];
            try
            {
                _param[0] = new SqlParameter("@UserID", SqlDbType.VarChar);
                _param[0].Value = (objLoginSchema.UserID);

                _param[1] = new SqlParameter("@CurrentPassword", SqlDbType.VarChar);
                _param[1].Value = objLoginSchema.ChangedPassword;

                _param[2] = new SqlParameter("@Newpassword", SqlDbType.VarChar);
                _param[2].Value = objLoginSchema.ConfirmPassword;

                _param[3] = new SqlParameter("@Seed", SqlDbType.VarChar);
                _param[3].Value = objLoginSchema.SessionID;

                SqlCommand command = new SqlCommand();
                command.CommandText = "uspChangePassword";
                command.CommandTimeout = 5000;
                command.CommandType = CommandType.StoredProcedure;
                int result = HelperCls.ExecuteNonQuery(login_conn, null, CommandType.StoredProcedure, command.CommandText, _param);
                return result;

            }

            catch (Exception Ex)
            {
                throw Ex;

            }
            finally
            {
                login_conn.Close();

                login_conn.Dispose();
            }
        }
        // End 07-08-2018
        #endregion
    }
}
