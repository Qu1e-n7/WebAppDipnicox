using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class ListaProductos : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            
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