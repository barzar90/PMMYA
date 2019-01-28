<%@ Page Language="C#" MasterPageFile="~/Masters/WebSiteMasters/LDM_Master.Master" AutoEventWireup="true" CodeBehind="BestTopBankPerformance.aspx.cs" Inherits="PMMYA.App.LdmForms.BestTopBankPerformance" %>

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
                url: 'BestTopBankPerformance.aspx/GetBestFiveBank',
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
    <div class="container">
        <div class="col-xs-12">
            <div class="row">
                <div class="form-group">
                    <h4 style="color: black; font-size: 25px; font-weight: bold; text-align: center !important;">Top 5 Best Performance Bank</h4>
                </div>
            </div>

            <asp:HiddenField ID="hdn_ddnm" runat="server" Visible="False"></asp:HiddenField>
            <div id="visualization" style="width: 600px; height: 350px;">
            </div>
        </div>
    </div>

    <%-- <div class="container">
        <div class="col-xs-12">
            <div class="form-group">
                <h4 style="color: black; font-size: 25px; font-weight: bold; text-align: center !important;">Top 5 Best Performance Bank</h4>
            </div>
        </div>
        <asp:Chart ID="Chart1" runat="server" BackColor="#e9eaeb" Height="360px" Width="380px">
            <Titles>
                <asp:Title ShadowOffset="10" Name="Items" />
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                    LegendStyle="Row" />
            </Legends>
            <Series>
                <asp:Series Name="Default" />
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
            </ChartAreas>
        </asp:Chart>
    </div>--%>
</asp:Content>
