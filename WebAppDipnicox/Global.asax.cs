using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebAppDipnicox
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Administrador"] = "";
            Session["Asesor"] = "";
            Session["Trabajador"] = "";
            Session["Usuario"] = "";
            Session["Tipo"] = 0;
            Session["Total"] = 0;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["Administrador"] = "";
            Session["Asesor"] = "";
            Session["Trabajador"] = "";
            Session["Usuario"] = "";
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}