using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox
{
    public partial class AdminTrabaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClProductosL obproduc=new ClProductosL();
            List<ClProductosE> listProdu = obproduc.mtdListaProductos();
            repcard.DataSource = listProdu;
            repcard.DataBind();
        }
    }
}