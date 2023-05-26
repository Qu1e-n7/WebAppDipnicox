<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebAppDipnicox.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <link href="Vista/Css/Cards.css" rel="stylesheet" />
    <link href="Vista/Css/CSSDipnicox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">
    <div class="inner-header flex">
        <div class="animated-word" >
            <div class="letter">D</div>
            <div class="letter">I</div>
            <div class="letter">P</div>
            <div class="letter">N</div>
            <div class="letter">I</div>
            <div class="letter">C</div>
            <div class="letter">O</div>
            <div class="letter">X</div>
        </div>
    </div>
    <div>
        <svg class="waves" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
            viewBox="0 24 150 28" preserveAspectRatio="none" shape-rendering="auto">
            <defs>
                <path id="gentle-wave" d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z" />
            </defs>
            <g class="parallax">
                <use xlink:href="#gentle-wave" x="48" y="0" fill="#031529" />
                <use xlink:href="#gentle-wave" x="48" y="3" fill="#051e3a" />
                <use xlink:href="#gentle-wave" x="48" y="5" fill="#07284e" />
                <use xlink:href="#gentle-wave" x="48" y="7" fill="#09305e" />
            </g>
        </svg>
    </div>
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
                                            <img src="Vista/Imagenes/Productos/TipoProd/<%# Eval("imagen") %>" class="tokenImage card-img-top" alt="nft">
                                            <h5 class="card-title" style="color: #AE87EC;"><%# Eval("Nombre") %> </h5>
                                            <p class="card-text" style="color: #a89ec9;"><%# Eval("Descripcion") %></p>
                                            <div class="card-body">
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
