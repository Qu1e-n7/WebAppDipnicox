﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegProductos.aspx.cs" Inherits="WebAppDipnicox.Vista.RegistarProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v2.1.9/css/unicons.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous" />
    <link href="../Css/Style.css" rel="stylesheet" />
    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />

    <script>
        function abrir() {
            document.getElementById('<%= FPImage.ClientID %>').click();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container">
            <div class="row full-height justify-content-center">
                <div class="col-12 text-center align-self-center py-5">
                    <div class="card-3d-wrap mx-auto">
                        <div class="card-3d-wrapper">
                            <div class="card-front">
                                <div class="center-wrap">
                                    <div class="section text-center">
                                        <h4 class="mb-3 pb-3">Registrar Productos </h4>
                                        <div class="form-group">
                                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-style" placeholder="Codigo"></asp:TextBox>
                                            <i class="input-icon uil uil-user-square"></i>
                                        </div>
                                        <div class="form-group mt-2">
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-style" placeholder="Nombre"></asp:TextBox>
                                            <i class="input-icon uil uil-user"></i>
                                        </div>
                                        <div class="form-group mt-2">
                                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-style" TextMode="MultiLine" Style="height: 100px" placeholder="Descripcion"></asp:TextBox>
                                            <i class="input-icon uil uil-user"></i>
                                        </div>
                                        <div class="form-group mt-2">
                                            <asp:TextBox ID="txtValor" runat="server" CssClass="form-style" placeholder="Valor Unitario"></asp:TextBox>
                                            <i class="input-icon uil uil-phone"></i>
                                        </div>
                                        <div class="form-group mt-2">
                                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-style" placeholder="Cantidad"></asp:TextBox>
                                            <i class="input-icon uil uil-user-check"></i>
                                        </div>
                                        <div class="form-group mt-2">
                                            <asp:FileUpload ID="FPImage" runat="server" style="display: none;" CssClass="form-style" onchange="imagen();"/>
                                            <asp:Button ID="btnimage" CssClass="form-style" runat="server" Text="Selecione Imagen del Producto" OnClientClick="abrir(); return false;" />
                                            <i class="input-icon uil uil-image-plus"></i>

                                        </div>
                                        <div class="form-group mt-2">
                                            <asp:TextBox ID="txtMedidad" runat="server" CssClass="form-style" placeholder="Medida"></asp:TextBox>
                                            <i class="input-icon uil uil-at"></i>
                                        </div>
                                    </div>

                                    <div class="form-group mt-2">
                                        <asp:DropDownList ID="ddlTipoProduc" runat="server" CssClass="form-style"></asp:DropDownList>
                                        <i class="input-icon uil uil-users-alt"></i>
                                    </div>
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Register" CssClass="btn mt-4" OnClick="btnRegistrar_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function imagen() {
            var fileUpload = document.getElementById("<%= FPImage.ClientID %>");
            if (fileUpload.files.length > 0) {
                var NomArc = fileUpload.files[0].name;
                document.getElementById("<%=btnimage.ClientID %>").value = NomArc;
            }
        }

    </script>
</asp:Content>
