﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClPersonalL
    {
        public int mtdRegistrar(ClPersonalE objDatos)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            int reg = objPersonalD.mtdRegistrar(objDatos);
            return reg;
        }
    }
}