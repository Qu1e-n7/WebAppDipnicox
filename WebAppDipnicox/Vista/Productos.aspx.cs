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

namespace WebAppDipnicox.Vista
{
    public partial class Productos : System.Web.UI.Page
    {
        ClVentaL obVenta = new ClVentaL();
        ClProductosE obDatos = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            int TipoProd = int.Parse(Session["TipProductos"].ToString());
            //Cards
            ClProductosL obproduc = new ClProductosL();
            List<ClProductosE> listProdu = obproduc.mtdListaProductos();
            List<ClProductosE> listTipProdu = new List<ClProductosE>();
            if (TipoProd!=0)
            {
                for (int i = 0; i < listProdu.Count; i++)
                {
                    if (listProdu[i].idTipoProducto == TipoProd)
                    {
                        obDatos = new ClProductosE();
                        obDatos.idProducto = listProdu[i].idProducto;
                        obDatos.Codigo = listProdu[i].Codigo;
                        obDatos.Nombre = listProdu[i].Nombre;
                        obDatos.Descripcion = listProdu[i].Descripcion;
                        obDatos.Image = listProdu[i].Image;
                        obDatos.Valor = listProdu[i].Valor;
                        obDatos.Cantidad = listProdu[i].Cantidad;
                        obDatos.UnidadMed = listProdu[i].UnidadMed;
                        obDatos.idTipoProducto = listProdu[i].idTipoProducto;
                        listTipProdu.Add(obDatos);
                    }
                }
                repcard.DataSource = listTipProdu;
                repcard.DataBind();
            }
            else
            {
                repcard.DataSource = listProdu;
                repcard.DataBind();
            }

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
        [WebMethod]
        public static void mtdAgregar(int idProd)
        {
            ClClienteE obCliente  = HttpContext.Current.Session["Usuario"] as ClClienteE;
            ClVentaL obVenta = new ClVentaL();
            ClVentaE obDatos = obVenta.mtdListarXid(0, obCliente.idCliente);
            int idVenta = obDatos.idVenta;
            List<ClVentaE> ListaCarrito = new List<ClVentaE>();
            if (idVenta == 0)
            {
                obDatos = new ClVentaE();
                obDatos.Estado = "Pendiente";
                obDatos.idCliente = obCliente.idCliente;
                int AgregVenta = obVenta.mtdRegistrarVenta(obDatos);
                if (AgregVenta!=0)
                {
                    ClProductoVentaL obProVen = new ClProductoVentaL();
                    obDatos = new ClVentaE();
                    obDatos.idVenta = idVenta;
                    obDatos.idProducto = idProd;
                    obDatos.CantidadVen = 1;
                    int RegProducVen = obProVen.mtdReg(obDatos);
                }
            }
            else
            {
                ClProductoVentaL obProVen = new ClProductoVentaL();
                obDatos = new ClVentaE();
                obDatos.idVenta = idVenta;
                obDatos.idProducto = idProd;
                obDatos.CantidadVen = 1;
                int RegProducVen = obProVen.mtdReg(obDatos);
            }
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
            obDatos.idTipoVenta = 1;
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
    }
}