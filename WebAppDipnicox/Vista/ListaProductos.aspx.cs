using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        ClProductosL obProductos = new ClProductosL();
        ClProductosE obDatos = new ClProductosE();
        ClTipoProducL obTipProd = new ClTipoProducL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ClTipoProducE> lisTipProd = obTipProd.mtdLisTipProd();
                ddlTipProductos.DataSource = lisTipProd;
                ddlTipProductos.DataTextField = "Nombre";
                ddlTipProductos.DataValueField = "idTipoProduc";
                ddlTipProductos.DataBind();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            obDatos.idProducto = int.Parse(txtDato.Text);
            obDatos.Codigo = txtCodigo.Text;
            obDatos.Nombre = txtNombre.Text;
            obDatos.Descripcion = txtDescrip.Text;
            obDatos.Valor = int.Parse(txtValor.Text);
            obDatos.Cantidad = int.Parse(txtCantidad.Text);
            obDatos.UnidadMed = txtMedida.Text;
            obDatos.idTipoProducto = int.Parse(ddlTipProductos.SelectedValue.ToString());  
            int Actualizar = obProductos.mtdActualizar(obDatos);
            if (Actualizar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Actualizar Producto!', 'Se ha Actualizado el producto " + obDatos.Codigo + "', 'success')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int Eliminar = obProductos.mtdEliminar(int.Parse(txtDato.Text));
            if (Eliminar==1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Eliminar Producto!', 'Se ha Actualizado el producto "+ obDatos.Codigo + "', 'warning')", true);
            }
        }


        [WebMethod]
        public static List<ClProductosE> cargardatos(int id)
        {
            var Page = HttpContext.Current.Handler as ListaProductos;
            List<ClProductosE> list = Page.obProductos.mtdListaXDato(id);
            return list;
        }

        [WebMethod]
        public static List<ClProductosE> mtdLista()
        {
            ClProductosL obProductos = new ClProductosL();
            List<ClProductosE> ListaProductos = obProductos.mtdListaProductos();
            return ListaProductos;
        }
    }
}