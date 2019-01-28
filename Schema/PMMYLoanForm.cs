using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schema
{
    public class PMMYLoanForm
    {
        public string BusiInfo_Enterprise_Name { get; set; }
        public string BusiInfo_Constitution { get; set; }
        public string BusiInfo_Curr_Address { get; set; }
        public string BusiInfo_Pincode { get; set; }
        public string BusiInfo_State { get; set; }
        public string BusiInfo_District { get; set; }
        public string BusiInfo_Location { get; set; }
        public string BusiInfo_Premises { get; set; }
        public string BusiInfo_Mobile { get; set; }
        public string BusiInfo_Email { get; set; }
        public string BusiInfo_Act_Existing { get; set; }
        public string BusiInfo_Act_Proposed { get; set; }
        public string BusiInfo_Commencement_Dt { get; set; }
        public string BusiInfo_IsUnitReg { get; set; }
        public string BusiInfo_Reg_Number { get; set; }
        public string BusiInfo_Resi_Address { get; set; }
        public string BusiInfo_Social_Cat { get; set; }
        public string BusiInfo_MonorityComm { get; set; }
        public string Partner_Name { get; set; }
        public string Partner_DOB { get; set; }
        public string Partner_Gender { get; set; }
        public string Partner_Resi_Address { get; set; }
        public string Partner_Mobile { get; set; }
        public string Partner_Qualification { get; set; }
        public string Partner_Exp { get; set; }
        public string Partner_ID_Proof { get; set; }
        public string Partner_ID_Number { get; set; }
        public string Partner_Addr_Proof { get; set; }
        public string Partner_AddrProof_Num { get; set; }
        public string Partner_PAN_DIN_Num { get; set; }
        public string Partner_Relation { get; set; }
        public string Associate_Name { get; set; }
        public string Associate_Addr { get; set; }
        public string Associate_Present_Banking { get; set; }
        public string Associate_Nature { get; set; }
        public string Associate_Interest { get; set; }
        public string Associate_Relation { get; set; }
        public string CR_Exist_SA_Banking { get; set; }
        public string CR_Exist_SA_Outstanding { get; set; }
        public string CR_Exist_SA_Status { get; set; }
        public string CR_Exist_CA_Banking { get; set; }
        public string CR_Exist_CA_Outstanding { get; set; }
        public string CR_Exist_CA_Status { get; set; }
        public string CR_Exist_CC_Banking { get; set; }
        public string CR_Exist_CC_LimitAvailed { get; set; }
        public string CR_Exist_CC_Outstanding { get; set; }
        public string CR_Exist_CC_SecurityLodg { get; set; }
        public string CR_Exist_CC_Status { get; set; }
        public string CR_Exist_TL_Banking { get; set; }
        public string CR_Exist_TL_LimitAvailed { get; set; }
        public string CR_Exist_TL_Outstanding { get; set; }
        public string CR_Exist_TL_SecurityLodg { get; set; }
        public string CR_Exist_TL_Status { get; set; }
        public string CR_Exist_LGBG_Banking { get; set; }
        public string CR_Exist_LGBG_Limit { get; set; }
        public string CR_Exist_LGBG_Outstanding { get; set; }
        public string CR_Exist_LGBG_SecurityLodg { get; set; }
        public string CR_Exist_LGBG_Status { get; set; }
        public string CR_Prop_CC_Amount { get; set; }
        public string CR_Prop_CC_Purpose { get; set; }
        public string CR_Prop_CC_SecurityOffer { get; set; }
        public string CR_Prop_TL_Amount { get; set; }
        public string CR_Prop_TL_Purpose { get; set; }
        public string CR_Prop_TL_SecurityOffer { get; set; }
        public string CR_Prop_LGBG_Amount { get; set; }
        public string CR_Prop_LGBG_Purpose { get; set; }
        public string CR_Prop_LGBG_SecurityOffer { get; set; }
        public string CCL_WC_ActSale_previousFY { get; set; }
        public string CCL_WC_ActSale_currFY { get; set; }
        public string CCL_WC_Proj_Sale { get; set; }
        public string CCL_WC_Proj_Cycle { get; set; }
        public string CCL_WC_Proj_Inventory { get; set; }
        public string CCL_WC_Proj_Debtors { get; set; }
        public string CCL_WC_Proj_Creditors { get; set; }
        public string CCL_WC_Proj_Promot_Contri { get; set; }
        public string CCL_WC_Proj_Limit { get; set; }
        public string CCL_TL_MachineEquip { get; set; }
        public string CCL_TL_Purpose { get; set; }
        public string CCL_TL_SupplierName { get; set; }
        public string CCL_TL_MachineCost { get; set; }
        public string CCL_TL_Promote_Contri { get; set; }
        public string CCL_TL_Loan_Req { get; set; }
        public string CCL_TL_Repayment_Period { get; set; }
        public string PastPerf_PYII_Act_NetSale { get; set; }
        public string PastPerf_PYII_Act_NetProfit { get; set; }
        public string PastPerf_PYII_Act_Capital { get; set; }
        public string PastPerf_PYI_Act_NetSale { get; set; }
        public string PastPerf_PYI_Act_NetProfit { get; set; }
        public string PastPerf_PYI_Act_Capital { get; set; }
        public string PresentYear_Est_NetSale { get; set; }
        public string PresentYear_Est_NetProfit { get; set; }
        public string PresentYear_Est_Capital { get; set; }
        public string NextYear_Proj_NetSale { get; set; }
        public string NextYear_Proj_NetProfit { get; set; }
        public string NextYear_Proj_Capital { get; set; }
        public string SatutoryObl_Reg_Shop { get; set; }
        public string SatutoryObl_Reg_ShopRemark { get; set; }
        public string SatutoryObl_Reg_MSME { get; set; }
        public string SatutoryObl_Reg_MSMERemark { get; set; }
        public string SatutoryObl_DrugLicense { get; set; }
        public string SatutoryObl_DrugLicense_Remark { get; set; }
        public string SatutoryObl_SaleReturn_File { get; set; }
        public string SatutoryObl_SaleReturn_File_Remark { get; set; }
        public string SatutoryObl_ITReturn_File { get; set; }
        public string SatutoryObl_ITReturn_File_Remark { get; set; }
        public string SatutoryObl_Dues_Remain { get; set; }
        public string SatutoryObl_Dues_RemainRemark { get; set; }
        public string Bank { get; set; }
        public string Bank_Branch { get; set; }
        public string Branch_ID { get; set; }
    }
}
