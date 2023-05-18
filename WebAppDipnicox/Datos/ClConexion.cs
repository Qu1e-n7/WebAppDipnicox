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
            conexion = new SqlConnection("Data Source=.;Initial Catalog=dbDipnicox;User ID=Quien1; Password=q123");
            conexion.Open();
            return conexion;
        }
    }
}