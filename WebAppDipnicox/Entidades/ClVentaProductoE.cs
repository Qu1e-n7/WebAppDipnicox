using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClVentaProductoE
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Total { get; set; }
        public int idVenta { get; set; }
    }
}