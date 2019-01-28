<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="FrmCreateAlbum.aspx.cs" Inherits="PMMYA.App.Forms.FrmCreateAlbum" %>

<%@ Register TagPrefix="Fu" TagName="File_Upload" Src="~/Controls/AdminControls/FileUpload.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <span>Create Album for Photo</span>
        <div class="clearfix"></div>
        </h1>
        
        <table  class="table table-bordered table-striped">
  <tr>
    <td><asp:Label ID="Label1" runat="server" Text="Select Album"></asp:Label></td>
    <td>    <asp:DropDownList ID="ddlAlbum" runat="server" Width="165px" OnSelectedIndexChanged="ddlAlbum_SelectedIndexChanged"
                AutoPostBack="True">
            </asp:DropDownList></td>
   
  </tr>

  <tr>
   <td colspan="3"><asp:LinkButton ID="lnkAddalbum" runat="server" Text="Create Album" PostBackUrl="~/App/Forms/FrmAlbumDetail.aspx?MODE=Album" CssClass="btn btn-sm btn-warning" Width="110px"></asp:LinkButton></td>
   
  </tr>
  <tr>
    <td><asp:Label ID="Label2" runat="server" Text="Select SubAlbum"></asp:Label></td>
    <td> <asp:DropDownList ID="ddlSubalbum" runat="server" Width="165px" AutoPostBack="True"
                OnSelectedIndexChanged="ddlSubalbum_SelectedIndexChanged">
            </asp:DropDownList></td>
   
  </tr>
 
  <tr>
    <td colspan="3"><asp:LinkButton ID="lnkAddsubalbum" runat="server"  Text="Create SubAlbum" Visible="false" CssClass="button"></asp:LinkButton></td>
 
  </tr>  
  <tr>
    <td><asp:Label ID="Label5" runat="server" Text="Enter Photo Name: "></asp:Label></td>
    <td> <asp:TextBox ID="txtPhoto" runat="server" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox></td>
 
  </tr>
 
  <tr>
    <td colspan="3"><asp:FileUpload ID="PhotoUpload" runat="server"  CssClass="multi upload"/></td>
 
  </tr>
  <tr>
    <td colspan="3"><asp:Button ID="btnAddPhoto" runat="server" Text="Add" CssClass="btn btn-sm btn-success" OnClick="btnAddPhoto_Click" /></td>
 
  </tr>

 
</table>
 
    <div class="seperator"></div>
        <asp:DataGrid ID="DG_Photo" AutoGenerateColumns="False" ShowFooter="True" CellPadding="3"
            CssClass="table table-bordered table-striped" runat="server" Width="100%" DataKeyField="ID" OnCancelCommand="DG_Photo_CancelCommand"
            OnDeleteCommand="DG_Photo_DeleteCommand" OnEditCommand="DG_Photo_EditCommand"
            OnItemCommand="DG_Photo_ItemCommand" OnItemDataBound="DG_Photo_ItemDataBound"
            OnUpdateCommand="DG_Photo_UpdateCommand" UseAccessibleHeader="true">
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
        </asp:DataGrid>
    </div>
</asp:Content>
