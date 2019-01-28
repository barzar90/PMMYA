<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="FrmPMMYLoanForm.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="PMMYA.Site.Home.FrmPMMYLoanForm" %>

<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="../../Styles/jquery-ui-1.8.10.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../css/msgBoxLight.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/ValidationScripts.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.10.custom.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript" src="../../js/jquery.msgBox.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {



            //$('#SitePH_ddlLoanType').change(function () {
            //    debugger;
            //    var item = $(this);
            //    if (item.val() == 0)
            //    {
            //        $("#AppForm").hide();                  
            //    }
            //    else
            //    {
            //        $('#AppForm').show();
            //    }
            //});
           <%-- var hdnApplicationId = document.getElementById('<%= hiddenApplicationId.ClientID%>').val();
            var SuccessMsg= $('#SitePH_lblSuccessMsg').val();
            if (SuccessMsg.val() != null) {              
                alertPopupUrl('Information', SuccessMsg.val(), "~/Site/Home/FrmShishu.aspx?ApplicationId=" + hdnApplicationId + "");
            }--%>


             //Bind this keypress function to all of the input tags
            $("input").keypress(function (evt) {
                //Deterime where our character code is coming from within the event
                var charCode = evt.charCode || evt.keyCode;
                if (charCode == 13) { //Enter key's keycode
                    return false;
                }
            });


            $("#SitePH_TxtResidentialAdd").attr("autocomplete", "off");
            $("#SitePH_TxtBusinessAddress").attr("autocomplete", "off");


            $("#SitePH_TxtPeriod").val('0');
            $("#SitePH_TxtExistingLoanAmount").val('0');
            $("#SitePH_TxtIFSC").attr("readonly", true);
            $("#SitePH_TxtBankAddress").attr("readonly", true);

            var FinalDOB = $('#SitePH_TxtDOB');
            $("#SitePH_TxtDOB").attr("readonly", true);
            $("#SitePH_TxtAge").attr("readonly", true);

            $(FinalDOB).datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                maxDate: '0',
                yearRange: "-125:+0",
                onSelect: function (date) {
                    debugger;
                    var date1 = $('#SitePH_TxtDOB').val();
                    var Age = calage(date1);
                    $('#SitePH_TxtAge').val(Age);
                    $("#SitePH_TxtAge").attr("readonly", true);
                },
                onChangeMonthYear: function (y, m, i) {
                    var d = i.selectedDay;
                    $(this).datepicker('setDate', new Date(y, m - 1, d));
                    var date1 = $('#SitePH_TxtDOB').val();
                    var Age = calage(date1);
                    $('#SitePH_TxtAge').val(Age);
                    $("#SitePH_TxtAge").attr("readonly", true);
                }
            });


            //$("#SitePH_btnadd").click(function () {
            //    return CheckValidation();
            //});


            $("#SitePH_btnSubmit").click(function () {

                // disable_autocomplete();
                var hdnTaluka = document.getElementById('<%= hdnTaluka.ClientID%>');
                hdnTaluka.value = $('#SitePH_ddlTaluka').val();


                var hdnBankId = document.getElementById('<%= hdnBankId.ClientID%>');
                hdnBankId.value = $('#SitePH_ddlBankName').val();

                var hdnBranchName = document.getElementById('<%= hdnBranchName.ClientID%>');
                document.getElementById('<%=hdnBranchName.ClientID %>').value = " ";

                hdnBranchName.value = $("#SitePH_ddlBranchname option:selected").text();
                // alert(hdnBranchName.value);

                var HdnMinority = document.getElementById('<%= HdnMinority.ClientID%>');
                HdnMinority.value = $('#SitePH_ddlMinority').val();

                return Validation();
            });


            function Validation() {
                var txt = "";
                var opMode = "";
                debugger;
                var ddlLoanType_selectedIndex = $("#SitePH_ddlLoanType").get(0).selectedIndex;
                if (ddlLoanType_selectedIndex == 0) {
                    //txt += "- Please Select Type of Loan.";
                    txt +='<%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlLoanType") %>'
                    var opt = 1;
                }

                var ddlBankLoanId_selectedIndex = $("#SitePH_ddlLoanAccountType").get(0).selectedIndex;
                if (ddlBankLoanId_selectedIndex == 0) {
                    //txt += "<br /> - Please Select Loan Account Type.";
                    txt += '<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlLoanAccountType") %>'
                    var opt = 1;
                }

                var txtNubmer = $("#SitePH_txtAmount");
                if (txtNubmer != null && txtNubmer.val() == '') {
                    // txt += "<br />  - Please Enter Loan Amount.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrortxtNubmer") %>'
                    var opt = 1;
                }

                if (txtNubmer.val() != '') {
                    if (ddlLoanType_selectedIndex == 1 && txtNubmer.val() > 50000) {
                        //txt += "<br />  - Loan Amount is less than 50000. (For Shishu Loan Type) ";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtLoanShishu") %>'
                        var opt = 1;
                    }

                    if (ddlLoanType_selectedIndex == 2) {
                        if (txtNubmer.val() < 50000 || txtNubmer.val() > 500000) {
                            //txt += "<br />  - Loan Amount is More than 50000 and Less Than 5 lakh. (For Kishore Loan Type) ";
                            txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtLoanKishore") %>'
                            var opt = 1;
                        }
                    }

                    if (ddlLoanType_selectedIndex == 3) {
                        if (txtNubmer.val() < 500000 || txtNubmer.val() > 1000000) {
                            //txt += "<br />  - Loan Amount is More than 5 lakh and Less Than 10 lakh. (For Tarun Loan Type) ";
                            txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtLoanTarun") %>'
                            var opt = 1;
                        }
                    }

                }

                var ddldistrict_selectedIndex = $("#SitePH_ddldistrict").get(0).selectedIndex;
                if (ddldistrict_selectedIndex == 0) {
                    // txt += "<br /> - Please Select District.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "Errorddldistrict") %>'
                    var opt = 1;
                }

                var ddlTaluka_selectedIndex = $("#SitePH_ddlTaluka").get(0).selectedIndex;
                if (ddlTaluka_selectedIndex == 0) {
                    // txt += "<br /> - Please Select Taluka.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlTaluka") %>'
                    var opt = 1;
                }


                var ddlBankName_selectedIndex = $("#SitePH_ddlBankName").get(0).selectedIndex;
                if (ddlBankName_selectedIndex == 0) {
                    //txt += "<br /> - Please Select Bank Name.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlBankName") %>'
                    var opt = 1;
                }

                var ddlBranchname_selectedIndex = $("#SitePH_ddlBranchname").get(0).selectedIndex;
                if (ddlBranchname_selectedIndex == 0) {
                    //txt += "<br /> - Please Select Branch Name.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlBranchname") %>'
                    var opt = 1;
                }


                var TxtIFSC = $("#SitePH_TxtIFSC");
                if (TxtIFSC != null && TxtIFSC.val() == '') {
                    //txt += "<br />  - Please Enter IFSC Code.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtIFSC") %>'
                    var opt = 1;
                }

                var TxtBankAddress = $("#SitePH_TxtBankAddress");
                if (TxtBankAddress != null && TxtBankAddress.val() == '') {
                    //txt += "<br />  - Please Enter Bank Address.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtBankAddress") %>'
                    var opt = 1;
                }

                var TxtApplicantName1 = $("#SitePH_TxtApplicantName1");
                if (TxtApplicantName1 != null && TxtApplicantName1.val() == '') {
                    // txt += "<br />  - Please Enter 1 Applicant Name.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtApplicantName1") %>'
                    var opt = 1;
                }

                //var TxtApplicantName2 = $("#SitePH_TxtApplicantName2");
                //if (TxtApplicantName2 != null && TxtApplicantName2.val() == '') {
                //    txt += "<br />  - Please Enter 2 Applicant Name.";
                //    var opt = 1;
                //}

                var TxtFatherName = $("#SitePH_TxtFatherName");
                if (TxtFatherName != null && TxtFatherName.val() == '') {
                    // txt += "<br />  - Please Enter Father/Husband Name.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtFatherName") %>'
                    var opt = 1;
                }


                var ddlConstitution_selectedIndex = $("#SitePH_ddlConstitution").get(0).selectedIndex;
                if (ddlConstitution_selectedIndex == 0) {
                    //txt += "<br />- Please Select Constitution.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlConstitution") %>'
                    var opt = 1;
                }

                var ResidentialAddress = $("#SitePH_TxtResidentialAdd");
                if (ResidentialAddress != null && ResidentialAddress.val() == '') {
                    //txt += "<br />  - Please Enter Residential Address.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtResidentialAdd") %>'
                    var opt = 1;
                }

                var ddlresidenttype_selectedIndex = $("#SitePH_ddlresidenttype").get(0).selectedIndex;
                if (ddlresidenttype_selectedIndex == 0) {
                    //txt += "<br />- Please Select Residential Address Type.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "Errorddlresidenttype") %>'
                    var opt = 1;
                }

                var BusinessAddress = $("#SitePH_TxtBusinessAddress");
                if (BusinessAddress != null && BusinessAddress.val() == '') {
                    //txt += "<br /> - Please Enter Business Address.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtBusinessAddress") %>'
                    var opt = 1;
                }

                var ddlBusinessAddType_selectedIndex = $("#SitePH_ddlBusinessAddType").get(0).selectedIndex;
                if (ddlBusinessAddType_selectedIndex == 0) {
                    //txt += "<br />- Please Select Business Address Type.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlBusinessAddType") %>'
                    var opt = 1;
                }


                var DOB = $("#SitePH_TxtDOB");
                if (DOB != null && DOB.val() == '') {
                    //txt += "<br />  - Please Enter Date of Birth.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtDOB") %>'
                    var opt = 1;
                }

                var Age = $("#SitePH_TxtAge");
                if (Age != null && Age.val() == '') {
                    //txt += "<br />  - Please Enter Age.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtAge") %>'
                    var opt = 1;
                }

                if (Age.val() != '') {
                    if (Age.val() < 18) {

                        //txt += "<br /> - Applicant Age Should be more than 18 years.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorMinorAge") %>'
                        opt = 1;
                    }

                    if (Age.val() > 125) {
                        //txt += "<br /> - Applicant Age Should be not more than 125 years";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorMoreAge") %>'
                        opt = 1;
                    }
                }

                var ddlGender_selectedIndex = $("#SitePH_ddlGender").get(0).selectedIndex;
                if (ddlGender_selectedIndex == 0) {
                    //txt += "<br />- Please Select Sex.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlGender") %>'
                    var opt = 1;
                }

                var ddlQualification_selectedIndex = $("#SitePH_ddlQualification").get(0).selectedIndex;
                if (ddlQualification_selectedIndex == 0) {
                    // txt += "<br />- Please Select Education Qualification.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlQualification") %>'
                    var opt = 1;
                }

                var ddlSocialCategory_selectedIndex = $("#SitePH_ddlSocialCategory").get(0).selectedIndex;
                if (ddlSocialCategory_selectedIndex == 0) {
                    //txt += "<br />- Please Select Social Category.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlSocialCategory") %>'
                    var opt = 1;
                }

                if (ddlSocialCategory_selectedIndex == 5) {

                    var ddlMinority_selectedIndex = $("#SitePH_ddlMinority").get(0).selectedIndex;
                    if (ddlMinority_selectedIndex == 0) {
                        //txt += "<br />- Please Select Minority Category.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlMinority") %>'
                        var opt = 1;
                    }
                }

                var Telephone = $("#SitePH_TxtTelephone");
                //if (Telephone != null && Telephone.val() == '') {
                //    txt += "<br />  - Please Enter Telephone Number.";
                //    var opt = 1;
                //}
                if (Telephone != null && Telephone.val() != '') {
                    if (Telephone.val().length < 11) {
                        //txt += "<br />  - Please Enter Valid Telephone Number";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtTelephone") %>'
                        var opt = 1;
                    }
                }

                var Mobile = $("#SitePH_TxtMobile");
                if (Mobile != null && Mobile.val() == '') {
                    // txt += "<br />  - Please Enter Mobile Number.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtMobile") %>'
                    var opt = 1;
                }

                //if (Mobile.val().length < 10)
                //{
                //    txt += "<br />  - Please Enter Valid Number";
                //    var opt = 1;
                //}
                if (Mobile != null && Mobile.val() != '') {
                    var mobmatch = /^[789]\d{9}$/;
                    if (Mobile.val().length > 0 && !mobmatch.test(Mobile.val())) {
                        // txt += "<br /> - Please Enter Valid 10 digit Mobile Numer. Number Start with 7 or 8 or 9";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorValidMobile") %>'
                        opt = 1;
                    }
                }

                var Email = $("#SitePH_TxtEmail");
                if (Email != null && Email.val() == '') {
                    //txt += "<br />  - Please Enter Email.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtEmail") %>'
                    var opt = 1;
                }

                if (Email != null && Email.val() != '') {
                    var EmailMatch = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                    if (EmailMatch.test(Email.val())) {
                    }
                    else {
                        txt += '<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorValidEmail") %>';
                        opt = 1;
                    }
                }

                //if (Email != null && Email.val() != '') {
                //    var EmailMatch = /^([A-Za-z0-9_\-\.])+\@@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
                //    if (!EmailMatch.test(Email.val())) {
                //        txt += "<br /> - Please Enter Valid Email Id.";
                //        opt = 1;
                //    }
                //}



                var TxtIDproofVoterNo = $("#SitePH_TxtIDproofVoterNo");
                var TxtIDProofAadharNo = $("#SitePH_TxtIDProofAadharNo");
                var TxtIDproofDLN = $("#SitePH_TxtIDproofDLN");
                var TxtIdProofNumberAny = $("#SitePH_TxtIdProofNumberAny");
                var idcount = 0;
                if (TxtIDproofVoterNo != null && TxtIDproofVoterNo.val() == '') {
                    idcount = idcount + 1;
                }
                if (TxtIDProofAadharNo != null && TxtIDProofAadharNo.val() == '') {
                    idcount += 1;
                }

                if (TxtIDproofDLN != null && TxtIDproofDLN.val() == '') {
                    idcount += 1;
                }

                if (TxtIdProofNumberAny != null && TxtIdProofNumberAny.val() == '') {
                    idcount += 1;
                }
                if (idcount == 4) {
                    //txt += "<br />  - Please Enter Atleast one ID Proof.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorAtleastIDPrrof") %>'
                    var opt = 1;
                }

                var TxtAddproofVoterNo = $("#SitePH_TxtAddproofVoterNo");
                var TxtAddProofAadharNo = $("#SitePH_TxtAddProofAadharNo");
                var TxtAddproofDLN = $("#SitePH_TxtAddproofDLN");
                var TxtAddproofNumberAny = $("#SitePH_TxtAddproofNumberAny");
                var Addproofcount = 0;
                if (TxtAddproofVoterNo != null && TxtAddproofVoterNo.val() == '') {
                    Addproofcount = Addproofcount + 1;
                }
                if (TxtAddProofAadharNo != null && TxtAddProofAadharNo.val() == '') {
                    Addproofcount += 1;
                }

                if (TxtAddproofDLN != null && TxtAddproofDLN.val() == '') {
                    Addproofcount += 1;
                }

                if (TxtAddproofNumberAny != null && TxtAddproofNumberAny.val() == '') {
                    Addproofcount += 1;
                }
                if (Addproofcount == 4) {
                    //txt += "<br />  - Please Enter Atleast one Address Proof.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorAtleastAddressProof") %>'
                    var opt = 1;
                }

                //********** Adhar Validation*************
                if (TxtIDProofAadharNo != null && TxtIDProofAadharNo.val() != '') {
                    if (TxtIDProofAadharNo.val().length < 12) {
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorAadhar12digitID") %>'
                        //txt += "<br />  - Please Enter 12 Digit Aadhar Number for ID Proof.";
                        var opt = 1;
                    }

                    var FieldIdAddharValue = $("#SitePH_TxtIDProofAadharNo").val();
                    if (FieldIdAddharValue.charAt(0) == "0" || FieldIdAddharValue.charAt(0) == "1") {
                        //txt += "<br />  - Please Enter Valid Aadhar Number for ID Proof.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtIDProofAadharNo") %>'
                        var opt = 1;
                    }
                }

                if (TxtAddProofAadharNo != null && TxtAddProofAadharNo.val() != '') {
                    if (TxtAddProofAadharNo.val().length < 12) {
                        //txt += "<br />  - Please Enter 12 Digit Aadhar Number for Address Proof.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorAadhar12digitAdd") %>'
                        var opt = 1;
                    }

                    var FieldAdddAddharValue = $("#SitePH_TxtAddProofAadharNo").val();
                    if (FieldAdddAddharValue.charAt(0) == "0" || FieldAdddAddharValue.charAt(0) == "1") {
                        // txt += "<br />  - Please Enter Valid Aadhar Number for Address Proof.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtAddProofAadharNo") %>'
                        var opt = 1;
                    }

                }

                if (($("#SitePH_TxtAddProofAadharNo").val() != null && $("#SitePH_TxtIDProofAadharNo").val() != null) && ($("#SitePH_TxtAddProofAadharNo").val() != '' && $("#SitePH_TxtIDProofAadharNo").val() != ''))
                    if ($("#SitePH_TxtIDProofAadharNo").val() != $("#SitePH_TxtAddProofAadharNo").val()) {
                        // alert("ID and Address proof for Aadhar should be same.!")
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorAadharNoSame") %>'
                        var opt = 1;
                    }

                //End

                //********** Driving Licence Validation*************
                if (TxtIDproofDLN != null && TxtIDproofDLN.val() != '') {
                    if (TxtIDproofDLN.val().length < 16) {
                        //txt += "<br />  - Please Enter 16 Digit Driving Licence Number for ID Proof.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "Error16DigitDLID") %>'
                        var opt = 1;
                    }


                    var FielDrivingLicenceValue = $("#SitePH_TxtIDproofDLN").val();
                    if ((FielDrivingLicenceValue.charAt(0) != 'M' && FielDrivingLicenceValue.charAt(1) != 'H') && (FielDrivingLicenceValue.charAt(0) != 'm' && FielDrivingLicenceValue.charAt(1) != 'h')) {
                        //txt += "<br />  - Please Enter Valid Driving Licence Number for ID Proof Number";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtIDproofDLN") %>'
                        var opt = 1;
                    }

                    if (FielDrivingLicenceValue.charAt(4) != ' ') {

                        //txt += "<br />  - Please Enter Valid Driving Licence Number for ID Proof Number";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtIDproofDLN") %>'
                        var opt = 1;
                    }
                }

                if (TxtAddproofDLN != null && TxtAddproofDLN.val() != '') {

                    if (TxtAddproofDLN.val().length < 16) {
                        //txt += "<br />  - Please Enter 16 Digit Driving Licence Number for Address Proof.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "Error16DigitDLAddress") %>'
                        var opt = 1;
                    }

                    var FielAddDrivingLicenceValue = $("#SitePH_TxtAddproofDLN").val();
                    if ((FielAddDrivingLicenceValue.charAt(0) != 'M' && FielAddDrivingLicenceValue.charAt(1) != 'H') && (FielAddDrivingLicenceValue.charAt(0) != 'm' && FielAddDrivingLicenceValue.charAt(1) != 'h')) {
                        //txt += "<br />  - Please Enter Valid Driving Licence Number for Address Proof Number";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtAddproofDLN") %>'
                        var opt = 1;
                    }

                    if (FielAddDrivingLicenceValue.charAt(4) != ' ') {
                        // txt += "<br />  - Please Enter Valid Driving Licence Number for Address Proof Number";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "Error16DigitDLAddress") %>'
                        var opt = 1;
                    }
                }

                if (($("#SitePH_TxtAddproofDLN").val() != null && $("#SitePH_TxtIDproofDLN").val() != null) && ($("#SitePH_TxtAddproofDLN").val() != '' && $("#SitePH_TxtIDproofDLN").val() != ''))
                    if ($("#SitePH_TxtIDproofDLN").val() != $("#SitePH_TxtAddproofDLN").val()) {
                        //alert("ID and Address proof for Driving Licence should be same.!")
                        txt += '<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorDLNoSame") %>'
                        var opt = 1;
                    }


                //End

                //*********Voting Card Number
                var IDVotingMatch = /^[a-zA-Z]{3}[0-9]{7}$/;
                if (TxtIDproofVoterNo != null && TxtIDproofVoterNo.val() != '') {

                    if (TxtIDproofVoterNo.val().length < 10) {
                        //txt += "<br />  - Please Enter 10 Digit Voting Card  for ID Proof.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "Error10DigitVoterID") %>'
                        var opt = 1;
                    }

                    if (!IDVotingMatch.test(TxtIDproofVoterNo.val())) {
                        //txt += "<br /> -  Please Enter Valid Voting Card Number for ID Proof";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtIDproofVoterNo") %>'
                        opt = 1;
                    }
                }
                if (TxtAddproofVoterNo != null && TxtAddproofVoterNo.val() != '') {
                    if (TxtAddproofVoterNo.val().length < 10) {
                        // txt += "<br />  - Please Enter 10 Digit Voting Card for Address Proof.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "Error10DigitVoterAddress") %>'
                        var opt = 1;
                    }
                    if (!IDVotingMatch.test(TxtAddproofVoterNo.val())) {
                        // txt += "<br /> - Please Enter Valid Voting Card Number for Address Proof";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtAddproofVoterNo") %>'
                        opt = 1;
                    }
                }

                if (($("#SitePH_TxtAddproofVoterNo").val() != null && $("#SitePH_TxtIDproofVoterNo").val() != null) && ($("#SitePH_TxtAddproofVoterNo").val() != '' && $("#SitePH_TxtIDproofVoterNo").val() != ''))
                    if ($("#SitePH_TxtIDproofVoterNo").val() != $("#SitePH_TxtAddproofVoterNo").val()) {

                        //alert("ID and Address proof for VoterNo should be same.!")
                        txt += '<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorVoterNoSame") %>'
                        opt = 1;
                    }


                if (($("#SitePH_TxtAddproofNameAny").val() != null && $("#SitePH_TxtIdProofNumberAny").val() != null) && ($("#SitePH_TxtAddproofNameAny").val() != '' && $("#SitePH_TxtIdProofNumberAny").val() != ''))
                    if ($("#SitePH_TxtIdProofNumberAny").val() != $("#SitePH_TxtAddproofNameAny").val()) {
                        // alert("ID and Address proof should be same.!")
                        txt += '<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorOtherSame") %>'
                        opt = 1;
                    }
                //************************

                var ddlLineofBusiness_selectedIndex = $("#SitePH_ddlLineofBusiness").get(0).selectedIndex;
                if (ddlLineofBusiness_selectedIndex == 0) {
                    //txt += "<br />- Please Select Line of Business Activity.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlLineofBusiness") %>'
                    var opt = 1;
                }

                if (ddlLineofBusiness_selectedIndex == 1) {
                    var Period = $("#SitePH_TxtPeriod");
                    if (Period != null && Period.val() == '') {
                        //txt += "<br />  - Please Enter Period.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtPeriod") %>'
                        var opt = 1;
                    }

                }

                var TxtSalesExisting = $("#SitePH_TxtSalesExisting");
                if (TxtSalesExisting != null && TxtSalesExisting.val() == '') {
                    //txt += "<br />  - Please Enter Annual Sales for Existing Business.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtSalesExisting") %>'
                    var opt = 1;
                }

                var TxtSalesProposed = $("#SitePH_TxtSalesProposed");
                if (TxtSalesProposed != null && TxtSalesProposed.val() == '') {
                    //txt += "<br />  - Please Enter Annual Sales for Proposed Business.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtSalesProposed") %>'
                    var opt = 1;
                }

                //var TxtExperience = $("#SitePH_TxtExperience");
                //if (TxtExperience != null && TxtExperience.val() == '') {
                //    txt += "<br />  - Please Enter Experience if any.";
                //    var opt = 1;
                //}

                //var TxtLARCCOD = $("#SitePH_TxtLARCCOD");
                //if (TxtLARCCOD != null && TxtLARCCOD.val() == '') {
                //    txt += "<br />  - Please Enter Loan Amount Required CC/OD-Rs.";
                //    var opt = 1;
                //}

                //var TxtLARTermLoan = $("#SitePH_TxtLARTermLoan");
                //if (TxtLARTermLoan != null && TxtLARTermLoan.val() == '') {
                //    txt += "<br />  - Please Enter Loan Amount Required Term Loan-Rs.";
                //    var opt = 1;
                //}


                var isChecked = $("#SitePH_chkExistingAcc").is(":checked");
                if (isChecked) {
                    var ddlExistingAccType_selectedIndex = $("#SitePH_ddlExistingAccType").get(0).selectedIndex;
                    if (ddlExistingAccType_selectedIndex == 0) {
                        //txt += "<br />- Please Select Account Type.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorddlExistingAccType") %>'
                        var opt = 1;
                    }

                    var TxtExistingBankName = $("#SitePH_TxtExistingBankName");
                    if (TxtExistingBankName != null && TxtExistingBankName.val() == '') {
                        //txt += "<br />  - Please Enter Name of Bank and Branch.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtExistingBankName") %>'
                        var opt = 1;
                    }

                    var TxtAccountNumber = $("#SitePH_TxtAccountNumber");
                    if (TxtAccountNumber != null && TxtAccountNumber.val() == '') {
                        //txt += "<br />  - Please Enter Account Number.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtAccountNumber") %>'
                        var opt = 1;
                    }

                    if (TxtAccountNumber != null && TxtAccountNumber.val() != '') {
                        var Accountmatch = /^\d{9,18}$/;
                        if (!Accountmatch.test(TxtAccountNumber.val())) {
                            //txt += "<br /> - Please Enter Valid Account Numer";
                            txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorValidAccount") %>'
                            opt = 1;
                        }
                    }

                    var TxtExistingLoanAmount = $("#SitePH_TxtExistingLoanAmount");
                    if (TxtExistingLoanAmount != null && TxtExistingLoanAmount.val() == '') {
                        //txt += "<br />  - Please Enter Amount of loan Taken.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtExistingLoanAmount") %>'
                        var opt = 1;
                    }
                }

                var TxtCaptcha = $("#SitePH_txtimgcode");
                var hdnCaptcha = $("#SitePH_hdnCaptcha");
                if (TxtCaptcha != null && TxtCaptcha.val() == '') {
                    // txt += "<br />  - Please Enter Captcha.";
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "ErrorTxtCaptcha") %>'
                    var opt = 1;
                }
                if (TxtCaptcha != null && TxtCaptcha.val() != '') {
                    if (TxtCaptcha.val() != hdnCaptcha.val().replace(/ /g, '')) {
                        //txt += "<br />  - Please Enter Valid Captcha.";
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("Common", "txtCaptchavalid") %>'
                        var opt = 1;
                    }
                }

                if (opt == "1") {
                    captcha();
                    var header = '<%= HttpContext.GetGlobalResourceObject("Common", "ErrorHeader") %>'
                    alertPopup(header, txt);
                    //alertPopup("Kindly enter data in below fields.", txt);
                    return false;
                }

            }






            function AadharNoValidation(text) {

                var UID = $('#' + text).val();
                if (UID.length = 12) {
                    var FirstChar = UID.charAt(0);
                    if (FirstChar == "0" || FirstChar == "1") {
                        return false;
                    }
                }
            }




            function CheckValidation() {
                var text = "";
                var opMode = "";




                var ddlProoftype_selectedIndex = $("#SitePH_ddlProoftype").get(0).selectedIndex;
                if (ddlProoftype_selectedIndex == 0) {
                    text += "- Please Select Proof Type.";
                    var opt = 1;
                }

                var ddlKYCDocument_selectedIndex = $("#SitePH_ddlKYCDoc").get(0).selectedIndex;
                if (ddlKYCDocument_selectedIndex == 0) {
                    text += "<br />  - Please Select KYC Document.";
                    var opt = 1;
                }

                var ProofNumber = $("#SitePH_TxtProofNumber");
                if (ProofNumber != null && ProofNumber.val() == '') {
                    text += "<br />  - Please Enter Proof Number.";
                    var opt = 1;
                }

                //opt = 1;
                if (opt == "1") {

                    alertPopup("Kindly enter data in below fields.", text);

                    return false;
                }
            }



            $("#SitePH_ddlMinority").attr("readonly", true);
            $("#SitePH_ddlMinority").prop("disabled", true);
            $('#SitePH_ddlSocialCategory').change(function () {
                var item = $(this);
                if (item.val() == 5) {
                    $("#SitePH_ddlMinority").attr("readonly", false);
                    $("#SitePH_ddlMinority").prop("disabled", true);
                }
                else {
                    $("#SitePH_ddlMinority").attr("readonly", true);
                    $("#SitePH_ddlMinority").prop("disabled", true);
                }
            });

            $("#SitePH_TxtPeriod").attr("readonly", true);
            $("#SitePH_TxtSalesExisting").attr("readonly", true);
            $("#SitePH_TxtSalesProposed").attr("readonly", true);
            $('#SitePH_ddlLineofBusiness').change(function () {
                var item = $(this);
                if (item.val() == 1) {
                    $("#SitePH_TxtPeriod").attr("readonly", false);
                    $("#SitePH_TxtPeriod").val('0');
                    $("#SitePH_TxtSalesExisting").attr("readonly", false);
                    $("#SitePH_TxtSalesProposed").attr("readonly", true);
                    $("#SitePH_TxtSalesProposed").val('0')
                }
                else {
                    $("#SitePH_TxtPeriod").attr("readonly", true);
                    $("#SitePH_TxtPeriod").val();
                    $("#SitePH_TxtSalesProposed").attr("readonly", false);
                    $("#SitePH_TxtSalesExisting").attr("readonly", true);
                    $("#SitePH_TxtSalesExisting").val('0')

                }
            });

            $("#SitePH_chkExistingAcc").click(function () {
                if (this.checked) {
                    $('#ExistingAccount').show();
                    $("#SitePH_TxtExistingLoanAmount").val();
                }
                if (!this.checked) {
                    $("#ExistingAccount").hide();
                    $("#SitePH_TxtExistingLoanAmount").val('0');

                }
            });

            $("#SitePH_TxtIDProofNameAny").attr("readonly", true);
            $("#SitePH_TxtIdProofNumberAny").attr("readonly", true);
            $("#SitePH_TxtAddproofNameAny").attr("readonly", true);
            $("#SitePH_TxtAddproofNumberAny").attr("readonly", true);

            $("#SitePH_TxtIDproofDLN").attr("readonly", true);
            $("#SitePH_TxtAddproofDLN").attr("readonly", true);
            $("#SitePH_TxtIDProofAadharNo").attr("readonly", true);
            $("#SitePH_TxtAddProofAadharNo").attr("readonly", true);
            $("#SitePH_TxtIDproofVoterNo").attr("readonly", true);
            $("#SitePH_TxtAddproofVoterNo").attr("readonly", true);

            $("#SitePH_ChkDrivingLic").click(function () {
                if (this.checked) {
                    $("#SitePH_TxtIDproofDLN").attr("readonly", false);
                    $("#SitePH_TxtAddproofDLN").attr("readonly", false);
                }
                if (!this.checked) {
                    $("#SitePH_TxtIDproofDLN").attr("readonly", true);
                    $("#SitePH_TxtAddproofDLN").attr("readonly", true);
                }
            });

            $("#SitePH_ChkAAdharNumber").click(function () {
                if (this.checked) {
                    $("#SitePH_TxtIDProofAadharNo").attr("readonly", false);
                    $("#SitePH_TxtAddProofAadharNo").attr("readonly", false);
                }
                if (!this.checked) {
                    $("#SitePH_TxtIDProofAadharNo").attr("readonly", true);
                    $("#SitePH_TxtAddProofAadharNo").attr("readonly", true);
                }
            });

            $("#SitePH_ChkVoterId").click(function () {
                if (this.checked) {
                    $("#SitePH_TxtIDproofVoterNo").attr("readonly", false);
                    $("#SitePH_TxtAddproofVoterNo").attr("readonly", false);
                }
                if (!this.checked) {
                    $("#SitePH_TxtIDproofVoterNo").attr("readonly", true);
                    $("#SitePH_TxtAddproofVoterNo").attr("readonly", true);
                }
            });

            $("#SitePH_ChkAnyOtherDoc").click(function () {
                if (this.checked) {
                    $("#SitePH_TxtIDProofNameAny").attr("readonly", false);
                    $("#SitePH_TxtIdProofNumberAny").attr("readonly", false);
                    $("#SitePH_TxtAddproofNameAny").attr("readonly", false);
                    $("#SitePH_TxtAddproofNumberAny").attr("readonly", false);
                }
                if (!this.checked) {
                    $("#SitePH_TxtIDProofNameAny").attr("readonly", true);
                    $("#SitePH_TxtIdProofNumberAny").attr("readonly", true);
                    $("#SitePH_TxtAddproofNameAny").attr("readonly", true);
                    $("#SitePH_TxtAddproofNumberAny").attr("readonly", true);

                }
            });



        });
    </script>

    <%--    <script type="text/javascript">

        jQuery(function ($) {
            $("#SitePH_TxtAddProofAadharNo").blur(function () {
                if (($(this).val() != null && $("#SitePH_TxtIDProofAadharNo").val() != null) && ($(this).val() != '' && $("#SitePH_TxtIDProofAadharNo").val() != ''))
                    if ($("#SitePH_TxtIDProofAadharNo").val() != $(this).val()) {
                        $("#SitePH_TxtIDProofAadharNo").focus();
                        alert("ID and Address proof for Aadhar should be same.!")
                    }
            });
        });
        jQuery(function ($) {
            $("#SitePH_TxtAddproofVoterNo").blur(function () {
                if (($(this).val() != null && $("#SitePH_TxtIDproofVoterNo").val() != null) && ($(this).val() != '' && $("#SitePH_TxtIDproofVoterNo").val() != ''))
                    if ($("#SitePH_TxtIDproofVoterNo").val() != $(this).val()) {
                        $("#SitePH_TxtIDproofVoterNo").focus();
                        alert("ID and Address proof for VoterNo should be same.!")
                    }
            });
        });
        jQuery(function ($) {
            $("#SitePH_TxtAddproofDLN").blur(function () {
                if (($(this).val() != null && $("#SitePH_TxtIDproofDLN").val() != null) && ($(this).val() != '' && $("#SitePH_TxtIDproofDLN").val() != ''))
                    if ($("#SitePH_TxtIDproofDLN").val() != $(this).val()) {
                        $("#SitePH_TxtIDproofDLN").focus();
                        alert("ID and Address proof for Driving Licence should be same.!")
                    }
            });
        });
        jQuery(function ($) {
            $("#SitePH_TxtAddproofNumberAny").blur(function () {
                if (($(this).val() != null && $("#SitePH_TxtIdProofNumberAny").val() != null) && ($(this).val() != '' && $("#SitePH_TxtIdProofNumberAny").val() != ''))
                    if ($("#SitePH_TxtIdProofNumberAny").val() != $(this).val()) {
                        $("#SitePH_TxtIdProofNumberAny").focus();
                        alert("ID and Address proof should be same.!")
                    }
            });
        });
     


    </script>--%>

    <script type="text/javascript">
        debugger;
        var dat = new Date();
        var curday = dat.getDate();
        var curmon = dat.getMonth() + 1;
        var curyear = dat.getFullYear();
        function checkleapyear(datea) {
            if (datea.getYear() % 4 == 0) {
                if (datea.getYear() % 10 != 0) {
                    return true;
                }
                else {
                    if (datea.getYear() % 400 == 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        function DaysInMonth(Y, M) {
            with (new Date(Y, M, 1, 12)) {
                setDate(0);
                return getDate();
            }
        }
        function datediff(date1, date2) {
            var y1 = date1.getFullYear(), m1 = date1.getMonth(), d1 = date1.getDate(),
                y2 = date2.getFullYear(), m2 = date2.getMonth(), d2 = date2.getDate();
            if (d1 < d2) {
                m1--;
                d1 += DaysInMonth(y2, m2);
            }
            if (m1 < m2) {
                y1--;
                m1 += 12;
            }
            return [y1 - y2, m1 - m2, d1 - d2];
        }

        function calage(dob) {
            debugger;
            var D1 = dob.split('/');
            var calday = D1[0];
            var calmon = D1[1];
            var calyear = D1[2];

            var curd = new Date(curyear, curmon - 1, curday);
            var cald = new Date(calyear, calmon - 1, calday);
            var diff = Date.UTC(curyear, curmon, curday, 0, 0, 0) - Date.UTC(calyear, calmon, calday, 0, 0, 0);
            var dife = datediff(curd, cald);
            return dife[0];
        }

    </script>

    <script type="text/javascript">

        function PopulateControl(list, control) {
            if (list.length > 0) {
                control.removeAttr("disabled");
                control.empty().append('<option selected="selected" value="0">--Select--</option>');
                $.each(list, function () {
                    control.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            else {
                control.empty().append('<option selected="selected" value="0">--Select--<option>');
            }
        }

        function PopulateSubDistrict() {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/FrmPMMYLoanForm.aspx")%>'
            if ($('#SitePH_ddldistrict').val() == "0") {
                $('#SitePH_ddlTaluka').empty().append('<option selected="selected" value="0">--Select--</option>');
            }
            else {
                $('#SitePH_ddlTaluka').empty().append('<option selected="selected" value="0">Loading...</option>');
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/PopulateSubDistrict',
                    data: '{DistrictID: ' + $('#SitePH_ddldistrict').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnCitiesPopulated,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }

        function OnCitiesPopulated(response) {
            PopulateControl(response.d, $("#SitePH_ddlTaluka"));
        }

        function BindBankDetails() {


            //alert(hdnTaluka.value);

            var pageUrl = '<%=ResolveUrl("~/Site/Home/FrmPMMYLoanForm.aspx")%>'
            if ($('#SitePH_ddlTaluka').val() == "0") {
                $('#SitePH_ddlBankName').empty().append('<option selected="selected" value="0">--Select--</option>');
            }
            else {
                $('#SitePH_ddlBankName').empty().append('<option selected="selected" value="0">Loading...</option>');
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/BindBankList',
                    // data: '{DistrictID: ' + $('#SitePH_ddldistrict').val() + '}',
                    data: "{'districtid':'" + $('#SitePH_ddldistrict').val() + "','talukaid':'" + $('#SitePH_ddlTaluka').val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnBankPopulated,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }


        function OnBankPopulated(response) {
            PopulateControl(response.d, $("#SitePH_ddlBankName"));
        }

        function BindBranchDetails() {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/FrmPMMYLoanForm.aspx")%>'
            if ($('#SitePH_ddlBankName').val() == "0") {
                $('#SitePH_ddlBranchname').empty().append('<option selected="selected" value="0">--Select--</option>');
            }
            else {
                $('#SitePH_ddlBranchname').empty().append('<option selected="selected" value="0">Loading...</option>');
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/BindBranchname',
                    data: "{'districtid':'" + $('#SitePH_ddldistrict').val() + "','talukaid':'" + $('#SitePH_ddlTaluka').val() + "','bankid':'" + $('#SitePH_ddlBankName').val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnBranchPopulated,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }


        function OnBranchPopulated(response) {
            PopulateControl(response.d, $("#SitePH_ddlBranchname"));
        }

        function BindBrancData() {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/FrmPMMYLoanForm.aspx")%>'
            if ($('#SitePH_ddlBranchname').val() == "0") {
                $("#SitePH_TxtIFSC").attr("readonly", true);
                $("#SitePH_TxtBankAddress").attr("readonly", true);
                // $('#SitePH_ddlBranchname').empty().append('<option selected="selected" value="0">--Select--</option>');
            }
            else {
                // $('#SitePH_ddlBranchname').empty().append('<option selected="selected" value="0">Loading...</option>');
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/BindBranchDetails',
                    data: "{'IFSCCode':'" + $('#SitePH_ddlBranchname').val() + "','BranchName':'" + $('#SitePH_ddlBranchname option:selected').text() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnBindBranch,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }


        function OnBindBranch(response) {
            var details = response.d;
            var OthedataSplit = details.split("|");
            $("#SitePH_TxtBankAddress").val(OthedataSplit[0].toString());
            $("#SitePH_TxtIFSC").val(OthedataSplit[1].toString());
            $("#SitePH_TxtIFSC").attr("readonly", true);
            $("#SitePH_TxtBankAddress").attr("readonly", true);
        }



        function PopulateMinority() {
            debugger;
            var pageUrl = '<%=ResolveUrl("~/Site/Home/FrmPMMYLoanForm.aspx")%>'
            if ($('#SitePH_ddlSocialCategory').val() == "0") {
                $('#SitePH_ddlMinority').empty().append('<option selected="selected" value="0">--Select--</option>');
            }
            else {
                $('#SitePH_ddlMinority').empty().append('<option selected="selected" value="0">Loading...</option>');
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/BindMinority',
                    data: '{ID: ' + $('#SitePH_ddlSocialCategory').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnMinorityPopulated,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }

        function OnMinorityPopulated(response) {
            PopulateControl(response.d, $("#SitePH_ddlMinority"));
        }


    </script>
    <script type="text/javascript">

        $(function () {
            $("#SitePH_TxtIDproofVoterNo").keyup(function () {
                if (this.value.match(/[^a-zA-Z0-9]/g)) {
                    this.value = this.value.replace(/[^a-zA-Z0-9]/g, '');
                }
            }
            );
        }
        );

        $(function () {
            $("#SitePH_TxtAddproofVoterNo").keyup(function () {
                if (this.value.match(/[^a-zA-Z0-9]/g)) {
                    this.value = this.value.replace(/[^a-zA-Z0-9]/g, '');
                }
            }
            );
        }
        );
        $(function () {
            $("#SitePH_TxtIDproofDLN").keyup(function () {
                if (this.value.match(/[^a-zA-Z0-9]/g)) {
                    this.value = this.value.replace(/[^a-zA-Z0-9 ]/g, '');
                }
            }
            );
        }
        );
        $(function () {
            $("#SitePH_TxtIDproofDLN").keyup(function () {
                if (this.value.match(/[^a-zA-Z0-9]/g)) {
                    this.value = this.value.replace(/[^a-zA-Z0-9 ]/g, '');
                }
            }
            );
        }
        );
    </script>
    <script type="text/javascript">
        function disable_autocomplete() {
            $("#form").attr('autocomplete', 'off');
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server" autocomplete="false">


    <asp:Panel ID="Panel1" runat="server">

        <%-- <div class="col-md-12 box-container">--%>
        <fieldset>
            <legend>
                <asp:Label ID="lblApplicationHeading" runat="server" Text="1. Loan Details"></asp:Label></legend>
            <%--<div class="box-body">--%>
            <div class="row">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="lblLoanType" AssociatedControlID="ddlLoanType" runat="server" Text="Mudra Loan Type" CssClass="manadatory"></asp:Label>
                        <asp:DropDownList ID="ddlLoanType" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="lblAccountLoanType" AssociatedControlID="ddlLoanAccountType" runat="server" Text="Loan Account Type" CssClass="manadatory"></asp:Label>
                        <asp:DropDownList ID="ddlLoanAccountType" runat="server" class="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <div class="form-group">
                        <asp:Label ID="lblAmount" AssociatedControlID="txtAmount" runat="server" Text="Amount" CssClass="manadatory"></asp:Label>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" MaxLength="8" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="clearfix">
            </div>
            <%--</div>--%>
        </fieldset>

        <%-- <div class="box-heading">--%>
        <%-- <h4 class="box-title">
                <asp:Label ID="lblApplicationHeading" runat="server" Text="Loan Details"></asp:Label>
            </h4>--%>
        <%--</div>--%>

        <%-- <div class="box-body">
                 <div class="container">
                 <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                          <asp:Label ID="lblLoanType" runat="server" Text="Mudra Loan Type"></asp:Label>
                            <asp:DropDownList ID="ddlLoanType" runat="server" class="form-control">
                            </asp:DropDownList>                 
                      </div>
                  </div>
                 <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                          <asp:Label ID="lblAccountLoanType" runat="server" Text="Loan Account Type"></asp:Label>
                            <asp:DropDownList ID="ddlLoanAccountType" runat="server" class="form-control">
                            </asp:DropDownList>                 
                      </div>
                  </div>
                 </div>
                  <div class="container">
                       <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                           <asp:Label ID="lblAmount" AssociatedControlID="txtAmount" runat="server" Text="Amount" ></asp:Label>
                           <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" MaxLength="8" onkeypress = "return onlyNumbers(event);"></asp:TextBox>
                       </div>
                  </div>
                  </div>
             <div class="clearfix">
             </div>
         </div>--%>
        <%--</div>--%>

        <div id="AppForm">


            <fieldset>
                <legend>
                    <asp:Label ID="lblBankDetails" runat="server" Text="2. Bank Details"></asp:Label></legend>
                <%-- <div class="box-body">--%>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblDistrict" AssociatedControlID="ddlDistrict" runat="server" Text="District" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" onchange="PopulateSubDistrict();">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:HiddenField ID="hdnTaluka" runat="server" Value="" />
                            <asp:Label ID="lblTaluka" AssociatedControlID="ddlTaluka" runat="server" Text="Taluka" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlTaluka" runat="server" class="form-control" onchange="BindBankDetails();">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:HiddenField ID="hdnBankId" runat="server" Value="" />
                            <asp:Label ID="lblBankName" AssociatedControlID="ddlBankName" runat="server" Text="Bank Name" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlBankName" runat="server" class="form-control" onchange="BindBranchDetails();">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="TxtBankValue" runat="server" Visible="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:HiddenField ID="hdnBranchName" runat="server" />
                            <asp:Label ID="lblBranch" AssociatedControlID="ddlBranchname" runat="server" Text="Branch Name" CssClass="manadatory"></asp:Label>
                            <%--<asp:TextBox ID="TxtBranch" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlBranchname" runat="server" class="form-control" onchange="BindBrancData();">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblBankIFSC" AssociatedControlID="TxtIFSC" runat="server" Text="Bank IFSC Code" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtIFSC" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblBankAdd" AssociatedControlID="TxtBankAddress" runat="server" Text="Bank Address" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtBankAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="clearfix">
                </div>
                <%--</div>--%>
            </fieldset>
            <%-- <div class="col-md-12 box-container" >--%>
            <%-- <div class="box-heading" >
                <h4 class="box-title">
                <asp:Label ID="lblBankDetails" runat="server" Text="Bank Details"></asp:Label>
               </h4>
           </div>--%>
            <%--<div class="box-body">
               <div class="container">
               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblDistrict" AssociatedControlID="ddlDistrict" runat="server" Text="District"></asp:Label>
                       <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" onchange="PopulateSubDistrict();">
                       </asp:DropDownList> 
                   </div>
               </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:HiddenField id="hdnTaluka" runat="server" Value=""/>
                       <asp:Label ID="lblTaluka" AssociatedControlID="ddlTaluka" runat="server" Text="Taluka" ></asp:Label>
                       <asp:DropDownList ID="ddlTaluka" runat="server" class="form-control" onchange="BindBankDetails();">
                           <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                       </asp:DropDownList> 
                       
                   </div>
               </div>
               </div>
               <div class="container">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:HiddenField id="hdnBankId" runat="server" Value=""/>
                       <asp:Label ID="lblBankName" AssociatedControlID="ddlBankName" runat="server" Text="Bank Name"></asp:Label>
                       <asp:DropDownList ID="ddlBankName" runat="server" class="form-control" onchange="BindBranchDetails();">
                       <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                       </asp:DropDownList> 
                       <asp:TextBox ID="TxtBankValue" runat="server" Visible="false"></asp:TextBox>
                   </div>
               </div>
               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                          <asp:HiddenField id="hdnBranchName" runat="server" />
                           <asp:Label ID="lblBranch" AssociatedControlID="ddlBranchname" runat="server" Text="Branch Name"></asp:Label>
                           <%--<asp:TextBox ID="TxtBranch" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>--%>
            <%-- <asp:DropDownList ID="ddlBranchname" runat="server" class="form-control" onchange="BindBrancData();">--%>
            <%-- <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>--%>
            <%--  </asp:DropDownList> --%>

            <%-- </div>
                  </div>
                   </div>
               <div class="container">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                           <asp:Label ID="lblBankIFSC" AssociatedControlID="TxtIFSC" runat="server" Text="Bank IFSC Code"></asp:Label>
                           <asp:TextBox ID="TxtIFSC" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                       </div>
                </div>

               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                           <asp:Label ID="lblBankAdd" AssociatedControlID="TxtBankAddress" runat="server" Text="Bank Address"></asp:Label>
                           <asp:TextBox ID="TxtBankAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                       </div>
                </div>
                   </div>
               <div class="clearfix">
             </div>
           </div>--%>

            <%-- </div>--%>


            <fieldset>
                <legend>
                    <asp:Label ID="lblApplicantName" runat="server" Text="3. Applicant Details"></asp:Label></legend>
                <%-- <div class="box-body">--%>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblAppName1" AssociatedControlID="TxtApplicantName1" runat="server" Text="1.Applicant Name" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtApplicantName1" runat="server" MaxLength="99" CssClass="form-control" onkeypress="return valAlphabetic(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblAppName2" AssociatedControlID="TxtApplicantName2" runat="server" Text="2.Applicant Name"></asp:Label>
                            <asp:TextBox ID="TxtApplicantName2" runat="server" MaxLength="99" CssClass="form-control" onkeypress="return valAlphabetic(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblFather" AssociatedControlID="TxtFatherName" runat="server" Text="Father/Husband Name" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtFatherName" runat="server" MaxLength="99" CssClass="form-control" onkeypress="return valAlphabetic(event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblConstitution" AssociatedControlID="ddlConstitution" runat="server" Text="Constitution" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlConstitution" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblResidentialAddress" AssociatedControlID="TxtResidentialAdd" runat="server" Text="Residential Address" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtResidentialAdd" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblResidenttype" AssociatedControlID="ddlresidenttype" runat="server" Text="Address Type" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlresidenttype" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblBusinessAddress" AssociatedControlID="TxtBusinessAddress" runat="server" Text="Business Address" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtBusinessAddress" runat="server" TextMode="MultiLine" CssClass="form-control" oncopy="return false" onpaste="return false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblBusinessAddType" AssociatedControlID="ddlBusinessAddType" runat="server" Text="Address Type" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlBusinessAddType" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblDOB" AssociatedControlID="TxtDOB" runat="server" Text="Date of Birth" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtDOB" runat="server" CssClass="form-control Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblAge" AssociatedControlID="TxtAge" runat="server" Text="Age" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtAge" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                </div>


                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblsex" AssociatedControlID="ddlGender" runat="server" Text="Sex" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblQualification" AssociatedControlID="ddlQualification" runat="server" Text="Education Qualification" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlQualification" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblSocialCategory" AssociatedControlID="ddlSocialCategory" runat="server" Text="Social Category" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlSocialCategory" runat="server" class="form-control" onchange="PopulateMinority();">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblminority" AssociatedControlID="ddlMinority" runat="server" Text="If Minority"></asp:Label>
                            <asp:HiddenField ID="HdnMinority" runat="server" Value="" />
                            <asp:DropDownList ID="ddlMinority" runat="server" class="form-control">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>



                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblTelephone" AssociatedControlID="TxtTelephone" runat="server" Text="Telephone No"></asp:Label>
                            <asp:TextBox ID="TxtTelephone" runat="server" MaxLength="11" CssClass="form-control" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblMobile" AssociatedControlID="TxtMobile" runat="server" Text="Mobile No" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtMobile" runat="server" MaxLength="10" CssClass="form-control" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblEmail" AssociatedControlID="TxtEmail" runat="server" Text="Email" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <%--</div>--%>
            </fieldset>

            <%--<div class="col-md-12 box-container" >--%>
            <%-- <div class="box-heading" >
                <h4 class="box-title">
                <asp:Label ID="lblApplicantName" runat="server" Text="Applicant Details"></asp:Label>
               </h4>
           </div>--%>
            <%--<div class="box-body">
               <div class="container">
               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblAppName1" AssociatedControlID="TxtApplicantName1" runat="server" Text="1.Applicant Name" ></asp:Label>
                        <asp:TextBox ID="TxtApplicantName1" runat="server" MaxLength="99" CssClass="form-control" onkeypress = "return valAlphabetic(event);"   ></asp:TextBox>
                   </div>
               </div>
               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblAppName2" AssociatedControlID="TxtApplicantName2" runat="server" Text="2.Applicant Name" ></asp:Label>
                        <asp:TextBox ID="TxtApplicantName2" runat="server" MaxLength="99" CssClass="form-control" onkeypress = "return valAlphabetic(event);"></asp:TextBox>
                   </div>
               </div>
               </div>

               <div class="container">
               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblFather" AssociatedControlID="TxtFatherName" runat="server" Text="Father/Husband Name"></asp:Label>
                        <asp:TextBox ID="TxtFatherName" runat="server" MaxLength="99" CssClass="form-control" onkeypress = "return valAlphabetic(event);"></asp:TextBox>
                   </div>
               </div>

               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblConstitution" AssociatedControlID="ddlConstitution" runat="server" Text="Constitution"></asp:Label>
                       <asp:DropDownList ID="ddlConstitution" runat="server" class="form-control">
                       </asp:DropDownList> 
                   </div>
               </div>
           </div>
               <div class="container">
               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblResidentialAddress" AssociatedControlID="TxtResidentialAdd" runat="server" Text="Residential Address"></asp:Label>
                        <asp:TextBox ID="TxtResidentialAdd" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                   </div>
               </div>

                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblResidenttype" AssociatedControlID="ddlresidenttype" runat="server" Text="Address Type"></asp:Label>
                         <asp:DropDownList ID="ddlresidenttype" runat="server" class="form-control">
                       </asp:DropDownList> 
                   </div>
               </div>
               </div>

               <div class="container">
               <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblBusinessAddress" AssociatedControlID="TxtBusinessAddress" runat="server" Text="Business Address"></asp:Label>
                        <asp:TextBox ID="TxtBusinessAddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                   </div>
               </div>

                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblBusinessAddType" AssociatedControlID="ddlBusinessAddType" runat="server" Text="Address Type"></asp:Label>
                         <asp:DropDownList ID="ddlBusinessAddType" runat="server" class="form-control">
                       </asp:DropDownList> 
                   </div>
               </div>
               </div>


               <div class="container">
                  <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblDOB" AssociatedControlID="TxtDOB" runat="server" Text="Date of Birth"></asp:Label>
                        <asp:TextBox ID="TxtDOB" runat="server" CssClass="form-control Date"></asp:TextBox>
                   </div>
                  </div>
                  <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblAge" AssociatedControlID="TxtAge" runat="server" Text="Age"></asp:Label>
                        <asp:TextBox ID="TxtAge" runat="server"  CssClass="form-control"></asp:TextBox>
                   </div>
                  </div>

               </div>


               <div class="container">
                   <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblsex" AssociatedControlID="ddlGender" runat="server" Text="Sex"></asp:Label>
                         <asp:DropDownList ID="ddlGender" runat="server" class="form-control">
                       </asp:DropDownList> 
                   </div>
                   </div>
                     <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                   <div class="form-group">
                       <asp:Label ID="lblQualification" AssociatedControlID="ddlQualification" runat="server" Text="Education Qualification"></asp:Label>
                         <asp:DropDownList ID="ddlQualification" runat="server" class="form-control">
                       </asp:DropDownList> 
                   </div>
               </div>
              
               </div>

               <div class="container">
                   <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                       <div class="form-group">
                           <asp:Label ID="lblSocialCategory" AssociatedControlID="ddlSocialCategory" runat="server" Text="Social Category" ></asp:Label>
                           <asp:DropDownList ID="ddlSocialCategory" runat="server" class="form-control" onchange="PopulateMinority();">
                           </asp:DropDownList> 
                       </div>
                   </div>
                   <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                       <div class="form-group">
                           <asp:Label ID="lblminority" AssociatedControlID="ddlMinority" runat="server" Text="If Minority"></asp:Label>
                           <asp:DropDownList ID="ddlMinority" runat="server" class="form-control">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                           </asp:DropDownList>
                       </div>
                   </div>
               </div>



                <div class="container">
                  <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                       <asp:Label ID="lblTelephone" AssociatedControlID="TxtTelephone" runat="server" Text="Telephone No"></asp:Label>
                        <asp:TextBox ID="TxtTelephone" runat="server" MaxLength="11" CssClass="form-control" onkeypress = "return onlyNumbers(event);"></asp:TextBox>
                   </div>
                  </div>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                       <asp:Label ID="lblMobile" AssociatedControlID="TxtMobile" runat="server" Text="Mobile No" ></asp:Label>
                        <asp:TextBox ID="TxtMobile" runat="server" MaxLength="10"  CssClass="form-control" onkeypress = "return onlyNumbers(event);"></asp:TextBox>
                   </div>
                  </div>
                </div>

               <div class="container">
                   <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                      <div class="form-group">
                       <asp:Label ID="lblEmail" AssociatedControlID="TxtEmail" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TxtEmail" runat="server"  CssClass="form-control"></asp:TextBox>
                   </div>
                  </div>
               </div>

           </div>--%>
            <%--  </div>--%>

            <fieldset>
                <legend>
                    <asp:Label ID="lblKycHeading" runat="server" Text="4. KYC Documents"></asp:Label></legend>
                <%-- <div class="box-body">--%>

                <div class="col-md-2 col-lg-2">
                    <div class="form-group">
                        <asp:Label ID="lblKYC" runat="server" Text="KYC Document(s)" CssClass="KYC-Doc-bold"></asp:Label>                        
                    </div>
                    <br>
                    <div class="form-group">
                        <asp:Label ID="lblIDproof" runat="server" Text="ID Proof" CssClass="KYC-Doc-bold"></asp:Label>
                    </div>
                    <br>
                    <div class="form-group">
                        <asp:Label ID="lblAddproof" runat="server" Text="Address Proof" CssClass="KYC-Doc-bold"></asp:Label>
                    </div>
                </div>
                <div class="col-md-2 col-lg-2">
                    <div class="form-group">
                        <asp:CheckBox ID="ChkVoterId" runat="server" />
                        <asp:Label ID="lblVoterId" runat="server" Text="Voter ID No." CssClass="KYC-Doc-bold"></asp:Label>

                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtIDproofVoterNo" MaxLength="10" runat="server" onkeypress="return IsAlphaNumericText(event);" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtAddproofVoterNo" MaxLength="10" runat="server" onkeypress="return IsAlphaNumericText(event);" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2 col-lg-2">
                    <div class="form-group">
                        <asp:CheckBox ID="ChkAAdharNumber" runat="server" />
                        <asp:Label ID="lblAdharNo" runat="server" Text="Aadhar No." CssClass="KYC-Doc-bold"></asp:Label>

                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtIDProofAadharNo" MaxLength="12" runat="server" autocomplete='new-password' onkeypress="return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtAddProofAadharNo" MaxLength="12" runat="server" autocomplete='new-password' onkeypress="return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2 col-lg-2">
                    <div class="form-group">
                        <asp:CheckBox ID="ChkDrivingLic" runat="server" />
                        <asp:Label ID="lblDLNo" runat="server" Text="DL No" CssClass="KYC-Doc-bold"></asp:Label>

                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtIDproofDLN" MaxLength="16" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtAddproofDLN" MaxLength="16" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2 col-lg-2">
                    <div class="form-group">
                        <asp:CheckBox ID="ChkAnyOtherDoc" runat="server" />
                        <asp:Label ID="lblAnyother" runat="server" Text="Any Others" CssClass="KYC-Doc-bold"></asp:Label>

                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtIDProofNameAny" runat="server" CssClass="form-control"></asp:TextBox>


                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtAddproofNameAny" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-2 col-lg-2">
                    <br>
                    <br>
                    <div class="form-group">
                        <asp:TextBox ID="TxtIdProofNumberAny" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="TxtAddproofNumberAny" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>



                <%-- </div>--%>
            </fieldset>

            <%--<div class="col-md-12 box-container" >--%>
            <%--<div class="box-heading" >
                <h4 class="box-title">
                <asp:Label ID="lblKycHeading" runat="server" Text="KYC Documents"></asp:Label>
                </h4>
               </div>--%>
            <%--<div class="box-body">
                <div class="container">

                    <div class="col-md-2">
                        <p style="border:1px solid #fff"><asp:Label ID="Label1" runat="server" Text="KYC Document(s)"></asp:Label></p>
                        <p style="border:1px solid #fff"><asp:Label ID="Label2" runat="server" Text="ID Proof"></asp:Label></p>
                        <p style="border:1px solid #fff"><asp:Label ID="Label3" runat="server" Text="Address Proof"></asp:Label></p>

                    </div>
                    <div class="col-md-2 ">
                         <p style="border:1px solid #fff"><asp:Label ID="Label4" runat="server" Text="Voter ID No."></asp:Label>
                             <asp:CheckBox ID="ChkVoterId" runat="server" />
                         </p>
                        <p style="border:1px solid #fff"> <asp:TextBox ID="TxtIDproofVoterNo" MaxLength="10" runat="server" onkeypress="return IsAlphaNumericText(event);"></asp:TextBox></p>
                        <p style="border:1px solid #fff"><asp:TextBox ID="TxtAddproofVoterNo" MaxLength="10" runat="server" onkeypress="return IsAlphaNumericText(event);"></asp:TextBox></p>
                    </div>
                    <div class="col-md-2 ">
                         <p style="border:1px solid #fff"><asp:Label ID="Label5" runat="server" Text="Aadhar No."></asp:Label>
                              <asp:CheckBox ID="ChkAAdharNumber" runat="server" />
                         </p>
                        <p style="border:1px solid #fff"> <asp:TextBox ID="TxtIDProofAadharNo" MaxLength="12" runat="server" onkeypress = "return onlyNumbers(event);"></asp:TextBox></p>
                        <p style="border:1px solid #fff"><asp:TextBox ID="TxtAddProofAadharNo" MaxLength="12" runat="server" onkeypress = "return onlyNumbers(event);" ></asp:TextBox></p>
                    </div>
                    <div class="col-md-2 ">
                         <p style="border:1px solid #fff"><asp:Label ID="Label6" runat="server" Text="Driving Licence No."></asp:Label>
                             <asp:CheckBox ID="ChkDrivingLic" runat="server" />
                         </p>
                        <p style="border:1px solid #fff" ><asp:TextBox ID="TxtIDproofDLN" MaxLength="16"  runat="server" ></asp:TextBox></p>
                        <p style="border:1px solid #fff"><asp:TextBox ID="TxtAddproofDLN" MaxLength="16" runat="server" ></asp:TextBox></p>
                    </div>
                    <div class="col-md-4 ">
                         <p style="border:1px solid #fff"><asp:Label ID="Label7" runat="server" Text="Any Others"></asp:Label>
                              <asp:CheckBox ID="ChkAnyOtherDoc" runat="server" />
                         </p>
                        <p style="border:1px solid #fff"><asp:TextBox ID="TxtIDProofNameAny" runat="server" ></asp:TextBox>
                            <asp:TextBox ID="TxtIdProofNumberAny" runat="server" ></asp:TextBox>
                        </p>
                        <p style="border:1px solid #fff"><asp:TextBox ID="TxtAddproofNameAny" runat="server" ></asp:TextBox>
                            <asp:TextBox ID="TxtAddproofNumberAny" runat="server" ></asp:TextBox></p>
                    </div>


                                          
               </div>
                 

                 


                </div>--%>
            <%-- </div>--%>

            <fieldset>
                <legend>
                    <asp:Label ID="lblBusiness" runat="server" Text="5. Business Details"></asp:Label></legend>
                <%--<div class="box-body">--%>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblLineofBusiness" AssociatedControlID="ddlLineofBusiness" runat="server" Text="Line of Business Activity (Purpose)" CssClass="manadatory"></asp:Label>
                            <asp:DropDownList ID="ddlLineofBusiness" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblperiod" AssociatedControlID="TxtPeriod" runat="server" Text="Period"></asp:Label>
                            <asp:TextBox ID="TxtPeriod" runat="server" MaxLength="2" CssClass="form-control" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblSalesExisting" AssociatedControlID="TxtSalesExisting" runat="server" Text="Annual Sales for Existing (Rs. in Lakh)"></asp:Label>
                            <asp:TextBox ID="TxtSalesExisting" runat="server" MaxLength="8" onkeypress="return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblSalesProposed" AssociatedControlID="TxtSalesProposed" runat="server" Text="Annual Sales for Proposed (Rs. in Lakh)"></asp:Label>
                            <asp:TextBox ID="TxtSalesProposed" runat="server" MaxLength="8" onkeypress="return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblExperience" AssociatedControlID="TxtExperience" runat="server" Text="Experience, if any"></asp:Label>
                            <asp:TextBox ID="TxtExperience" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Label ID="lblBusinessActivity" AssociatedControlID="TxtBusinessActivity" runat="server" Text="Name of Business Activity"></asp:Label>
                            <asp:TextBox ID="TxtBusinessActivity" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <%-- </div>--%>
            </fieldset>

            <%--<div class="col-md-12 box-container" >--%>
            <%--<div class="box-heading" >
                <h4 class="box-title">
                <asp:Label ID="lblBusiness" runat="server" Text="Business Details"></asp:Label>
                </h4>
               </div>--%>

            <%-- <div class="box-body">
                    <div class="container">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                        <div class="form-group">
                            <asp:Label ID="lblLineofBusiness" AssociatedControlID="ddlLineofBusiness" runat="server" Text="Line of Business Activity (Purpose)"></asp:Label>
                            <asp:DropDownList ID="ddlLineofBusiness" runat="server" class="form-control">
                            </asp:DropDownList> 
                        </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                           <div class="form-group">
                           <asp:Label ID="lblperiod" AssociatedControlID="TxtPeriod" runat="server" Text="Period"></asp:Label>
                            <asp:TextBox ID="TxtPeriod" runat="server" MaxLength="2"  CssClass="form-control" onkeypress = "return onlyNumbers(event);"></asp:TextBox>
                        </div>
                       </div>
                    </div>

                    <div class="container">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                            <div class="form-group">
                                <asp:Label ID="lblSalesExisting" AssociatedControlID="TxtSalesExisting" runat="server" Text="Annual Sales for Existing (Rs. in Lakh)"></asp:Label>
                                <asp:TextBox ID="TxtSalesExisting" runat="server" MaxLength="8"  onkeypress = "return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                             </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                            <div class="form-group">
                                <asp:Label ID="lblSalesProposed" AssociatedControlID="TxtSalesProposed" runat="server" Text="Annual Sales for Proposed (Rs. in Lakh)"></asp:Label>
                                <asp:TextBox ID="TxtSalesProposed" runat="server" MaxLength="8" onkeypress = "return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                             </div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                            <div class="form-group">
                                <asp:Label ID="lblExperience" AssociatedControlID="TxtExperience" runat="server" Text="Experience, if any"></asp:Label>
                                <asp:TextBox ID="TxtExperience" runat="server"  CssClass="form-control"></asp:TextBox>
                             </div>
                        </div>
                    </div>

                 </div>--%>
            <%-- </div>--%>

            <fieldset>
                <legend>
                    <asp:Label ID="LblLoan" runat="server" Text="6. Loan Details"></asp:Label></legend>
                <div class="box-body">
                    <%--<div class="container">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                        <div class="form-group">
                            <asp:Label ID="LblLARCCOD" AssociatedControlID="TxtLARCCOD" runat="server" Text="Loan Amount Required CC/OD-Rs"></asp:Label>
                            <asp:TextBox ID="TxtLARCCOD" runat="server" MaxLength="8" onkeypress = "return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                        <div class="form-group">
                            <asp:Label ID="LblLARTermLoan" AssociatedControlID="TxtLARTermLoan" runat="server" Text="Loan Amount Required Term Loan-Rs"></asp:Label>
                            <asp:TextBox ID="TxtLARTermLoan" runat="server" MaxLength="8" onkeypress = "return onlyNumbers(event);"  CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                            <div class="form-group">
                                <asp:CheckBox ID="chkExistingAcc" runat="server" />
                                <asp:Label ID="LblExistingAcc" AssociatedControlID="chkExistingAcc" runat="server" Text="Detail of Existing Accounts ,if any"></asp:Label>

                            </div>
                        </div>
                    </div>

                    <div id="ExistingAccount" style="display: none">
                        <div class="row">
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lblExistingAccType" AssociatedControlID="ddlExistingAccType" runat="server" Text="Account Type" CssClass="manadatory"></asp:Label>
                                    <asp:DropDownList ID="ddlExistingAccType" runat="server" class="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="LblExistingBank" AssociatedControlID="TxtExistingBankName" runat="server" Text="Name of Bank & Branch" CssClass="manadatory"></asp:Label>
                                    <asp:TextBox ID="TxtExistingBankName" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="lblAccountNumber" AssociatedControlID="TxtAccountNumber" runat="server" Text="Account Number" CssClass="manadatory"></asp:Label>
                                    <asp:TextBox ID="TxtAccountNumber" runat="server" MaxLength="16" CssClass="form-control" onkeypress="return onlyNumbers(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <asp:Label ID="LblExistingLoanAmount" AssociatedControlID="TxtExistingLoanAmount" runat="server" Text="If Loan A/c, amount of loan taken" CssClass="manadatory"></asp:Label>
                                    <asp:TextBox ID="TxtExistingLoanAmount" runat="server" MaxLength="8" onkeypress="return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                            <div class="form-group">
                                <asp:HiddenField ID="hiddenApplicationId" runat="server" Value="" />
                                <asp:Label ID="lblSuccessMsg" runat="server" Text="" Visible="false"></asp:Label>
                                <%-- <asp:Button ID="btnSubmit" CssClass="btn btn-sm btn-success" runat="server" Text="Submit"  OnClick="btnSubmit_Click " CausesValidation="false"/>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>


            <fieldset>
                <legend>
                    <asp:Label ID="lblcaptchaText" runat="server" Text="7. Captcha"></asp:Label></legend>
                <%--<div class="box-body">--%>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <%-- <label>Captcha (पडताळणी संकेतांक कोड)</label>--%>
                            <asp:Label ID="Lblcaptcha" AssociatedControlID="txtimgcode" runat="server" Text="Captcha (पडताळणी संकेतांक कोड)" CssClass="manadatory"></asp:Label>
                            <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <label>
                                <label>
                                    <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label>
                                    <%--<span id="sp_captcha" runat="server" style="color: Red">*</span>--%>
                                </label>
                                <asp:TextBox ID="txtCaptchAnswer" runat="server" class="form-control" disabled="true"></asp:TextBox>
                                <asp:HiddenField ID="hdnCaptcha" runat="server" Value="" />
                                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                            </label>
                            <button type="button" onclick="Captcha();" />
                            <img src="../../Images/Refresh.png" alt="Refresh Captcha" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                        <div class="form-group">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-m btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click " CausesValidation="false" />
                        </div>
                    </div>

                </div>

                <%-- </div>--%>
            </fieldset>






            <%--</div>--%>

            <%-- <div class="col-md-12 box-container" >--%>
            <%--<div class="box-heading" >
                    <h4 class="box-title">
                    <asp:Label ID="LblLoan" runat="server" Text="Loan Details"></asp:Label>
                    </h4>
                  </div>--%>
            <%-- <div class="box-body">--%>
            <%--<div class="container">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                        <div class="form-group">
                            <asp:Label ID="LblLARCCOD" AssociatedControlID="TxtLARCCOD" runat="server" Text="Loan Amount Required CC/OD-Rs"></asp:Label>
                            <asp:TextBox ID="TxtLARCCOD" runat="server" MaxLength="8" onkeypress = "return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                        <div class="form-group">
                            <asp:Label ID="LblLARTermLoan" AssociatedControlID="TxtLARTermLoan" runat="server" Text="Loan Amount Required Term Loan-Rs"></asp:Label>
                            <asp:TextBox ID="TxtLARTermLoan" runat="server" MaxLength="8" onkeypress = "return onlyNumbers(event);"  CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                    </div>--%>
            <%--     <div class="container">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                        <div class="form-group">
                            <asp:Label ID="LblExistingAcc" AssociatedControlID="chkExistingAcc" runat="server" Text="Detail of Existing Accounts ,if"></asp:Label>                          
                            <asp:CheckBox ID="chkExistingAcc" runat="server" />
                        </div>
                        </div>
                     </div>

                     <div  id="ExistingAccount" style="display:none">
                         <div class="container">
                                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                                <div class="form-group">  
                                    <asp:Label ID="lblExistingAccType" AssociatedControlID="ddlExistingAccType" runat="server" Text="Account Type"></asp:Label>
                                    <asp:DropDownList ID="ddlExistingAccType" runat="server" class="form-control">
                                   </asp:DropDownList>
                                </div>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                                <div class="form-group">
                                    <asp:Label ID="LblExistingBank" AssociatedControlID="TxtExistingBankName" runat="server" Text="Name of Bank & Branch"></asp:Label>
                                    <asp:TextBox ID="TxtExistingBankName" runat="server"  TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                                </div>
                         </div>
                         <div class="container">
                             <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                                <div class="form-group"> 
                                    <asp:Label ID="lblAccountNumber" AssociatedControlID="TxtAccountNumber" runat="server" Text="Account Number"></asp:Label>
                                    <asp:TextBox ID="TxtAccountNumber" runat="server"  MaxLength="16" CssClass="form-control" onkeypress = "return onlyNumbers(event);"></asp:TextBox>
                                </div>
                                </div>
                             <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                                <div class="form-group"> 
                                    <asp:Label ID="LblExistingLoanAmount" AssociatedControlID="TxtExistingLoanAmount" runat="server" Text="If Loan A/c, amount of loan taken"></asp:Label>
                                    <asp:TextBox ID="TxtExistingLoanAmount" runat="server" MaxLength="8" onkeypress = "return onlyNumbers(event);" CssClass="form-control"></asp:TextBox>
                                </div>
                                </div>
                         </div>
                     </div>
                     
                      <div class="container">
                        <div class="col-xs-12 col-sm-6 col-md-6 col-lg-5">
                        <div class="form-group">
                            <asp:HiddenField id="hiddenApplicationId" runat="server" Value=""/>
                            <asp:Label ID="lblSuccessMsg"  runat="server" Text=""></asp:Label>
                           <asp:Button ID="btnSubmit" CssClass="btn btn-sm btn-success" runat="server" Text="Submit"  OnClick="btnSubmit_Click" CausesValidation="false"/>
                        </div>
                        </div>
                      </div>
                  </div>--%>
            <%--</div>--%>
        </div>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
    <script type="text/javascript">
        function Captcha() {
            var alpha = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z');
            var i;
            for (i = 0; i < 5; i++) {
                var a = alpha[Math.floor(Math.random() * alpha.length)];
                var b = alpha[Math.floor(Math.random() * alpha.length)];
                var c = alpha[Math.floor(Math.random() * alpha.length)];
                var d = alpha[Math.floor(Math.random() * alpha.length)];
                var e = alpha[Math.floor(Math.random() * alpha.length)];

            }
            var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e;
            document.getElementById("SitePH_txtCaptchAnswer").value = code;
            document.getElementById("SitePH_hdnCaptcha").value = code;
        }
    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            Captcha();
        });
    </script>
</asp:Content>
