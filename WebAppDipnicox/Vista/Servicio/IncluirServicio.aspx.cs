using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista.Servicio
{
    public partial class IncluirServicio : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ClPersonalE objDato = (ClPersonalE)Session["Trabajador"];

                ClServicioL objServicioL = new ClServicioL();
                List<ClServicioE> listaServicio = new List<ClServicioE>();
                listaServicio = objServicioL.mtdListarServicio();

                ddlServicio.DataSource = listaServicio;
                ddlServicio.DataTextField = "Nombre";
                ddlServicio.DataValueField = "idServicio";
                ddlServicio.DataBind();

                ClCiudadL objCiudadL = new ClCiudadL();
                List<ClCiudadE> listaCiudad = objCiudadL.mtdCiudad();



                ddlCiudad.DataSource = listaCiudad;
                ddlCiudad.DataTextField = "Ciudad";
                ddlCiudad.DataValueField = "idCiudad";





                int idPersonal = objDato.idPersonal;


                txtDocumento.Text = objDato.Documento;
                txtNombre.Text = objDato.Nombre;
                txtApellido.Text = objDato.Apellido;
                txtTelefono.Text = objDato.Telefono;
                txtEstado.Text = objDato.Estado;
                txtEmail.Text = objDato.Email;
                txtContraseña.Text = objDato.Contraseña;
                if (ddlCiudad.Items.FindByValue(objDato.idCiudad.ToString()) == null)
                {
                    ddlCiudad.SelectedValue = objDato.idCiudad.ToString();
                    ddlCiudad.DataBind();

                }


            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClServicioE objDatos = new ClServicioE();
            ClPersonalE objDatos1 = new ClPersonalE();


            ClPersonalE objDato = (ClPersonalE)Session["Trabajador"];
            objDatos1.idPersonal = objDato.idPersonal;
            objDatos1.Documento = txtDocumento.Text;
            objDatos1.Nombre = txtNombre.Text;
            objDatos1.Apellido = txtApellido.Text;
            objDatos1.Telefono = txtTelefono.Text;
            objDatos1.Estado = txtEstado.Text;
            objDatos1.Email = txtEmail.Text;
            objDatos1.Contraseña = txtContraseña.Text;
            objDatos1.idTipoPersonal = objDato.idTipoPersonal;
            //objDatos1.idCiudad = objDato.idCiudad;
            int idPersonal = objDato.idPersonal;

            objDatos.idServicio = int.Parse(ddlServicio.SelectedValue.ToString());
            objDatos1.idCiudad = int.Parse(ddlCiudad.SelectedValue.ToString());


            ClServicioL objServicioL = new ClServicioL();

            int Actuliza = objServicioL.mtdAculizarServicio(objDatos, objDatos1);
            if (Actuliza == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Agregado " + objDatos.Nombre + "!', 'Se ha Agregado el Servicio', 'success')", true);
            }
        }

        protected void btnActualizarDatosP_Click(object sender, EventArgs e)
        {
            ClPersonalE objDatos = new ClPersonalE();

            ClPersonalE objDato = (ClPersonalE)Session["Trabajador"];
            objDatos.idPersonal = objDato.idPersonal;
            objDatos.Documento = txtDocumento.Text;
            objDatos.Nombre = txtNombre.Text;
            objDatos.Apellido = txtApellido.Text;
            objDatos.Telefono = txtTelefono.Text;
            objDatos.Estado = txtEstado.Text;
            objDatos.Email = txtEmail.Text;
            objDatos.Contraseña = txtContraseña.Text;
            objDatos.idTipoPersonal = objDato.idTipoPersonal;
            objDatos.idCiudad = objDato.idCiudad;

            ClPersonalL objPersonal = new ClPersonalL();

            int Actualizar = objPersonal.mtdActualizarPersonal(objDatos);
            if (Actualizar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Actualizacion " + objDatos.Nombre + "!', 'Se ha Actualizado el Usuario', 'success')", true);
            }
        }

        protected void btnActualizarDatosC_Click(object sender, EventArgs e)
        {
            ClPersonalE objDatos = new ClPersonalE();

            ClPersonalE objDato = (ClPersonalE)Session["Trabajador"];
            objDatos.idPersonal = objDato.idPersonal;
            objDatos.Documento = txtDocumento.Text;
            objDatos.Nombre = txtNombre.Text;
            objDatos.Apellido = txtApellido.Text;
            objDatos.Telefono = txtTelefono.Text;
            objDatos.Estado = txtEstado.Text;
            objDatos.Email = txtEmail.Text;
            objDatos.Contraseña = txtContraseña.Text;
            objDatos.idTipoPersonal = objDato.idTipoPersonal;
            objDatos.idCiudad = objDato.idCiudad;


            ClPersonalL objPersonal = new ClPersonalL();

            int Actualizar = objPersonal.mtdActualizarPersonal(objDatos);
            if (Actualizar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Actualizacion " + objDatos.Nombre + "!', 'Se ha Actualizado el Usuario', 'success')", true);
            }
        }
    }
}