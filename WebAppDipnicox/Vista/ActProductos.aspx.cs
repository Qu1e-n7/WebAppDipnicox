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
    public partial class ActProductos : System.Web.UI.Page
    {
        ClProductosL obProductos = new ClProductosL();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int id = 1;
                List<ClProductosE> list = obProductos.mtdListaXDato(id);
                if (list.Count>0)
                {
                    ClProductosE obDatos= list[0];
                    txtCodigo.Text = obDatos.Codigo;
                    txtNombre.Text = obDatos.Nombre;
                    txtDescrip.Text = obDatos.Descripcion;
                    txtValor.Text = obDatos.Valor.ToString();
                    txtCantidad.Text = obDatos.Cantidad.ToString();
                    txtMedida.Text = obDatos.UnidadMed;
                    ddlTipProductos.DataValueField = obDatos.idProducto.ToString();
                }
                
            }
        }

    }
}