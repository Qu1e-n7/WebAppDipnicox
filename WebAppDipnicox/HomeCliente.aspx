<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="HomeCliente.aspx.cs" Inherits="WebAppDipnicox.HomeCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <link href="Vista/Css/Carrito.css" rel="stylesheet" />
    <link href="Vista/Css/Cards1.css" rel="stylesheet" />
    <link href="Vista/Css/CSSDipnicox.css" rel="stylesheet" />
    <link href="Vista/Css/Inicio.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    <script src="https://www.paypal.com/sdk/js?client-id=AWh-o5lQO5QVXSj2EbM-WCe5hdhI_NlYNdSpw8ug6WGod8vn-FaX06E-IesnwfuL4Oel-eOrvrNZ1a3V"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="header-section container">
            <div>
                <img onclick="showCart()" class="cart" src="Vista/Imagenes/anadir-a-la-cesta.png" alt="">
                <asp:Label ID="lblcontador" class="count-product" runat="server" Text="0"></asp:Label>
                <%--<p id="contador"  runat="server" >0</p>--%>
            </div>
            <div class="cart-products" id="products-id">

                <div class="card-item">
                    <!-- Carrito de compras -->
                    <div class="carrito">
                        <div class="header-carrito">
                            <h2>Carrito de Compras</h2>
                        </div>
                        <p class="close-btn" onclick="closeBtn()">X</p>

                        <div id="carComp" class="carrito-items">
                            <ul id="listaCarrito" style="background-color: #386eb3; border-radius: 10px;">
                            </ul>
                        </div>
                        <%--Pago--%>
                        <div class="carrito-total">
                            <div class="fila">
                                <h2>Total A Pagar</h2>
                                <asp:Label ID="lblcontPrecio" ClientIDMode="Static" CssClass="price-total" runat="server"></asp:Label>
                                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                                <asp:DropDownList ID="ddlTipoVenta" runat="server" onchange="mostrarElemento()"></asp:DropDownList>
                                <asp:Button ID="btnPagar" runat="server" Text="Pagar" Style="display: none;" OnClick="btnPagar_Click" />
                                <div id="panelContenedor" style="display: none;">
                                    <section>
                                        <div id="paypal-button-container"></div>

                                        <div id="successMessage" style="display: none;">
                                            !Pago Exitoso! El Pago Ha Sido Realizado Con Exito.
                                        </div>

                                        <div id="cancelMessage" style="display: none;">
                                            ¡Pago Cancelado! El Pago Ha Sido Cancelado.
                                        </div>

                                    </section>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </header>

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
    <script>
        $(document).ready(function () {
            ListarCarro();
        })
        function showCart() {
            document.getElementById("products-id").style.display = "block";
        }
        function closeBtn() {
            document.getElementById("products-id").style.display = "none";
        }

        function ListarCarro() {
            $.ajax({
                type: "POST",
                url: "HomeCliente.aspx/mtdListarCarrito",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var listProd = response.d;
                    var rptDatos = '';
                    var ListaCarr = document.getElementById('listaCarrito');
                    var TotalPagar = 0;
                    for (var i = 0; i < listProd.length; i++) {
                        rptDatos += `<li>
                        <div class="carrito-item">
                            <img src="#" width="80px" alt="">
                                <div class="carrito-item-detalles">
                                    <span class="carrito-item-titulo">${listProd[i].Nombre}</span>
                                    <div class="selector-cantidad">
                                        <i class="bi bi-caret-left-fill" onclick="RestarCarr(this)"></i>
                                        <input type="text" value="${listProd[i].Cantidad}" class="carrito-item-cantidad" disabled>
                                            <i class="bi bi-caret-right-fill" onclick="SumarCarr(this)""></i>
                                    </div>

                                    <span class="carrito-item-precio">${listProd[i].Total}</span>
                                </div>
                                <button class="ms-5 btn btn-indigo-400 p-2" onclick="EliminarCarr(${listProd[i].idProductoVenta})">Eliminar</button>
                        </div>
                        <li>`;
                        TotalPagar = TotalPagar + listProd[i].Total;
                    }
                    ListaCarr.innerHTML = rptDatos;
                    actualizarContador(listProd.length);
                    TotalPgar(TotalPagar);
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJvar rptListCarrito = document.getElementById('rptListCarrito');
                    console.error('mal todo');
                }
            });
        }

        function TotalPgar(TotalP) {
            var lblTotal = document.getElementById("<%= lblcontPrecio.ClientID %>");
            $.ajax({
                type: "POST",
                url: "HomeCliente.aspx/mtdTotal",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ total: TotalP }),
                success: function (response) {
                    lblTotal.textContent = TotalP;
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJvar rptListCarrito = document.getElementById('rptListCarrito');
                    console.error(errorThrown);
                }
            });
        }
        function EliminarCarr(idProVent) {
            $.ajax({
                type: "POST",
                url: "HomeCliente.aspx/mtdEliminarCarro",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ idProVen: idProVent }),
                success: function (response) {
                    var datos = response.d;
                    ListarCarro();

                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJvar rptListCarrito = document.getElementById('rptListCarrito');
                    console.error(errorThrown);
                }
            });
        }
        function actualizarContador(contador) {
            var contadorElement = document.getElementById("<%= lblcontador.ClientID %>");
            contadorElement.textContent = contador;
        }
        function ocultarCarrito() {
            var carrito = document.getElementById('carrito');
            carrito.style.display = 'none';
        }
        function mostrarElemento() {
            var dropdownList = document.getElementById("<%= ddlTipoVenta.ClientID %>");
            var opcionSeleccionada = dropdownList.options[dropdownList.selectedIndex].value;
            var contenedor = document.getElementById("panelContenedor");
            var boton = document.getElementById("<%= btnPagar.ClientID %>");

            if (opcionSeleccionada === "1") {
                contenedor.style.display = "block";
                boton.style.display = "none";
            } else if (opcionSeleccionada === "2") {
                contenedor.style.display = "none";
                boton.style.display = "block";
            } else {
                contenedor.style.display = "none";
                boton.style.display = "none";
            }
        }

        var btnPagar = document.getElementById('<%= btnPagar.ClientID %>');
        paypal.Buttons({
            style: {
                color: 'blue',
                shape: 'pill',
                label: 'pay'
            },
            createOrder: function (data, actions) {
                var total = document.getElementById('<%= lblcontPrecio.ClientID %>').textContent;
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: total
                        }
                    }]
                });
            },
            onApprove: function (data, actions) {
                btnPagar.click();
                return actions.order.capture().then(function (details) {
                    document.getElementById('paymentDetails').textContent = JSON.stringify(details, null, 2);
                    document.getElementById('nameField').textContent = details.payer.name.given_name + ' ' + details.payer.name.surname;
                    document.getElementById('emailField').textContent = details.payer.email.address;
                    document.getElementById('paymentTable').style.display = 'table';
                    document.getElementById('successMessage').style.display = 'block';

                    console.log(details);
                });
            },
            onCancel: function (data) {
                swal("!Pago Cancelado!", "El Pago Ha Sido Cancelado.", "error");
                document.getElementById('cancelMessage').style.display = 'block';
                console.log(data);
            }
        }).render('#paypal-button-container');

    </script>
</asp:Content>
