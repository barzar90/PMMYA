<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmKishor.aspx.cs" Inherits="PMMYA.Site.Home.FrmKishor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kishore Loan Form</title>
    <link href="../../assets/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body style="background: beige;">
    <form id="form1" runat="server">
        <div>
           <%-- <div class="container">
	<table class="table">
		<tbody>		
		<tr>
		  <td width="50%" style="border:0"><img src="../../Images/images.png" alt="mudra-logo" width="260px" height="130px"></td>
		  <td width="50%" style="border:0" class="text-right"><img src="../../Images/logo.png" alt="mudra-logo"></td>		 
		</tr>
		</tbody>
	</table>	
</div>--%>

	<div class="container">
		<h5 style="text-align:center"><b>LOAN APPLICATION FORM PRADHAN MANTRI MUDRA YOJANA</b> <br><small>(To be submitted along with documents as per the check list)</small></h5>
		<h4>A. For office Use:</h4><br>
          <div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">	
					
				<tr>
				  <td><b>Enterprise Name</b></td>
				  <td><b>Application Sl. No.</b></td>
				  <td><b>Name of the Branch</b></td>
				  <td><b>Category</b></td>			  
				</tr>			
				<tr>
				  <td><asp:Label ID="lblEnterpriseName" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="LblApplicationSrNo" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="LblBranchName" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="LblLoanType" runat="server" Text=""></asp:Label></td>			  
				</tr>		
			
		</table>
		</div>
        <div>
		<h4>B. Business Information:</h4><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">		
				<tr>
					<td colspan="2">Name of the Enterprise</td>
					<td colspan="7"><asp:Label ID="lblNameofEnterprise" runat="server" Text=""></asp:Label> </td>				  
				</tr>
				<tr>
					<td colspan="2">Constitution (tick Yes)</td>
					<td colspan="7"><asp:Label ID="lblConstitution" runat="server" Text=""></asp:Label></td>					
				</tr>
				<tr>	
					<td rowspan="3"> Current Business Address</td>
					<td colspan="9"><asp:Label ID="LblBusinessAddress" runat="server" Text=""></asp:Label></td>      	 
				</tr>
				<%--<tr>      
					<td colspan="8"><asp:Label ID="LblBusinessAddress" runat="server" Text=""></asp:Label></td>
					<td> </td> 
					<td></td> 
					<td> </td> 
					<td> </td> 
					<td> </td> 
					<td> </td> 
					<td> </td> 
					<td> </td> 				
				</tr>--%>
				<tr>      
					<td>Business Premises</td>					
					<td colspan="7"><asp:Label ID="LblBusinessAddType" runat="server" Text=""></asp:Label></td>
										
				</tr>
				<tr>
					<td colspan="2">Telephone No.</td>
					<td colspan="2"><asp:Label ID="LblTelephoneNo" runat="server" Text=""></asp:Label> </td>
					<td>Mobile No.</td>					
					<td colspan="4"><asp:Label ID="LblMobileNo" runat="server" Text=""></asp:Label> </td>
				</tr>
				<tr>
					<td>E-mail:</td>
					<td colspan="9"><asp:Label ID="LblEmail" runat="server" Text=""></asp:Label> </td>
				</tr>
				<tr>	
					<td rowspan="2">Business Activity</td>
					<td>Existing </td>
					<td colspan="8"><asp:Label ID="LblLineofBusiness" runat="server" Text=""></asp:Label> </td>      	 
				</tr>
				<tr>      
					<td>Proposed</td>
					<td colspan="8"> </td>    	 
				</tr>
				<tr>
					<td colspan="4">Date of Commencement(DD/MM/YYYY)</td>
					<td colspan="5"> </td>
					<%--<td> </td>
					<td> </td>
					<td> </td>
					<td> </td>
					<td> </td>
					<td> </td>
					<td> </td>		--%>			
				</tr>
				<tr>
					<td colspan="4">Whether the Unit is Registered</td>					
					<td colspan="5">Yes/No</td>
									
				</tr>
				<tr>
					<td colspan="4">If Registered(Please mention:Registration No. And the Act under which registered) </td>
					<td colspan="5"> </td>
				</tr>
				<tr>
					<td colspan="4">Registered office Address</td>
					<td colspan="5"> </td>
				</tr>
				<tr>
					<td colspan="4">Social Category</td>
					<td colspan="5"><asp:Label ID="LblSocialCategory" runat="server" Text=""></asp:Label> </td>
									
				</tr>
				<tr>
					<td colspan="4">If Minority Community</td>
					<td colspan="5"><asp:Label ID="LblMinority" runat="server" Text=""></asp:Label></td>									
				</tr>									
			
		</table>
		</div>
            </div>
     
        <h4>C. Background Information of Proprietor / Partners / Directions:</h4><br>
    
		
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">			
				<tr>
				  <td>S.No.</td>
				  <td>Name</td>
				  <td>Date of Birth</td>
				  <td>Sex</td>
				  <td>Residential Address with Mobile No.</td>
				  <td>Academic Qualification</td>
				  <td>Experience in the line of activity(Years)</td>				  
				</tr>			
				<tr>
				  <td>1</td>
				  <td><asp:Label ID="lblCRow1Name" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow1DOB" runat="server" Text=""></asp:Label></td>
				  <td><asp:Label ID="lblCRow1Sex" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow1ResAddWMobileNo" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow1AcademicQualification" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow1ExpInLineActivity" runat="server" Text=""></asp:Label> </td>				  
				</tr>
				<tr>
				  <td> 2</td>
				  <td><asp:Label ID="lblCRow2Name" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow2DOB" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow2Sex" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow2ResAddWMobileNo" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow2AcademicQualification" runat="server" Text=""></asp:Label> </td>
				  <td><asp:Label ID="lblCRow2ExpInLineActivity" runat="server" Text=""></asp:Label> </td>				  
				</tr>				
			
		</table>
		</div>
            <br>

		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">			
				<tr>
				  <td>S.No.</td>
				  <td>Id Proof</td>
				  <td>Id Proof No.</td>
				  <td>Address Proof No.</td>
				  <td>Address Proof</td>
				  <td>PAN Card/DIN No.</td>
				  <td>Relationship with the officials/Director of the bank if any</td>				  			  
				</tr>			
				<tr>
				  <td>1. </td>
				  <td> <asp:Label ID="lblRow1IDPrrof" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow1IDPrrofNo" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow1AddressProofNo" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow1AddressProof" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow1PanCardOrDinNo" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow1RelationWOffiorDirector" runat="server" Text=""></asp:Label></td>				  
				</tr>
				<tr>
				  <td> 2.</td>
				  <td> <asp:Label ID="lblRow2IDPrrof" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow2IDPrrofNo" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow2AddressProofNo" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow2AddressProof" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow2PanCardOrDinNo" runat="server" Text=""></asp:Label></td>
				  <td> <asp:Label ID="lblRow2RelationWOffiorDirector" runat="server" Text=""></asp:Label></td>				  
				</tr>				
			
		</table>
            </div>
        <div></div>
		<h4>D. Names of Associate Concerns and Nature of Association:</h4><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">			
				<tr>
				  <td>Name of Associate Concern</td>
				  <td>Address of Associate Concern</td>
				  <td>Presently Banking with</td>
				  <td>Nature of Association Concern</td>
				  <td>Extent of Interest as a Prop./Partner/Director or Just Investor in Associate Concern</td>				 		  
				</tr>			
				<tr>
				  <td><asp:Label ID="lblDRow1NameOfAssoConcern" runat="server" Text="____"></asp:Label></td>
				  <td><asp:Label ID="lblDRow1AddOfAssoConcern" runat="server" Text="____"></asp:Label> </td>
				  <td><asp:Label ID="lblDRow1PresentBankWith" runat="server" Text="____"></asp:Label></td>
				  <td><asp:Label ID="lblDRow1NatureOfAssoConcern" runat="server" Text="____"></asp:Label></td>
				  <td><asp:Label ID="lblDRow1ExtentIntrestorPartnerorDire" runat="server" Text="____"></asp:Label></td>				 				  
				</tr>                
				<tr>                 
				  <td><asp:Label ID="lblDRow2NameOfAssoConcern" runat="server" Text="____"></asp:Label></td>
				  <td><asp:Label ID="lblDRow2AddOfAssoConcern" runat="server" Text="____"></asp:Label></td>
				  <td><asp:Label ID="lblDRow2PresentBankWith" runat="server" Text="____"></asp:Label></td>
				  <td><asp:Label ID="lblDRow2NatureOfAssoConcern" runat="server" Text="____"></asp:Label> </td>
				  <td><asp:Label ID="lblDRow2ExtentIntrestorPartnerorDire" runat="server" Text="____"></asp:Label> </td>				  				  
				</tr>				
			
		</table>
		</div>
        <div>

		<h4>E. Banking/Credit Facilities Existing: (In Rs.)</h4><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">		
				<tr>
				  <td>Type of Facilities</td>
				  <td>Presently Banking with</td>
				  <td>Limit Availed</td>
				  <td>Outstanding As on...</td>
				  <td>Security lodged</td>
				  <td>Asset classification status</td>						  
				</tr>			
				<tr>
				  <td>Saving Account</td>
				  <td> </td>
				  <td> N. A.</td>
				  <td> </td>
				  <td> N. A.</td>
				  <td> </td>				  
				</tr>
				<tr>
				  <td>Current Account</td>
				  <td> </td>
				  <td> N. A.</td>
				  <td> </td>
				  <td> N. A.</td>
				  <td> </td>				  
				</tr>
				<tr>
				  <td>Cash Credit</td>
				  <td> </td>
				  <td> </td>
				  <td> </td>
				  <td> </td>
				  <td> </td>				  
				</tr>
				<tr>
				  <td>Term Loan</td>
				  <td> </td>
				  <td> </td>
				  <td> </td>
				  <td> </td>
				  <td> </td>				  
				</tr>
				<tr>
				  <td>LC/BG</td>
				  <td> </td>
				  <td> </td>
				  <td> </td>
				  <td> </td>
				  <td> </td>				  
				</tr>
				<tr>
				  <td colspan="4">If banking with this bank, customer ID to be given here:</td>
				  <td colspan="2"> </td>				  				  
				</tr>
				<tr>
				  <td colspan="6">It is certified that our unit has not availed any loan from any other Bank / Financial Institution in the past and I/we am/are not indebted to any other Bank / Financial Institution other than those mentioned in column no. E above.</td>
				  			  
				</tr>
			
		</table>
            </div>
		</div>
            <div>
		<h4>F. Credit Facilities Proposed: (In Rs.)</h4><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">			
				<tr>
				  <td>Type of Facilities</td>
				  <td>Amount</td>
				  <td>Purpose for which Required</td>
				  <td>Details of Primary Security Offered<br>(with approx. value to be mentioned)</td>				  			 		  
				</tr>			
				<tr>
				  <td>Cash Credit</td>
				  <td> </td>
				  <td> </td>
				  <td> </td>				  			 				  
				</tr>
				<tr>
				  <td>Term Loan</td>
				  <td> </td>
				  <td> </td>
				  <td> </td>				  				  				  
				</tr>
				<tr>
				  <td>LC/BG</td>
				  <td> </td>
				  <td> </td>
				  <td> </td>				  				  				  
				</tr>	
				<tr>
				  <td>Total</td>
				  <td> </td>
				  <td> </td>
				  <td> </td>				  				  				  
				</tr>					
			
		</table>
            </div>
                
		</div>
        <div>
		<h4>G. In case of Working Capital: Basis of Cash Credit Limit applied: (In Rs.)</h4><br>
            <div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">	
				
				<tr>
					<td colspan="2">Actual Sales</td>
					<td colspan="7">Projected</td>										  
				</tr>			
				<tr>
					<td>FY-</td>
					<td>FY-</td>
					<td>Sales</td>
					<td>Working Cycle in Months</td>
					<td>Inventory</td>	
					<td>Debtors</td>	
					<td>Creditors</td>	
					<td>Promoter's Contribution</td>	
					<td>Limits</td>					  
				</tr>
				<tr>
					<td style="text-align:right"> Rs</td>
					<td style ="text-align:right">Rs </td>
					<td style="text-align:right"> Rs</td>
					<td style="text-align:right"> Rs</td>
					<td style="text-align:right"> Rs</td>	
					<td style="text-align:right"> Rs</td>	
					<td style="text-align:right"> Rs</td>	
					<td style="text-align:right"> Rs</td>	
					<td style="text-align:right"> Rs</td>					  
				</tr>			
			
		</table>
                </div>
            
		</div>
        <div>
		<h4>H. In case of Term loan requirements, the details of machinery/equipment may be given as under:</h4><br>
		  <div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">					
				<tr>
					<td>Type of machinery/Equipment</td>
					<td>Purpose of which required</td>
					<td>Name of Supplier</td>
					<td>Total Cost of Machine</td>
					<td>Contribution being made by the promoters(Rs.)</td>	
					<td>Loan Required(Rs.)</td>								  
				</tr>
				<tr>
					<td><asp:Label ID="lblHRow1TypeOfMachineryOrEquipment" runat="server" Text="____"></asp:Label></td>
					<td><asp:Label ID="lblHRow1PurposeodWhichRequired" runat="server" Text="____"></asp:Label> </td>
					<td><asp:Label ID="lblHRow1NameOfSupp" runat="server" Text="____"></asp:Label> </td>
					<td><asp:Label ID="lblHRow1TotCostofMachine" runat="server" Text="____"></asp:Label> </td>
					<td><asp:Label ID="lblHRow1Contributionmadebycontri" runat="server" Text="____"></asp:Label></td>	
					<td><asp:Label ID="lblHRow1LoanRequired" runat="server" Text="____"></asp:Label></td>								  
				</tr>
				<tr>
					<td><asp:Label ID="lblHRow2TypeOfMachineryOrEquipment" runat="server" Text="____"></asp:Label></td>
					<td><asp:Label ID="lblHRow2PurposeodWhichRequired" runat="server" Text="____"></asp:Label></td>
					<td><asp:Label ID="lblHRow2NameOfSupp" runat="server" Text="____"></asp:Label> </td>
					<td><asp:Label ID="lblHRow2TotCostofMachine" runat="server" Text="____"></asp:Label> </td>
					<td><asp:Label ID="lblHRow2Contributionmadebycontri" runat="server" Text="____"></asp:Label></td>	
					<td><asp:Label ID="lblHRow2LoanRequired" runat="server" Text="____"></asp:Label></td>								  
				</tr>
				<tr>
					<td colspan="3" class="text-right"><b>Total</b></td>					
					<td> </td>
					<td> </td>	
					<td> </td>								  
				</tr>				
			
		</table>
            </div>
            </div>
        <div><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">				
				<tr>
					<td>Repayment period with Moratorium period requested for</td>					
					<td> </td>								  
				</tr>								
			
		</table>
		</div>
            </div>
        <div>
		<h4>I. Past Performance / Future Estimates: (In Rs.)</h4><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">					
				<tr>
					<td colspan="5">Past Performance / Future Estimates (Actual performance for two previous years, estimates for current year and projections for next year to be provided for working capital facilities. However for term loan facilities projections to be provided till the proposed year of repayment of loan)</td>														  
				</tr>
				<tr>
					<td> </td>
					<td>Past Year-II (Actual)</td>
					<td>Past Year-I (Actual)</td>
					<td>Present Year (Estimate)</td>
					<td>Next Year (Projection)</td>									  
				</tr>
				<tr>
					<td>Net Sales</td>
					<td> </td>
					<td> </td>
					<td> </td>
					<td> </td>									  
				</tr>
				<tr>
					<td>Net Profit</td>
					<td> </td>
					<td> </td>
					<td> </td>
					<td> </td>									  
				</tr>
				<tr>
					<td>Capital (Net Worth in case of Companies)</td>
					<td> </td>
					<td> </td>
					<td> </td>
					<td> </td>									  
				</tr>
			
		</table>
            </div>
		</div>
        <div>
		<h4>J. Status Regarding Statutory Obligations:</h4><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">	
				<tr>
					<td>Statutory Obligations</td>
					<td>Whether Complied with (select Yes/No)If not applicable then select N.A.</td>
					<td>Remarks(Any details in connection with the relevant obligation to be given)</td>														  
				</tr>
				<tr>
					<td>1. Registration under Shops and Establishment Act</td>
					<td> </td>
					<td> </td>														  
				</tr>
				<tr>
					<td>2. Registration under MSME (Provisional/Final)</td>
					<td> </td>
					<td> </td>														  
				</tr>
				<tr>
					<td>3. Drug License</td>
					<td> </td>
					<td> </td>														  
				</tr>
				<tr>
					<td>4. Latest Sales Tax Return Filed</td>
					<td> </td>
					<td> </td>														  
				</tr>
				<tr>
					<td>5. Latest Income Tax Returns Filed</td>
					<td> </td>
					<td> </td>														  
				</tr>
				<tr>
					<td>6. Any other Statutory dues remaining outstanding</td>
					<td> </td>
					<td> </td>														  
				</tr>
			
		</table>
		</div>
            </div>
		<h4>K. Declaration:</h4><br>
		<p class="text-justify">I/We hereby certify that all information furnished by me/us is true, correct and complete. I/We have no borrowing arrangements for the unit except as indicated in the application form. There is/are no overdue / statutory dueowed by me/us. I/We shall furnish all other information that may be required by Bank in connection with my/our application. The information may also be exchanged by you with any agency you may be deem fit. You, your representatives or Reserve Bank of India or Mudra Ltd, or any etc. in our factory/business premises as given above. You may take appropriate safeguards/action for recovery of bank's dues.</p>
		<br>
		<table class="table table-bordered" border="1">
			<tbody>				
				<tr>
					<td height="100" class="text-center" style="vertical-align:middle;">Space for Photo<br><br></td>					
					<td class="text-center" style="vertical-align:middle;">Space for Photo<br><br></td>
					<td class="text-center" style="vertical-align:middle;">Space for Photo<br><br></td>					
				</tr>
	
				<tr>
					<td colspan="3" style="text-align:center">(Signatures of Proprietor/Partner/Director whose photo is affixed above)<br><br></td>									
				</tr>				
			</tbody>
		</table>
		<p>Date:______________</p>
		<p>Place:_____________</p>
		<h4>CHECK LIST:(The check list is only indicative and not exhaustive and depending upon the local requirements at different places addition could be made as per necessity)</h4>
		<p>1. Proof of identity - Self certified copy of Voter's ID Card / Driving License / Pan Card / Aadhar Card / Passport.</p>
		<p>2. Proof of Residence - Recent telephone bill, Electricity bill, Property tax receipt(not older than 2 months), Voter's ID Card, Aadhar Card & Passport of Proprietor/Partners/Directors.</p>
		<p>3. Proof of SC/ST/OBC/Minority.</p>
		<p>4. Proof of Identity/Address of the Business Enterprise - Copies of relevant licenses/registration certificates/other documents pertaining to the ownership, identity and address of businessunit.</p>
		<p>5. Applicant should not be defaulter in any Bank/Financial institution.</p>
		<p>6. Statement of accounts (for the last six months), from the existing banker, if any.</p>
		<p>7. Last two years balance sheets of the units along with income tax/sales tax return etc. (Applicable for all cases from Rs.2 Lacs and above).</p>
		<p>8. Projected balance sheets for one year in case of working capital limits and for the period of the loan in case of term loan (Applicable for all cases from Rs.2 Lacs and above).</p>
		<p>9. Sales achieved during the current financial year up to the date of submission of application.</p>
		<p>10. Project Report (for the proposed project) containing details of technical & economic viability.</p>
		<p>11. Memorandum and articles of association of the company/Partnership Deed of Partners etc.</p>
		<p>12. In absence of third party guarantee, Asset & Liability statement from the borrower including Directors & Partners may be sought to know the net-worth</p>
		<p>13. Photos (two copies) of Proprietor/Partners/Directors</p>
		<h4 style="text-align:center">Acknowledgement Slip for loan Application under PradhanMantri MUDRA Yojana</h4>
		<h4>Office Copy:</h4><br>
		<div style="font-family: Arial" class="loan-application-display">
					<table width="100%" border="1">
				<tr>
					<td>Application (System Generated/Manual)Number</td>
					<td> </td>
					<td>Date of Application</td>
					<td> </td>					
				</tr>
				<tr>
					<td>Name of Applicant(s)</td>
					<td> </td>
					<td>Loan Amt. Requested for</td>
					<td> </td>					
				</tr>
				<tr>
					<td>Signature of Applicant(s)</td>
					<td> </td>
					<td>Signature of Branch official</td>
					<td> </td>					
				</tr>				
			
		</table>
            </div>
		<p>---------------------------------------------------------------------------------------------------------------------------------------------------</p>
		<%--<h4 style="text-align:center"><img src="../../Images/logo.png" alt="mudra-logo"></h4>--%>
		<h4 style="text-align:center">Acknowledgement Slip for loan Application under PradhanMantri MUDRA Yojana</h4>
		<h4>Applicants Copy:</h4><br>
        <div style="font-family: Arial" class="loan-application-display">
		<table class="table table-bordered" border="1">
			<tbody>				
				<tr>
					<td colspan="2">Application (System Generated/Manual)Number</td>
					<td> </td>
					<td>Date of Application</td>
					<td> </td>					
				</tr>
				<tr>
					<td colspan="2">Name of Applicant(s)</td>
					<td> </td>
					<td>Loan Amt. Requested for</td>
					<td> </td>					
				</tr>
				<tr>
					<td colspan="2">Signature of Applicant(s)</td>
					<td> </td>
					<td>Signature of Branch official</td>
					<td> </td>					
				</tr>				
			</tbody>
		</table>
            </div>
	</div>




            

</div>


      
    </form>
</body>
</html>
