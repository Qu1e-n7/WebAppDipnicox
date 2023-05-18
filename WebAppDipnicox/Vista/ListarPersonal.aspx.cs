using Newtonsoft.Json;
using Newtonsoft.JsonResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services;
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
           
            //GridView1.DataSource= ListaPersonal;
            //GridView1.DataBind();
        }

        [WebMethod]
        public static List<ClPersonalE> mtdObtenerDatos()
        {
            ClPersonalL obPersonalL = new ClPersonalL();
            ClPersonalE obdatos = new ClPersonalE();
            List<ClPersonalE> ListaPersonal = obPersonalL.mtdListarPersonal(obdatos);

            
            return ListaPersonal;
            
        }
    }
}