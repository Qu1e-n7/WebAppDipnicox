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
    public partial class RegistrarServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClServicioL objServicio = new ClServicioL();
            ClServicioE obDatos = new ClServicioE();
            obDatos.Nombre = txtNombre.Text;
            obDatos.Descripcion = txtDescripcion.Text;
            obDatos.Valor = int.Parse(txtValor.Text);
            int Registrar = objServicio.mtdRegistarServicio(obDatos);
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