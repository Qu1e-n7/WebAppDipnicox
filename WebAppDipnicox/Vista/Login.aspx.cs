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
    public partial class Login11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Usuario = txtEmail.Text;
            string Clave = txtClave.Text;
            ClPersonalL obPersonal = new ClPersonalL();
            ClPersonalE obDatosP = obPersonal.mtdLogin(Usuario, Clave);
            if (obDatosP != null)
            {
                if (obDatosP.idTipoPersonal == 1)
                {
                    Session["Administrador"] = obDatosP;
                    Response.Redirect("../HomeAdmi.aspx");
                }
                else if (obDatosP.idTipoPersonal == 2)
                {
                    Session["Asesor"] = obDatosP.idPersonal + " " + obDatosP.Nombre + " " + obDatosP.Apellido + " " + obDatosP.Telefono;
                    Response.Redirect("");
                }
                else if (obDatosP.idTipoPersonal == 3)
                {
                    Session["Trabajador"] = obDatosP.idPersonal + " " + obDatosP.Nombre + " " + obDatosP.Apellido + " " + obDatosP.Telefono;
                    Response.Redirect("");
                }
            }
            else
            {
                ClClienteL obCliente = new ClClienteL();
                ClClienteE obDatosC = obCliente.mtdLogin(Usuario, Clave);

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Bienvenido " + obDatosC.Nombre + "!', 'Se ha iniciado Sesion', 'success')", true);
                Session["Usuario"] = obDatosC.idCliente + " " + obDatosC.Nombre + " " + obDatosC.Apellido + " " + obDatosC.Telefono;
                Response.Redirect("");
            }
        }
    }
}