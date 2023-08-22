using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClVentaL
    {

        ClVentaD objDatosVentaD = new ClVentaD();
        public int mtdRegistrarVenta(ClVentaE objDatos)
        {
            int registro = objDatosVentaD.mtdRegistrarVenta(objDatos);
            return registro;
        }

        public ClVentaE mtdListarXid(int idPersonal,int idCliente)
        {
            List<ClVentaE> Lista = objDatosVentaD.mtdListar();
            ClVentaE obDatos=new ClVentaE();

            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista[i].idPersonal== idPersonal && Lista[i].Estado=="Pendiente" || Lista[i].idCliente == idCliente && Lista[i].Estado == "Pendiente")
                {
                    obDatos.idVenta = Lista[i].idVenta;
                    obDatos.Codigo = Lista[i].Codigo;
                    obDatos.Fecha = Lista[i].Fecha;
                    obDatos.Estado = Lista[i].Estado;
                    obDatos.TotalVen = Lista[i].TotalVen;
                    obDatos.idCliente = Lista[i].idCliente;
                    obDatos.idPersonal = Lista[i].idPersonal;
                    obDatos.idTipoVenta = Lista[i].idPersonal;
                    
                }
            }
            return obDatos;
        }

        public int mtdConfirmarVenta (ClVentaE obDatos)
        {
            int Actua = objDatosVentaD.mtdActualizar(obDatos);
            return Actua;
        }

        public List<ClVentaE> mtdVentaConfirmadas()
        {
            List<ClVentaE> Lista = objDatosVentaD.mtdConfirma();
            return Lista;
        }

    }

}