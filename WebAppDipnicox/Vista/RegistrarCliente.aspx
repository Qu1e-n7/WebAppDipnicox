<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCliente.aspx.cs" Inherits="WebAppDipnicox.Vista.RegistrarCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v2.1.9/css/unicons.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.0/css/bootstrap.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous" />
    <link href="Css/Style.css" rel="stylesheet" />
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="section">
                <div class="container">
                    <div class="row full-height justify-content-center">
                        <div class="col-12 text-center align-self-center py-5">
                            <div class="card-3d-wrap mx-auto">
                                <div class="card-3d-wrapper">
                                    <div class="card-front">
                                        <div class="center-wrap">
                                            <div class="section text-center">
                                                <h4 class="mb-3 pb-3">Registrate!!</h4>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-style" placeholder="Documento"></asp:TextBox>
                                                    <i class="input-icon uil uil-user-square"></i>
                                                </div>
                                                <div class="form-group mt-2">
                                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-style" placeholder="Nombre"></asp:TextBox>
                                                    <i class="input-icon uil uil-user"></i>
                                                </div>
                                                <div class="form-group mt-2">
                                                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-style" placeholder="Apellido"></asp:TextBox>
                                                    <i class="input-icon uil uil-user"></i>
                                                </div>
                                                <div class="form-group mt-2">
                                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-style" placeholder="Numero Telefonico"></asp:TextBox>
                                                    <i class="input-icon uil uil-phone"></i>
                                                </div>
                                                <div class="form-group mt-2">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-style" placeholder="Email"></asp:TextBox>
                                                    <i class="input-icon uil uil-at"></i>
                                                </div>
                                                <div class="form-group mt-2" />
                                                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" CssClass="form-style" placeholder="Password"></asp:TextBox>
                                                <i class="input-icon uil uil-lock-alt"></i>

                                                <div class="form-group mt-2" />


                                            </div>
                                            <div class="form-group mt-2" />
                                            <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-style"></asp:DropDownList>
                                            <i class="input-icon uil uil-map"></i>
                                        </div>

                                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn mt-4" OnClick="btnRegistrar_Click" />
                                        <br />
                                        <div class="login-help">
                                            <a href="Login.aspx">Ya tengo una cuenta</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
