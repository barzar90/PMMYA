<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PMMYA.Account.Login.Login" %>
<%@ Register src="../../Controls/AdminControls/Login.ascx" tagname="Login" tagprefix="uc1" %>


<asp:Content ID="SitePH" ContentPlaceHolderID="SitePH" runat="server">
    <style type="text/css">
        .topHeaderSection  { border-top: 30px solid #104384}
     </style>
     <asp:LinkButton ID="lbtnRegister" runat="server" onclick="lbtnRegister_Click" Text="<%$Resources:Common,lblNewUserRegister %>" Visible="false"></asp:LinkButton>
    <uc1:Login ID="ctrlLogin" runat="server" />   
<br />
<asp:HiddenField ID="hdnDisplayReg" runat="server" />

</asp:Content>
