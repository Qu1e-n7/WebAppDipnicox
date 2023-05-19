using Newtonsoft.Json;
using Newtonsoft.JsonResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Logica;




namespace WebAppDipnicox.Vista
{
    public partial class ListarPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClPersonalL objPersonal = new ClPersonalL();
            int id = 1;
            List<ClPersonalE> list = objPersonal.mtdListaPersonalXDato(id);
            if (list.Count > 0)
            {
                ClPersonalE obDatos = list[0];
                txtDocumento.Text = obDatos.Documento;
                txtNombre.Text = obDatos.Nombre;
                txtApellido.Text = obDatos.Apellido;
                txtTelefono.Text = obDatos.Telefono;
                txtEstado.Text = obDatos.Estado;
                txtEmail.Text = obDatos.Email;
                txtContraseña.Text = obDatos.Contraseña;
                ddlTipoPersonal.DataValueField = obDatos.idTipoPersonal.ToString();
                ddlCiudad.DataValueField = obDatos.idCiudad.ToString();
            }

        }

        [WebMethod]
        public static List<ClPersonalE> mtdObtenerDatos()
        {
            ClPersonalL obPersonalL = new ClPersonalL();
            List<ClPersonalE> ListaPersonal = obPersonalL.mtdListarPersonal();
            return ListaPersonal;

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}