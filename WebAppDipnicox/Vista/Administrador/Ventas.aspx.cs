using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class Ventas : System.Web.UI.Page
    {
        ClVentaL obVentas = new ClVentaL();
        private int idVenta;
        int idVen=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        [WebMethod]
        public static List<ClVentaE> Listar()
        {
            ClVentaL obVentas= new ClVentaL();
            List<ClVentaE> list = obVentas.mtdVentaConfirmadas();
            
            return list;
        }

        //[WebMethod]
        //public static void GuardarIdPersonal(int idVenta)
        //{

        //    var page = HttpContext.Current.Handler as Ventas;
        //    if (page != null)
        //    {
        //        page.idVenta = idVenta;
        //        HttpContext.Current.Session["idVenta"] = idVenta;

        //    }

        //}
        [WebMethod]
        public static List<ClVentaProductoE> Lista()
        {
            //int idVenta = Convert.ToInt32(HttpContext.Current.Session["idVenta"]);
            ClVentaL obVentas = new ClVentaL();
            List<ClVentaProductoE> list = obVentas.mtdVentaProd(9);

            return list;
        }

    }
}