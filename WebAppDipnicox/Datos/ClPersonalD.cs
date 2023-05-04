using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClPersonalD
    {
        public int mtdRegistrar(ClPersonalE objDatos)
        {
            string consulta = "INSERT INTO Personal(Documento,Nombre,Apellido,Telefono,Estado,Email,Contraseña,idTipoPersonal,idCiudad) " +
                "VALUES('" + objDatos.Documento + "','" + objDatos.Nombre + "','" + objDatos.Apellido + "','" + objDatos.Telefono + "','" + objDatos.Estado + "','" + objDatos.Email + "','" + objDatos.Contraseña + "'," + objDatos.idTipoPersonal + "," + objDatos.idCiudad + ")";

            ClProcesarSQL objSQL = new ClProcesarSQL();
            int canReg = objSQL.mtdIUDConec(consulta);
            return canReg;

        }
    }
}