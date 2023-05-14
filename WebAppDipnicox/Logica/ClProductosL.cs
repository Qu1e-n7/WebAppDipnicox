using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClProductosL
    {
        public int mtdRegistar(ClProductosE obDatos)
        {
            ClProductosD obProducto= new ClProductosD();
            int Registro= obProducto.mtdRegistrar(obDatos);
            return Registro;
        }
    }
}