using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClCiudadL
    {
        public List<ClCiudadE> mtdCiudad()
        {
            ClCiudadD objCiudad = new ClCiudadD();
            List<ClCiudadE> listaCiudad = objCiudad.mtdCiudad();
            return listaCiudad;

        }
    }
}