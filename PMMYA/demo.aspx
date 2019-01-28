<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demo.aspx.cs" Inherits="PMMYA.demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductOrderID"
                OnRowCancelingEdit="gvProducts_RowCancelingEdit"
                OnRowEditing="gvProducts_RowEditing"
                OnRowUpdating="gvProducts_RowUpdating"
                OnRowDataBound="gvProducts_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ProductOrderID" ReadOnly="true" />
                    <asp:TemplateField HeaderText="Make">
                        <ItemTemplate>
                            <asp:Label ID="lblMake" runat="server" Text='<%# Bind("Make") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlProductMake" runat="server"
                                OnSelectedIndexChanged="ddlProductMake_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Model">
                        <ItemTemplate>
                            <asp:Label ID="lblModel" runat="server" Text='<%# Bind("Model") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlProductModel" runat="server"
                                OnSelectedIndexChanged="ddlProductModel_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" DataFormatString="{0:c}" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
