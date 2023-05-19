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
        public int mtdActualizar(ClProductosE obDatos)
        {
            ClProductosD obProducto = new ClProductosD();
            int Registro = obProducto.mtdActualizar(obDatos);
            return Registro;
        }
        public List<ClProductosE> mtdListaXDato(int id)
        {
            ClProductosD obProducto = new ClProductosD();
            List<ClProductosE> Lista = obProducto.mtdListaPorProducto(id);
            return Lista;
        }
        public List<ClProductosE> mtdListaProductos()
        {
            ClProductosD obProducto = new ClProductosD();
            List<ClProductosE> Lista = obProducto.mtdListarProductos();
            return Lista;
        }
    }
}