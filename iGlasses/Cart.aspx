<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Master/Base.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div>
                <asp:Image float="left" Width="200" Height="200" draggable="false" ID="ImageLabel" runat="server" ImageUrl='<%# Bind("Image") %>' />
                <div >
                   
                        <h2>
                            <asp:Label  ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                        </h2>
                        <h4>
                            $<asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>' />
                        </h4>
                        Remaining: <asp:Label ID="QuantityLabel" runat="server" Text='<%# Bind("Quantity") %>' />
                 
                </div>
                        </div>
            </ItemTemplate>
        </asp:Repeater>
                    <input type="button" value="Buy Now"
                        onclick="myFunction('<%#Eval("Name")%>')"/>
                    <script>
function myFunction(name) {
    alert("You are going to buy these products: " + name);
s}
</script>

    </form>
</asp:Content>