using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Datos
{
    public class ClConexion
    {
        SqlConnection conexion = null;
        public SqlConnection mtdConexion()
        {
            conexion = new SqlConnection("Data Source=SOGAPRRBCFSD546\\MSSQLSERVERR;Initial Catalog=dbDipnicox;User ID=Sizin;Password=123");
            conexion.Open();
            return conexion;
        }
    }
}