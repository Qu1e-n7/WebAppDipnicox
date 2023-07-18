<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="AdminTrabaj.aspx.cs" Inherits="WebAppDipnicox.AdminTrabaj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <link href="Vista/Css/Cards.css" rel="stylesheet" />
    <link href="Vista/Css/Buscar.css" rel="stylesheet" />
    <link href="Vista/Css/Carrito.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js"></script>
    <script
        src="https://www.paypal.com/sdk/js?client-id=AWh-o5lQO5QVXSj2EbM-WCe5hdhI_NlYNdSpw8ug6WGod8vn-FaX06E-IesnwfuL4Oel-eOrvrNZ1a3V"></script>

    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v2.1.9/css/unicons.css" />
    <script src="Vista/JavaScript/app.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="CardCatego">
        <header>
            <div class="header-section container">

                <div>
                    <img onclick="showCart(this)" class="cart" src="Vista/Imagenes/anadir-a-la-cesta.png" alt="">
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
                                    <asp:Label ID="lblcontPrecio" CssClass="price-total" data-count="0" runat="server" Text="Total A Pagar"></asp:Label>
                                    <%--<strong id="contadorPrecio" class="price-total" runat="server">0</strong></h2>--%>

                                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                                    <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>--%>
                                    <asp:DropDownList ID="ddlTipoVenta" runat="server" OnSelectedIndexChanged="ddlTipoVenta_SelectedIndexChanged" onchange="mostrarElemento()"></asp:DropDownList>

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
                                    <%--</ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlTipoVenta" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>--%>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
        </header>
        <h2>Bienvenido Trabajador</h2>
        <br />


        <div class="wrapper">
            <asp:TextBox ID="txtBuscar" CssClass="busca" placeholder="Digite para buscar..." runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" CssClass="buscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
        <br />



        <div class="container">

            <div class="products">
                <div class="row">
                    <asp:Repeater ID="repcard" runat="server" OnItemDataBound="repcard_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6 col-sm-12">
                                <div class="card bg-transparent border-0">
                                    <div class="card-body">
                                        <div class="nft">
                                            <div class="main">
                                                <img src="#" class="img-item tokenImage card-img-top" alt="nft">
                                                <h3 class="titulo-item" style="color: #AE87EC;"><%# Eval("Nombre") %> </h3>
                                                <p class="card-body" style="color: #a89ec9;"><%# Eval("Descripcion") %></p>
                                                <p class="precio-item" style="color: #a89ec9;"><%# Eval("Valor") %> </p>

                                                <div class="card-body">
                                                    <hr />
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="idProducto" runat="server" Text='<%# Eval("idProducto")  %>' Visible="false"></asp:Label></h5>
                                                       <%--<a href="#" data-id="<%# Eval("idProducto")  %>" class="btn-add-cart card-link ms-5 btn btn-primary p-2">Agregar al Carrito</a>--%>

                                                            <button class="btn-add-cart card-link ms-5 btn btn-primary p-2" onclick="agregarAlCarrito('<%# Eval("idProducto")  %>');">Agregar al carrito</button>
                                                            <%--<asp:Button data-id="<%# Eval("idProducto")  %>" ID="btnAgregar" CssClass="btn-add-cart card-link ms-5 btn btn-primary p-2" runat="server" Text="Agregar al Carrito" OnClick="btnAgregar_Click" />--%>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
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

    <script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "AdminTrabaj.aspx/mtdListProdVen",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = response.d;
                    ListCarr(data);
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJvar rptListCarrito = document.getElementById('rptListCarrito');
                    console.error(errorThrown);
                }
            });
        })
        function showCart(x) {
            document.getElementById("products-id").style.display = "block";
        }
        function closeBtn() {
            document.getElementById("products-id").style.display = "none";
        }

    </script>

    <script>
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
    </script>

    <script>


        // Variables globales
        var total = 0;
        var contador = 0;

        // Función para agregar un producto al carrito
        function agregarAlCarrito(idProd) {
            AgregarVent(idProd)
            // Actualizar contador y total
            total += precio;
            actualizarContadorPrecio();
        }

        function AgregarVent(idPro) {
            $.ajax({
                type: "POST",
                url: "AdminTrabaj.aspx/mtdAgregar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ idProd: idPro }),
                success: function (response) {
                    var data = response.d;
                    ListCarr(data);
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJvar rptListCarrito = document.getElementById('rptListCarrito');
                    console.error(errorThrown);
                }
            });
        }

        function ListCarr(data) {
            var rptDatos = '';
            var ListaCarr = document.getElementById('listaCarrito');
            console.log(ListaCarr);
            var TotalPagar = 0;
            var lblTotal = document.getElementById("<%= lblcontPrecio.ClientID %>");
            for (var i = 0; i < data.length; i++) {
                rptDatos += `<li>
                        <div class="carrito-item">
                            <img src="#" width="80px" alt="">
                                <div class="carrito-item-detalles">
                                    <span class="carrito-item-titulo">${data[i].Nombre}</span>
                                    <div class="selector-cantidad">
                                        <i class="uil uil-angle-left-b restar-cantidad"></i>
                                        <input type="text" value="1" class="carrito-item-cantidad" disabled>
                                            <i class="uil uil-angle-right sumar-cantidad"></i>
                                    </div>

                                    <span class="carrito-item-precio">${data[i].Total}</span>
                                </div>
                                <button class="ms-5 btn btn-$indigo-400 p-2" onclick="EliminarCarr(${data[i].idProductoVenta});">Eliminar</button>
                        </div>
                        <li>`;
                TotalPagar = TotalPagar + data[i].Total;
            }
            ListaCarr.innerHTML = rptDatos;
            actualizarContador(data.length);
            lblTotal.textContent = TotalPagar;
        }
        function EliminarCarr(idProVent) {
            $.ajax({
                type: "POST",
                url: "AdminTrabaj.aspx/mtdEliminarCarro",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ idProVen: idProVent }),
                success: function (response) {
                    var datos = response.d;
                    if (datos=!null) {
                        alert('se elimino');
                    }
                    
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJvar rptListCarrito = document.getElementById('rptListCarrito');
                    console.error(errorThrown);
                }
            });
        }

        // Función para actualizar el contador
        function actualizarContador(contador) {
            var contadorElement = document.getElementById("<%= lblcontador.ClientID %>");
            contadorElement.textContent = contador;
        }
        function actualizarContadorPrecio() {
            var contadorPrecioElement = document.getElementById('contadorPrecio');
            contadorPrecioElement.innerHTML = total;
        }
        // Función para mostrar el total
        function mostrarTotal() {
            var totalElement = document.getElementById('total');
            totalElement.innerHTML = total;
        }
        function ocultarCarrito() {
            var carrito = document.getElementById('carrito');
            carrito.style.display = 'none';
        }


        //function listar(elementoA) {
        //    var valor = elementoA.previousElementSibling.innerText;
        //    $.ajax({
        //        type: "POST",
        //        url: "Home.aspx/Listar",
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        data: JSON.stringify({ tipo: valor }),
        //        success: function (data) {
        //            console.log(valor);
        //        }, error: function (xhr, textStatus, errorThrown) {
        //            // Manejar cualquier error que ocurra durante la llamada AJAX
        //            console.error(errorThrown);
        //        }

        //    });
        //    activarBoton();
        //}
<%--        function activarBoton() {
            // Obtiene una referencia al botón
            var boton = document.getElementById('<%= btnAgregar.ClientID %>');

            // Simula el clic en el botón
            if (boton) {
                boton.click();
            }
        }--%>

    </script>



    <script>
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
