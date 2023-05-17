using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Datos;

namespace WebAppDipnicox.Vista
{
    public partial class PerfilTrabajador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            int tamanioarchivo;
            byte[] imagen = FUImage.FileBytes;
            tamanioarchivo = int.Parse(FUImage.FileContent.Length.ToString());
            if (tamanioarchivo >= 2097151000)
            {
                lblError.Text = "El tamaño de la imagen debe ser menor a 10 Mb!";
            }
            else if (FUImage.HasFile)
            {
                //SqlCommand cmd = new SqlCommand("CambiarImagen", con)
                //{
                //    CommandType = CommandType.StoredProcedure
                //};
                //cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = imagen;
                //cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                //ClConexion objConexion = new ClConexion();

                
                //cmd.ExecuteNonQuery();
                //lblError.Text = "";
               
            }
            else
            {
                lblError.Text = "No se ha cargado una imagen de perfil nueva!";
            }
        }
    }
}