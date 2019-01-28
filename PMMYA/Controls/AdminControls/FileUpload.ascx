<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.ascx.cs" Inherits="PMMYA.Controls.AdminControls.FileUpload" %>
<script src="../../Scripts/jquery.MultiFile.js" type="text/javascript"></script>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr> 
        <td class="label" style="width:16%">
       <%--  <asp:Label ID="Label8" runat="server" Text="Attach Expense Receipt"></asp:Label>--%>
        </td>       
        <td class="labelDescription" style="width:75%">
            <asp:FileUpload ID="FileUpload1" runat="server" class="multi" Enabled="true" maxlength="5" accept="pdf" size="4"/>            
            <span style="color:Red">Only jpg type is accepted.</span>        
        </td>
    </tr>
</table>