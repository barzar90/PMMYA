<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanApplicationFormPMMYA.aspx.cs" Inherits="PMMYA.Site.Home.LoanApplicationFormPMMYA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../assets/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <%--<form id="form1" runat="server">--%>

        <%--<div>
            <img src="http://localhost:64857//Images/mudra.jpg" runat="server" style="height: 93px; width: 369px" />
        </div>--%>
        <div>

            <asp:Label ID="lblLoanAppnFormPMMYA" Text="LOAN APPLICATION FORMPRADHAN MANTRI MUDRA YOJANA
( To be submitted along with documents as per the check list )"
                runat="server"></asp:Label>
        </div>

        <div>
            <br>
            <%--<asp:Label ID="lblLoanAppnFormForOfficeUsePMMYA" runat="server" Text="A. For office Use: "></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table border="1" width="100%">
                    <tr>
                        <td>EnterpriseName</td>
                        <td>Application Sl. No.</td>
                        <td>Name of the Branch</td>
                        <td>Category</td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEnterpriseName" runat="server" Text="EnterpriseName"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblApplicationSlNo" runat="server" Text="Application Sl. No."></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNameOfTheBranch" runat="server" Text="Name of the Branch"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblCategoryValue" runat="server" Text="Shishu/Kishor/Tarun"></asp:Label></td>
                    </tr>

                </table>


            </div>
            <br>--%>
            <asp:Label ID="Label3" runat="server" Text="B.Business Information: "></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">


                <table width="100%" border="1" style="padding:5px">
                    <tr>
                        <td class="auto-style2">Name of the Enterprise</td>
                        <td colspan="7" class="auto-style2">
                            <asp:Label ID="lblBusiInfo_Enterprise_NameValue" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>Constitution                            
                        </td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_ConstitutionValue" runat="server" Text="Constitution "></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Current Business Address                          
                        </td>
                        <td colspan="7" class="auto-style1">
                            <asp:Label ID="lblBusiInfo_Curr_AddressValue" runat="server" Text="Current Business Address "></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <%-- <td>                            
                           Telephone No.                   
                        </td>
                          <td colspan="3">                            
                           <asp:Label ID="Label28" runat="server" Text="Telephone No."></asp:Label>                            
                        </td>--%>
                        <td>Mobile No.                        
                        </td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_MobileValue" runat="server" Text="Mobile No."></asp:Label>
                        </td>

                    </tr>


                    <%-- <tr>
                        
                       
                        <td rowspan="2">Current Business Address </td>
                         <td>
                            
                         </td>
                       
                           
                        <td>State</td>
                        <td>
                            <asp:Label ID="lblCurrentBusinessAddValue" runat="server" Text="Maharashtra"></asp:Label></td>
                        <td>Pin Code</td>
                        <td>
                            <asp:Label ID="lblPinCodeValue" runat="server" Text="441106"></asp:Label></td>
                        <td></td>
                        <td></td>
                               
                           
                    </tr>--%>

                    <tr>
                        <td>E-mail:</td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_EmailValue" runat="server"></asp:Label></td>

                    </tr>

                    <tr>
                        <td>Business Activity</td>

                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_Act_ExistingValue" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Business Activity</td>

                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_Act_ProposedValue" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Date of Commencement(DD/MM/YYYY)</td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_Commencement_DtValue" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td>Whether the Unit is Registered</td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_IsUnitRegValue" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>If Registered (Please mention:Registration no. And the Act under which registered )</td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_Reg_NumberValue" runat="server" Text="If Registered (Please mention:Registration no. And the Act under which registered )"></asp:Label></td>

                    </tr>
                    <tr>
                        <td>Registered office Address</td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_Resi_AddressValue" runat="server"></asp:Label></td>

                    </tr>
                    <tr>
                        <td>Social Category </td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_Social_CatValue" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>If Minority Community </td>
                        <td colspan="7">
                            <asp:Label ID="lblBusiInfo_MonorityCommValue" runat="server" ></asp:Label></td>
                    </tr>
                </table>
            </div>




        </div>

        <div>
            <br>
            <asp:Label ID="Label4" runat="server" Text="C.Background Information of Proprietor/ Partners/ Directors: "></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>S.No</td>
                        <td>Name </td>
                        <td>Date of
Birth</td>
                        <td>Sex </td>
                        <td>Residential
Address with
Mobile No.
                        </td>
                        <td>Academic
Qualification</td>
                        <td>Experience in
the line of
activity (Years)</td>
                    </tr>
                    <tr>
                        <td>1.</td>
                        <td>
                            <asp:Label ID="lblPartenersNameValue" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPartnersDOBValue" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPartnerPartner_GenderValue" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblResidentialAddWithMobNoValue" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lbllpartnerQualificationValue" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPartnerExperienceValue" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <%-- <tr>
                        <td>2.</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>--%>
                </table>
            </div>
        </div>
        <div>
            <br>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>S.No</td>
                        <td>Id proof </td>
                        <td>DId proof
no.</td>
                        <td>Address
proof </td>
                        <td>Address
proof no.
                        </td>
                        <td>PAN
Card/DIN No.</td>
                        <td>Relationship with the
officials/ Director of the
bank if any</td>
                    </tr>
                    <tr>
                        <td>1.</td>
                        <td>
                            <asp:Label ID="lblRelationshipwithanyIdProof" runat="server" Text="1"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRelationshipwithanyDidProofno" runat="server" Text="1"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRelationshipwithanyAddressProof" runat="server" Text="1"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRelationshipwithanyAddressProofNo" runat="server" Text="1"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRelationshipwithanyPanCard" runat="server" Text="1"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblRelationship" runat="server" Text="1"></asp:Label></td>
                    </tr>
                    <%--<tr>
                        <td>2.</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>--%>
                </table>
            </div>
        </div>

        <div>
            <br>
            <asp:Label ID="Label5" runat="server" Text="D. Names of Associate Concerns and Nature of Association: 
"></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Names of
Associate
Concern</td>
                        <td>Address of
Associate
Concern
                        </td>
                        <td>Presently
Banking with</td>
                        <td>Nature of
Association
Concern </td>
                        <td>Extent of Interest as a
Prop./Partner/ Director or Just
Investor in Associate Concern 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNameofAssociates" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblAddressofAssociates" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPresentlyBanking" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNatureOfAssociates" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblInvestorAssociation" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <%--<tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>--%>
                </table>
            </div>
        </div>

        <div>
            <br>
            <asp:Label ID="Label6" runat="server" Text="E. Banking/Credit Facilities Existing: (In Rs.) "></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td class="auto-style1">Type of
Facilities</td>
                        <td>Presently
Banking with </td>
                        <td>Limit
Availed</td>
                        <td>Outstanding
As on …… </td>
                        <td>Security
lodged
                        </td>
                        <td>Asset
classification
status</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Savings Account </td>
                        <td>
                            <asp:Label ID="lblSavingAccount" runat="server" Text="">
                            </asp:Label></td>
                        <td>N. A.</td>
                        <td>
                            <asp:Label ID="lblSavingOutstanding" runat="server" Text="">
                            </asp:Label></td>
                        <td>N. A.</td>
                        <td>
                            <asp:Label ID="lblSavingAssessetClassification" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Current Account </td>
                        <td>
                            <asp:Label ID="lblCurrentAccount" runat="server" Text="">
                            </asp:Label></td>
                        <td>N. A.</td>
                        <td>
                            <asp:Label ID="lblCurrentOutstanding" runat="server" Text="">
                            </asp:Label></td>
                        <td>N. A.</td>
                        <td>
                            <asp:Label ID="lblCurrentAssessetClassification" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Cash Credit </td>
                        <td>
                            <asp:Label ID="lblCashCredit" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCashCreditLimitAvailed" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCashCreditOutstanding" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblSecurityLodgedOutstanding" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCashCredittAssessetClassification" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Term Loan</td>
                        <td>
                            <asp:Label ID="lblTermLoan" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblTermLoanLimit" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblTermLoanOutstanding" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblTermLoanSecurity" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblTermLoanAssessetClassification" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">LC/BG</td>
                        <td>
                            <asp:Label ID="lblLGBG" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblLGBGLimit" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblLGBGOutstanding" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblLGBGSecurityLodged" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblLGBGAssetClassification" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">If banking with this bank, customer ID to be given here:</td>
                        <td colspan="5">NA</td>

                    </tr>
                    <tr>
                        <td class="auto-style1" colspan="6">It is certified that our unit has not availed any loan from any other Bank / Financial Institution in the
past and I/we am/are not indebted to any other Bank / Financial Institution other than those
mentioned in column no. E above. </td>

                    </tr>
                </table>
            </div>
        </div>

        <div>
            <br>
            <asp:Label ID="Label7" runat="server" Text="F. Credit Facilities Proposed:(In Rs.) "></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Type of Facilities</td>
                        <td>Amount </td>
                        <td>Purpose for which
Required</td>
                        <td>Details of Primary Security Offered
(with approx. value to be mentioned) </td>
                    </tr>
                    <tr>
                        <td>Cash Credit
                        </td>
                        <td>
                            <asp:Label ID="lblCashcreditDetailsSecurityAmount" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCashcreditDetailsSecurityPurpose" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCashcreditDetailsSecurityDetailsOfPrimarySecurityOffered" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td>Term Loan
                        </td>
                        <td>
                            <asp:Label ID="lblTermLoanAmount" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblTermLoanPurposeForWhichRequired" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblTermLoanDetailsSecurityOffered" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td>LC/BG

                        </td>
                        <td>
                            <asp:Label ID="lblLCBGAmount" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblLCBGPurposeForWhicRequired" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblLGBGDetailsOfPrimarySecurityOffered" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                    <tr>
                        <td>Total

                        </td>
                        <td>
                            <asp:Label ID="lblTotalAmount" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblTotalPurposeForWhichRequired" runat="server" Text="">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblDetailsOFPrimarySecurityOffered" runat="server" Text="">
                            </asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>

        <div>
            <br>
            <asp:Label ID="Label8" runat="server" Text="G.In case of Working Capital: Basis of CashCredit Limit applied:(In Rs.)"></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Actual Sales</td>
                        <td colspan="8">Projected </td>
                    </tr>
                    <tr>
                        <td>FY-</td>
                        <td>FY- </td>
                        <td>Sales</td>
                        <td>WorkingCycle inMonths</td>
                        <td>Inventory</td>
                        <td>Debtors</td>
                        <td>Creditors</td>
                        <td>Promoter’s Contribution</td>
                        <td>Limits</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCCL_WC_ActSale_previousFY" runat="server" Text="10">
                            </asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_ActSale_currFY" runat="server"></asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_Proj_Sale" runat="server" >
                            </asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_Proj_Cycle" runat="server" >
                            </asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_Proj_Inventory" runat="server" >
                            </asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_Proj_Debtors" runat="server" >
                            </asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_Proj_Creditors" runat="server" >
                            </asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_Proj_Promot_Contri" runat="server" >
                            </asp:Label></td>

                        <td>
                            <asp:Label ID="lblCCL_WC_Proj_Limit" runat="server" >
                            </asp:Label></td>
                    </tr>

                </table>
            </div>
        </div>






       
        <div>
            <br>
            <asp:Label ID="Label9" runat="server" Text="H. In case of Term loan requirements, the details of machinery/equipment may be given as
under:"></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Type of machine/ Equipment</td>
                        <td>Purpose for which required</td>
                        <td>Name of Supplier </td>
                        <td>Total Cost of Machine  </td>
                        <td>Contribution being made by the promoters(Rs.)</td>
                        <td>Loan Required (Rs.)</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCCL_TL_MachineEquip" runat="server" >
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCCL_TL_Purpose" runat="server" >
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCCL_TL_SupplierName" runat="server" >
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCCL_TL_MachineCost" runat="server" >
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCCL_TL_Promote_Contri" runat="server">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCCL_TL_Loan_Req" runat="server">
                            </asp:Label></td>

                    </tr>
                    <%-- <tr>
                        <td><asp:Label ID="Label48" runat="server" Text="41">
                            </asp:Label></td>
                        <td><asp:Label ID="Label49" runat="server" Text="41">
                            </asp:Label></td>
                        <td><asp:Label ID="Label50" runat="server" Text="41">
                            </asp:Label></td>
                        <td><asp:Label ID="Label51" runat="server" Text="41">
                            </asp:Label></td>
                        <td><asp:Label ID="Label52" runat="server" Text="41">
                            </asp:Label></td>
                        <td><asp:Label ID="Label53" runat="server" Text="41">
                            </asp:Label></td>

                    </tr>--%>
                    <tr>

                        <td colspan="3">Total</td>
                        <td>
                            <asp:Label ID="lblCCL_TL_MachineCostTotal" runat="server" >
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCCL_TL_Promote_ContriTotal" runat="server">
                            </asp:Label></td>
                        <td>
                            <asp:Label ID="lblCCL_TL_Loan_ReqTotal" runat="server">
                            </asp:Label></td>
                    </tr>

                    <tr>
                        <td>Repayment period with Moratorium period requested for</td>
                        <td colspan="5">
                            <asp:Label ID="lblCCL_TL_Repayment_Period" runat="server">
                            </asp:Label></td>

                    </tr>


                </table>

            </div>
        </div>
        <div>
            <br>
            <asp:Label ID="Label10" runat="server" Text="I. Past Performance / Future Estimates: (In Rs.)"></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td colspan="5">Past Performance / Future Estimates (Actual performance for two previous years, estimates for
current year and projections for next year to be provided for working capital facilities. However for
term loan facilities projections to be provided till the proposed year of repayment of loan)</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Past Year-II
(Actual) </td>
                        <td>Past Year-I
(Actual)</td>
                        <td>Present Year
(Estimate)</td>
                        <td>Next Year (Projection)</td>




                    </tr>
                    <tr>
                        <td>Net Sales</td>
                        <td>
                            <asp:Label ID="lblPastPerf_PYII_Act_NetSale" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPastPerf_PYI_Act_NetSale" runat="server"></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblPastPerf_PY0_Act_NetSale" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPastPerf_PYNext_Act_NetSale" runat="server"></asp:Label></td>


                    </tr>
                    <tr>
                        <td>Net Profit</td>
                        <td><asp:Label ID="lblPastPerf_PYII_Act_NetProfit" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblPastPerf_PYI_Act_NetProfit" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblPresentYear0_Est_NetProfit" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblPresentYearNext_Est_NetProfit" runat="server"></asp:Label></td>


                    </tr>
                    <tr>
                        <td>Capital (Net
Worth in case of
Companies)

                        </td>
                        <td><asp:Label ID="lblPastPerf_PYII_Act_Capital" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblPastPerf_PYI_Act_Capital" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblPresentYear_Est_Capital" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblPresentYearNext_Est_Capital" runat="server"></asp:Label></td>

                    </tr>
                </table>
            </div>
        </div>

        <div>
            <br>
            <asp:Label ID="Label11" runat="server" Text=" J. Status Regarding Statutory Obligations: 
"></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Statutory Obligations</td>
                        <td>Whether
Complied with
(select Yes/No)
If not applicable
then select N. A.</td>
                        <td>Remarks
(Any details in
connection withthe
relevant obligation to be
given )</td>

                    </tr>
                    <tr>
                        <td>1. Registration under Shops and Establishment Act

                        </td>
                        <td><asp:Label ID="lblSatutoryObl_Reg_Shop" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblSatutoryObl_Reg_ShopRemark" runat="server" ></asp:Label></td>
                    </tr>

                    <tr>
                        <td>2. Registration under MSME (Provisional /Final)
                            
                        </td>
                         <td><asp:Label ID="lblSatutoryObl_Reg_MSME" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblSatutoryObl_Reg_MSMERemark" runat="server" ></asp:Label></td>
                                               
                    </tr>
                    <tr>
                        <td>3. Drug License

                        </td>
                          <td><asp:Label ID="lblSatutoryObl_DrugLicense" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblSatutoryObl_DrugLicense_Remark" runat="server" ></asp:Label></td>


                    </tr>
                    <tr>
                        <td>4. Latest Sales Tax Return Filed

                        </td>
                         <td><asp:Label ID="lblSatutoryObl_SaleReturn_File" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblSatutoryObl_SaleReturn_File_Remark" runat="server" ></asp:Label></td>


                    </tr>
                    <tr>
                        <td>5.Latest Income Tax Returns Filed

                        </td>
                          <td><asp:Label ID="lblSatutoryObl_ITReturn_File" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblSatutoryObl_ITReturn_File_Remark" runat="server" ></asp:Label></td>


                    </tr>
                    <tr>
                        <td>6.Any other Statutory dues remaining outstanding

                        </td>
                          <td><asp:Label ID="lblSatutoryObl_Dues_Remain" runat="server"></asp:Label></td>
                        <td><asp:Label ID="lblSatutoryObl_Dues_RemainRemark" runat="server" ></asp:Label></td>


                    </tr>
                </table>
            </div>
        </div>
        <div>
            <br>
            <asp:Label ID="Label12" runat="server" Text="K. Declaration:  
"></asp:Label>
            <br />
            <div>
                I/We hereby certify that all information furnished by me/us is true, correct and complete. I/We have no
borrowing arrangements for the unit except as indicated in the application form. There is/are no
overdue / statutory dueowed by me/us. I/We shall furnish all other information that may be required by
Bank in connection with my/our application. The information may also be exchanged by you with any
agency you may deem fit. You, your representatives or Reserve Bank of India or Mudra Ltd., or any
other agency as authorised by you, may at any time, inspect/ verify my/our assets, books of accounts
etc. in our factory/business premises as given above. You may take appropriate safeguards/action for
recovery of bank’s dues.
            </div>

        </div>

        <div>
            <br>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Space for Photo</td>
                        <td>Space for Photo</td>
                        <td>Space for Photo</td>

                    </tr>
                    <tr>
                        <td colspan="8">
                            <asp:Label ID="Label57" runat="server" Text="(Signatures of Proprietor/partner/ director whose photo is affixed above)"></asp:Label></td>

                    </tr>

                </table>
            </div>
        </div>
        <div>
            Date :
            <asp:Label ID="lblDateValue" runat="server"></asp:Label>
        </div>
        <br />
        <div>
            Place :
            <asp:Label ID="lblPlaceValue" runat="server"></asp:Label>
        </div>


        <div>

            <div>
                CHECK LIST: (The check list is only indicative and not exhaustive and depending upon the
local requirements at different places addition could be made as per necessity)
            </div>
            <br />
            <div>
                1) Proof of identity - Self certified copy of Voter’s ID card / Driving License / PAN Card /
Aadhar Card/Passport.
            </div>
            <br />
            <div>
                2) Proof of Residence - Recent telephone bill, electricity bill, property tax receipt (not older than 2
months), Voter’s ID card, Aadhar Card & Passport of Proprietor/Partners/Directors.
            </div>
            <br />
            <div>3) Proof of SC/ST/OBC/Minority.</div>
            <br />
            <div>
                4) Proof of Identity/Address of the Business Enterprise -Copies of relevant licenses/registration
certificates/other documents pertaining to the ownership, identity and address of business unit
            </div>
            <br />
            <div>5) Applicant should not be defaulter in any Bank/Financial institution.</div>
            <br />
            <div>
                6) Statement of accounts (for the last six months), from the existing banker, if any.
            </div>
            <br />
            <div>
                7) Last two years balance sheets of the units along with income tax/sales tax return etc.
(Applicable for all cases from Rs.2 Lacs and above).
            </div>
            <br />
            <div>
                8) Projected balance sheets for one year in case of working capital limits and for the period of the
loan in case of term loan (Applicable for all cases from Rs.2 Lacs and above).
            </div>
            <br />
            <div>9) Sales achieved during the current financial year up to the date of submission of application.</div>
            <br />
            <div>10)Project report (for the proposed project) containing details of technical & economic viability.</div>
            <div>11)Memorandum and articles of association of the company/Partnership Deed of Partners etc.</div>
            <br />
            <div>
                12)In absence of third party guarantee, Asset & Liability statement from the borrower including
Directors& Partners may be sought to know the net-worth.

            </div>
            <br />

            <div>13)Photos (two copies) of Proprietor/ Partners/ Directors.</div>
            <br />

            <div>Acknowledgement Slip for loan Application under PradhanMantri MUDRA Yojana</div>
        </div>

        <div>
            <br>
            <asp:Label ID="Label13" runat="server" Text="Office Copy: "></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Application (system
generated/manual) Number</td>
                        <td>
                            <asp:Label ID="lblApplicationGenerated_AckSlip" runat="server"></asp:Label></td>
                        <td>Date of Application</td>
                        <td>
                            <asp:Label ID="lblDataOfApplication_AckSlip" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Name of the Applicant(s)</td>
                        <td>
                            <asp:Label ID="lblNameofApplicant_AckSlip" runat="server" ></asp:Label></td>
                        <td>Loan Amt. Requested for</td>
                        <td>
                            <asp:Label ID="lblLoanAmtReq_AckSlip" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td>Signature of Applicant(s)</td>
                        <td>
                            <asp:Label ID="lblSignOfApplicant_AckSlip" runat="server"></asp:Label></td>
                        <td>Signature of Branch
official</td>
                        <td>
                            <asp:Label ID="lblSignOfBranch_AckSlip" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        <div>---------------------------------------------------------------------</div>

        <div>Acknowledgement Slip for loan Application under PradhanMantri MUDRA Yojana</div>


        <div>
            <br>
            <asp:Label ID="Label20" runat="server" Text="Applicants Copy: "></asp:Label>
            <div style="font-family: Arial" class="loan-application-display">
                <table width="100%" border="1">
                    <tr>
                        <td>Application (system
generated/manual) Number</td>
                        <td>
                            <asp:Label ID="lblApplicationNo_ApplicantsCopy" runat="server"></asp:Label></td>
                        <td>Date of Application</td>
                        <td>
                            <asp:Label ID="lblDateofApp_ApplicantsCopy" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Name of the Applicant(s)</td>
                        <td>
                            <asp:Label ID="lblApplicantName_ApplicantsCopy" runat="server"></asp:Label></td>
                        <td>Loan Amt. Requested for</td>
                        <td>
                            <asp:Label ID="lblAppLoanAmtRequested_ApplicantsCopy" runat="server"></asp:Label></td>
                    </tr>

                    <tr>
                        <td>Signature of Applicant(s)</td>
                        <td>
                            <asp:Label ID="lblSignofapplicant_ApplicantsCopy" runat="server"></asp:Label></td>
                        <td>Signature of Branch
official</td>
                        <td>
                            <asp:Label ID="lblSignofbranch_ApplicantsCopy" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
            <br>
            <
        </div>
        <%-- </form>--%>
    </div>
</body>
</html>
