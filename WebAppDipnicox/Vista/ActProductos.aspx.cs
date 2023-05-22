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
        ClProductosE obDatos = new ClProductosE();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    lis(1);
                
            }
        }
        public void lis(int id)
        {
            List<ClProductosE> list = obProductos.mtdListaXDato(id);
            ClTipoProducL obTipProduc = new ClTipoProducL();
            List<ClTipoProducE> listaTipoPersonal = obTipProduc.mtdLisTipProd();
            ddlTipProductos.DataSource = listaTipoPersonal;
            ddlTipProductos.DataTextField = "Nombre";
            ddlTipProductos.DataValueField = "idTipoProduc";
            
            
            if (list.Count > 0)
            {
                obDatos = list[0];
                txtCodigo.Text = obDatos.Codigo;
                txtNombre.Text = obDatos.Nombre;
                txtDescrip.Text = obDatos.Descripcion;
                txtValor.Text = obDatos.Valor.ToString();
                txtCantidad.Text = obDatos.Cantidad.ToString();
                txtMedida.Text = obDatos.UnidadMed;
                if (ddlTipProductos.Items.FindByValue(obDatos.idTipoProducto.ToString()) == null)
                {
                    ddlTipProductos.SelectedValue = obDatos.idTipoProducto.ToString();
                    ddlTipProductos.DataBind();

                }
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            obDatos.idProducto = 1;
            obDatos.Codigo = txtCodigo.Text;
            obDatos.Nombre = txtNombre.Text;
            obDatos.Descripcion = txtDescrip.Text;
            obDatos.Valor = int.Parse(txtValor.Text);
            obDatos.Cantidad = int.Parse(txtCantidad.Text);
            obDatos.UnidadMed = txtMedida.Text;
            obDatos.idTipoProducto = 1;
            int Actualizar = obProductos.mtdActualizar(obDatos);
            if (Actualizar==1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Actualizacion " + obDatos.Codigo + "!', 'Se ha Actualizado el producto', 'success')", true);
            }
            
        }
    }
}