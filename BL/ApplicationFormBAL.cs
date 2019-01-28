using DAL;
using Schema;
using System;
using System.Data;

namespace BL
{
    public class ApplicationFormBAL
    {

        #region Public variable declaration
        ApplicationformDAL objApplicationformDAL = new ApplicationformDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion

        public DataSet GetConstitutionDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetConstitutionDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetResidentDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetResidentDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetEducationDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetEducationDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetKYCDocDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetKYCDocDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetBusinessDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetBusinessDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetSocialCategoryDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetSocialCategoryDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetMinorityCommunityDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetMinorityCommunityDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetGenderDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetGenderDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }


        public DataSet GetLoanTypeDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetLoanTypeDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetTaluka(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetTaluka(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetBankName(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetBankName(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetAddressType(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetAddressType(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetProofType(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetProofType(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetTypeofExistingAccount(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetTypeofExistingAccount(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetBranchkName(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetBranchkName(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetBranchkDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetBranchkDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetApplicantDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetApplicantDetails(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetBankLoanType(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetBankLoanType(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        // added by Anand dated on 28-08-2018
        public DataSet SaveAndGetApplicantID(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.SaveAndGetApplicantID(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }
        //ENd

        public string InsertLoanApplicationDetails(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                string reslutdata = string.Empty;
                reslutdata = objApplicationformDAL.InsertLoanApplicationDetails(objApplicationFormSchema);
                return reslutdata;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public DataSet GetLoanApplicationDetail(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetLoanApplicationDetail(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetBankData(ApplicationFormSchema objApplicationFormSchema)
        {
            try
            {
                ds = objApplicationformDAL.GetBankData(objApplicationFormSchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

    }
}
