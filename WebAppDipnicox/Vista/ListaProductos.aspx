<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="WebAppDipnicox.Vista.ListaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tblUsua" class="table">
        <thead>
            <tr>
                <th scope="col">Codigo</th>
                <th scope="col">Nombre</th>
                <th scope="col">Descripcion</th>
                <th scope="col">Valor Unitario</th>
                <th scope="col">Medida</th>
                <th scope="col">TipoProducto</th>
            </tr>
        </thead>
        <tbody></tbody>
        <tfoot>
        </tfoot>
    </table>
    <script>
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "ListaProductos.aspx/mtdLista",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var lista = response.d;
                    console.log(lista);
                    $('#tblUsua').DataTable({
                        data: lista,
                        colums: [
                            { data: "Codigo" },
                            { data: "Nombre" },
                            { data: "Descripcion" },
                            { data: "ValorUni" },
                            { data: "Cantidad" },
                            { data: "UnidadMedida" },
                            { data: "idTipoProduc" },
                        ],
                         deferRender: true
                        
                    });
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });

    </script>
</asp:Content>
