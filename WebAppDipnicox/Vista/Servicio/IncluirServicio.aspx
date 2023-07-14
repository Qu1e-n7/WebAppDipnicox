<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="IncluirServicio.aspx.cs" Inherits="WebAppDipnicox.Vista.Servicio.IncluirServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/IncluirServicio.css" rel="stylesheet" />
    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />

    <link href="css/Trabajador.css" rel="stylesheet" />
    <link href="css/TextBox.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    
    <script>


    </script>
</asp:Content>
