 <%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="FrmViewSubAlbum.aspx.cs" Inherits="PMMYA.Site.Home.FrmViewSubAlbum" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">   
     <div class="headingBg">
    <div class='breadcrumbDiv' id="breadcrumb" runat="server">
         </div>
         </div>
    <div  id="LeftMenuContent" runat="server" class="col-xs-12 col-sm-3 col-md-3 col-lg-3">
        <div class="quick-links">
            <div id="PContent" runat="server"></div>
        </div>
    </div>
    <div class="col-xs-12 col-sm-9 col-md-9 col-lg-9 brd-left1 pleft25">
     <div >
         <h1><asp:Label ID="lblAlbum" runat="server"></asp:Label></h1>   
        <div class="photoalbum_index">
            <asp:ListView ID="LV_Events" OnItemDataBound="ListView_ItemDataBound" runat="server">
                    <ItemTemplate>                  
                     <asp:Label ID="Label1" CssClass="heading-h2 hidden"  runat="server"  Text='<%# Bind("AlbumName") %> '></asp:Label>
                        <dl>
                            <dt>
                            <a href='<%# "../../Site/Home/FrmViewPhoto.aspx?ID=" + Eval("PhotoSubAlbumID")%>'title="">
                            <asp:Image ID="Image1" CssClass="img-responsive motivational-img" runat="server" alt="View Event Photo" ImageUrl='<%# Eval("FileName")%>' /></a></dt>
                            <dd><asp:Literal ID="Literal2" runat="server" Text='<%# Eval("SubAlbumName")%>'></asp:Literal></dd>
                        </dl>
                </ItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server">
                        <li runat="server" id="itemPlaceholder"></li>
                    </ul>
                </LayoutTemplate>
            </asp:ListView>
            <div class="clear">
                    </div>
        </div>
    </div>
        </div>
</asp:Content>
