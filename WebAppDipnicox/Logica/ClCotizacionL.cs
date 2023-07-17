using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClCotizacionL
    {
        public int mtdRegistroVentas(ClCotizacionE objDatos)
        {
            ClCotizacionD objDatosD = new ClCotizacionD();
            int registro = objDatosD.mtdRegistrarCotizacion(objDatos);
            return registro;
        }
    }
}