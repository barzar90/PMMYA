using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class EmailSchema
    {
        private string custemailid;
        private string bankemailid;
        private string dpoemailid;
        private string applicationid;
        private string applicantname;
        private string loantype;
        private string loanamount;
        private string bankname;
        private string branchname;
        private string districtname;
        private string talukaname;
        private string dponame;
        private string dpoaddress;
        private string mobileno;
        private string aplicantaddress;
        private DateTime applicationdate;

        public string CustEmailID
        {
            get { return custemailid; }
            set { custemailid = value; }
        }

        public string BankEmailID
        {
            get { return bankemailid; }
            set { bankemailid = value; }
        }

        public string DPOEmailID
        {
            get { return dpoemailid; }
            set { dpoemailid = value; }
        }

        public string ApplicationID
        {
            get { return applicationid; }
            set { applicationid = value; }
        }

        public string ApplicantName
        {
            get { return applicantname; }
            set { applicantname = value; }
        }

        public string LoanType
        {
            get { return loantype; }
            set { loantype = value; }
        }

        public string LoanAmount
        {
            get { return loanamount; }
            set { loanamount = value; }
        }

        public string BankName
        {
            get { return bankname; }
            set { bankname = value; }
        }

        public string BranchName
        {
            get { return branchname; }
            set { branchname = value; }
        }

        public string DistrictName
        {
            get { return districtname; }
            set { districtname = value; }
        }

        public string TalukaName
        {
            get { return talukaname; }
            set { talukaname = value; }
        }

        public string DPOName
        {
            get { return dponame; }
            set { dponame = value; }
        }

        public string DPOAddress
        {
            get { return dpoaddress; }
            set { dpoaddress = value; }
        }

        public string MobileNo
        {
            get { return mobileno; }
            set { mobileno = value; }
        }

        public string AplicantAddress
        {
            get { return aplicantaddress; }
            set { aplicantaddress = value; }
        }

        public DateTime ApplicationDate
        {
            get { return applicationdate; }
            set { applicationdate = value; }
        }

    }
}
