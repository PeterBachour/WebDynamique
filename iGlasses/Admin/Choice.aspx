﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Choice.aspx.cs" Inherits="Admin_Chooice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Check All Users" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Check All Products" />
        </div>
    </form>
</body>
</html>
