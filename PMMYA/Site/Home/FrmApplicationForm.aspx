<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="FrmApplicationForm.aspx.cs" Inherits="PMMYA.Site.Home.FrmApplicationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title></title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- Bootstrap core CSS -->
  <%--  <link href="../../Content/PMMY/MDB-Free/css/bootstrap.min.css" rel="stylesheet" />--%>
    <!-- Material Design Bootstrap -->
    <link href="../../Content/PMMY/MDB-Free/css/mdb.min.css" rel="stylesheet" />
    <!-- Your custom styles (optional) -->
    <link href="../../Content/PMMY/MDB-Free/css/style.min.css" rel="stylesheet" />

    <link href="../../Content/PMMY/PMMYApplicationForm.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <!-- SCRIPTS -->
    <!-- JQuery -->
    <script src="../../Content/PMMY/MDB-Free/js/jquery-3.3.1.min.js"></script>
    <!-- Bootstrap tooltips -->
    <script src="../../Content/PMMY/MDB-Free/js/popper.min.js"></script>
    <!-- Bootstrap core JavaScript -->
<%--    <script src="../../Content/PMMY/MDB-Free/js/bootstrap.min.js"></script>--%>
    <!-- MDB core JavaScript -->
    <script src="../../Content/PMMY/MDB-Free/js/mdb.min.js"></script>
    <script src="../../Content/PMMY/PMMYApplicationForm.js"></script>
  <%--  <script src="../../Content/PMMY/jquery-1.3.2.min.js"></script>--%>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    
    <script src="../../Content/PMMY/Validation.js"></script>

<%--    <script src="../../Scripts/html5media.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../assets/bootstrap/js/bootstrap.min.js"></script>--%>

    <h2 class="text-center font-bold pt-4 pb-5 mb-5 application-form-mudra"><strong>Application Form</strong></h2>

     <%--<div class="container">--%>
    <div class="steps-form-2">
        <div class="steps-row-2 setup-panel-2 d-flex justify-content-between">
            <div class="steps-step-2">
                <a href="#step-1" type="button" class="btn btn-amber btn-circle-2 waves-effect ml-0" data-toggle="tooltip" data-placement="top" title="Business Information"><i class="fa fa-briefcase" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-2" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect" data-toggle="tooltip" data-placement="top" title="Info of Proprietor/Partners/Directors"><i class="fa fa-user" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-3" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect" data-toggle="tooltip" data-placement="top" title="Associate Concerns & Nature of Association"><i class="fa fa-file-text" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-4" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect mr-0" data-toggle="tooltip" data-placement="top" title="Banking/Credit Facilities Existing & Proposed"><i class="fa fa-pencil" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-5" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect mr-0" data-toggle="tooltip" data-placement="top" title="Basis of Cash Credit Limit applied"><i class="fa fa-credit-card" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-6" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect mr-0" data-toggle="tooltip" data-placement="top" title="Past Performance / Future Estimates"><i class="fa fa-line-chart" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-7" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect mr-0" data-toggle="tooltip" data-placement="top" title="Statutory Obligations & Declaration"><i class="fa fa-legal" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-8" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect mr-0" data-toggle="tooltip" data-placement="top" title="Select Bank"><i class="fa fa-bank" aria-hidden="true"></i></a>
            </div>
            <div class="steps-step-2">
                <a href="#step-9" type="button" class="btn btn-blue-grey btn-circle-2 waves-effect mr-0" data-toggle="tooltip" data-placement="top" title="Select Bank"><i class="fa fa-check" aria-hidden="true"></i></a>
            </div>
        </div>
    </div>

    <!-- First Step -->
    <form role="form" action="FrmApplicationForm.aspx" method="post">
        <div class="row setup-content-2" id="step-1">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Business Information</strong></h3>
                <div class="form-group">
                    <label for="txtEnterpriseName" data-error="wrong" data-success="right"><b>Name of the Enterprise</b></label>
                    <input id="txtEnterpriseName" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                     <label for="ddlConstitution" data-error="wrong" data-success="right"><b>Constitution</b></label>
                    <select class="form-control" id="ddlConstitution">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Proprietary</option>
                        <option value="2">Partnership</option>
                        <option value="3">Pvt. Ltd.</option>
                        <option value="4">Ltd. Company</option>
                        <option value="5">Any Other</option>
                    </select>
                   
                </div>
                <div class="form-group mt-3">
                    <label for="txtBusinessAddress" data-error="wrong" data-success="right"><b>Current Business Address</b></label>
                    <input id="txtBusinessAddress" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPin" data-error="wrong" data-success="right"><b>Pincode</b></label>
                    <input id="txtPin" type="number" max="999999" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtState" data-error="wrong" data-success="right"><b>State</b></label>
                    <input id="txtState" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtDistrict" data-error="wrong" data-success="right"><b>District</b></label>
                    <input id="txtDistrict" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlLocation" data-error="wrong" data-success="right"><b>Location</b></label>
                    <select class="form-control" id="ddlLocation">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Borivali</option>
                    </select>                    
                </div>
                <div class="form-group">
                    <label for="ddlBusinessPremises" data-error="wrong" data-success="right"><b>Business Premises</b></label>
                    <select class="form-control" id="ddlBusinessPremises">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Owned</option>
                        <option value="2">Rented</option>
                    </select>
                    
                </div>
                <div class="form-group mt-3">
                    <label for="txtMobile" data-error="wrong" data-success="right"><b>Mobile Number</b></label>
                    <input id="txtMobile" type="number" max="9999999999" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtEmail" data-error="wrong" data-success="right"><b>Email</b></label>
                    <input id="txtEmail" type="email" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtBusinessActExisting" data-error="wrong" data-success="right"><b>Business Activity Existing</b></label>
                    <input id="txtBusinessActExisting" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtBusinessActProposed" data-error="wrong" data-success="right"><b>Business Activity Proposed</b></label>
                    <input id="txtBusinessActProposed" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="dtCommencement"><b>Date of Commencement</b></label>
                    <input placeholder="Selected date" type="text" id="dtCommencement" class="form-control datepicker" />                    
                </div>
                <div class="form-group mt-3">
                    <label for="ddlIsunitRegistered" data-error="wrong" data-success="right"><b>Whether the Unit is Registered?</b></label>
                    <select class="form-control" id="ddlIsunitRegistered">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Yes</option>
                        <option value="2">No</option>
                    </select>                    
                </div>
                <div class="form-group mt-3">
                    <label for="txtRegiNumber" data-error="wrong" data-success="right"><b>Registration Number</b></label>
                    <input id="txtRegiNumber" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtResiAddress" data-error="wrong" data-success="right"><b>Residential Address</b></label>
                    <input id="txtResiAddress" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="ddlSocCategory" data-error="wrong" data-success="right"><b>Social Category</b></label>
                    <select class="form-control" id="ddlSocCategory" onchange="SocialCat();">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">SC</option>
                        <option value="2">ST</option>
                        <option value="3">OBC</option>
                        <option value="4">Minority Community</option>
                    </select>                    
                </div>
                <div class="form-group mt-3" id="minority">
                    <label for="ddlMinorityComm" data-error="wrong" data-success="right"><b>Minority Community</b></label>
                    <select class="form-control" id="ddlMinorityComm">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Buddhists</option>
                        <option value="2">Muslims</option>
                        <option value="3">Christians</option>
                        <option value="4">Sikhs</option>
                        <option value="5">Jains</option>
                        <option value="6">Zoroastrians</option>
                    </select>
                    
                </div>
                <button id="BusiInfo" onclick="return BusinessInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Second Step -->
        <div class="row setup-content-2" id="step-2">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Info of Proprietor/Partners/Directors</strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong>1] Partner's Details</strong></h3>
                <div class="form-group">
                    <label for="txtName" data-error="wrong" data-success="right"><b>Name</b></Name></label>
                    <input id="txtName" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                     <label for="dtDOB"><b>Date of Birth</b></label>
                    <input placeholder="Selected date" type="text" id="dtDOB" class="form-control datepicker" />                   
                </div>
                <div class="form-group">
                    <label for="ddlGender" data-error="wrong" data-success="right"><b>Gender</b></label>
                    <select class="form-control" id="ddlGender">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Male</option>
                        <option value="2">Female</option>
                        <option value="3">Other</option>
                    </select>
                </div>
                <div class="form-group mt-3">
                    <label for="txtpartResiAddress" data-error="wrong" data-success="right"><b>Residential Address</b></label>
                    <input id="txtpartResiAddress" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPartMobile" data-error="wrong" data-success="right"><b>Mobile Number</b></label>
                    <input id="txtPartMobile" type="number" max="9999999999" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtQualification" data-error="wrong" data-success="right"><b>Academic Qualification</b></label>
                    <input id="txtQualification" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtExpAct" data-error="wrong" data-success="right"><b>Experience in the line of activity</b></label>
                    <input id="txtExpAct" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlIdProof" data-error="wrong" data-success="right"><b>ID Proof</b></label>
                    <select class="form-control" id="ddlIdProof">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Aadhar</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtIDNum" data-error="wrong" data-success="right"><b>ID Proof Number</b></label>
                    <input id="txtIDNum" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlAddressProof" data-error="wrong" data-success="right"><b>Address Proof</b></label>
                    <select class="form-control" id="ddlAddressProof">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Aadhar</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtAddressProofNum" data-error="wrong" data-success="right"><b>Address Proof Number</b></label>
                    <input id="txtAddressProofNum" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtPANDIN" data-error="wrong" data-success="right"><b> Card/DIN Number</b></label>
                    <input id="txtPANDIN" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtRelationDirectors" data-error="wrong" data-success="right"><b>Relation with official/Directors of bank(If Any)</b></label>
                    <input id="txtRelationDirectors" type="text" required="required" class="form-control validate"/>
                </div>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="PartInfo" onclick="return PartnerInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Third Step -->
        <div class="row setup-content-2" id="step-3">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Associate Concerns & Nature of Association</strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong>1] Associate's Details</strong></h3>
                <div class="form-group">
                    <label for="txtAssociateName" data-error="wrong" data-success="right"><b>Name of Associate Concern</b></label>
                    <input id="txtAssociateName" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtAssociateAddress" data-error="wrong" data-success="right"><b>Address of Associate Concern</b></label>
                    <input id="txtAssociateAddress" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtAssoBankingwith" data-error="wrong" data-success="right"><b>Presently Banking With</b></label>
                    <input id="txtAssoBankingwith" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtAssociateNature" data-error="wrong" data-success="right"><b>Nature of Associate Concern</b></label>
                    <input id="txtAssociateNature" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtAssociateInterest" data-error="wrong" data-success="right"><b>Extent of Interest as a Prop/Partner/Director/ or Just Investor in Associate Concern</b></label>
                    <input id="txtAssociateInterest" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtAssociateRelationship" data-error="wrong" data-success="right"><b>Relationship with the officials/ Director of the bank if any</b></label>
                    <input id="txtAssociateRelationship" type="text" required="required" class="form-control validate" />
                </div>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="AssoctInfo" onclick="return AssociateInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Fourth Step -->
        <div class="row setup-content-2" id="step-4">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Banking/Credit Facilities Existing & Proposed</strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong><b>Credit Facilities (Existing)</b></strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong>Savings Account</strong></h3>
                <div class="form-group mt-3">
                    <label for="txtSBankingWith" data-error="wrong" data-success="right"><b>Presently Banking With</b></label>
                    <input id="txtSBankingWith" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtSOutstanding" data-error="wrong" data-success="right"><b>Outstanding as on</b></label>
                    <input id="txtSOutstanding" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtSAssetStatus" data-error="wrong" data-success="right"><b>Asset Classification Status</b></label>
                    <input id="txtSAssetStatus" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Current Account</strong></h3>
                <div class="form-group">
                    <label for="txtCBankingWith" data-error="wrong" data-success="right"><b>Presently Banking With</b></label>
                    <input id="txtCBankingWith" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCOutstanding" data-error="wrong" data-success="right"><b>Outstanding as on</b></label>
                    <input id="txtCOutstanding" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCAssetStatus" data-error="wrong" data-success="right"><b>Asset Classification Status</b></label>
                    <input id="txtCAssetStatus" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Cash Credit</strong></h3>
                <div class="form-group">
                    <label for="txtCCBankingWith" data-error="wrong" data-success="right"><b>Presently Banking With</b></label>
                    <input id="txtCCBankingWith" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtCCLimitAvailed" data-error="wrong" data-success="right"><b>Limit Availed</b></label>
                    <input id="txtCCLimitAvailed" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCCOutstanding" data-error="wrong" data-success="right"><b>Outstanding as on</b></label>
                    <input id="txtCCOutstanding" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCCSecurityLodged" data-error="wrong" data-success="right"><b>Security Lodged</b></label>
                    <input id="txtCCSecurityLodged" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCCAssetStatus" data-error="wrong" data-success="right"><b>Asset Classification Status</b></label>
                    <input id="txtCCAssetStatus" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Term Loan</strong></h3>
                <div class="form-group">
                    <label for="txtTLBankingWith" data-error="wrong" data-success="right"><b>Presently Banking With</b></label>
                    <input id="txtTLBankingWith" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtTLLimitAvailed" data-error="wrong" data-success="right"><b>Limit Availed</b></label>
                    <input id="txtTLLimitAvailed" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtTLOutstanding" data-error="wrong" data-success="right"><b>Outstanding as on</b></label>
                    <input id="txtTLOutstanding" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtTLSecurityLodged" data-error="wrong" data-success="right"><b>Security Lodged</b></label>
                    <input id="txtTLSecurityLodged" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtTLAssetStatus" data-error="wrong" data-success="right"><b>Asset Classification Status</b></label>
                    <input id="txtTLAssetStatus" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>LG/BG</strong></h3>
                <div class="form-group">
                    <label for="txtLGBGBankingWith" data-error="wrong" data-success="right"><b>Presently Banking With</b></label>
                    <input id="txtLGBGBankingWith" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtLGBGLimitAvailed" data-error="wrong" data-success="right"><b>Limit Availed</b></label>
                    <input id="txtLGBGLimitAvailed" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtLGBGOutstanding" data-error="wrong" data-success="right"><b>Outstanding as on</b></label>
                    <input id="txtLGBGOutstanding" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtLGBGSecurityLodged" data-error="wrong" data-success="right"><b>Security Lodged</b></label>
                    <input id="txtLGBGSecurityLodged" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtLGBGAssetStatus" data-error="wrong" data-success="right"><b>Asset Classification Status</b></label>
                    <input id="txtLGBGAssetStatus" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong><b>Credit Facilities (Proposed)</b></strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong>Cash Credit</strong></h3>
                <div class="form-group">
                    <label for="txtCCAmount" data-error="wrong" data-success="right"><b>Amount</b></label>
                    <input id="txtCCAmount" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtCCRequiredPurpose" data-error="wrong" data-success="right"><b>Purpose for which required</b></label>
                    <input id="txtCCRequiredPurpose" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCCSecurityOffered" data-error="wrong" data-success="right"><b>Details of Primary Security Offered (with approx. value to be mentioned)</b></label>
                    <input id="txtCCSecurityOffered" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Term Loan</strong></h3>
                <div class="form-group">
                    <label for="txtTLAmount" data-error="wrong" data-success="right"><b>Amount</b></label>
                    <input id="txtTLAmount" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtTLRequiredPurpose" data-error="wrong" data-success="right"><b>Purpose for which required</b></label>
                    <input id="txtTLRequiredPurpose" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtTLSecurityOffered" data-error="wrong" data-success="right"><b>Details of Primary Security Offered (with approx. value to be mentioned)</b></label>
                    <input id="txtTLSecurityOffered" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>LG/BG</strong></h3>
                <div class="form-group">
                    <label for="txtLGBGAmount" data-error="wrong" data-success="right"><b>Amount</b></label>
                    <input id="txtLGBGAmount" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtLGBGRequiredPurpose" data-error="wrong" data-success="right"><b>Purpose for which required</b></label>
                    <input id="txtLGBGRequiredPurpose" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtLGBGSecurityOffered" data-error="wrong" data-success="right"><b>Details of Primary Security Offered (with approx. value to be mentioned)</b></label>
                    <input id="txtLGBGSecurityOffered" type="text" required="required" class="form-control validate" />
                </div>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="BankCreditInfo" onclick="return BankingCreditInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Fifth Step -->
        <div class="row setup-content-2" id="step-5">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Basis of Cash Credit Limit applied</strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong><b>In case of Working Capital</b></strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong>Actual Sale</strong></h3>
                <div class="form-group">
                    <label for="txtPreviousFYSale" data-error="wrong" data-success="right"><b>Previous FY Sale</b></label>
                    <input id="txtPreviousFYSale" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCurrentFYSale" data-error="wrong" data-success="right"><b>Current FY Sale</b></label>
                    <input id="txtCurrentFYSale" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Projected</strong></h3>
                <div class="form-group mt-3">
                    <label for="txtSale" data-error="wrong" data-success="right"><b>Sale</b></label>
                    <input id="txtSale" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtWorkingCycle" data-error="wrong" data-success="right"><b>Working Cycle in Months</b></label>
                    <input id="txtWorkingCycle" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtInventory" data-error="wrong" data-success="right"><b>Inventory</b></label>
                    <input id="txtInventory" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtDebtors" data-error="wrong" data-success="right"><b>Debtors</b></label>
                    <input id="txtDebtors" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtCreditors" data-error="wrong" data-success="right"><b>Creditors</b></label>
                    <input id="txtCreditors" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPromotorsContri" data-error="wrong" data-success="right"><b>Promotor's Contribution</b></label>
                    <input id="txtPromotorsContri" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtLimits" data-error="wrong" data-success="right"><b>Limits</b></label>
                    <input id="txtLimits" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong><b>In case of Term Loan Requirement, The Details of Machinery/ Equipment may be given as under</b></strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong>1] Machinery/ Equipment</strong></h3>
                <div class="form-group">
                    <label for="txtMachineEquip" data-error="wrong" data-success="right"><b>Type of Machine/ Equipment</b></label>
                    <input id="txtMachineEquip" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtMachinePurposeReq" data-error="wrong" data-success="right"><b>Purpose for which Required</b></label>
                    <input id="txtMachinePurposeReq" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtSupplierName" data-error="wrong" data-success="right"><b>Name of Supplier</b></label>
                    <input id="txtSupplierName" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtMachineCost" data-error="wrong" data-success="right"><b>Total Cost of Machine</b></label>
                    <input id="txtMachineCost" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="txtPromotorContri" data-error="wrong" data-success="right"><b>Contribution made by Promotors(Rs.)</b></label>
                    <input id="txtPromotorContri" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtLoanRequired" data-error="wrong" data-success="right"><b>Loan Required</b></label>
                    <input id="txtLoanRequired" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtRepaymentPeriod" data-error="wrong" data-success="right"><b>Repayment period with Moratorium period requested for</b></label>
                    <input id="txtRepaymentPeriod" type="text" required="required" class="form-control validate" />
                </div>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="CashCredInfo" onclick="return CashCreditInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Sixth Step -->
        <div class="row setup-content-2" id="step-6">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Past Performance / Future Estimates</strong></h3>
                <h3 class="font-weight-bold pl-0 my-4"><strong>Past Year - II (Actual)</strong></h3>
                <div class="form-group">
                    <label for="txtPYIINetSale" data-error="wrong" data-success="right"><b>Net Sale</b></label>
                    <input id="txtPYIINetSale" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPYIINetProfit" data-error="wrong" data-success="right"><b>Net Profit</b></label>
                    <input id="txtPYIINetProfit" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPYIICapital" data-error="wrong" data-success="right"><b>Capital (Net worth in case of Companies)</b></label>
                    <input id="txtPYIICapital" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Past Year - I (Actual)</strong></h3>
                <div class="form-group">
                    <label for="txtPYINetSale" data-error="wrong" data-success="right"><b>Net Sale</b></label>
                    <input id="txtPYINetSale" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPYINetProfit" data-error="wrong" data-success="right"><b>Net Profit</b></label>
                    <input id="txtPYINetProfit" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPYICapital" data-error="wrong" data-success="right"><b>Capital (Net worth in case of Companies)</b></label>
                    <input id="txtPYICapital" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Present Year (Estimate)</strong></h3>
                <div class="form-group">
                    <label for="txtPYEstNetSale" data-error="wrong" data-success="right"><b>Net Sale</b></label>
                    <input id="txtPYEstNetSale" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPYEstNetProfit" data-error="wrong" data-success="right"><b>Net Profit</b></label>
                    <input id="txtPYEstNetProfit" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtPYEstCapital" data-error="wrong" data-success="right"><b>Capital (Net worth in case of Companies)</b></label>
                    <input id="txtPYEstCapital" type="text" required="required" class="form-control validate" />
                </div>
                <br />
                <h3 class="font-weight-bold pl-0 my-4"><strong>Next Year (Projection)</strong></h3>
                <div class="form-group md-f">
                    <label for="txtNYProjNetSale" data-error="wrong" data-success="right"><b>Net Sale</b></label>
                    <input id="txtNYProjNetSale" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtNYProjNetProfit" data-error="wrong" data-success="right"><b>Net Profit</b></label>
                    <input id="txtNYProjNetProfit" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group mt-3">
                    <label for="txtNYProjCapital" data-error="wrong" data-success="right"></b>Capital (Net worth in case of Companies)</b></label>
                    <input id="txtNYProjCapital" type="text" required="required" class="form-control validate" />
                </div>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="PastFutInfo" onclick="return PastFutureInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Seventh Step -->
        <div class="row setup-content-2" id="step-7">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Satutory Obligations & Declaration</strong></h3>
                <div class="form-group">
                    <label for="ddlRegEstablishment" data-error="wrong" data-success="right"><b>Registration under Shop and Establishment Act</b></label>
                    <select class="form-control" id="ddlRegEstablishment">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Yes</option>
                        <option value="2">No</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtRegEstablishmentRemark" data-error="wrong" data-success="right"><b>Remark (Any details in connection with the relevant Obligation to be given</b></label>
                    <input id="txtRegEstablishmentRemark" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlRegMSME" data-error="wrong" data-success="right"><b>Registration under MSME (Provisional/ Final)</b></label>
                    <select class="form-control" id="ddlRegMSME">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Yes</option>
                        <option value="2">No</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtRegMSMERemark" data-error="wrong" data-success="right"><b>Remark (Any details in connection with the relevant Obligation to be given</b></label>
                    <input id="txtRegMSMERemark" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlDrugLic" data-error="wrong" data-success="right"><b>Drug License</b></label>
                    <select class="form-control" id="ddlDrugLic">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Yes</option>
                        <option value="2">No</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtDrugLicRemark" data-error="wrong" data-success="right"><b>Remark (Any details in connection with the relevant Obligation to be given</b></label>
                    <input id="txtDrugLicRemark" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlSalesTaxFiled" data-error="wrong" data-success="right"><b>Latest Sales Tax Return Filed</b></label>
                    <select class="form-control" id="ddlSalesTaxFiled">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Yes</option>
                        <option value="2">No</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtSalesTaxFiledRemark" data-error="wrong" data-success="right"><b>Remark (Any details in connection with the relevant Obligation to be given</b></label>
                    <input id="txtSalesTaxFiledRemark" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlIncomeTaxFiled" data-error="wrong" data-success="right"><b>Latest Income Tax Return Filed</b></label>
                    <select class="form-control" id="ddlIncomeTaxFiled">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Yes</option>
                        <option value="2">No</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtIncomeTaxFiledRemark" data-error="wrong" data-success="right"><b>Remark (Any details in connection with the relevant Obligation to be given</b></label>
                    <input id="txtIncomeTaxFiledRemark" type="text" required="required" class="form-control validate" />
                </div>
                <div class="form-group">
                    <label for="ddlSatutoryDues" data-error="wrong" data-success="right"><b>Any Satutory dues remaining outstanding</b></label>
                    <select class="form-control" id="ddlSatutoryDues">
                        <option value="" disabled="disabled" selected="selected">Choose your option</option>
                        <option value="1">Yes</option>
                        <option value="2">No</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="txtSatutoryDuesRemark" data-error="wrong" data-success="right"><b>Remark (Any details in connection with the relevant Obligation to be given</b></label>
                    <input id="txtSatutoryDuesRemark" type="text" required="required" class="form-control validate" />
                </div>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="SatuInfo" onclick="return SatutoryInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Eighth Step -->
        <div class="row setup-content-2" id="step-8">
            <h3 class="font-weight-bold pl-0 my-4"><strong>Select Bank</strong></h3>
            <div class="col-md-12">
                <div class="form-group">
                    <label for="ddlBank" data-error="wrong" data-success="right"><b>Select Bank</b></label>
                    <select class="form-control" id="ddlBank">
                        <option value="" disabled="disabled" selected="selected">Select Bank</option>
                        <option value="1">ICICI</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="ddlBranch" data-error="wrong" data-success="right"><b>Select Branch</b></label>
                    <select class="form-control" id="ddlBranch">
                        <option value="" disabled="disabled" selected="selected">Select Branch</option>
                        <option value="1">Borivali</option>
                    </select>
                </div>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="BkInfo" onclick="return BankInfo();" class="btn btn-mdb-color btn-rounded nextBtn-2 float-right" type="button">Next</button>
            </div>
        </div>

        <!-- Ninth Step -->
        <div class="row setup-content-2" id="step-9">
            <div class="col-md-12">
                <h3 class="font-weight-bold pl-0 my-4"><strong>Finish</strong></h3>
                <%--<h2 class="text-center font-weight-bold my-4">Registration completed!</h2>--%>
                <button class="btn btn-mdb-color btn-rounded prevBtn-2 float-left" type="button">Previous</button>
                <button id="btnSubmit" onclick="return SubmitInfo();" class="btn btn-success btn-rounded float-right" type="submit">Submit</button>
            </div>
        </div>
    </form>
    <%--</div>--%>
</asp:Content>
