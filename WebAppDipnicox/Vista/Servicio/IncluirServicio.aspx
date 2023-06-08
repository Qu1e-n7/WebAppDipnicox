<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="IncluirServicio.aspx.cs" Inherits="WebAppDipnicox.Vista.Servicio.IncluirServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/IncluirServicio.css" rel="stylesheet" />

    <link href="css/BotonIncluir.css" rel="stylesheet" />
    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <aside class="profile-card">
        <header>
            <!-- here’s the avatar -->
            <a target="_blank" href="#">
                <img src="http://lorempixel.com/150/150/people/" class="hoverZoomLink">
            </a>

            <!-- the username -->
            <h1>John Doe
            </h1>

            <!-- and role or location -->
            <h2>Better Visuals
            </h2>

        </header>

        <!-- bit of a bio; who are you? -->
        <div class="profile-bio">

            <p>
                It takes monumental improvement for us to change how we live our lives. Design is the way we access that improvement.
            </p>

        </div>

        <!-- some social links to show off -->
        <ul class="profile-social-links">
            <li>
                <a target="_blank" href="https://www.facebook.com/creativedonut">
                    <i class="fa fa-facebook"></i>
                </a>
            </li>
            <li>
                <a target="_blank" href="https://twitter.com/dropyourbass">
                    <i class="fa fa-twitter"></i>
                </a>
            </li>
            <li>
                <a target="_blank" href="https://github.com/vipulsaxena">
                    <i class="fa fa-github"></i>
                </a>
            </li>
            <li>
                <a target="_blank" href="https://www.behance.net/vipulsaxena">

                    <i class="fa fa-behance"></i>
                </a>
            </li>
        </ul>
        <div class="card mt-5">
            <div class="tools">
                <div class="circle">
                    <span class="red box"></span>
                </div>
                <div class="circle">
                    <span class="yellow box"></span>
                </div>
                <div class="circle">
                    <span class="green box"></span>
                </div>
            </div>
            <div class="card__content">
                <asp:DropDownList ID="ddlServicio" CssClass="button" runat="server"></asp:DropDownList>
                <asp:Button ID="btnActualizar" CssClass="button" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />

            </div>
        </div>
    </aside>


</asp:Content>
