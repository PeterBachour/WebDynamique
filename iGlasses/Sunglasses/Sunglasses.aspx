<%@ Page Title="Sunglasses" Language="C#" MasterPageFile="~/Master/Base.master" AutoEventWireup="true" CodeFile="Sunglasses.aspx.cs" Inherits="Sunglasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="sunglasses.js"></script>
        <link rel="stylesheet" href="sunglasses.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Type] FROM [Type]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT p.* , b.* FROM Product p
join [Brand] b on p.Brand= b.id
where p.Type= 2
">
    
        </asp:SqlDataSource>
        <br />
        <div class="items">
            <div class="cards">
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">
            <ItemTemplate>
                      <div class="card">
                        <img src="http://s4c.cymru/temp/wave1.jpg">
                        <div class="card-title">
                          <a href="#" class="toggle-info btn">
                            <span class="left"></span>
                            <span class="right"></span>
                          </a>
                          <h2>
                              <%#Eval("Name")%>
                              <small><%#Eval("Brand1")%></small>
                          </h2>
                        </div>
                        <div class="card-flap flap1">
                          <div class="card-description">
                            This grid is an attempt to make something nice that works on touch devices. Ignoring hover states when they're not available etc.
                          </div>
                          <div class="card-flap flap2">
                            <div class="card-actions">
                              <a href="#" class="btn">Read more</a>
                            </div>
                          </div>
                        </div>
                      </div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
        </div>
    </form>
</asp:Content>

