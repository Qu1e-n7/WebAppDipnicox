<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ActProductos.aspx.cs" Inherits="WebAppDipnicox.Vista.ActProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe"
        crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://unicons.iconscout.com/release/v4.0.8/css/line.css">
    <link href="Css/Actualiza.css" rel="stylesheet" />
    <script src="SweetAlert/Scripts/sweetalert.min.js"></script>
    <link href="SweetAlert/Styles/sweetalert.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                            <asp:Button ID="btnActualizar" Cssclass="mt-5 mx-5 btn btn-primary" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
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
    <!-- Modal -->
<div class="modal fade " id="ModalActua" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Dato</h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
        </div>
        <div class="modal-body">
          <p>Aquí va tu dato</p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
        </div>
      </div>
    </div>
  </div>
    <script>
    function AbrirModal() {
        $('#ModalActua').modal('show'); // Reemplaza "miModal" con el ID de tu ventana modal
    }
    </script>
</asp:Content>
