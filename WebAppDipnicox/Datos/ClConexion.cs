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
            conexion = new SqlConnection("Data Source=DESKTOP-8HIJ12M;Initial Catalog=dbDipnicox;Persist Security Info=True;User ID=Quien1;Password=q123");
            conexion.Open();
            return conexion;
        }
    }
}