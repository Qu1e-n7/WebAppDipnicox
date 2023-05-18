using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class ListarPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClPersonalL obPersonalL = new ClPersonalL();
            ClPersonalE obdatos =new ClPersonalE();
            List<ClPersonalE> ListaPersonal = obPersonalL.mtdListarPersonal();
            GridView1.DataSource= ListaPersonal;
            GridView1.DataBind();
        }
    }
}