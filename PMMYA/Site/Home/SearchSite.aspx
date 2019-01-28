<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="SearchSite.aspx.cs" Inherits="PMMYA.Site.Home.SearchSite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
     <h1>
            <asp:Label ID="lblPartnersHeading" runat="server" Text="Search Site"></asp:Label></h1>
          <h2> <asp:Label ID="lblSearchword" runat="server" ></asp:Label></h2>  
          <br />
            <div  class="searchResult">
            <ul>
                <asp:DataList ID="dlSearchSite" runat="server" Width="100%">
                    <ItemTemplate>
                            
                            <li>
                                <a href='<%# Eval("SearchURL").ToString().Replace("~", Request.Url.OriginalString.Replace(Request.Url.PathAndQuery, ""))%>'><%# Eval("PageTitle") %></a>
                                <br />
                                <span><%# Eval("ShortDescription")%></span>
                            </li>
                    </ItemTemplate>
                </asp:DataList>
             </ul>
             </div>
    <asp:HiddenField ID="hdncult" runat="server" />
    <asp:HiddenField ID="hdn_keyword" runat="server" />
</asp:Content>
