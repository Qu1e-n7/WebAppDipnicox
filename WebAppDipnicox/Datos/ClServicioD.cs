using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClServicioD
    {
        public int mtdRegistrarServicio(ClServicioE objDatos)
        {
            ClProcesarSQL objSQL = new ClProcesarSQL();
            string Proceso = "RegistrarServicio";
            SqlCommand Registro = objSQL.mtdProcesoAlmacenado(Proceso);
            Registro.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Registro.Parameters.AddWithValue("@Descripcion", objDatos.Descripcion);
            Registro.Parameters.AddWithValue("@Valor", objDatos.Valor);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }
    }
}