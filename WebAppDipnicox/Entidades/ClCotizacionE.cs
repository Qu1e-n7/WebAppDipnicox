using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClCotizacionE
    {
        public int idCotizacion { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Total { get; set; }
        public int idCliente { get; set; }

    }
}