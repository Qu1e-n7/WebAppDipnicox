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
            ClPersonalD obPersonalD = new ClPersonalD();
            ClPersonalE obPersonalE = obPersonalD.mtdLogin(usu, clave);
            return obPersonalE;
        }
        public int mtdRegistrar(ClPersonalE objDatos)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            int reg = objPersonalD.mtdRegistrar(objDatos);
            return reg;

        }
        public List<ClPersonalE> mtdListarPersonal()
        {
            ClPersonalD obPersonalD = new ClPersonalD();
            List<ClPersonalE> ListaPersonal= obPersonalD.mtdListaPersonal();
            return ListaPersonal;
        }
    }
}