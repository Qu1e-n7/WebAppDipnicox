<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebAppDipnicox.Vista.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Vista/Css/Cards.css" rel="stylesheet" />
    <link href="Vista/Css/Carrito.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    <script src="https://www.paypal.com/sdk/js?client-id=AWh-o5lQO5QVXSj2EbM-WCe5hdhI_NlYNdSpw8ug6WGod8vn-FaX06E-IesnwfuL4Oel-eOrvrNZ1a3V"></script>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
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
                            <ul id="listaCarrito" style="background-color: blue; border-radius: 10px;">
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
                                            <img src="Imagenes/Productos/<%# Eval("Image") %>" class="tokenImage card-img-top" alt="nft">
                                            <h5 class="card-title" style="color: #AE87EC;"><%# Eval("Nombre") %> </h5>
                                            <p class="card-text" style="color: #a89ec9;"><%# Eval("Descripcion") %></p>
                                            <div class="card-body">
                                                <hr />
                                                <button class="btn-add-cart card-link ms-5 btn btn-primary p-2" onclick="AgregarVent('<%# Eval("idProducto")  %>');">Agregar al carrito</button>
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
                url: "Productos.aspx/mtdListarCarrito",
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
                                        <i class="uil uil-angle-left-b restar-cantidad"></i>
                                        <input type="text" value="1" class="carrito-item-cantidad" disabled>
                                            <i class="uil uil-angle-right sumar-cantidad"></i>
                                    </div>

                                    <span class="carrito-item-precio">${listProd[i].Total}</span>
                                </div>
                                <button class="ms-5 btn btn-$indigo-400 p-2" onclick="EliminarCarr(${listProd[i].idProductoVenta})">Eliminar</button>
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
                url: "Productos.aspx/mtdTotal",
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
                url: "Productos.aspx/mtdEliminarCarro",
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
        function AgregarVent(idPro) {
            $.ajax({
                type: "POST",
                url: "Productos.aspx/mtdAgregar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ idProd: idPro }),
                success: function (response) {
                    var data = response.d;
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
