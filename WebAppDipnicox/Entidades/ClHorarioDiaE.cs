using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClHorarioDiaE:ClHorarioE
    {
        public int idHorarioDia { get; set; }
        public int idHoraio { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }

    }
}