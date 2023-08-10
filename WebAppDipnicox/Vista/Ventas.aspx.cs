using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        [WebMethod]
        public static List<ClVentaE> Listar()
        {
            ClVentaL obVentas= new ClVentaL();
            List<ClVentaE> list = obVentas.mtdVentaConfirmadas();
            return list;
        }
        [WebMethod]
        public static string Nombres (int idCliente, int idTrabajador)
        {
            string Nombres = "";
            List<ClClienteE> ListaCliente = new List<ClClienteE>();
            ClClienteL obCliente = new ClClienteL();
            ClPersonalL obPersonal = new ClPersonalL();
            if (idCliente!=0)
            {
                Nombres = obCliente.ListaNombre(idCliente);
            }else if (idTrabajador!=0) {
                Nombres = obPersonal.mtdNombres(idTrabajador);
            }
            return Nombres;
        }
    }
}