<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhotoControl.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.PhotoControl" %>
  <div class="photoalbum_index">
        <asp:ListView ID="LV_Events" runat="server">
            <ItemTemplate>
            </ItemTemplate>
            <ItemTemplate>
                <dl>
                    <dt>
                        <asp:Image CssClass="img" ID="Image1" runat="server" alt="" ImageUrl='<%# Eval("FileName")%>' /></a></dt>
                    <dd>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Name")%>'></asp:Literal>
                    </dd>
                </dl>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
            </LayoutTemplate>
        </asp:ListView>
    </div>
    <div class="clear"></div>
    <%--<a href='<%# "/Site/Home/FrmViewSubAlbum.aspx?ID=" + Eval("PhotoAlbumID")%>'
                        title="">--%>
