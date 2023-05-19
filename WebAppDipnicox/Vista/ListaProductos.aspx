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
    <div style="width: 1100px">
        <table id="tblUsua" class="table">
            <thead>
                <tr>
                    <th>Codigo</th>
                    <th>Nombre</th>
                    <th>Descripcion</th>
                    <th>Valor</th>
                    <th>Cantidad</th>
                    <th>Medida</th>
                    <th>Tipo Producto</th>
                    <th>Opciones</th>
                </tr>
            </thead>
            <tbody></tbody>
            <tfoot>
            </tfoot>
        </table>
    </div>
    <!-- Modal -->
<div class="modal fade" id="ModalActua" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                                                        <label for="Codigo">Codigo</label>
                                                        <asp:TextBox ID="txtCodigo" CssClass="form-style" runat="server"></asp:TextBox>
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
                                            </div>
                                            <div class="mt-3 form-group">
                                                <label for="Descripcion">Descripcion</label>
                                                <asp:TextBox ID="txtDescrip" TextMode="MultiLine" CssClass="form-style" style="height:110px" runat="server"></asp:TextBox>
                                                <i class="input-icon uil uil-align-alt"></i>
                                            </div>

                                            <div class="row">
                                                <div class="col">
                                                    <div class="mt-3 form-group">
                                                        <label for="Valor">Valor Unitario</label>
                                                        <asp:TextBox ID="txtValor" Cssclass="form-style" runat="server"></asp:TextBox>
                                                        <i class="input-icon uil uil-dollar-alt"></i>
                                                    </div>

                                                </div>
                                                <div class="col-md-5">
                                                    <div class="mt-3 form-group">
                                                        <label for="Cantidad">Cantidad</label>
                                                        <asp:TextBox ID="txtCantidad" Cssclass="form-style" runat="server"></asp:TextBox>
                                                        <i class="input-icon uil uil-object-group"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col">
                                                    <div class="mt-3 form-group">
                                                        <label for="medida">Unidad de Medida</label>
                                                        <asp:TextBox ID="txtMedida" Cssclass="form-style" runat="server"></asp:TextBox>
                                                        <i class="input-icon uil uil-ruler"></i>
                                                    </div>

                                                </div>
                                                <div class="col-md-6">
                                                    <div class="mt-3 form-group">
                                                        <label for="TipProd">Tipo de Producto</label>
                                                        <asp:DropDownList ID="ddlTipProductos" Cssclass="form-style" runat="server"></asp:DropDownList>
                                                        <i class="input-icon uil-suitcase-alt"></i>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:Button ID="btnActualizar" Cssclass="mt-5 mx-5 btn btn-primary" runat="server" Text="Actualizar" />
                                            <asp:Button ID="btnEliminar" Cssclass="mt-5 mx-5 btn btn-primary" runat="server" Text="Eliminar" />
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
                url: "ListaProductos.aspx/mtdLista",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var data = response.d;
                    console.log(data);
                    $('#tblUsua').DataTable({
                        data: data,
                        columns: [
                            { data: "Codigo" },
                            { data: "Nombre" },
                            { data: "Descripcion" },
                            { data: "Valor" },
                            { data: "Cantidad" },
                            { data: "UnidadMed" },
                            { data: "idTipoProducto" },
                            {
                                data: null,
                                render: function (data, type, row) {
                                    return '<button  class="btn btn-primary btn-delete" data-id="' + data.idProducto + '" data-bs-toggle="modal" data-bs-target="#ModalActua" >Actualizar</button>'
                                }
                            }
                        ],
                    });
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });

    </script>
</asp:Content>
