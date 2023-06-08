using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista.Servicio
{
    public partial class IncluirServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClServicioL objServicioL = new ClServicioL();
                List<ClServicioE> listaServicio = new List<ClServicioE>();
                listaServicio = objServicioL.mtdListarServicio();

                ddlServicio.DataSource = listaServicio;
                ddlServicio.DataTextField = "Nombre";
                ddlServicio.DataValueField = "idServicio";
                ddlServicio.DataBind();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClServicioE objDatos = new ClServicioE();
            ClPersonalE objDatos1 = new ClPersonalE();

            objDatos.idServicio = int.Parse(ddlServicio.SelectedValue.ToString());
            objDatos1.idPersonal = 5;

            ClServicioL objServicioL = new ClServicioL();

            int Actuliza = objServicioL.mtdAculizarServicio(objDatos,objDatos1);
            if (Actuliza ==1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Agregado " + objDatos.Nombre + "!', 'Se ha Agregado el Servicio', 'success')", true);
            }
        }
    }
}