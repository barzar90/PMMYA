<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="WebPrint.aspx.cs" Inherits="PMMYA.Site.Home.WebPrint" %>
<%@ Register Src="~/Controls/WebSiteControls/CMS.ascx" TagPrefix="uc" TagName="Cms" %>
<%@ Register Src="~/Controls/WebSiteControls/CMSMore.ascx" TagPrefix="uc" TagName="CmsMore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
<uc:Cms ID="CmsContent" runat="server" />
<uc:CmsMore ID="CmsContentMore" runat="server" />
</asp:Content>
