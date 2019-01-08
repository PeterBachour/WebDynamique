<%@ Page Title="Eyeglasses" Language="C#" MasterPageFile="~/Master/Base.master" AutoEventWireup="true" CodeFile="Eyeglasses.aspx.cs" Inherits="Eyeglasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="eyeglasses.js"></script>
    <script src="filter.js"></script>
    <link rel="stylesheet" href="filter.css">
    <link rel="stylesheet" href="eyeglasses.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [Brand], [Id] FROM [Brand]"></asp:SqlDataSource>
        <div id="div-container">
            <div class="wrapper">
                <ul>
                    <li>
                        <input type="checkbox" id="list-item-1">
                        <label class="list-group-item first active" style="background-color:darkgrey" for="list-item-1">Brand</label>
                        <ul>
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                                DataTextField="Brand" DataValueField="Id" OnSelectedIndexChanged="Country_Selected">
                            </asp:CheckBoxList>
                        </ul>
                    </li>
                    <li>
                        <input type="checkbox" id="list-item-2">
                        <label class="list-group-item" style="background-color:darkgrey" for="list-item-2">Price</label>
                        <ul>
                            <asp:FormView ID="FormView1" runat="server">
                                <ItemTemplate>
                                    <span class="multi-range">
                                        <input id="lower" type="range" min="<%#DataBinder.Eval(Container.DataItem,"min")%>"
                                        max="<%#DataBinder.Eval(Container.DataItem," max")%>"
                                        value="<%#DataBinder.Eval(Container.DataItem,"min")%>">
                                        <input id="upper" type="range" min="<%#DataBinder.Eval(Container.DataItem,"min")%>"
                                        max="<%#DataBinder.Eval(Container.DataItem,"max")%>"
                                        value="<%#DataBinder.Eval(Container.DataItem,"max")%>">
                                    </span>
                                    <br />
                                    <br />
                                    from: $<asp:Label  ClientIDMode="Static" ID="lower_tb" runat="server" Text='<%#Bind("min")%>'></asp:Label>
                                    <br />
                                    to: $<asp:Label  ClientIDMode="Static" ID="upper_tb" runat="server" Text='<%#Bind("max")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:FormView>
                        </ul>
                    </li>
                </ul>
            </div>
            <div class="cards">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <img draggable="false" src="<%# DataBinder.Eval(Container.DataItem," Image") %> ">
                            <div class="card-title">
                                <a class="toggle-info btn">
                                    <span class="left"></span>
                                    <span class="right"></span>
                                </a>
                                <h2>
                                    <%# DataBinder.Eval(Container.DataItem,"Name") %>
                                    <small>
                                        <%# DataBinder.Eval(Container.DataItem,"Brand1") %> &nbsp; &nbsp; &nbsp; &nbsp;
                                        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                        <%# DataBinder.Eval(Container.DataItem,"Price") %>$
                                    </small>
                                </h2>
                            </div>
                            <div class="card-flap flap1">
                                <div class="card-flap flap2">
                                    <div class="card-actions">
                                        <button onclick='window.location.href = "<%#String.Format("../Product.aspx?id={0}", DataBinder.Eval(Container.DataItem,"Id")) %>"'
                                            class="btn">Buy now</button>
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