<%@ Page Title="Register" Language="C#" MasterPageFile="~/Master/Base.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
            <asp:Label runat="server" Text='Username'></asp:Label>
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text='Email'></asp:Label>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server" Text='Password'></asp:Label>
            <input type="password" id="Password" runat="server" minlength="8" required>
            <br />
            <asp:Label runat="server" Text='Confirm Password'></asp:Label>
            <input type="password" id="checkPassword" runat="server" minlength="8" required>
            <br />
            <asp:Button ID="SignUp" runat="server" Text="Sign Up" OnClick="SignUp_Click" />
    </form>
</asp:Content>