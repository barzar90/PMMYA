<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="PMMYA.Account.Login.ChangePassword" %>
<%@ Register src="~/Controls/AdminControls/ChangePassword.ascx" tagname="ChangePassword" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <uc1:ChangePassword ID="ChangePassword1" runat="server" />
</asp:Content>
