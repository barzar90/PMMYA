<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Masters/WebSiteMasters/LDM_Master.Master" CodeBehind="LdmDashboard.aspx.cs" Inherits="PMMYA.Admin.MenuManagement.LdmDashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FormsHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FormsPH" runat="server">
    <style>
        svg rect {
            fill: #e9eaeb;
        }
    </style>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="//www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'LdmDashboard.aspx/GetBestFiveBanks',
                data: '{}',
                success:
                    function (response) {
                        drawVisualization(response.d);
                    }
            });
        })
        function drawVisualization(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].ColumnName, dataValues[i].Value]);
            }
            new google.visualization.PieChart(document.getElementById('visualization')).
                draw(data, { title: "" });
        }
    </script>

    <script type="text/javascript">
        google.load('visualizationdist', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'LdmDashboard.aspx/GetBestFiveDistricts',
                data: '{}',
                success:
                    function (response) {
                        drawVisualizationdist(response.d);
                    }
            });
        })
        function drawVisualizationdist(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].ColumnName, dataValues[i].Value]);
            }
            new google.visualization.PieChart(document.getElementById('visualizationdist')).
                draw(data, { title: "" });
        }
    </script>

    <div class="content-wrapper" style="margin-left: 0px;">
        <div class="row">
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box" style="background-color: #00B0F0;">
                    <div class="info-box-content-ldmdashboard" style="color: white;">
                        <asp:Label runat="server" class="info-box-text" Style="font-weight: bold;" ID="das_Shishu" Text=""></asp:Label>

                        <asp:Label runat="server" class="info-box-text" ID="ShishuApplicationText" Text="Total application received : ">
                            <asp:Label runat="server" ID="ShishuApplicationNum"></asp:Label>
                        </asp:Label>
                        <asp:Label runat="server" class="info-box-text" ID="ShishuSanctionText" Text="Sanction Amount : ">
                            <asp:Label runat="server" ID="ShishuSanctionAmt"></asp:Label>
                        </asp:Label>
                        <asp:Label runat="server" class="info-box-text" ID="ShishuDisburseText" Text="Disburse Amount : ">
                            <asp:Label runat="server" ID="ShishuDisburseAmt"></asp:Label>
                        </asp:Label>

                    </div>
                </div>
            </div>
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box" style="background-color: #3C336D;">
                    <div class="info-box-content-ldmdashboard" style="color: white;">
                        <asp:Label runat="server" class="info-box-text" Style="font-weight: bold;" ID="das_Kishore" Text="Kishore"></asp:Label>

                        <asp:Label runat="server" class="info-box-text" ID="KishoreApplicationText" Text="Total application received : ">
                            <asp:Label runat="server" ID="KishoreApplicationNum"></asp:Label>
                        </asp:Label>
                        <asp:Label runat="server" class="info-box-text" ID="KishoreSanctionText" Text="Sanction Amount : ">
                            <asp:Label runat="server" ID="KishoreSanctionAmt"></asp:Label>
                        </asp:Label>
                        <asp:Label runat="server" class="info-box-text" ID="KishoreDisburseText" Text="Disburse Amount : ">
                            <asp:Label runat="server" ID="KishoreDisburseAmt"></asp:Label>
                        </asp:Label>
                    </div>
                </div>
            </div>
            <div class="clearfix visible-sm-block"></div>
            <div class="col-md-4 col-sm-6 col-xs-12">
                <div class="info-box" style="background-color: #EC9F5A;">
                    <div class="info-box-content-ldmdashboard" style="color: white;">
                        <asp:Label runat="server" class="info-box-text" Style="font-weight: bold;" ID="das_Tarun" Text="Tarun"></asp:Label>

                        <asp:Label runat="server" class="info-box-text" ID="TarunApplicationText" Text="Total application received : ">
                            <asp:Label runat="server" ID="TarunApplicationNum"></asp:Label>
                        </asp:Label>
                        <asp:Label runat="server" class="info-box-text" ID="TarunSanctionText" Text="Sanction Amount : ">
                            <asp:Label runat="server" ID="TarunSanctionAmt"></asp:Label>
                        </asp:Label>
                        <asp:Label runat="server" class="info-box-text" ID="TarunDisburseText" Text="Disburse Amount : ">
                            <asp:Label runat="server" ID="TarunDisburseAmt"></asp:Label>
                        </asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <%--Mahesh Vs Kamlakar Start--%>
        <br />
        <div class="row" style="text-align: center;">
            <div class="col-xs-12 col-sm-6 col-md-6">
                <asp:Label ID="lblMessage" runat="server" Visible="False" Font-Bold="True" ForeColor="#009933"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-12 col-ms-6 col-md-6">
                <h2 runat="server" id="lblAppliedForm" style="margin-top:6px;">Applied Form</h2>
            </div>
            <div class="col-xs-12 col-ms-6 col-md-6">
                <asp:Button ID="btnExport" Style="float: right; margin-bottom: 5px;" class="btn btn-primary" runat="server" Text="Send Mail" OnClick="btnExport_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <asp:GridView CssClass="table table-bordered table-striped" ID="grdAppFrm" AllowPaging="True"
                    AutoGenerateColumns="False" EmptyDataText="There is no data to display" runat="server"
                    OnRowDataBound="grdAppFrm_RowDataBound"
                    OnRowCancelingEdit="grdAppFrm_RowCancelingEdit"
                    OnRowEditing="grdAppFrm_RowEditing"
                    OnRowUpdating="grdAppFrm_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                                <%#  Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Application ID" DataField="ApplicationID" ItemStyle-HorizontalAlign="Left" ControlStyle-Width="50px" />
                        <asp:BoundField HeaderText="Applicant Name" DataField="FullName" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderText="Request Amount" DataField="LoanAmount" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderText="Sanction Amount" DataField="AnnualSaleExt" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderText="Disburse Amount" DataField="AnnualSaleProp" ItemStyle-HorizontalAlign="Left" />

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblAction" runat="server" Text='<%# Bind("Status") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlAction" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlAction_SelectedIndexChanged" AppendDataBoundItems="True">
                                    <asp:ListItem Selected="True" Value="0" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="label1" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <PagerStyle CssClass="pager-d" />
                </asp:GridView>
            </div>
        </div>


        <%--Mahesh Vs Kamlakar End--%>

        <div class="row">
            <div class="col-xs-12 col-xl-6 col-md-6">
                <h4 style="color: black; font-size: 25px; font-weight: bold; text-align: center !important;">Top 5 Best Performance Bank</h4>
                <asp:HiddenField ID="hdn_ddnm" runat="server" Visible="False"></asp:HiddenField>
                <div id="visualization" style="width: 500px; height: 250px;">
                </div>
            </div>

            <div class="col-xs-12 col-xl-6 col-md-6">
                <h4 style="color: black; font-size: 25px; font-weight: bold; text-align: center !important;">Top 5 Best Performance District</h4>
                <asp:HiddenField ID="hdn_ddnmDistrict" runat="server" Visible="False"></asp:HiddenField>
                <div id="visualizationdist" style="width: 500px; height: 250px;">
                </div>
            </div>
        </div>

    </div>
</asp:Content>
