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
    }
}