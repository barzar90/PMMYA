<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="PMMYA.Admin.MenuManagement.MenuList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
     <div class="admintab">
        <asp:Button ID="btnAddMenu" runat="server" CssClass="btn btn-success btn-sm" Text="Add Menu"
            PostBackUrl="~/Admin/MenuManagement/CreateMenu.aspx"  />
        <asp:Button ID="btnPublish" runat="server" CssClass="btn btn-default btn-sm" Text="Publish Menu"
            OnClick="btnPublish_Click" />
        <asp:Button ID="btnAddPlaceholder" runat="server" CssClass="btn btn-default btn-sm"
            Text="Add Place Holder Content"   PostBackUrl="~/Admin/MenuManagement/AddPlaceHolderContent.aspx"  />
        <asp:Button ID="btnPlaceHolderList" runat="server" CssClass="btn btn-default btn-sm"
            Text="Place Holder Content List"  PostBackUrl="~/Admin/MenuManagement/PlaceHolderList.aspx" />
                <asp:Button ID="btnGenSiteMap" runat="server" CssClass="btn btn-default btn-sm" Text="Generate Site Map"
            OnClick="btnGenSiteMap_Click" />
        
        <%--<a id="A3" class="btn btn-success btn-sm" runat="server" target="_blank" href="~/Site/Upload/Pdf/UserManual.pdf">
            CMS User Manual</a>--%>
        <div class="clear"></div>
    </div>
    <asp:GridView CssClass="table table-bordered table-striped" ID="grdManuList" AllowPaging="True"
        AutoGenerateColumns="False" EmptyDataText="There is no data to display" runat="server"
        OnRowCommand="grdManuList_RowCommand" OnRowDeleting="grdManuList_delete" OnPageIndexChanging="grdManuList_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Sr No">
                <ItemTemplate>
                    <%#  Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Menu Link">
                <ItemTemplate>
                    <%# "["+ Request.Url.OriginalString.Replace(Request.Url.PathAndQuery, string.Empty)+"/"+Convert.ToString(Eval("MenuID")) + "/" + Convert.ToString(Eval("MenuName")).TrimEnd().TrimStart().Replace(" ","-") +"]" %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Menu Name" DataField="MenuName" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Menu Type" DataField="MenuType" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Parent Menu " DataField="Parent" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField HeaderText="Seq No" DataField="SequenceNo" />
            <asp:TemplateField HeaderText="Is New">
                <ItemTemplate>
                    <%#  (Convert.ToBoolean(Eval("IsNewFlag"))==true)?"Yes":"No" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active">
                <ItemTemplate>
                    <%#  (Convert.ToBoolean(Eval("Active"))==true)?"Yes":"No" %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <a href='<%# GetSiteURL()%>/Admin/MenuManagement/CreateMenu.aspx?shvid=<%# Eval("MenuID") %>&action=edit&pid=<%#Eval("ParentID") %>'>
                        <span class="glyphicon glyphicon-edit" title="Edit Menu"></span></a>
                    <asp:LinkButton ID="lnkDelete" OnClientClick="javascript:return confirm('Are you sure do you to delete');"
                        CommandArgument='<%# Eval("MenuID") %>' runat="server" CommandName="Delete">
                                        <span class="glyphicon glyphicon-trash" title="Delete Menu"></span>
                    </asp:LinkButton>
                    <a class="hidden" href='QuickMenu.aspx?MenuID=<%# Eval("MenuID") %>'><span class="glyphicon glyphicon-link"
                        title="Add Quick Link"></span></a><a class="hidden" href='<%# GetSiteURL()%>/Admin/MenuManagement/QuickMenuList.aspx?MenuID=<%#Eval("MenuID") %>'>
                            <span class="glyphicon glyphicon-list-alt" title="View Quick Links"></span>
                    </a><a href='<%# GetSiteURL()%>/Admin/MenuManagement/AddMenuContent.aspx?MenuID=<%#Eval("MenuID") %>'>
                        <span class="glyphicon glyphicon-plus" title="Add menu Content"></span></a><a href='<%# GetSiteURL()%>/Admin/MenuManagement/MenuContentList.aspx?MenuID=<%#Eval("MenuID")%>'>
                            <span class="glyphicon glyphicon-list" title="View menu Content"></span>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="pager-d" />
    </asp:GridView>
</asp:Content>
