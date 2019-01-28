<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="FrmAlbumDetail.aspx.cs" Inherits="PMMYA.App.Forms.FrmAlbumDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tblAlbum" runat="server" class="table table-bordered table-striped">
        <tr id="trAlbum" runat="server">
            <td>
                <asp:Label ID="lblPhotoText" runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAlbum" runat="server" AutoCompleteType="Disabled"
                    autocomplete="off" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPhotoUploadText" runat="server"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="AlbumPhotoUpload" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnAddAlbumPhoto" runat="server" Text="Add" CssClass="btn btn-sm btn-success" OnClick="btnAddAlbumPhoto_Click" />
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-warning" PostBackUrl="~/App/Forms/FrmCreateAlbum.aspx"/>
            </td>
        </tr>
    </table>
</asp:Content>
