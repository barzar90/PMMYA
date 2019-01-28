<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="FrmMotivational.aspx.cs" Inherits="PMMYA.Site.Home.FrmMotivational" %>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script type="text/javascript" src="../../js/jquery.flexisel.js"></script>--%>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--<script src="../../Scripts/jquery.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../../js/jquery.flexisel.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="headingBg">
        
        <uc:BreadCrum ID="BreadCrum" runat="server" />

    </div>
    <div  id="LeftMenuContent" runat="server" class="col-md-3">
        <div class="quick-links">
            <div id="PContent" runat="server"></div>
        </div>
    </div>
  <%--  <div class="container"><h1>Motivational</h1></div>--%>
  
  <div class="col-md-9 brd-left1 pleft25">
        <div class="col-md-12">
            <h1>
                <asp:Label ID="lblMotivational" runat="server" Text="Motivational"></asp:Label>
            </h1>
        </div>
      <%--<div class="col-md-6">--%>
          <asp:ListView ID="LV_Events" runat="server">
    <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
        </ul>                
    </LayoutTemplate>
    <ItemTemplate>
        <li>
              <div class="col-md-4">
             <a href="#myMotivational<%# Eval("VideoID")%>" data-backdrop="static" data-toggle="modal">
                            <img id="button" src='<%# Eval("ImagePath")%>' class="img-responsive motivational-img"></a>
                  </div>
            <div class="modal fade" id="myMotivational<%# Eval("VideoID")%>" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" id="MotivationalmodalClose" data-dismiss="modal">&times;</button>
                                        <div class="col-md-4"><div class="row"><img src="../../Images/mudralogo1.png" alt="Mudra Logo" height="62px"></div></div>
                                        <div class="col-md-8"><h4 class="modal-title modal-title-name1">Motivational</h4></div>
                                    </div>
                                    <div class="modal-body">
                                        <video controls id="video1" style="width: 100%; height: auto; margin: 0 auto; frameborder: 0;">
                                        <source src='<%# Eval("VideoPath")%>' type="video/mp4">
                                          Your browser doesn't support HTML5 video tag.
                                        </video>
                                    </div>
                                   <%-- <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>--%>
                                </div>

                            </div>
                        </div> 
        </li>
    </ItemTemplate>
    <EmptyDataTemplate>
        <p>Nothing here.</p>
    </EmptyDataTemplate>
</asp:ListView>
      <%--</div>--%>
  </div>



    

</asp:Content>

