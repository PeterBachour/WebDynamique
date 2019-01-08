<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Base.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Product] p 
join Brand b on p.Brand = b.Id
WHERE (p.[Id] = @Id)">
            <SelectParameters>
                <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id,Id1" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <asp:Image float="left" draggable="false" ID="ImageLabel" runat="server" ImageUrl='<%# Bind("Image") %>' />
                <div style="float:right">
                    <center>
                        <h2>
                            <asp:Label  ID="NameLabel" runat="server" Text='<%# Bind("Name") %>' />
                        </h2>
                        <h4>
                            $<asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>' />
                        </h4>
                        <asp:Label ID="QuantityLabel" runat="server" Text='<%# Bind("Quantity") %>' />
                        <asp:Label ID="Brand1Label" runat="server" Text='<%# Bind("Brand1") %>' />
                    </center>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </form>
</asp:Content>