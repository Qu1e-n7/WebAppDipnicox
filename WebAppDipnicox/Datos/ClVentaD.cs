using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClVentaD
    {
        public int mtdRegistrarVenta(ClVentaE objDatos)
        {
            ClProcesarSQL objSQL = new ClProcesarSQL();
            string Proceso = "RegistrarVenta";
            SqlCommand Registro = objSQL.mtdProcesoAlmacenado(Proceso);
            Registro.Parameters.AddWithValue("@Estado", objDatos.Estado);
            Registro.Parameters.AddWithValue("@Total", objDatos.Total);
            Registro.Parameters.AddWithValue("@idCliente", objDatos.idCliente);
            Registro.Parameters.AddWithValue("@idPersonal", objDatos.idPersonal);
            Registro.Parameters.AddWithValue("@idTipoVenta", objDatos.idTipoVenta);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }
    }
}