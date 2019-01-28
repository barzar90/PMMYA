<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextCaptcha.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.TextCaptcha" %>
<div class="formLabel" style="height: 60px;">
    <asp:Label ID="lblRandomNo" AssociatedControlID="txtCaptchAnswer" runat="server" Text="random"></asp:Label>
    <br />
    <asp:Label ID="lblRandomNo2" runat="server"></asp:Label>
    <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
</div>
<div class="formLabelDescription" style="height:85px">
    <asp:TextBox ID="txtCaptchAnswer" runat="server"></asp:TextBox>
    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
</div>

<asp:Button ID="btnSubmit" runat="server" Visible="false" Text="Submit" ValidationGroup="a" CssClass="button"
    OnClick="btnSubmit_Click" />