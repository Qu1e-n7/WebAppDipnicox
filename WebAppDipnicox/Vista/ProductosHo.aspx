<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ProductosHo.aspx.cs" Inherits="WebAppDipnicox.Vista.ProductosHo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/Cards1.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <asp:Label ID="lblProductos" runat="server" Text="Productos"></asp:Label>
    </div>
    <div class="CardCatego">
        <div class="container">
            <div class="row">
                <asp:Repeater ID="repcard" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="card bg-transparent border-0">
                                <div class="card-body">
                                    <div class="nft">
                                        <div class="main">
                                            <img src="../Vista/Imagenes/Productos/<%# Eval("Image") %>" class="tokenImage card-img-top" alt="nft">
                                            <h5 class="card-title" style="color: #AE87EC;"><%# Eval("Nombre") %> </h5>
                                            <p class="card-text" style="color: #a89ec9;"><%# Eval("Descripcion") %></p>
                                            <div class="card-body">
                                                <hr />
                                                <asp:Button ID="btnAgregar" CssClass="btn-add-cart card-link ms-5 btn btn-primary p-2" runat="server" OnClick="btnAgregar_Click" Text="Agregar Carrito" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
