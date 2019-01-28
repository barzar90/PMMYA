<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="Audit_Trail.aspx.cs" Inherits="PMMYA.App.Forms.Audit_Trail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <style>
        .t_view {
            margin:0 !important;
        }
    </style>
     <asp:Panel ID="PanelApplicant" runat="server" Font-Bold="true" Width="98%">
        <br />
        <h1 class="text-uppercase">Audit Trail</h1>
       
                <p class="text-right">
                    <asp:LinkButton ID="LnkHome" runat="server" 
                        Text="Back to DashBoard" CssClass="btn btn-primary btn-sm" ForeColor="White"  PostBackUrl="~/Admin/MenuManagement/MenuList.aspx"></asp:LinkButton>

                </p>
            
            <table>
            <tr>
                <td style="width: 100%">
                    
                    <asp:GridView ID="grdUserListing" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="4" ForeColor="#333333" PageSize="10" OnPageIndexChanging="grdUserListing_PageIndexChanging"
                        AllowPaging="True" OnRowDataBound="grdUserListing_RowDataBound" OnRowCreated="grdUserListing_RowCreated"
                        CssClass="t_view">
                        <AlternatingRowStyle BorderStyle="Dotted" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <HeaderStyle CssClass="labelGridHeader" Width="4%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" runat="server" Text='<%# Bind("RowNumber") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Name">
                                <HeaderStyle CssClass="labelGridHeader" Width="16%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LoginTime">
                                <HeaderStyle CssClass="labelGridHeader" Width="10%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("LoginDateTime") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <HeaderStyle CssClass="labelGridHeader" Width="80%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIsOnline" runat="server" Text='<%# Bind("IP") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerSettings Mode="NextPrevious" />
                        <SelectedRowStyle Font-Bold="False" />
                    </asp:GridView>
                    <asp:Panel ID="Panel1" runat="server" CssClass="popupControl">
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
