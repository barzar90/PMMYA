<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="CMSContent.aspx.cs" Inherits="PMMYA.Site.Home.CMSContent" %>
<%@ Register Src="~/Controls/WebSiteControls/CMS.ascx" TagName="Cms" TagPrefix="uc" %>
<%@ Register Src="~/Controls/WebSiteControls/LastReviewedDate.ascx" TagName="LastReviewedDate"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
     <uc:Cms ID="CmsContent" runat="server" />
</asp:Content>
