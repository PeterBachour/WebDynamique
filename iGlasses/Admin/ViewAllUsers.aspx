<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllUsers.aspx.cs" Inherits="Admin_ViewAllUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <br />
        <br />
        UserName : <asp:TextBox ID="txtDname" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Grant Admin Role" />
&nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Revoke Admin Role" />
        <br />
        <br />
       
      </form>
</body>
</html>
