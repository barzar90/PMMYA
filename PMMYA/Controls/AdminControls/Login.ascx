<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="PMMYA.Controls.AdminControls.Login" %>
<script src="../../Scripts/md5.js" type="text/javascript"></script>
<link href="../../assets/bootstrap/css/main.css" rel="stylesheet" />
<script src="../../Scripts/jquery.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">

    function md5auth(seed) {
        var password = document.getElementById("<%= LoginUser.FindControl("Password").ClientID %>").value;
        var md1_password = calcMD5(password).toUpperCase();
        var hash = calcMD5(seed + md1_password);
        document.getElementById("<%= LoginUser.FindControl("Password").ClientID %>").value = hash.toUpperCase();
        return true;
    }
</script>

<h1>
    <asp:Label ID="lblLogin" runat="server"></asp:Label></h1>
<div class="clearfix">
</div>
<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
    OnLoggedIn="RedirectUser" OnAuthenticate="CreateLoginAudit">

    <LayoutTemplate>

        <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">
            <%--<div class="text-center col-md-8">
                <div class="login100-pic js-tilt">
                    <img src="../../Images/login.png" alt="" />
                </div>
            </div>--%>
            <div class="col-md-6 col-md-offset-3">
                <div class="mainbox login">
                    <%--<div class="login-top">
						    <img src="../../Images/login-mudra-icon.png">
					    </div>--%>
                    <div class="panel panel-warning" style="border-color: #104384">
                        <div class="panel-heading" style="background: #104384; color: #fff;">
                            <div class="panel-title">
                                <asp:Label ID="lblLoginPanel" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div style="padding-top: 30px" class="panel-body">
                            <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12">
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    CssClass="notification1" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    CssClass="notification1" ErrorMessage="Password is required." ToolTip="Password is required."
                                    ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                            <div style="margin-bottom: 20px" class="input-group col-md-12">
                                <div class="wrap-input100">
                                    <asp:Label ID="UserNameLabel" CssClass="sr-only" runat="server" AssociatedControlID="UserName"></asp:Label>
                                    <asp:TextBox ID="UserName" runat="server" autocomplete="off" CssClass="input100" placeholder="Username"></asp:TextBox>
                                    <span class="focus-input100"></span>
                                    <span class="symbol-input100">
                                        <i class="fa fa-user" aria-hidden="true"></i>
                                    </span>
                                </div>
                            </div>
                            <div style="margin-bottom: 20px" class="input-group col-md-12">
                                <div class="wrap-input100">
                                    <asp:Label ID="PasswordLabel" CssClass="sr-only" runat="server" AssociatedControlID="Password"></asp:Label>
                                    <input style="display: none" type="password" id="Password1">
                                    <asp:TextBox ID="Password" runat="server" CssClass="input100" TextMode="Password" placeholder="Password"
                                        autocomplete="off"></asp:TextBox>
                                    <span class="focus-input100"></span>
                                    <span class="symbol-input100">
                                        <i class="fa fa-lock" aria-hidden="true"></i>
                                    </span>
                                </div>
                            </div>
                            <%--<div style="margin-bottom: 25px" class="input-group col-md-12">
                                <div class="wrap-input100">
                                    <asp:Label ID="lblCaptcha" runat="server" Text="Captcha (पडताळणी संकेतांक कोड)"></asp:Label>
                                    <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="input100"></asp:TextBox>
                                    <span class="focus-input100"></span>

                                    <asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                                        id="sp_captcha" runat="server" style="color: Red">*</span>
                                    <asp:Image ID="Image1" runat="server" Height="50px" Width="220px" ImageUrl="~/Site/Home/captcha.aspx" />

                                    <input type="image" onclick="document.getElementById('form1').submit();" src="../../Images/Refresh.png"
                                        alt="Refresh Captcha" style="width: 30px; height: 30px;" />
                                </div>--%>
                            <div style="margin-bottom: 20px" class="input-group col-md-12">
                                <div class="wrap-input100">
                                    <label>Captcha (पडताळणी संकेतांक कोड)</label>
                                    <asp:TextBox ID="txtimgcode" runat="server" AutoComplete="Off" CssClass="input100"></asp:TextBox>
                                    <span class="focus-input100"></span>                                    
                                </div>
                            </div>

                            <div style="margin-bottom: 20px" class="input-group col-md-12">

                                <label class="manadatory" style="width: 100%">Case Sensitive</label>
                                <%--<asp:Label ID="lblNote" runat="server" Text="Case Sensitive" CssClass="addInfo"></asp:Label><span
                                        id="sp_captcha" runat="server" style="color: Red">*</span>--%>

                                <asp:TextBox ID="txtCaptchAnswer" runat="server" class="form-control" disabled="true" Width="50%" Style="border-radius: 25px; border: none;" Height="50px"></asp:TextBox>
                                <asp:HiddenField ID="hdnCaptcha" runat="server" Value="" />
                                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>

                                <button type="button" onclick="Captcha();" style="margin-top: 15px; margin-left: 10px; border-radius: 25px;" />
                                <img src="../../Images/Refresh.png" alt="Refresh Captcha" />




                            </div>

                            <div class="input-group col-md-12" style="display: none">
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="RememberMe" CssClass="checkbox" runat="server" />
                                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline"></asp:Label>
                                    </label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="Password"
                                        autocomplete="off"></asp:TextBox>
                                </div>
                            </div>
                            <p>
                                <asp:Label ID="PasswordSent" runat="server"></asp:Label>
                            </p>
                            <div style="margin-top: 10px" class="form-group">
                                <!-- Button -->
                                <div class="col-sm-12 ">
                                    <div class="row">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" CssClass="btn btn-primary"
                                            ValidationGroup="LoginUserValidationGroup" CommandArgument="Submit" OnClick="LoginButton_Click" />
                                        <asp:Button ID="ForgotPassword" runat="server" Text="Forgot Password" CssClass="btn btn-primary"
                                            CommandArgument="Submit" OnClick="LoginUser_ForgotPassword" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix">
                </div>
            </div>
            <div style="clear: both"></div>
            </div>
            <%-- <div class="col-md-12">
                <div class="login-main">
				    <div class="login">
					    <div class="login-top">
						    <img src="../../Images/login-mudra-icon.png">
					    </div>
					    <h1>Mudra Login</h1>
					    <div class="login-bottom">
					    <form>
						    <input type="text" placeholder="Username" required=" ">					
						    <input type="password" class="password" placeholder="Password" required=" ">						
						    <input type="submit" value="login">
					    </form>
					    <a href="#"><p>Forgot your password? Click Here</p></a>
					    </div>
				    </div>
			    </div>
            </div>--%>
        </asp:Panel>
    </LayoutTemplate>
</asp:Login>
<p>
    &nbsp;
</p>
<script type="text/javascript">
    $(document).ready(function () {
        Captcha();
    });
</script>
<script src="../../assets/bootstrap/js/tilt.jquery.min.js"></script>
<script>
    $('.js-tilt').tilt({
        scale: 1.1
    })
</script>

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
        document.getElementById("SitePH_ctrlLogin_LoginUser_txtCaptchAnswer").value = code;
        document.getElementById("SitePH_ctrlLogin_LoginUser_hdnCaptcha").value = code;
    }
</script>



