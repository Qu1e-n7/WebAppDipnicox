<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebAppDipnicox.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <link href="Vista/Css/Cards1.css" rel="stylesheet" />
    <link href="Vista/Css/CSSDipnicox.css" rel="stylesheet" />
    <link href="Vista/Css/Inicio.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="header">
        <div class="inner-header flex">
            <div class="animated-word">
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
        <div>
            <div id="about" class="about">
                <div class="container">
                    <div class="row">
                        <div class="col-md-5">
                            <div class="titlepage">
                                <h2>Sobre <span class="green">Nosotros</span></h2>
                                <p>Somos una empresa dedicada a brindar soluciones en cámaras de seguridad y servicio técnico. Con años de experiencia en el mercado, nos enorgullece 
                                    ofrecer productos y servicios de alta calidad para garantizar la seguridad de nuestros clientes.
                                    
                                    Nuestro equipo de profesionales altamente capacitados está comprometido en proporcionar las mejores soluciones y asesoramiento personalizado para
                                    satisfacer las necesidades únicas de cada cliente. Ya sea para la instalación de sistemas de cámaras de seguridad o para la reparación y mantenimiento 
                                    de equipos, estamos aquí para ayudarte.
                                    En Dipnicox, nos esforzamos por superar las expectativas de nuestros clientes y brindar un servicio excepcional.</p>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <div class="about_img">
                                <figure>
                                    <img src="Vista/Imagenes/camara.PNG" alt="#" style="opacity: 0.7;" />
                                </figure>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <svg class="waves" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"
                        viewBox="0 24 150 28" preserveAspectRatio="none" shape-rendering="auto">
                        <defs>
                            <path id="gentle-wave1" d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z" />
                        </defs>
                        <g class="parallax">
                            <use xlink:href="#gentle-wave" x="48" y="0" fill="#031529" />
                            <use xlink:href="#gentle-wave" x="48" y="3" fill="#051e3a" />
                            <use xlink:href="#gentle-wave" x="48" y="5" fill="#09304e" />
                            <use xlink:href="#gentle-wave" x="48" y="7" fill="#07284e" />
                        </g>
                    </svg>
                </div>
                <!-- product section -->
                <section class="product_section layout_padding" style="background: #07284e;">
                    <div class="d-flex justify-content-center">
                        <h2 class="custom_heading">Nuestros Productos
                        </h2>
                    </div>
                    <div class="container layout_padding2">
                        <div class="CardCatego" style="background: #07284e;">
                            <div class="container">
                                <div class="row">
                                    <asp:Repeater ID="repcard" runat="server">
                                        <ItemTemplate>
                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card bg-transparent border-0">
                                                    <div class="card-body">
                                                        <div class="nft">
                                                            <div class="img-box box-1">
                                                                <div class="main">
                                                                    <img src="Vista/Imagenes/Productos/TipoProd/<%# Eval("imagen") %>" class="tokenImage card-img-top" alt="nft">
                                                                    <h5 class="card-title" style="color: #AE87EC;"><%# Eval("Nombre") %> </h5>
                                                                    <p class="card-text" style="color: #a89ec9;"><%# Eval("Descripcion") %></p>
                                                                    <div class="card-body">
                                                                        <hr />
                                                                        <asp:Button ID="btnProductos" CssClass="ard-link ms-5 btn btn-primary p-2" runat="server" Text="Ver Productos" OnClick="btnProductos_Click" CommandArgument='<%# Eval("idTipoProduc") %>' />
                                                                        <%--<a href="#" class="card-link ms-5 btn btn-primary p-2">Productos</a>--%>
                                                                    </div>
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
                    </div>
                </section>
                <!-- end product section -->
            </div>
        </div>
    </div>

</asp:Content>
