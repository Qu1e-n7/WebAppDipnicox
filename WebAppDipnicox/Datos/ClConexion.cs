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
            //conexion = new SqlConnection("Data Source=SOGAPRRBCFSD544\\SQLEXPRESS;Initial Catalog=dbDipnicox;User ID=Quien;Password=q123");
            //conexion = new SqlConnection("Data Source=.;Initial Catalog=dbDipnicox;User ID=Quien1;Password=q123");

            conexion = new SqlConnection("Data Source=DESKTOP-JRTUVHD\\SQLEXPRESS;Initial Catalog=dbDipnicox;Integrated Security=True");

            conexion.Open();
            return conexion;
        }
    }
}