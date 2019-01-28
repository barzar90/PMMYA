<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmShishu.aspx.cs" Inherits="PMMYA.Site.Home.FrmShishu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shishu Loan Form</title>
    <link href="../../assets/bootstrap/css/bootstrap.css" rel="stylesheet" />
</head>
<body style="background: beige;">
    <form id="form1" runat="server">
        <div>
            <div class="container">
	<br>
	<table class="table table-bordered" border="1">
		<tbody>		
		<tr>
		  <td style="text-align:center" colspan="2">Application No.:<asp:Label ID="lblApplicationId" runat="server" Text=""></asp:Label></td>
          <td style="text-align:center">Date:<asp:Label ID="lblCreatedDate" runat="server" Text=""></asp:Label></td>		
		</tr>
		</tbody>
	</table>
<br>
<table class="table table-bordered" border="1">
		<tbody>		
		<tr>
		  <td style="text-align:center">Name of Bank</td> 
          <td colspan="2" style="text-align:center"> </td>  
		</tr>
		</tbody>
	</table>
	

	
</div>

<div class="container">
	<h3 style="text-align:center">Application Form for Loan under Pradhan Mantri Mudra Yojana (PMMY)<br>(For Loan upto Rs.50000/- underShishu)</h3>
	<p><b>Name of Bank & Branch from where Loan is required  <asp:Label ID="lblBankName" runat="server" Text=""></asp:Label> ,  <asp:Label ID="lblBranchName" runat="server" Text=""></asp:Label></b></p>
	<p>I hereby apply for <asp:Label ID="lblBankLoanType" runat="server" Text=""></asp:Label> of Rs.<asp:Label ID="lblLoanAmountReq" runat="server" Text=""></asp:Label> for <asp:Label ID="LblMudraLoanType" runat="server" Text=""></asp:Label></p>	<br>
<table class="table table-bordered" border="1" style="padding:10px">
    <tbody>
    <tr>
      <td colspan="1">Name of Applicants(s)</td>
      <td colspan="1"><p><asp:Label ID="lblFirstHolderName" runat="server" Text=""></asp:Label></p>
          <p><asp:Label ID="lblSecondHolderName" runat="server" Text=""></asp:Label></p></td>
      <td colspan="1">Father's/Husband's Name</td>
      <td colspan="2"><p><asp:Label ID="lblFirstHolderFatherName" runat="server" Text=""></asp:Label></p><p><asp:Label ID="lblSecondHolderFatherName" runat="server" Text=""></asp:Label></p></td>
	    
    </tr>
	<tr>	
      <td>Constitution()</td>
      <td colspan="7"><asp:Label ID="LblConstitution" runat="server" Text=""></asp:Label></td>
      <%--<td></td>
      <td></td>
	  <td></td>
	  <td colspan="3"></td>	 --%>
    </tr>
	
	<tr>	
      <td rowspan="2">Residential Address</td>
      <td colspan="7"><asp:Label ID="LblResidentialAddress" runat="server" Text=""></asp:Label></td>      	 
    </tr>
	<tr>      
      <td colspan="8"><div class="text-right"><asp:Label ID="LblResidentialAddType" runat="server" Text=""></asp:Label></div></td>      	 
    </tr>
	
	<tr>	
      <td rowspan="2">Business Address</td>
      <td colspan="7"><asp:Label ID="LblBusinessAddress" runat="server" Text=""></asp:Label></td>      	 
    </tr>
	<tr>      
      <td colspan="8"><div class="text-right"><asp:Label ID="LblBusinessAddType" runat="server" Text=""></asp:Label></div></td>      	 
    </tr>
	
	
	<tr>	
      <td>Date of Birth</td>
      <td><asp:Label ID="lblDOB" runat="server" Text=""></asp:Label> </td>
      <td>Age:<asp:Label ID="lblAge" runat="server" Text=""></asp:Label></td>      
	  <td colspan="5">Sex: <asp:Label ID="LblGender" runat="server" Text=""></asp:Label></td>	   
    </tr>
	
	<tr>
      <td colspan="2">Education Qualification</td>
      <td colspan="5"><asp:Label ID="LblEducationQualification" runat="server" Text=""></asp:Label></td>
      <%--<td></td>
      <td></td>
	  <td></td>
      <td></td>--%>
      <%--<td colspan="6"></td>--%>
    </tr>
	
	<tr>
      <td>KYC Document(s)</td>
      <td>Voter ID No.</td>
      <td>Aadhar No.</td>
      <td>Driving License No.</td>
	  <td colspan="4">Any Others</td>
    </tr>
	
	<tr>
      <td>ID proof(pl. specify)</td>
      <td><asp:Label ID="lblIdproofVoterNo" runat="server" Text=""></asp:Label> </td>
      <td><asp:Label ID="lblIdproofAadharNo" runat="server" Text=""></asp:Label> </td>
      <td><asp:Label ID="lblIdproofDLN" runat="server" Text=""></asp:Label> </td>
	  <td colspan="4"><asp:Label ID="lblIdproofother" runat="server" Text=""></asp:Label> </td>
    </tr>
	
	<tr>
      <td>Address Proof(pl. specify)</td>
      <td><asp:Label ID="lblAddproofVoterNo" runat="server" Text=""></asp:Label></td>
      <td><asp:Label ID="LblAddAadharNo" runat="server" Text=""></asp:Label> </td>
      <td><asp:Label ID="LblAddproofDLN" runat="server" Text=""></asp:Label> </td>
	  <td colspan="4"><asp:Label ID="LblAddproofOther" runat="server" Text=""></asp:Label> </td>
    </tr>
	
	
	<tr>
      <td colspan="2">Telephone No.:<asp:Label ID="LblTelephoneNo" runat="server" Text=""></asp:Label></td>
      <td colspan="1">Mobile No.:<asp:Label ID="LblMobileNo" runat="server" Text=""></asp:Label></td>
      <td colspan="3">E-mail:<asp:Label ID="LblEmail" runat="server" Text=""></asp:Label></td>     
    </tr>
	
	<tr>
      <td  rowspan="2">Line of Business Activity (Purpose)</td>
      <td><asp:Label ID="LblLineofBusiness" runat="server" Text=""></asp:Label></td>
	  <td></td>
	  <td colspan="5">Period:<asp:Label ID="LblPeriod" runat="server" Text=""></asp:Label></td>
		<!--<table>
			<tr>
				<td>Existing</td>
				<td></td>
				<td>Period</td>
			</tr>
			<tr>
				<td>Proposed</td>
				<td></td>
			</tr>
		</table>-->	        
    </tr>
	
	<tr>
	<td>Proposed</td>
	<td colspan="6"></td>
	</tr>
	<tr>
      <td colspan="2">Annual Sales (Rs. in lakh)</td>
      <td>Existing:<asp:Label ID="lblAnnualSalesExisting" runat="server" Text=""></asp:Label></td>	 
      <td colspan="4">Proposed:<asp:Label ID="lblAnnualSalesProposed" runat="server" Text=""></asp:Label></td>     
    </tr>
	
	<tr>
      <td>Experience, if any</td>      
      <td colspan="7"><asp:Label ID="LblExperience" runat="server" Text=""></asp:Label></td>     
    </tr>

	<tr>
      <td>Name of Business Activity</td>      
      <td colspan="7"><asp:Label ID="lblBusinessActivity" runat="server" Text=""></asp:Label></td>     
    </tr>
	<tr>
      <td colspan="2">Social Category (Pls. tick)</td>
      <td colspan="5"><asp:Label ID="LblSocialCategory" runat="server" Text=""></asp:Label></td>
     <%-- <td></td>
      <td></td>
	  <td></td>
      <td colspan="3"></td>--%>
    </tr>
	
	<tr>
      <td>If Minority()</td>
      <td colspan="7"><asp:Label ID="lblMinority" runat="server" Text=""></asp:Label></td>
     <%-- <td></td>
      <td></td>
	  <td></td>
	  <td></td>
	  <td></td>
      <td></td>--%>
    </tr>
	
	<tr>
      <td colspan="2">Loan Amount Required</td>
      <td colspan="2"><asp:Label ID="lblLoanCCOD" runat="server" Text=""></asp:Label> Rs <asp:Label ID="LblLoanccodtermAmmount" runat="server" Text=""></asp:Label></td>
      <td colspan="2"></td>     
    </tr>
	
	<tr>
      <td colspan="1">Details of Existing Account(s), if any</td>
      <td>Type:<asp:Label ID="LblExistingLoanType" runat="server" Text=""></asp:Label></td>
      <td>Name of Bank & Branch:</td>
      <td colspan="4"><asp:Label ID="LblExistingBankNameAdd" runat="server" Text=""></asp:Label> </td>
    </tr>
	
	<tr>
      <td>A/C. No.</td>
      <td> <asp:Label ID="LblExistingAccountNo" runat="server" Text=""></asp:Label></td>
      <td colspan="2">If Loan A/c, amount of loan taken</td>
      <td colspan="3">Rs.<asp:Label ID="LblLoanAmountExisting" runat="server" Text=""></asp:Label></td>
    </tr>
	
	<!--<tr>
      <td>2</td>
      <td>Jacob</td>
      <td>Thornton</td>
      <td>@fat</td>
    </tr>-->
	
	</tbody>
</table>
	
</div>

<div class='container'>
	<p><b>Declaration:</b><p>
	<p style="text-align:justify">I/We hereby certify that all information furnished by me/us is true, correct and complete. I/We have no borrowing arrangements for the unit except as indicated in the application form. I/We have not applied to any Bank. There is/are no overdue / statutory dueowed by me/us. I/We shall furnish all other information that may be required by Bank in connection with my/our application. The information may also be exchanged by you with any agency you may deem fit. You, your representatives or Reserve bank of India or MUDRA Ltd., or any other agency as authorised by you, may at any time, inspect/verify my/our assets, books of accounts etc. in our factory/business premises as given above. You may take appropriate safeguards/action for recovery of Bank's dues.</p>
</div>

<div class='container'>
	<div class="col-md-6">
		<p>Date:___________________</p>
		<p>Place:__________________</p>
	</div>
	<div class="col-md-6">
		<p class="text-right" style="padding-top:30px; text-align:right"><b>Thumb impression/Signature of Applicant(s)</b></p>
	</div>
</div>

<div class='container'>
	<p style="text-align:center">(For Office use only)</p>
	<p style="text-align:center">Acknowledgment Slip No.__________________loan Application No.______________dated__________</p>
	<p style="text-align:center">Received by____________________________</p>
</div>

<div class='container' style="margin-top:10px;">
	<div class="col-md-6"><b>Place and Date</b></div>
	<div class="col-md-6 text-right" style="text-align:right"><b>Authorized Signature (Branch Seal and sign)</b></div>
	<p style="text-align:center">----------------------------------------------------------------Cut here--------------------------------------------------------------------</p>
	<p style="text-align:left">Acknowledgment Slip No._________________________for loan application under PMMY (Applicant copy)</p>
	<p style="text-align:left">Received with thanks from Sh./Smt._________________loan application dated________for Rs._______</p>
</div>

<div class='container' style="margin-top:15px; margin-bottom:20px">
	<div class="col-md-6"><b>Place and Date</b></div>
	<div class="col-md-6 text-right" style="text-align:right"><b>Authorized Signature (Branch Seal and sign)</b></div>	
</div>
        </div>
    </form>
</body>
</html>
