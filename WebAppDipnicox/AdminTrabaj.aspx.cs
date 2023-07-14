using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox
{
    public partial class AdminTrabaj : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClProductosL obproduc = new ClProductosL();
            List<ClProductosE> listProdu = obproduc.mtdListaProductos();
            repcard.DataSource = listProdu;
            repcard.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;

            ClProductosL objProductoL = new ClProductosL();
            ClProductosE objDatos = new ClProductosE();
            List<ClProductosE> Busqueda = objProductoL.mtdBuscar(nombre);
            repcard.DataSource = Busqueda;
            repcard.DataBind();


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            List<ClProductosE> listaProducto = new List<ClProductosE>();
            List<ClProductosE> listaProducto1 = new List<ClProductosE>();

            foreach (RepeaterItem item in repcard.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    ClProductosE objProdcutosE = new ClProductosE();

                    Label lblId = (Label)item.FindControl("idProducto");
                    objProdcutosE.idProducto = int.Parse(lblId.Text);

                    //Image imgProducto = (Image)item.FindControl("img");
                    //objProdcutosE.Imagen = imgProducto.ImageUrl;

                    Label lblNombre = (Label)item.FindControl("Nombre");
                    objProdcutosE.Nombre = lblNombre.Text;

                    Label lblPrecio = (Label)item.FindControl("Valor");
                    objProdcutosE.Valor = int.Parse(lblPrecio.Text);

                    listaProducto.Add(objProdcutosE);

                }
            }

            int tipo = int.Parse(Session["Tipo"].ToString());

            for (int i = 0; i < listaProducto.Count; i++)
            {
                if (listaProducto[i].idProducto == tipo)
                {
                    listaProducto1.Add(listaProducto[i]);
                }


            }
            string productosJson = JsonConvert.SerializeObject(listaProducto1);

            ScriptManager.RegisterStartupScript(this, GetType(), "app", $"agregarAlCarrito('{productosJson}')", true);



        }

        [WebMethod]
        public static void Listar(string tipo)
        {
            HttpContext.Current.Session["Tipo"] = tipo;
        }

        protected void repcard_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Button agregarAlCarritoButton = (Button)e.Item.FindControl("btnAgregar");
            //    agregarAlCarritoButton.OnClientClick = "agregarAlCarritoClicked(event)";
            //}
        }
    }
}