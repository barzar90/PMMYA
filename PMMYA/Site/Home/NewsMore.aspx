<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/WebSiteMasters/Site.Master" AutoEventWireup="true" CodeBehind="NewsMore.aspx.cs" Inherits="PMMYA.Site.Home.NewsMore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" language="javascript">
    function forgetEnterKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 13) && ((node.type == "text") ||
          (node.type == "password"))) {
            return false;
        }
    }
    document.onkeypress = forgetEnterKey; 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CustomForms" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SitePH" runat="server">
    <h1><asp:Label ID="lblNews" runat="server" Text="Label"></asp:Label></h1>
<br />
<div class="clear"></div>
<ul class="list-group">
  <li class="list-group-item"> <asp:Label ID="lblSearch" Text="Enter A KeyWord To Search : " runat="server" AssociatedControlID="txtSearch"></asp:Label>
      <div class="col-md-8 col-sm-8">
  
      <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server">
        </asp:TextBox>
     </div>
         <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-warning" />

        &nbsp;&nbsp;

        <asp:Button ID="btnReset" runat="server" Text="Reset"  class="btn btn-success" OnClick="btnReset_Click" /></li>

</ul>

 

<div class="table-responsive">
    <asp:UpdatePanel ID="upNews" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed table-striped"
                ShowFooter="True" OnPageIndexChanging="gvNews_PageIndexChanging" AllowPaging="true" PageSize="10">
                <Columns>
                    <asp:TemplateField HeaderText="क्रमांक" HeaderStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="बातम्या" SortExpression="News" HeaderStyle-Width="70%">
                        <ItemTemplate>
                            <asp:Label ID="lblNews" runat="server" Text='<%# string.Format("{0}", System.Threading.Thread.CurrentThread.CurrentCulture.ToString().ToLower().Equals("mr-in") ? Eval("News_LL").ToString() : Eval("News").ToString()) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="तारीख" SortExpression="Date" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%#  Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="डाउनलोड" SortExpression="URL" HeaderStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblDownload" runat="server" Text="">
                                <a class='align-center' href='<%# Eval("URL") %>' target="_blank"><img id="img1" src="../../Images/pdf.png" alt="PDF" title="Download PDF"/></a>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
