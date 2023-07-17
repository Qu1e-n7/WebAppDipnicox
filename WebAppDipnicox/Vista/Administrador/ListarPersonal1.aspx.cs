using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;

namespace WebAppDipnicox.Vista
{
    public partial class ListarPersonal1 : System.Web.UI.Page
    {
        private int idPersonal;
        ClPersonalL objPersonalL = new ClPersonalL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ClTipoPersonalL objTipoPersonal = new ClTipoPersonalL();
                List<ClTipoPersonalE> listaTipoPersonal = new List<ClTipoPersonalE>();
                listaTipoPersonal = objTipoPersonal.mtdListarTipoPersonal();

                ddlTipoPersonal.DataSource = listaTipoPersonal;
                ddlTipoPersonal.DataTextField = "TipoPersonal";
                ddlTipoPersonal.DataValueField = "idTipoPersonal";
                ddlTipoPersonal.DataBind();

                ClCiudadL objCiudad = new ClCiudadL();
                List<ClCiudadE> listaCiudad = new List<ClCiudadE>();
                listaCiudad = objCiudad.mtdCiudad();

                ddlCiudad.DataSource = listaCiudad;
                ddlCiudad.DataTextField = "Ciudad";
                ddlCiudad.DataValueField = "idCiudad";
                ddlCiudad.DataBind();

                // Verificar si se proporcionó el parámetro "method" en la URL
                if (Request.QueryString["method"] != null)
                {
                    string methodName = Request.QueryString["method"];
                    if (methodName == "OtroMetodo")
                    {
                        // Verificar si se proporcionó el parámetro "idPersonal" en la URL
                        if (Request.QueryString["idPersonal"] != null)
                        {
                            int idPersonal = Convert.ToInt32(Request.QueryString["idPersonal"]);
                            // Llamar al método OtroMetodo con el parámetro idPersonal
                            mtdMostarPersonal(idPersonal);
                        }
                    }
                }
            }



        }

        [WebMethod]
        public static List<ClPersonalE> mtdObtenerDatos()
        {
            ClPersonalL obPersonalL = new ClPersonalL();
            List<ClPersonalE> ListaPersonal = obPersonalL.mtdListarPersonal();
            return ListaPersonal;

        }

        [WebMethod]
        public static void GuardarIdPersonal(int idPersonal)
        {

            var page = HttpContext.Current.Handler as ListarPersonal1;
            if (page != null)
            {
                page.idPersonal = idPersonal;

            }



        }
        [WebMethod]
        public static List<ClPersonalE> mtdMostarPersonal(int idPersonal)
        {
            ClPersonalL objPersonalL = new ClPersonalL();
            var Page = HttpContext.Current.Handler as ListarPersonal1;
            List<ClPersonalE> list = Page.objPersonalL.mtdListaPersonalXDato(idPersonal);
            return list;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ClPersonalE objDatos = new ClPersonalE();

            objDatos.idPersonal = int.Parse(txtId.Text);
            objDatos.Documento = txtDocumento.Text;
            objDatos.Nombre = txtNombre.Text;
            objDatos.Apellido = txtApellido.Text;
            objDatos.Telefono = txtTelefono.Text;
            objDatos.Estado = txtEstado.Text;
            objDatos.Email = txtEmail.Text;
            objDatos.Contraseña = txtContraseña.Text;
            objDatos.idTipoPersonal = int.Parse(ddlTipoPersonal.SelectedValue.ToString());
            objDatos.idCiudad = int.Parse(ddlCiudad.SelectedValue.ToString());
            ClPersonalL objPersonal = new ClPersonalL();

            int Actualizar = objPersonal.mtdActualizarPersonal(objDatos);
            if (Actualizar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Actualizacion " + objDatos.Nombre + "!', 'Se ha Actualizado el Usuario', 'success')", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ClPersonalE objDatos = new ClPersonalE();

            objDatos.idPersonal = int.Parse(txtId.Text);

            ClPersonalL objPersonal = new ClPersonalL();
            int Eliminar = objPersonal.mtdEliminarDatos(objDatos);
            if (Eliminar == 1)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "swal('¡Eliminacion " + objDatos.Nombre + "!', 'Se ha Eliminado el Usuario', 'error')", true);
            }
        }
    }
}