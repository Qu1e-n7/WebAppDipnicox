using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClTipoPersonalL
    {
        public List<ClTipoPersonalE> mtdListarTipoPersonal()
        {
            ClTipoPersonalD objRol = new ClTipoPersonalD();
            List<ClTipoPersonalE> listaRoles = objRol.mtdListarTipoPersonal();
            return listaRoles;

        }
    }
}