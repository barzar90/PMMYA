<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistrictSubdistictUserControl.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.DistrictSubdistictUserControl" %>

<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<link href="../../Content/bootstrap.css" rel="stylesheet" />
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />

<style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    .Pager span
    {
        text-align: center;
        color: #999;
        display: inline-block;
        width: 20px;
        background-color: #A1DCF2;
        margin-right: 3px;
        line-height: 150%;
        border: 1px solid #3AC0F2;
    }
    .Pager a
    {
        text-align: center;
        display: inline-block;
        width: 20px;
        background-color: #3AC0F2;
        color: #fff;
        border: 1px solid #3AC0F2;
        margin-right: 3px;
        line-height: 150%;
        text-decoration: none;
    }
</style>
<script type = "text/javascript">
    debugger;
  
    var pageUrl = '<%=ResolveUrl("~/Site/Home/Index.aspx")%>' 
    function PopulateState() {
    $("#<%=ddlState.ClientID%>").attr("disabled", "disabled");
    $("#<%=ddlSubDistrict.ClientID%>").attr("disabled", "disabled");
    if ($('#<%=ddlState.ClientID%>').val() == "0") {
        $('#<%=ddlDistrict.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
        $('#<%=ddlSubDistrict.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
    }
    else {
        $('#<%=ddlDistrict.ClientID %>').empty().append('<option selected="selected" value="0">Loading...</option>');
        $.ajax({
            type: "POST",
            url: pageUrl + '/PopulateDistrict',
            data: '{StateID: ' + $('#<%=ddlState.ClientID%>').val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnCountriesPopulated,
            failure: function(response) {
                alert(response.d);
            }
        });
    }
}
 
function OnCountriesPopulated(response) {
    PopulateControl(response.d, $("#<%=ddlDistrict.ClientID %>"));
}
</script>

<script type = "text/javascript">
    function PopulateSubDistrict() {

    $("#<%=ddlSubDistrict.ClientID%>").attr("disabled", "disabled");
    if ($('#<%=ddlDistrict.ClientID%>').val() == "0") {
        $('#<%=ddlSubDistrict.ClientID %>').empty().append('<option selected="selected" value="0">Please select</option>');
    }
    else {
        $('#<%=ddlSubDistrict.ClientID %>').empty().append('<option selected="selected" value="0">Loading...</option>');
        $.ajax({
            type: "POST",
            url: pageUrl + '/PopulateSubDistrict',
            data: '{DistrictID: ' + $('#<%=ddlDistrict.ClientID%>').val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnCitiesPopulated,
            failure: function(response) {
                alert(response.d);
            }
        });
    }
}
 
function OnCitiesPopulated(response) {
    PopulateControl(response.d, $("#<%=ddlSubDistrict.ClientID %>"));
}
</script>



<script type = "text/javascript">
function PopulateControl(list, control) {
    if (list.length > 0) {
        control.removeAttr("disabled");
        control.empty().append('<option selected="selected" value="0">Please select</option>');
        $.each(list, function() {
            control.append($("<option></option>").val(this['Value']).html(this['Text']));
        });
    }
    else {
        control.empty().append('<option selected="selected" value="0">Not available<option>');
    }
}
</script>
<script type="text/javascript">  
    debugger;
    function PopulateBank() {

        debugger;
        $(document).ready(function () {
            var pageUrl1 = '<%=ResolveUrl("~/Site/Home/Index.aspx")%>'
            $.ajax({
                type: "POST",
                url: pageUrl1 + '/PopulateBank',
                data: '{TalukaID: ' + $('#<%=ddlSubDistrict.ClientID%>').val() + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json", success: function (result) {
                    alert(result);
                    alert('hi');
                    for (var i = 0; i < result.d.length; i++) {
                        $("#gvData").append("<tr><td>" + result.d[i].BankName + "</td><td>" + result.d[i].BranchAddress + "</td><td>" + result.d[i].BranchManagerName + "</td><td>" + result.d[i].BranchTelNowithSTDcode + "</td></tr>");
                    }
                }, error: function (result) {
                    alert("Error");
                }
            });

        });
   }
                </script>  


<script type="text/javascript">
    //$(function () {
 
    //    GetCustomers();
 
    //});
    function GetCustomers() {
        var pageUrl1 = '<%=ResolveUrl("~/Site/Home/Index.aspx")%>'
        debugger;
        $.ajax({
            type: "POST",
             url: pageUrl1 + '/GetCustomers',
             data: '{TalukaID: ' + $('#<%=ddlSubDistrict.ClientID%>').val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess,
            failure: function (response) {
                alert(response.d);
            },
            error: function (response) {
                alert(response.d);
            }
        });
    }
 
    function OnSuccess(response) {
        debugger;
        //var ajaxResult = [];
        //ajaxResult.push(response);
        var xmlDoc = $.parseXML(response.d);
        //alert(xmlDoc);
        var xml = $(xmlDoc);
        //alert(xml);
        var customers = xml.find("Table1");
        var row = $("[id*=gvCustomers] tr:last-child").clone(true);
        $("[id*=gvCustomers] tr").not($("[id*=gvCustomers] tr:first-child")).remove();
        $.each(customers, function () {
            //  debugger;
            var customer = $(this);
            $("td", row).eq(0).html($(this).find("BankName").text());
            $("td", row).eq(1).html($(this).find("BranchName").text());
            $("td", row).eq(2).html($(this).find("BranchAddress").text());
            $("td", row).eq(3).html($(this).find("DistrictName").text());
            $("[id*=gvCustomers]").append(row);
            row = $("[id*=gvCustomers] tr:last-child").clone(true);
        });
    };
</script>
<div class="col-md-6 col-md-offset-3">
<div class="form-group">
  <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
    <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="true"
        onchange="PopulateState();" class="form-control">
        <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
    </asp:DropDownList>
</div>

<div class=" form-group">
    <asp:Label ID="lblDistrict" runat="server" Text="District:"></asp:Label>
    <asp:DropDownList ID="ddlDistrict" runat="server"
        onchange="PopulateSubDistrict();" class="form-control">
        <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
    </asp:DropDownList>
 </div>

<div class=" form-group">
     <asp:Label ID="Label1" runat="server" Text="Taluka:"></asp:Label>
    <asp:DropDownList ID="ddlSubDistrict" runat="server" onchange="GetCustomers()" class="form-control">
        <asp:ListItem Text="Please select" Value="0"></asp:ListItem>
    </asp:DropDownList>
 </div>
</div>



<div class="col-md-10 col-md-offset-1">
<div>
    <asp:Label ID="Label2" runat="server" Text="Bank Details:"></asp:Label>
   
</div>
  <div>
 <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" RowStyle-BackColor="#A1DCF2"
            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" Width="100%">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="BankName" HeaderText="Bank Name" />
                <asp:BoundField ItemStyle-Width="150px" DataField="BranchName" HeaderText="Branch Name" />
                <asp:BoundField ItemStyle-Width="150px" DataField="BranchAddress" HeaderText="Branch Address" />
            </Columns>
        </asp:GridView>
</div>
    </div>