<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="Horario.aspx.cs" Inherits="WebAppDipnicox.Vista.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <link href="Css/Horario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conta">
        <div class="text-center mt-5">
            <h2>HORARIO</h2>
            <div class="labor text-start my-5 px-5">
                <h3>Dias que deseas laboral</h3>
                <asp:Repeater runat="server" ID="rptDias">
                    <ItemTemplate>
                        <label class="dia my-3 mx-4">
                            <asp:CheckBox ID="chkDias" runat="server" AutoPostBack="true" OnCheckedChanged="chkDias_CheckedChanged" Text='<%# Eval("Dia") %>' />
                            <svg viewBox="0 0 64 64" height="2em" width="2em">
                                <path
                                    d="M 0 16 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 16 L 32 48 L 64 16 V 8 A 8 8 90 0 0 56 0 H 8 A 8 8 90 0 0 0 8 V 56 A 8 8 90 0 0 8 64 H 56 A 8 8 90 0 0 64 56 V 16"
                                    pathLength="575.0541381835938" class="path">
                                </path>
                            </svg>
                        </label>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="horar pt-5">
                <div class="d-flex justify-content-center">
                    <div class="row">
                        <asp:Repeater runat="server" ID="rptSeman">
                            <ItemTemplate>
                                <div class="col my-5 mx-3">
                                    <div class="Dias d-flex justify-content-center align-items-center">
                                        <label for="" style="color: black;">lunes</label>
                                    </div>
                                    <div class="Horas mt-4">
                                        <asp:TextBox ID="TextBox1" class="tex" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
