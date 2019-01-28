<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LDM_Menu.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.LDM_Menu" %>

<nav class="navbar-default">
    <div class="container">
        <div class="row">
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <%--Dashboard--%>
                    <li>
                        <asp:LinkButton ID="lnk_dashboard" runat="server" OnClick="lnk_dashboard_Click">Home</asp:LinkButton>
                    </li>
                    <%--LDMForm--%>
                    <li>
                        <asp:LinkButton ID="lnk_ldmfrm" runat="server" OnClick="lnk_ldmfrm_Click">LDM Form</asp:LinkButton>
                    </li>
                    <%--Reports--%>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Reports</a>
                        <ul class="dropdown-menu">
                            <%--<li>
                                <asp:LinkButton ID="lnk_statelvlrep" runat="server"
                                    OnClick="lnk_statelvlrep_Click">State Level Report</asp:LinkButton></li>--%>
                            <li>
                                <asp:LinkButton ID="lnk_distlvlrep" runat="server"
                                    OnClick="lnk_distlvlrep_Click">District Level Report</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk_bankwiserep" runat="server"
                                    OnClick="lnk_bankwiserep_Click">Bank wise Report</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk_SocialCategory" runat="server"
                                    OnClick="lnk_SocialCategory_Click">Category Wise Report</asp:LinkButton></li>
                        </ul>
                    </li>
                    <%--Useful Links--%>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Useful Links</a>
                        <ul class="dropdown-menu">
                            <li>
                                <%--<asp:LinkButton ID="lnk_SIDBI" runat="server"
                                    OnClick="lnk_SIDBI_Click">SIDBI</asp:LinkButton></li>--%>
                                <a href="https://sidbi.in/index.php" target="_blank">SIDBI</a>
                            <li>
                                <a href="https://www.standupmitra.in/" target="_blank">Stand up India</a>
                                <%--<asp:LinkButton ID="lnk_StandupIndia" runat="server"
                                    OnClick="lnk_StandupIndia_Click">Stand up India</asp:LinkButton></li>--%>
                            <li>
                                <a href="https://www.udyamimitra.in/" target="_blank">UdyamiMitra</a>
                                <%--<asp:LinkButton ID="lnk_UdyamiMitra" runat="server"
                                    OnClick="lnk_UdyamiMitra_Click">UdyamiMitra</asp:LinkButton></li>--%>
                        </ul>
                    </li>
                    <%--Best Performance--%>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Best Performance</a>
                        <ul class="dropdown-menu">
                            <li>
                                <asp:LinkButton ID="lnk_distperformance" runat="server"
                                    OnClick="lnk_distperformance_Click">Top 5 Best Performance District</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk_bankperformance" runat="server"
                                    OnClick="lnk_bankperformance_Click">Top 5 Best Performance Bank</asp:LinkButton></li>
                        </ul>
                    </li>

                </ul>
            </div>
        </div>
    </div>
</nav>
