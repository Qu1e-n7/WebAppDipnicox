using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace WebAppDipnicox.Datos
{
    public class ClClienteD
    {
        public ClClienteE mtdLogin(string Usua, string Clave)
        {

            string consulta = "Select * from Cliente where Email='" + Usua + "' and Contraseña='" + Clave + "'";
            ClProcesarSQL obSql = new ClProcesarSQL();
            DataTable tblPersonal = obSql.mtdSelectDesc(consulta);
            ClClienteE obClienteE = null;
            if (tblPersonal.Rows.Count > 0)
            {
                obClienteE = new ClClienteE();
                obClienteE.idCliente = int.Parse(tblPersonal.Rows[0]["idCliente"].ToString());
                obClienteE.Documento = tblPersonal.Rows[0]["Documento"].ToString();
                obClienteE.Nombre = tblPersonal.Rows[0]["Nombre"].ToString();
                obClienteE.Apellido = tblPersonal.Rows[0]["Apellido"].ToString();
                obClienteE.Telefono = tblPersonal.Rows[0]["Telefono"].ToString();
                obClienteE.Email = tblPersonal.Rows[0]["Email"].ToString();
                obClienteE.Contraseña = tblPersonal.Rows[0]["Contraseña"].ToString();
                //obClienteE.idCiudad = int.Parse(tblPersonal.Rows[0]["idCiudad"].ToString());
            }

            return obClienteE;
        }
    }
}