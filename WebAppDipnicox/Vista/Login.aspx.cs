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
                    Session["Asesor"] = obDatosP;
                    

                }
                else if (obDatosP.idTipoPersonal == 3)
                {
                    Session["Trabajador"] = obDatosP;
                    Response.Redirect("../AdminTrabaj.aspx");
                }
            }
            else
            {
                ClClienteL obCliente = new ClClienteL();
                ClClienteE obDatosC = obCliente.mtdLogin(Usuario, Clave);
                Session["Usuario"] = obDatosC;
                if (obDatosC!=null)
                {
                    Response.Redirect("../HomeCliente.aspx");
                }
                
            }
        }
    }
}