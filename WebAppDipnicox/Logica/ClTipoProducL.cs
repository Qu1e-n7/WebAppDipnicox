using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClTipoProducL
    {
        public List<ClTipoProducE> mtdLisTipProd()
        {
            ClTipoProducD obTipProd=new ClTipoProducD();
            List<ClTipoProducE> lisTipProd = obTipProd.mtdListarTipoPersonal();
            return lisTipProd;
        }
    }
}