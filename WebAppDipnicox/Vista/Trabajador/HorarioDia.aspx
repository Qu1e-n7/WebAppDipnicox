﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="HorarioDia.aspx.cs" Inherits="WebAppDipnicox.Vista.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <link href="../Css/Horario.css" rel="stylesheet" />
    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="conta">
        <div class="text-center mt-5">
            <h2>HORARIO</h2>
            <div class="labor text-start my-5 px-5">
                <h3>Dias que deseas laboral</h3>
                <asp:Repeater runat="server" ID="rptDias" OnItemDataBound="rptDias_ItemDataBound">
                    <ItemTemplate>
                        <label class="dia my-3 mx-4">
                            <asp:CheckBox ID="chkDias" runat="server" onclick="slectheck(this)" Text='<%# Eval("Dia") %>' />
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
            <div class="horar pt-3">
                <div class="d-flex justify-content-center">
                    <div id="diho" runat="server" class="row">
                        <div id="horinifin" runat="server" class="col mt-4 pt-3 p-0 d-none" style="width: 100px;">
                            <label for="" class="mt-4 pt-3" style="color: #10b3a0; font-size: 15px; font-weight: bold;">Hora inicial</label>
                            <label for="" class="mt-4 pt-3" style="color: #10b3a0; font-size: 15px; font-weight: bold;">Hora final</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            var checkb = $('.dia input[type="checkbox"]');
            checkb.on('click', function () {
                var selc = true;
                checkb.each(function () {
                    if ($(this).is(':checked')) {
                        selc = false;
                        return false;
                    }
                });
                var divhor = document.getElementById('<%= horinifin.ClientID %>');
                if (selc) {
                    console.log('pasa');
                    divhor.className = 'd-none';
                }
            });

        });
        function slectheck(check) {
            var chktex = check.parentNode.innerText;
            var divdias = document.getElementById('<%= diho.ClientID %>');
            var divhor = document.getElementById('<%= horinifin.ClientID %>');
            if (check.checked) {
                //Principal
                var div = document.createElement('div');
                div.id = 'col' + chktex;
                div.className = 'col my-5 mx-3';
                //div1
                var div1 = document.createElement('div');
                div1.id = 'di' + chktex;
                div1.className = 'Dias d-flex justify-content-center align-items-center';
                var lbdia = document.createElement('label');
                lbdia.textContent = chktex;
                div1.appendChild(lbdia);
                //Div2
                var div2 = document.createElement('div');
                div2.id = 'ho' + chktex;
                div2.className = 'Horas mt-4';
                div2.style = 'width: min-content'
                //Hora Inicial
                var txthoraini = document.createElement('input');
                txthoraini.type = 'time';
                txthoraini.id = 'txtIni' + lbdia.textContent;
                txthoraini.className = 'tex mb-2';
                div2.appendChild(txthoraini);
                //Hora Final
                var txthorafin = document.createElement('input')
                txthorafin.type = 'time';
                txthorafin.id = 'txtFin' + lbdia.textContent;
                txthorafin.className = 'tex mb-2';
                div2.appendChild(txthorafin);
                //Buton
                var btn = document.createElement("button");
                btn.className = 'guardar px-4 py-2 mb-4';
                btn.innerHTML = "Guardar";
                btn.setAttribute("type", "button");

                btn.addEventListener("click", function (event) {
                    console.log("Se hizo clic en el botón");
                    Horario(txthoraini.value, txthorafin.value, lbdia.textContent);
                });
                div2.appendChild(btn);
                div.appendChild(div1);
                div.appendChild(div2);


                divdias.appendChild(div);
                divhor.className = 'col mt-5 pt-5 p-0 d-block';
            } else {
                var divdelt = document.getElementById('col' + chktex);
                if (divdelt) {
                    divdias.removeChild(divdelt);
                }
            }
        }

        function Horario(HoraIni, HoraFin, Dia) {
            $.ajax({
                type: "POST",
                url: "HorarioDia.aspx/mtdAgregarHor",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ txtInicio: HoraIni, txtFinal: HoraFin, dia: Dia }),
                success: function (dat) {
                    var Regis = dat.d;
                    if (Regis != 0) {
                        alert("Se registro Horas del dia");
                    }
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJAX
                    console.error(errorThrown);
                    console.error(xhr);
                }
            });
        }
        function selectHorDia() {
            $.ajax({
                type: "POST",
                url: "HorarioDia.aspx/mtdSelect",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (dat) {
                    var listar = dat.d;
                    console.log(listar);
                }, error: function (xhr, textStatus, errorThrown) {
                    // Manejar cualquier error que ocurra durante la llamada AJAX
                    console.error(errorThrown);
                    console.error(xhr);
                }
            });
        }

    </script>
</asp:Content>
