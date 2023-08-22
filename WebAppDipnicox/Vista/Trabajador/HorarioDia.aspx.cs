using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;
using static System.Net.Mime.MediaTypeNames;

namespace WebAppDipnicox.Vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClHorarioD obHorario = new ClHorarioD();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ClDiaE> Dias = obHorario.mtdDias();
                rptDias.DataSource = Dias;
                rptDias.DataBind();
            }

        }
        protected void rptDias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            List<ClHorarioDiaE> ListHorDia = mtdSelect();

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chkDias = (CheckBox)e.Item.FindControl("chkDias");
                chkDias.ID = "chkDias_" + e.Item.ItemIndex.ToString();
                for (int i = 0; i < ListHorDia.Count; i++)
                {
                    if (chkDias.Text == ListHorDia[i].Dia)
                    {
                        chkDias.Checked = true;
                        chkDias.Enabled = false;
                        //Principal
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.ID = "col" + chkDias.Text;
                        div.Attributes["class"] = "col my-5 mx-3";
                        //div1
                        HtmlGenericControl div1 = new HtmlGenericControl("div");
                        div1.ID = "di" + chkDias.Text;
                        div1.Attributes["class"] = "Dias d-flex justify-content-center align-items-center";
                        Label lblDia = new Label();
                        lblDia.Text = ListHorDia[i].Dia;
                        div1.Controls.Add(lblDia);
                        //Div2
                        HtmlGenericControl div2 = new HtmlGenericControl("div");
                        div2.ID = "ho" + chkDias.Text;
                        div2.Attributes["class"] = "Horas mt-4";
                        div2.Attributes["style"] = "width: min-content";
                        //Hora Inicial
                        TextBox txtHoraIni = new TextBox();
                        txtHoraIni.TextMode = TextBoxMode.Time;
                        txtHoraIni.ID = "txtIni" + ListHorDia[i].Dia;
                        txtHoraIni.CssClass = "tex mb-2";
                        txtHoraIni.Text = ListHorDia[i].HoraInicio.ToString(@"hh\:mm");
                        div2.Controls.Add(txtHoraIni);
                        //Hora Final
                        TextBox txtHoraFin = new TextBox();
                        txtHoraFin.ID = "txtFin" + ListHorDia[i].Dia;
                        txtHoraFin.CssClass = "tex mb-2";
                        txtHoraFin.TextMode = TextBoxMode.Time;
                        txtHoraFin.Text = ListHorDia[i].HoraFinal.ToString(@"hh\:mm");
                        div2.Controls.Add(txtHoraFin);
                        //Buton
                        Button btn = new Button();
                        btn.CssClass = "guardar px-4 py-2 mb-4";
                        btn.Text = "Guardar";
                        div2.Controls.Add(btn);
                        // Agregar los divs al div principal
                        div.Controls.Add(div1);
                        div.Controls.Add(div2);
                        // Agregar el div principal al div de días
                        diho.Controls.Add(div);
                        break;
                    }

                }
                
            }
        }
        public List<ClHorarioDiaE> mtdSelect()
        {
            ClPersonalE obPersonal = HttpContext.Current.Session["Trabajador"] as ClPersonalE;
            ClHorarioL obHorario = new ClHorarioL();
            int idHorario = obHorario.mtdidHorario(obPersonal.idPersonal);
            List<ClHorarioDiaE> ListHorDia = obHorario.MtdListHoras(idHorario);
            return ListHorDia;
        }

        [WebMethod]
        public static int mtdAgregarHor(string txtInicio, string txtFinal, string dia)
        {
            ClPersonalE obPersonal = HttpContext.Current.Session["Trabajador"] as ClPersonalE;
            ClHorarioL obHorario = new ClHorarioL();
            int idHorario = obHorario.mtdidHorario(obPersonal.idPersonal);
            ClHorarioDiaE obDatos = new ClHorarioDiaE();
            obDatos.idHorario = idHorario;
            List<ClDiaE> Dias = obHorario.mtdListaDias();
            for (int i = 0; i < Dias.Count; i++)
            {
                string Di = Dias[i].Dia + " ";
                if (dia == Di)
                {
                    obDatos.idDia = Dias[i].idDia;
                    break;
                }
            }

            obDatos.HoraInicio = TimeSpan.Parse(txtInicio);
            obDatos.HoraFinal = TimeSpan.Parse(txtFinal);
            int registar = obHorario.mtdAgregarHoraDi(obDatos);
            return registar;
        }

    }
}