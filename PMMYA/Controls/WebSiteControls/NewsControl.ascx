<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsControl.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.NewsControl" %>
<%--<div class="col-md-3 col-sm-12 col-xs-12">--%>


    <div class="ticker-container">
			  <div class="ticker-caption">
				<p><asp:Label ID="lblNews" runat="server" Text="Label"></asp:Label></p>
			  </div>

        <ul>
            <asp:Repeater ID="RptrWhatsNew" runat="server" OnItemCommand="RptrWhatsNew_ItemCommand">
                <ItemTemplate>
                    <div>
                    <li>                     
                      <span>
                            <asp:HyperLink ID="hypViewFile" runat="server" Target="_blank" CssClass="news-acolor" Text='<%# Eval("News") %>'
                                NavigateUrl='<%#  Eval("URL") %>'></asp:HyperLink>
                      <%--    <a href="../../NewsMore.aspx">read more</a>--%>
                         <asp:HyperLink ID="lnkmore" NavigateUrl="~/Site/Home/NewsMore.aspx" runat="server"><%#  Eval("NewsMore") %></asp:HyperLink>
                        <%--<asp:Label ID="lnkmore" runat="server" Text=""></asp:Label>--%>

                        </span>
                    </li>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
        </ul>




		</div>
 <script src="../../Js/jquery-1.9.1.min.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="../../js/app.js"></script>--%>
    <script type="text/javascript" src="../../js/ticker.js"></script>
   <%-- <script type="text/javascript" src="../../js/ValidationScripts.js"></script>--%>
