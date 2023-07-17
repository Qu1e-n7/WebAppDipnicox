using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClCotizacionD
    {
        public int mtdRegistrarCotizacion(ClCotizacionE objDatos)
        {
            ClProcesarSQL objSQL = new ClProcesarSQL();
            string Proceso = "RegistrarCotizacion";
            SqlCommand Registro = objSQL.mtdProcesoAlmacenado(Proceso);
            Registro.Parameters.AddWithValue("@Fecha", objDatos.Fecha);
            Registro.Parameters.AddWithValue("@Descripcion", objDatos.Descripcion);
            Registro.Parameters.AddWithValue("@Estado", objDatos.Estado);
            Registro.Parameters.AddWithValue("@Total", objDatos.Total);
            Registro.Parameters.AddWithValue("@idCliente", objDatos.idCliente);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }
    }
}