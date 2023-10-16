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
        public int mtdRegistroVentas(ClCotizacionE objDatos, int idPersonal)
        {
            ClCotizacionD objDatosD = new ClCotizacionD();
            int registro = objDatosD.mtdRegistrarCotizacion(objDatos,idPersonal);
            return registro;
        }
    }
}