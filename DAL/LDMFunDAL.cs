using Helper;
using Schema;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LDMFunDAL
    {
        public DataSet LDM_Insert(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[]
                    {
                         //new SqlParameter("@Sr_No", objLDMFuncSchema.Sr_No == 0 ? 0 : objLDMFuncSchema.Sr_No),
                         new SqlParameter("@BankName",objLDMFuncSchema.BankName == null ? (object)DBNull.Value :objLDMFuncSchema.BankName),
                         new SqlParameter("@BankBranch",objLDMFuncSchema.BankBranch == null ? (object)DBNull.Value :objLDMFuncSchema.BankBranch),
                         new SqlParameter("@IFSCCode",objLDMFuncSchema.IFSCCode == null ? (object)DBNull.Value :objLDMFuncSchema.IFSCCode),
                         new SqlParameter("@App_Reg",objLDMFuncSchema.App_Reg == null ? (object)DBNull.Value :objLDMFuncSchema.App_Reg),
                         new SqlParameter("@Loan_Category",objLDMFuncSchema.Loan_Category == null ? (object)DBNull.Value :objLDMFuncSchema.Loan_Category),
                         new SqlParameter("@FirstName",objLDMFuncSchema.FirstName == null ? (object)DBNull.Value :objLDMFuncSchema.FirstName),
                         new SqlParameter("@MiddleName",objLDMFuncSchema.MiddleName == null ? (object)DBNull.Value :objLDMFuncSchema.MiddleName),
                         new SqlParameter("@LastName",objLDMFuncSchema.LastName == null ? (object)DBNull.Value :objLDMFuncSchema.LastName),
                         new SqlParameter("@Gender",objLDMFuncSchema.Gender == null ? (object)DBNull.Value :objLDMFuncSchema.Gender),
                         new SqlParameter("@MaritalStatus",objLDMFuncSchema.MaritalStatus == null ? (object)DBNull.Value :objLDMFuncSchema.MaritalStatus),
                         new SqlParameter("@Dob",objLDMFuncSchema.Dob == null ? (object)DBNull.Value :objLDMFuncSchema.Dob),
                         new SqlParameter("@Village",objLDMFuncSchema.Village == null ? (object)DBNull.Value :objLDMFuncSchema.Village),
                         new SqlParameter("@Gram",objLDMFuncSchema.Gram == null ? (object)DBNull.Value :objLDMFuncSchema.Gram),
                         new SqlParameter("@Tehsil",objLDMFuncSchema.Tehsil == null ? (object)DBNull.Value :objLDMFuncSchema.Tehsil),
                         new SqlParameter("@Block",objLDMFuncSchema.Block == null ? (object)DBNull.Value :objLDMFuncSchema.Block),
                         new SqlParameter("@District",objLDMFuncSchema.District == null ? (object)DBNull.Value :objLDMFuncSchema.District),
                         new SqlParameter("@Religion",objLDMFuncSchema.Religion == null ? (object)DBNull.Value :objLDMFuncSchema.Religion),
                         new SqlParameter("@Minority_Comm",objLDMFuncSchema.Minority_Comm == null ? (object)DBNull.Value :objLDMFuncSchema.Minority_Comm),
                         new SqlParameter("@Social_Category",objLDMFuncSchema.Social_Category == null ? (object)DBNull.Value :objLDMFuncSchema.Social_Category),
                         new SqlParameter("@Aadhar",objLDMFuncSchema.Aadhar == null ? (object)DBNull.Value :objLDMFuncSchema.Aadhar),
                         new SqlParameter("@PAN",objLDMFuncSchema.PAN == null ? (object)DBNull.Value :objLDMFuncSchema.PAN),
                         new SqlParameter("@Mobile",objLDMFuncSchema.Mobile == null ? (object)DBNull.Value :objLDMFuncSchema.Mobile),
                         new SqlParameter("@Email",objLDMFuncSchema.Email == null ? (object)DBNull.Value :objLDMFuncSchema.Email),
                         new SqlParameter("@ReqLoanAmnt",objLDMFuncSchema.ReqLoanAmnt == 0 ? 0 : objLDMFuncSchema.ReqLoanAmnt),
                         new SqlParameter("@SanctionAmnt",objLDMFuncSchema.SanctionAmnt == 0 ? 0 :objLDMFuncSchema.SanctionAmnt),
                         new SqlParameter("@SanctionDate",objLDMFuncSchema.SanctionDate == null ? (object)DBNull.Value :objLDMFuncSchema.SanctionDate),
                         new SqlParameter("@Business_Activity",objLDMFuncSchema.Business_Activity == null ? (object)DBNull.Value :objLDMFuncSchema.Business_Activity),
                         new SqlParameter("@Type_Loan",objLDMFuncSchema.Type_Loan== null ? (object)DBNull.Value :objLDMFuncSchema.Type_Loan),
                         new SqlParameter("@DisbursedAmnt",objLDMFuncSchema.DisbursedAmnt == 0 ? 0 :objLDMFuncSchema.DisbursedAmnt),
                         new SqlParameter("@DisburseDate",objLDMFuncSchema.DisburseDate == null ? (object)DBNull.Value :objLDMFuncSchema.DisburseDate),
                         new SqlParameter("@LoanAmntOutStanding",objLDMFuncSchema.LoanAmntOutStanding == 0 ? 0 :objLDMFuncSchema.LoanAmntOutStanding),
                         new SqlParameter("@AnualTarget", objLDMFuncSchema.AnualTarget == 0 ? 0 : objLDMFuncSchema.AnualTarget),
                         new SqlParameter("@Districtid",objLDMFuncSchema.Districtid == 0 ? 0 :objLDMFuncSchema.Districtid),
                         new SqlParameter("@BankId",objLDMFuncSchema.BankId == 0 ? 0 :objLDMFuncSchema.BankId),
                         new SqlParameter("@CategoryId",objLDMFuncSchema.CategoryId == 0 ? 0 :objLDMFuncSchema.CategoryId),
                         new SqlParameter("@InsertDate",objLDMFuncSchema.InsertDate == null ? (object)DBNull.Value :objLDMFuncSchema.InsertDate),
                         new SqlParameter("@InsertedBy", objLDMFuncSchema.InsertedBy == null ? (object)DBNull.Value : objLDMFuncSchema.InsertedBy),
                    };
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_ReadDataInsert", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet GetGridViewData(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;               

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetGridViewData", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        //Search
        public DataSet SearchGridData(string searchTxt)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                         new SqlParameter("@BankName", searchTxt == null ? (object)DBNull.Value :searchTxt),
                };
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetSearchBankGridData", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        #region Search
        //Search Bank
        public DataSet SearchBankGridData(string searchTxt, LDMFunSchema objLDMFuncSchema)
        {
            //LDMFunSchema objLDMFuncSchema= new LDMFunSchema();
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                //SqlParameter[] param = new SqlParameter[1]
                //{                
                //new SqlParameter("@BankName", searchTxt == null ? (object)DBNull.Value :searchTxt),
                //};
                //param[0] = new SqlParameter("@DistrictType", SqlDbType.VarChar);
                //param[0].Value = objLDMFuncSchema.DistrictType;

                SqlParameter[] param = new SqlParameter[2];
                //new SqlParameter("@BankName", searchTxt == null ? (object)DBNull.Value : searchTxt);                
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;

                param[1] = new SqlParameter("@BankName", SqlDbType.VarChar);
                param[1].Value = searchTxt == null ? (object)DBNull.Value : searchTxt;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetSearchBankGridData", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
        
        public DataSet SearchDistrictGridData(string searchTxt, LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                //{
                //         new SqlParameter("@District", searchTxt == null ? (object)DBNull.Value :searchTxt),
                //};
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;

                param[1] = new SqlParameter("@BankName", SqlDbType.VarChar);
                param[1].Value = searchTxt == null ? (object)DBNull.Value : searchTxt;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetSearchDistrictGridData", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
        
        public DataSet SearchStateGridData(string searchTxt, LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                //{
                //         new SqlParameter("@BankName", searchTxt == null ? (object)DBNull.Value :searchTxt),
                //};
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
                param[1] = new SqlParameter("@BankName", SqlDbType.VarChar);
                param[1].Value = searchTxt == null ? (object)DBNull.Value : searchTxt;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetSearchStateGridData", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
        
        public DataSet SearchSocialCategoryGridData(string searchTxt, LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                //{
                //         new SqlParameter("@BankName", searchTxt == null ? (object)DBNull.Value :searchTxt),
                //};
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
                param[1] = new SqlParameter("@CategoryName", SqlDbType.VarChar);
                param[1].Value = searchTxt == null ? (object)DBNull.Value : searchTxt;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetSearchCategoryGridData", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }        
        #endregion

        public DataSet GetBankName(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int)
                {
                    Value = objLDMFuncSchema.Districtid
                };

                //using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBankName", param))
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBankName"))
                {
                    return ds;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        #region Get All
        //Get Bank Id
        public DataSet GetAllBank(string BankName)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@BankName", SqlDbType.VarChar)
                {
                    Value = BankName
                };
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getAllBank", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
        
        //Get District ID
        public DataSet GetAllDistrict(string DistrictName)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DistrictName", SqlDbType.VarChar)
                {
                    Value = DistrictName
                };
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getAllDistrict", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        //Get Social Category
        public DataSet GetAllCategory(string CategoryName)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryName", SqlDbType.VarChar)
                {
                    Value = CategoryName
                };
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getAllSocialCategory", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
        #endregion

        #region Reports
        public DataSet GetBankViewReport(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
              
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "rep_BankLevelReport", param))
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
       
        public DataSet GetDistrictViewReport(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
                //param[1] = new SqlParameter("@ShiLoanCategory", SqlDbType.VarChar);
                //param[1].Value = objLDMFuncSchema.ShiLoanCategory;
                //param[2] = new SqlParameter("@KisLoanCategory", SqlDbType.VarChar);
                //param[2].Value = objLDMFuncSchema.KisLoanCategory;
                //param[3] = new SqlParameter("@TarLoanCategory", SqlDbType.VarChar);
                //param[3].Value = objLDMFuncSchema.TarLoanCategory;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "rep_DistrictLevelReport", param))                
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
       
        public DataSet GetStateViewReport(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
                
                param[1] = new SqlParameter("@ShiLoanCategory", SqlDbType.VarChar);
                param[1].Value = objLDMFuncSchema.ShiLoanCategory;

                param[2] = new SqlParameter("@KisLoanCategory", SqlDbType.VarChar);
                param[2].Value = objLDMFuncSchema.KisLoanCategory;

                param[3] = new SqlParameter("@TarLoanCategory", SqlDbType.VarChar);
                param[3].Value = objLDMFuncSchema.TarLoanCategory;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "rep_StateLevelReport", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet GetSocialCategoryViewReport(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;

                param[1] = new SqlParameter("@ShiLoanCategory", SqlDbType.VarChar);
                param[1].Value = objLDMFuncSchema.ShiLoanCategory;

                param[2] = new SqlParameter("@KisLoanCategory", SqlDbType.VarChar);
                param[2].Value = objLDMFuncSchema.KisLoanCategory;

                param[3] = new SqlParameter("@TarLoanCategory", SqlDbType.VarChar);
                param[3].Value = objLDMFuncSchema.TarLoanCategory;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "rep_CategoryLevelReport", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }        

        public DataSet GetTopBestBank(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Perform_TopBank", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet GetTopBestDistrict(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Districtid", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Perform_TopDistrict", param))
                {
                    return ds;
                }
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }
        #endregion
        
        //LDM Dashboard Shishu
        public DataSet GetLDMContentShishu(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;
               
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getldmDashbordShishu", param))
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
        
        //LDM Dashboard Kishore
        public DataSet GetLDMContentKishore(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getldmDashbordKishore", param))
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

        //LDM Dashboard Tarun
        public DataSet GetLDMContentTarun(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                param[0].Value = objLDMFuncSchema.Districtid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getldmDashbordTarun", param))
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

        //Ldm Application Form            
        public DataSet GetApplicationForm(LDMFunSchema objLDMFuncSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];                
                param[0] = new SqlParameter("@Status", SqlDbType.VarChar);
                param[0].Value = objLDMFuncSchema.Status;
                param[1] = new SqlParameter("@ApplicationID", SqlDbType.VarChar);
                param[1].Value = objLDMFuncSchema.ApplicationID;
                param[2] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                param[2].Value = objLDMFuncSchema.ActionType;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getFormApplicationDetails"))
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

        public DataSet UpdateApplicationForm(string spAction, string appId, string status)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Status", SqlDbType.VarChar);
                param[0].Value = status;
                param[1] = new SqlParameter("@ApplicationID", SqlDbType.VarChar);
                param[1].Value = appId;
                param[2] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                param[2].Value = spAction;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getFormApplicationDetails", param))
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

        public DataSet SelectApplicationForm(string spAction, string appId, string status)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Status", SqlDbType.VarChar);
                param[0].Value = status;
                param[1] = new SqlParameter("@ApplicationID", SqlDbType.VarChar);
                param[1].Value = appId;
                param[2] = new SqlParameter("@ActionType", SqlDbType.VarChar);
                param[2].Value = spAction;
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "getFormApplicationDetails", param))
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
