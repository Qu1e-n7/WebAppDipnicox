using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClPersonalE obdatos=(ClPersonalE) Session["Administrador"];
                ReDatos.Text = obdatos.Nombre + " " + obdatos.Apellido;
            }
        }
    }
}