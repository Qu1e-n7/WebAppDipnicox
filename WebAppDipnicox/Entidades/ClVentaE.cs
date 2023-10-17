using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClVentaE:ClProductoVentaE
    {
        public int idVenta { get; set; }
        public string CodVenta { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string TotalVen { get; set; }
        public int? idCliente { get; set; }
        public string Cliente { get; set; }
        public int? idPersonal { get; set; }
        public string Personal { get; set; }
        public int? idTipoVenta { get; set; }
        public string TipVent { get; set; }

    }
}