<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master"
    AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="PMMYA.Site.Home.Feedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Src="~/Controls/WebSiteControls/TextCaptcha.ascx" TagName="Captcha"
    TagPrefix="UCCaptcha" %>--%>
<%@ Register Src="~/Controls/WebSiteControls/UCBreadCrum.ascx" TagName="BreadCrum"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

      <link href="../../Styles/jquery-ui-1.8.10.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../css/msgBoxLight.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/ValidationScripts.js"></script>
    <script type="text/javascript" src="../../js/jquery.msgBox.js"></script>
    <style type="text/css">
        .formLabel {
            width: 260px !important;
            height: 85px !important;
        }
    </style>


      <script type="text/javascript">
          $(document).ready(function () {


             $("#SitePH_btnSubmit").click(function () {
                  return Validation();
               });
         


          function Validation() {

              
                 var txt = "";
                 var opMode = "";

                  var txtName = $("#SitePH_txtName");
                  if (txtName != null && txtName.val() == '') {
                     txt +='<%= HttpContext.GetGlobalResourceObject("FeedBack", "rfvName") %>'
                    var opt = 1;
                 }


                  var TxtEmail = $("#SitePH_txtEmail");
                  if (TxtEmail != null && TxtEmail.val() == '') {
                     txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "RfvEmail") %>'
                    var opt = 1;
                 }


                   if (TxtEmail != null && TxtEmail.val() != '') {
                    var EmailMatch = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                    if (EmailMatch.test(TxtEmail.val())) {
                    }
                    else {
                        txt += '<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "ErrorValidEmail") %>';
                        opt = 1;
                    }
                }

                var Mobile = $("#SitePH_txtMobile");
                if (Mobile != null && Mobile.val() == '') {
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "rfvMobile") %>'
                    var opt = 1;
                 }


                 if (Mobile != null && Mobile.val() != '') {
                    var mobmatch = /^[789]\d{9}$/;
                    if (Mobile.val().length > 0 && !mobmatch.test(Mobile.val())) {
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "ErrorValidMobile") %>'
                        opt = 1;
                    }
                }


                var ddlDistrict_selectedIndex = $("#SitePH_ddlDistrict").get(0).selectedIndex;
                if (ddlDistrict_selectedIndex == 0) {
                    txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "rfvDistrict") %>'
                    var opt = 1;
                }


                  var TxtSubject = $("#SitePH_TxtSubject");
                  if (TxtSubject != null && TxtSubject.val() == '') {
                     txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "rfvSubject") %>'
                    var opt = 1;
                 }

                  var TxtFeedback = $("#SitePH_txtFeedback");
                  if (TxtFeedback != null && TxtFeedback.val() == '') {
                     txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "rfvFeedback") %>'
                    var opt = 1;
                 }

               var TxtCaptcha = $("#SitePH_txtimgcode");
               var hdnCaptcha = $("#SitePH_hdnCaptcha");
                  if (TxtCaptcha != null && TxtCaptcha.val() == '') {
                     txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "txtCaptcha") %>'
                    var opt = 1;
               }

               if (TxtCaptcha != null && TxtCaptcha.val() != '') {
                    if (TxtCaptcha.val() != hdnCaptcha.val().replace(/ /g, '')) {
                        txt +='<br /> <%= HttpContext.GetGlobalResourceObject("FeedBack", "txtCaptchavalid") %>'
                        var opt = 1;
                    }
                }

                


                 if (opt == "1") {
                    Captcha();
                    var header = '<%= HttpContext.GetGlobalResourceObject("Common", "ErrorHeader") %>'
                    alertPopup(header, txt);
                    return false;
                }
          }


               });
    </script>

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




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SitePH" runat="server">
    <div class="headingBg">

        <uc:BreadCrum ID="BreadCrum" runat="server" />

    </div>
    <div class="form-group col-md-6 col-md-offset-3">
        <h1>
            <asp:Label ID="lblFeedbackHeading" runat="server" Text="Feedback"></asp:Label></h1>
    </div>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
        <div class="searchMarg">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Save" ShowMessageBox="true" ShowSummary="false" CssClass="failureNotification" />
        </div>
        <div class="searchInner searchMarg">
            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblMandatory" runat="server" Visible="false" CssClass="errorMsg" Text="* denotes mandatory fields" Height="18px" Style="color: red; font-weight: bolder;"></asp:Label>
            </div>



            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblName" AssociatedControlID="txtName" runat="server" Text="Name" CssClass="manadatory"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Please Enter Name" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="Email" CssClass="manadatory"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" ToolTip="" CssClass="form-control" MaxLength="254"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Please Enter Email" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>

                <%-- <asp:FilteredTextBoxExtender ID="fteEmail" runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers"
                            ValidChars="_@." TargetControlID="txtEmail">
                        </asp:FilteredTextBoxExtender>--%>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Please Enter Valid Email-id"
                    ValidationGroup="Save" Display="None" ControlToValidate="txtEmail" ForeColor="Red"
                    ValidationExpression="^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" SetFocusOnError="true"></asp:RegularExpressionValidator>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblMobile" AssociatedControlID="txtMobile" runat="server" Text="Mobile" CssClass="manadatory"></asp:Label>
                <asp:TextBox ID="txtMobile" runat="server" ToolTip="" CssClass="form-control" MaxLength="10" onkeypress="return validatenumerics(event);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile"
                    ErrorMessage="Please Enter Mobile" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revMobile" runat="server" ErrorMessage="Mobile Number must be 10-digit number" ControlToValidate="txtMobile"
                    Display="None" ValidationGroup="Save" SetFocusOnError="true" ForeColor="Red" ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
                <%-- <asp:FilteredTextBoxExtender ID="fteEngPhone" runat="server" FilterType="Numbers,Custom"
                            ValidChars="/- ," TargetControlID="txtMobile">
                        </asp:FilteredTextBoxExtender>--%>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblDistrict" AssociatedControlID="ddlDistrict" runat="server" Text="District" CssClass="manadatory"></asp:Label>
                <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvddldistrict" runat="server" ControlToValidate="ddlDistrict"
                    ErrorMessage="Please Select District" Display="None" InitialValue="0" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblSub" AssociatedControlID="TxtSubject" runat="server" Text="Subject" CssClass="manadatory"></asp:Label>
                <asp:TextBox ID="TxtSubject" runat="server" ToolTip="" CssClass="form-control" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="TxtSubject"
                    ErrorMessage="Please Enter Subject" Display="None" SetFocusOnError="true" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Label ID="lblFeedback" AssociatedControlID="txtFeedback" runat="server" Text="Feedback" CssClass="manadatory"></asp:Label>
                <asp:TextBox ID="txtFeedback" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" ToolTip=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFeedback" runat="server" ErrorMessage="Please Enter Feedback"
                    ControlToValidate="txtFeedback" Display="None" ValidationGroup="Save" ForeColor="Red"
                    CssClass="errorMsg" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>

            <%--<div class="form-group col-md-6 col-md-offset-3">
                <label>Captcha (पडताळणी संकेतांक कोड)</label>
                <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="form-control"></asp:TextBox>
                <label>
                    <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                        id="sp_captcha" runat="server" style="color: Red">*</span>
                    <asp:Image ID="Image1" runat="server" Height="50px" Width="220px" ImageUrl="~/Site/Home/captcha.aspx" />

                    <input type="image" onclick="document.getElementById('form1').submit();" src="../../Images/Refresh.png"
                        alt="Refresh Captcha" style="width: 30px; height: 30px;" /></label>
            </div>--%>

            <div class="form-group col-md-6 col-md-offset-3">
                <%--<label>Captcha (पडताळणी संकेतांक कोड)</label>--%>
                <asp:Label ID="Lblcaptcha" AssociatedControlID="txtimgcode" runat="server" Text="Captcha (पडताळणी संकेतांक कोड)" CssClass="manadatory"></asp:Label>
                <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="form-control"></asp:TextBox><br>
                <label><label>
                    <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                        id="sp_captcha" runat="server" style="color: Red">*</span></label>
                    <asp:TextBox ID="txtCaptchAnswer" runat="server" class="form-control" disabled="true"></asp:TextBox>
                    <asp:HiddenField ID="hdnCaptcha" runat="server" Value="" />
                    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>                   
                </label>
                 <button type="button" onclick="Captcha();" />
                    <img src="../../Images/Refresh.png" alt="Refresh Captcha" />
            </div>

            <div class="form-group col-md-6 col-md-offset-3">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-m btn-success" Text="Submit" 
                    OnClick="btnSubmit_Click" />&nbsp;
                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-m btn-danger" Text="Reset" OnClick="btnReset_Click" />
            </div>


        </div>
       <%-- </label>--%>
    </asp:Panel>

    <script type="text/javascript">
        function Captcha() {
            var alpha = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z');
            var i;
            for (i = 0; i < 5; i++) {
                var a = alpha[Math.floor(Math.random() * alpha.length)];
                var b = alpha[Math.floor(Math.random() * alpha.length)];
                var c = alpha[Math.floor(Math.random() * alpha.length)];
                var d = alpha[Math.floor(Math.random() * alpha.length)];
                var e = alpha[Math.floor(Math.random() * alpha.length)];

            }
            var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e;
            document.getElementById("SitePH_txtCaptchAnswer").value = code;
            document.getElementById("SitePH_hdnCaptcha").value = code;
        }
    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            Captcha();
        });
    </script>

</asp:Content>
