<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllProducts.aspx.cs" Inherits="Admin_ViewAllProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 118px;
        }
        .auto-style3 {
            width: 221px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" >
        </asp:GridView>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Name:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Nametxt" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Brand:</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="BrandDDL" runat="server" DataSourceID="SqlDataSource1" DataTextField="Brand" DataValueField="Id">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Brand] FROM [Brand] ORDER BY [Brand]"></asp:SqlDataSource>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Type:</td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="TypeDDL" runat="server" DataSourceID="SqlDataSource2" DataTextField="Type" DataValueField="Id">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Type]"></asp:SqlDataSource>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Price:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Pricetxt" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Quantity:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Quantitytxt" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">Image:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Imagetxt" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" OnClick="BtnAdd_Click" Text="Add" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
            <br />
            <br />
            <br />
            <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" />
        <br />
        </div>
    </form>
</body>
</html>
