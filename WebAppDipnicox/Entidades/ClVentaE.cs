using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClVentaE
    {
        public int idVenta { get; set; }
        public string Codigo { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string Total { get; set; }
        public int idCliente { get; set; }
        public int idPersonal { get; set; }
        public int idTipoVenta { get; set; }
    }
}