using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;
using WebAppDipnicox.Vista;

namespace WebAppDipnicox
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        ClProductosL obProductos = new ClProductosL();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ClNotificacionE> list = obProductos.mtdMensaje();
            List<ClNotificacionE> NotifiServ = new List<ClNotificacionE>();
            ClNotificacionE obNotifi = null;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Titulo == "Servicio")
                {
                    obNotifi = new ClNotificacionE();
                    obNotifi.Titulo = list[i].Titulo;
                    obNotifi.Descripcion = list[i].Descripcion;
                    NotifiServ.Add(obNotifi);
                }
            }
            repnotif.DataSource = NotifiServ;
            repnotif.DataBind();
            int count = NotifiServ.Count;
            var miDiv = (HtmlGenericControl)FindControl("notificac");
            miDiv.Attributes["data-count"] = count.ToString();
        }
    }
}