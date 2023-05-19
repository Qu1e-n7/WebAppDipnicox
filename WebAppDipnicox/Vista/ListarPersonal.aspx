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

    <%-- Actualizar --%>
    <%--<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe"
        crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
    <link href="Css/Actualiza.css" rel="stylesheet" />
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />--%>
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


        <!-- Modal -->
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="section">
                            <h2 class="py-3">Actualizacion de Productos</h2>
                            <div class="container">
                                <div class="row full-height justify-content-center">
                                    <div class="col-12 text-center align-self-center py-5">
                                        <div class="card-3d-wrap mx-auto">
                                            <div class="card-3d-wrapper">
                                                <div class="card-front">
                                                    <h2 class="py-3 mt-3 mr-2 ">Datos del producto</h2>
                                                    <div class="center-wrap">
                                                        <div class="text-center mt-2 py-4 px-2" style="background: #2b2e38">
                                                            <div class="section text-center">
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div class="mt-2 form-group">
                                                                            <label for="Documento">Documento</label>
                                                                            <asp:TextBox ID="txtDocumento" CssClass="form-style" runat="server"></asp:TextBox>
                                                                            <i class="input-icon uil uil-asterisk"></i>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col">
                                                                        <div class="mt-2 px-2 form-group">
                                                                            <label for="Nombre">Nombre</label>
                                                                            <asp:TextBox ID="txtNombre" CssClass="form-style" runat="server"></asp:TextBox>
                                                                            <i class="input-icon uil uil-briefcase"></i>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col">
                                                                        <div class="mt-2 px-2 form-group">
                                                                            <label for="Apellido">Apellido</label>
                                                                            <asp:TextBox ID="txtApellido" CssClass="form-style" runat="server"></asp:TextBox>
                                                                            <i class="input-icon uil uil-briefcase"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div class="mt-3 form-group">
                                                                            <label for="Telefono">Telefono</label>
                                                                            <asp:TextBox ID="txtTelefono" CssClass="form-style" runat="server"></asp:TextBox>
                                                                            <i class="input-icon uil uil-dollar-alt"></i>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-5">
                                                                        <div class="mt-3 form-group">
                                                                            <label for="Estado">Estado</label>
                                                                            <asp:TextBox ID="txtEstado" CssClass="form-style" runat="server"></asp:TextBox>
                                                                            <i class="input-icon uil uil-object-group"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div class="mt-3 form-group">
                                                                            <label for="Email">Email</label>
                                                                            <asp:TextBox ID="txtEmail" CssClass="form-style" runat="server"></asp:TextBox>
                                                                            <i class="input-icon uil uil-dollar-alt"></i>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-5">
                                                                        <div class="mt-3 form-group">
                                                                            <label for="Contraseña">Contraseña</label>
                                                                            <asp:TextBox ID="txtContraseña" CssClass="form-style" runat="server"></asp:TextBox>
                                                                            <i class="input-icon uil uil-object-group"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>


                                                                <div class="row">
                                                                    <div class="col">
                                                                        <div class="mt-3 form-group">
                                                                            <label for="TipoPersonal">Tipo Personal</label>
                                                                            <asp:DropDownList ID="ddlTipoPersonal" runat="server"></asp:DropDownList>
                                                                            <i class="input-icon uil uil-dollar-alt"></i>
                                                                        </div>

                                                                    </div>
                                                                    <div class="col-md-5">
                                                                        <div class="mt-3 form-group">
                                                                            <label for="Ciudad">Ciudad</label>
                                                                            <asp:DropDownList ID="ddlCiudad" runat="server"></asp:DropDownList>
                                                                            <i class="input-icon uil uil-object-group"></i>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <asp:Button ID="btnActualizar" CssClass="mt-5 mx-5 btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                                                                <asp:Button ID="btnEliminar" CssClass="mt-5 mx-5 btn btn-primary" runat="server" Text="Eliminar" />
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
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Understood</button>
                    </div>
                </div>
            </div>
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
                                    return '<button class="btn btn-danger btn-delete" data-id="' + data.idPersonal + '">Eliminar</button>' + ' ' +
                                        '<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">Actualizar </button> ';
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
