function BusinessInfo() {
    var a = $('#txtEnterpriseName').val();

    if ($('#txtEnterpriseName').val() == null || $('#txtEnterpriseName').val() == "") {
        myFunction($('#txtEnterpriseName'));
        swal("Please Fill Enterprise Name");
        return false;
    }
    if ($('#ddlConstitution :selected').val() == null || $('#ddlConstitution :selected').val() == "") {
        myFunction($('#ddlConstitution'));
        swal("Please Fill Constitution");
        return false;
    }
    if ($('#txtBusinessAddress').val() == null || $('#txtBusinessAddress').val() == "") {
        myFunction($('#txtBusinessAddress'));
        swal("Please Fill Business Address");
        return false;
    }
    if ($('#txtPin').val() == null || $('#txtPin').val() == "" || $('#txtPin').val().length != 6) {
        myFunction($('#txtPin'));
        swal("Please Fill 6 digit PinCode");
        return false;
    }
    var data = $('#txtPin').val();
    var filter = /^[a-zA-Z0-9]+$/;
    if (!filter.test(data)) {
        swal("Please Fill 6 digit numeric PinCode");
        return false;
    }
    if ($('#ddlState :selected').val() == null || $('#ddlState :selected').val() == "") {
        myFunction($('#ddlState'));
        swal("Please Fill State");
        return false;
    }
    if ($('#ddlDistrict :selected').val() == null || $('#ddlDistrict :selected').val() == "") {
        myFunction($('#ddlDistrict'));
        swal("Please Fill District");
        return false;
    }
    if ($('#ddlLocation :selected').val() == null || $('#ddlLocation :selected').val() == "") {
        myFunction($('#ddlLocation'));
        swal("Please Fill Location");
        return false;
    }
    if ($('#ddlBusinessPremises :selected').val() == null || $('#ddlBusinessPremises :selected').val() == "") {
        myFunction($('#ddlBusinessPremises'));
        swal("Please Fill Business Premises");
        return false;
    }
    if ($('#txtMobile').val() == null || $('#txtMobile').val() == "" || $('#txtMobile').val().length != 10) {
        myFunction($('#txtMobile'));
        swal("Please Fill 10 digit Mobile");
        return false;
    }
    if ($('#txtEmail').val() == null || $('#txtEmail').val() == "") {
        myFunction($('#txtEmail'));
        swal("Please Fill Email");
        return false;
    }
    if ($('#txtBusinessActExisting').val() == null || $('#txtBusinessActExisting').val() == "") {
        myFunction($('#txtBusinessActExisting'));
        swal("Please Fill Business Activity Existing");
        return false;
    }
    if ($('#txtBusinessActProposed').val() == null || $('#txtBusinessActProposed').val() == "") {
        myFunction($('#txtBusinessActProposed'));
        swal("Please Fill Business Activity Proposed");
        return false;
    }
    if ($('#dtCommencement').val() == null || $('#dtCommencement').val() == "") {
        myFunction($('#dtCommencement'));
        swal("Please Fill Date of Commencement");
        return false;
    }
    if ($('#ddlIsunitRegistered :selected').val() == null || $('#ddlIsunitRegistered :selected').val() == "") {
        myFunction($('#ddlIsunitRegistered'));
        swal("Please Fill Whether the Unit is Registered");
        return false;
    }
    if ($('#txtRegiNumber').val() == null || $('#txtRegiNumber').val() == "") {
        myFunction($('#txtRegiNumber'));
        swal("Please Fill Registration Number");
        return false;
    }
    if ($('#txtResiAddress').val() == null || $('#txtResiAddress').val() == "") {
        myFunction($('#txtResiAddress'));
        swal("Please Fill Residential Address");
        return false;
    }
    if ($('#ddlSocCategory :selected').val() == null || $('#ddlSocCategory :selected').val() == "") {
        myFunction($('#ddlSocCategory'));
        swal("Please Fill Social Category");
        return false;
    }
    if ($('#ddlSocCategory :selected').val() == null || $('#ddlSocCategory :selected').val() == "" || $('#ddlSocCategory :selected').val() == "4") {

        if ($('#ddlMinorityComm :selected').val() == null || $('#ddlMinorityComm :selected').val() == "") {
            myFunction($('#ddlMinorityComm'));
            swal("Please Fill Minority Community");
            return false;
        }
    }
    var d = '{"BusiInfo_Enterprise_Name": "' + $('#txtEnterpriseName').val() + '", "BusiInfo_Constitution": "' + $('#ddlConstitution :selected').text() + '", "BusiInfo_Curr_Address": "' + $('#txtBusinessAddress').val() + '", "BusiInfo_Pincode": "' + $('#txtPin').val() + '", "BusiInfo_State": "' + $('#txtState').val() + '", "BusiInfo_District": "' + $('#txtDistrict').val() + '", "BusiInfo_Location": "' + $('#ddlLocation :selected').text() + '", "BusiInfo_Premises": "' + $('#ddlBusinessPremises :selected').text() + '", "BusiInfo_Mobile": "' + $('#txtMobile').val() + '", "BusiInfo_Email": "' + $('#txtEmail').val() + '", "BusiInfo_Act_Existing": "' + $('#txtBusinessActExisting').val() + '", "BusiInfo_Act_Proposed": "' + $('#txtBusinessActProposed').val() + '", "BusiInfo_Commencement_Dt": "' + $('#dtCommencement').val() + '", "BusiInfo_IsUnitReg": "' + $('#ddlIsunitRegistered :selected').text() + '", "BusiInfo_Reg_Number": "' + $('#txtRegiNumber').val() + '", "BusiInfo_Resi_Address": "' + $('#txtResiAddress').val() + '", "BusiInfo_Social_Cat": "' + $('#ddlSocCategory :selected').text() + '", "BusiInfo_MonorityComm": "' + $('#ddlMinorityComm :selected').text() + '" }';
    var f = "";
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/BusinessInfo",
        //data: "{'BusiInfo_Enterprise_Name':'" + a + "'}",
        data: '{"BusiInfo_Enterprise_Name": "' + $('#txtEnterpriseName').val() + '", "BusiInfo_Constitution": "' + $('#ddlConstitution :selected').text() + '", "BusiInfo_Curr_Address": "' + $('#txtBusinessAddress').val() + '", "BusiInfo_Pincode": "' + $('#txtPin').val() + '", "BusiInfo_State": "' + $('#txtState').val() + '", "BusiInfo_District": "' + $('#txtDistrict').val() + '", "BusiInfo_Location": "' + $('#ddlLocation :selected').text() + '", "BusiInfo_Premises": "' + $('#ddlBusinessPremises :selected').text() + '", "BusiInfo_Mobile": "' + $('#txtMobile').val() + '", "BusiInfo_Email": "' + $('#txtEmail').val() + '", "BusiInfo_Act_Existing": "' + $('#txtBusinessActExisting').val() + '", "BusiInfo_Act_Proposed": "' + $('#txtBusinessActProposed').val() + '", "BusiInfo_Commencement_Dt": "' + $('#dtCommencement').val() + '", "BusiInfo_IsUnitReg": "' + $('#ddlIsunitRegistered :selected').text() + '", "BusiInfo_Reg_Number": "' + $('#txtRegiNumber').val() + '", "BusiInfo_Resi_Address": "' + $('#txtResiAddress').val() + '", "BusiInfo_Social_Cat": "' + $('#ddlSocCategory :selected').text() + '", "BusiInfo_MonorityComm": "' + $('#ddlMinorityComm :selected').text() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-briefcase").css("color", "blue");
            //swal("Yes");
        },
        error: function (response) {
            swal(response.error);
        }
    });
}

function myFunction(IDofObject) {
    $('html, body').animate({
        scrollTop: (IDofObject.offset().top)
    }, 500);
}

function PartnerInfo() {
    var a = $('#txtName').val();

    if ($('#txtName').val() == null || $('#txtName').val() == "") {
        myFunction($('#txtName'));
        swal("Please Fill Partner Name");
        return false;
    }
    if ($('#dtDOB').val() == null || $('#dtDOB').val() == "") {
        myFunction($('#dtDOB'));
        swal("Please Fill Date of Birth ");
        return false;
    }
    if ($('#ddlGender').val() == null || $('#ddlGender').val() == "") {
        myFunction($('#ddlGender'));
        swal("Please Fill Gender");
        return false;
    }
    if ($('#txtpartResiAddress').val() == null || $('#txtpartResiAddress').val() == "") {
        myFunction($('#txtpartResiAddress'));
        swal("Please Fill Partner Residential Address");
        return false;
    }
    if ($('#txtPartMobile').val() == null || $('#txtPartMobile').val() == "" || $('#txtPartMobile').val().length != 10) {
        myFunction($('#txtPartMobile'));
        swal("Please Fill 10 digit Mobile");
        return false;
    }
    if ($('#txtQualification').val() == null || $('#txtQualification').val() == "") {
        myFunction($('#txtQualification'));
        swal("Please Fill Academic Qualification");
        return false;
    }
    if ($('#txtExpAct').val() == null || $('#txtExpAct').val() == "") {
        myFunction($('#txtExpAct'));
        swal("Please Fill Experience in the line of activity");
        return false;
    }
    if ($('#ddlIdProof').val() == null || $('#ddlIdProof').val() == "") {
        myFunction($('#ddlIdProof'));
        swal("Please Fill ID Proof");
        return false;
    }
    if ($('#txtIDNum').val() == null || $('#txtIDNum').val() == "") {
        myFunction($('#txtIDNum'));
        swal("Please Fill ID Proof Number");
        return false;
    }
    if ($('#ddlAddressProof').val() == null || $('#ddlAddressProof').val() == "") {
        myFunction($('#ddlAddressProof'));
        swal("Please Fill Address Proof");
        return false;
    }
    if ($('#txtAddressProofNum').val() == null || $('#txtAddressProofNum').val() == "") {
        myFunction($('#txtAddressProofNum'));
        swal("Please Fill Address Proof Number");
        return false;
    }
    if ($('#txtPANDIN').val() == null || $('#txtPANDIN').val() == "") {
        myFunction($('#txtPANDIN'));
        swal("Please Fill PAN Card/DIN Number");
        return false;
    }
    if ($('#txtRelationDirectors').val() == null || $('#txtRelationDirectors').val() == "") {
        myFunction($('#txtRelationDirectors'));
        swal("Please Fill Relation with official/Directors of bank");
        return false;
    }
    var d = '{Partner_Name: "' + $('#txtName').val() + '", Partner_DOB: "' + $('#dtDOB').val() + '", Partner_Gender: "' + $('#ddlGender :selected').text() + '", Partner_Resi_Address: "' + $('#txtpartResiAddress').val() + '", Partner_Mobile: "' + $('#txtPartMobile').val() + '", Partner_Qualification: "' + $('#txtQualification').val() + '", Partner_Exp: "' + $('#txtExpAct').val() + '", Partner_ID_Proof: "' + $('#ddlIdProof :selected').text() + '", Partner_ID_Number: "' + $('#txtIDNum').val() + '", Partner_Addr_Proof: "' + $('#ddlAddressProof :selected').text() + '", Partner_AddrProof_Num: "' + $('#txtAddressProofNum').val() + '", Partner_PAN_DIN_Num: "' + $('#txtPANDIN').val() + '", Partner_Relation: "' + $('#txtRelationDirectors').val() + '" }';
    var f = "";
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/PartnerInfo",
        data: '{Partner_Name: "' + $('#txtName').val() + '", Partner_DOB: "' + $('#dtDOB').val() + '", Partner_Gender: "' + $('#ddlGender :selected').text() + '", Partner_Resi_Address: "' + $('#txtpartResiAddress').val() + '", Partner_Mobile: "' + $('#txtPartMobile').val() + '", Partner_Qualification: "' + $('#txtQualification').val() + '", Partner_Exp: "' + $('#txtExpAct').val() + '", Partner_ID_Proof: "' + $('#ddlIdProof :selected').text() + '", Partner_ID_Number: "' + $('#txtIDNum').val() + '", Partner_Addr_Proof: "' + $('#ddlAddressProof :selected').text() + '", Partner_AddrProof_Num: "' + $('#txtAddressProofNum').val() + '", Partner_PAN_DIN_Num: "' + $('#txtPANDIN').val() + '", Partner_Relation: "' + $('#txtRelationDirectors').val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-user").css("color", "blue");
            //alert("Yes");
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function AssociateInfo() {
    var a = $('#txtAssociateName').val();
    var d = '{Associate_Name: "' + $('#txtAssociateName').val() + '", Associate_Addr: "' + $('#txtAssociateAddress').val() + '", Associate_Present_Banking: "' + $('#txtAssoBankingwith').val() + '", Associate_Nature: "' + $('#txtAssociateNature').val() + '", Associate_Interest: "' + $('#txtAssociateInterest').val() + '", Associate_Relation: "' + $('#txtAssociateRelationship').val() + '"}';
    var f = "";

    if ($('#txtAssociateName').val() == null || $('#txtAssociateName').val() == "") {
        myFunction($('#txtAssociateName'));
        swal("Please Fill Name of Associate Concern");
        return false;
    }
    if ($('#txtAssociateAddress').val() == null || $('#txtAssociateAddress').val() == "") {
        myFunction($('#txtAssociateAddress'));
        swal("Please Fill Address of Associate Concern");
        return false;
    }
    if ($('#txtAssoBankingwith').val() == null || $('#txtAssoBankingwith').val() == "") {
        myFunction($('#txtAssoBankingwith'));
        swal("Please Fill Presently Banking With");
        return false;
    }
    if ($('#txtAssociateNature').val() == null || $('#txtAssociateNature').val() == "") {
        myFunction($('#txtAssociateNature'));
        swal("Please Fill Nature of Associate Concern");
        return false;
    }
    if ($('#txtAssociateInterest').val() == null || $('#txtAssociateInterest').val() == "") {
        myFunction($('#txtAssociateInterest'));
        swal("Please Fill Extent of Interest");
        return false;
    }
    if ($('#txtAssociateRelationship').val() == null || $('#txtAssociateRelationship').val() == "") {
        myFunction($('#txtAssociateRelationship'));
        swal("Please Fill Relationship");
        return false;
    }

    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/AssociateInfo",
        data: '{Associate_Name: "' + $('#txtAssociateName').val() + '", Associate_Addr: "' + $('#txtAssociateAddress').val() + '", Associate_Present_Banking: "' + $('#txtAssoBankingwith').val() + '", Associate_Nature: "' + $('#txtAssociateNature').val() + '", Associate_Interest: "' + $('#txtAssociateInterest').val() + '", Associate_Relation: "' + $('#txtAssociateRelationship').val() + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-file-text").css("color", "blue");
            //alert("Yes");
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function BankingCreditInfo() {
    var a = $('#txtSBankingWith').val();

    if ($('#txtSBankingWith').val() == null || $('#txtSBankingWith').val() == "") {
        myFunction($('#txtSBankingWith'));
        swal("Please Fill Presently Banking With");
        return false;
    }
    if ($('#txtSOutstanding').val() == null || $('#txtSOutstanding').val() == "") {
        myFunction($('#txtSOutstanding'));
        swal("Please Fill Outstanding as on");
        return false;
    }
    if ($('#txtSAssetStatus').val() == null || $('#txtSAssetStatus').val() == "") {
        myFunction($('#txtSAssetStatus'));
        swal("Please Fill Asset Classification Status");
        return false;
    }
    if ($('#txtCBankingWith').val() == null || $('#txtCBankingWith').val() == "") {
        myFunction($('#txtCBankingWith'));
        swal("Please Fill Presently Banking With");
        return false;
    }
    if ($('#txtCOutstanding').val() == null || $('#txtCOutstanding').val() == "") {
        myFunction($('#txtCOutstanding'));
        swal("Please Fill Outstanding as on");
        return false;
    }
    if ($('#txtCAssetStatus').val() == null || $('#txtCAssetStatus').val() == "") {
        myFunction($('#txtCAssetStatus'));
        swal("Please Fill Asset Classification Status");
        return false;
    }
    if ($('#txtCCBankingWith').val() == null || $('#txtCCBankingWith').val() == "") {
        myFunction($('#txtCCBankingWith'));
        swal("Please Fill Presently Banking With");
        return false;
    }
    if ($('#txtCCLimitAvailed').val() == null || $('#txtCCLimitAvailed').val() == "") {
        myFunction($('#txtCCLimitAvailed'));
        swal("Please Fill Limit Availed");
        return false;
    }
    if ($('#txtCCOutstanding').val() == null || $('#txtCCOutstanding').val() == "") {
        myFunction($('#txtCCOutstanding'));
        swal("Please Fill Outstanding as on");
        return false;
    }
    if ($('#txtCCSecurityLodged').val() == null || $('#txtCCSecurityLodged').val() == "") {
        myFunction($('#txtCCSecurityLodged'));
        swal("Please Fill Security Lodged");
        return false;
    }
    if ($('#txtCCAssetStatus').val() == null || $('#txtCCAssetStatus').val() == "") {
        myFunction($('#txtCCAssetStatus'));
        swal("Please Fill Asset Classification Status");
        return false;
    }
    if ($('#txtTLBankingWith').val() == null || $('#txtTLBankingWith').val() == "") {
        myFunction($('#txtTLBankingWith'));
        swal("Please Fill Presently Banking With");
        return false;
    }
    if ($('#txtTLLimitAvailed').val() == null || $('#txtTLLimitAvailed').val() == "") {
        myFunction($('#txtTLLimitAvailed'));
        swal("Please Fill Limit Availed");
        return false;
    }
    if ($('#txtTLOutstanding').val() == null || $('#txtTLOutstanding').val() == "") {
        myFunction($('#txtTLOutstanding'));
        swal("Please Fill Outstanding as on");
        return false;
    }
    if ($('#txtTLSecurityLodged').val() == null || $('#txtTLSecurityLodged').val() == "") {
        myFunction($('#txtTLSecurityLodged'));
        swal("Please Fill Security Lodged");
        return false;
    }
    if ($('#txtTLAssetStatus').val() == null || $('#txtTLAssetStatus').val() == "") {
        myFunction($('#txtTLAssetStatus'));
        swal("Please Fill Asset Classification Status");
        return false;
    }
    if ($('#txtLGBGBankingWith').val() == null || $('#txtLGBGBankingWith').val() == "") {
        myFunction($('#txtLGBGBankingWith'));
        swal("Please Fill Presently Banking With");
        return false;
    }
    if ($('#txtLGBGLimitAvailed').val() == null || $('#txtLGBGLimitAvailed').val() == "") {
        myFunction($('#txtLGBGLimitAvailed'));
        swal("Please Fill Limit Availed");
        return false;
    }
    if ($('#txtLGBGOutstanding').val() == null || $('#txtLGBGOutstanding').val() == "") {
        myFunction($('#txtLGBGOutstanding'));
        swal("Please Fill Outstanding as on");
        return false;
    }
    if ($('#txtLGBGSecurityLodged').val() == null || $('#txtLGBGSecurityLodged').val() == "") {
        myFunction($('#txtLGBGSecurityLodged'));
        swal("Please Fill Security Lodged");
        return false;
    }
    if ($('#txtLGBGAssetStatus').val() == null || $('#txtLGBGAssetStatus').val() == "") {
        myFunction($('#txtLGBGAssetStatus'));
        swal("Please Fill Asset Classification Status");
        return false;
    }
    if ($('#txtCCAmount').val() == null || $('#txtCCAmount').val() == "") {
        myFunction($('#txtCCAmount'));
        swal("Please Fill Amount");
        return false;
    }
    if ($('#txtCCRequiredPurpose').val() == null || $('#txtCCRequiredPurpose').val() == "") {
        myFunction($('#txtCCRequiredPurpose'));
        swal("Please Fill Purpose for which required");
        return false;
    }
    if ($('#txtCCSecurityOffered').val() == null || $('#txtCCSecurityOffered').val() == "") {
        myFunction($('#txtCCSecurityOffered'));
        swal("Please Fill Security Offered");
        return false;
    }
    if ($('#txtTLAmount').val() == null || $('#txtTLAmount').val() == "") {
        myFunction($('#txtTLAmount'));
        swal("Please Fill Amount");
        return false;
    }
    if ($('#txtTLRequiredPurpose').val() == null || $('#txtTLRequiredPurpose').val() == "") {
        myFunction($('#txtTLRequiredPurpose'));
        swal("Please Fill Purpose for which required");
        return false;
    }
    if ($('#txtTLSecurityOffered').val() == null || $('#txtTLSecurityOffered').val() == "") {
        myFunction($('#txtTLSecurityOffered'));
        swal("Please Fill Security Offered");
        return false;
    }
    if ($('#txtLGBGAmount').val() == null || $('#txtLGBGAmount').val() == "") {
        myFunction($('#txtLGBGAmount'));
        swal("Please Fill Amount");
        return false;
    }
    if ($('#txtLGBGRequiredPurpose').val() == null || $('#txtLGBGRequiredPurpose').val() == "") {
        myFunction($('#txtLGBGRequiredPurpose'));
        swal("Please Fill Purpose for which required");
        return false;
    }
    if ($('#txtLGBGSecurityOffered').val() == null || $('#txtLGBGSecurityOffered').val() == "") {
        myFunction($('#txtLGBGSecurityOffered'));
        swal("Please Fill Security Offered");
        return false;
    }

    var d = '{CR_Exist_SA_Banking: "' + $('#txtSBankingWith').val() + '", CR_Exist_SA_Outstanding: "' + $('#txtSOutstanding').val() + '", CR_Exist_SA_Status: "' + $('#txtSAssetStatus').val() + '", CR_Exist_CA_Banking: "' + $('#txtCBankingWith').val() + '", CR_Exist_CA_Outstanding: "' + $('#txtCOutstanding').val() + '", CR_Exist_CA_Status: "' + $('#txtCAssetStatus').val() + '", CR_Exist_CC_Banking: "' + $('#txtCCBankingWith').val() + '", CR_Exist_CC_LimitAvailed: "' + $('#txtCCLimitAvailed').val() + '", CR_Exist_CC_Outstanding: "' + $('#txtCCOutstanding').val() + '", CR_Exist_CC_SecurityLodg: "' + $('#txtCCSecurityLodged').val() + '", CR_Exist_CC_Status: "' + $('#txtCCAssetStatus').val() + '", CR_Exist_TL_Banking: "' + $('#txtTLBankingWith').val() + '", CR_Exist_TL_LimitAvailed: "' + $('#txtTLLimitAvailed').val() + '", CR_Exist_TL_Outstanding: "' + $('#txtTLOutstanding').val() + '", CR_Exist_TL_SecurityLodg: "' + $('#txtTLSecurityLodged').val() + '", CR_Exist_TL_Status: "' + $('#txtTLAssetStatus').val() + '", CR_Exist_LGBG_Banking: "' + $('#txtLGBGBankingWith').val() + '", CR_Exist_LGBG_Limit: "' + $('#txtLGBGLimitAvailed').val() + '", CR_Exist_LGBG_Outstanding: "' + $('#txtLGBGOutstanding').val() + '", CR_Exist_LGBG_SecurityLodg: "' + $('#txtLGBGSecurityLodged').val() + '", CR_Exist_LGBG_Status: "' + $('#txtLGBGAssetStatus').val() + '", CR_Prop_CC_Amount: "' + $('#txtCCAmount').val() + '", CR_Prop_CC_Purpose: "' + $('#txtCCRequiredPurpose').val() + '", CR_Prop_CC_SecurityOffer: "' + $('#txtCCSecurityOffered').val() + '", CR_Prop_TL_Amount: "' + $('#txtTLAmount').val() + '", CR_Prop_TL_Purpose: "' + $('#txtTLRequiredPurpose').val() + '", CR_Prop_TL_SecurityOffer: "' + $('#txtTLSecurityOffered').val() + '", CR_Prop_LGBG_Amount: "' + $('#txtLGBGAmount').val() + '", CR_Prop_LGBG_Purpose: "' + $('#txtLGBGRequiredPurpose').val() + '", CR_Prop_LGBG_SecurityOffer: "' + $('#txtLGBGSecurityOffered').val() + '" }';
    var f = "";
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/BankingCreditInfo",
        data: '{CR_Exist_SA_Banking: "' + $('#txtSBankingWith').val() + '", CR_Exist_SA_Outstanding: "' + $('#txtSOutstanding').val() + '", CR_Exist_SA_Status: "' + $('#txtSAssetStatus').val() + '", CR_Exist_CA_Banking: "' + $('#txtCBankingWith').val() + '", CR_Exist_CA_Outstanding: "' + $('#txtCOutstanding').val() + '", CR_Exist_CA_Status: "' + $('#txtCAssetStatus').val() + '", CR_Exist_CC_Banking: "' + $('#txtCCBankingWith').val() + '", CR_Exist_CC_LimitAvailed: "' + $('#txtCCLimitAvailed').val() + '", CR_Exist_CC_Outstanding: "' + $('#txtCCOutstanding').val() + '", CR_Exist_CC_SecurityLodg: "' + $('#txtCCSecurityLodged').val() + '", CR_Exist_CC_Status: "' + $('#txtCCAssetStatus').val() + '", CR_Exist_TL_Banking: "' + $('#txtTLBankingWith').val() + '", CR_Exist_TL_LimitAvailed: "' + $('#txtTLLimitAvailed').val() + '", CR_Exist_TL_Outstanding: "' + $('#txtTLOutstanding').val() + '", CR_Exist_TL_SecurityLodg: "' + $('#txtTLSecurityLodged').val() + '", CR_Exist_TL_Status: "' + $('#txtTLAssetStatus').val() + '", CR_Exist_LGBG_Banking: "' + $('#txtLGBGBankingWith').val() + '", CR_Exist_LGBG_Limit: "' + $('#txtLGBGLimitAvailed').val() + '", CR_Exist_LGBG_Outstanding: "' + $('#txtLGBGOutstanding').val() + '", CR_Exist_LGBG_SecurityLodg: "' + $('#txtLGBGSecurityLodged').val() + '", CR_Exist_LGBG_Status: "' + $('#txtLGBGAssetStatus').val() + '", CR_Prop_CC_Amount: "' + $('#txtCCAmount').val() + '", CR_Prop_CC_Purpose: "' + $('#txtCCRequiredPurpose').val() + '", CR_Prop_CC_SecurityOffer: "' + $('#txtCCSecurityOffered').val() + '", CR_Prop_TL_Amount: "' + $('#txtTLAmount').val() + '", CR_Prop_TL_Purpose: "' + $('#txtTLRequiredPurpose').val() + '", CR_Prop_TL_SecurityOffer: "' + $('#txtTLSecurityOffered').val() + '", CR_Prop_LGBG_Amount: "' + $('#txtLGBGAmount').val() + '", CR_Prop_LGBG_Purpose: "' + $('#txtLGBGRequiredPurpose').val() + '", CR_Prop_LGBG_SecurityOffer: "' + $('#txtLGBGSecurityOffered').val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-pencil").css("color", "blue");
            //alert("Yes");
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function CashCreditInfo() {
    var a = $('#txtPreviousFYSale').val();

    $('#txtMachineCost').val()
    $('#txtPromotorContri').val()
    $('#txtLoanRequired').val()
    $('#txtRepaymentPeriod').val()

    if ($('#txtPreviousFYSale').val() == null || $('#txtPreviousFYSale').val() == "") {
        myFunction($('#txtPreviousFYSale'));
        swal("Please Fill Previous FY Sale");
        return false;
    }
    if ($('#txtCurrentFYSale').val() == null || $('#txtCurrentFYSale').val() == "") {
        myFunction($('#txtCurrentFYSale'));
        swal("Please Fill Current FY Sale");
        return false;
    }
    if ($('#txtSale').val() == null || $('#txtSale').val() == "") {
        myFunction($('#txtSale'));
        swal("Please Fill Sale");
        return false;
    }
    if ($('#txtWorkingCycle').val() == null || $('#txtWorkingCycle').val() == "") {
        myFunction($('#txtWorkingCycle'));
        swal("Please Fill Working Cycle in Months");
        return false;
    }
    if ($('#txtInventory').val() == null || $('#txtInventory').val() == "") {
        myFunction($('#txtInventory'));
        swal("Please Fill Inventory");
        return false;
    }
    if ($('#txtDebtors').val() == null || $('#txtDebtors').val() == "") {
        myFunction($('#txtDebtors'));
        swal("Please Fill Debtors");
        return false;
    }
    if ($('#txtCreditors').val() == null || $('#txtCreditors').val() == "") {
        myFunction($('#txtCreditors'));
        swal("Please Fill Creditors");
        return false;
    }
    if ($('#txtPromotorsContri').val() == null || $('#txtPromotorsContri').val() == "") {
        myFunction($('#txtPromotorsContri'));
        swal("Please Fill Promotor's Contribution");
        return false;
    }
    if ($('#txtLimits').val() == null || $('#txtLimits').val() == "") {
        myFunction($('#txtLimits'));
        swal("Please Fill Limits");
        return false;
    }
    if ($('#txtMachineEquip').val() == null || $('#txtMachineEquip').val() == "") {
        myFunction($('#txtMachineEquip'));
        swal("Please Fill Type of Machine/ Equipment");
        return false;
    }
    if ($('#txtMachinePurposeReq').val() == null || $('#txtMachinePurposeReq').val() == "") {
        myFunction($('#txtMachinePurposeReq'));
        swal("Please Fill Purpose for which Required");
        return false;
    }
    if ($('#txtSupplierName').val() == null || $('#txtSupplierName').val() == "") {
        myFunction($('#txtSupplierName'));
        swal("Please Fill Name of Supplier");
        return false;
    }
    if ($('#txtMachineCost').val() == null || $('#txtMachineCost').val() == "") {
        myFunction($('#txtMachineCost'));
        swal("Please Fill Total Cost of Machine");
        return false;
    }
    if ($('#txtPromotorContri').val() == null || $('#txtPromotorContri').val() == "") {
        myFunction($('#txtPromotorContri'));
        swal("Please Fill Contribution made by Promotors(Rs.)");
        return false;
    }
    if ($('#txtLoanRequired').val() == null || $('#txtLoanRequired').val() == "") {
        myFunction($('#txtLoanRequired'));
        swal("Please Fill Loan Required");
        return false;
    }
    if ($('#txtRepaymentPeriod').val() == null || $('#txtRepaymentPeriod').val() == "") {
        myFunction($('#txtRepaymentPeriod'));
        swal("Please Fill Repayment period");
        return false;
    }

    var d = '{CCL_WC_ActSale_previousFY: "' + $('#txtPreviousFYSale').val() + '", CCL_WC_ActSale_currFY: "' + $('#txtCurrentFYSale').val() + '", CCL_WC_Proj_Sale: "' + $('#txtSale').val() + '", CCL_WC_Proj_Cycle: "' + $('#txtWorkingCycle').val() + '", CCL_WC_Proj_Inventory: "' + $('#txtInventory').val() + '", CCL_WC_Proj_Debtors: "' + $('#txtDebtors').val() + '", CCL_WC_Proj_Creditors: "' + $('#txtCreditors').val() + '", CCL_WC_Proj_Promot_Contri: "' + $('#txtPromotorsContri').val() + '", CCL_WC_Proj_Limit: "' + $('#txtLimits').val() + '", CCL_TL_MachineEquip: "' + $('#txtMachineEquip').val() + '", CCL_TL_Purpose: "' + $('#txtMachinePurposeReq').val() + '", CCL_TL_SupplierName: "' + $('#txtSupplierName').val() + '", CCL_TL_MachineCost: "' + $('#txtMachineCost').val() + '", CCL_TL_Promote_Contri: "' + $('#txtPromotorContri').val() + '", CCL_TL_Loan_Req: "' + $('#txtLoanRequired').val() + '", CCL_TL_Repayment_Period: "' + $('#txtRepaymentPeriod').val() + '" }';
    var f = "";
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/CashCreditInfo",
        data: '{CCL_WC_ActSale_previousFY: "' + $('#txtPreviousFYSale').val() + '", CCL_WC_ActSale_currFY: "' + $('#txtCurrentFYSale').val() + '", CCL_WC_Proj_Sale: "' + $('#txtSale').val() + '", CCL_WC_Proj_Cycle: "' + $('#txtWorkingCycle').val() + '", CCL_WC_Proj_Inventory: "' + $('#txtInventory').val() + '", CCL_WC_Proj_Debtors: "' + $('#txtDebtors').val() + '", CCL_WC_Proj_Creditors: "' + $('#txtCreditors').val() + '", CCL_WC_Proj_Promot_Contri: "' + $('#txtPromotorsContri').val() + '", CCL_WC_Proj_Limit: "' + $('#txtLimits').val() + '", CCL_TL_MachineEquip: "' + $('#txtMachineEquip').val() + '", CCL_TL_Purpose: "' + $('#txtMachinePurposeReq').val() + '", CCL_TL_SupplierName: "' + $('#txtSupplierName').val() + '", CCL_TL_MachineCost: "' + $('#txtMachineCost').val() + '", CCL_TL_Promote_Contri: "' + $('#txtPromotorContri').val() + '", CCL_TL_Loan_Req: "' + $('#txtLoanRequired').val() + '", CCL_TL_Repayment_Period: "' + $('#txtRepaymentPeriod').val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-credit-card").css("color", "blue");
            //alert("Yes");
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function PastFutureInfo() {
    var a = $('#txtPYIINetSale').val();

    if ($('#txtPYIINetSale').val() == null || $('#txtPYIINetSale').val() == "") {
        myFunction($('#txtPYIINetSale'));
        swal("Please Fill Net Sale");
        return false;
    }
    if ($('#txtPYIINetProfit').val() == null || $('#txtPYIINetProfit').val() == "") {
        myFunction($('#txtPYIINetProfit'));
        swal("Please Fill Net Profit");
        return false;
    }
    if ($('#txtPYIICapital').val() == null || $('#txtPYIICapital').val() == "") {
        myFunction($('#txtPYIICapital'));
        swal("Please Fill Capital");
        return false;
    }
    if ($('#txtPYINetSale').val() == null || $('#txtPYINetSale').val() == "") {
        myFunction($('#txtPYINetSale'));
        swal("Please Fill Net Sale");
        return false;
    }
    if ($('#txtPYINetProfit').val() == null || $('#txtPYINetProfit').val() == "") {
        myFunction($('#txtPYINetProfit'));
        swal("Please Fill Net Profit");
        return false;
    }
    if ($('#txtPYICapital').val() == null || $('#txtPYICapital').val() == "") {
        myFunction($('#txtPYICapital'));
        swal("Please Fill Capital");
        return false;
    }
    if ($('#txtPYEstNetSale').val() == null || $('#txtPYEstNetSale').val() == "") {
        myFunction($('#txtPYEstNetSale'));
        swal("Please Fill Net Sale");
        return false;
    }
    if ($('#txtPYEstNetProfit').val() == null || $('#txtPYEstNetProfit').val() == "") {
        myFunction($('#txtPYEstNetProfit'));
        swal("Please Fill Net Profit");
        return false;
    }
    if ($('#txtPYEstCapital').val() == null || $('#txtPYEstCapital').val() == "") {
        myFunction($('#txtPYEstCapital'));
        swal("Please Fill Capital");
        return false;
    }
    if ($('#txtNYProjNetSale').val() == null || $('#txtNYProjNetSale').val() == "") {
        myFunction($('#txtNYProjNetSale'));
        swal("Please Fill Net Sale");
        return false;
    }
    if ($('#txtNYProjNetProfit').val() == null || $('#txtNYProjNetProfit').val() == "") {
        myFunction($('#txtNYProjNetProfit'));
        swal("Please Fill Net Profit");
        return false;
    }
    if ($('#txtNYProjCapital').val() == null || $('#txtNYProjCapital').val() == "") {
        myFunction($('#txtNYProjCapital'));
        swal("Please Fill Capital");
        return false;
    }

    var d = '{PastPerf_PYII_Act_NetSale: "' + $('#txtPYIINetSale').val() + '", PastPerf_PYII_Act_NetProfit: "' + $('#txtPYIINetProfit').val() + '", PastPerf_PYII_Act_Capital: "' + $('#txtPYIICapital').val() + '", PastPerf_PYI_Act_NetSale: "' + $('#txtPYINetSale').val() + '", PastPerf_PYI_Act_NetProfit: "' + $('#txtPYINetProfit').val() + '", PastPerf_PYI_Act_Capital: "' + $('#txtPYICapital').val() + '", PresentYear_Est_NetSale: "' + $('#txtPYEstNetSale').val() + '", PresentYear_Est_NetProfit: "' + $('#txtPYEstNetProfit').val() + '", PresentYear_Est_Capital: "' + $('#txtPYEstCapital').val() + '", NextYear_Proj_NetSale: "' + $('#txtNYProjNetSale').val() + '", NextYear_Proj_NetProfit: "' + $('#txtNYProjNetProfit').val() + '", NextYear_Proj_Capital: "' + $('#txtNYProjCapital').val() + '" }';
    var f = "";
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/PastFutureInfo",
        data: '{PastPerf_PYII_Act_NetSale: "' + $('#txtPYIINetSale').val() + '", PastPerf_PYII_Act_NetProfit: "' + $('#txtPYIINetProfit').val() + '", PastPerf_PYII_Act_Capital: "' + $('#txtPYIICapital').val() + '", PastPerf_PYI_Act_NetSale: "' + $('#txtPYINetSale').val() + '", PastPerf_PYI_Act_NetProfit: "' + $('#txtPYINetProfit').val() + '", PastPerf_PYI_Act_Capital: "' + $('#txtPYICapital').val() + '", PresentYear_Est_NetSale: "' + $('#txtPYEstNetSale').val() + '", PresentYear_Est_NetProfit: "' + $('#txtPYEstNetProfit').val() + '", PresentYear_Est_Capital: "' + $('#txtPYEstCapital').val() + '", NextYear_Proj_NetSale: "' + $('#txtNYProjNetSale').val() + '", NextYear_Proj_NetProfit: "' + $('#txtNYProjNetProfit').val() + '", NextYear_Proj_Capital: "' + $('#txtNYProjCapital').val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-line-chart").css("color", "blue");
            //alert("Yes");
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function SatutoryInfo() {
    var a = $('#ddlRegEstablishment :selected').text();

    if ($('#ddlRegEstablishment').val() == null || $('#ddlRegEstablishment').val() == "") {
        myFunction($('#ddlRegEstablishment'));
        swal("Please Select Option");
        return false;
    }
    if ($('#txtRegEstablishmentRemark').val() == null || $('#txtRegEstablishmentRemark').val() == "") {
        myFunction($('#txtRegEstablishmentRemark'));
        swal("Please Fill Remark");
        return false;
    }
    if ($('#ddlRegMSME').val() == null || $('#ddlRegMSME').val() == "") {
        myFunction($('#ddlRegMSME'));
        swal("Please Select Option");
        return false;
    }
    if ($('#txtRegMSMERemark').val() == null || $('#txtRegMSMERemark').val() == "") {
        myFunction($('#txtRegMSMERemark'));
        swal("Please Fill Remark");
        return false;
    }
    if ($('#ddlDrugLic').val() == null || $('#ddlDrugLic').val() == "") {
        myFunction($('#ddlDrugLic'));
        swal("Please Select Option");
        return false;
    }
    if ($('#txtDrugLicRemark').val() == null || $('#txtDrugLicRemark').val() == "") {
        myFunction($('#txtDrugLicRemark'));
        swal("Please Fill Remark");
        return false;
    }
    if ($('#ddlSalesTaxFiled').val() == null || $('#ddlSalesTaxFiled').val() == "") {
        myFunction($('#ddlSalesTaxFiled'));
        swal("Please Select Option");
        return false;
    }

    if ($('#txtSalesTaxFiledRemark').val() == null || $('#txtSalesTaxFiledRemark').val() == "") {
        myFunction($('#txtSalesTaxFiledRemark'));
        swal("Please Fill Remark");
        return false;
    }
    if ($('#ddlIncomeTaxFiled').val() == null || $('#ddlIncomeTaxFiled').val() == "") {
        myFunction($('#ddlIncomeTaxFiled'));
        swal("Please Select Option");
        return false;
    }
    if ($('#txtIncomeTaxFiledRemark').val() == null || $('#txtIncomeTaxFiledRemark').val() == "") {
        myFunction($('#txtIncomeTaxFiledRemark'));
        swal("Please Fill Remark");
        return false;
    }
    if ($('#ddlSatutoryDues').val() == null || $('#ddlSatutoryDues').val() == "") {
        myFunction($('#ddlSatutoryDues'));
        swal("Please Select Option");
        return false;
    }
    if ($('#txtSatutoryDuesRemark').val() == null || $('#txtSatutoryDuesRemark').val() == "") {
        myFunction($('#txtSatutoryDuesRemark'));
        swal("Please Fill Remark");
        return false;
    }

    var d = '{SatutoryObl_Reg_Shop: "' + $('#ddlRegEstablishment :selected').text() + '", SatutoryObl_Reg_ShopRemark: "' + $('#txtRegEstablishmentRemark').val() + '", SatutoryObl_Reg_MSME: "' + $('#ddlRegMSME :selected').text() + '", SatutoryObl_Reg_MSMERemark: "' + $('#txtRegMSMERemark').val() + '", SatutoryObl_DrugLicense: "' + $('#ddlDrugLic :selected').text() + '", SatutoryObl_DrugLicense_Remark: "' + $('#txtDrugLicRemark').val() + '", SatutoryObl_SaleReturn_File: "' + $('#ddlSalesTaxFiled :selected').text() + '", SatutoryObl_SaleReturn_File_Remark: "' + $('#txtSalesTaxFiledRemark').val() + '", SatutoryObl_ITReturn_File: "' + $('#ddlIncomeTaxFiled :selected').text() + '", SatutoryObl_ITReturn_File_Remark: "' + $('#txtIncomeTaxFiledRemark').val() + '", SatutoryObl_Dues_Remain: "' + $('#ddlSatutoryDues :selected').text() + '", SatutoryObl_Dues_RemainRemark: "' + $('#txtSatutoryDuesRemark').val() + '" }';
    var f = "";
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/SatutoryInfo",
        data: '{SatutoryObl_Reg_Shop: "' + $('#ddlRegEstablishment :selected').text() + '", SatutoryObl_Reg_ShopRemark: "' + $('#txtRegEstablishmentRemark').val() + '", SatutoryObl_Reg_MSME: "' + $('#ddlRegMSME :selected').text() + '", SatutoryObl_Reg_MSMERemark: "' + $('#txtRegMSMERemark').val() + '", SatutoryObl_DrugLicense: "' + $('#ddlDrugLic :selected').text() + '", SatutoryObl_DrugLicense_Remark: "' + $('#txtDrugLicRemark').val() + '", SatutoryObl_SaleReturn_File: "' + $('#ddlSalesTaxFiled :selected').text() + '", SatutoryObl_SaleReturn_File_Remark: "' + $('#txtSalesTaxFiledRemark').val() + '", SatutoryObl_ITReturn_File: "' + $('#ddlIncomeTaxFiled :selected').text() + '", SatutoryObl_ITReturn_File_Remark: "' + $('#txtIncomeTaxFiledRemark').val() + '", SatutoryObl_Dues_Remain: "' + $('#ddlSatutoryDues :selected').text() + '", SatutoryObl_Dues_RemainRemark: "' + $('#txtSatutoryDuesRemark').val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-legal").css("color", "blue");
            //alert("Yes");
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function BankInfo() {
    var a = $('#ddlBank :selected').text();

    if ($('#ddlBank').val() == null || $('#ddlBank').val() == "") {
        myFunction($('#ddlBank'));
        swal("Please Select Bank");
        return false;
    }
    if ($('#ddlBranch').val() == null || $('#ddlBranch').val() == "") {
        myFunction($('#ddlBranch'));
        swal("Please Select Branch");
        return false;
    }

    var d = '{Bank: "' + $('#ddlBank :selected').text() + '", Bank_Branch: "' + $('#ddlBranch :selected').text() + '" }';
    var f = "";
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/BankInfo",
        data: '{Bank: "' + $('#ddlBank :selected').text() + '", Bank_Branch: "' + $('#ddlBranch :selected').text() + '", Branch_ID: "' + $('#ddlBranch :selected').val() + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("i.fa.fa-bank").css("color", "blue");
            //alert("Yes");
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function SubmitInfo() {

    window.location = 'LoanApplicationFormPMMYA.aspx';

    //$.ajax({
    //    type: "POST",
    //    url: "FrmApplicationForm.aspx/SubmitInfo",
    //    data: '{Bank: "' + $('#ddlBank :selected').text() + '", Bank_Branch: "' + $('#ddlBranch :selected').text() + '" }',
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: function (data) {
    //        window.location = 'LoanApplicationFormPMMYA.aspx';
    //    },
    //    error: function (response) {
    //        alert(response.error);
    //    }
    //});
}


function GetDistrict(type, id, Branch) {
    var a = type;
    var b = id;
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/GetLocations",
        data: '{type: "' + type + '", id: "' + id + '", Branch: "' + Branch + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#ddlDistrict').find('option').remove().end().append('<option value="" disabled="disabled" selected="selected">Select District</option>').val('whatever');
            $.each(response.d, function (data, value) {
                $("#ddlDistrict").append($("<option></option>").val(value.Name).html(value.Value));
            })
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function GetTaluka(type, id, Branch) {
    var a = type;
    var b = id;
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/GetLocations",
        data: '{type: "' + type + '", id: "' + id + '", Branch: "' + Branch + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#ddlLocation').find('option').remove().end().append('<option value="" disabled="disabled" selected="selected">Select Taluka</option>').val('whatever');
            $.each(response.d, function (data, value) {
                $("#ddlLocation").append($("<option></option>").val(value.Name).html(value.Value));
            })
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function GetBank(type, id, Branch) {
    var a = type;
    var b = id;
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/GetLocations",
        data: '{type: "' + type + '", id: "' + id + '", Branch: "' + Branch + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#ddlBank').find('option').remove().end().append('<option value="" disabled="disabled" selected="selected">Select Taluka</option>').val('whatever');
            $.each(response.d, function (data, value) {
                $("#ddlBank").append($("<option></option>").val(value.Name).html(value.Value));
            })
        },
        error: function (response) {
            alert(response.error);
        }
    });
}

function GetBranch(type, id, Branch) {
    var a = type;
    var b = id;
    $.ajax({
        type: "POST",
        url: "FrmApplicationForm.aspx/GetLocations",
        data: '{type: "' + type + '", id: "' + id + '", Branch: "' + Branch + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $('#ddlBranch').find('option').remove().end().append('<option value="" disabled="disabled" selected="selected">Select Taluka</option>').val('whatever');
            $.each(response.d, function (data, value) {
                $("#ddlBranch").append($("<option></option>").val(value.Name).html(value.Value));
            })
        },
        error: function (response) {
            alert(response.error);
        }
    });
}


function SocialCat() {

    if ($('#ddlSocCategory :selected').val() == 4) {
        $('#minority').show();
    }
    else {
        $('#minority').hide();
    }

}

function Fillddl(str) {

    if (str == "") return;
    else {
        DistrictInfo();
    }

}

function getdate() {
    $('.datepicker').pickadate();
}