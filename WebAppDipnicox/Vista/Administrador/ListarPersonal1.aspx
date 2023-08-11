<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListarPersonal1.aspx.cs" Inherits="WebAppDipnicox.Vista.ListarPersonal1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>

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
        <div id="dataTableContainer" class="table-responsive">
            <table id="tblTrabajador" class="table" style="width: 100%; color: #ffffff">
                <thead style="color: #99b8df ">
                    <tr>

                        <th>Documento</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Telefono</th>
                        <th>Estado</th>
                        <th>Email</th>
                        <th>Contraseña</th>
                        <th>Detalles</th>

                    </tr>
                </thead>
                <tbody style="color: white">
                </tbody>
                <tfoot style="color: #0070ff">
                    <tr>

                        <th>Documento</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Telefono</th>
                        <th>Estado</th>
                        <th>Email</th>
                        <th>Contraseña</th>
                        <th>Detalles</th>
                    </tr>
                </tfoot>
            </table>
        </div>
    </div>




    <!-- Modal -->
    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content" style="width: 650px; background: #5e6a75">
                <div class="modal-header">
                    <h5 class="modal-title" style="color: black" id="staticBackdropLabel">Actualizacion de Datos</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="section">
                        <%--<h2 class="py-3">Actualizacion de Datos</h2>--%>
                        <div class="container">
                            <div class="row full-height justify-content-center">
                                <div class="col-12 text-center align-self-center">
                                    <div class="card-3d-wrap mx-auto">
                                        <div class="card-3d-wrapper">
                                            <div class="card-front">
                                                <%--<h2 class="py-3 mt-3 mr-2 ">Datos del producto</h2>--%>
                                                <div class="center-wrap">
                                                    <div class="text-center mt-2 py-4 px-2" style="background: #2b2e38">
                                                        <div class="section text-center">
                                                            <div class="row">
                                                                <div class="col">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Documento">Documento</label>
                                                                        <asp:TextBox ID="txtDocumento" CssClass="form-style" runat="server"></asp:TextBox>
                                                                        <i class="input-icon uil uil-briefcase"></i>
                                                                    </div>

                                                                </div>
                                                            </div>

                                                             <div class="row">
                                                                <div class="col">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Nombre">Nombre</label>
                                                                        <asp:TextBox ID="txtNombre" CssClass="form-style" runat="server"></asp:TextBox>
                                                                        <i class="input-icon uil uil-dollar-alt"></i>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Apellido">Apellido</label>
                                                                        <asp:TextBox ID="txtApellido" CssClass="form-style" runat="server"></asp:TextBox><br />
                                                                        <i class="input-icon uil uil-object-group"></i>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                           
                                                            <div class="row">
                                                                <div class="col">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Telefono">Telefono</label>
                                                                        <asp:TextBox ID="txtTelefono" CssClass="form-style" runat="server"></asp:TextBox><br />
                                                                        <i class="input-icon uil uil-dollar-alt"></i>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Estado">Estado</label>
                                                                        <asp:TextBox ID="txtEstado" CssClass="form-style" runat="server"></asp:TextBox><br />
                                                                        <i class="input-icon uil uil-object-group"></i>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-7">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Email">Email</label>
                                                                        <asp:TextBox ID="txtEmail" CssClass="form-style" runat="server"></asp:TextBox><br />
                                                                        <i class="input-icon uil uil-object-group"></i>
                                                                    </div>
                                                                </div>
                                                                <div class="col">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Contraseña">Contraseña</label>
                                                                        <asp:TextBox ID="txtContraseña" CssClass="form-style" runat="server"></asp:TextBox><br />
                                                                        <i class="input-icon uil uil-dollar-alt"></i>
                                                                    </div>
                                                                </div>

                                                            </div>

                                                            <div class="row">
                                                                <div class="col">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="TipoPersonal">TipoPersonal</label>
                                                                        <asp:DropDownList ID="ddlTipoPersonal" CssClass="form-style" runat="server"></asp:DropDownList><br />
                                                                        <i class="input-icon uil uil-ruler"></i>
                                                                    </div>

                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="mt-3 form-group">
                                                                        <label for="Ciudad">Ciudad</label>
                                                                        <asp:DropDownList ID="ddlCiudad" CssClass="form-style" runat="server"></asp:DropDownList><br />
                                                                        <i class="input-icon uil-suitcase-alt"></i>
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

                            <%--
                            <div class="card">
                                <div class="card__image-container">
                                    <img class="card__image" src="Imagenes/Halo.PNG" alt="" />
                                </div>

                                <svg version="1.1" xmlns="http://www.w3.org/2000/svg">
                                    <filter id="blur">
                                        <feGaussianBlur stdDeviation="15" />
                                    </filter>
                                </svg>

                                <%--<svg class="card__svg" viewBox="0 0 800 500">

                                    <path d="M 0 100 Q 50 200 100 250 Q 250 400 350 300 C 400 250 550 150 650 300 Q 750 450 800 400 L 800 500 L 0 500" stroke="transparent" fill="#333" />
                                    <path class="card__line" d="M 0 100 Q 50 200 100 250 Q 250 400 350 300 C 400 250 550 150 650 300 Q 750 450 800 400" stroke="pink" stroke-width="3" fill="transparent" />
                                </svg>--%>

                            <%--<div class="card__content">
                                    <h1 class="card__title">Datos Personales</h1>

                                </div>--%>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:TextBox ID="txtId" runat="server" Style="color: #031529; background: #031529; border: none;"></asp:TextBox>


    <script>

        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "ListarPersonal1.aspx/mtdObtenerDatos",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = response.d;

                    $('#tblTrabajador').DataTable({
                        responsive: true,
                        data: data,
                        columns: [

                            { data: "Documento" },
                            { data: "Nombre" },
                            { data: "Apellido" },
                            { data: "Telefono" },
                            { data: "Estado" },
                            { data: "Email" },
                            { data: "Contraseña" },

                            {
                                data: null,
                                render: function (data, type, row) {
                                    return '<button type="button" class="btn btn-update btn-primary" data-id-personal="' + data.idPersonal + '" data-bs-toggle="modal" data-bs-target="#staticBackdrop"> Editar </button > ';
                                }
                            }

                        ]
                    });

                    $('#tblTrabajador').on('click', '.btn-delete', function () {
                        var id = $(this).data('idPersonal');
                        GuardarIdPersonal(id)


                    });

                    $('#tblTrabajador').on('click', '.btn-update', function () {
                        var id = $(this).data('idPersonal');
                        GuardarIdPersonal(id)
                        MostrarIdPersonal(id)
                    });


                },
                error: function (error) {
                    console.log(error);
                }
            });
        });

        function GuardarIdPersonal(id) {
            $.ajax({
                type: "POST",
                url: "ListarPersonal1.aspx/GuardarIdPersonal",
                data: JSON.stringify({ idPersonal: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Lógica adicional si es necesario
                },
                error: function (error) {
                    console.log(error);
                }
            });


        }

        function MostrarIdPersonal(id) {
            $.ajax({
                type: "POST",
                url: "ListarPersonal1.aspx/mtdMostarPersonal",
                data: JSON.stringify({ idPersonal: id }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    // Actualiza los campos de la ventana modal con los datos recibidos en la respuesta
                    var data = response.d;

                    document.getElementById('<%= txtId.ClientID %>').value = id;
                    document.getElementById('<%= txtDocumento.ClientID %>').value = data[0]["Documento"];
                    document.getElementById('<%= txtNombre.ClientID %>').value = data[0]["Nombre"];
                    document.getElementById('<%= txtApellido.ClientID %>').value = data[0]["Apellido"];
                    document.getElementById('<%= txtTelefono.ClientID %>').value = data[0]["Telefono"];
                    document.getElementById('<%= txtEstado.ClientID %>').value = data[0]["Estado"];
                    document.getElementById('<%= txtEmail.ClientID %>').value = data[0]["Email"];
                    document.getElementById('<%= txtContraseña.ClientID %>').value = data[0]["Contraseña"];
                    CargarIdCombo(data[0]["idTipoPersonal"]);
                    CargarIdComboCiudad(data[0]["idCiudad"]);
                    //$('#txtDocumento').val(data.Documento);
                    //$('#txtNombre').val(data.Nombre);
                    //$('#txtApellido').val(data.Apellido);
                    //$('#txtTelefono').val(data.Telefono);
                    //$('#txtEstado').val(data.Estado);
                    //$('#txtEmail').val(data.Email);
                    //$('#txtContraseña').val(data.Contraseña);
                    //$('#ddlTipoPersonal').val(data.idTipoPersonal);
                    //$('#ddlCiudad').val(data.idCiudad);
                    //CargarIdCombo(data.idTipoPersonal);
                    //CargarIdComboCiudad();
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
        function CargarIdCombo(idTipoPersonal) {
            var ddl = document.getElementById('<%= ddlTipoPersonal.ClientID%>')
            for (var i = 0; i < ddl.options.length; i++) {
                if (ddl.options[i].value === idTipoPersonal.toString()) {
                    ddl.seletedIndex = i;
                    break;
                }
            }
        }
        function CargarIdComboCiudad(idCiudad) {
            var ddl1 = document.getElementById('<%= ddlCiudad.ClientID%>')
            for (var i = 0; i < ddl1.options.length; i++) {
                if (ddl1.options[i].value === idCiudad.toString()) {
                    ddl1.seletedIndex = i;
                    break;
                }
            }
        }



    </script>

</asp:Content>
