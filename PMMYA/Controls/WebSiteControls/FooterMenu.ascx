<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterMenu.ascx.cs" Inherits="PMMYA.Controls.WebSiteControls.FooterMenu" %>
<%@ Register Src="~/Controls/WebSiteControls/LastReviewedDate.ascx" TagName="LastReviewedDate"
    TagPrefix="uc1" %>
<%@ Register Src="PlaceHolderControl.ascx" TagName="PlaceHolderControl" TagPrefix="uc4" %>
<%@ Register Src="VisitorCount.ascx" TagName="VisitorCount"
    TagPrefix="uc5" %>
<footer>

    <div class="agileinfo_copyright">
        <div class="container">
            <div class="row">
                <div class="col-md-8" style="margin-top: 15px; font-size: 11px">
                    <div class="footermenu1">
                        <div id="Footermenu1" runat="server"></div>
                        <asp:Label ID="lblDevelopedby" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="footer-content">
                        <a href="http://mahait.org/" target="_blank" class="mahaitcenter">
                            <img src="../../images/MahaIT_Trans.png" alt="MahaIT" class="mahaitlogos">
                            <div class="clear"></div>
                        </a>
                        <div class="clear"></div>
                    </div>
                </div>

                <div class="col-md-4" style="font-size: 11px">
                    <div class="row">
                        <p>
                            <uc5:VisitorCount ID="VisitorCount1" runat="server" />
                        </p>
                    </div>
                    <div class="row">
                        <div class="lastreviewdt pull-right">
                            <uc1:LastReviewedDate ID="LastReviewedDate1" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="clear"></div>
            </div>
        </div>
    </div>


    <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 0;"></span>To Topyle="opacity: 0;">0;"></span>To Top</a>

</footer>
