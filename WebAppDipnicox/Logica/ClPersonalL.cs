using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClPersonalL
    {
        public ClPersonalE mtdLogin(string usu, string clave)
        {
            ClPersonalD obPersonalD = new ClPersonalD();
            ClPersonalE obPersonalE = obPersonalD.mtdLogin(usu, clave);
            return obPersonalE;
        }
        public int mtdRegistrar(ClPersonalE objDatos)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            int reg = objPersonalD.mtdRegistrar(objDatos);
            return reg;

        }
        public List<ClPersonalE> mtdListarPersonal()
        {
            ClPersonalD obPersonalD = new ClPersonalD();
            List<ClPersonalE> ListaPersonal= obPersonalD.mtdListaPersonal();
            return ListaPersonal;
        }
        public int mtdActualizarPersonal(ClPersonalE objDatos)
        {
            ClPersonalD objPersonal = new ClPersonalD();
            int Regsitro = objPersonal.mtdActualizar(objDatos);
            return Regsitro;
        }

        public List<ClPersonalE> mtdListaPersonalXDato(int id)
        {
            ClPersonalD obPersonal = new ClPersonalD();
            List<ClPersonalE> ListaPersonal = obPersonal.mtdListarPersonalXDato(id);
            return ListaPersonal;
        }
        public int mtdActualizarDatos(ClPersonalE objDatos)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            int Actualizar = objPersonalD.mtdActualizarPersonal(objDatos);
            return Actualizar;

        }
        public int mtdEliminarDatos(ClPersonalE objDatos)
        {
            ClPersonalD objPersonalD = new ClPersonalD();
            int Eliminar = objPersonalD.mtdEliminarDato(objDatos);
            return Eliminar;
        }
    }
}