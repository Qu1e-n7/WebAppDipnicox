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

        public List<ClServicioE> mtdListarServicio()
        {
            ClServicioE obDatos = new ClServicioE();
            ClProcesarSQL SQL = new ClProcesarSQL();
            string Proceso = "ListarServicio";
            SqlCommand ComanList = SQL.mtdProcesoAlmacenado(Proceso);
            SqlDataReader reader = ComanList.ExecuteReader();

            List<ClServicioE> listServicio = new List<ClServicioE>();

            while (reader.Read())
            {
                obDatos = new ClServicioE();
                obDatos.idServicio = Convert.ToInt32(reader["idServicio"]);
                obDatos.Nombre = reader["Nombre"].ToString();
                obDatos.Descripcion = reader["Descripcion"].ToString();
                obDatos.Valor = Convert.ToInt32(reader["Valor"]);

                listServicio.Add(obDatos);
            }
            return listServicio;

        }
        public int mtdActulizarServicioPer(ClServicioE objDatos,ClPersonalE objDatos1)
        {
            ClProcesarSQL objSQL = new ClProcesarSQL();
            string Proceso = "ActualizarServicioPer";
            SqlCommand Actualizar = objSQL.mtdProcesoAlmacenado(Proceso);

            Actualizar.Parameters.AddWithValue("@idPersonal", objDatos1.idPersonal);
            Actualizar.Parameters.AddWithValue("@idServicio", objDatos.idServicio);
            Actualizar.Parameters.AddWithValue("@idCiudad", objDatos1.idCiudad);


            int Actualiza = Actualizar.ExecuteNonQuery();

            return Actualiza;
        }
    }
}