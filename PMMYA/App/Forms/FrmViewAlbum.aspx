<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="FrmViewAlbum.aspx.cs" Inherits="PMMYA.App.Forms.FrmViewAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <span>View Album</span>
         <div class="clearfix"></div>
        
        </h1>
    <table id="tblalbum" runat="server" class="table table-bordered table-striped" style="display: none">
        <tr id="tralbum" runat="server">
            <td>
                <asp:Label ID="Label1" runat="server" Text="Select Album"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAlbum" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAlbum_SelectedIndexChanged"
                    Width="250px">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:DataGrid ID="DG_Album" AutoGenerateColumns="False" ShowFooter="True" CellPadding="3"
        CssClass="table table-bordered table-striped" runat="server" Width="100%" DataKeyField="ID" OnCancelCommand="DG_Album_CancelCommand"
        OnDeleteCommand="DG_Album_DeleteCommand" OnEditCommand="DG_Album_EditCommand"
        OnItemCommand="DG_Album_ItemCommand" OnItemDataBound="DG_Album_ItemDataBound"
        OnUpdateCommand="DG_Album_UpdateCommand" UseAccessibleHeader="true">
        <Columns>
            <asp:TemplateColumn HeaderText="ID" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Width="95%"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="FileName">
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("FileName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:EditCommandColumn UpdateText="Update" CancelText="Cancel" EditText="Edit" HeaderText="Edit">
                <HeaderStyle Width="10%" />
            </asp:EditCommandColumn>
            <asp:TemplateColumn HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtn_Delete" runat="Server" Text="Delete" CommandName="Delete" />
                </ItemTemplate>
                <HeaderStyle Width="5%" />
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid><br />
    <asp:Label ID="lbl_Error" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
</asp:Content>
