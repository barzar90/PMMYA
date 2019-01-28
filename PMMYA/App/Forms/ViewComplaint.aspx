<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="ViewComplaint.aspx.cs" Inherits="PMMYA.App.Forms.ViewComplaint" %>
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
        <h1 class="text-uppercase">View Complaints</h1>
       
                <p class="text-right">
                    <asp:LinkButton ID="LnkHome" runat="server" 
                        Text="Back to DashBoard" CssClass="btn btn-primary btn-sm" ForeColor="White"  PostBackUrl="~/Admin/MenuManagement/MenuList.aspx"></asp:LinkButton>
                </p>
          
            <table>
            <tr>
                <td>
                    <asp:GridView ID="grdUserListing" runat="server" AutoGenerateColumns="False" Width="100%"
                        CellPadding="4" ForeColor="#333333" PageSize="10" OnPageIndexChanging="grdUserListing_PageIndexChanging"
                        AllowPaging="True" OnRowDataBound="grdUserListing_RowDataBound" OnRowCreated="grdUserListing_RowCreated"
                        CssClass="t_view">
                        <AlternatingRowStyle BorderStyle="Dotted" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No.">
                                <HeaderStyle CssClass="labelGridHeader" Width="4%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" runat="server" Text='<%# Bind("srno") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <HeaderStyle CssClass="labelGridHeader" Width="16%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("name") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile Number">
                                <HeaderStyle CssClass="labelGridHeader" Width="16%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("contact") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Subject">
                                <HeaderStyle CssClass="labelGridHeader" Width="16%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("subject") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Complaint Description">
                                <HeaderStyle CssClass="labelGridHeader" Width="16%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("message") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Email">
                                <HeaderStyle CssClass="labelGridHeader" Width="16%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("email") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="District">
                                <HeaderStyle CssClass="labelGridHeader" Width="16%" />
                                <ItemStyle CssClass="labelDescription" Font-Bold="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("districtName") %>' />
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
