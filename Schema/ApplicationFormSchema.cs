using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class ApplicationFormSchema
    {

        private string type;
        private int id;
        private int districtid;
        private int talukaid;
        private int bankid;
        private string ifsccode;
        private string applicantsessionid;
        private int loantypeid;
        private double loanamount;
        private string branchname;
        private string branchaddress;
        private string firstholdername;
        private string secondholdername;
        private string faterorhusbandname;
        private int constitutionid;
        private string residentialaddress;
        private int resiaddresid;
        private string businessaddress;
        private int busiaddresid;
        private DateTime dob;
        private int age;
        private int genderid;
        private int educationid;
        private string kycid_voteridno;
        private string kycid_aadharno;
        private string kycid_drivinglicno;
        private string kycid_otheridno;
        private string kycaddr_voteridno;
        private string kycaddr_aadharno;
        private string kycaddr_drivinglicno;
        private string kycaddr_otheridno;
        private string telphno;
        private string mobileno;
        private string emailid;
        private int businesstypeid;
        private int extbusinessperiod;
        private double annualsaleext;
        private double annualsaleprop;
        private string businessexperience;
        private int socialcategoryid;
        private int minoritycategory;
        private bool isexistingaccount;
        private int extaccounttype;
        private string extbankname;
        private string extbankbranch;
        private string extbankaccno;
        private double extloanamount;
        private string applicationid;
        private string createdby;
        private int bankloanId;
        private string businessActivity;

        public string Type
        {
            get { return type; }

            set { type = value; }
        }

        public int ID
        {
            get { return id; }

            set { id = value; }
        }

        public int Districtid
        {
            get { return districtid; }

            set { districtid = value; }
        }

        public int Talukaid
        {
            get { return talukaid; }

            set { talukaid = value; }
        }

        public int Bankid
        {
            get { return bankid; }

            set { bankid = value; }
        }

        public string IFSCCode
        {
            get { return ifsccode; }

            set { ifsccode = value; }
        }

        public string ApplicantSessionid
        {
            get { return applicantsessionid; }

            set { applicantsessionid = value; }
        }

        public int LoanTypeID
        {
            get { return loantypeid; }

            set { loantypeid = value; }
        }

        public double LoanAmount
        {
            get { return loanamount; }

            set { loanamount = value; }
        }

        public string BranchName
        {
            get { return branchname; }

            set { branchname = value; }
        }


        public string BranchAddress
        {
            get { return branchaddress; }

            set { branchaddress = value; }
        }

        public string FirstHolderName
        {
            get { return firstholdername; }

            set { firstholdername = value; }
        }

        public string SecondHolderName
        {
            get { return secondholdername; }

            set { secondholdername = value; }
        }

        public string FaterOrHusbandName
        {
            get { return faterorhusbandname; }

            set { faterorhusbandname = value; }
        }

        public int ConstitutionID
        {
            get { return constitutionid; }

            set { constitutionid = value; }
        }

        public string ResidentialAddress
        {
            get { return residentialaddress; }

            set { residentialaddress = value; }
        }

        public int ResiAddresID
        {
            get { return resiaddresid; }

            set { resiaddresid = value; }
        }

        public string BusinessAddress
        {
            get { return businessaddress; }

            set { businessaddress = value; }
        }

        public int BusiAddresID
        {
            get { return busiaddresid; }

            set { busiaddresid = value; }
        }

        public DateTime DOB
        {
            get { return dob; }

            set { dob = value; }
        }

        public int Age
        {
            get { return age; }

            set { age = value; }
        }

        public int GenderID
        {
            get { return genderid; }

            set { genderid = value; }
        }

        public int EducationID
        {
            get { return educationid; }

            set { educationid = value; }
        }

        public string KycID_VoterIDNo
        {
            get { return kycid_voteridno; }

            set { kycid_voteridno = value; }
        }

        public string KycID_AadharNo
        {
            get { return kycid_aadharno; }

            set { kycid_aadharno = value; }
        }

        public string KycID_DrivingLicNo
        {
            get { return kycid_drivinglicno; }

            set { kycid_drivinglicno = value; }
        }

        public string KycID_OtherIDNo
        {
            get { return kycid_otheridno; }

            set { kycid_otheridno = value; }
        }

        public string KycAddr_VoterIDNo
        {
            get { return kycaddr_voteridno; }

            set { kycaddr_voteridno = value; }
        }

        public string KycAddr_AadharNo
        {
            get { return kycaddr_aadharno; }

            set { kycaddr_aadharno = value; }
        }

        public string KycAddr_DrivingLicNo
        {
            get { return kycaddr_drivinglicno; }

            set { kycaddr_drivinglicno = value; }
        }

        public string KycAddr_OtherIDNo
        {
            get { return kycaddr_otheridno; }

            set { kycaddr_otheridno = value; }
        }

        public string TelPhNo
        {
            get { return telphno; }

            set { telphno = value; }
        }

        public string MobileNo
        {
            get { return mobileno; }

            set { mobileno = value; }
        }

        public string EmailId
        {
            get { return emailid; }

            set { emailid = value; }
        }

        public int BusinessTypeID
        {
            get { return businesstypeid; }

            set { businesstypeid = value; }
        }

        public int ExtBusinessPeriod
        {
            get { return extbusinessperiod; }

            set { extbusinessperiod = value; }
        }

        public double AnnualSaleExt
        {
            get { return annualsaleext; }

            set { annualsaleext = value; }
        }

        public double AnnualSaleProp
        {
            get { return annualsaleprop; }

            set { annualsaleprop = value; }
        }

        public string BusinessExperience
        {
            get { return businessexperience; }

            set { businessexperience = value; }
        }

        public int SocialCategoryID
        {
            get { return socialcategoryid; }

            set { socialcategoryid = value; }
        }

        public int MinorityCategory
        {
            get { return minoritycategory; }

            set { minoritycategory = value; }
        }

        public bool ISExistingAccount
        {
            get { return isexistingaccount; }

            set { isexistingaccount = value; }
        }

        public int ExtAccountType
        {
            get { return extaccounttype; }

            set { extaccounttype = value; }
        }

        public string ExtBankName
        {
            get { return extbankname; }

            set { extbankname = value; }
        }

        public string ExtBankBranch
        {
            get { return extbankbranch; }

            set { extbankbranch = value; }
        }

        public string ExtBankAccNo
        {
            get { return extbankaccno; }

            set { extbankaccno = value; }
        }

        public double ExtLoanAmount
        {
            get { return extloanamount; }

            set { extloanamount = value; }
        }

        public string ApplicationID
        {
            get { return applicationid; }

            set { applicationid = value; }
        }

        public string CreatedBy
        {
            get { return createdby; }

            set { createdby = value; }
        }

        public int BankloanId
        {
            get { return bankloanId; }

            set { bankloanId = value; }
        }


        public string BusinessActivity
        {
            get { return businessActivity; }

            set { businessActivity = value; }
        }

    }
}
