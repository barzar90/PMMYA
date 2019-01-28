<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="PMMYA.App.Forms.UploadFile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-bordered table-striped">
        <tr>
            <td>
                <asp:HiddenField ID="HdnExt" runat="server" Value="" />
                <asp:HiddenField ID="HdnSizeLimit" runat="server" Value="0" />
                <asp:HiddenField ID="HdnDelete" runat="server" Value="0" />
                <asp:Label ID="lblCategory" runat="server" Text="Select Category"></asp:Label>
            </td>
            <td>
                <asp:DropDownList CssClass="form-control" ID="DDLcategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLcategory_SelectedIndexChanged">
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFtitle" runat="server" Text="File Title" ></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtFTitle" runat="server" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldtxtFTitle" runat="server" ControlToValidate="txtFTitle" 
                      ValidationGroup="save"  ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFtitleLL" runat="server" Text="File Title In Marathi"></asp:Label>
            </td>
            <td>
                <asp:TextBoxControl CssClass="form-control" ID="txtFTitleLL" runat="server" DestinationLanguage="MARATHI"
                    CDACDestinationLanguage="ENGLISH" TypingMode="GOOGLE"  AutoCompleteType="Disabled" autocomplete="off"></asp:TextBoxControl>
                <asp:RequiredFieldValidator ID="RequiredFieldtxtFTitleLL" runat="server" ControlToValidate="txtFTitleLL" ValidationGroup="save"
                    ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblFtitleUL" runat="server" Text="File Title In Hindi"></asp:Label>
            </td>
            <td>
                <asp:TextBoxControl CssClass="form-control" ID="txtFTitleUL" runat="server" DestinationLanguage="Hindi"
                    CDACDestinationLanguage="ENGLISH" TypingMode="GOOGLE"  AutoCompleteType="Disabled" autocomplete="off"></asp:TextBoxControl>
                <asp:RequiredFieldValidator ID="RequiredFieldtxtFTitleUL" runat="server" ControlToValidate="txtFTitleUL" ValidationGroup="save"
                    ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblFdtl" runat="server" Text="File Details :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtFDtl" runat="server" TextMode="MultiLine"  AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFDtlLL" runat="server" Text="File Details LL"></asp:Label>
            </td>
            <td>
                <asp:TextBoxControl CssClass="form-control" ID="txtFDtlLL" runat="server" TextMode="MultiLine"
                    DestinationLanguage="MARATHI" CDACDestinationLanguage="ENGLISH" TypingMode="GOOGLE" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBoxControl>
            </td>
        </tr>

         <tr>
            <td>
                <asp:Label ID="lblFDtlUL" runat="server" Text="File Details Hindi"></asp:Label>
            </td>
            <td>
                <asp:TextBoxControl CssClass="form-control" ID="txtFDtlUL" runat="server" TextMode="MultiLine"
                    DestinationLanguage="MARATHI" CDACDestinationLanguage="ENGLISH" TypingMode="GOOGLE" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblseqNo" runat="server" Text="Sequence No :"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="txtSeqNo" runat="server" autocomplete="off"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtSeqNo"
                    ValidChars="0123654789" FilterType="Numbers">
                </asp:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldtxtSeqNo" runat="server" ControlToValidate="txtSeqNo" ValidationGroup="save"
                    ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIsActive" runat="server" Text="Approve"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFile" runat="server" Text="Select File"></asp:Label>&nbsp;(.jpg,.jpeg,.png,.bmp,.gif
                only)
            </td>
            <td>
                <asp:FileUpload ID="UploadImage" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-sm btn-success" OnClick="btnSave_Click" ValidationGroup="save"  />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sm btn-warning" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdupload" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
        AllowPaging="true" CellPadding="3" GridLines="Vertical" Width="100%" OnPageIndexChanging="grdupload_PageIndexChanging"
        OnRowCommand="grdupload_RowCommand" OnRowDeleting="grdupload_RowDeleting" PageSize="5">
        <Columns>
            <asp:TemplateField HeaderText="SR No" ItemStyle-HorizontalAlign="Center" SortExpression="SRNo"
                Visible="true">
                <ItemTemplate>
                    <asp:Label ID="lblsrNo" runat="server" Text='<%# Bind("SRNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="File Title" Visible="true">
                <ItemTemplate>
                    <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("FileTitle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title Marathi">
                <ItemTemplate>
                    <asp:Label ID="lblTitleLL" runat="server" Text='<%# Bind("FileTitleLL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="File Detail">
                <ItemTemplate>
                    <asp:Label ID="lblDtl" runat="server" Text='<%# Bind("FileDtl") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Details Marathi">
                <ItemTemplate>
                    <asp:Label ID="lblDtlLL" runat="server" Text='<%# Bind("FileDtlLL") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Width="40" Height="40" ImageUrl='<%# "/PublicApp/STD/ViewFile.ashx?ID=" + Eval("Rowid") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblActive" runat="server" Text='<%# Bind("IsActive") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Seq. No" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblseqNo" runat="server" Text='<%# Bind("SequenceNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <span onclick="return confirm('Are you sure to Delete?')">
                        <asp:LinkButton ID="lnkDelete" ForeColor="Blue" runat="server" CausesValidation="False"
                            CommandName="delete" CommandArgument='<%# Eval("Rowid") %>' Text="Delete"></asp:LinkButton>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" ForeColor="Blue" runat="server" CausesValidation="False"
                        CommandName="view" CommandArgument='<%# Eval("Rowid") %>' Text="View"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
