<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CMS.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.CMS" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<%@ Register Src="PlaceHolderControl.ascx" TagName="PlaceHolderControl"
    TagPrefix="uc4" %>


<div class="row">
    
       <div class="headingBg">
           <uc:BreadCrum ID="BreadCrum" runat="server" />
                   
        </div>
     <div  id="LeftMenuContent" runat="server">
        <div class="quick-links">
            <div id="PContent" runat="server"></div>
        </div>
    </div>
    <div class="brd-left pleft25">
         
        <asp:HiddenField ID="hdn_keyword" runat="server" />
        <div class="col-md-9 brd-left1"  id="divContent" runat="server"><h1>
                <asp:Label ID="lblHeading" runat="server" Text="Label" Visible="false"></asp:Label></h1></div>
        <div id="CMSContent" runat="server">

        </div>
        <div class="clear">
        </div>
    </div>


</div>
