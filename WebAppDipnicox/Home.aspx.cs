using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClTipoProducL obTipProd = new ClTipoProducL();
                List<ClTipoProducE> LisTipProd = obTipProd.mtdLisTipProd();
                repcard.DataSource = LisTipProd;
                repcard.DataBind();
            }
            
        }
    }
}