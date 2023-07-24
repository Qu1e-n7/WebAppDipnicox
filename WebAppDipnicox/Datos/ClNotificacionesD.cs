using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClNotificacionesD
    {
        public List<ClNotificacionesE> mtdListarNotificacionesXServicio()
        {
            ClNotificacionesE obDatos = new ClNotificacionesE();
            ClProcesarSQL SQL = new ClProcesarSQL();
            string Proceso = "ListarNotiXSer";
            SqlCommand ComanList = SQL.mtdProcesoAlmacenado(Proceso);
            SqlDataReader reader = ComanList.ExecuteReader();

            List<ClNotificacionesE> listNotificacion = new List<ClNotificacionesE>();

            while (reader.Read())
            {
                obDatos = new ClNotificacionesE();
                obDatos.idNotificacion = Convert.ToInt32(reader["idNotificacion"]);
                obDatos.Titulo = reader["Titulo"].ToString();
                obDatos.Descripcion = reader["Descripcion"].ToString();

                listNotificacion.Add(obDatos);
            }
            return listNotificacion;

        }
    }
}