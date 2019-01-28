using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class ApplicationformDAL
    {


        public DataSet GetConstitutionDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetResidentDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetEducationDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetKYCDocDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetBusinessDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetSocialCategoryDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetMinorityCommunityDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;
                param[1] = new SqlParameter("@ID", SqlDbType.Int);
                param[1].Value = objApplicationFormSchema.ID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetGenderDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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


        public DataSet GetLoanTypeDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetTaluka(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                param[0].Value = objApplicationFormSchema.Districtid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetTaluka", param))
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

        public DataSet GetBankName(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                param[0].Value = objApplicationFormSchema.Districtid;
                param[1] = new SqlParameter("@TalukaID", SqlDbType.Int);
                param[1].Value = objApplicationFormSchema.Talukaid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBank", param))
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

        public DataSet GetAddressType(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetProofType(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetTypeofExistingAccount(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetBranchkName(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                param[0].Value = objApplicationFormSchema.Districtid;
                param[1] = new SqlParameter("@TalukaID", SqlDbType.Int);
                param[1].Value = objApplicationFormSchema.Talukaid;
                param[2] = new SqlParameter("@BankID", SqlDbType.Int);
                param[2].Value = objApplicationFormSchema.Bankid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBankBranch", param))
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


        public DataSet GetBranchkDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@IFSCode", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.IFSCCode;

                param[1] = new SqlParameter("@BranchName", SqlDbType.VarChar);
                param[1].Value = objApplicationFormSchema.BranchName;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBranchDetails", param))
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


        public DataSet GetBankLoanType(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Type", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.Type;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_BindData", param))
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

        public DataSet GetApplicantDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ApplicantSessionId", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.ApplicantSessionid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetApplicantDetails", param))
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

        // Added by Anand Dated on 28-08-2018
        public DataSet SaveAndGetApplicantID(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {

                var param = new SqlParameter[]
                     {
                         new SqlParameter("@LoanTypeID",objApplicationFormSchema.LoanTypeID == 0 ? 0 :objApplicationFormSchema.LoanTypeID),
                         new SqlParameter("@LoanAmount",objApplicationFormSchema.LoanAmount == 0 ? 0 :objApplicationFormSchema.LoanAmount),
                         new SqlParameter("@DistrictID",objApplicationFormSchema.Districtid == 0 ? 0 :objApplicationFormSchema.Districtid),
                         new SqlParameter("@TalukaID",objApplicationFormSchema.Talukaid == 0 ? 0 :objApplicationFormSchema.Talukaid),
                         new SqlParameter("@BankID",objApplicationFormSchema.Bankid == 0 ? 0 :objApplicationFormSchema.Bankid),
                         new SqlParameter("@BranchName",objApplicationFormSchema.BranchName== null ? (object)DBNull.Value :objApplicationFormSchema.BranchName),
                         new SqlParameter("@IFSCCode",objApplicationFormSchema.IFSCCode== null ? (object)DBNull.Value :objApplicationFormSchema.IFSCCode),
                         new SqlParameter("@BranchAddress",objApplicationFormSchema.BranchAddress== null ? (object)DBNull.Value :objApplicationFormSchema.BranchAddress),
                         new SqlParameter("@FirstHolderName",objApplicationFormSchema.FirstHolderName== null ? (object)DBNull.Value :objApplicationFormSchema.FirstHolderName),
                         new SqlParameter("@SecondHolderName",objApplicationFormSchema.SecondHolderName== null ? (object)DBNull.Value :objApplicationFormSchema.SecondHolderName),
                         new SqlParameter("@FaterOrHusbandName",objApplicationFormSchema.FaterOrHusbandName== null ? (object)DBNull.Value :objApplicationFormSchema.FaterOrHusbandName),
                         new SqlParameter("@ConstitutionID",objApplicationFormSchema.ConstitutionID == 0 ? 0 :objApplicationFormSchema.ConstitutionID),
                         new SqlParameter("@ResidentialAddress",objApplicationFormSchema.ResidentialAddress== null ? (object)DBNull.Value :objApplicationFormSchema.ResidentialAddress),
                         new SqlParameter("@ResiAddresID",objApplicationFormSchema.ResiAddresID == 0 ? 0 :objApplicationFormSchema.ResiAddresID),
                         new SqlParameter("@BusinessAddress",objApplicationFormSchema.BusinessAddress== null ? (object)DBNull.Value :objApplicationFormSchema.BusinessAddress),
                         new SqlParameter("@BusiAddresID",objApplicationFormSchema.BusiAddresID == 0 ? 0 :objApplicationFormSchema.BusiAddresID),
                         new SqlParameter("@DOB",objApplicationFormSchema.DOB== null ? (object)DBNull.Value :objApplicationFormSchema.DOB),
                         new SqlParameter("@Age",objApplicationFormSchema.Age == 0 ? 0 :objApplicationFormSchema.Age),
                         new SqlParameter("@GenderID",objApplicationFormSchema.GenderID == 0 ? 0 :objApplicationFormSchema.GenderID),
                         new SqlParameter("@EducationID",objApplicationFormSchema.EducationID == 0 ? 0 :objApplicationFormSchema.EducationID),
                         new SqlParameter("@KycID_VoterIDNo",objApplicationFormSchema.KycID_VoterIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_VoterIDNo),
                         new SqlParameter("@KycID_AadharNo",objApplicationFormSchema.KycID_AadharNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_AadharNo),
                         new SqlParameter("@KycID_DrivingLicNo",objApplicationFormSchema.KycID_DrivingLicNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_DrivingLicNo),
                         new SqlParameter("@KycID_OtherIDNo",objApplicationFormSchema.KycID_OtherIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_OtherIDNo),
                         new SqlParameter("@KycAddr_VoterIDNo",objApplicationFormSchema.KycAddr_VoterIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_VoterIDNo),
                         new SqlParameter("@KycAddr_AadharNo",objApplicationFormSchema.KycAddr_AadharNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_AadharNo),
                         new SqlParameter("@KycAddr_DrivingLicNo",objApplicationFormSchema.KycAddr_DrivingLicNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_DrivingLicNo),
                         new SqlParameter("@KycAddr_OtherIDNo",objApplicationFormSchema.KycAddr_OtherIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_OtherIDNo),
                         new SqlParameter("@TelPhNo",objApplicationFormSchema.TelPhNo== null ? (object)DBNull.Value :objApplicationFormSchema.TelPhNo),
                         new SqlParameter("@MobileNo",objApplicationFormSchema.MobileNo== null ? (object)DBNull.Value :objApplicationFormSchema.MobileNo),
                         new SqlParameter("@EmailId",objApplicationFormSchema.EmailId== null ? (object)DBNull.Value :objApplicationFormSchema.EmailId),
                         new SqlParameter("@BusinessTypeID",objApplicationFormSchema.BusinessTypeID == 0 ? 0 :objApplicationFormSchema.BusinessTypeID),
                         new SqlParameter("@ExtBusinessPeriod",objApplicationFormSchema.ExtBusinessPeriod == 0 ? 0 :objApplicationFormSchema.ExtBusinessPeriod),
                         new SqlParameter("@AnnualSaleExt",objApplicationFormSchema.AnnualSaleExt == 0 ? 0 :objApplicationFormSchema.AnnualSaleExt),
                         new SqlParameter("@AnnualSaleProp",objApplicationFormSchema.AnnualSaleProp == 0 ? 0 :objApplicationFormSchema.AnnualSaleProp),
                         new SqlParameter("@BusinessExperience",objApplicationFormSchema.BusinessExperience== null ? (object)DBNull.Value :objApplicationFormSchema.BusinessExperience),
                         new SqlParameter("@SocialCategoryID",objApplicationFormSchema.SocialCategoryID == 0 ? 0 :objApplicationFormSchema.SocialCategoryID),
                         new SqlParameter("@MinorityCategory",objApplicationFormSchema.MinorityCategory == 0 ? 0 :objApplicationFormSchema.MinorityCategory),
                         new SqlParameter("@ISExistingAccount",objApplicationFormSchema.ISExistingAccount == false ? Convert.ToBoolean(0) : objApplicationFormSchema.ISExistingAccount),
                         new SqlParameter("@ExtAccountType",objApplicationFormSchema.ExtAccountType == 0 ? 0 :objApplicationFormSchema.ExtAccountType),
                         new SqlParameter("@ExtBankName",objApplicationFormSchema.ExtBankName== null ? (object)DBNull.Value :objApplicationFormSchema.ExtBankName),
                         new SqlParameter("@ExtBankBranch",objApplicationFormSchema.ExtBankBranch== null ? (object)DBNull.Value :objApplicationFormSchema.ExtBankBranch),
                         new SqlParameter("@ExtBankAccNo",objApplicationFormSchema.ExtBankAccNo== null ? (object)DBNull.Value :objApplicationFormSchema.ExtBankAccNo),
                         new SqlParameter("@ExtLoanAmount",objApplicationFormSchema.ExtLoanAmount == 0 ? 0 :objApplicationFormSchema.ExtLoanAmount),
                         new SqlParameter("@ApplicationID",objApplicationFormSchema.ApplicationID== null ? (object)DBNull.Value :objApplicationFormSchema.ApplicationID),
                         new SqlParameter("@CreatedBy",objApplicationFormSchema.CreatedBy== null ? (object)DBNull.Value :objApplicationFormSchema.CreatedBy),
                         new SqlParameter("@BankLoanID",objApplicationFormSchema.BankloanId == 0 ? 0 :objApplicationFormSchema.BankloanId),
                         new SqlParameter("@BusinessActivity",objApplicationFormSchema.BusinessActivity == null ? (object)DBNull.Value :objApplicationFormSchema.BusinessActivity),
                     };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_InsertApplicationData", param))
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
        // end

        // Added By Kiran 
        public string InsertLoanApplicationDetails(ApplicationFormSchema objApplicationFormSchema)
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
                           
                            //*********Insert into Loan Application ***********************************************
                              
                         new SqlParameter("@LoanTypeID",objApplicationFormSchema.LoanTypeID == 0 ? 0 :objApplicationFormSchema.LoanTypeID),
                         new SqlParameter("@LoanAmount",objApplicationFormSchema.LoanAmount == 0 ? 0 :objApplicationFormSchema.LoanAmount),
                         new SqlParameter("@DistrictID",objApplicationFormSchema.Districtid == 0 ? 0 :objApplicationFormSchema.Districtid),
                         new SqlParameter("@TalukaID",objApplicationFormSchema.Talukaid == 0 ? 0 :objApplicationFormSchema.Talukaid),
                         new SqlParameter("@BankID",objApplicationFormSchema.Bankid == 0 ? 0 :objApplicationFormSchema.Bankid),
                         new SqlParameter("@BranchName",objApplicationFormSchema.BranchName== null ? (object)DBNull.Value :objApplicationFormSchema.BranchName),
                         new SqlParameter("@IFSCCode",objApplicationFormSchema.IFSCCode== null ? (object)DBNull.Value :objApplicationFormSchema.IFSCCode),
                         new SqlParameter("@BranchAddress",objApplicationFormSchema.BranchAddress== null ? (object)DBNull.Value :objApplicationFormSchema.BranchAddress),
                         new SqlParameter("@FirstHolderName",objApplicationFormSchema.FirstHolderName== null ? (object)DBNull.Value :objApplicationFormSchema.FirstHolderName),
                         new SqlParameter("@SecondHolderName",objApplicationFormSchema.SecondHolderName== null ? (object)DBNull.Value :objApplicationFormSchema.SecondHolderName),
                         new SqlParameter("@FaterOrHusbandName",objApplicationFormSchema.FaterOrHusbandName== null ? (object)DBNull.Value :objApplicationFormSchema.FaterOrHusbandName),
                         new SqlParameter("@ConstitutionID",objApplicationFormSchema.ConstitutionID == 0 ? 0 :objApplicationFormSchema.ConstitutionID),
                         new SqlParameter("@ResidentialAddress",objApplicationFormSchema.ResidentialAddress== null ? (object)DBNull.Value :objApplicationFormSchema.ResidentialAddress),
                         new SqlParameter("@ResiAddresID",objApplicationFormSchema.ResiAddresID == 0 ? 0 :objApplicationFormSchema.ResiAddresID),
                         new SqlParameter("@BusinessAddress",objApplicationFormSchema.BusinessAddress== null ? (object)DBNull.Value :objApplicationFormSchema.BusinessAddress),
                         new SqlParameter("@BusiAddresID",objApplicationFormSchema.BusiAddresID == 0 ? 0 :objApplicationFormSchema.BusiAddresID),
                         new SqlParameter("@DOB",objApplicationFormSchema.DOB== null ? (object)DBNull.Value :objApplicationFormSchema.DOB),
                         new SqlParameter("@Age",objApplicationFormSchema.Age == 0 ? 0 :objApplicationFormSchema.Age),
                         new SqlParameter("@GenderID",objApplicationFormSchema.GenderID == 0 ? 0 :objApplicationFormSchema.GenderID),
                         new SqlParameter("@EducationID",objApplicationFormSchema.EducationID == 0 ? 0 :objApplicationFormSchema.EducationID),
                         new SqlParameter("@KycID_VoterIDNo",objApplicationFormSchema.KycID_VoterIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_VoterIDNo),
                         new SqlParameter("@KycID_AadharNo",objApplicationFormSchema.KycID_AadharNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_AadharNo),
                         new SqlParameter("@KycID_DrivingLicNo",objApplicationFormSchema.KycID_DrivingLicNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_DrivingLicNo),
                         new SqlParameter("@KycID_OtherIDNo",objApplicationFormSchema.KycID_OtherIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycID_OtherIDNo),
                         new SqlParameter("@KycAddr_VoterIDNo",objApplicationFormSchema.KycAddr_VoterIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_VoterIDNo),
                         new SqlParameter("@KycAddr_AadharNo",objApplicationFormSchema.KycAddr_AadharNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_AadharNo),
                         new SqlParameter("@KycAddr_DrivingLicNo",objApplicationFormSchema.KycAddr_DrivingLicNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_DrivingLicNo),
                         new SqlParameter("@KycAddr_OtherIDNo",objApplicationFormSchema.KycAddr_OtherIDNo== null ? (object)DBNull.Value :objApplicationFormSchema.KycAddr_OtherIDNo),
                         new SqlParameter("@TelPhNo",objApplicationFormSchema.TelPhNo== null ? (object)DBNull.Value :objApplicationFormSchema.TelPhNo),
                         new SqlParameter("@MobileNo",objApplicationFormSchema.MobileNo== null ? (object)DBNull.Value :objApplicationFormSchema.MobileNo),
                         new SqlParameter("@EmailId",objApplicationFormSchema.EmailId== null ? (object)DBNull.Value :objApplicationFormSchema.EmailId),
                         new SqlParameter("@BusinessTypeID",objApplicationFormSchema.BusinessTypeID == 0 ? 0 :objApplicationFormSchema.BusinessTypeID),
                         new SqlParameter("@ExtBusinessPeriod",objApplicationFormSchema.ExtBusinessPeriod == 0 ? 0 :objApplicationFormSchema.ExtBusinessPeriod),
                         new SqlParameter("@AnnualSaleExt",objApplicationFormSchema.AnnualSaleExt == 0 ? 0 :objApplicationFormSchema.AnnualSaleExt),
                         new SqlParameter("@AnnualSaleProp",objApplicationFormSchema.AnnualSaleProp == 0 ? 0 :objApplicationFormSchema.AnnualSaleProp),
                         new SqlParameter("@BusinessExperience",objApplicationFormSchema.BusinessExperience== null ? (object)DBNull.Value :objApplicationFormSchema.BusinessExperience),
                         new SqlParameter("@SocialCategoryID",objApplicationFormSchema.SocialCategoryID == 0 ? 0 :objApplicationFormSchema.SocialCategoryID),
                         new SqlParameter("@MinorityCategory",objApplicationFormSchema.MinorityCategory == 0 ? 0 :objApplicationFormSchema.MinorityCategory),
                         new SqlParameter("@ISExistingAccount",objApplicationFormSchema.ISExistingAccount == false ? Convert.ToBoolean(0) : objApplicationFormSchema.ISExistingAccount),
                         new SqlParameter("@ExtAccountType",objApplicationFormSchema.ExtAccountType == 0 ? 0 :objApplicationFormSchema.ExtAccountType),
                         new SqlParameter("@ExtBankName",objApplicationFormSchema.ExtBankName== null ? (object)DBNull.Value :objApplicationFormSchema.ExtBankName),
                         new SqlParameter("@ExtBankBranch",objApplicationFormSchema.ExtBankBranch== null ? (object)DBNull.Value :objApplicationFormSchema.ExtBankBranch),
                         new SqlParameter("@ExtBankAccNo",objApplicationFormSchema.ExtBankAccNo== null ? (object)DBNull.Value :objApplicationFormSchema.ExtBankAccNo),
                         new SqlParameter("@ExtLoanAmount",objApplicationFormSchema.ExtLoanAmount == 0 ? 0 :objApplicationFormSchema.ExtLoanAmount),
                         new SqlParameter("@ApplicationID",  SqlDbType.NVarChar, 35, ParameterDirection.Output, true, 0, 0, "ApplicationID", DataRowVersion.Current,""),
                         new SqlParameter("@CreatedBy",objApplicationFormSchema.CreatedBy== null ? (object)DBNull.Value :objApplicationFormSchema.CreatedBy),
                         new SqlParameter("@BankLoanID",objApplicationFormSchema.BankloanId == 0 ? 0 :objApplicationFormSchema.BankloanId),
                         new SqlParameter("@BusinessActivity",objApplicationFormSchema.BusinessActivity == null ? (object)DBNull.Value :objApplicationFormSchema.BusinessActivity)

                            };

                            string record = Convert.ToString(SQLHelper.ExecuteNonQuery(objConn, objTran, CommandType.StoredProcedure, "Usp_InsertLoanApplicationDetails", param));
                            string strArray_result = param[44].Value.ToString();
                            string[] strArrays = strArray_result.Split(';');
                            if (Convert.ToString(strArrays[1].ToLower()) == Convert.ToString("Success").ToLower())
                            {
                                objTran.Commit();
                                return strArray_result;
                            }
                            else
                            {
                                objTran.Rollback();
                                return "";
                            }
                        }

                        catch (Exception ex)
                        {
                            objTran.Rollback();
                            return "";
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                return "";
            }
            finally
            {

            }
        }

        //End

        public DataSet GetLoanApplicationDetail(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ApplicationID", SqlDbType.VarChar);
                param[0].Value = objApplicationFormSchema.ApplicationID;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetLoanDetailsForPDF", param))
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

        public DataSet GetBankData(ApplicationFormSchema objApplicationFormSchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@DistrictID", SqlDbType.Int);
                param[0].Value = objApplicationFormSchema.Districtid;
                param[1] = new SqlParameter("@TalukaID", SqlDbType.Int);
                param[1].Value = objApplicationFormSchema.Talukaid;

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBankData", param))
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
