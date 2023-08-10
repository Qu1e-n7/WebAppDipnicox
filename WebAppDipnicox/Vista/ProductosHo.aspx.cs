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
    public partial class ProductosHo : System.Web.UI.Page
    {
        ClVentaL obVenta = new ClVentaL();
        ClProductosE obDatos = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int TipoProd = int.Parse(Session["TipProductos"].ToString());
                //Cards
                ClProductosL obproduc = new ClProductosL();
                List<ClProductosE> listProdu = obproduc.mtdListaProductos();
                List<ClProductosE> listTipProdu = new List<ClProductosE>();
                if (TipoProd != 0)
                {
                    for (int i = 0; i < listProdu.Count; i++)
                    {
                        if (listProdu[i].idTipoProducto == TipoProd)
                        {
                            obDatos = new ClProductosE();
                            obDatos.idProducto = listProdu[i].idProducto;
                            obDatos.Codigo = listProdu[i].Codigo;
                            obDatos.Nombre = listProdu[i].Nombre;
                            obDatos.Descripcion = listProdu[i].Descripcion;
                            //obDatos.Image = datosread["Imagen"].ToString();
                            obDatos.Valor = listProdu[i].Valor;
                            obDatos.Cantidad = listProdu[i].Cantidad;
                            obDatos.UnidadMed = listProdu[i].UnidadMed;
                            obDatos.idTipoProducto = listProdu[i].idTipoProducto;
                            listTipProdu.Add(obDatos);
                        }
                    }
                    repcard.DataSource = listTipProdu;
                    repcard.DataBind();
                    Session["TipProductos"] = 0;
                }
                else
                {
                    repcard.DataSource = listProdu;
                    repcard.DataBind();
                }
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Vista/Login.aspx");
        }
    }
}