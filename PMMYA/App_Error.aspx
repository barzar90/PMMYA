<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="App_Error.aspx.cs" Inherits="PMMYA.App_Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <h1>
        <asp:Label ID="lUhHo" runat="server"></asp:Label></h1>
    <div style="padding: 5px 0; clear: both">
        <p>
            <asp:Label ID="lText" runat="server" CssClass="Text"></asp:Label></p>
        <p>
            <asp:Label ID="lError" runat="server" Text="" CssClass="Text"></asp:Label></p>
        <div>
            <asp:Button ID="bReport" runat="server" CssClass="button" OnClick="bReport_Click"
                Visible="false" />
            <br />
            <br />
            <asp:Label ID="lConfirmation" runat="server" Text="" CssClass="Text" ForeColor="Red"></asp:Label>
        </div>
        <asp:Label ID="lExceptionId" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    </div>
</asp:Content>
