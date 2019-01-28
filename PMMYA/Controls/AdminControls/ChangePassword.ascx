<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="PMMYA.Controls.AdminControls.ChangePassword" %>
<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>

<script src="../../Scripts/md5.js" type="text/javascript"></script>

<style type="text/css">
.VeryPoorStrength
{
background: Red;
color:White;
font-weight:bold;
}
.WeakStrength
{
background: Gray;
color:White;
font-weight:bold;
}
.AverageStrength
{
background: orange;
color:black;
font-weight:bold;
}
.GoodStrength

{
background: blue;
color:White;
font-weight:bold;
}
.ExcellentStrength

{
background: Green;
color:White;
font-weight:bold;
}
.BarBorder
{
border-style: solid;
border-width: 1px;
width: 180px;
padding:2px;
}
</style>
<script language="javascript" type="text/javascript">




function md5auth(seed) {
debugger;
        if (Page_ClientValidate()) {
            var isValid = false;

            var CurrentPassword = document.getElementById("<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword").ClientID %>").value;
            var NewPassword = document.getElementById("<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPassword").ClientID %>").value;
            var ConfirmNewPassword =  document.getElementById("<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("ConfirmNewPassword").ClientID %>").value;


           //var hash1 = calcMD5(seed + CurrentPassword).toUpperCase(); //calcMD5(CurrentPassword.value);

            var hash1 = calcMD5(seed + calcMD5(CurrentPassword).toUpperCase()).toUpperCase(); //calcMD5(CurrentPassword.value);
            document.getElementById('<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword").ClientID %>').value = hash1;

            var password = NewPassword;

            var strength = 0;

            strength += /[A-Z]+/.test(password) ? 1 : 0;

            strength += /[a-z]+/.test(password) ? 1 : 0;

            strength += /[0-9]+/.test(password) ? 1 : 0;

            strength += /[\W]+/.test(password) ? 1 : 0;


            if (strength > 3){
                if (NewPassword == ConfirmNewPassword && NewPassword.length >0)  {

                     hash1 = calcMD5(CurrentPassword).toUpperCase(); 


//                    hash1 = calcMD5(seed + calcMD5(CurrentPassword).toUpperCase()).toUpperCase(); //calcMD5(CurrentPassword.value);
                
                    document.getElementById('<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword").ClientID %>').value = hash1;

                    var hash2 = calcMD5(NewPassword).toUpperCase(); //calcMD5(NewPassword.value).toUpperCase();
                    document.getElementById('<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("NewPassword").ClientID %>').value = hash2;

                    var hash3 = calcMD5(ConfirmNewPassword).toUpperCase();//calcMD5(ConfirmNewPassword.value).toUpperCase();
                    document.getElementById('<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("ConfirmNewPassword").ClientID %>').value = hash3;

                    isValid = true;
                }
                else {
                    alert('');
                    hash1 = calcMD5(CurrentPassword).toUpperCase(); //calcMD5(NewPassword.value).toUpperCase();
                    document.getElementById('<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword").ClientID %>').value = hash1;
                    isValid = false;
                     NewPassword = "";
                     ConfirmNewPassword = "";
                    alert('Password and Confirm Password should be same');
                } //End IF 1 Inner

            }

            else {
                    hash1 = calcMD5(CurrentPassword).toUpperCase(); //calcMD5(NewPassword.value).toUpperCase();
                    document.getElementById('<%= ChangeUserPassword.ChangePasswordTemplateContainer.FindControl("CurrentPassword").ClientID %>').value = hash1;
                isValid = false;
                 NewPassword.value = "";
                alert('Weak Password !!! \n\r\n\r Password should contain atleast one capital letter one number and one special charactor');

            } //End IF 2 Inner

            return isValid;
        } // End If Last
    }





</script>


<h1>
    Change Password
</h1>
<p>
    Use the form below to change your password.
</p>
<%--<p>
    New passwords are required to be a minimum of
    <%= Membership.MinRequiredPasswordLength %>
    characters in length.
</p>
--%>
   <div class="row">
        <div class="col-md-12">
            <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/"
                EnableViewState="false" RenderOuterTable="false" SuccessPageUrl="~/App/Profiles/PasswordSuccess.aspx">
                <ChangePasswordTemplate>
                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification"
                        ValidationGroup="ChangeUserPasswordValidationGroup" />

                    <fieldset class="login">
                        <legend>Account Information</legend>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="CurrentPassword" runat="server" CssClass="form-control" TextMode="Password" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required."
                                    ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="NewPassword" runat="server" CssClass="form-control"
                                    TextMode="Password" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                    CssClass="failureNotification"
                                    ErrorMessage="New Password is required." ToolTip="New Password is required."
                                    ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <ajax:PasswordStrength ID="pwdStrength" TargetControlID="NewPassword" StrengthIndicatorType="Text" PrefixText="Strength:"
                                    HelpStatusLabelID="lblhelp" PreferredPasswordLength="8" MinimumNumericCharacters="1" MinimumSymbolCharacters="1"
                                    TextStrengthDescriptions="Very Poor;Weak;Average;Good;Excellent"
                                    TextStrengthDescriptionStyles="VeryPoorStrength;WeakStrength;AverageStrength;GoodStrength;ExcellentStrength" runat="server" />
                            </div>
                        </div>
                        <div class="row mtop20">
                            <div class="col-md-3">
                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="form-control" TextMode="Password" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                                    ToolTip="Confirm New Password is required."
                                    ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Red">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                    ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                                    ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ChangeUserPasswordValidationGroup"></asp:CompareValidator>
                                <div class="clear"></div>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" CssClass="button" OnClick="LoginButton_Click"
                                    Text="Change Password" ValidationGroup="ChangeUserPasswordValidationGroup" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="CancelPushButton" CssClass="button" runat="server"
                                    CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel" OnClick="CancelPushButton_Click" />
                            </div>
                        </div>
                        <div class="row mtop20">
                            <div class="col-md-12">
                                <asp:Label ID="lblhelp" runat="server" />
                            </div>
                        </div>
                    </fieldset>

                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </div>
    </div>
