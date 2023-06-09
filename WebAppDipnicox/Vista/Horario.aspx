<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Horario.aspx.cs" Inherits="WebAppDipnicox.Vista.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conta">
        <div class="text-center mt-5">
            <h2>HORARIO</h2>
            <div class="labor text-start my-5 px-5">
                <h3>Dias que deseas laboral</h3>
                <label class="dia my-3 mx-4">
                    <input type="checkbox">
                    <svg viewBox="0 0 64 64" height="2em" width="2em">
                        <path
                            d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16"
                            pathLength="575.0541381835938" class="path"></path>
                    </svg>
                    <span class="ms-3" >Lunes</span>
                </label>
            </div>
            <div class="horar pt-5">
                <div class="d-flex justify-content-center">
                    <div class="row">
                        <div class="col my-5 mx-3">
                            <div class="Dias d-flex justify-content-center align-items-center">
                                <label for="" style="color: black;">Lunes</label>
                            </div>
                            <div class="Horas mt-4">
                                <input type="text" class="tex" id="">
                            </div>
                        </div>
                        <div class="col my-5 mx-3">
                            <div class="Dias d-flex justify-content-center align-items-center">
                                <label for="">Martes</label>
                            </div>
                            <div class="Horas mt-4">
                                <input type="text" class="tex" id="">
                            </div>
                        </div>
                        <div class="col my-5 mx-3">
                            <div class="Dias d-flex justify-content-center align-items-center">
                                <label for="">Miercoles</label>
                            </div>
                            <div class="Horas mt-4">
                                <input type="text" class="tex" id="">
                            </div>
                        </div>
                        <div class="col my-5 mx-3">
                            <div class="Dias d-flex justify-content-center align-items-center">
                                <label for="">Jueves</label>
                            </div>
                            <div class="Horas mt-4">
                                <input type="text" class="tex" id="">
                            </div>
                        </div>
                        <div class="col my-5 mx-3">
                            <div class="Dias d-flex justify-content-center align-items-center">
                                <label for="">Viernes</label>
                            </div>
                            <div class="Horas mt-4">
                                <input type="text" class="tex" id="">
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>

    </div>
</asp:Content>
