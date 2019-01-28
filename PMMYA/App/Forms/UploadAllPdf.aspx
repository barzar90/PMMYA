<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="UploadAllPdf.aspx.cs"
    Inherits="PMMYA.App.Forms.UploadAllPdf" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/PagerControl.ascx" TagName="PagerControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../../Scripts/CommonValidations.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(function () {
            var $j = jQuery.noConflict();
            $j(".txtCreatedDate").datepicker({
                hangeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });           
        });  
       </script>
        <style type="text/css">
.ui-datepicker { font-size:8pt !important}
</style>
    <script language="JavaScript" type="text/javascript">

        var isShift = false;
        function keyUP(keyCode) {

            if (keyCode == 16)
                isShift = false;
        }
        function isAlphaNum(keyCode) {
            if (keyCode == 16)
                isShift = true;
            return ((keyCode >= 65 && keyCode <= 90) || ((keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 189 || keyCode == 191 || keyCode == 109 || keyCode == 111 || (keyCode >= 48 && keyCode <= 57) || (keyCode >= 96 && keyCode <= 105)) && isShift == false))
        }
        function isNumberKey1(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function isBS(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode || 8)

                return false;

            return true;


        }
        function IsAlphabet(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode

            var txt = String.fromCharCode(charCode)

            if (txt.match(/^[a-zA-Z\b ]+$/))

                return true

            return false

        }
        function checkDate(sender, args) {


            if (sender._selectedDate > new Date()) {
                alert("You Can Not Select Date Greater Than Todays Date!");
                sender._selectedDate = new Date();
                //sender._selectedDate = "";
                // set the date back to the current date 
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
        }


        function OpenUploadFile(ctrlName) {
            var strPath = document.getElementById(ctrlName).value;
            window.open(strPath, "PDFWindow", "");
            return false;
        }
        function IsNumeric(sText, obj) {
            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;
            var sVAL
            Char = sText.charAt(0);
            if (Char == "." && obj.value.indexOf('.') > -1)
                IsNumber = false;
            else {
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                    alert("Enter Only Nimeric Value");
                }
            }
            return IsNumber;
        }

        function checkname() {
            var keyCode = window.event.keyCode;
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                window.event.returnValue = false;
                alert("Enter only letters");
            }
        }


        function Checkfiles() {
            var fup = document.getElementById('FileUpload1');
            var fileName = fup.value;
            var ext = fileName.substring(fileName.lastIndexOf('.') + 1);
            if (ext == "gif" || ext == "GIF" || ext == "PNG" || ext == "png" || ext == "jpg" || ext == "JPG" || ext == "bmp" || ext == "BMP") {
                return true;
            }
            else {
                alert("Upload Gif,Bmp or Jpg images only");
                fup.focus();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
    <span>Upload All Pdf</span>
         <div class="clearfix"></div>
    </h1>
    <asp:HiddenField ID="HDNUpdate" runat="server"/>
    <table class="table table-bordered table-striped">
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Label ID="lblDocumentType" runat="server" AssociatedControlID="ddlDocumentType"
                    Text="Document Type" AutoCompleteType="Disabled" autocomplete="off" ></asp:Label><span style="color: #f00;">*</span>
            </td>
            <td class="labelDescription">
                <asp:DropDownList ID="ddlDocumentType" CssClass="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDocumentType_SelectedIndexChanged">
                </asp:DropDownList>
                <a href="CreateDocType.aspx?mode=1" class="btn btn-sm btn-default"><b>Create New Document Type</b></a>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDocumentType"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr id="Tr0" runat="server">
            <td>
                <asp:Label ID="lblSubType0" runat="server" AssociatedControlID="ddlsubType0" Text="Sub Type"></asp:Label><span
                    style="color: #f00;">*</span>
            </td>
            <td class="labelDescription">
                <asp:DropDownList ID="ddlsubType0" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsubType0_SelectedIndexChanged">
                </asp:DropDownList>
                <a href="CreateDocType.aspx?mode=2" class="btn btn-sm btn-default"><b>Create New Sub Type</b></a>
            </td>
        </tr>
    </table>
    <table class="table table-bordered table-striped">
        <%--<tr>
            <td>
                <asp:Label ID="lblCreatedDate" AssociatedControlID="txtCreatedDate" runat="server"
                    Text="GR Date" Visible="false"></asp:Label>
            </td>
            <td class="labelDescription">
            <asp:TextBox ID="txtCreatedDate" runat="server" CssClass="txtCreatedDate" Visible="false" ></asp:TextBox>
            
             <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCreatedDate"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>--%>
       
        <tr>
            <td>
                <asp:Label ID="lblSub" runat="server" AssociatedControlID="txtSub" Text="Subject "></asp:Label>
            </td>
            <td class="labelDescription">
                <cc1:TextBoxControl ID="txtSub" runat="server" DestinationLanguage="ENGLISH" TypingMode="CDAC" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSubLL" runat="server" AssociatedControlID="txtsubLL" Text="Subject Marathi"></asp:Label>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtsubLL" runat="server" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSubUL" runat="server" AssociatedControlID="txtsubLL" Text="Subject Urdu"></asp:Label>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtsubUL" runat="server" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPathEng" runat="server" Text="English Pdf" AssociatedControlID="FileUploadEng"></asp:Label>
            </td>
            <td class="labelDescription">
                <asp:FileUpload ID="FileUploadEng" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUploadEng"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                <asp:Label ID="lblPathMar" runat="server" Text="Marathi Pdf" AssociatedControlID="FileUploadMar"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUploadMar" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 15px">
                <asp:Label ID="lblPathUrdu" runat="server" Text="Urdu Pdf" AssociatedControlID="FileUploadUrdu"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUploadUrdu" runat="server" />
            </td>
        </tr>
        <tr >
            <td style="height: 15px" align="right">
               <asp:Label ID="Label1" runat="server" Text="Archive" AssociatedControlID="FileUploadEng"></asp:Label>
            </td>
            <td align="left">
              <asp:CheckBox ID="chkArchive" runat="server" OnCheckedChanged="chkArchive_CheckedChanged" AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                    CssClass="btn btn-sm btn-success" ValidationGroup="VC" OnClientClick="return ValidateForm()"  />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-warning"  />
            </td>
        </tr>
    </table>
    <table class="t_view" width="100%">
        <tr>
            <td align="center">
                <asp:GridView ID="grdupload" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False"
                    AllowPaging="true" CellPadding="3" GridLines="Vertical" Width="100%" OnRowCommand="grdupload_RowCommand"
                    PageSize="5" OnPageIndexChanging="grdupload_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="SR No" SortExpression="SRNo" ControlStyle-CssClass="align-center">
                            <ItemTemplate>
                                <asp:Label ID="lblSN" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Document No" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblDOcNo" runat="server" Text='<%# Bind("DocumentNO_LL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="दस्तएवज क्रमांक" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblDOcNoLL" runat="server" Text='<%# Bind("DocumentNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Subject" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblsub" runat="server" Text='<%# Bind("subject") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="विषय" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblsubLL" runat="server" Text='<%# Bind("subject_LL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="Date" SortExpression="CreatedDate">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <a class='align-center' href='<%# "../../Site/Upload/GR/" + Convert.ToString(Eval("DocumentPath"))%>'
                                    target="_blank">
                                    <img id="img1" src="../../Images/pdf.png" alt="PDF" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Size">
                            <ItemTemplate>
                                <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="linkEdit" runat="server" CausesValidation="False" CommandName="View"
                                    CommandArgument='<%# Eval("DocumentID") %>' Text="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <span onclick="return confirm('Are you sure to Delete?')">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="delete1"
                                        CommandArgument='<%# Eval("DocumentID") %>' Text="Delete"></asp:LinkButton>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
`        </tr>
    </table>
</asp:Content>
