using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        ClProductosL obProductos =new ClProductosL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  ClPersonalE obdatos=(ClPersonalE) Session["Administrador"];
                ReDatos.Text = obdatos.Nombre + " " + obdatos.Apellido;
                List<ClNotificacionE> list = obProductos.mtdMensaje();
                if (list!=null)
                {
                    repnotif.DataSource = list;
                    repnotif.DataBind();
                    int count = list.Count;
                    var miDiv = (HtmlGenericControl)FindControl("notificac");
                    miDiv.Attributes["data-count"] = count.ToString();
                }
                
                
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["Administrador"] = "";
            Response.Redirect("~/Home.aspx");
        }
    }
}