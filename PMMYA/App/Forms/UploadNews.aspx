<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="UploadNews.aspx.cs" Inherits="PMMYA.App.Forms.UploadNews" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <%--  <script language="javascript" type="text/javascript">
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
</script>--%>  
    <link href="../../Styles/jquery-ui-1.8.10.custom.css" rel="stylesheet" type="text/css" />
  <%--  <script type="text/javascript" src="../../Styles/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.10.custom.min.js"></script>  
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>--%>
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.8.10.custom.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".Date").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: false,
                changeYear: false,               
                maxDate: '0'
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Upload News</h1>
        <div class="clearfix"></div>
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Height="400px">
        <table class="table table-bordered table-striped">
            <tr>
                <td align="center">
                    <asp:DataGrid ID="dg_PDF" AutoGenerateColumns="False" ShowFooter="True" runat="server"
                        Width="100%" DataKeyField="ID" CssClass="table table-bordered table-striped" OnCancelCommand="dg_PDF_CancelCommand" OnDeleteCommand="dg_PDF_DeleteCommand"
                        OnEditCommand="dg_PDF_EditCommand" OnItemCommand="dg_PDF_ItemCommand" OnItemDataBound="dgev_PDF_ItemDataBound"
                        OnUpdateCommand="dg_PDF_UpdateCommand">
                        <Columns>
                            <asp:TemplateColumn HeaderText="Sr No" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Sr_No" runat="server" Text='<%# Bind("Sr_No") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_Sr_No" runat="server" Text='<%# Bind("Sr_No") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="File ID" Visible="false" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lbl_ID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Date" ItemStyle-Width="50%"  >
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Date" runat="server" Text='<%#  Eval("CreatedDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                        <%--<asp:TextBox ID="txt_CreatedDate" runat="server" onkeydown="return isBS(event);" ></asp:TextBox>--%>
                                    <asp:TextBox ID="txt_CreatedDate" runat="server" CssClass="Date"></asp:TextBox>
                        <%-- <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_CreatedDate"></asp:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_CreatedDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="UPN" ForeColor="Red" Font-Size="X-Small" Text="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>                                
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_CreatedDate" runat="server" Text='<%#  Eval("CreatedDate","{0:dd/MM/yyyy}") %>' CssClass="Date"></asp:TextBox>
                                    <%--<asp:TextBox ID="txt_CreatedDate" runat="server" onkeydown="return isBS(event);" Text='<%#  Eval("CreatedDate","{0:dd/MM/yyyy}") %>'></asp:TextBox>--%>
                                    <%--<asp:TextBox ID="txt_CreatedDate" onkeydown="return isBS(event);"  runat="server" Width="95%" Height="40px" Text='<%#  Eval("CreatedDate","{0:dd/MM/yyyy}") %>' ></asp:TextBox>--%>
                                    <%--<asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txt_CreatedDate"></asp:CalendarExtender>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_CreatedDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="VC" ForeColor="Red" Font-Size="X-Small" Text="*"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="News" ItemStyle-Width="50%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_News" runat="server" Text='<%# Bind("News") %>' />
                                    <span>
                                        <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txt_News" runat="server" CssClass="formn-control"></asp:TextBox><span
                                        style="color: #f00;">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter events"
                                        Text="*" ForeColor="Red" ControlToValidate="txt_News" ValidationGroup="UPN"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_News" runat="server" Width="95%" Height="40px"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="News in Local Language" ItemStyle-Width="50%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_News_LL" runat="server" Text='<%# Bind("News_LL") %>' />
                                    <span>
                                        <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <cc1:TextBoxControl ID="txt_News_LL" runat="server" CssClass="formn-control upload-news-textarea" DestinationLanguage="MARATHI"
                                        Width="95%" Height="40px" TypingMode="CDAC" CDACDestinationLanguage="MARATHI"
                                        TextMode="MultiLine"></cc1:TextBoxControl>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter news"
                                        Text="*" ForeColor="Red" ControlToValidate="txt_News_LL" ValidationGroup="UPN"></asp:RequiredFieldValidator><span
                                            style="color: #f00;">*</span>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <cc1:TextBoxControl ID="txt_News_LL" runat="server" DestinationLanguage="MARATHI"
                                        Width="95%" Height="40px" CDACDestinationLanguage="MARATHI" TypingMode="CDAC"
                                        TextMode="MultiLine" CssClass="upload-news-textarea"></cc1:TextBoxControl>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="News in Hindi Language" ItemStyle-Width="50%">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_News_UL" runat="server" Text='<%# Bind("News_UL") %>' />
                                    <span>
                                        <%# (Convert.ToBoolean(Eval("IsNew")) == true ? "<img alt='New' src='../../img/gif_new.gif' />" : "")%></span></a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <cc1:TextBoxControl ID="txt_News_UL" runat="server" CssClass="formn-control upload-news-textarea" DestinationLanguage="Urdu"
                                        Width="95%" Height="40px" TypingMode="CDAC" CDACDestinationLanguage="MARATHI"
                                        TextMode="MultiLine"></cc1:TextBoxControl>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUL" runat="server" ErrorMessage="Enter news"
                                        Text="*" ForeColor="Red" ControlToValidate="txt_News_UL" ValidationGroup="UPN"></asp:RequiredFieldValidator><span
                                            style="color: #f00;">*</span>
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <cc1:TextBoxControl ID="txt_News_UL" runat="server" DestinationLanguage="Urdu"
                                        Width="95%" Height="40px" CDACDestinationLanguage="MARATHI" TypingMode="CDAC"
                                        TextMode="MultiLine"  CssClass="upload-news-textarea"></cc1:TextBoxControl>
                                </EditItemTemplate>
                            </asp:TemplateColumn>

                           <asp:TemplateColumn HeaderText="Is PDF/URL">
                                <FooterTemplate>
                                    <asp:CheckBox ID="chkFt_URL" runat="server" AutoPostBack="true" OnCheckedChanged="chkFt_URL_OnCheckedChanged" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkEd_URL" runat="server" AutoPostBack="true" OnCheckedChanged="chkEd_URL_OnCheckedChanged" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText=" URL / SelectFile" ItemStyle-Width="16%">
                                <ItemTemplate>
                                    <a href='<%#Eval("URL")%>'>
                                        <asp:Label ID="lbl_URL" runat="server" Text='<%# Bind("URL") %>' />
                                    </a>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txt_URL" runat="server" Width="90%" Height="40px" Visible="false"></asp:TextBox>
                                    <asp:FileUpload ID="UploadFile" runat="server" Width="90%" />
                                </FooterTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txt_URL" runat="server" Width="95%" Height="40px" Visible="false"></asp:TextBox>
                                    <asp:FileUpload ID="UploadFile" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Active">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Is_Active" runat="server" Checked='<%# Convert.ToBoolean(Eval("Is_Active")) %>'
                                        AutoPostBack="true" OnCheckedChanged="chk_Is_Active_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="IsNew">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chkstatus" AutoPostBack="true" key='<%# Eval("ID") %>' OnCheckedChanged="chkbox_OnCheckedChanged"
                                        runat="server" />
                                    <asp:Label ID="lblIsnew" Visible="false" runat="server" Text='<%# Eval("IsNew") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:EditCommandColumn UpdateText="Update" CancelText="Cancel" ItemStyle-CssClass="btn1 btn-info1" EditText="Edit" HeaderText="Edit">
                                <HeaderStyle Width="10%" />
                            </asp:EditCommandColumn>
                            <asp:TemplateColumn HeaderText="Delete">
                                <FooterTemplate>
                                    <asp:LinkButton ID="lbtn_Add" Text="Add" runat="Server" CssClass="btn btn-success" CommandName="Add" ValidationGroup="UPN" />
                                </FooterTemplate>
                                <ItemTemplate>
                                    <span onclick="return confirm('Are you sure to Delete?')">
                                        <asp:LinkButton ID="lbtn_Delete" runat="Server" Text="Delete" CssClass="btn btn-danger" CommandName="Delete" />
                                    </span>
                                </ItemTemplate>
                                <HeaderStyle Width="5%" />
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_Error" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </asp:Content>
