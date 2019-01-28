using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using Schema;

namespace PMMYA.Site.Home
{
    public partial class FrmApplicationForm : System.Web.UI.Page
    {
        PMMYLoanForm LoanObj = new PMMYLoanForm();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Loan"] = LoanObj;
        }
        //[System.Web.Services.WebMethod]
        //public static string BusinessInfo(string BusiInfo_Enterprise_Name)
        //{
        //    return "hello";
        //}

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string BusinessInfo(string BusiInfo_Enterprise_Name, string BusiInfo_Constitution, string BusiInfo_Curr_Address, string BusiInfo_Pincode,
    string BusiInfo_State, string BusiInfo_District, string BusiInfo_Location, string BusiInfo_Premises, string BusiInfo_Mobile, string BusiInfo_Email,
    string BusiInfo_Act_Existing, string BusiInfo_Act_Proposed, string BusiInfo_Commencement_Dt, string BusiInfo_IsUnitReg, string BusiInfo_Reg_Number,
    string BusiInfo_Resi_Address, string BusiInfo_Social_Cat, string BusiInfo_MonorityComm)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.BusiInfo_Enterprise_Name = BusiInfo_Enterprise_Name;
            Loandata.BusiInfo_Constitution = BusiInfo_Constitution;
            Loandata.BusiInfo_Curr_Address = BusiInfo_Curr_Address;
            Loandata.BusiInfo_Pincode = BusiInfo_Pincode;
            Loandata.BusiInfo_State = BusiInfo_State;
            Loandata.BusiInfo_District = BusiInfo_District;
            Loandata.BusiInfo_Location = BusiInfo_Location;
            Loandata.BusiInfo_Premises = BusiInfo_Premises;
            Loandata.BusiInfo_Mobile = BusiInfo_Mobile;
            Loandata.BusiInfo_Email = BusiInfo_Email;
            Loandata.BusiInfo_Act_Existing = BusiInfo_Act_Existing;
            Loandata.BusiInfo_Act_Proposed = BusiInfo_Act_Proposed;
            Loandata.BusiInfo_Commencement_Dt = BusiInfo_Commencement_Dt;
            Loandata.BusiInfo_IsUnitReg = BusiInfo_IsUnitReg;
            Loandata.BusiInfo_Reg_Number = BusiInfo_Reg_Number;
            Loandata.BusiInfo_Resi_Address = BusiInfo_Resi_Address;
            Loandata.BusiInfo_Social_Cat = BusiInfo_Social_Cat;
            Loandata.BusiInfo_MonorityComm = BusiInfo_MonorityComm;



            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);


            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string PartnerInfo(string Partner_Name, string Partner_DOB, string Partner_Gender, string Partner_Resi_Address,
    string Partner_Mobile, string Partner_Qualification, string Partner_Exp, string Partner_ID_Proof, string Partner_ID_Number, string Partner_Addr_Proof,
    string Partner_AddrProof_Num, string Partner_PAN_DIN_Num, string Partner_Relation)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.Partner_Name = Partner_Name;
            Loandata.Partner_DOB = Partner_DOB;
            Loandata.Partner_Gender = Partner_Gender;
            Loandata.Partner_Resi_Address = Partner_Resi_Address;
            Loandata.Partner_Mobile = Partner_Mobile;
            Loandata.Partner_Qualification = Partner_Qualification;
            Loandata.Partner_Exp = Partner_Exp;
            Loandata.Partner_ID_Proof = Partner_ID_Proof;
            Loandata.Partner_ID_Number = Partner_ID_Number;
            Loandata.Partner_Addr_Proof = Partner_Addr_Proof;
            Loandata.Partner_AddrProof_Num = Partner_AddrProof_Num;
            Loandata.Partner_PAN_DIN_Num = Partner_PAN_DIN_Num;
            Loandata.Partner_Relation = Partner_Relation;

            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);


            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string AssociateInfo(string Associate_Name, string Associate_Addr, string Associate_Present_Banking, string Associate_Nature,
    string Associate_Interest, string Associate_Relation)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.Associate_Name = Associate_Name;
            Loandata.Associate_Addr = Associate_Addr;
            Loandata.Associate_Present_Banking = Associate_Present_Banking;
            Loandata.Associate_Nature = Associate_Nature;
            Loandata.Associate_Interest = Associate_Interest;
            Loandata.Associate_Relation = Associate_Relation;

            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);


            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string BankingCreditInfo(string CR_Exist_SA_Banking, string CR_Exist_SA_Outstanding, string CR_Exist_SA_Status, string CR_Exist_CA_Banking, string CR_Exist_CA_Outstanding,
    string CR_Exist_CA_Status, string CR_Exist_CC_Banking, string CR_Exist_CC_LimitAvailed, string CR_Exist_CC_Outstanding, string CR_Exist_CC_SecurityLodg,
    string CR_Exist_CC_Status, string CR_Exist_TL_Banking, string CR_Exist_TL_LimitAvailed, string CR_Exist_TL_Outstanding, string CR_Exist_TL_SecurityLodg,
    string CR_Exist_TL_Status, string CR_Exist_LGBG_Banking, string CR_Exist_LGBG_Limit, string CR_Exist_LGBG_Outstanding, string CR_Exist_LGBG_SecurityLodg,
    string CR_Exist_LGBG_Status, string CR_Prop_CC_Amount, string CR_Prop_CC_Purpose, string CR_Prop_CC_SecurityOffer, string CR_Prop_TL_Amount,
    string CR_Prop_TL_Purpose, string CR_Prop_TL_SecurityOffer, string CR_Prop_LGBG_Amount, string CR_Prop_LGBG_Purpose, string CR_Prop_LGBG_SecurityOffer)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.CR_Exist_SA_Banking = CR_Exist_SA_Banking;
            Loandata.CR_Exist_SA_Outstanding = CR_Exist_SA_Outstanding;
            Loandata.CR_Exist_SA_Status = CR_Exist_SA_Status;
            Loandata.CR_Exist_CA_Banking = CR_Exist_CA_Banking;
            Loandata.CR_Exist_CA_Outstanding = CR_Exist_CA_Outstanding;
            Loandata.CR_Exist_CA_Status = CR_Exist_CA_Status;
            Loandata.CR_Exist_CC_Banking = CR_Exist_CC_Banking;
            Loandata.CR_Exist_CC_LimitAvailed = CR_Exist_CC_LimitAvailed;
            Loandata.CR_Exist_CC_Outstanding = CR_Exist_CC_Outstanding;
            Loandata.CR_Exist_CC_SecurityLodg = CR_Exist_CC_SecurityLodg;
            Loandata.CR_Exist_CC_Status = CR_Exist_CC_Status;
            Loandata.CR_Exist_TL_Banking = CR_Exist_TL_Banking;
            Loandata.CR_Exist_TL_LimitAvailed = CR_Exist_TL_LimitAvailed;
            Loandata.CR_Exist_TL_Outstanding = CR_Exist_TL_Outstanding;
            Loandata.CR_Exist_TL_SecurityLodg = CR_Exist_TL_SecurityLodg;
            Loandata.CR_Exist_TL_Status = CR_Exist_TL_Status;
            Loandata.CR_Exist_LGBG_Banking = CR_Exist_LGBG_Banking;
            Loandata.CR_Exist_LGBG_Limit = CR_Exist_LGBG_Limit;
            Loandata.CR_Exist_LGBG_Outstanding = CR_Exist_LGBG_Outstanding;
            Loandata.CR_Exist_LGBG_SecurityLodg = CR_Exist_LGBG_SecurityLodg;
            Loandata.CR_Exist_LGBG_Status = CR_Exist_LGBG_Status;
            Loandata.CR_Prop_CC_Amount = CR_Prop_CC_Amount;
            Loandata.CR_Prop_CC_Purpose = CR_Prop_CC_Purpose;
            Loandata.CR_Prop_CC_SecurityOffer = CR_Prop_CC_SecurityOffer;
            Loandata.CR_Prop_TL_Amount = CR_Prop_TL_Amount;
            Loandata.CR_Prop_TL_Purpose = CR_Prop_TL_Purpose;
            Loandata.CR_Prop_TL_SecurityOffer = CR_Prop_TL_SecurityOffer;
            Loandata.CR_Prop_LGBG_Amount = CR_Prop_LGBG_Amount;
            Loandata.CR_Prop_LGBG_Purpose = CR_Prop_LGBG_Purpose;
            Loandata.CR_Prop_LGBG_SecurityOffer = CR_Prop_LGBG_SecurityOffer;


            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);


            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string CashCreditInfo(string CCL_WC_ActSale_previousFY, string CCL_WC_ActSale_currFY, string CCL_WC_Proj_Sale, string CCL_WC_Proj_Cycle, string CCL_WC_Proj_Inventory,
    string CCL_WC_Proj_Debtors, string CCL_WC_Proj_Creditors, string CCL_WC_Proj_Promot_Contri, string CCL_WC_Proj_Limit, string CCL_TL_MachineEquip,
    string CCL_TL_Purpose, string CCL_TL_SupplierName, string CCL_TL_MachineCost, string CCL_TL_Promote_Contri, string CCL_TL_Loan_Req, string CCL_TL_Repayment_Period)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.CCL_WC_ActSale_previousFY = CCL_WC_ActSale_previousFY;
            Loandata.CCL_WC_ActSale_currFY = CCL_WC_ActSale_currFY;
            Loandata.CCL_WC_Proj_Sale = CCL_WC_Proj_Sale;
            Loandata.CCL_WC_Proj_Cycle = CCL_WC_Proj_Cycle;
            Loandata.CCL_WC_Proj_Inventory = CCL_WC_Proj_Inventory;
            Loandata.CCL_WC_Proj_Debtors = CCL_WC_Proj_Debtors;
            Loandata.CCL_WC_Proj_Creditors = CCL_WC_Proj_Creditors;
            Loandata.CCL_WC_Proj_Promot_Contri = CCL_WC_Proj_Promot_Contri;
            Loandata.CCL_WC_Proj_Limit = CCL_WC_Proj_Limit;
            Loandata.CCL_TL_MachineEquip = CCL_TL_MachineEquip;
            Loandata.CCL_TL_Purpose = CCL_TL_Purpose;
            Loandata.CCL_TL_SupplierName = CCL_TL_SupplierName;
            Loandata.CCL_TL_MachineCost = CCL_TL_MachineCost;
            Loandata.CCL_TL_Promote_Contri = CCL_TL_Promote_Contri;
            Loandata.CCL_TL_Loan_Req = CCL_TL_Loan_Req;
            Loandata.CCL_TL_Repayment_Period = CCL_TL_Repayment_Period;

            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);


            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string PastFutureInfo(string PastPerf_PYII_Act_NetSale, string PastPerf_PYII_Act_NetProfit, string PastPerf_PYII_Act_Capital,
            string PastPerf_PYI_Act_NetSale, string PastPerf_PYI_Act_NetProfit, string PastPerf_PYI_Act_Capital, string PresentYear_Est_NetSale,
            string PresentYear_Est_NetProfit, string PresentYear_Est_Capital, string NextYear_Proj_NetSale, string NextYear_Proj_NetProfit,
            string NextYear_Proj_Capital)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.PastPerf_PYII_Act_NetSale = PastPerf_PYII_Act_NetSale;
            Loandata.PastPerf_PYII_Act_NetProfit = PastPerf_PYII_Act_NetProfit;
            Loandata.PastPerf_PYII_Act_Capital = PastPerf_PYII_Act_Capital;
            Loandata.PastPerf_PYI_Act_NetSale = PastPerf_PYI_Act_NetSale;
            Loandata.PastPerf_PYI_Act_NetProfit = PastPerf_PYI_Act_NetProfit;
            Loandata.PastPerf_PYI_Act_Capital = PastPerf_PYI_Act_Capital;
            Loandata.PresentYear_Est_NetSale = PresentYear_Est_NetSale;
            Loandata.PresentYear_Est_NetProfit = PresentYear_Est_NetProfit;
            Loandata.PresentYear_Est_Capital = PresentYear_Est_Capital;
            Loandata.NextYear_Proj_NetSale = NextYear_Proj_NetSale;
            Loandata.NextYear_Proj_NetProfit = NextYear_Proj_NetProfit;
            Loandata.NextYear_Proj_Capital = NextYear_Proj_Capital;

            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);


            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string SatutoryInfo(string SatutoryObl_Reg_Shop, string SatutoryObl_Reg_ShopRemark, string SatutoryObl_Reg_MSME,
            string SatutoryObl_Reg_MSMERemark, string SatutoryObl_DrugLicense, string SatutoryObl_DrugLicense_Remark, string SatutoryObl_SaleReturn_File,
            string SatutoryObl_SaleReturn_File_Remark, string SatutoryObl_ITReturn_File, string SatutoryObl_ITReturn_File_Remark,
            string SatutoryObl_Dues_Remain, string SatutoryObl_Dues_RemainRemark)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.SatutoryObl_Reg_Shop = SatutoryObl_Reg_Shop;
            Loandata.SatutoryObl_Reg_ShopRemark = SatutoryObl_Reg_ShopRemark;
            Loandata.SatutoryObl_Reg_MSME = SatutoryObl_Reg_MSME;
            Loandata.SatutoryObl_Reg_MSMERemark = SatutoryObl_Reg_MSMERemark;
            Loandata.SatutoryObl_DrugLicense = SatutoryObl_DrugLicense;
            Loandata.SatutoryObl_DrugLicense_Remark = SatutoryObl_DrugLicense_Remark;
            Loandata.SatutoryObl_SaleReturn_File = SatutoryObl_SaleReturn_File;
            Loandata.SatutoryObl_SaleReturn_File_Remark = SatutoryObl_SaleReturn_File_Remark;
            Loandata.SatutoryObl_ITReturn_File = SatutoryObl_ITReturn_File;
            Loandata.SatutoryObl_ITReturn_File_Remark = SatutoryObl_ITReturn_File_Remark;
            Loandata.SatutoryObl_Dues_Remain = SatutoryObl_Dues_Remain;
            Loandata.SatutoryObl_Dues_RemainRemark = SatutoryObl_Dues_RemainRemark;

            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);


            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string BankInfo(string Bank, string Bank_Branch, string Branch_ID)
        {
            PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
            Loandata.Bank = Bank;
            Loandata.Bank_Branch = Bank_Branch;
            
            

            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(Loandata.GetType());
            serializer.Serialize(stringwriter, Loandata);

            XmlDocument xml = new XmlDocument();

            xml.LoadXml(stringwriter.ToString());
            XmlNodeList nodes = xml.SelectNodes("PMMYLoanForm");
            //xml.ChildNodes[0].RemoveAll();
            foreach (XmlNode node in nodes)
            {
                //node.ParentNode.RemoveChild(node);
                node.Attributes.RemoveNamedItem("xmlns:xsi");
                node.Attributes.RemoveNamedItem("xmlns:xsd");
            }
            string strxml = xml.ChildNodes[1].OuterXml;



            //string xml = "&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&lt;PMMYLoanForm xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;&lt;BusiInfo_Enterprise_Name&gt;xgsdgsdgsdg&lt;/BusiInfo_Enterprise_Name&gt;&lt;BusiInfo_Constitution&gt;Partnership&lt;/BusiInfo_Constitution&gt;&lt;BusiInfo_Curr_Address&gt;sdgsdg&lt;/BusiInfo_Curr_Address&gt;&lt;BusiInfo_Pincode&gt;dgsdg&lt;/BusiInfo_Pincode&gt;&lt;BusiInfo_State&gt;sgsgdg&lt;/BusiInfo_State&gt;&lt;BusiInfo_District&gt;sdgsgsd&lt;/BusiInfo_District&gt;&lt;BusiInfo_Location&gt;Choose your option&lt;/BusiInfo_Location&gt;&lt;BusiInfo_Premises&gt;Owned&lt;/BusiInfo_Premises&gt;&lt;BusiInfo_Mobile&gt;sdgsdf&lt;/BusiInfo_Mobile&gt;&lt;BusiInfo_Email&gt;s@y.com&lt;/BusiInfo_Email&gt;&lt;BusiInfo_Act_Existing&gt;dfhdfh&lt;/BusiInfo_Act_Existing&gt;&lt;BusiInfo_Act_Proposed&gt;fhghgh&lt;/BusiInfo_Act_Proposed&gt;&lt;BusiInfo_Commencement_Dt&gt;10-Jun-2018&lt;/BusiInfo_Commencement_Dt&gt;&lt;BusiInfo_IsUnitReg&gt;Yes&lt;/BusiInfo_IsUnitReg&gt;&lt;BusiInfo_Reg_Number&gt;fghfhgh&lt;/BusiInfo_Reg_Number&gt;&lt;BusiInfo_Resi_Address&gt;hgh&lt;/BusiInfo_Resi_Address&gt;&lt;BusiInfo_Social_Cat&gt;Minority Community&lt;/BusiInfo_Social_Cat&gt;&lt;BusiInfo_MonorityComm&gt;Jains&lt;/BusiInfo_MonorityComm&gt;&lt;Partner_Name&gt;bvxcbvbv&lt;/Partner_Name&gt;&lt;Partner_DOB&gt;10-Jun-2018&lt;/Partner_DOB&gt;&lt;Partner_Gender&gt;Male&lt;/Partner_Gender&gt;&lt;Partner_Resi_Address&gt;thdf&lt;/Partner_Resi_Address&gt;&lt;Partner_Mobile&gt;hdfhdfh&lt;/Partner_Mobile&gt;&lt;Partner_Qualification&gt;dfhdfh&lt;/Partner_Qualification&gt;&lt;Partner_Exp&gt;dfhdfh&lt;/Partner_Exp&gt;&lt;Partner_ID_Proof&gt;Aadhar&lt;/Partner_ID_Proof&gt;&lt;Partner_ID_Number&gt;dfhdfh&lt;/Partner_ID_Number&gt;&lt;Partner_Addr_Proof&gt;Aadhar&lt;/Partner_Addr_Proof&gt;&lt;Partner_AddrProof_Num&gt;dhdfh&lt;/Partner_AddrProof_Num&gt;&lt;Partner_PAN_DIN_Num&gt;dfhdfh&lt;/Partner_PAN_DIN_Num&gt;&lt;Partner_Relation&gt;dhdfhdfh&lt;/Partner_Relation&gt;&lt;Associate_Name&gt;vdfdgdf&lt;/Associate_Name&gt;&lt;Associate_Addr&gt;dgsdgfgf&lt;/Associate_Addr&gt;&lt;Associate_Present_Banking&gt;dghdgdf&lt;/Associate_Present_Banking&gt;&lt;Associate_Nature&gt;dgdfgd&lt;/Associate_Nature&gt;&lt;Associate_Interest&gt;dgdf&lt;/Associate_Interest&gt;&lt;Associate_Relation&gt;dgdfgd&lt;/Associate_Relation&gt;&lt;CR_Exist_SA_Banking&gt;dfhdf&lt;/CR_Exist_SA_Banking&gt;&lt;CR_Exist_SA_Outstanding /&gt;&lt;CR_Exist_SA_Status&gt;dghdfg&lt;/CR_Exist_SA_Status&gt;&lt;CR_Exist_CA_Banking&gt;dgdgdfgf&lt;/CR_Exist_CA_Banking&gt;&lt;CR_Exist_CA_Outstanding&gt;dfgdfgdf&lt;/CR_Exist_CA_Outstanding&gt;&lt;CR_Exist_CA_Status&gt;dfgdfgdfgd&lt;/CR_Exist_CA_Status&gt;&lt;CR_Exist_CC_Banking&gt;dfgdg&lt;/CR_Exist_CC_Banking&gt;&lt;CR_Exist_CC_LimitAvailed&gt;hjfgjf&lt;/CR_Exist_CC_LimitAvailed&gt;&lt;CR_Exist_CC_Outstanding&gt;sdfsfsd&lt;/CR_Exist_CC_Outstanding&gt;&lt;CR_Exist_CC_SecurityLodg&gt;jfgjf&lt;/CR_Exist_CC_SecurityLodg&gt;&lt;CR_Exist_CC_Status&gt;jdfdfjdf&lt;/CR_Exist_CC_Status&gt;&lt;CR_Exist_TL_Banking&gt;dfhjdfdfh&lt;/CR_Exist_TL_Banking&gt;&lt;CR_Exist_TL_LimitAvailed&gt;dfhdfhd&lt;/CR_Exist_TL_LimitAvailed&gt;&lt;CR_Exist_TL_Outstanding&gt;dhdffdfh&lt;/CR_Exist_TL_Outstanding&gt;&lt;CR_Exist_TL_SecurityLodg&gt;dhdfhdfh&lt;/CR_Exist_TL_SecurityLodg&gt;&lt;CR_Exist_TL_Status&gt;dhdfhdfh&lt;/CR_Exist_TL_Status&gt;&lt;CR_Exist_LGBG_Banking&gt;dhdfhd&lt;/CR_Exist_LGBG_Banking&gt;&lt;CR_Exist_LGBG_Limit&gt;hjghjff&lt;/CR_Exist_LGBG_Limit&gt;&lt;CR_Exist_LGBG_Outstanding&gt;dfdfhdh&lt;/CR_Exist_LGBG_Outstanding&gt;&lt;CR_Exist_LGBG_SecurityLodg&gt;dfhdfhdf&lt;/CR_Exist_LGBG_SecurityLodg&gt;&lt;CR_Exist_LGBG_Status&gt;dfhdfhdf&lt;/CR_Exist_LGBG_Status&gt;&lt;CR_Prop_CC_Amount&gt;dhdfhdfh&lt;/CR_Prop_CC_Amount&gt;&lt;CR_Prop_CC_Purpose&gt;dhdfhfh&lt;/CR_Prop_CC_Purpose&gt;&lt;CR_Prop_CC_SecurityOffer&gt;dfhdfhdf&lt;/CR_Prop_CC_SecurityOffer&gt;&lt;CR_Prop_TL_Amount&gt;dhdfhdfhfh&lt;/CR_Prop_TL_Amount&gt;&lt;CR_Prop_TL_Purpose&gt;dfhdfhdfh&lt;/CR_Prop_TL_Purpose&gt;&lt;CR_Prop_TL_SecurityOffer&gt;dhdfhdfhdfh&lt;/CR_Prop_TL_SecurityOffer&gt;&lt;CR_Prop_LGBG_Amount&gt;dhdfhdfh&lt;/CR_Prop_LGBG_Amount&gt;&lt;CR_Prop_LGBG_Purpose&gt;dfhdfhdf&lt;/CR_Prop_LGBG_Purpose&gt;&lt;CR_Prop_LGBG_SecurityOffer&gt;dfhdfhfh&lt;/CR_Prop_LGBG_SecurityOffer&gt;&lt;CCL_WC_ActSale_previousFY&gt;dhdhdfhdfh&lt;/CCL_WC_ActSale_previousFY&gt;&lt;CCL_WC_ActSale_currFY&gt;dfhdhfdfh&lt;/CCL_WC_ActSale_currFY&gt;&lt;CCL_WC_Proj_Sale&gt;dfhdfhdh&lt;/CCL_WC_Proj_Sale&gt;&lt;CCL_WC_Proj_Cycle&gt;dfhdfh&lt;/CCL_WC_Proj_Cycle&gt;&lt;CCL_WC_Proj_Inventory&gt;dhdfh&lt;/CCL_WC_Proj_Inventory&gt;&lt;CCL_WC_Proj_Debtors&gt;dfhdfh&lt;/CCL_WC_Proj_Debtors&gt;&lt;CCL_WC_Proj_Creditors&gt;dfhdfhd&lt;/CCL_WC_Proj_Creditors&gt;&lt;CCL_WC_Proj_Promot_Contri&gt;dfhdfhdfh&lt;/CCL_WC_Proj_Promot_Contri&gt;&lt;CCL_WC_Proj_Limit&gt;ghg&lt;/CCL_WC_Proj_Limit&gt;&lt;CCL_TL_MachineEquip&gt;dfhydey&lt;/CCL_TL_MachineEquip&gt;&lt;CCL_TL_Purpose&gt;ryerye&lt;/CCL_TL_Purpose&gt;&lt;CCL_TL_SupplierName&gt;cdhc&lt;/CCL_TL_SupplierName&gt;&lt;CCL_TL_MachineCost&gt;chdfhdfh&lt;/CCL_TL_MachineCost&gt;&lt;CCL_TL_Promote_Contri&gt;dfhdfhdfh&lt;/CCL_TL_Promote_Contri&gt;&lt;CCL_TL_Loan_Req&gt;dhdfhdf&lt;/CCL_TL_Loan_Req&gt;&lt;CCL_TL_Repayment_Period&gt;dhdfdf&lt;/CCL_TL_Repayment_Period&gt;&lt;PastPerf_PYII_Act_NetSale&gt;klhjsdkl&lt;/PastPerf_PYII_Act_NetSale&gt;&lt;PastPerf_PYII_Act_NetProfit&gt;kjhjkhjkh&lt;/PastPerf_PYII_Act_NetProfit&gt;&lt;PastPerf_PYII_Act_Capital&gt;kjhjkhjkhjk&lt;/PastPerf_PYII_Act_Capital&gt;&lt;PastPerf_PYI_Act_NetSale&gt;kjghkjhjkhjk&lt;/PastPerf_PYI_Act_NetSale&gt;&lt;PastPerf_PYI_Act_NetProfit&gt;kjhjkhjkhjkh&lt;/PastPerf_PYI_Act_NetProfit&gt;&lt;PastPerf_PYI_Act_Capital&gt;kjhjkhjkhjkhjkh&lt;/PastPerf_PYI_Act_Capital&gt;&lt;PresentYear_Est_NetSale&gt;kjghjkhjkhjkh&lt;/PresentYear_Est_NetSale&gt;&lt;PresentYear_Est_NetProfit&gt;kjhjkhjkhjk&lt;/PresentYear_Est_NetProfit&gt;&lt;PresentYear_Est_Capital&gt;kjghjkhjkhjkh&lt;/PresentYear_Est_Capital&gt;&lt;NextYear_Proj_NetSale&gt;kjhjkhjkhjk&lt;/NextYear_Proj_NetSale&gt;&lt;NextYear_Proj_NetProfit&gt;hjgfghfgh&lt;/NextYear_Proj_NetProfit&gt;&lt;NextYear_Proj_Capital&gt;uiytyutyu&lt;/NextYear_Proj_Capital&gt;&lt;SatutoryObl_Reg_Shop&gt;Yes&lt;/SatutoryObl_Reg_Shop&gt;&lt;SatutoryObl_Reg_ShopRemark&gt;ghgfj&lt;/SatutoryObl_Reg_ShopRemark&gt;&lt;SatutoryObl_Reg_MSME&gt;Yes&lt;/SatutoryObl_Reg_MSME&gt;&lt;SatutoryObl_Reg_MSMERemark&gt;dhdfhdfh&lt;/SatutoryObl_Reg_MSMERemark&gt;&lt;SatutoryObl_DrugLicense&gt;No&lt;/SatutoryObl_DrugLicense&gt;&lt;SatutoryObl_DrugLicense_Remark&gt;dfhdfhfh&lt;/SatutoryObl_DrugLicense_Remark&gt;&lt;SatutoryObl_SaleReturn_File&gt;No&lt;/SatutoryObl_SaleReturn_File&gt;&lt;SatutoryObl_SaleReturn_File_Remark&gt;dfhfdhdh&lt;/SatutoryObl_SaleReturn_File_Remark&gt;&lt;SatutoryObl_ITReturn_File&gt;Yes&lt;/SatutoryObl_ITReturn_File&gt;&lt;SatutoryObl_ITReturn_File_Remark&gt;dfhdfhfh&lt;/SatutoryObl_ITReturn_File_Remark&gt;&lt;SatutoryObl_Dues_Remain&gt;No&lt;/SatutoryObl_Dues_Remain&gt;&lt;SatutoryObl_Dues_RemainRemark&gt;dfhdfhfhf&lt;/SatutoryObl_Dues_RemainRemark&gt;&lt;Bank&gt;Select Bank&lt;/Bank&gt;&lt;Bank_Branch&gt;Select Branch&lt;/Bank_Branch&gt;&lt;/PMMYLoanForm&gt;";
            //string xml = "<? xml version = \"1.0\" encoding = \"utf-16\" ?>< PMMYLoanForm xmlns:xsi = \"http://www.w3.org/2001/XMLSchema-instance\" xmlns: xsd = \"http://www.w3.org/2001/XMLSchema\" >< BusiInfo_Enterprise_Name > xgsdgsdgsdg </ BusiInfo_Enterprise_Name >< BusiInfo_Constitution > Partnership </ BusiInfo_Constitution >< BusiInfo_Curr_Address > sdgsdg </ BusiInfo_Curr_Address ></ PMMYLoanForm >";
            //string xml = "<?xmlversion="1.0"standalone="yes"?><Customers><CustomerId ="1"><Name>John Hammond</Name><Country>United States</Country></Customer><CustomerId = "2"><Name>Mudassar Khan</Name><Country>India</Country></Customer><CustomerId ="3"><Name>Suzanne Mathews</Name><Country>France</Country></Customer><CustomerId ="4"><Name>Robert Schidner</Name><Country>Russia</Country></Customer></Customers>";
            //string xml = File.ReadAllText("C:\\Users\\Mantralaya\\Desktop\\asdf.xml");

            BL.BL MOLDBAccess;
            MOLDBAccess = new BL.BL(System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString());
            string constr = System.Configuration.ConfigurationManager.AppSettings["APPID"].ToString();
            HttpContext.Current.Session["Application_ID"] = "";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("InsertXMLFile1"))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@xml", strxml);

                        SqlParameter outPutParameter = new SqlParameter();
                        outPutParameter.ParameterName = "@appId";
                        outPutParameter.SqlDbType = System.Data.SqlDbType.NVarChar;
                        outPutParameter.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(outPutParameter);

                        con.Open();
                        int result = (int)MOLDBAccess.ExecuteNonQuery(cmd);
                        //cmd.ExecuteNonQuery();
                        string ApplID = outPutParameter.Value.ToString();
                        HttpContext.Current.Session["Application_ID"] = ApplID;
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                string ds = ex.Message + "---" + ex.StackTrace;
            }
            HttpContext.Current.Session["Loan"] = Loandata;
            return "hello";
        }

        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public static string SubmitInfo(string Bank, string Bank_Branch)
        //{
        //    PMMYLoanForm Loandata = (PMMYLoanForm)HttpContext.Current.Session["Loan"];
        //    //HttpContext.Current.Response.Redirect("LoanApplicationFormPMMYA.aspx");
        //    HttpContext.Current.Session["Loan"] = Loandata;
        //    return "LoanApplicationFormPMMYA.aspx";
        //}

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static List<CountryList> GetLocations(string type, string id, string Branch)
        {

            string conString = System.Configuration.ConfigurationManager.AppSettings["Constr"].ToString();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            List<CountryList> lst = new List<CountryList>();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[Get_LocationDetails]";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Branch", Branch);
                cmd.CommandTimeout = 1000;
                
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    cmd.Connection = con;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        lst.Add(new CountryList
                        {
                            Name = Convert.ToInt32(row["ID"]),
                            Value = row["VALUE"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                //string ds = ex.Message + "---" + ex.StackTrace;
            }
            
            return lst;

        }

        public T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }

    public class CountryList
    {
        public int Name { get; set; }
        public string Value { get; set; }
    }
    
}
