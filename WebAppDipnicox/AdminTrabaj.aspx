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
                    <p id="contador" class="count-product">0</p>
                </div>
                <div class="cart-products" id="products-id">

                    <div class="card-item">
                        <!-- Carrito de compras -->
                        <div class="carrito">
                            <div class="header-carrito">
                                <h2>Carrito de Compras</h2>
                            </div>
                            <p class="close-btn" onclick="closeBtn()">X</p>

                            <div class="carrito-items">
                                <ul id="listaCarrito" style="background-color: blue; border-radius: 10px;"></ul>
                            </div>
                            <div class="carrito-total">
                                <div class="fila">
                                    <h2>Total: $<strong id="contadorPrecio" class="price-total">0</strong></h2>
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
                    <
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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

                                                            <button class="btn-add-cart card-link ms-5 btn btn-primary p-2" onclick="agregarAlCarrito('<%# Eval("Nombre") %>', <%# Eval("Valor") %>);">Agregar al carrito</button>
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
        function showCart(x) {
            document.getElementById("products-id").style.display = "block";
        }
        function closeBtn() {
            document.getElementById("products-id").style.display = "none";
        }

    </script>

    <script>


        // Variables globales
        var total = 0;
        var contador = 0;

        // Función para agregar un producto al carrito
        function agregarAlCarrito(nombre, precio) {
            var listaCarrito = document.getElementById('listaCarrito');
            var li = document.createElement('li');
            li.innerHTML = `
        <div class="carrito-item">
            <img src="#" width="80px" alt="">
            <div class="carrito-item-detalles">
                <span class="carrito-item-titulo">${nombre}</span>
                <div class="selector-cantidad">
                    <i class="uil uil-angle-left-b restar-cantidad"></i>
                    <input type="text" value="1" class="carrito-item-cantidad" disabled>
                    <i class="uil uil-angle-right sumar-cantidad"></i>
                </div>
               
                <span class="carrito-item-precio">${precio}</span>
            </div>
            

        </div>
    `;

            var botonEliminar = document.createElement('button');
            botonEliminar.textContent = 'Eliminar';
            botonEliminar.classList.add('btn-eliminar');
            botonEliminar.addEventListener('click', function () {
                eliminarDelCarrito(li, precio);
            });
            li.appendChild(botonEliminar);

            listaCarrito.appendChild(li);

            // Actualizar contador y total
            contador++;
            total += precio;
            actualizarContador();
            actualizarContadorPrecio();
        }

        function eliminarDelCarrito(item, precio) {
            item.parentNode.removeChild(item);

            // Actualizar contador de productos y total
            contador--;
            total -= precio;
            actualizarContador();
            actualizarContadorPrecio();

            if (contador === 0) {
                ocultarCarrito();
            }
        }

        // Función para actualizar el contador
        function actualizarContador() {
            var contadorElement = document.getElementById('contador');
            contadorElement.innerHTML = contador;
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
        paypal.Buttons({
            style: {
                color: 'blue',
                shape: 'pill',
                label: 'pay'
            },
            createOrder: function (data, actions) {
                var total = document.getElementById('contadorPrecio').textContent;
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: total
                        }
                    }]
                });
            },
            onApprove: function (data, actions) {
                swal("¡Pago Aprobado! ", "El Pago Ha Sido Realizado Con Exito.", "success");
                return actions.order.capture().then(function (details) {
                    document.getElementById('paymentDetails').textContent = JSON.stringify(details, null, 2);
                    document.getElementById('nameField').textContent = details.payer.name.given_name + ' ' + details.payer.name.surname;
                    document.getElementById('emailField').textContent = details.payer.email.address;
                    document.getElementById('paymentTable').style.display = 'table';
                    document.getElementById('successMessage').style.display = 'block';

                    console.log(details);
                });
            },
            OnCancel: function (data) {
                swal("!Pago Cancelado!", "El Pago Ha Sido Cancelado.", "error");
                document.getElementById('cancelMessage').style.display = 'block';
                console.log(data);
            }
        }).render('#paypal-button-container');
    </script>
</asp:Content>
