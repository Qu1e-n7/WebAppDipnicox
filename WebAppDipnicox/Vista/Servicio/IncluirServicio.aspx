<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="IncluirServicio.aspx.cs" Inherits="WebAppDipnicox.Vista.Servicio.IncluirServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />

    <link href="css/Trabajador.css" rel="stylesheet" />
    <link href="../Css/TextBox.css" rel="stylesheet" />
    <link href="../Css/Carrito.css" rel="stylesheet" />
    <link href="../Css/Modal.css" rel="stylesheet" />
    <link href="../Css/Notificacion.css" rel="stylesheet" />
    <link href="../Css/IncluirServicio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <header>
        <div class="header-section container">

            <div>
                <img onclick="showCart(this)" class="cart" src="../Imagenes/1271361.png" alt="">
                <p id="contador" class="count-product">0</p>
                <asp:HiddenField ID="hfListaEnJson" runat="server" Value='<%# ListaEnJson %>' />
            </div>
            <div class="cart-products" id="products-id">

                <div class="card-item">
                    <!-- Carrito de compras -->
                    <div class="carrito">
                        <div class="header-carrito">
                            <h2 style="color: white;">Notificaciones!!</h2>
                        </div>
                        <p class="close-btn" onclick="closeBtn()">X</p>
                    </div>
                    <asp:Repeater ID="repcard" runat="server">
                        <ItemTemplate>

                            <div class="toast-tray dissmiss-toast">
                                <div class="toast-wrap">
                                    <div class="toast-icon">
                                        <img src="payment-icon.svg" alt="">
                                    </div>

                                    <div class="toast-msg">
                                        <span><%# Eval("Titulo") %></span><br>
                                        <%# Eval("Descripcion") %>
                                    </div>
                                </div>
                                <div class="toast-btn">
                                    <a href="#modal-1" class="link">VIEW</a>
                                    <hr>
                                    <a href="#" class="link dissmiss">DISMISS</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

    </header>

    <aside class="profile-card">

        <h2>Tu perfil</h2>
        <div class="warpper">
            <input class="radio" id="one" name="group" type="radio" checked>
            <input class="radio" id="two" name="group" type="radio">
            <input class="radio" id="three" name="group" type="radio">
            <div class="tabs">
                <label class="tab" id="one-tab" for="one">Datos Personales</label>
                <label class="tab" id="two-tab" for="two">Datos de Contacto </label>
                <label class="tab" id="three-tab" for="three">Servicio</label>
            </div>
            <div class="panels">
                <div class="panel" id="one-panel">
                    <div class="coolinput">
                        <label for="input" class="text">Documento:</label>
                        <asp:TextBox ID="txtDocumento" runat="server" placeholder="Documento" name="input" class="input"></asp:TextBox>
                    </div>
                    <br />
                    <div class="row">
                        <div class="d-flex">
                            <div class="coolinput">
                                <label for="input" class="text">Nombre:</label>
                                <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" name="input" class="input"></asp:TextBox>
                            </div>

                            <asp:Button ID="btnActualizarDatosP" CssClass="button ms-5" runat="server" Text="Actualizar" OnClick="btnActualizarDatosP_Click" />

                        </div>
                    </div>
                    <br />
                    <div class="coolinput">
                        <label for="input" class="text">Apellido:</label>
                        <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" name="input" class="input"></asp:TextBox>
                    </div>
                    <br />
                </div>
                <div class="panel" id="two-panel">
                    <div class="row">
                        <div class="d-flex">
                            <div class="coolinput">
                                <label for="input" class="text">Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" name="input" class="input"></asp:TextBox>
                            </div>
                            <br />
                            <div class="coolinput ms-5">
                                <label for="input" class="text">Telefono:</label>
                                <asp:TextBox ID="txtTelefono" runat="server" placeholder="Telefono" name="input" class="input"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <h1>Actualizacion de Datos Ingresados</h1>
                    <div class="row">
                        <div class="d-flex">
                            <div class="coolinput">
                                <label for="input" class="text">Estado:</label>
                                <asp:TextBox ID="txtEstado" runat="server" placeholder="Estado" name="input" class="input"></asp:TextBox>
                            </div>
                            <div class="coolinput ms-5">
                                <label for="input" class="text">Contraseña:</label>
                                <asp:TextBox ID="txtContraseña" runat="server" placeholder="Contraseña" name="input" class="input"></asp:TextBox>
                            </div>
                            <br />
                        </div>
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="btnActualizarDatosC" CssClass="button mt-4" runat="server" Text="Actualizar" OnClick="btnActualizarDatosC_Click" />
                        </div>
                    </div>
                </div>

                <div class="panel mt-5" id="three-panel">
                    <div class="row">
                        <div class="d-flex">
                            <h1 class="ms-5">Ciudad</h1>
                            <h1 class="ms-5">Agregar Servicio</h1>

                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="d-flex">
                            <div class="inputbox ms-5">
                                <div class="card__content">
                                    <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="input"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="inputbox ms-5">

                                <asp:DropDownList ID="ddlServicio" CssClass="input" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="d-flex justify-content-center">
                            <asp:Button ID="btnActualizar" CssClass="button mt-5" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </aside>

    <div class="modal-page" id="modal-1">

        <div class="modal-wrapper">

            <h1 style="color: white;">Aceptar Servicio</h1>

            <fieldset>

                <label for="name" style="color: white">Valores Adicionales:</label>
                <asp:TextBox ID="name" name="user_name" runat="server" Style="background: none;">0</asp:TextBox>


            </fieldset>
            <fieldset>

                <label for="bio" style="color: white;">Caracteristicas Adicionales:</label>
                <asp:TextBox ID="bio" runat="server" name="user_bio" TextMode="MultiLine" Rows="4" Columns="40" Style="color: black;"></asp:TextBox>


                <a href="#" class="btn btn-sm">X</a>
            </fieldset>
            <asp:Label ID="lblValor" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnConsignacion" CssClass="botonCon" Style="transform: translateX(-50%); left: 50%;" runat="server" Text="Pedir" />

        </div>
        <!-- modal wrapper end -->

    </div>
    <!-- modal-page end -->

    <script>

        function showCart(x) {
            document.getElementById("products-id").style.display = "block";
        }
        function closeBtn() {
            document.getElementById("products-id").style.display = "none";
        }
        var listaNoti = JSON.parse(document.getElementById('<%= hfListaEnJson.ClientID %>').value);
        function calcularContador() {
            var contador = 0;

            for (var i = 0; i < listaNoti.length; i++) {
                contador += listaNoti[i];
            }

            document.getElementById("contador").innerHTML = contador;
        }
        window.onload = function () {
            calcularContador();
        };

    </script>
</asp:Content>
