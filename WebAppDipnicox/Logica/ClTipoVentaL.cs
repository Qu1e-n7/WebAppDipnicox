using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClTipoVentaL
    {
        public List<ClTipoVentaE> mtdListarVenta(ClTipoVentaE objDatos)
        {
            ClTipoVentaD objTipoVentaD = new ClTipoVentaD();
            List<ClTipoVentaE> listaTipoVenta = objTipoVentaD.mtdListarTipoVenta(objDatos);
            return listaTipoVenta;
        }
    }
}