using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClPersonalD
    {
        public ClPersonalE mtdLogin(string Usua, string Clave)
        {

            string consulta = "Select * from Personal where Email='" + Usua + "' and Contraseña='" + Clave + "'";
            ClProcesarSQL obSql = new ClProcesarSQL();
            DataTable tblPersonal = obSql.mtdSelectDesc(consulta);
            ClPersonalE obPersonalE = null;
            if (tblPersonal.Rows.Count > 0)
            {
                obPersonalE = new ClPersonalE();
                obPersonalE.idPersonal = int.Parse(tblPersonal.Rows[0]["idPersonal"].ToString());
                obPersonalE.Documento = tblPersonal.Rows[0]["Documento"].ToString();
                obPersonalE.Nombre = tblPersonal.Rows[0]["Nombre"].ToString();
                obPersonalE.Apellido = tblPersonal.Rows[0]["Apellido"].ToString();
                obPersonalE.Email = tblPersonal.Rows[0]["Email"].ToString();
                obPersonalE.Contraseña = tblPersonal.Rows[0]["Contraseña"].ToString();
                obPersonalE.Telefono = tblPersonal.Rows[0]["Telefono"].ToString();
                obPersonalE.Estado = tblPersonal.Rows[0]["Estado"].ToString();
                obPersonalE.idTipoPersonal = int.Parse(tblPersonal.Rows[0]["idTipoPersonal"].ToString());
            }

            return obPersonalE;
}
        public int mtdRegistrar(ClPersonalE objDatos)
        {
            string consulta = "INSERT INTO Personal(Documento,Nombre,Apellido,Telefono,Estado,Email,Contraseña,idTipoPersonal,idCiudad) " +
                "VALUES('" + objDatos.Documento + "','" + objDatos.Nombre + "','" + objDatos.Apellido + "','" + objDatos.Telefono + "','" + objDatos.Estado + "','" + objDatos.Email + "','" + objDatos.Contraseña + "'," + objDatos.idTipoPersonal + "," + objDatos.idCiudad + ")";

            ClProcesarSQL objSQL = new ClProcesarSQL();
            int canReg = objSQL.mtdIUDConec(consulta);
            return canReg;

        }
        public List<ClPersonalE> mtdListaPersonal(ClPersonalE obDatos)
        {
            ClProcesarSQL SQL= new ClProcesarSQL();
            SqlDataReader reader = SQL.mtdListar();
            List<ClPersonalE> listPersonal=new List<ClPersonalE>();
            while (reader.Read())
            {
                obDatos = new ClPersonalE();
                obDatos.idPersonal = reader.GetInt32(0);
                obDatos.Documento = reader.GetString(1);
                obDatos.Nombre = reader.GetString(2);
                obDatos.Apellido = reader.GetString(3);
                obDatos.Telefono = reader.GetString(4);
                obDatos.Estado = reader.GetString(5);
                obDatos.Email = reader.GetString(6);
                obDatos.Contraseña = reader.GetString(7);
                obDatos.idTipoPersonal = reader.GetInt32(8);
                obDatos.idCiudad = reader.GetInt32(9);
                listPersonal.Add(obDatos);
            }
            return listPersonal;
        }
    }
}