<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllProducts.aspx.cs" Inherits="Admin_ViewAllProducts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" >
        </asp:GridView>
        <br />
        </div>
    </form>
</body>
</html>
