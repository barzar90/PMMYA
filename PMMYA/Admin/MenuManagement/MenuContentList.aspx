<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="MenuContentList.aspx.cs" Inherits="PMMYA.Admin.MenuManagement.MenuContentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
      <h1>
        <asp:Label ID="Label1" runat="server" Text="The Menu Contents for Menu"></asp:Label>
        <span
            class="span">
            <%=MenuName %></span>
    </h1>
    <table class="table table-bordered table-striped">
        <tr>
            <td>
                <div class="admintab pull-right">
                    <asp:Button ID="btnBack" CssClass="btn btn-sm btn-danger" runat="server" Text="Back to Menu" PostBackUrl="~/Admin/MenuManagement/MenuList.aspx" />
                    <div class="clearfix"></div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView CssClass="table table-bordered table-striped" ID="GV_MenuContentList" runat="server" AllowPaging="true" EmptyDataText="No Data Found!!"
                    OnRowCommand="GV_MenuContentList_RowCommand" OnRowDeleting="GV_MenuContentList_RowDeleting"
                    OnPageIndexChanging="GV_MenuContentList_PageIndexChanging" Width="100%" PageSize="5"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Page Title" DataField="PageTitle" />
                        <asp:BoundField HeaderText="Short Description" DataField="ShortDescription" />
                        <asp:BoundField HeaderText="Long Description" DataField="LongDescription" />
                        <asp:BoundField HeaderText="Sequence No" DataField="SequenceNo" />
                        <asp:TemplateField HeaderText="IsApprove">
                            <ItemTemplate>
                                <%#Convert.ToBoolean(Eval("IsApprove")) == true ? "Yes" : "No"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate>
                                <%#Convert.ToBoolean(Eval("Active")) == true ? "Yes" : "No"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <a href="AddMenuContent.aspx?shvid=<%#Eval("MenuContentID")%>&MenuID=<%#Eval("MenuID")%>&Mode=Edit">
                                    <img style="display: inline; width: 20px;" src="../../Images/edit_menu.png" alt="Edit Menu"
                                        title="Edit Menu" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%#Eval("MenuContentID") %>'
                                    CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete');">
                            <img style="display:inline; width:20px;" src="../../Images/delete_menu.png" alt="Delete Menu" title="Delete Menu" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pager-d" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
