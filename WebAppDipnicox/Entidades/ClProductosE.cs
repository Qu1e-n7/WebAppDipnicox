using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDipnicox.Entidades
{
    public class ClProductosE
    {
        public int idProducto { get;set; }
        public string Codigo { get;set; }
        public string Nombre { get;set; }
        public string Descripcion { get;set; }
        public int Valor { get;set; }
        public int Cantidad { get;set; }
        public string UnidadMed { get;set; }
        public int idTipoProducto { get;set; }


        
    }
}