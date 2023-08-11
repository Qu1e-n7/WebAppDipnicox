using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class ListHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClPersonalE obdatos = (ClPersonalE)Session["Trabajador"];
            }
        }
        [WebMethod]
        public static string mtdAgregarHorario()
        {
            ClPersonalE obPersonal = HttpContext.Current.Session["Trabajador"] as ClPersonalE;
            ClHorarioL obHorario = new ClHorarioL();
            int idHorario = obHorario.mtdidHorario(obPersonal.idPersonal);
            HttpContext.Current.Session["idHorario"]=idHorario;
            string ruta = "/Vista/Trabajador/HorarioDia.aspx";
            if (idHorario == 0)
            {
                ClHorarioE obDatos = new ClHorarioE();
                obDatos.FechaInicio = DateTime.Parse("1900-01-01");
                obDatos.FechaFinal = DateTime.Parse("1900-01-01");
                obDatos.idPersonal = obPersonal.idPersonal;
                int registro = obHorario.mtdAgregarHorario(obDatos);
            }

            return ruta;

        }


        [WebMethod]
        public static List<ClHorarioDiaE> mtdListHorario()
        {
            ClPersonalE obPersonal = HttpContext.Current.Session["Trabajador"] as ClPersonalE;
            ClHorarioL obHorario = new ClHorarioL();
            int idHorario = obHorario.mtdidHorario(obPersonal.idPersonal);
            List<ClHorarioDiaE> ListHoario = obHorario.MtdListHoras(idHorario);
            return ListHoario;
        }
        [WebMethod]
        public static ClHorarioDiaE mtdListHoraDia(int id)
        {
            
            ClHorarioL obHorario = new ClHorarioL();
            ClHorarioDiaE obDatos = new ClHorarioDiaE();
            obDatos = obHorario.MtdListHoraDia(id);
            return obDatos;   
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            
            ClHorarioL obHorario = new ClHorarioL();
            ClHorarioDiaE obDatos = new ClHorarioDiaE();
            obDatos.idHorarioDia = int.Parse(txtid.Text);
            obDatos.HoraInicio =TimeSpan.Parse(txtHoraIni.Text);
            obDatos.HoraFinal =TimeSpan.Parse(txtHoraFin.Text);
            int Actu = obHorario.mtdActHorarioDia(obDatos);
            if (Actu!=0)
            {
                HtmlGenericControl div = (HtmlGenericControl)FindControl("diho");
                if (div!=null)
                {
                    div.Attributes["class"] = "horar ms-5 pt-3 d-none";
                }
            }

        }
    }
}