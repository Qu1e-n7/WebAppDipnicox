using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClNotificacionesL
    {
        public List<ClNotificacionesE> mtdListarNotiXSer()
        {
            ClNotificacionesD objDatosD = new ClNotificacionesD();
            List<ClNotificacionesE> listaNotifi = objDatosD.mtdListarNotificacionesXServicio();
            return listaNotifi;
        }
    }
}