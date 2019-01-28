<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisitorCount.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.VisitorCount" %>
<div class="visitorCount">
<div class="lastReviewed">
    <i class="fa fa-users fa-users-footer" aria-hidden="true"></i>
    <asp:Label ID="lblTotalVisitHeading" runat="server" Text=""></asp:Label>
  <span class="color-cyan">  <asp:Label ID="lblCounter" runat="server" Text=""></asp:Label></span>
   <label class="vertical-linefooter"> |</label>
    <i class="fa fa-user fa-user-footer" aria-hidden="true"></i>
    <asp:Label ID="lblTodayVisitHeading" runat="server" Text=""></asp:Label>
   <span class="color-cyan"> <asp:Label ID="lbltodayCount" runat="server" Text=""></asp:Label></span>    <br />

<%--   <span><asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>15/08/2018</span>--%>
    <div class="clear"></div>
</div>
</div>