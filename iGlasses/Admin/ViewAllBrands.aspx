<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllBrands.aspx.cs" Inherits="Admin_ViewAllBrands" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 205px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Add a Brand</p>
        <p>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Brand Name</td>
                    <td>
                        <asp:TextBox ID="NewBrand" runat="server"></asp:TextBox>
&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style2">Brand Image</td>
                    <td>
                        <asp:TextBox ID="NewBrandImage" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </p>
        <p>
            <asp:Button ID="AddBrand" runat="server" OnClick="AddBrand_Click" Text="Add New Brand" />
        </p>
        <p>
            <asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" />
        </p>
    </form>
</body>
</html>
