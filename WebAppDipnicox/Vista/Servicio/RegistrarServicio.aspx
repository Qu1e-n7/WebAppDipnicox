<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistrarServicio.aspx.cs" Inherits="WebAppDipnicox.Vista.RegistrarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/RegistrarServicio.css" rel="stylesheet" />
    <link href="css/Boton.css" rel="stylesheet" />
    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-box">
        <h2>Registrar Servicios</h2>

        <div class="user-box">
            <asp:TextBox ID="txtNombre" runat="server" required=""></asp:TextBox>
            <label>Nombre</label>
        </div>
        <div class="user-box">
            <asp:TextBox ID="txtDescripcion" runat="server" required=""></asp:TextBox>
            <label>Descripcion</label>
        </div>
        <div class="user-box">
            <asp:TextBox ID="txtValor" runat="server" required=""></asp:TextBox>
            <label>Valor</label>
        </div>
        <div class="wrap">
            <asp:Button CssClass="button" ID="btnRegistrar" runat="server" Text="Registrar Servicio" OnClick="btnRegistrar_Click" />
        </div>

    </div>

</asp:Content>
