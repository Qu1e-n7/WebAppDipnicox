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
    public partial class RegistrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClCiudadL objCiudad = new ClCiudadL();
                List<ClCiudadE> listaCiudad = new List<ClCiudadE>();
                listaCiudad = objCiudad.mtdCiudad();

                ddlCiudad.DataSource = listaCiudad;
                ddlCiudad.DataTextField = "Ciudad";
                ddlCiudad.DataValueField = "idCiudad";
                ddlCiudad.DataBind();
                ddlCiudad.Items.Insert(0, new ListItem("Ciudad:", "0"));

            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClClienteE objDatosCliente = new ClClienteE();
            objDatosCliente.Documento = txtDocumento.Text;
            objDatosCliente.Nombre = txtNombre.Text;
            objDatosCliente.Apellido = txtApellido.Text;
            objDatosCliente.Telefono = txtTelefono.Text;
            objDatosCliente.Email = txtEmail.Text;
            objDatosCliente.Contraseña = txtContraseña.Text;
            objDatosCliente.idCiudad = int.Parse(ddlCiudad.SelectedValue.ToString());

            ClClienteL objPersonalL = new ClClienteL();
            int resultado = objPersonalL.mtdRegistrarCliente(objDatosCliente);

            if (resultado == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Registrado Exitososamente! ', 'Su usuario ha Sido Registrado Con Exito', 'success')", true);
                Response.Redirect("Login.aspx");
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Usuario No Registrado!', 'Su usuario no ha Sido Registrado', 'warning')", true);
            }
        }
    }
}