using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox
{
    public partial class Site4 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClClienteE obdatos = (ClClienteE)Session["Usuario"];
            lblNombre.Text = obdatos.Nombre + " " + obdatos.Apellido;
        }
    }
}