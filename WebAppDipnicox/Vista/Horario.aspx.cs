using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        //protected void chkDias_CheckedChanged(object sender, EventArgs e)
        //{
        //    CheckBox checkBox = (CheckBox)sender;
        //    string dato = checkBox.Text;
        //    if (checkBox.Checked)
        //    {
        //        rptSeman.DataSource = dato;
        //        rptSeman.DataBind();
        //    }
        //    else
        //    {
        //        rptSeman = null;
        //    }
        //    //}

        protected void rptDias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chkDias = (CheckBox)e.Item.FindControl("chkDias");
                chkDias.ID = "chkDias_" + e.Item.ItemIndex.ToString();
            }

        }

        //protected void btnHorario_Click(object sender, EventArgs e)
        //{
        //    string txt = "";
        //    List<ClDiaE> Dias = obHorario.mtdDias();
        //    txt = "txtIni" + Dias[0].Dia;

        //    //string imput = Request.Form["txtIniLunes "];
        //    //if (!string.IsNullOrEmpty(imput))
        //    //{

        //    //}

        //    TextBox txtField = FindControlRecursive(Page, "txtIniLunes ") as TextBox;

        //    if (txtField != null)
        //    {
        //        Console.WriteLine("SI que si");
        //    }
        //    //for (int i = 0; i < Dias.Count; i++)
        //    //{

        //    //}
        //}
        [WebMethod]
        public static int mtdAgregarHor(string txtInicio, string txtFinal, string dia)
        {
            ClHorarioL obHorario = new ClHorarioL();
            ClHorarioDiaE obDatos = new ClHorarioDiaE();

            obDatos.idHorario = 1;

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

            obDatos.HoraInicio = txtInicio;
            obDatos.HoraFinal = txtFinal;
            int registar = obHorario.mtdAgregarHoraDi(obDatos);
            return registar;
        }

    }
}