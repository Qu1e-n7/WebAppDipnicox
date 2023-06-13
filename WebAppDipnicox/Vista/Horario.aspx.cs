using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Vista
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClHorarioD obHorario =new ClHorarioD();
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
        //    CheckBox checkBox=(CheckBox)sender;
        //    string dato=checkBox.Text;
        //    if (checkBox.Checked)
        //    {
        //        rptSeman.DataSource = dato;
        //        rptSeman.DataBind();
        //    }
        //    else
        //    {
        //        rptSeman = null;
        //    }
        //}

        protected void rptDias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chkDias = (CheckBox)e.Item.FindControl("chkDias");
                chkDias.ID = "chkDias_" + e.Item.ItemIndex.ToString();
            }

        }
    }
}