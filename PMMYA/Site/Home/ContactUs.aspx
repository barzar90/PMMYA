<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="PMMYA.Site.Home.ContactUs" %>

<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%-- <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/dataTables.jqueryui.min.js"></script>
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet">
    <link href="https://cdn.datatables.net/1.10.19/css/dataTables.jqueryui.min.css" rel="stylesheet">--%>


    <%-- <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap.min.css" rel="stylesheet">

    <script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap.min.js"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            var pageUrl = '<%=ResolveUrl("~/Site/Home/ContactUs.aspx")%>'
            $.ajax({
                type: "POST",
                url: pageUrl + "/BindDpoDetails",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //$("#example").dataTable({
                    //    data: data,
                    //    columns: [
                    //        { "data": "Srno" },
                    //        { "data": "DistrictName" },
                    //        { "data": "DPOName," },
                    //        { "data": "DPOAddress" },
                    //        { "data": "EmailID" },
                    //        { "data": "TelNo" },
                    //    ]
                    for (var i = 0; i < data.d.length; i++) {
                        //$("#example").append("<tr><td>" + data.d[i].Srno + "</td><td>" + data.d[i].DistrictName + "</td><td>" + data.d[i].DPOName + "</td><td>" + data.d[i].DPOAddress + "</td><td>" + data.d[i].EmailID + "</td><td>" + data.d[i].TelNo + "</td></tr > ");
                        //alert(JSON.stringify(data));
                        $('#example').dataTable().fnAddData([data.d[i].Srno, data.d[i].DistrictName, data.d[i].DPOName, data.d[i].DPOAddress, data.d[i].EmailID, data.d[i].TelNo]);
                    }


                    //});
                }
            });

        });

       <%-- $(document).ready(function () {
            $('#example').dataTable({
                "oLanguage": {
                    "sSearch": "<%= HttpContext.GetGlobalResourceObject("FeedBack", "RfvEmail") %>",
                    "sLengthMenu": "Display _MENU_ records"
                }
            });
        });--%>
</script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <div class="headingBg">

        <uc:BreadCrum ID="BreadCrum" runat="server" />

    </div>
    <div class="col-md-12 box-container">
        <div class="col-md-12" style="padding-bottom: 10px;">
            <h1>
                <asp:Label ID="lblContact" runat="server" Text="Contact Us"></asp:Label>
            </h1>
        </div>
        <div class="box-body">
            <div class="container">
                <div class="col-xs-12 col-sm-10">
                    <div class="table-responsive">
                        <table id="example" class="t_view" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>
                                        <asp:Label ID="LblSrno" runat="server" Text="SrNo"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblDistrict" runat="server" Text="District"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="LblDponame" runat="server" Text="DPO Name"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="LblOfficeAddress" runat="server" Text="Office Address"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="LblEmailIdContact" runat="server" Text="Email ID"></asp:Label></th>
                                    <th>
                                        <asp:Label ID="LblTelNo" runat="server" Text="Tel.No."></asp:Label></th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>


    </div>
    <div class="clearfix">
    </div>



</asp:Content>
