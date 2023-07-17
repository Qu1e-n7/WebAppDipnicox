using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClProductoVentaL
    {
        ClProductoVentaD obProdVen=new ClProductoVentaD();
        public int mtdReg(ClVentaE obDatos)
        {
            int Regi = obProdVen.mtdRegProductoVenta(obDatos);
            return Regi;
        }
        public List<ClVentaE> mtdList(int idVenta)
        {
            List<ClVentaE> Lista= obProdVen.mtdListProdVen(idVenta);
            return Lista;
        }
        public int mtdEliminar(int idPrV)
        {
            int Eliminar = obProdVen.mtdEliminar(idPrV); 
            return Eliminar;
        }
    }
}