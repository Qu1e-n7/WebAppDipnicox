using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClTipoVentaD
    {
        public List<ClTipoVentaE> mtdListarTipoVenta(ClTipoVentaE obDatos)
        {
            

            ClProcesarSQL SQL = new ClProcesarSQL();
            string Proceso = "ListarTipoVenta";
            SqlCommand ComanList = SQL.mtdProcesoAlmacenado(Proceso);
            SqlDataReader reader = ComanList.ExecuteReader();

            List<ClTipoVentaE> listaTipoVenta = new List<ClTipoVentaE>();

            while (reader.Read())
            {
                obDatos = new ClTipoVentaE();
                obDatos.idTipoVenta = Convert.ToInt32(reader["idTipoVenta"]);
                obDatos.nombreTipoVenta = reader["nombreTipoVenta"].ToString();

                listaTipoVenta.Add(obDatos);
            }
            return listaTipoVenta;

        }


    }
}