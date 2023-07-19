using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox
{
    public partial class Site4 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClClienteE obdatos = (ClClienteE)Session["Usuario"];
            lblNombre.Text = obdatos.Nombre + " " + obdatos.Apellido;
        }
        [WebMethod]
        public static List<ClVentaE> mtdListarCarrito() 
        {
            ClVentaL obVenta = new ClVentaL();
            ClClienteE obCliente = HttpContext.Current.Session["Usuario"] as ClClienteE;
            ClVentaE obDatos = obVenta.mtdListarXid(obCliente.idCliente);
            int idVenta = obDatos.idVenta;
            ClProductoVentaL obProVen = new ClProductoVentaL();
            List<ClVentaE> ListaCarrito = obProVen.mtdList(idVenta);
            return ListaCarrito;
        }
    }

    
}