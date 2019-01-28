<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LDM_MenuControl.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.LDM_MenuControl" %>
<%@ Register Src="SetCulture.ascx" TagName="SetCulture" TagPrefix="uc1" %>
<%@ Register src="LDM_Menu.ascx" tagname="LDMMenu" tagprefix="uc2" %>
<header class="topHeaderSection">
<div id="topLinks" class="topLinks" runat="server">
                <div id="defaultMenu" class="container">
                                            <!-- topLinks -->
                    <%--<form id="form1" runat="server">--%>
                        <ul class="other_links">
                            <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                                <AnonymousTemplate>
                                    <li>
                                        <asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_Click"></asp:Button></li>
                                </AnonymousTemplate>
                                <LoggedInTemplate>
                                    <li class="username">Welcome <span style="font-weight: bolder">
                                        <% Response.Write(HttpContext.Current.Profile.GetPropertyValue("firstName") == "" ? HttpContext.Current.Profile.UserName : HttpContext.Current.Profile.GetPropertyValue("firstName") + " " + HttpContext.Current.Profile.GetPropertyValue("lastName")); %>
                                    </span>! </li>
                                    <li>
                                            <%--  <asp:Button ID="btnlogout" runat="server" Text="Log Out" CssClass="btnResizer" OnClick="btnlogout_Click"></asp:Button>--%>
                                        <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Log Out" OnLoggedOut="HeadLoginStatus_LoggedOut" />
                                    </li>
                                    <li>
                                      <asp:LinkButton ID="lnk_changepassword" runat="server" OnClick="lnk_changepassword_Click">LinkButton</asp:LinkButton>
                                        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/App/Profiles/ChangePassword.aspx"></asp:HyperLink>--%></li>
                                    <%-- <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/App/Profiles/Profile.aspx"></asp:HyperLink></li>--%>
                                </LoggedInTemplate>
                            </asp:LoginView>
                            <li>
                                <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" CssClass="btnResizer" /></li>
                            <li>
                                <asp:Button ID="btnContactUs" runat="server" OnClick="btnContactUs_Click" CssClass="btnResizer" /></li>
                            <uc1:SetCulture ID="SetCulture1" runat="server" />
                        </ul>
                       
                                            <div class="searchBox">
                            <input type="text" name="search" id="searchTxtBox" value="Search here" class="searchBG"
                                onclick="this.value = ( this.value == this.defaultValue ) ? '' : this.value;return true;" />
                            <asp:Button ID="Search_btn" runat="server" class="searchBTN" />
                            <div class="clear">
                            </div>
                        </div>
<%--                         </form>--%>
                        
                        <!-- topLinks End -->
                   <div class="clear">
            </div>
            </div>
          
        </div>
    <div class="header">
        
     
           <div class="header-top">
           <div class="container">
                   <div class="row">
		<div class="col-md-2 maharashtra-logo">
            <a href="https://www.maharashtra.gov.in" target="_blank"><img src="../../Images/Seal_of_Maharashtra.png" alt=""></a>
		</div>
		<div class="col-md-8 mudra-yojna-logo">
			<img src="../../Images/mudralogo-4.png" alt="">			
		</div>
		<div class="col-md-2 enbI-logo"><img src="../../Images/enbI.png" alt=""></div>
           <div class="clear"> </div>
	</div>
        </div>
            </div>
         <uc2:LDMMenu ID="Menu11" runat="server" />
     
        
        <div>
            <asp:Label runat="server" ID="lblTitle" Text="" />
        </div>
    </div>
</header>