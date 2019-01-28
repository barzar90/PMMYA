<%@ Page Language="C#" MasterPageFile="~/Masters/WebSiteMasters/LDM_Master.Master" AutoEventWireup="true" CodeBehind="StateLevelReport.aspx.cs" Inherits="PMMYA.App.LdmForms.StateLevelReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-6 col-md-6">
                <div class="form-group">
                    <asp:Button ID="btnExport" class="btn btn-primary" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                    <asp:Label ID="hdnSession" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
                </div>
            </div>
            <div class="col-xs-12 col-sm-6 col-md-6">
                <div class="form-group">
                    <asp:Label ID="lblSearch" AssociatedControlID="txtSearch" runat="server" Text="Search State Name"></asp:Label>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" OnTextChanged="Search" MaxLength="30" AutoPostBack="true" Style="width: 50% !important; display: initial !important"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>

    <br />
    <div class="row" style="text-align: center;">
        <div class="col-xs-12 col-sm-12 col-md-12">
            <asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
        </div>
    </div>


    <asp:GridView ID="grdReport" CssClass="table table-bordered table-striped" runat="server"
        AutoGenerateColumns="false" AllowPaging="true" EmptyDataText="There is no data to display"
        AllowSorting="true" OnPageIndexChanging="OnPaging" ShowFooter="true">
        <Columns>
            <asp:TemplateField HeaderText="Sr No">
                <ItemTemplate>
                    <%#  Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="BankName" HeaderText="Bank Name" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="AnnualTarget" HeaderText="Annual Target" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ShiA/Cs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ShiSanAmt" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ShiDisAmt" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" />
            <%-----------%>
            <asp:BoundField DataField="KisA/Cs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="KisSanAmt" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="KisDisAmt" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" />
            <%-----------%>
            <asp:BoundField DataField="TarA/Cs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="TarSanAmt" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="TarDisAmt" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" />
            <%-----------%>
            <asp:BoundField DataField="ShiACsTotalACs" HeaderText="A/Cs" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="KisSanTotalACs" HeaderText="Sanct. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="TarDisTotalACs" HeaderText="Disbur. Amt" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="%ofAchievement" HeaderText="% of Achievement" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Rank" HeaderText="Rank" ItemStyle-HorizontalAlign="Left" />

            <%--            <asp:BoundField DataField="SanctionAmnt" HeaderText="Sanction Amount" ItemStyle-HorizontalAlign="Left" />            
            <asp:BoundField DataField="DisbursedAmnt" HeaderText="Disbursed Amount" ItemStyle-HorizontalAlign="Left" />          --%>
        </Columns>
        <PagerStyle CssClass="pager-d" />
    </asp:GridView>

</asp:Content>


