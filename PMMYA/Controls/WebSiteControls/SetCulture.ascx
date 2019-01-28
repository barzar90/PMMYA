<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SetCulture.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.SetCulture" %>
<li class="m_hide"><asp:Button ID="btn_Smallest" CausesValidation="false" runat="server" Text="A-" ToolTip="" OnClick="btn_Small_Click" CssClass="btnResizer" /></li>
<%--<li class="m_hide"><asp:Button ID="btn_Small" CausesValidation="false" runat="server" Text="A-" ToolTip="" OnClick="btn_Smallest_Click" CssClass="btnResizer" /></li>--%>
<li class="m_hide"><asp:Button ID="btn_Medium" CausesValidation="false" runat="server" Text="A" ToolTip="" OnClick="btn_Medium_Click" CssClass="btnResizer" /></li>
<%--<li class="m_hide"><asp:Button ID="btn_Large" CausesValidation="false" runat="server" Text="A+" ToolTip="" OnClick="btn_Large_Click" CssClass="btnResizer" /></li>--%>
<li class="m_hide"><asp:Button ID="btn_Larger" CausesValidation="false" runat="server" Text="A+" ToolTip="" OnClick="btn_Larger_Click1" CssClass="btnResizer" /></li>
<li class="m_hide"><asp:Button ID="btnABlack" CausesValidation="false" runat="server" Text="High Contrast" OnClick="btnABlack_Click" CssClass="btnBlack" /></li>
<li class="m_hide" style="background:none !important"><asp:Button ID="btnAWhite" CausesValidation="false" runat="server" Text="Low Contrast" OnClick="btnAWhite_Click" CssClass="btnWhite" /></li>
<li><asp:Button ID="btn_Language" CausesValidation="false" runat="server" Text="English" OnClick="btn_Language_Click" CssClass="btnResizer marathi-button" Visible="false" />
    <asp:DropDownList ID="DDL_Language" runat="server" Height="20px" Width="131px" AutoPostBack="True"  OnSelectedIndexChanged="DDL_Language_SelectedIndexChanged" CssClass="searchBG">
        <asp:ListItem Value="मराठी">मराठी</asp:ListItem>
        <asp:ListItem>English</asp:ListItem>
        <asp:ListItem Value="हिन्दी">हिन्दी</asp:ListItem>
    </asp:DropDownList>
</li>
