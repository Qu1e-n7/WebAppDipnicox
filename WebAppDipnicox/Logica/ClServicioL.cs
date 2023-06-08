using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClServicioL
    {
        public int mtdRegistarServicio(ClServicioE obDatos)
        {
            ClServicioD objServicio = new ClServicioD();
            int Registro = objServicio.mtdRegistrarServicio(obDatos);
            return Registro;
        }
        public List<ClServicioE> mtdListarServicio()
        {
            ClServicioD objServicioD = new ClServicioD();
            List<ClServicioE> listaServicio = objServicioD.mtdListarServicio();
            return listaServicio;
        }
        public int mtdAculizarServicio(ClServicioE objDatos,ClPersonalE objDatos1)
        {
            ClServicioD objServicioD = new ClServicioD();
            int Actualiza = objServicioD.mtdActulizarServicioPer(objDatos,objDatos1);
            return Actualiza;
        }

    }
}