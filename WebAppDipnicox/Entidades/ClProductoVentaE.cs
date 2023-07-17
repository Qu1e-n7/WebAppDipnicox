using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClProductoVentaE:ClProductosE
    {
        public int idProductoVenta { get; set; }
        public int CantidadVen  { get; set; }
        public int Total { get; set; }
    }
}