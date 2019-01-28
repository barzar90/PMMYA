<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderMain.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.HeaderMain" %>
<%@ Register Src="SetCulture.ascx" TagName="SetCulture" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/WebSiteControls/HeaderMenu.ascx" TagName="HeaderMenu"
    TagPrefix="uc1" %>
<%@ Register Assembly="TextBoxServerControl" Namespace="TextBoxServerControl" TagPrefix="asp" %>
<header class="topHeaderSection">
    <div id="topLinks" class="topLinks top-links-shadow" runat="server">
        <div class="container ">
        <ul class="other_links">
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        <li class="m_hide">
                            <asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_Click" CssClass="btnResizer">
                            </asp:Button></li>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <li>Welcome <span style="font-weight: bolder">
                            <% Response.Write(HttpContext.Current.Profile.GetPropertyValue("firstName") == "" ? HttpContext.Current.Profile.UserName : HttpContext.Current.Profile.GetPropertyValue("firstName") + " " + HttpContext.Current.Profile.GetPropertyValue("lastName")); %>
                        </span>! </li>
                        <li>
             
                            <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                               LogoutPageUrl="~/" />
                        </li>                   
                    </LoggedInTemplate>
                </asp:LoginView>
              
                <li class="m_hide"><a href="#Navigation">
                    <asp:Label ID="lbl_skipToNav" runat="server" Text=""></asp:Label></a></li>
                <li class="m_hide"><a href="#Content">
                    <asp:Label ID="lbl_skipToContent" runat="server" Text=""></asp:Label></a></li>
                <uc1:SetCulture ID="SetCulture1" runat="server" />
                
            </ul>
            <div class="searchBox">
                <label id="lblSearchBTN" runat="server" class="btnDisplay" for='HeaderMain1_searchTxtBox'>
                    Search</label>
                <asp:TextBoxControl ID="searchTxtBox" runat="server" TypingMode="CDAC"  class="searchBG"
                    autocomplete="off" onclick="this.value = ( this.value == this.defaultValue ) ? '' : this.value;return true;"
                    DestinationLanguage="ENGLISH"></asp:TextBoxControl>
                <asp:Button ID="Search_btn" runat="server" class="searchBTN" OnClick="Search_btn_Click"
                    CausesValidation="false" />
                <div class="clear">
                </div>
            </div>
            
            
            <div class="clear">
            </div>
        </div>
    </div>


    <div class="header1">
 

        <div class="container">
	

      <div class="row">
		<div class="col-md-2 col-sm-3 col-xs-3 maharashtra-logo">
            <a href="https://www.maharashtra.gov.in" target="_blank"><img src="../../Images/Seal_of_Maharashtra.png" alt="Seal of Maharashtra"></a>
		</div>
		<div class="col-md-8 col-sm-6 col-xs-6 mudra-yojna-logo">
			<a href="https://mahamudra.maharashtra.gov.in"><img src="../../Images/mudralogo-4.png" alt="Mudra Logo"></a>			
		</div>
		<div class="col-md-2 col-sm-3 col-xs-3 enbI-logo">
            <a href="https://www.india.gov.in/" target="_blank"><img src="../../Images/enbI.png" alt="Emblem of India"></a>
		</div>
           <div class="clear"> </div>
	</div>
</div>
         <a class="btnDisplay" href="#" id="Navigation">
                    <asp:Label ID="lbl_navigation" runat="server" Text="Label"></asp:Label></a>
         <uc1:HeaderMenu ID="menu" runat="server" />
    </div>
</header>
<a class="btnDisplay" href="#" id="Content">
    <asp:Label ID="lbl_contents" runat="server" Text="Label"></asp:Label></a> 

<script type="text/javascript">
$("input").keypress(function (evt) {
                //Deterime where our character code is coming from within the event
                var charCode = evt.charCode || evt.keyCode;
                if (charCode == 13) { //Enter key's keycode
                    return false;
                }
            });
</script>