using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

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
        public int mtdRegistrar(ClPersonalE objDatos)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            int reg = objPersonalD.mtdRegistrar(objDatos);
            return reg;
        }
    }
}