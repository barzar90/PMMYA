<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewVideoControl3.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.ViewVideoControl3" %>


   <%-- <h2><asp:Label ID="lblPhoto" runat="server" Text=""></asp:Label></h2>--%>
  
    
<asp:ListView ID="lvEventPhoto" runat="server">
    <LayoutTemplate>
        <ul id="flexiselDemo22">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />    
        </ul>                
    </LayoutTemplate>
    <ItemTemplate>
        <li>
             <a class="vlightbox1" href='<%# DataBinder.Eval(Container.DataItem,"FileName") %>'
                                title="">
                                <asp:Image ID="Image1" runat="server" alt="View Event Photo" ImageUrl='<%# Eval("FileName")%>' />                                                            </a>
        </li>
    </ItemTemplate>
    <EmptyDataTemplate>
        <p>Nothing here.</p>
    </EmptyDataTemplate>
</asp:ListView>

   
   

 