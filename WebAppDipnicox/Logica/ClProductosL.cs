﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClProductosL
    {
        ClProductosD obProducto = new ClProductosD();

        public int mtdRegistar(ClProductosE obDatos)
        {
            int Registro= obProducto.mtdRegistrar(obDatos);
            return Registro;
        }

        public int mtdActualizar(ClProductosE obDatos)
        {
            int Actualizar = obProducto.mtdActualizar(obDatos);
            return Actualizar;
        }
        public List<ClNotificacionE> mtdMensaje(int id=0 )
        {
            List<ClNotificacionE> msjTrigger = obProducto.mtdTrMensa(id);
            return msjTrigger;
        }
        public List<ClNotificacionE> mtdMensaje1()
        {
            List<ClNotificacionE> msjTrigger = obProducto.mtdTrMensa1();
            return msjTrigger;
        }
        public int mtdEliminar(int id)
        {
            int  Eliminar= obProducto.mtdEliminar(id);
            return Eliminar;
        }

        public List<ClProductosE> mtdListaXDato(int id)
        {
            List<ClProductosE> Lista = obProducto.mtdListaPorProducto(id);
            return Lista;
        }

        public List<ClProductosE> mtdListaProductos()
        {
            List<ClProductosE> Lista = obProducto.mtdListarProductos();
            return Lista;
        }
        public List<ClProductosE> mtdBuscar(string NombreBusca)
        {
            List<ClProductosE> listaProducto = obProducto.mtdBuscar(NombreBusca);
            return listaProducto;
        }
    }
}