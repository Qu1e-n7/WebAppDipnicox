<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPersonal.aspx.cs" Inherits="WebAppDipnicox.Vista.ListarPersonal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap5.min.js"></script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.4/css/dataTables.bootstrap5.min.css" rel="stylesheet" />



</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>--%>

            <table id="tblTrabajador" class="table table-striped table-bordered dt-responsive nowrap " style="width: 100%">
                <thead>
                    <tr>
                        <th>idPersonal</th>
                        <th>Documento</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Telefono</th>
                        <th>Estado</th>
                        <th>Email</th>
                        <th>Contraseña</th>
                        <th>idTipoPersonal</th>
                        <th>idCiudad</th>
                        <th>Detalles</th>

                    </tr>
                </thead>
                <tbody>
                </tbody>
                <tfoot>
                    <tr>
                        <th>idPersonal</th>
                        <th>Documento</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Telefono</th>
                        <th>Estado</th>
                        <th>Email</th>
                        <th>Contraseña</th>
                        <th>idTipoPersonal</th>
                        <th>idCiudad</th>
                        <th>Detalles</th>
                    </tr>
                </tfoot>
            </table>



        </div>
    </form>
    <script>

        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "ListarPersonal.aspx/mtdObtenerDatos",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = response.d;

                    $('#tblTrabajador').DataTable({
                        data: data,
                        columns: [
                            { data: "idPersonal" },
                            { data: "Documento" },
                            { data: "Nombre" },
                            { data: "Apellido" },
                            { data: "Telefono" },
                            { data: "Estado" },
                            { data: "Email" },
                            { data: "Contraseña" },
                            { data: "idTipoPersonal" },
                            { data: "idCiudad" },
                            {
                                data: null,
                                render: function (data, type, row) {
                                    return '<button class="btn btn-danger btn-delete" data-id="' + data.idPersonal + '">Eliminar</button>' +
                                        '<button class="btn btn-primary btn-update" data-id="' + data.idPersonal + '">Actualizar</button>';
                                }
                            }

                        ]
                    });

                    $('#tblTrabajador').on('click', '.btn-delete', function () {
                        var id = $(this).data('id');


                    });

                    $('#tblTrabajador').on('click', '.btn-update', function () {
                        var id = $(this).data('id');


                    });


                },
                error: function (error) {
                    console.log(error);
                }
            });
        });

        
      
    </script>
</body>
</html>
