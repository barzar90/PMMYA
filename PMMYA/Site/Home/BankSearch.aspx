<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="BankSearch.aspx.cs" Inherits="PMMYA.Site.Home.BankSearch" %>
<%@ Register Src="~/Controls/WebSiteControls/DistrictSubdistictUserControl.ascx" TagName="Details"
    TagPrefix="uc10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.1.min.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <uc10:Details ID="Details" runat="server" />
</asp:Content>
