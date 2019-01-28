using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Schema;
using BL;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Collections;
using Helper;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace PMMYA.Site.Home
{
    public partial class FrmPMMYLoanForm : System.Web.UI.Page
    {

        #region Public variable declaration
        ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
        ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
        Feedback_BL objFeedback_BL = new Feedback_BL();
        FeddbackSchema objFeedback_Schema = new FeddbackSchema();
        DataTable dt;
        DataSet ds, ds_taluka, ds_branch, ds_bank, ds_minority;
        MAHAITUserControl _MahaITUC = new MAHAITUserControl();
        #endregion


        protected void Page_PreRender(Object o, EventArgs e)
        {
            
            lblApplicationHeading.Text = _MahaITUC.GetResourceValue("Common", "lblApplicationHeading", "");
            lblAccountLoanType.Text = _MahaITUC.GetResourceValue("Common", "lblAccountLoanType", "");
            lblAddproof.Text = _MahaITUC.GetResourceValue("Common", "lblAddproof", "");
            lblAdharNo.Text = _MahaITUC.GetResourceValue("Common", "lblAdharNo", "");
            lblAge.Text = _MahaITUC.GetResourceValue("Common", "lblAge", "");
            lblAmount.Text = _MahaITUC.GetResourceValue("Common", "lblAmount", "");
            lblAnyother.Text = _MahaITUC.GetResourceValue("Common", "lblAnyother", "");
            lblApplicantName.Text = _MahaITUC.GetResourceValue("Common", "lblApplicantName", "");
            lblAppName1.Text = _MahaITUC.GetResourceValue("Common", "lblAppName1", "");
            lblAppName2.Text = _MahaITUC.GetResourceValue("Common", "lblAppName2", "");
            lblBankAdd.Text = _MahaITUC.GetResourceValue("Common", "lblBankAdd", "");
            lblBankDetails.Text = _MahaITUC.GetResourceValue("Common", "lblBankDetails", "");
            lblBankIFSC.Text = _MahaITUC.GetResourceValue("Common", "lblBankIFSC", "");
            lblBankName.Text = _MahaITUC.GetResourceValue("Common", "lblBankName", "");
            lblBranch.Text = _MahaITUC.GetResourceValue("Common", "lblBranch", "");
            lblBusiness.Text = _MahaITUC.GetResourceValue("Common", "lblBusiness", "");
            lblBusinessActivity.Text = _MahaITUC.GetResourceValue("Common", "lblBusinessActivity", "");
            lblBusinessAddType.Text = _MahaITUC.GetResourceValue("Common", "lblBusinessAddType", "");
            lblConstitution.Text = _MahaITUC.GetResourceValue("Common", "lblConstitution", "");
            lblDistrict.Text = _MahaITUC.GetResourceValue("Common", "lblDistrict", "");
            lblDLNo.Text = _MahaITUC.GetResourceValue("Common", "lblDLNo", "");
            lblDistrict.Text = _MahaITUC.GetResourceValue("Common", "lblDistrict", "");
            lblDOB.Text = _MahaITUC.GetResourceValue("Common", "lblDOB", "");
            lblEmail.Text = _MahaITUC.GetResourceValue("Common", "lblEmail", "");
            LblExistingAcc.Text = _MahaITUC.GetResourceValue("Common", "LblExistingAcc", "");
            lblExperience.Text = _MahaITUC.GetResourceValue("Common", "lblExperience", "");
            lblFather.Text = _MahaITUC.GetResourceValue("Common", "lblFather", "");
            lblIDproof.Text = _MahaITUC.GetResourceValue("Common", "lblIDproof", "");
            lblKYC.Text = _MahaITUC.GetResourceValue("Common", "lblKYC", "");
            lblKycHeading.Text = _MahaITUC.GetResourceValue("Common", "lblKycHeading", "");
            lblLineofBusiness.Text = _MahaITUC.GetResourceValue("Common", "lblLineofBusiness", "");
            LblLoan.Text = _MahaITUC.GetResourceValue("Common", "LblLoan", "");
            lblLoanType.Text = _MahaITUC.GetResourceValue("Common", "lblLoanType", "");
            lblminority.Text = _MahaITUC.GetResourceValue("Common", "lblminority", "");
            lblMobile.Text = _MahaITUC.GetResourceValue("Common", "lblMobile", "");
            lblperiod.Text = _MahaITUC.GetResourceValue("Common", "lblperiod", "");
            lblQualification.Text = _MahaITUC.GetResourceValue("Common", "lblQualification", "");
            lblResidentialAddress.Text = _MahaITUC.GetResourceValue("Common", "lblResidentialAddress", "");
            lblResidenttype.Text = _MahaITUC.GetResourceValue("Common", "lblResidenttype", "");
            lblSalesExisting.Text = _MahaITUC.GetResourceValue("Common", "lblSalesExisting", "");
            lblSalesProposed.Text = _MahaITUC.GetResourceValue("Common", "lblSalesProposed", "");
            lblsex.Text = _MahaITUC.GetResourceValue("Common", "lblsex", "");
            lblSocialCategory.Text = _MahaITUC.GetResourceValue("Common", "lblSocialCategory", "");
            lblTaluka.Text = _MahaITUC.GetResourceValue("Common", "lblTaluka", "");
            lblTelephone.Text = _MahaITUC.GetResourceValue("Common", "lblTelephone", "");
            lblVoterId.Text = _MahaITUC.GetResourceValue("Common", "lblVoterId", "");
            lblBusinessAddress.Text = _MahaITUC.GetResourceValue("Common", "lblBusinessAddress", "");
            lblAccountNumber.Text = _MahaITUC.GetResourceValue("Common", "lblAccountNumber", "");
            lblExistingAccType.Text = _MahaITUC.GetResourceValue("Common", "lblExistingAccType", "");
            LblExistingBank.Text = _MahaITUC.GetResourceValue("Common", "LblExistingBank", "");
            LblExistingLoanAmount.Text = _MahaITUC.GetResourceValue("Common", "LblExistingLoanAmount", "");
            lblcaptchaText.Text= _MahaITUC.GetResourceValue("Common", "lblcaptchaText", "");
            lblNote.Text = _MahaITUC.GetResourceValue("Common", "lblNote", "");
            Lblcaptcha.Text = _MahaITUC.GetResourceValue("Common", "Lblcaptcha", "");
            btnSubmit.Text = _MahaITUC.GetResourceValue("Common", "btnSubmit", "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hiddenApplicationId.Value = "";
                BindLoanType();
                BindDistrict();
                BindConstitution();
                BindAddressType();
                BindGender();
                BindEducationQualification();
                // BindProofType();
                // BindKYCDocument();
                BindSocialCategory();
                BindLineofBusiness();
                BindTypeofExistingAccount();
                BindProofType();
                objApplicationFormSchema.ApplicantSessionid = System.Web.HttpContext.Current.Session.SessionID;
                ds = objApplicationFormBAL.GetApplicantDetails(objApplicationFormSchema);
                if (ds != null && (ds.Tables[0].Rows.Count > 0))
                {
                    dt = ds.Tables[0];
                    TxtApplicantName1.Text = dt.Rows[0]["Name"].ToString();
                    //txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                    TxtMobile.Text = dt.Rows[0]["MobileNo"].ToString();
                    TxtEmail.Text = dt.Rows[0]["EmailID"].ToString();
                    //ddlLoanType.SelectedValue = dt.Rows[0]["LoanType"].ToString();
                    // ddlLoanType.Items.FindByValue(dt.Rows[0]["LoanType"].ToString()).Selected = true;
                }
            }
        }


        //protected void ddlSocialCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        objApplicationFormSchema.ID = Convert.ToInt32(ddlSocialCategory.SelectedValue);
        //        objApplicationFormSchema.Type = "MinorityCommunity";
        //        ds = new DataSet();
        //        ds = objApplicationFormBAL.GetMinorityCommunityDetails(objApplicationFormSchema);
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            ddlMinority.Items.Clear();
        //            ddlMinority.DataSource = ds;
        //            ddlMinority.DataTextField = "MinorityCommunityName";
        //            ddlMinority.DataValueField = "ID";
        //            ddlMinority.DataBind();
        //            ddlMinority.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlMinority.SelectedValue = "0";

        //        }
        //        else
        //        {
        //            ddlMinority.Items.Clear();
        //            ddlMinority.Items.Insert(0, new ListItem("--Select--", "0"));
        //            ddlMinority.SelectedValue = "0";
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string msg = string.Empty;
                int conuter = 0;

                if (ddlLoanType.SelectedValue == "0")
                {
                  
                    msg += _MahaITUC.GetResourceValue("Common", "ErrorddlLoanType", "");
                    //msg += "-Please Select Type of Loan.\\n";
                    conuter = 1;
                }

                if (ddlLoanAccountType.SelectedValue == "0")
                {
                    //msg += "<br /> -Please Select Loan Account Type.";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlLoanAccountType", "");
                    conuter = 1;
                }

                if (txtAmount.Text == "" && txtAmount.Text != null)
                {
                    //msg += "<br /> -Please Enter Loan Amount.\\n";
                    msg += "<br />"+ _MahaITUC.GetResourceValue("Common", "ErrortxtNubmer", "") ;
                    conuter = 1;
                }

                if (txtAmount.Text != null)
                {

                    if (ddlLoanType.SelectedValue == "1" &&(Convert.ToInt32(txtAmount.Text) > 50000))
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtLoanShishu", "");
                        conuter = 1;
                    }

                    if (ddlLoanType.SelectedValue == "2")
                    {
                        if ((Convert.ToInt32(txtAmount.Text) < 50000) || (Convert.ToInt32(txtAmount.Text) > 500000))
                        {
                            msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtLoanKishore", "");
                            conuter = 1;
                        }
                    }

                    if (ddlLoanType.SelectedValue == "3")
                    {
                        if ((Convert.ToInt32(txtAmount.Text) < 500000) || (Convert.ToInt32(txtAmount.Text) > 1000000))
                        {
                            msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtLoanTarun", "");
                            conuter = 1;
                        }
                    }

                }

                    if (ddldistrict.SelectedValue == "0")
                {
                    // msg += "<br /> -Please Select District.";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "Errorddldistrict", "");
                    conuter = 1;
                }
                if (hdnTaluka.Value == "0")
                {
                    //msg += "<br /> -Please Select Taluka.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlTaluka", "");
                    conuter = 1;
                }
                //else
                //{
                //    ddlTaluka.SelectedValue = hdnTaluka.Value;
                //}
                if (hdnBankId.Value == "0")
                {
                    //msg += "<br /> -Please Select Bank Name.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlBankName", "");
                    conuter = 1;
                }


                if (hdnBranchName.Value == "" && hdnBranchName.Value != null)
                {
                    //msg += "<br /> -Please Select Branch Name.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlBranchname", "");
                    conuter = 1;
                }

                if (TxtIFSC.Text == "" && TxtIFSC.Text != null)
                {
                    //msg += "<br /> -Please Enter IFSC Code.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtIFSC", "");
                    conuter = 1;
                }

                if (TxtBankAddress.Text == "" && TxtBankAddress.Text != null)
                {
                    //msg += "<br /> -Please Enter Bank Address.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtBankAddress", "");
                    conuter = 1;
                }

                if (TxtApplicantName1.Text == "" && TxtApplicantName1.Text != null)
                {
                    //msg += "<br /> -Please Enter 1 Applicant Name.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtApplicantName1", "");
                    conuter = 1;
                }
                if (TxtFatherName.Text == "" && TxtFatherName.Text != null)
                {
                    //msg += "<br /> -Please Enter Father/Husband Name.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtFatherName", "");
                    conuter = 1;
                }

                if (ddlConstitution.SelectedValue == "0")
                {
                    //msg += "<br /> -Please Select Constitution.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlConstitution", "");
                    conuter = 1;
                }

                if (TxtResidentialAdd.Text == "" && TxtResidentialAdd.Text != null)
                {
                    //msg += "<br /> -Please Enter Residential Address.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtResidentialAdd", "");
                    conuter = 1;
                }

                if (ddlresidenttype.SelectedValue == "0")
                {
                    // msg += "<br /> -Please Select Residential Address Type.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "Errorddlresidenttype", "");
                    conuter = 1;
                }

                if (TxtBusinessAddress.Text == "" && TxtBusinessAddress.Text != null)
                {
                    // msg += "<br /> -Please Enter Business Address.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtBusinessAddress", "");
                    conuter = 1;
                }

                if (ddlBusinessAddType.SelectedValue == "0")
                {
                    // msg += "<br /> -Please Select Business Address Type.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlBusinessAddType", "");
                    conuter = 1;
                }

                if (TxtDOB.Text == "" && TxtDOB.Text != null)
                {
                    //msg += "<br /> -Please Enter Date of Birth.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtDOB", "");
                    conuter = 1;
                }

                if (TxtAge.Text == "" && TxtAge.Text != null)
                {
                    //msg += "<br /> -Please Enter Age.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtAge", "");
                    conuter = 1;
                }

                if (TxtAge.Text != "")
                {
                    if (Convert.ToInt32(TxtAge.Text) < 18)
                    {
                        //msg += "<br /> -Applicant Age Should be more than 18 years.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorMinorAge", "");
                        conuter = 1;
                    }
                    if (Convert.ToInt32(TxtAge.Text) > 125)
                    {
                        //msg += "<br /> -Applicant Age Should be not more than 125 years.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorMoreAge", "");
                        conuter = 1;
                    }
                }

                if (ddlGender.SelectedValue == "0")
                {
                    //msg += "<br /> -Please Select Sex.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlGender", "");
                    conuter = 1;
                }

                if (ddlQualification.SelectedValue == "0")
                {
                    //msg += "<br /> -Please Select Education Qualification.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlQualification", "");
                    conuter = 1;
                }

                if (ddlSocialCategory.SelectedValue == "0")
                {
                    //msg += "<br /> -Please Select Social Category.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlSocialCategory", "");
                    conuter = 1;
                }

                if (ddlSocialCategory.SelectedValue == "5")
                {
                    // if (ddlMinority.SelectedValue == "0")
                    if (HdnMinority.Value == "0")
                    {
                        //msg += "<br /> -Please Select Minority Category.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlMinority", "");
                        conuter = 1;
                    }
                }

                //if (TxtTelephone.Text == "" && TxtTelephone.Text != null)
                //{
                //    msg += "<br /> -Please Enter Telephone Number.\\n";
                //    conuter = 1;
                //}

                if (TxtTelephone.Text != "")
                {
                    if (TxtTelephone.Text.Length < 11)
                    {
                        //msg += "<br /> -Please Enter Valid  Telephone Number.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtTelephone", "");
                        conuter = 1;
                    }

                }

                if (TxtMobile.Text == "" && TxtMobile.Text != null)
                {
                    // msg += "<br /> -Please Enter Mobile Number.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtMobile", "");
                    conuter = 1;
                }

                if (TxtMobile.Text != "")
                {
                    Regex _MobileMatch = new Regex("^[789]\\d{9}$");
                    if (!_MobileMatch.IsMatch(TxtMobile.Text))
                    {
                        // msg += "<br /> -Please Enter Valid 10 digit Mobile Numer. Number Start with 7 or 8 or 9\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorValidMobile", "");
                        conuter = 1;
                    }
                }

                if (TxtEmail.Text == "" && TxtEmail.Text != null)
                {
                    //msg += "<br /> -Please Enter Email.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtEmail", "");
                    conuter = 1;
                }

                //if (TxtEmail.Text != "")
                //{
                //    Regex _EmailMatch = new Regex("/w + ([-+.']/w+)*@/w+([-.]/w+)*/./w+([-.]/w+)*");
                //    if (!_EmailMatch.IsMatch(TxtEmail.Text))
                //    {
                //        msg += "<br /> -Please Enter Valid Email Id.\\n";
                //        conuter = 1;
                //    }
                //}

                //if (TxtEmail.Text != "")
                //{


                //    Regex EmailMatch = new Regex("/^ ([/w -/.] +)@((/[[0-9]{1,3}/.[0-9]{1,3}/.[0-9]{1,3}/.)|(([/w -]+/.)+))([a - zA - Z]{2,4}|[0-9]{1,3})(/]?)$/");
                //    if (EmailMatch.IsMatch(TxtEmail.Text)) {

                //    }
                //    else {
                //       // txt += '<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorValidEmail") %>';
                //        //opt = 1;
                //        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorValidEmail", "");
                //        conuter = 1;
                //    }
                //}

                int idproofcount = 0;
                if (TxtIDproofVoterNo.Text == "" && TxtIDproofVoterNo.Text != null)
                {
                    idproofcount = idproofcount + 1;
                }
                if (TxtIDProofAadharNo.Text == "" && TxtIDProofAadharNo.Text != null)
                {
                    idproofcount += 1;
                }
                if (TxtIDproofDLN.Text == "" && TxtIDproofDLN.Text != null)
                {
                    idproofcount += 1;
                }
                if (TxtIdProofNumberAny.Text == "" && TxtIdProofNumberAny.Text != null)
                {
                    idproofcount += 1;
                }

                if (idproofcount == 4)
                {
                    //msg += "<br /> -Please Enter Atleast one ID Proof.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorAtleastIDPrrof", "");
                    conuter = 1;
                }

                int Addproofcount = 0;
                if (TxtAddproofVoterNo.Text == "" && TxtAddproofVoterNo.Text != null)
                {
                    Addproofcount = Addproofcount + 1;
                }
                if (TxtAddProofAadharNo.Text == "" && TxtAddProofAadharNo.Text != null)
                {
                    Addproofcount += 1;
                }
                if (TxtAddproofDLN.Text == "" && TxtAddproofDLN.Text != null)
                {
                    Addproofcount += 1;
                }
                if (TxtAddproofNumberAny.Text == "" && TxtAddproofNumberAny.Text != null)
                {
                    Addproofcount += 1;
                }

                if (Addproofcount == 4)
                {
                    //msg += "<br /> -Please Enter Atleast one Address Proof.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorAtleastAddressProof", "");
                    conuter = 1;
                }

                if (TxtIDProofAadharNo.Text != "")
                {
                    if (TxtIDProofAadharNo.Text.Length < 12)
                    {
                        //msg += "<br />  - Please Enter 12 Digit Aadhar Number for ID Proof.";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorAadhar12digitID", "");
                        conuter = 1;
                    }

                    var FieldIdAddharValue = TxtIDProofAadharNo.Text;
                    if (FieldIdAddharValue[0].ToString() == "0" || FieldIdAddharValue[0].ToString() == "1")
                    {
                        //msg += "<br />  - Please Enter Valid Aadhar Number for ID Proof.";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtIDProofAadharNo", "");
                        conuter = 1;
                    }
                }

                if (TxtAddProofAadharNo.Text != "")
                {
                    if (TxtAddProofAadharNo.Text.Length < 12)
                    {
                        //msg += "<br />  - Please Enter 12 Digit Aadhar Number for Address Proof.";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorAadhar12digitAdd", "");
                        conuter = 1;
                    }
                    var FieldAdddAddharValue = TxtAddProofAadharNo.Text;
                    if (FieldAdddAddharValue[0].ToString() == "0" || FieldAdddAddharValue[0].ToString() == "1")
                    {
                        // msg += "<br />  - Please Enter Valid Aadhar Number for Address Proof.";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtAddProofAadharNo", "");
                        conuter = 1;
                    }

                }


                if (TxtAddProofAadharNo.Text != "" && TxtIDProofAadharNo.Text != "")
                {
                    if (TxtIDProofAadharNo.Text != TxtAddProofAadharNo.Text)
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorAadharNoSame", "");
                        conuter = 1;

                    }
                   
                }

                if (TxtIDproofDLN.Text != "")
                {
                    if (TxtIDproofDLN.Text.Length < 16)
                    {
                        //msg += "<br />  - Please Enter 16 Digit Driving Licence Number for ID Proof.";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "Error16DigitDLID", "");
                        conuter = 1;
                    }

                    var FielDrivingLicenceValue = TxtIDproofDLN.Text;
                    if ((FielDrivingLicenceValue[0].ToString() != "M" && FielDrivingLicenceValue[1].ToString() != "H") && (FielDrivingLicenceValue[0].ToString() != "m" && FielDrivingLicenceValue[1].ToString() != "h"))
                    {
                        // msg += "<br />  - Please Enter Valid Driving Licence Number for ID Proof Number";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtIDproofDLN", "");
                        conuter = 1;
                    }

                    if (FielDrivingLicenceValue[4].ToString() != " ")
                    {
                        //msg += "<br />  - Please Enter Valid Driving Licence Number for ID Proof Number";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtIDproofDLN", "");
                        conuter = 1;
                    }

                }

                if (TxtAddproofDLN.Text != "")
                {
                    if (TxtAddproofDLN.Text.Length < 16)
                    {
                        // msg += "<br />  - Please Enter 16 Digit Driving Licence Number for Address Proof.";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "Error16DigitDLAddress", "");
                        conuter = 1;
                    }

                    var FielAddDrivingLicenceValue = TxtAddproofDLN.Text;
                    if ((FielAddDrivingLicenceValue[0].ToString() != "M" && FielAddDrivingLicenceValue[1].ToString() != "H") && (FielAddDrivingLicenceValue[0].ToString() != "m" && FielAddDrivingLicenceValue[1].ToString() != "h"))
                    {
                        //msg += "<br />  - Please Enter Valid Driving Licence Number for Address Proof Number";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtAddproofDLN", "");
                        conuter = 1;
                    }

                    if (FielAddDrivingLicenceValue[4].ToString() != " ")
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtAddproofDLN", "");
                        conuter = 1;
                    }

                }

                if (TxtIDproofDLN.Text != "" && TxtAddproofDLN.Text != "")
                {
                    if (TxtIDproofDLN.Text != TxtAddproofDLN.Text)
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorDLNoSame", "");
                        conuter = 1;
                    }
                }
                   

                if (TxtIDproofVoterNo.Text != "")
                {
                    if (TxtIDproofVoterNo.Text.Length < 10)
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "Error10DigitVoterID", "");
                        conuter = 1;
                    }
                   // var IDVotingMatch = /^[a - zA - Z]{ 3}[0-9]{7}$/;
                    //Regex _IDproofVotingNo= new Regex("/^[a-zA-Z]{3}[0-9]{7}$/");
                    Regex  IDVotingMatch = new Regex("/^[a-zA-Z]{3}[0-9]{7}$/");
                    if (!IDVotingMatch.IsMatch(TxtIDproofVoterNo.Text))
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtIDproofVoterNo", "");
                        conuter = 1;
                    }
                    //if (_IDproofVotingNo.IsMatch(TxtIDproofVoterNo.Text))
                    //{

                    //}
                    //else
                    //{
                    //    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtIDproofVoterNo", "");
                    //    conuter = 1;
                    //}
                }

                if (TxtAddproofVoterNo.Text != "")
                {
                    if (TxtAddproofVoterNo.Text.Length < 10)
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "Error10DigitVoterAddress", "");
                        conuter = 1;
                    }

                    Regex _AddproofVotingNo = new Regex("/^[a-zA-Z]{3}[0-9]{7}$/");
                    if (!_AddproofVotingNo.IsMatch(TxtAddproofVoterNo.Text))
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtAddproofVoterNo", "");
                        conuter = 1;
                    }
                }

                if (TxtIDproofVoterNo.Text != "" && TxtAddproofVoterNo.Text != "")
                {
                    if (TxtIDproofVoterNo.Text != TxtAddproofVoterNo.Text)
                    {
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorVoterNoSame", "");
                        conuter = 1;
                    }
                }



                if (TxtAddproofNameAny.Text != "" && TxtIdProofNumberAny.Text != "")
                    if (TxtIdProofNumberAny.Text != TxtAddproofNameAny.Text) {
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorOtherSame", "");
                    conuter = 1;
                }
                if (ddlLineofBusiness.SelectedValue == "0")
                {
                    // msg += "<br /> -Please Select Line of Business Activity.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlLineofBusiness", "");
                    conuter = 1;
                }

                if (ddlLineofBusiness.SelectedValue == "1")
                {
                    if (TxtPeriod.Text == "" && TxtPeriod.Text != null)
                    {
                        //msg += "<br /> - Please Enter Period.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtPeriod", "");
                        conuter = 1;
                    }

                }

                if (TxtSalesExisting.Text == "" && TxtSalesExisting.Text != null)
                {
                    //msg += "<br /> - Please Enter Annual Sales for Existing Business.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtSalesExisting", "");
                    conuter = 1;
                }

                if (TxtSalesProposed.Text == "" && TxtSalesProposed.Text != null)
                {
                    //msg += "<br /> - Please Enter Annual Sales for Proposed Business.\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtSalesProposed", "");
                    conuter = 1;
                }



                if (chkExistingAcc.Checked == true)
                {
                    if (ddlExistingAccType.SelectedValue == "0")
                    {
                        //msg += "<br /> -Please Select Account Type.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorddlExistingAccType", "");
                        conuter = 1;
                    }

                    if (TxtExistingBankName.Text == "" && TxtExistingBankName.Text != null)
                    {
                        //msg += "<br /> -Please Enter Name of Bank and Branch.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtExistingBankName", "");
                        conuter = 1;
                    }

                    if (TxtAccountNumber.Text == "" && TxtAccountNumber.Text != null)
                    {
                        //msg += "<br /> -Please Enter Account Number.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtAccountNumber", "");
                        conuter = 1;
                    }

                    if (TxtExistingLoanAmount.Text == "" && TxtExistingLoanAmount.Text != null)
                    {
                        // msg += "<br /> -Please Enter Amount of loan Taken.\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorValidAccount", "");
                        conuter = 1;
                    }

                }
                if (txtimgcode.Text == "" && txtimgcode.Text != null)
                {
                    //msg += "<br /> -Please enter captcha..\\n";
                    msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorTxtCaptcha", "");
                    conuter = 1;
                }
                if (txtimgcode.Text != "")
                {
                    if (txtimgcode.Text != RemoveSpace(hdnCaptcha.Value.Trim().ToString()))
                    {
                        //msg += "<br /> -Please enter valid captcha..\\n";
                        msg += "<br />" + _MahaITUC.GetResourceValue("Common", "ErrorValidCaptcha", "");
                        conuter = 1;
                    }
                }
                if (conuter == 0)
                {
                    #region Save And Get Application Id

                    objApplicationFormSchema.LoanTypeID = Convert.ToInt32(ddlLoanType.SelectedValue);
                    objApplicationFormSchema.LoanAmount = Convert.ToDouble(txtAmount.Text);
                    objApplicationFormSchema.Districtid = Convert.ToInt32(ddldistrict.SelectedValue);
                    objApplicationFormSchema.Talukaid = Convert.ToInt32(hdnTaluka.Value);
                    objApplicationFormSchema.Bankid = Convert.ToInt32(hdnBankId.Value);
                    objApplicationFormSchema.BranchName = Convert.ToString(hdnBranchName.Value);
                    objApplicationFormSchema.IFSCCode = TxtIFSC.Text;
                    objApplicationFormSchema.BranchAddress = TxtBankAddress.Text;
                    objApplicationFormSchema.FirstHolderName = TxtApplicantName1.Text;
                    objApplicationFormSchema.SecondHolderName = TxtApplicantName2.Text;
                    objApplicationFormSchema.FaterOrHusbandName = TxtFatherName.Text;
                    objApplicationFormSchema.ConstitutionID = Convert.ToInt32(ddlConstitution.SelectedValue);
                    objApplicationFormSchema.ResidentialAddress = TxtResidentialAdd.Text;
                    objApplicationFormSchema.ResiAddresID = Convert.ToInt32(ddlresidenttype.SelectedValue);
                    objApplicationFormSchema.BusinessAddress = TxtBusinessAddress.Text;
                    objApplicationFormSchema.BusiAddresID = Convert.ToInt32(ddlBusinessAddType.SelectedValue);
                    objApplicationFormSchema.DOB = Convert.ToDateTime(TxtDOB.Text);
                    objApplicationFormSchema.Age = Convert.ToInt32(TxtAge.Text);
                    objApplicationFormSchema.GenderID = Convert.ToInt32(ddlGender.SelectedValue);
                    objApplicationFormSchema.EducationID = Convert.ToInt32(ddlQualification.SelectedValue);
                    objApplicationFormSchema.KycID_VoterIDNo = TxtIDproofVoterNo.Text;
                    objApplicationFormSchema.KycID_AadharNo = TxtIDProofAadharNo.Text;
                    objApplicationFormSchema.KycID_DrivingLicNo = TxtIDproofDLN.Text;
                    objApplicationFormSchema.KycID_OtherIDNo = TxtIDProofNameAny.Text + "-" + TxtIdProofNumberAny.Text;
                    objApplicationFormSchema.KycAddr_VoterIDNo = TxtAddproofVoterNo.Text;
                    objApplicationFormSchema.KycAddr_AadharNo = TxtAddProofAadharNo.Text;
                    objApplicationFormSchema.KycAddr_DrivingLicNo = TxtAddproofDLN.Text;
                    objApplicationFormSchema.KycAddr_OtherIDNo = TxtAddproofNameAny.Text + "-" + TxtAddproofNumberAny.Text;
                    objApplicationFormSchema.TelPhNo = TxtTelephone.Text;
                    objApplicationFormSchema.MobileNo = TxtMobile.Text;
                    objApplicationFormSchema.EmailId = TxtEmail.Text;
                    objApplicationFormSchema.BusinessTypeID = Convert.ToInt32(ddlLineofBusiness.SelectedValue);
                    objApplicationFormSchema.ExtBusinessPeriod = Convert.ToInt32(TxtPeriod.Text);
                    objApplicationFormSchema.AnnualSaleExt = Convert.ToDouble(TxtSalesExisting.Text);
                    objApplicationFormSchema.AnnualSaleProp = Convert.ToDouble(TxtSalesProposed.Text);
                    objApplicationFormSchema.BusinessExperience = TxtExperience.Text;
                    objApplicationFormSchema.SocialCategoryID = Convert.ToInt32(ddlSocialCategory.SelectedValue);
                    objApplicationFormSchema.MinorityCategory = Convert.ToInt32(ddlMinority.SelectedValue);
                    objApplicationFormSchema.ISExistingAccount = chkExistingAcc.Checked;
                    objApplicationFormSchema.ExtAccountType = Convert.ToInt32(ddlExistingAccType.SelectedValue);
                    objApplicationFormSchema.ExtBankAccNo = TxtAccountNumber.Text;
                    objApplicationFormSchema.ExtBankName = TxtExistingBankName.Text;
                    objApplicationFormSchema.ExtLoanAmount = Convert.ToDouble(TxtExistingLoanAmount.Text);
                    objApplicationFormSchema.BankloanId = Convert.ToInt32(ddlLoanAccountType.SelectedValue);
                    objApplicationFormSchema.BusinessActivity = TxtBusinessActivity.Text;
                    //string record = objApplicationFormBAL.InsertLoanApplicationDetails(objApplicationFormSchema);
                    //string[] strArray = record.Split(';');
                    //if (strArray.Length == 2 && Convert.ToString(strArray[1]) == "Success")
                    //{
                    //    string Applicationid = string.Empty;
                    //    Applicationid = Convert.ToString(strArray[0]);
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Data saved Successfully. Your Application ID -'" + Applicationid + "');window.location.href='FrmPMMYLoanForm.aspx'", true);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                    //}
                    //ds = objApplicationFormBAL.SaveAndGetApplicantID(objApplicationFormSchema);
                    //if (ds != null && ds.Tables[0].Rows.Count > 0)
                    //{
                    string record = objApplicationFormBAL.InsertLoanApplicationDetails(objApplicationFormSchema);
                    string[] strArray = record.Split(';');
                    if (strArray.Length == 2 && Convert.ToString(strArray[1]) == "Success")
                    { 
                        string Applicationid = string.Empty;
                        //dt = ds.Tables[0];
                        // Applicationid = dt.Rows[0]["ApplicationID"].ToString();
                        Applicationid = Convert.ToString(strArray[0]);
                        string sucessmsg = "Data saved Successfully. Your Application ID -" + Applicationid;
                        hiddenApplicationId.Value = Applicationid;
                        lblSuccessMsg.Text = sucessmsg;
                        resetcontrols();

                        if (objApplicationFormSchema.LoanTypeID == 1)
                        {
                            string redirectScript = " window.location.href ='FrmShishu.aspx?ApplicationId=" + Applicationid + "'";
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alertPopup('Kindly enter data in below fields.','" + sucessmsg + "');" + redirectScript, true);
                        }
                        else
                        {
                            string redirectScript = " window.location.href ='FrmKishor.aspx?ApplicationId=" + Applicationid + "'";
                            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alertPopup('Kindly enter data in below fields.','" + sucessmsg + "');" + redirectScript, true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error Occured while saving data.')", true);
                    }
                    #endregion
                }
                else
                {
                    //string redirectScript = " window.location.href ='FrmKishor.aspx?ApplicationId=" + Applicationid + "'";
                    //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('" + sucessmsg + "');" + redirectScript, true);
                    //alertPopup("Kindly enter data in below fields.", txt);
                    string msgheader= _MahaITUC.GetResourceValue("Common", "ErrorHeader", "");
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alertPopup('"+ msgheader + "','" + msg + "');", true);

                    objApplicationFormSchema.Districtid = Convert.ToInt32(ddldistrict.SelectedValue);
                    objApplicationFormSchema.Talukaid = Convert.ToInt32(hdnTaluka.Value);

                    ds_taluka = objApplicationFormBAL.GetTaluka(objApplicationFormSchema);
                    if (ds_taluka != null)
                    {
                        ddlTaluka.Items.Clear();
                        ddlTaluka.DataSource = ds_taluka;
                        ddlTaluka.DataTextField = "SubDistrictname";
                        ddlTaluka.DataValueField = "SubDistrictcode";
                        ddlTaluka.DataBind();
                        ddlTaluka.Items.Insert(0, new ListItem("--Select--", "0"));
                        ddlTaluka.SelectedValue = hdnTaluka.Value;
                    }

                    ds_bank = objApplicationFormBAL.GetBankName(objApplicationFormSchema);
                    if (ds_bank != null)
                    {
                        ddlBankName.Items.Clear();
                        ddlBankName.DataSource = ds_bank;
                        ddlBankName.DataTextField = "BankName";
                        ddlBankName.DataValueField = "BankID";
                        ddlBankName.DataBind();
                        ddlBankName.Items.Insert(0, new ListItem("--Select--", "0"));
                        ddlBankName.SelectedValue = hdnBankId.Value;
                    }

                    objApplicationFormSchema.Bankid = Convert.ToInt32(hdnBankId.Value);
                    ds_branch = objApplicationFormBAL.GetBranchkName(objApplicationFormSchema);
                    if (ds_branch != null)
                    {
                        ddlBranchname.Items.Clear();
                        ddlBranchname.DataSource = ds_branch;
                        ddlBranchname.DataTextField = "BranchName";
                        ddlBranchname.DataValueField = "IFSCode";
                        ddlBranchname.DataBind();
                        ddlBranchname.Items.Insert(0, new ListItem("--Select--", "0"));

                        if (TxtIFSC.Text != "")
                        {
                            ddlBranchname.SelectedValue = TxtIFSC.Text;
                        }
                        else
                        {
                            ddlBranchname.SelectedValue = "0";
                        }
                 
                       
                    }

                    if (ddlSocialCategory.SelectedValue == "5")
                    {
                        objApplicationFormSchema.ID = Convert.ToInt32(ddlSocialCategory.SelectedValue); ;
                        objApplicationFormSchema.Type = "MinorityCommunity";
                        ds_minority = objApplicationFormBAL.GetMinorityCommunityDetails(objApplicationFormSchema);
                        if (ds_minority != null)
                        {
                            ddlMinority.Items.Clear();
                            ddlMinority.DataSource = ds_minority;
                            ddlMinority.DataTextField = "MinorityCommunityName";
                            ddlMinority.DataValueField = "ID";
                            ddlMinority.DataBind();
                            ddlMinority.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlMinority.SelectedValue = HdnMinority.Value;
                        }
                    }
                }
            }

            catch (Exception ee)
            {
                throw ee;
            }
        }

        private string RemoveSpace(string Captchastr)
        {
            StringBuilder sb = new StringBuilder();
            char[] longChars = Captchastr.ToCharArray();

            int spaceCount = 0;

            //Using standard method with no library help
            for (int i = 0; i < longChars.Length; i++)
            {
                //If space then keep a count and move on until nonspace char is found
                if (longChars[i] == 32)
                {
                    spaceCount++;
                    continue;
                }

                //If more than one space then append a single space  
                if (spaceCount > 1 && sb.Length > 0)
                    sb.Append("");

                //Append the non space character
                sb.Append(longChars[i]);

                //Reset the space count
                spaceCount = 1;
            }
            return sb.ToString();
        }

        public void ShowMessage_Redirect(System.Web.UI.Page page, string Message, string Redirect_URL)
        {
            string alertMessage = "<script language=\"javascript\" type=\"text/javascript\">";

            alertMessage += "alert('" + Message + "');";
            alertMessage += "window.location.href=\"";
            alertMessage += Redirect_URL;
            alertMessage += "\";";
            alertMessage += "</script>";

            ClientScript.RegisterClientScriptBlock(GetType(), "alertMessage ", alertMessage);

        }
        public void resetcontrols()
        {
            ddlLoanType.SelectedIndex = 0;
            ddlLoanAccountType.SelectedIndex = 0;
            txtAmount.Text = "";
            ddldistrict.SelectedIndex = 0;
            ddlTaluka.SelectedIndex = 0;
            ddlBankName.SelectedIndex = 0;
            ddlBranchname.SelectedIndex = 0;
            hdnTaluka.Value = "";
            hdnBankId.Value = "";
            hdnBranchName.Value = "";
            TxtIFSC.Text = "";
            TxtBankAddress.Text = "";
            TxtApplicantName1.Text = "";
            TxtApplicantName2.Text = "";
            TxtFatherName.Text = "";
            ddlConstitution.SelectedIndex = 0;
            TxtResidentialAdd.Text = "";
            ddlresidenttype.SelectedIndex = 0;
            TxtBusinessAddress.Text = "";
            ddlBusinessAddType.SelectedIndex = 0;
            TxtDOB.Text = "";
            TxtAge.Text = "";
            ddlGender.SelectedIndex = 0;
            ddlQualification.SelectedIndex = 0;
            TxtIDproofVoterNo.Text = "";
            TxtIDProofAadharNo.Text = "";
            TxtIDproofDLN.Text = "";
            TxtIDProofNameAny.Text = "";
            TxtIdProofNumberAny.Text = "";
            TxtAddproofVoterNo.Text = "";
            TxtAddProofAadharNo.Text = "";
            TxtAddproofDLN.Text = "";
            TxtAddproofNameAny.Text = "";
            TxtAddproofNumberAny.Text = "";
            TxtTelephone.Text = "";
            TxtMobile.Text = "";
            TxtEmail.Text = "";
            ddlLineofBusiness.SelectedIndex = 0;
            TxtPeriod.Text = "";
            TxtSalesExisting.Text = "";
            TxtSalesProposed.Text = "";
            TxtExperience.Text = "";
            ddlSocialCategory.SelectedIndex = 0;
            ddlMinority.SelectedIndex = 0;
            chkExistingAcc.Checked = false;
            ddlExistingAccType.SelectedIndex = 0;
            TxtAccountNumber.Text = "";
            TxtExistingBankName.Text = "";
            TxtExistingBankName.Text = "";
            txtimgcode.Text = "";
            hdnCaptcha.Value = "";
        }

        #region BindDropdown Data

        public void BindLoanType()
        {
            objApplicationFormSchema.Type = "LoanType";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetLoanTypeDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlLoanType.DataSource = ds;
                ddlLoanType.DataTextField = "MudraLoanType";
                ddlLoanType.DataValueField = "ID";
                ddlLoanType.DataBind();
                ddlLoanType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanType.SelectedValue = "0";

            }
            else
            {
                ddlLoanType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanType.SelectedValue = "0";
            }
        }

        public void BindDistrict()
        {
            objFeedback_Schema.Langid = 1;
            ds = new DataSet();
            ds = objFeedback_BL.GetDistrict(objFeedback_Schema);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                ddldistrict.DataSource = ds;
                ddldistrict.DataTextField = "Districtname";
                ddldistrict.DataValueField = "Districtcode";
                ddldistrict.DataBind();
                ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddldistrict.SelectedValue = "0";
                ddlBranchname.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBranchname.SelectedValue = "0";

            }
            else
            {
                ddldistrict.Items.Insert(0, new ListItem("--Select--", "0"));
                ddldistrict.SelectedValue = "0";
                ddlBranchname.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBranchname.SelectedValue = "0";
            }
        }

        public void BindConstitution()
        {
            objApplicationFormSchema.Type = "Constitution";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetConstitutionDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlConstitution.DataSource = ds;
                ddlConstitution.DataTextField = "ConstitutionName";
                ddlConstitution.DataValueField = "ID";
                ddlConstitution.DataBind();
                ddlConstitution.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlConstitution.SelectedValue = "0";

            }
            else
            {
                ddlConstitution.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlConstitution.SelectedValue = "0";
            }
        }

        public void BindAddressType()
        {
            objApplicationFormSchema.Type = "Resident";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetAddressType(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlresidenttype.DataSource = ds;
                ddlresidenttype.DataTextField = "ResidentAddress";
                ddlresidenttype.DataValueField = "ID";
                ddlresidenttype.DataBind();
                ddlresidenttype.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlresidenttype.SelectedValue = "0";

                ddlBusinessAddType.DataSource = ds;
                ddlBusinessAddType.DataTextField = "ResidentAddress";
                ddlBusinessAddType.DataValueField = "ID";
                ddlBusinessAddType.DataBind();
                ddlBusinessAddType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBusinessAddType.SelectedValue = "0";
            }
            else
            {
                ddlresidenttype.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlresidenttype.SelectedValue = "0";

                ddlBusinessAddType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlBusinessAddType.SelectedValue = "0";
            }
        }

        public void BindGender()
        {
            objApplicationFormSchema.Type = "Gender";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetGenderDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlGender.DataSource = ds;
                ddlGender.DataTextField = "Gender";
                ddlGender.DataValueField = "ID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlGender.SelectedValue = "0";

            }
            else
            {
                ddlGender.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlGender.SelectedValue = "0";
            }
        }

        public void BindEducationQualification()
        {
            objApplicationFormSchema.Type = "Education";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetEducationDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlQualification.DataSource = ds;
                ddlQualification.DataTextField = "EduQualification";
                ddlQualification.DataValueField = "ID";
                ddlQualification.DataBind();
                ddlQualification.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlQualification.SelectedValue = "0";

            }
            else
            {
                ddlQualification.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlQualification.SelectedValue = "0";
            }
        }

        public void BindProofType()
        {
            objApplicationFormSchema.Type = "BankLaonType";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetProofType(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlLoanAccountType.DataSource = ds;
                ddlLoanAccountType.DataTextField = "LoanType";
                ddlLoanAccountType.DataValueField = "Id";
                ddlLoanAccountType.DataBind();
                ddlLoanAccountType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanAccountType.SelectedValue = "0";

            }
            else
            {
                ddlLoanAccountType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLoanAccountType.SelectedValue = "0";
            }
        }


        public void BindSocialCategory()
        {
            objApplicationFormSchema.Type = "SocialCategory";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetSocialCategoryDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlSocialCategory.DataSource = ds;
                ddlSocialCategory.DataTextField = "SocialCategory";
                ddlSocialCategory.DataValueField = "ID";
                ddlSocialCategory.DataBind();
                ddlSocialCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlSocialCategory.SelectedValue = "0";

            }
            else
            {
                ddlSocialCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlSocialCategory.SelectedValue = "0";
            }
        }


        //public void BindKYCDocument()
        //{
        //    objApplicationFormSchema.Type = "KYCDoc";

        //    ds = new DataSet();
        //    ds = objApplicationFormBAL.GetKYCDocDetails(objApplicationFormSchema);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //        ddlKYCDoc.DataSource = ds;
        //        ddlKYCDoc.DataTextField = "KYCDoc";
        //        ddlKYCDoc.DataValueField = "ID";
        //        ddlKYCDoc.DataBind();
        //        ddlKYCDoc.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlKYCDoc.SelectedValue = "0";

        //    }
        //    else
        //    {
        //        ddlKYCDoc.Items.Insert(0, new ListItem("--Select--", "0"));
        //        ddlKYCDoc.SelectedValue = "0";
        //    }
        //}


        public void BindLineofBusiness()
        {
            objApplicationFormSchema.Type = "Business";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetBusinessDetails(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlLineofBusiness.DataSource = ds;
                ddlLineofBusiness.DataTextField = "BusinessType";
                ddlLineofBusiness.DataValueField = "ID";
                ddlLineofBusiness.DataBind();
                ddlLineofBusiness.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLineofBusiness.SelectedValue = "0";

            }
            else
            {
                ddlLineofBusiness.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlLineofBusiness.SelectedValue = "0";
            }
        }

        public void BindTypeofExistingAccount()
        {
            objApplicationFormSchema.Type = "ExtAccType";

            ds = new DataSet();
            ds = objApplicationFormBAL.GetTypeofExistingAccount(objApplicationFormSchema);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlExistingAccType.DataSource = ds;
                ddlExistingAccType.DataTextField = "AccountType";
                ddlExistingAccType.DataValueField = "ID";
                ddlExistingAccType.DataBind();
                ddlExistingAccType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlExistingAccType.SelectedValue = "0";

            }
            else
            {
                ddlExistingAccType.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlExistingAccType.SelectedValue = "0";
            }
        }

        [System.Web.Services.WebMethod]
        public static ArrayList PopulateSubDistrict(int DistrictID)
        {

            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            ArrayList list = new ArrayList();


            objApplicationFormSchema.Districtid = DistrictID;

            ds = objApplicationFormBAL.GetTaluka(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];

                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["SubDistrictname"].ToString(),
                   dr["SubDistrictcode"].ToString()
                    ));
                }
                return list;
            }


            return list;
        }


        [System.Web.Services.WebMethod]
        public static ArrayList BindBankList(int districtid, int talukaid)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            ArrayList list = new ArrayList();
            objApplicationFormSchema.Districtid = districtid;
            objApplicationFormSchema.Talukaid = talukaid;

            ds = objApplicationFormBAL.GetBankName(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];
                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["BankName"].ToString(),
                   dr["BankID"].ToString()
                    ));
                }
                return list;
            }


            return list;
        }

        [System.Web.Services.WebMethod]
        public static ArrayList BindBranchname(int districtid, int talukaid, int bankid)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            FrmPMMYLoanForm objFrmPMMYLoanForm = new FrmPMMYLoanForm();
            ArrayList list = new ArrayList();
            objApplicationFormSchema.Districtid = districtid;
            objApplicationFormSchema.Talukaid = talukaid;
            objApplicationFormSchema.Bankid = bankid;
            ds = objApplicationFormBAL.GetBranchkName(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];
                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["BranchName"].ToString(),
                   dr["IFSCode"].ToString()
                    ));
                }


                return list;
            }
            return list;
        }

        [System.Web.Services.WebMethod]
        public static string BindBranchDetails(string IFSCCode, string BranchName)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            FrmPMMYLoanForm objFrmPMMYLoanForm = new FrmPMMYLoanForm();
            ArrayList list = new ArrayList();
            string result = string.Empty;
            objApplicationFormSchema.IFSCCode = IFSCCode;
            objApplicationFormSchema.BranchName = BranchName;
            ds = objApplicationFormBAL.GetBranchkDetails(objApplicationFormSchema);
            if (ds != null)
            {
                dt = ds.Tables[0];
                result = dt.Rows[0]["BranchAddress"].ToString() + "|" + dt.Rows[0]["IFSCode"].ToString();
            }
            return result;
        }



        [System.Web.Services.WebMethod]
        public static ArrayList BindMinority(int ID)
        {
            DataSet ds;
            DataTable dt = new DataTable();
            ApplicationFormSchema objApplicationFormSchema = new ApplicationFormSchema();
            ApplicationFormBAL objApplicationFormBAL = new ApplicationFormBAL();
            DataTableReader dr;
            ArrayList list = new ArrayList();
            objApplicationFormSchema.ID = ID;
            objApplicationFormSchema.Type = "MinorityCommunity";

            ds = objApplicationFormBAL.GetMinorityCommunityDetails(objApplicationFormSchema);

            if (ds != null)
            {
                dt = ds.Tables[0];
                dr = dt.CreateDataReader();
                while (dr.Read())
                {
                    list.Add(new ListItem(
                   dr["MinorityCommunityName"].ToString(),
                   dr["ID"].ToString()
                    ));
                }
                return list;
            }


            return list;
        }
        #endregion
    }
}