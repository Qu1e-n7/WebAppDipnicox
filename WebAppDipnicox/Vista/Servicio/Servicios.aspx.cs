using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista.Servicio
{
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClServicioL objServicioL = new ClServicioL();
            List<ClServicioE> listaServicio = objServicioL.mtdListarServicio();
            repcard.DataSource = listaServicio;
            repcard.DataBind();


        }

        protected void repcard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //string valor = Session["Tipo"].ToString();
                //lblValor.Text = valor;

            }


        }

        [WebMethod]
        public static void Listar(string tipo)
        {
            HttpContext.Current.Session["Tipo"] = tipo;

        }
        [WebMethod]
        public static void Lista(string idSer)
        {
            HttpContext.Current.Session["idSer"] = idSer;

        }


        protected void btnAgregarValor_Click(object sender, EventArgs e)
        {
            List<ClServicioE> lista = new List<ClServicioE>();
            List<ClServicioE> lista2 = new List<ClServicioE>();
            foreach (RepeaterItem item in repcard.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    ClServicioE objE = new ClServicioE();
                    Label lblId = (Label)item.FindControl("idServicio");
                    objE.idServicio = int.Parse(lblId.Text);
                    Label valor = (Label)item.FindControl("Valor");
                    objE.Valor = int.Parse(valor.Text);
                    Label nombre = (Label)item.FindControl("Nombre");
                    objE.Nombre = nombre.Text;
                    Label descrip = (Label)item.FindControl("Descripcion");
                    objE.Descripcion = descrip.Text;

                    lista.Add(objE);

                }
            }
            int tipo = int.Parse(Session["Tipo"].ToString());

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idServicio == tipo)
                {
                    lista2.Add(lista[i]);
                }
            }

            lblValor.Text = lista2[0].Valor.ToString();

           

        }

        protected void btnConsignacion_Click(object sender, EventArgs e)
        {
            ClCotizacionL obCoti = new ClCotizacionL();
            ClCotizacionE obDatos = new ClCotizacionE();
            ClClienteE objDato = (ClClienteE)Session["Usuario"];



            obDatos.Fecha = name.Text;
            obDatos.Descripcion = bio.Text;
            obDatos.Estado = "Pendiente";
            obDatos.Total = Session["Tipo"].ToString();
            obDatos.idCliente = objDato.idCliente;
            int idPersonal = int.Parse(ddlServicios.SelectedValue.ToString());

            int Registrar = obCoti.mtdRegistroVentas(obDatos, idPersonal);
            if (Registrar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Cotizacion No Registrada!', 'Su Cotizacion no ha Sido Registrado Con Exito', 'warning')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Cotizacion Registrado!', 'Su Cotizacion ha Sido Registrado', 'success')", true);

            }
        }

       
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            int tipo1 = int.Parse(Session["idSer"].ToString());
            ClPersonalL objServicio = new ClPersonalL();
            List<ClPersonalE> listaServicio1 = new List<ClPersonalE>();
            listaServicio1 = objServicio.mtdListaServicio(tipo1);

            ddlServicios.DataSource = listaServicio1;
            ddlServicios.DataTextField = "Nombre";
            ddlServicios.DataValueField = "idPersonal";
            ddlServicios.DataBind();
            ddlServicios.Items.Insert(0, new ListItem("Trabajadores:", "0"));
        }

        protected void repcard_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }

        protected void btnCargar_Command(object sender, CommandEventArgs e)
        {
            
           
        }
    }
}