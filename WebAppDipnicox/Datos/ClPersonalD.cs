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
        ClProcesarSQL SQL = new ClProcesarSQL();
        ClPersonalE obDatos = null;
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
        public List<ClPersonalE> mtdListaPersonal()
        {
            string Proceso = "ListarPersonal";
            SqlCommand ComanList = SQL.mtdProcesoAlmacenado(Proceso);
            SqlDataReader ProcRead = ComanList.ExecuteReader();
            List<ClPersonalE> listPersonal=new List<ClPersonalE>();
            while (ProcRead.Read())
            {
                obDatos = new ClPersonalE();
                obDatos.idPersonal = ProcRead.GetInt32(0);
                obDatos.Documento = ProcRead.GetString(1);
                obDatos.Nombre = ProcRead.GetString(2);
                obDatos.Apellido = ProcRead.GetString(3);
                obDatos.Telefono = ProcRead.GetString(4);
                obDatos.Estado = ProcRead.GetString(5);
                obDatos.Email = ProcRead.GetString(6);
                obDatos.Contraseña = ProcRead.GetString(7);
                obDatos.idTipoPersonal = ProcRead.GetInt32(8);
                obDatos.idCiudad = ProcRead.GetInt32(9);
                listPersonal.Add(obDatos);
            }
            return listPersonal;
        }
        
    }
}