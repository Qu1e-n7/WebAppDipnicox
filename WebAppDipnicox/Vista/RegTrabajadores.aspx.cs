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
    public partial class RegTrabajadores1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ClTipoPersonalL objTipoPersonal = new ClTipoPersonalL();
                List<ClTipoPersonalE> listaTipoPersonal = new List<ClTipoPersonalE>();
                listaTipoPersonal = objTipoPersonal.mtdListarTipoPersonal();

                ddlTipoPersonal.DataSource = listaTipoPersonal;
                ddlTipoPersonal.DataTextField = "TipoPersonal";
                ddlTipoPersonal.DataValueField = "idTipoPersonal";
                ddlTipoPersonal.DataBind();
                ddlTipoPersonal.Items.Insert(0, new ListItem("Tipo Personal:", "0"));

                //

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
            ClPersonalE objDatosPersonal = new ClPersonalE();
            objDatosPersonal.Documento = txtDocumento.Text;
            objDatosPersonal.Nombre = txtNombre.Text;
            objDatosPersonal.Apellido = txtApellido.Text;
            objDatosPersonal.Telefono = txtTelefono.Text;
            objDatosPersonal.Estado = txtEstado.Text;
            objDatosPersonal.Email = txtEmail.Text;
            objDatosPersonal.Contraseña = txtContraseña.Text;
            objDatosPersonal.idTipoPersonal = int.Parse(ddlTipoPersonal.SelectedValue.ToString());
            objDatosPersonal.idCiudad = int.Parse(ddlCiudad.SelectedValue.ToString());

            ClPersonalL objPersonalL = new ClPersonalL();
            int resultado = objPersonalL.mtdRegistrar(objDatosPersonal);

            if (resultado == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Usuario Registrado!', 'Su usuario ha Sido Registrado Con Exito', 'success')", true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Usuario No Registrado!', 'Su usuario no ha Sido Registrado', 'warning')", true);
            }
        }
    }
}