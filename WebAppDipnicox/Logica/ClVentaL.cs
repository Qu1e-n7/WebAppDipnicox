using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClVentaL
    {
        public int mtdRegistrarVenta(ClVentaE objDatos)
        {
            ClVentaD objDatosVentaD = new ClVentaD();
            int registro = objDatosVentaD.mtdRegistrarVenta(objDatos);
            return registro;
        }
    }
}