<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="FrmViewPhoto.aspx.cs" Inherits="PMMYA.Site.Home.FrmViewPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/visuallightbox.js" type="text/javascript"></script>
    <script src="../../Scripts/vlbdata1.js" type="text/javascript"></script>
    <link href="../../Styles/visuallightbox.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/vlightbox1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="services">
       
            <h1>
                <asp:Label ID="lblAlbum" runat="server" Text="Photo Gallery"> </asp:Label></h1>
            <a href="FrmViewSubAlbum.aspx" class="btnBack">Back</a>
            <div id="photoalbum">
                <asp:ListView runat="server" ID="lvEventPhoto">
                    <ItemTemplate>
                         <div class="col-md-4">
                             <a class="vlightbox1" href='<%# DataBinder.Eval(Container.DataItem,"FileName") %>'
                                title="">
                                <asp:Image ID="Image1" runat="server" CssClass="motivational-img img-responsive" alt="View Event Photo" ImageUrl='<%# Eval("FileName")%>' />
                                <p>
                                    <asp:Label ID="LblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>'></asp:Label>
                                </p>
                            </a>
                         </div>
                    </ItemTemplate>
                </asp:ListView>
                <div class="clear"></div>
            </div>            
        
         <div class="clear"></div>
    </div>
</asp:Content>
