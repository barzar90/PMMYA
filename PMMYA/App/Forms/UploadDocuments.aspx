<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="UploadDocuments.aspx.cs" Inherits="PMMYA.App.Forms.UploadDocuments" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/WebSiteControls/PagerControl.ascx" TagName="PagerControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script language="javascript" type="text/javascript">
    function checkDate(sender, args) {


        if (sender._selectedDate > new Date()) {
            alert("You Can Not Select Date Greater Than Todays Date!");
            sender._selectedDate = new Date();
            //sender._selectedDate = "";
            // set the date back to the current date 
            sender._textbox.set_Value(sender._selectedDate.format(sender._format))
        }
    }
    function isBS(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode || 8)

            return false;

        return true;


    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>
    <span>Upload Road Map To Success</span>
         <div class="clearfix"></div>
    </h1>
    <asp:HiddenField ID="HDNUpdate" runat="server"/>    <table class="table table-bordered table-striped">
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Label ID="lblDocumentType" runat="server" AssociatedControlID="ddlDocumentType"
                    Text="Document Type"></asp:Label><span style="color: #f00;">*</span>
            </td>
            <td class="labelDescription">
                <asp:DropDownList ID="ddlDocumentType" CssClass="form-control"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDocumentType_SelectedIndexChanged">
                </asp:DropDownList>
                <a href="CreateDocType.aspx?mode=1" class="btn btn-sm btn-default"><b>Cretae New Document Type</b></a>
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
                <a href="CreateDocType.aspx?mode=2" class="btn btn-sm btn-default"><b>Cretae New Sub Type</b></a>
            </td>
        </tr>
    </table> 
    <table class="table table-bordered table-striped">
    <tr>
     <td>
                <asp:HiddenField ID="HdnExt" runat="server" Value="" />
                <asp:HiddenField ID="HdnSizeLimit" runat="server" Value="0" />
                <asp:HiddenField ID="HdnDelete" runat="server" Value="0" />                
            </td>
    </tr>
        <tr>
            <td>
                <asp:Label ID="lblCreatedDate" AssociatedControlID="txtCreatedDate" runat="server"
                    Text="Date"></asp:Label><span style="color: #f00;">*</span>
            </td>
            <td class="labelDescription">
                <asp:TextBox ID="txtCreatedDate" runat="server" onkeydown="return isBS(event);" AutoCompleteType="Disabled" autocomplete="off"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCreatedDate"
                    OnClientDateSelectionChanged="checkDate">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCreatedDate"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitle" runat="server" AssociatedControlID="txtTitle" Text="Title"></asp:Label>
                <span style="color: #f00;">*</span>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtTitle" runat="server" DestinationLanguage="ENGLISH" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUploadEng"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitleLL" runat="server" AssociatedControlID="txtTitleLL" Text="title In Marathi"></asp:Label>
                <span style="color: #f00;">*</span>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtTitleLL" runat="server" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTitleLL"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTitleUL" runat="server" AssociatedControlID="txtTitleUL" Text="title In Urdu"></asp:Label>
                <span style="color: #f00;">*</span>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtTitleUL" runat="server" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTitleUL"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription" Text="Description"></asp:Label>
            </td>
            <td class="labelDescription">
                <cc1:TextBoxControl ID="txtDescription" runat="server" DestinationLanguage="ENGLISH" TypingMode="CDAC" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescriptionLL" runat="server" AssociatedControlID="txtDescriptionLL" Text="Description In Marathi"></asp:Label>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtDescriptionLL" runat="server" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblDescriptionUL" runat="server" AssociatedControlID="txtDescriptionUL" Text="Description In Urdu"></asp:Label>
            </td>
            <td>
                <cc1:TextBoxControl ID="txtDescriptionUL" runat="server" AutoCompleteType="Disabled" autocomplete="off"></cc1:TextBoxControl>
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
                <asp:Label ID="lblPathUr" runat="server" Text="Urdu Pdf" AssociatedControlID="FileUploadUr"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUploadUr" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label ID="lblFile" runat="server" Text="Select File"></asp:Label>&nbsp;(.jpg,.jpeg,.png,.bmp,.gif
                only)
            </td>
            <td>
                <asp:FileUpload ID="UploadImage" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="UploadImage"
                    Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red"
                    Font-Size="X-Small">This is required field</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIsActive" runat="server" Text="Active"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" />
            </td>
        </tr>
        <tr style="display: none">
            <td style="height: 15px" align="right">
                &nbsp;
            </td>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                    CssClass="btn btn-sm btn-success" ValidationGroup="VC" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-warning" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <table class="t_view" width="100%">
        <tr>
            <td align="center">
                <asp:GridView ID="grdupload" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="False"
                    AllowPaging="true" CellPadding="3" GridLines="Vertical" Width="100%" OnRowCommand="grdupload_RowCommand"
                    PageSize="5" OnPageIndexChanging="grdupload_PageIndexChanging" OnRowDeleting="grdupload_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="SR No" SortExpression="SRNo" ControlStyle-CssClass="align-center">
                            <ItemTemplate>
                                <asp:Label ID="lblSN" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("Title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="शीर्षक" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lbltitleLL" runat="server" Text='<%# Bind("Title_LL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Title In Urdu" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lbltitleUL" runat="server" Text='<%# Bind("Title_UL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="वर्णन" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lbldescLL" runat="server" Text='<%# Bind("Description_LL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description In Urdu" SortExpression="SRNo">
                            <ItemTemplate>
                                <asp:Label ID="lbldescUL" runat="server" Text='<%# Bind("Description_UL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date" SortExpression="CreatedDate">
                            <ItemTemplate>
                                <asp:Label ID="lbldatecreate" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <a class='align-center' href='<%# "../../Site/Upload/Pdf/" + Convert.ToString(Eval("DocumentPath"))%>'
                                    target="_blank">
                                    <img id="img1" src="../../Images/pdf.png" alt="PDF" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>                               
                                    <img id="img1" src="<%# "../../Site/Upload/Images/" + Convert.ToString(Eval("DocumentImage"))%>" alt="PDF" />
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
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="delete"
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
