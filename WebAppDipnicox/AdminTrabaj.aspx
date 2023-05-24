<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="AdminTrabaj.aspx.cs" Inherits="WebAppDipnicox.AdminTrabaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <link href="Vista/Css/Cards.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Bienvenido Trabajador</h2>

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
                                            <img src="Vista/Imagenes/Productos/TipoProd/" class="tokenImage card-img-top" alt="nft">
                                            <h5 class="card-title" style="color: #AE87EC;"><%# Eval("Nombre") %> </h5>
                                            <p class="card-body" style="color: #a89ec9;"><%# Eval("Descripcion") %></p>
                                            <p class="card-text" style="color: #a89ec9;"><%# Eval("Valor") %> </p>
                                            <div class="card-body" >
                                                <hr />
                                                <a href="#" class="card-link ms-5 btn btn-primary p-2">Productos</a>
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
