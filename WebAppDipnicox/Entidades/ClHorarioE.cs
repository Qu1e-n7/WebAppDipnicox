using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClHorarioE
    {
        public int idHorario {get;set;}
        public string FechaInicio {get;set;}
        public string FechaFinal { get;set;}
        public int idPersonal { get;set;}
    }
}