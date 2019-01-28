using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
   public class DropDownnSchema
    {
        private string langid;
        private string DistrictID;
        private string branchID;
        private string stateID;
        public string Langid { get => langid; set => langid = value; }
        public string DistrictID1 { get => DistrictID; set => DistrictID = value; }
        public string BranchID { get => branchID; set => branchID = value; }
        public string StateID { get => stateID; set => stateID = value; }
        public string BankName { get => bankName; set => bankName = value; }
        public string BranchName { get => branchName; set => branchName = value; }
        public string IFSCode { get => iFSCode; set => iFSCode = value; }
        public string BranchAddress { get => branchAddress; set => branchAddress = value; }
        public string DistrictName { get => districtName; set => districtName = value; }
        public string TalukaName { get => talukaName; set => talukaName = value; }
        public string BranchemailID { get => branchemailID; set => branchemailID = value; }
        public string BranchTelNowithSTDcode { get => branchTelNowithSTDcode; set => branchTelNowithSTDcode = value; }
        public string BranchManagerName { get => branchManagerName; set => branchManagerName = value; }
        public string BranchManagerMobileNo { get => branchManagerMobileNo; set => branchManagerMobileNo = value; }
        private string bankName;
        private string branchName;
        private string iFSCode;
        private string branchAddress;
        private string districtName;
        private string talukaName;
        private string branchemailID;
        private string branchTelNowithSTDcode;
        private string branchManagerName;
        private string branchManagerMobileNo;
    }
}
