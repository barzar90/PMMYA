<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerControl.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.BannerControl" %>
<div id="carousel-example-generic" class="carousel slide clearfix" data-ride="carousel">
    <asp:Literal ID="LitBanner" runat="server"></asp:Literal>
    <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
        <span class="fa fa-angle-left"></span></a><a class="right carousel-control"
            href="#carousel-example-generic" data-slide="next"><span class="fa fa-angle-right">
            </span></a>
</div>