<%@ Page Title="Register" Language="C#" MasterPageFile="~/Master/Base.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">


            <table class="w-25">
                <tr>
                    <td> <asp:Label runat="server" Text='Username'></asp:Label></td>
                    <td> <asp:TextBox ID="Username" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text='Email'></asp:Label></td>
                    <td> <asp:TextBox ID="Email" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" Text='Password'></asp:Label></td>
                    <td><input type="password" id="Password" runat="server" minlength="8" required></td>
                </tr>
                <tr>
                    <td> <asp:Label runat="server" Text='Confirm Password'></asp:Label></td>
                    <td> <input type="password" id="checkPassword" runat="server" minlength="8" required></td>
                </tr>
            </table>
            <asp:Button ID="SignUp" runat="server" Text="Sign Up" OnClick="SignUp_Click" />
    </form>
</asp:Content>