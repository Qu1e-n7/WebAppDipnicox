using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;
using WebAppDipnicox.Vista;

namespace WebAppDipnicox
{
    public partial class AdminTrabaj : System.Web.UI.Page
    {
        ClVentaL obVenta = new ClVentaL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClPersonalE obPersonal = (ClPersonalE)Session["Trabajador"];
                //Cards
                ClProductosL obproduc = new ClProductosL();
                List<ClProductosE> listProdu = obproduc.mtdListaProductos();
                repcard.DataSource = listProdu;
                repcard.DataBind();
                //Contador
                //int count = ListaCarrito.Count;
                //lblcontador.Text = count.ToString();
                //mtdTotalPagar(ListaCarrito);
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
        public static List<ClVentaE> mtdAgregar(int idProd)
        {
            var page = HttpContext.Current.Handler as AdminTrabaj;
            ClPersonalE obPersonal = HttpContext.Current.Session["Trabajador"] as ClPersonalE;
            ClVentaL obVenta = new ClVentaL();
            int idcliente=1;
            ClVentaE obDatos = obVenta.mtdListarXid(obPersonal.idPersonal,idcliente);
            int idVenta = obDatos.idVenta;
            List<ClVentaE> ListaCarrito = new List<ClVentaE>();
            if (obDatos == null)
            {
                obDatos = new ClVentaE();
                obDatos.Estado = "Pendiente";
                obDatos.idPersonal = obPersonal.idPersonal;
                int AgregVenta = obVenta.mtdRegistrarVenta(obDatos);
            }
            else
            {

                ClProductoVentaL obProVen = new ClProductoVentaL();
                obDatos = new ClVentaE();
                obDatos.idVenta = idVenta;
                obDatos.idProducto = idProd;
                obDatos.CantidadVen = 1;
                int RegProducVen = obProVen.mtdReg(obDatos);
                if (RegProducVen != 0)
                {
                    ListaCarrito = obProVen.mtdList(idVenta);
                        
                }
            }
            return ListaCarrito;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;

            ClProductosL objProductoL = new ClProductosL();
            ClProductosE objDatos = new ClProductosE();
            List<ClProductosE> Busqueda = objProductoL.mtdBuscar(nombre);
            repcard.DataSource = Busqueda;
            repcard.DataBind();


        }

        [WebMethod]
        public static List<ClVentaE> mtdListProdVen()
        {
            ClVentaL obVenta = new ClVentaL();
            ClPersonalE obPersonal = HttpContext.Current.Session["Trabajador"] as ClPersonalE;
            int idcliente=0;
            ClVentaE obDatos = obVenta.mtdListarXid(obPersonal.idPersonal,idcliente);
            int idVenta = obDatos.idVenta;
            ClProductoVentaL obProVen = new ClProductoVentaL();
            List<ClVentaE> ListaCarrito = obProVen.mtdList(idVenta);
            return ListaCarrito;
        }
           


        [WebMethod]
        public static void Listar(string tipo)
        {
            HttpContext.Current.Session["Tipo"] = tipo;
        }
        [WebMethod]
        public static void mtdTotal(string total)
        {
            HttpContext.Current.Session["Total"]  = total;
        }

        protected void repcard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Button agregarAlCarritoButton = (Button)e.Item.FindControl("btnAgregar");
            //    agregarAlCarritoButton.OnClientClick = "agregarAlCarritoClicked(event)";
            //}
        }

        protected void ddlTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string opcionSeleccionada = ddlTipoVenta.SelectedValue;


            //if (opcionSeleccionada == "1")
            //{
            //    panelContenedor.Visible = true;
            //    btnPagar.Visible = false;
            //}
            //else if (opcionSeleccionada == "2")
            //{
            //    panelContenedor.Visible = false;
            //    btnPagar.Visible = true;
            //}
            //else
            //{
            //    panelContenedor.Visible = false;
            //    btnPagar.Visible = false;
            //}



            //UpdatePanel2.Update();
        }

        protected void btnBoton_Click(object sender, EventArgs e)
        {
            ClVentaL objVentaL = new ClVentaL();
            ClVentaE obDatos = new ClVentaE();
            ClPersonalE objDato = (ClPersonalE)Session["Trabajador"];
            obDatos.Estado = "Inactivo";
            //obDatos.Total = contadorPrecio.InnerText;
            obDatos.idCliente = 1;
            obDatos.idPersonal = objDato.idPersonal;
            obDatos.idTipoVenta = int.Parse(ddlTipoVenta.SelectedValue.ToString());
            int Registrar = objVentaL.mtdRegistrarVenta(obDatos);
            if (Registrar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡!Pago Exitoso!', 'Su Pago se ha Sido hecho Con Exito', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Pago Negado!', 'Su Pago no ha Sido Confirmado', 'warning')", true);

            }
        }
        [WebMethod]
        public static List<ClVentaE> mtdEliminarCarro(int idProVen)
        {
            ClProductoVentaL obProdVen = new ClProductoVentaL();
            ClVentaL obVenta = new ClVentaL();
            ClPersonalE obPersonal = HttpContext.Current.Session["Trabajador"] as ClPersonalE;
            ClVentaE obDatos = obVenta.mtdListarXid(obPersonal.idPersonal,0);
            int idVenta = obDatos.idVenta;
            List<ClVentaE> ListaCarrito = new List<ClVentaE>();
            int Elimnar = obProdVen.mtdEliminar(idProVen);
            if (Elimnar!=0)
            {
                ListaCarrito = obProdVen.mtdList(idVenta);

            }
            return ListaCarrito;
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            ClPersonalE obPersonal = (ClPersonalE)Session["Trabajador"];
            ClVentaL objVentaL = new ClVentaL();
            ClVentaE obDatos = obVenta.mtdListarXid(obPersonal.idPersonal,0);
            int idVenta = obDatos.idVenta;
            obDatos=new ClVentaE();
            obDatos.idVenta = idVenta;
            obDatos.Estado = "Confirmar";
            obDatos.Total = int.Parse(Session["Total"].ToString());
            obDatos.idTipoVenta = int.Parse(ddlTipoVenta.SelectedValue.ToString());
            int Cofirmar = objVentaL.mtdConfirmarVenta(obDatos);
            HtmlGenericControl div = (HtmlGenericControl)FindControl("listaCarrito");
            if (Cofirmar!=0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡!Pago Exitoso!', 'Su Pago se ha Sido hecho Con Exito', 'success')", true);
                if (div!=null)
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