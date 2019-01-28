<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" EnableEventValidation="false" ValidateRequest="false" CodeBehind="Financer.aspx.cs" Inherits="PMMYA.Site.Home.Financer" %>

<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap.min.css" rel="stylesheet">--%>
    <script type="text/javascript">
        function PopulateControl(list, control) {

            if (list.length > 0) {

                control.removeAttr("disabled");
                control.empty().append('<option selected="selected" value="0">--Select--</option>');
                $.each(list, function () {
                    control.append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            else {
                control.empty().append('<option selected="selected" value="0">--Select--<option>');
            }
        }
        function PopulateSubDistrict() {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/Financer.aspx")%>'
            if ($('#SitePH_ddldistrict').val() == "0") {
                $('#SitePH_ddlTaluka').empty().append('<option selected="selected" value="0">--Select--</option>');
            }
            else {
                $('#SitePH_ddlTaluka').empty().append('<option selected="selected" value="0">Loading...</option>');
                $('#example').DataTable().clear().draw();
                $('#DivTbl').css('display', 'none');
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/PopulateSubDistrict',
                    data: '{DistrictID: ' + $('#SitePH_ddldistrict').val() + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnCitiesPopulated,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
        }

        function OnCitiesPopulated(response) {
            PopulateControl(response.d, $("#SitePH_ddlTaluka"));
        }
        function BindBankDetails() {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/Financer.aspx")%>'
            if ($('#SitePH_ddlTaluka').val() == "0") {
                $('#example').DataTable().clear().draw();
                $('#DivTbl').css('display', 'none');
            }
            else {
                $.ajax({
                    type: "POST",
                    url: pageUrl + '/BindBankList',
                    data: "{'districtid':'" + $('#SitePH_ddldistrict').val() + "','talukaid':'" + $('#SitePH_ddlTaluka').val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnBankPopulated,
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }

        }


        function OnBankPopulated(response) {
            //var output = '';
            //for (var entry in response) {
            //    output += 'key: ' + entry + ' | value: ' + response[entry] + '\n';
            //}
            //alert(output);           
            PopulateTableControl(response.d, $("#example"));

        }

        function PopulateTableControl(list, control) {
            if (list.length > 0) {
                //control.empty();
                //var table = $('#example');
                //table.html('<table id="example" class="display" style="width: 100%">');
                ////table.append('');
                //table.append('<thead><tr><th>Bank Name</th><th>Branch Name</th><th>Branch Address</th><th>IFSC Code</th></tr></thead>');

                //table.append('<tbody>');

                //for (var i = 0; i < list.length; i++) {
                //    //table.append('<tr><td>Vidarbha Konkan Gramin Bank</td><td>Dhanora</td><td>Main Road  A/p Dhanora Tal Dhanora Dist Gadchiroli 442606 </td><td>BKID0WAINGB</td></tr>');
                //    table.append('<tr><td>' + list[i].BankName + '</td><td>' + list[i].BranchName + '</td><td>' + list[i].BranchAddress + '</td><td>' + list[i].IFSCode + '</td></tr>');                
                //}

                //table.append('</tbody>');
                //table.append('</table>');

                //var trHTML = '';
                //trHTML+='<thead><tr><th>BankName</th><th>BranchName</th><th>BankAddress</th><th>IFSCCode</th></tr></thead>'

                //$.each(list, function () {

                //     trHTML += '<tbody><tr><td>' + this.BankName + '</td><td>' + this.BranchName + '</td><td>' + this.BranchAddress + '</td><td>' + this.IFSCode + '</td></tr> </tbody>';
                // });

                //$('#example').append(trHTML);
                $('#example').DataTable().clear().draw();

                $('#DivTbl').css('display', 'inline');
                for (var i = 0; i < list.length; i++) {
                    //$("#example").append("<tr><td>" + data.d[i].Srno + "</td><td>" + data.d[i].DistrictName + "</td><td>" + data.d[i].DPOName + "</td><td>" + data.d[i].DPOAddress + "</td><td>" + data.d[i].EmailID + "</td><td>" + data.d[i].TelNo + "</td></tr > ");
                    //alert(JSON.stringify(data));                    
                    $('#example').dataTable().fnAddData([list[i].BankName, list[i].BranchName, list[i].BranchAddress, list[i].IFSCode]);

                }


            }
            else {
                $('#example').DataTable().clear().draw();
                //$('#example').dataTable().append('No Data Found...');
                //$('#DivTbl').css('display', 'none');
                // control.empty().append('No data found..!');
                //$('#DivTbl').empty().append('No data found..!');
                //$('#example').DataTable();
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="headingBg">

        <uc:BreadCrum ID="BreadCrum" runat="server" />

    </div>
    <div id="LeftMenuContent" runat="server" class="col-md-3">
        <div class="quick-links">
            <div id="PContent" runat="server"></div>
        </div>
    </div>
    <div class="col-md-9 brd-left1 pleft25">
        <div class="col-md-12">
            <h1>
                <asp:Label ID="lblBankDetails" runat="server" Text="Know Your Financer"></asp:Label>
            </h1>
        </div>

        <%--<div class="container">--%>
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="lblDistrict" AssociatedControlID="ddlDistrict" runat="server" Text="District"></asp:Label>
                <asp:DropDownList ID="ddldistrict" runat="server" class="form-control" onchange="PopulateSubDistrict();">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label ID="lblTaluka" AssociatedControlID="ddlTaluka" runat="server" Text="Taluka"></asp:Label>
                <asp:DropDownList ID="ddlTaluka" runat="server" class="form-control" onchange="BindBankDetails();">
                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <%-- </div>--%>

        <%--<div class="container">--%>
        <div class="col-md-12" id="DivTbl" style="display: none">
            <div class="table-responsive">
                <table id="example" class="t_view" style="width: 100%;">
                    <thead>
                        <tr>
                            <th>
                                <asp:Label ID="LblBankName" runat="server" Text="BankName"></asp:Label></th>
                            <th>
                                <asp:Label ID="LblBranchName" runat="server" Text="BranchName"></asp:Label></th>
                            <th>
                                <asp:Label ID="LblBankAddress" runat="server" Text="BankAddress"></asp:Label></th>
                            <th>
                                <asp:Label ID="LblIFSCCode" runat="server" Text="IFSCCode"></asp:Label></th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
        <%--</div>--%>

        <div class="clearfix">
        </div>


    </div>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable();
        });
    </script>--%>
</asp:Content>

