<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MudraData.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.MudraData" %>
<div id="mudradata" class="modal fade" style='background-color:#0000009e !important;'>
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
                        <%--<input type="text" class="form-control" id="name">--%>
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
                   <%-- <button type="submit" id="btnSubmit" class="btn btn-primary">Submit</button>--%>
                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
                    
                </form>
            </div>
        </div>
    </div>
</div>

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

<script type="text/javascript">

    //$(document).ready(function () {

    //    $("#btnSubmit").click(function () {
    //        validate();
    //    });
    //});

    function Validate() {
        var txtName = $("#MobileNo").val();
        var txtMobile = $("#MobileNo").val();
        var txtDescription = $("#Description").val();
        var ddlLoan = $("#ddlloantype").val();
        var txtAmount = $("#Amount").val();

        var txt = "Required to fill the following field(s)";
        var opt = 0;

        if (ddlLoan == "") {
            txt += "\n Please Select Loan Type";
            var opt = 1;
        }

        if (txtName == "") {
            txt += "\n Please Enter Name";
            var opt = 1;
        }

        if (txtMobile == "") {
            txt += "\n Please Enter Mobile Number";
            var opt = 1;
        }


        if (txtAmount == "") {
            txt += "\n Please Enter Amount";
            var opt = 1;
        }


        if (txtDescription = "") {
            txt += "\n Kindly Enter Description";
            var opt = 1;
        }


        if (opt == "1") {
            alert(txt);
            return false;
        }

        return true;
    }
    </script>