<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="PlaceHolderList.aspx.cs" Inherits="PMMYA.Admin.MenuManagement.PlaceHolderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
     <table class="table table-bordered table-striped">
        <tr>
            <td>
                <div class="admintab">
                    <asp:Button ID="btnPlaceHolderList" runat="server" CssClass="btn btn-default btn-sm" Text="Add Place Holder Content" PostBackUrl="~/Admin/MenuManagement/AddPlaceHolderContent.aspx" />
                    <asp:Button ID="btnBack" runat="server" Text="Back to Menu" CssClass="btn btn-danger btn-sm pull-right" PostBackUrl="~/Admin/MenuManagement/MenuList.aspx" />
                    <div class="clear"></div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GV_MenuContentList" runat="server" AllowPaging="true" EmptyDataText="No Data Found!!" OnRowCommand="GV_MenuContentList_RowCommand"
                    OnRowDeleting="GV_MenuContentList_RowDeleting" OnPageIndexChanging="GV_MenuContentList_PageIndexChanging" Width="100%" CssClass="table table-bordered table-striped"
                    PageSize="5" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Place Holder ID" DataField="PlaceHolderID" />
                        <asp:BoundField HeaderText="Place Holder Name" DataField="PlaceHolderName" />
                        <asp:BoundField HeaderText="Short Description" DataField="ShortDescription" />
                        <asp:TemplateField HeaderText="IsActive">
                            <ItemTemplate>
                                <%#Convert.ToBoolean(Eval("Active")) == true ? "Yes" : "No"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="IsApprove">
                            <ItemTemplate>
                                <%#Convert.ToBoolean(Eval("IsApprove")) == true ? "Yes" : "No"%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <a href="AddPlaceHolderContent.aspx?shvid=<%#Eval("PlaceHolderID")%>&Mode=Edit">
                                    <span class="glyphicon glyphicon-edit" title="Edit Menu"></span></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_Delete" runat="server" CommandArgument='<%#Eval("PlaceHolderID") %>'
                                    CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete');">
                            <span class="glyphicon glyphicon-trash" title="Delete Menu"></span>
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
