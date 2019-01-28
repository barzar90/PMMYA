<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.ascx.cs" Inherits="PMMYA.Controls.AdminControls.UserProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<div>
    <table>
        <tr>
            <td>
                First Name:
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorFirstName" runat="server" ControlToValidate="txtFirstName"
                    ErrorMessage="Enter only character" ForeColor="Red" ValidationExpression="^[a-zA-Z]+$"
                    SetFocusOnError="True" ValidationGroup="VC"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Last Name:
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" />
                      <asp:RegularExpressionValidator ID="RegularExpressionValidatorLastName" runat="server" ControlToValidate="txtLastName"
                    ErrorMessage="Enter only character" ForeColor="Red" ValidationExpression="^[a-zA-Z]+$"
                    SetFocusOnError="True" ValidationGroup="VC"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Phone Number:
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" autocomplete="off"   />
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxMobileNo" runat="server" TargetControlID="txtPhone"
                    FilterType="Numbers" />
                <asp:RegularExpressionValidator ID="RegularExpressionMobile" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage="Enter A Valid TelePhone No." ForeColor="Red" ValidationExpression="^([2-9]{1})([0-9]{9})$"
                    SetFocusOnError="True" ValidationGroup="VC"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Birth Date:
            </td>
            <td>
                <asp:TextBox ID="txtBirthDate" runat="server"  />
              <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtBirthDate">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBirthDate"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" Text="Save" runat="server" ValidationGroup="VC" OnClick="btnSave_Click" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>