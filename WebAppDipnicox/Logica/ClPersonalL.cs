using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Datos;

namespace WebAppDipnicox.Logica
{
    public class ClPersonalL
    {
        public ClPersonalE mtdLogin(string usu, string clave)
        {
            ClPersonalD obClienteD = new ClPersonalD();
            ClPersonalE obClienteE = obClienteD.mtdLogin(usu, clave);
            return obClienteE;
        }

    }
}