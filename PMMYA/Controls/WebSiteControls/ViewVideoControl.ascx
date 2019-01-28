<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewVideoControl.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.ViewVideoControl" %>


   <%-- <h2><asp:Label ID="lblMotivational" runat="server" Text=""></asp:Label></h2>--%>
  
   


<asp:ListView ID="LV_Events" runat="server">
    <LayoutTemplate>
        <ul id="flexiselDemo3">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
        </ul>                
    </LayoutTemplate>
    <ItemTemplate>
        <li>
             <a href="#myMotivational<%# Eval("VideoID")%>" data-backdrop="static" data-toggle="modal">
                            <img id="button" src='<%# Eval("ImagePath")%>' class="img-responsive"></a>

            <div class="modal fade" id="myMotivational<%# Eval("VideoID")%>" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        <div class="col-md-4"><div class="row"><img src="../../Images/mudralogo1.png" alt=""></div></div>
                                        <div class="col-md-8"><h4 class="modal-title modal-title-name">Motivational</h4></div>
                                    </div>
                                    <div class="modal-body">
                                        <video controls id="video1" style="width: 100%; height: auto; margin: 0 auto; frameborder: 0;">
                                        <source src='<%# Eval("VideoPath")%>' type="video/mp4">
                                          Your browser doesn't support HTML5 video tag.
                                        </video>
                                    </div>
                                   <!-- <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>-->
                                </div>

                            </div>
                        </div> 
        </li>
    </ItemTemplate>
    <EmptyDataTemplate>
        <p>Nothing here.</p>
    </EmptyDataTemplate>
</asp:ListView>
