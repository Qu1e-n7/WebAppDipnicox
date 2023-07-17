using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Datos;

namespace WebAppDipnicox.Logica
{
    public class ClClienteL
    {
        public ClClienteE mtdLogin(string usu, string clave)
        {
            ClClienteD obClienteD = new ClClienteD();
            ClClienteE obClienteE = obClienteD.mtdLogin(usu, clave);
            return obClienteE;
        }

        public int mtdRegistrarCliente(ClClienteE objDatos)
        {
            ClClienteD objDatosD = new ClClienteD();
            int registro = objDatosD.mtdRegistrarCliente(objDatos);
            return registro;
        }
    }
}