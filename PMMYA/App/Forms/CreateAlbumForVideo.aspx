<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="CreateAlbumForVideo.aspx.cs" Inherits="PMMYA.App.Forms.CreateAlbumForVideo" %>

<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        
        <span>Upload Videos</span>
         <div class="clearfix"></div></h1>
    <table class="table table-bordered table-striped">
        <tr>
            <td>
                <asp:Label ID="lblFileType" runat="server" Text="Gallery Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlFileType" runat="server" Width="180px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlFileType_SelectedIndexChanged">
                    <asp:ListItem Text="Select"></asp:ListItem>
                    <asp:ListItem Text="Motivational" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Success Stories" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblVideoTitle" runat="server" Text="English Title"></asp:Label>
                <span>*</span>
            </td>
            <td>
                <asp:TextBox ID="txtVideoTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Marathi Title"></asp:Label>
                <span>*</span>
            </td>
            <td>
                <cc2:TextBoxControl ID="txtVideoTitleLL" runat="server" DestinationLanguage="MARATHI"
                    ></cc2:TextBoxControl>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Hindi Title"></asp:Label>
                <span>*</span>
            </td>
            <td>
                <cc2:TextBoxControl ID="txtVideoTitleUL" runat="server" DestinationLanguage="MARATHI"
                    ></cc2:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" Text="English Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" Width="95%" Height="40px" Rows="4"
                    runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Marathi Description"></asp:Label>
            </td>
            <td>
                <cc2:TextBoxControl ID="txtDescriptionLL" runat="server" DestinationLanguage="MARATHI"
                    Width="95%" Height="40px" 
                    TextMode="MultiLine"></cc2:TextBoxControl>
            </td>
        </tr>
           <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Hindi Description"></asp:Label>
            </td>
            <td>
                <cc2:TextBoxControl ID="txtDescriptionUL" runat="server" DestinationLanguage="Urdu"
                    Width="95%" Height="40px" 
                    TextMode="MultiLine"></cc2:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblVideoPath" runat="server" Text="Video File"></asp:Label>
                <asp:Label ID="lblVideoMark" runat="server" Text="*"></asp:Label>
            </td>
            <td valign="top" width="30%" class="style2">
                <asp:FileUpload ID="uploadVideo" runat="server" Width="180px" /><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Upload Image"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="*"></asp:Label>
            </td>
            <td valign="top" width="30%" class="style2">
                <asp:FileUpload ID="uploadImage" runat="server" Width="180px" /><br />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-success" ValidationGroup="Save"
                    OnClick="btnSave_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-sm btn-warning" Text="Cancel" />
            </td>
        </tr>
    </table>
    <div class="seperator">
    </div>
    <asp:DataGrid ID="DG_Photo" AutoGenerateColumns="False" ShowFooter="True" CellPadding="3"
        CssClass="table table-bordered table-striped" runat="server" Width="100%" DataKeyField="VideoID" OnCancelCommand="DG_Photo_CancelCommand"
        OnDeleteCommand="DG_Photo_DeleteCommand" OnEditCommand="DG_Photo_EditCommand"
        OnItemCommand="DG_Photo_ItemCommand" OnItemDataBound="DG_Photo_ItemDataBound"
        OnUpdateCommand="DG_Photo_UpdateCommand" UseAccessibleHeader="true">
        <Columns>
            <asp:TemplateColumn HeaderText="ID" HeaderStyle-HorizontalAlign="Left" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("VideoID") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("VideoID") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="TypeID" HeaderStyle-HorizontalAlign="Left" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblTypes" runat="server" Text='<%# Bind("Types") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblTypes" runat="server" Text='<%# Bind("Types") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("Videoname") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Width="95%"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblNameLL" runat="server" Text='<%# Bind("VideonameLL") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtNameLL" runat="server" Width="95%"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="FileName">
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("Videopath") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:EditCommandColumn UpdateText="Update" HeaderStyle-HorizontalAlign="Left" CancelText="Cancel"
                EditText="Edit" HeaderText="Edit">
                <HeaderStyle Width="10%" />
            </asp:EditCommandColumn>
            <asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderText="Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtn_Delete" runat="Server" Text="Delete" OnClientClick="Confirm()"
                        CommandName="Delete" />
                </ItemTemplate>
                <HeaderStyle Width="5%" />
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>

</asp:Content>
