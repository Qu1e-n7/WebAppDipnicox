using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClHorarioE:ClDiaE
    {
        public int idHorario {get;set;}
        public DateTime FechaInicio {get;set;}
        public DateTime FechaFinal { get;set;}
        public int idPersonal { get;set;}
    }
}