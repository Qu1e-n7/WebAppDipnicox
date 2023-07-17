using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            if (!Page.IsPostBack)
            {
                ClTipoVentaE objDatos = new ClTipoVentaE();
                ClTipoVentaL objTipoVentaL = new ClTipoVentaL();
                List<ClTipoVentaE> listaVenta = objTipoVentaL.mtdListarVenta(objDatos);
                ddlTipoVenta.DataSource = listaVenta;
                ddlTipoVenta.DataTextField = "nombreTipoVenta";
                ddlTipoVenta.DataValueField = "idTipoVenta";
                ddlTipoVenta.DataBind();
                ddlTipoVenta.Items.Insert(0, new ListItem("Tipo Venta:", "0"));

            }
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

        protected void ddlTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string opcionSeleccionada = ddlTipoVenta.SelectedValue;


            //if (opcionSeleccionada == "1")
            //{
            //    panelContenedor.Visible = true;
            //    btnPagar.Visible = false;
            //}
            //else if (opcionSeleccionada == "2")
            //{
            //    panelContenedor.Visible = false;
            //    btnPagar.Visible = true;
            //}
            //else
            //{
            //    panelContenedor.Visible = false;
            //    btnPagar.Visible = false;
            //}



            //UpdatePanel2.Update();
        }

        protected void btnBoton_Click(object sender, EventArgs e)
        {
            ClVentaL objVentaL = new ClVentaL();
            ClVentaE obDatos = new ClVentaE();
            ClPersonalE objDato = (ClPersonalE)Session["Trabajador"];

            obDatos.Estado = "Inactivo";
            //obDatos.Total = contadorPrecio.InnerText;
            obDatos.idCliente = 1;
            obDatos.idPersonal = objDato.idPersonal;
            obDatos.idTipoVenta = int.Parse(ddlTipoVenta.SelectedValue.ToString());
            int Registrar = objVentaL.mtdRegistrarVenta(obDatos);
            if (Registrar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Servicio Registrado!', 'Su Servicio ha Sido Registrado Con Exito', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Producto No Registrado!', 'Su Producto no ha Sido Registrado', 'warning')", true);

            }
        }
    }
}