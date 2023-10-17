<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="WebAppDipnicox.Vista.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
    <link href="../Css/Actualiza.css" rel="stylesheet" />

    <script src="../SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="../SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1100px">
        <table id="tblVenta" class="table" style="color: #ffffff">
            <thead style="color: #99b8df">
                <tr>
                    <th>Codigo</th>
                    <th>Fecha</th>
                    <th>Total</th>
                    <th>Cliente</th>
                    <th>Trabajador</th>
                    <th>Tipo Venta</th>
                    <th>Detalles</th>
                </tr>
            </thead>
            <tbody></tbody>
            <tfoot>
            </tfoot>
        </table>
    </div>
    <div style="color: #ffeba7">
        <asp:TextBox ID="txtDato" runat="server" Style="color: #031529; background: #031529; border: none;"></asp:TextBox>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="ModalActua" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content" style="width: 650px; background: #5e6a75; height: 600px;">
                <%--<div class="modal-header">
                    <h5 class="mx-auto modal-title" style="color: #0070ff" id="exampleModalLabel">Actualizacion de Productos</h5>
                    
                </div>--%>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                <div class="modal-body">
                    <div class="section">
                        <div class="container">
                            <div class="row full-height justify-content-center">
                                <div class="col-12 text-center align-self-center">
                                    <div class="card-3d-wrap mx-auto">
                                        <div class="card-3d-wrapper">
                                            <div class="card-front">
                                                <h2 class="py-3 mt-3 mr-2 ">Datos del producto</h2>
                                                <div style="width: 580px">
                                                    <table id="tblPVentas" class="table" style="width: 580px; color: #ffffff">
                                                        <thead style="color: #99b8df">
                                                            <tr>
                                                                <th>Nombre</th>
                                                                <th>Codigo</th>
                                                                <th>Total</th>

                                                            </tr>
                                                        </thead>
                                                        <tbody></tbody>
                                                        <tfoot>
                                                        </tfoot>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "Ventas.aspx/Listar",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = response.d;
                    $('#tblVenta').DataTable({
                        data: data,
                        columns: [
                            { data: "Codigo" },
                            { data: "Fecha" },
                            { data: "Total" },
                            { data: "Cliente" },
                            { data: "Personal" },
                            { data: "TipVent" },
                            {
                                data: null,
                                render: function (data, type, row) {
                                    return '<button type="button" id="btnActua" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#ModalActua" data-id-venta="' + data.idVenta + '">Ver</button > '
                                }
                            }
                        ]
                    });
                    $('#tblVenta').on('click', '#btnActua', function () {
                        var id = $(this).data('idVenta');
                        //GuardarIdPersonal(id)

                    })

                },
                error: function (error) {
                    console.log(error);
                }
            });
        });

        //function GuardarIdPersonal(id) {

        //    $.ajax({
        //        type: "POST",
        //        url: "Ventas.aspx/GuardarIdPersonal",
        //        data: JSON.stringify({ idVenta: id }),
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (response) {
        //            var data = response.d;
        //            $('#tblPVentas').DataTable({
        //                data: data,
        //                columns: [
        //                    { data: "Nombre" },
        //                    { data: "Codigo" },
        //                    { data: "Total" }
        //                ]
        //            });
        //        },
        //        error: function (error) {
        //            console.log(error);
        //        }
        //    });

        //};

    </script>

    <script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "Ventas.aspx/Lista",
                /*data: JSON.stringify({ idVenta: id }),*/
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = response.d;
                    $('#tblPVentas').DataTable({
                        data: data,
                        columns: [
                            { data: "Nombre" },
                            { data: "Codigo" },
                            { data: "Total" }
                        ]
                    });

                },
                error: function (error) {
                    console.log(error);
                }
            });
        });


    </script>
</asp:Content>
