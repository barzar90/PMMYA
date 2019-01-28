<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu1.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.Menu1" %>
<nav class="navbar-default">
    <div class="container">
        <div class="row">
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li>
                        <asp:LinkButton ID="lnk_cmshome" runat="server" OnClick="lnk_cmshome_Click">CMS Home</asp:LinkButton></li>
                    <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Upload All Albums</a>
                        <ul class="dropdown-menu">

                            <li>
                                <asp:LinkButton ID="lnk_createalbum" runat="server"
                                    OnClick="lnk_createalbum_Click">Create Album for Photo</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk_updateulbum" runat="server"
                                    OnClick="lnk_updateulbum_Click">Update Album</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk_updatesubalbum" runat="server"
                                    OnClick="lnk_updatesubalbum_Click">Update SubAlbum</asp:LinkButton></li>
                      <%--      <li>
                                <asp:LinkButton ID="lnk_createalbumforpressnews" runat="server"
                                    OnClick="lnk_createalbumforpressnews_Click">Create Album For Press News</asp:LinkButton></li>--%>

                        </ul>
                    </li>

                 <li>
                        <asp:LinkButton ID="lnk_uploadvideo" runat="server"
                            OnClick="lnk_uploadvideo_Click">Upload Video</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="lnk_uploadfile" runat="server"
                            OnClick="lnk_uploadfile_Click">Upload Banner/Key Person</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="lnk_uploadnews" runat="server"
                            OnClick="lnk_uploadnews_Click">Upload News</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton ID="lnk_audittrail" runat="server"
                            OnClick="lnk_audittrail_Click">Audit Trail</asp:LinkButton></li>

                    <li>
                        <asp:LinkButton ID="lnk_ViewComplaint" runat="server" OnClick="lnk_ViewComplaint_Click"
                            >View Complaint</asp:LinkButton></li>

                </ul>
            </div>
        </div>
    </div>
</nav>


