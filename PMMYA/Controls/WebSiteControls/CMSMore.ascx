<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CMSMore.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.CMSMore" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<div class="row">
    <div class="col-md-12">
        <h1>
            <asp:Label ID="lblHeading" runat="server"></asp:Label></h1>
        <uc:BreadCrum ID="BreadCrum" runat="server" />
        <asp:HiddenField ID="hdn_keyword" runat="server" />
        <div id="CMSContent" runat="server">
        </div>
        <div class="clear">
        </div>
    </div>
</div>
