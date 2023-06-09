using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClHorarioD
    {
        ClProcesarSQL obSQL = new ClProcesarSQL();
        public List<ClDiaE> mtdDias()
        {
            string proceso = "ListarDias";
            SqlCommand ComaList = obSQL.mtdProcesoAlmacenado(proceso);
            SqlDataReader datosread = ComaList.ExecuteReader();
            List<ClDiaE> ListDias = new List<ClDiaE>();
            ClDiaE obDatos = null;
            while (datosread.Read())
            {
                obDatos = new ClDiaE();
                obDatos.idDia = Convert.ToInt32(datosread["idDia"].ToString());
                obDatos.Dia = datosread["Dia"].ToString();
                ListDias.Add(obDatos);
            }
            return ListDias;
        }
    }
}
