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
    <link href="Css/Actualiza.css" rel="stylesheet" />

    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1100px">
        <table id="tblVenta" class="table" style="color: #ffffff">
            <thead style="color: #99b8df">
                <tr>
                    <th>Codigo</th>
                    <th>Fecha</th>
                    <th>Total</th>
                    <th>idCliente</th>
                    <th>Trabajador</th>
                    <th>TipoVenta</th>
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
                            { data: "idCliente" },
                            { data: "idPersonal" },
                            { data: "idTipoVenta" },
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
