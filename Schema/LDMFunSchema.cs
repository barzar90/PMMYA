using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class LDMFunSchema
    {        
        public int Ph_Sec_Id { get; set; }        
        public int Sr_No { get; set; }
        public string BankName { get; set; }       
        public string BankBranch { get; set; }
        public string IFSCCode { get; set; }
        public string App_Reg { get; set; }
        public string Loan_Category { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime Dob { get; set; }
        public string Village { get; set; }
        public string Gram { get; set; }
        public string Tehsil { get; set; }
        public string Block { get; set; }
        public string District { get; set; }
        public string Religion { get; set; }
        public string Minority_Comm { get; set; }
        public string Social_Category { get; set; }
        public string Aadhar { get; set; }
        public string PAN { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public double ReqLoanAmnt { get; set; }
        public double SanctionAmnt { get; set; }
        public DateTime SanctionDate { get; set; }
        public string Business_Activity { get; set; }
        public string Type_Loan { get; set; }
        public double DisbursedAmnt { get; set; }
        public DateTime DisburseDate { get; set; }
        public double LoanAmntOutStanding { get; set; }
        public double AnualTarget { get; set; }
        public string Status { get; set; }
       
        public int Districtid { get; set; }
        public DateTime InsertDate { get; set; }
        public int BankId { get; set; }
        public int CategoryId { get; set; }
        public string InsertedBy { get; set; } //Inserted using district view means district name

        public string DistrictType { get; set; }

        public string ShiLoanCategory { get; set; }
        public string KisLoanCategory { get; set; }
        public string TarLoanCategory { get; set; }
        public string LdmAdmin { get; set; }
        public int ApplicationID { get; set; }

        public string ActionType { get; set; }
        private int ldmDashId;

        public int LDMDashId
        {
            get { return ldmDashId; }

            set { ldmDashId = value; }
        }
    }
}
