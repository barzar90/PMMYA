<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Forms/AppForms.Master" AutoEventWireup="true" CodeBehind="CreateMenu.aspx.cs" Inherits="PMMYA.Admin.MenuManagement.CreateMenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <div>
        <div class="row">
            <div class="text-left col-md-6">
                <h1>
                    <span>Create Menu</span>
                </h1>
            </div>
            <div class="col-md-6 text-right">
                <asp:LinkButton CssClass="btn btn-sm btn-danger pull-right" ID="linkBack" Text="Back"
                    CausesValsidation="true" runat="server" PostBackUrl="~/Admin/MenuManagement/MenuList.aspx" />
                <%--   onclick="linkBack_Click"--%>
            </div>
        </div>
        <div class="hajdivtable">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="Label1" runat="server" Text="Select Menu"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drpMenu" DataTextField="MenuName" DataValueField="MenuID" CssClass="form-control"
                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpMenu_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblSubMenu" Text="Sub Menu"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drpSubMenu" DataTextField="MenuName" DataValueField="MenuID" CssClass="form-control"
                        Visible="false" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblMenuCategory" runat="server" Text="Select Menu Category"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drpMenuCategory" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="MM">Main Menu</asp:ListItem>
                        <asp:ListItem Value="FM">Footer Menu</asp:ListItem>
                        <asp:ListItem Value="OM">Other Menu</asp:ListItem>
                        <%-- <asp:ListItem Value="HM">Non Menu Page</asp:ListItem>
                        <asp:ListItem Value="IM">Important Menu</asp:ListItem>
                        <asp:ListItem Value="QM">Quick Menu</asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6"></div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lblMenuType" Text="Menu Type"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drpMenuType" CssClass="form-control" DataTextField="MenuType" DataValueField="RowID"
                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpMenuType_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ForeColor="Red"
                        ControlToValidate="drpMenuType" ValidationGroup="save" runat="server" ErrorMessage="Please select menu type."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label2" Text="Value"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtMTValue" CssClass="form-control" runat="server" MaxLength="450"
                        Enabled="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="txtMTValue"
                        runat="server" ValidationGroup="save" ErrorMessage="please enter menu type value."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label runat="server" ID="lbl3" Text="Menu Name"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtMenuName" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtMenuName"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter menu name."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label3" Text="Local Language Name"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtMenuName_LL" runat="server" DestinationLanguage="MARATHI"
                        CssClass="form-control"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtMenuName_LL"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter local language menu name."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label4" Text="Hindi Language Name"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtMenuName_UL" runat="server" DestinationLanguage="Hindi"
                        CssClass="form-control"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" ControlToValidate="txtMenuName_UL"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter Hindi language menu name."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label5" Text="Page Title"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtPageTitle" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" ControlToValidate="txtPageTitle"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter Page Title."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label6" Text="Local Language Page Title"></asp:Label>
                </div>
                <div class="col-md-2">
                    <%--<asp:TextBox ID="txtMenuName_LL" CssClass="textEntry" runat="server"></asp:TextBox>--%>
                    <asp:TextBoxControl ID="txtPageTitle_LL" runat="server" DestinationLanguage="MARATHI"
                        CssClass="form-control"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" ControlToValidate="txtPageTitle_LL"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter local language Page Title."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label7" Text="Hindi Language Page Title"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtPageTitle_UL" runat="server" DestinationLanguage="URDU"
                        CssClass="form-control"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="Red" ControlToValidate="txtPageTitle_UL"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter Hindi language Page Title."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label8">Page Heading<span style="color: Red;">*</span></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtPageHead" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" ControlToValidate="txtPageHead"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter Page Head."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label9">Local Language Page Heading<span style="color: Red;">*</span></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtPageHead_LL" runat="server" DestinationLanguage="MARATHI"
                        CssClass="form-control"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" ControlToValidate="txtPageHead_LL"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter local language Page Head."></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label10">Hindi Language Page Heading<span style="color: Red;">*</span></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtPageHead_UL" runat="server" DestinationLanguage="Hindi"
                        CssClass="form-control"></asp:TextBoxControl>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="Red" ControlToValidate="txtPageHead_UL"
                        runat="server" ValidationGroup="save" ErrorMessage="Please enter Hindi language Page Head."></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label11">Meta Description</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtMDesc" TextMode="MultiLine" CssClass="form-control" Rows="6"
                        runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label12">Local Language Meta Description</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtMDesc_LL" runat="server" TextMode="MultiLine"
                        Rows="6" DestinationLanguage="MARATHI" CssClass="form-control"></asp:TextBoxControl>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label13">Hindi Language Meta Description</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtMDesc_UL" runat="server" TextMode="MultiLine"
                        Rows="6" DestinationLanguage="Hindi" CssClass="form-control"></asp:TextBoxControl>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label14">Meta Keywords</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtMKeywords" TextMode="MultiLine" Rows="6" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label15">Local Language Meta Keywords</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtMKeyWords_LL" runat="server" TextMode="MultiLine"
                        Rows="6" DestinationLanguage="MARATHI" CssClass="form-control"></asp:TextBoxControl>
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" ID="Label16">Hindi Language Meta Keywords</asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBoxControl ID="txtMKeyWords_UL" runat="server" TextMode="MultiLine"
                        Rows="6" DestinationLanguage="Hindi" CssClass="form-control"></asp:TextBoxControl>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label17">Menu Image</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:FileUpload ID="fileMenu" runat="server" CssClass="form-control" />
                    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label18">Sequence No<span style="color: Red;">*</span></asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtSequence" CssClass="form-control" runat="server"></asp:TextBox>
                    <br />
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtSequence"
                        ValidChars="0123654789" FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtSequence"
                        ValidationGroup="save" runat="server" ErrorMessage="Please enter sequence number."></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                        runat="server" ValidationExpression="[0-9]*\.?[0-9]*" Display="Dynamic" ControlToValidate="txtSequence"
                        ErrorMessage="Please enter only number"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label19">Is New Flag?</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:CheckBox ID="chkIsNew" runat="server" />
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label20">Is Active?</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:CheckBox ID="chkActive" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label21">Is need to open in Tab?</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:CheckBox ID="chkNewTab" runat="server" />
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="Label22">Is use in Mobile version?</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:CheckBox ID="chkmobileversion" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:Button ID="btnSave" CssClass="btn btn-sm btn-success" runat="server" Text="Save"
                        OnClick="btnSave_Click" ValidationGroup="save" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-sm btn-warning"
                        OnClientClick="javascript:history.go(-1);" OnClick="btnCancel_Click" />
                </div>
                <div class="col-md-6"></div>
            </div>
        </div>
    </div>
</asp:Content>
