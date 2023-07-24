using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;
using WebAppDipnicox.Vista;

namespace WebAppDipnicox
{
    public partial class HomeCliente : System.Web.UI.Page
    {
        ClVentaL obVenta = new ClVentaL();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                ClTipoProducL obTipProd = new ClTipoProducL();
                List<ClTipoProducE> LisTipProd = obTipProd.mtdLisTipProd();
                repcard.DataSource = LisTipProd;
                repcard.DataBind();
                //TipVenta
                ClTipoVentaE objDatos = new ClTipoVentaE();
                ClTipoVentaL objTipoVentaL = new ClTipoVentaL();
                List<ClTipoVentaE> listaVenta = objTipoVentaL.mtdListarVenta(objDatos);
                ddlTipoVenta.DataSource = listaVenta;
                ddlTipoVenta.DataTextField = "nombreTipoVenta";
                ddlTipoVenta.DataValueField = "idTipoVenta";
                ddlTipoVenta.DataBind();
                ddlTipoVenta.Items.Insert(0, new ListItem("Tipo Venta:", "0"));
            }
        }
        [WebMethod]
        public static List<ClVentaE> mtdListarCarrito()
        {
            ClVentaL obVenta = new ClVentaL();
            ClClienteE obCliente = HttpContext.Current.Session["Usuario"] as ClClienteE;
            int idPerso = 0;
            ClVentaE obDatos = obVenta.mtdListarXid(idPerso, obCliente.idCliente);
            int idVenta = obDatos.idVenta;
            ClProductoVentaL obProVen = new ClProductoVentaL();
            List<ClVentaE> ListaCarrito = obProVen.mtdList(idVenta);
            return ListaCarrito;
        }
        [WebMethod]
        public static void mtdTotal(string total)
        {
            HttpContext.Current.Session["Total"] = total;
        }

        [WebMethod]
        public static void mtdEliminarCarro(int idProVen)
        {
            ClProductoVentaL obProdVen = new ClProductoVentaL();
            ClVentaL obVenta = new ClVentaL();
            ClClienteE obCliente = HttpContext.Current.Session["Usuario"] as ClClienteE;
            ClVentaE obDatos = obVenta.mtdListarXid(0, obCliente.idCliente);
            int idVenta = obDatos.idVenta;
            int Elimnar = obProdVen.mtdEliminar(idProVen);
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            ClClienteE obCliente = (ClClienteE)Session["Usuario"];
            ClVentaL objVentaL = new ClVentaL();
            ClVentaE obDatos = obVenta.mtdListarXid(0, obCliente.idCliente);
            int idVenta = obDatos.idVenta;
            obDatos = new ClVentaE();
            obDatos.idVenta = idVenta;
            obDatos.Estado = "Confirmar";
            obDatos.Total = int.Parse(Session["Total"].ToString());
            obDatos.idTipoVenta = int.Parse(ddlTipoVenta.SelectedValue.ToString());
            int Cofirmar = objVentaL.mtdConfirmarVenta(obDatos);
            HtmlGenericControl div = (HtmlGenericControl)FindControl("listaCarrito");
            if (Cofirmar != 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡!Pago Exitoso!', 'Su Pago se ha Sido hecho Con Exito', 'success')", true);
                if (div != null)
                {
                    div.Parent.Controls.Remove(div);
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Pago Negado!', 'Su Pago no ha Sido Confirmado', 'warning')", true);

            }
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            HttpContext.Current.Session["TipProductos"] = btn.CommandArgument;
            Response.Redirect("/Vista/Productos.aspx");
        }
    }
}