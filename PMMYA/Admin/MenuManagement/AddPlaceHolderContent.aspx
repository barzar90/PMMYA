<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="AddPlaceHolderContent.aspx.cs" Inherits="PMMYA.Admin.MenuManagement.AddPlaceHolderContent" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
    <script src="ckeditor/jquery.1.9.1.js" type="text/javascript"></script>
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="ckeditor/adapters/jquery.js" type="text/javascript"></script>
    <%--<link href="ckeditor/sample.css" rel="stylesheet" type="text/css" />--%>
    <script src="../../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('.mckeditor').ckeditor();
            $('.mckeditor').ckeditor().on('getData.ckeditor', function (event, editor, data) {
                $.ajax({
                    type: "POST",
                    url: "../../WebServices/validateHtml.asmx/ValidateHTML",
                    data: "{'editorContent' : '" + data.dataValue + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == false) {
                            $('#' + editor.name + '').val('');
                        }
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
     <h1>
        <asp:Label ID="lbltitle" runat="server" Text="Add Place Holder Content"></asp:Label>
        <div class="clearfix"></div>
        </h1>
    <table class="table table-bordered table-striped">
        <tr>
            <td nowrap="nowrap" width="200px">
                <asp:Label ID="lblPgTitle" runat="server" Text="Title"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPageTitle" CssClass="form-control" runat="server"></asp:TextBox>&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
                <asp:Label ID="lblSDescription" runat="server" Text="Short Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEditor1" CssClass="mckeditor" ClientIDMode="Static" TextMode="MultiLine"
                    runat="server" Height="31px" Width="230px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
                <asp:Label ID="lblSDescription_LL" runat="server" Text="Local Language Short Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEditor2" CssClass="mckeditor" ClientIDMode="Static" TextMode="MultiLine"
                    runat="server" Height="36px" Width="233px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
                <asp:Label ID="Label2" runat="server" Text="Hindi Language Short Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEditor3" CssClass="mckeditor" ClientIDMode="Static" TextMode="MultiLine"
                    runat="server" Height="36px" Width="233px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                Is Active?
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Is Approve?
            </td>
            <td>
                <asp:CheckBox ID="chkIsApprove" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Select File Type to Upload :
            </td>
            <td>
                <asp:FileUpload ID="UploadFile" runat="server" class="multi" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Images Path &nbsp;:&nbsp;&nbsp;  ../../Site/Upload/Images/fileName.(extention)<br/> Pdf Path&nbsp;:&nbsp;&nbsp; ../../Site/Upload/Pdf/fileName.(extention) <br/> Video Path&nbsp;:&nbsp;&nbsp; ../../Site/Upload/Video/fileName.(extention)"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="labelM">
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblmsg" runat="server"></asp:Label>&nbsp;&nbsp;
                <br />
                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" width="200px">
            </td>
            <td>
                <asp:Button ID="btn_Save" CssClass="btn btn-sm btn-success" runat="server" Text="Save" Width="68px"
                    OnClick="btn_Save_Click" />
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Width="68px" CausesValidation="false"
                    CssClass="btn btn-sm btn-warning" OnClick="btn_Cancel_Click" />
            </td>
        </tr>
    </table>
    </fieldset>
</asp:Content>
