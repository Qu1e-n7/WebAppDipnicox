using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClProductosD
    {
        public int mtdRegistrar(ClProductosE objDatos)
        {
            string Proceso="AgregarProductos";
            ClProcesarSQL objSQL = new ClProcesarSQL();
            SqlCommand Registro = objSQL.mtdAgregar(Proceso);
            Registro.Parameters.AddWithValue("@Codigo", objDatos.Codigo);
            Registro.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Registro.Parameters.AddWithValue("@Descripcion", objDatos.Descripcion);
            Registro.Parameters.AddWithValue("@Valor", objDatos.Valor);
            Registro.Parameters.AddWithValue("@Cantidad", objDatos.Cantidad);
            Registro.Parameters.AddWithValue("@Medida", objDatos.UnidadMed);
            Registro.Parameters.AddWithValue("@idtpProd", objDatos.idTipoProducto);
            int Registar=Registro.ExecuteNonQuery();
            return Registar;

        }
    }
}