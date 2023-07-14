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
                List<string> list = obProductos.mtdMensaje();
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

        protected void repnotif_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType==ListItemType.Item||e.Item.ItemType==ListItemType.AlternatingItem)
            {
                string dato = (string)e.Item.DataItem;
                Label lblDato = (Label)e.Item.FindControl("lblnotifica");
                lblDato.Text = dato;
            }
        }
    }
}