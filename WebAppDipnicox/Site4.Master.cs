using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    public partial class Site4 : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ClClienteE obdatos = (ClClienteE)Session["Usuario"];
            lblNombre.Text = obdatos.Nombre + " " + obdatos.Apellido;
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = "";
            Response.Redirect("Home.aspx");
        }
    }


}