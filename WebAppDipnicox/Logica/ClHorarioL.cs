using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClHorarioL
    {
        ClHorarioD obHorario = new ClHorarioD();
        public List<ClDiaE> mtdListaDias()
        {
            List<ClDiaE> Lista=obHorario.mtdDias();
            return Lista;
        }
    }
}