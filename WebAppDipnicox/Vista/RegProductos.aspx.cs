using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class RegistarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClTipoProducL obTipProd = new ClTipoProducL();
                List<ClTipoProducE> listaTipProd = obTipProd.mtdLisTipProd();

                ddlTipoProduc.DataSource = listaTipProd;
                ddlTipoProduc.DataTextField = "Nombre";
                ddlTipoProduc.DataValueField = "idTipoProduc";
                ddlTipoProduc.DataBind();
                ddlTipoProduc.Items.Insert(0, new ListItem("Tipo Producto:", "0"));
            }

        }
        protected void FileUpload1_Changed(object sender, EventArgs e)
        {
            if (fUload.HasFile)
            {
                // Acciones a realizar cuando se carga un archivo.
                // Puedes acceder al archivo cargado a través de FileUpload1.PostedFile.
                // Realiza aquí las operaciones necesarias con el archivo.
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClProductosL obProd = new ClProductosL();
            ClProductosE obDatos = new ClProductosE();
            obDatos.Codigo = txtCodigo.Text;
            obDatos.Nombre = txtNombre.Text;
            obDatos.Descripcion = txtDescripcion.Text;
            obDatos.Valor = int.Parse(txtValor.Text);
            obDatos.Cantidad = int.Parse(txtCantidad.Text);
            obDatos.UnidadMed = txtMedidad.Text;
            obDatos.idTipoProducto = int.Parse(ddlTipoProduc.SelectedValue.ToString());
            int Registrar = obProd.mtdRegistar(obDatos);
            if (Registrar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Producto Registrado!', 'Su Producto ha Sido Registrado Con Exito', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Producto No Registrado!', 'Su Producto no ha Sido Registrado', 'warning')", true);

            }

        }

        protected void fUload_Load(object sender, EventArgs e)
        {
            int x = 0;
        }
    }
}