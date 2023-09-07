<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="WebAppDipnicox.Vista.Servicio.Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link href="css/CardServicio.css" rel="stylesheet" />
    <link href="css/Modal.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="CardCatego">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3 style="text-align: center; padding: 20px;">Servicios Disponibles</h3>
        <div class="container">
            <div class="row">
                <asp:Repeater ID="repcard" runat="server" OnItemDataBound="repcard_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <figure class="snip1336">
                                <img src="../Imagenes/Halo.PNG" alt="sample87" />
                                <figcaption>
                                    <img src="../Imagenes/88217.png" alt="profile-sample4" class="profile" />
                                    <asp:Label ID="nombreProducto" runat="server" Text='<%# Eval("Nombre")  %>'></asp:Label>
                                    <p class="card-price" style="color: white;">$<asp:Label ID="precio" runat="server" Text='<%# Eval("Valor")  %>'></asp:Label></p>
                                    <p class="card-text" style="color: white;">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Descripcion")  %>'></asp:Label>
                                    </p>
                                    <%-- <asp:Label ID="Valor" runat="server" Text="<%# Eval("Valor") %>"></asp:Label>
                                    <asp:Label ID="Descripcion" runat="server" Text="<%# Eval("Descripcion") %>"></asp:Label>--%>
                                    <%--<h2><%# Eval("Nombre") %><span id="spanValor"><%# Eval("Valor") %></span></h2>--%>
                                    <%--<p><%# Eval("Descripcion") %> </p>--%>

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="idServicio" runat="server" Text='<%# Eval("idServicio")  %>' Visible="false"></asp:Label></h5>
                                             <h2 style="display: none;"><%# Eval("Valor")  %></h2>
                                            <a href="#modal-1" class="follow" onclick="listar(this)">Quiero Pedir Este Servicio!!</a>
                                            <asp:Button ID="btnAgregarValor" runat="server" Text="" OnClick="btnAgregarValor_Click" Style="display: none;" />
                                            <%--<asp:Button ID="agregarAlCarrito" runat="server" CssClass="add-to-cart-btn ocultar" Text="Agregar al carrito"  OnClick="agregarAlCarrito_Click" />--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </figcaption>
                            </figure>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

    <div class="modal-page" id="modal-1">

        <div class="modal-wrapper">

            <h2 style="color: white;">Quiero Adquirir Este Servicio </h2>

            <fieldset>

                <label for="name" style="color: white">Dia del Servicio:</label>
                <asp:TextBox ID="name" name="user_name" TextMode="Date" runat="server" Style="background: none;"></asp:TextBox>


            </fieldset>
            <fieldset>

                <label for="bio" style="color: white;">Descripcion del Servicio:</label>
                <asp:TextBox ID="bio" runat="server" name="user_bio" TextMode="MultiLine" Rows="4" Columns="40" Style="color: black;"></asp:TextBox>


                <a href="#" class="btn btn-sm">X</a>
            </fieldset>
            <asp:Label ID="lblValor" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnConsignacion" CssClass="botonCon" Style="transform: translateX(-50%); left: 50%;" runat="server" Text="Pedir" OnClick="btnConsignacion_Click" />

        </div>
        <!-- modal wrapper end -->

    </div>
    <!-- modal-page end -->
    <script>

        function listar(elementoA) {
            var valor = elementoA.previousElementSibling.innerText;
            $.ajax({
                type: "POST",
                url: "MostrarServicio.aspx/Listar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ tipo: valor }),
                success: function (data) {
                    console.log(valor);
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJAX
                    console.error(errorThrown);
                }

            });
            activarBoton();
        }
        function activarBoton() {
            // Obtiene una referencia al botón
            console.log("bvb");
<%--            var boton = document.getElementById('<%= btnAgregarValor.ClientID %>');--%>
            console.log(boton);
            // Simula el clic en el botón
            if (boton) {
                boton.click();
            }
        }
    </script>
</asp:Content>
