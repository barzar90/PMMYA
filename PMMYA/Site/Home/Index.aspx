<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Home.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PMMYA.Site.Home.Index" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">
    <asp:Label ID="lblWelcomeMsg" runat="server" Text="" Visible="false"></asp:Label>
    <%--<div id="mudradata" class="modal fade" style='background-color:#0000009e !important;'>
    <div class="modal-dialog" style="margin:12% auto">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                <h4 class="modal-title">PRADHAN MANTRI MUDRA YOJANA</h4>
            </div>
            <div class="modal-body">                
                <form>

                    <div class="form-group">
                       <label for="name">Name:</label>
                        <asp:TextBox ID="name" runat="server" class="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvname" runat="server" ErrorMessage="Please Enter Name" ControlToValidate="name"></asp:RequiredFieldValidator>

                    </div>
                   <div class="form-group">
                     <label for="MobileNo">Mobile No:</label>
                       <asp:TextBox ID="MobileNo" runat="server" class="form-control" MaxLength="10" onkeypress="return validatenumerics(event);"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="Please Enter Mobile Number" ControlToValidate="MobileNo"></asp:RequiredFieldValidator>
                   </div>

                     <div class="form-group">
                       <label>Loan Type</label>                        
                         <asp:DropDownList ID="ddlloantype" runat="server" class="form-control">
                             <asp:ListItem>Select</asp:ListItem>
                             <asp:ListItem>Shsihu</asp:ListItem>
                             <asp:ListItem>Kishore</asp:ListItem>
                             <asp:ListItem>Tarun</asp:ListItem>
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="rfvddlloantype" runat="server" ControlToValidate="ddlloantype" InitialValue="Select" ErrorMessage="Please Select Loan Type" />
                    </div>
                      <div class="form-group">
                     <label for="Amount">Amount:</label>
                      <asp:TextBox ID="Amount" runat="server" class="form-control" MaxLength="10" onkeypress="return validatenumerics(event);"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RfvAmount" runat="server" ErrorMessage="Please Enter Amount" ControlToValidate="Amount"></asp:RequiredFieldValidator>
                   </div>
                    <div class="form-group">
                        <label for="Description">Description:</label>
                        <asp:TextBox ID="Description" runat="server" class="form-control" TextMode="MultiLine" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvDescription" runat="server" ErrorMessage="Please Enter Description" ControlToValidate="Amount"></asp:RequiredFieldValidator>
                    </div>                    
                   <button type="submit" id="btnSubmit" class="btn btn-primary">Submit</button>                           
                </form>
            </div>
        </div>
    </div>
</div>--%>

<script type="text/javascript" language="javascript">
    function validatenumerics(key) {
        //getting key code of pressed key
        var keycode = (key.which) ? key.which : key.keyCode;
        //comparing pressed keycodes

        if (keycode > 31 && (keycode < 48 || keycode > 57)) {
            //alert(" You can enter only characters 0 to 9 ");
            return false;
        }
        else return true;


    }
</script>
    <%--<script type="text/javascript">
        $(document).ready(function () {

            $("#btnsubmit").click(function () {
                debugger;
                var txtName = $("[id*=name]").val();
                var txtMobile = $("[id*=MobileNo]").val();
                var txtDescription = $("[id*=Description]").val();
                var txtDescription = $("[id*=ddlloantype]").val();
                var txtAmount = $("[id*=Amount]").val();
                var Str = $.ajax({                    
                    //async: true,
                    url: '<%= ResolveUrl("~/Masters/WebSiteMasters/home.Master/CheckSession") %>',
                     data: "{}",
                     contentType: 'application/json; charset=utf-8',
                     type: 'POST',
                     dataType: "json",
                     success: function (result) {
                         debugger;
                         //if (result.d != '') {
                         //}
                         alert('Success');
                     },
                     error: function (error) {
                         // alert(error.responseText);
                         alert('error');
                     },

                 });



            });
        });
    </script>--%>
</asp:Content>
