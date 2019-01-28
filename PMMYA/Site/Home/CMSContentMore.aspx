<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="CMSContentMore.aspx.cs" Inherits="PMMYA.Site.Home.CMSContentMore" %>
<%@ Register Src="~/Controls/WebSiteControls/CMSMore.ascx" TagPrefix="uc1" TagName="CMSContent" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"  TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <uc1:CMSContent ID="CmsContent"   runat="Server"></uc1:CMSContent>
</asp:Content>
