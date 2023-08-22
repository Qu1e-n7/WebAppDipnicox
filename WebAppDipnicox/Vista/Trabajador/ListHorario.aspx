<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeBehind="ListHorario.aspx.cs" Inherits="WebAppDipnicox.Vista.ListHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>

    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>

    <link href="../Css/Horario.css" rel="stylesheet" />
    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mt-5">
        <div id="horas" runat="server" class="d-flex ">
            <div class="ms-2">
                <table id="tblHorar" class="tbHor ms-5">
                    <thead>
                        <tr>
                            <th>Dia</th>
                            <th>Hora Inicial</th>
                            <th>Hora Final</th>
                            <th>Opciones</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>
            <div id="diho" runat="server" class="horar ms-5 pt-3 d-none">
                <div class="d-flex justify-content-center">
                    <div class="row">
                        <div class="col-md-6 d-flex align-items-center" style="width: min-content">
                            <div id="horinifin" runat="server" class="col mt-5 p-0" style="width: 100px;">
                                <label for="" class="mt-4 pt-3" style="color: #10b3a0; font-size: 15px; font-weight: bold;">Hora inicial</label>
                                <label for="" class="mt-4 pt-3" style="color: #10b3a0; font-size: 15px; font-weight: bold;">Hora final</label>
                            </div>

                            <div class="col my-5 mx-3">

                                <div class="Dias d-flex justify-content-center align-items-center">
                                    <asp:Label ID="lblDia" runat="server" Text="Dia"> </asp:Label>
                                </div>
                                <div class="Horas mt-4" style="width: min-content">
                                    <asp:TextBox ID="txtHoraIni" CssClass="tex mb-2" runat="server" TextMode="Time"></asp:TextBox>
                                    <asp:TextBox ID="txtHoraFin" CssClass="tex mb-2" runat="server" TextMode="Time"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col my-5 mx-3">
                                <asp:Button ID="btnActualizar" CssClass="guardar px-4 py-2 my-4" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                                <asp:Button ID="btnEliminar" CssClass="btn btn-danger guardar px-4 py-2 mb-4 " runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:TextBox ID="txtid" runat="server" Style="color: #031529; background: #031529; border: none;"></asp:TextBox>
        <script>
            $(document).ready(function () {
                $.ajax({
                    type: "Post",
                    url: "ListHorario.aspx/mtdListHorario",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var data = response.d;
                        if (data.length != 0) {
                            $('#tblHorar').DataTable({
                                "paging": false,
                                "searching": false,
                                "info": false,
                                data: data,
                                columns: [
                                    { data: "Dia" },
                                    {
                                        data: "HoraInicio",
                                        render: function (data, type) {
                                            var horas = data.Hours;
                                            var minutos = data.Minutes;
                                            var amPm = horas >= 12 ? 'PM' : 'AM';
                                            horas = horas % 12 || 12;
                                            var textoTiempo = horas.toString().padStart(2, '0') + ':' + minutos.toString().padStart(2, '0') + ' ' + amPm;
                                            return textoTiempo;
                                        }
                                    },
                                    {
                                        data: "HoraFinal",
                                        render: function (data, type) {
                                            var horas = data.Hours;
                                            var minutos = data.Minutes;
                                            var amPm = horas >= 12 ? 'PM' : 'AM';
                                            horas = horas % 12 || 12;
                                            var textoTiempo = horas.toString().padStart(2, '0') + ':' + minutos.toString().padStart(2, '0') + ' ' + amPm;
                                            return textoTiempo;
                                        }
                                    },
                                    {
                                        data: null,
                                        render: function (data, type, row) {
                                            return '<button type="button" id="btnVer" class="btn btn-primary" data-iddia="' + data.idHorarioDia + '" data-dia="' + data.Dia + '" >VER</button > '
                                        }
                                    }
                                ]
                            });
                            if (data.length <= 6) {
                                var btnAgregar = '<button type="button" id="btnAgregar" class="btn btn-primary">Agregar</button>';
                                var row = $('<tr>').append($('<td colspan="4">').html("Agregar mas dias " + btnAgregar));
                                $('#tblHorar tbody').append(row);
                                $('#tblHorar').on('click', '#btnAgregar', function () {
                                    AddHorario();
                                });
                            }
                        } else {
                            var btnAgregar = '<button type="button" id="btnAgregar"class="btn btn-primary">Agregar</button>';
                            var row = $('<tr>').append($('<td colspan="4">').html("No hay Horario " + btnAgregar));
                            $('#tblHorar tbody').append(row);
                            $('#tblHorar').on('click', '#btnAgregar', function () {
                                AddHorario();
                            });
                        }



                        $('#tblHorar').on('click', '#btnVer', function () {
                            Dia = $(this).data('dia');
                            id = $(this).data('iddia');
                            var divhor = document.getElementById('<%= diho.ClientID %>');
                        divhor.className = 'horar ms-5 pt-3 d-block';
                        HoraDia(id);
                    })
                }
            });
        });
            function HoraDia(id) {
                $.ajax({
                    type: "Post",
                    url: "ListHorario.aspx/mtdListHoraDia",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({ id: id }),
                    success: function (response) {
                        var data = response.d;
                        console.log(data);
                        var lblDia = document.getElementById('<%= lblDia.ClientID %>');
                    var txtid = document.getElementById('<%= txtid.ClientID %>');
                    var txtHIni = document.getElementById('<%= txtHoraIni.ClientID %>');
                    var txtHFin = document.getElementById('<%= txtHoraFin.ClientID %>');
                    lblDia.textContent = data.Dia;
                    txtid.value = data.idHorarioDia;
                    //Hora Inicial
                    var HInicio = new Date();
                    HInicio.setHours(data.HoraInicio.Hours);
                    HInicio.setMinutes(data.HoraInicio.Minutes);
                    txtHIni.value = HInicio.getHours().toString().padStart(2, '0') + ':' + HInicio.getMinutes().toString().padStart(2, '0');
                    //Hora Fin
                    var HFin = new Date();
                    HFin.setHours(data.HoraFinal.Hours);
                    HFin.setMinutes(data.HoraFinal.Minutes);
                    txtHFin.value = HFin.getHours().toString().padStart(2, '0') + ':' + HFin.getMinutes().toString().padStart(2, '0');
                }
            });
            }
            function AddHorario() {
                $.ajax({
                    type: "Post",
                    url: "ListHorario.aspx/mtdAgregarHorario",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var data = response.d;
                        if (data != "") {
                            location.href = data;
                        }
                    }
                });
            }
        </script>
</asp:Content>
