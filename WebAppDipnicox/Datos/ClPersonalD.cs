using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebAppDipnicox.Entidades;
using System.Web.Helpers;
using Newtonsoft.JsonResult;
using WebAppDipnicox.Vista;
using System.Security.Policy;

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
            SqlDataReader reader = ComanList.ExecuteReader();

            List<ClPersonalE> listPersonal = new List<ClPersonalE>();

            while (reader.Read())
            {
                obDatos = new ClPersonalE();
                obDatos.idPersonal = Convert.ToInt32(reader["idPersonal"]);
                obDatos.Documento = reader["Documento"].ToString();
                obDatos.Nombre = reader["Nombre"].ToString();
                obDatos.Apellido = reader["Apellido"].ToString();
                obDatos.Telefono = reader["Telefono"].ToString();
                obDatos.Estado = reader["Estado"].ToString();
                obDatos.Email = reader["Email"].ToString();
                obDatos.Contraseña = reader["Contraseña"].ToString();
                obDatos.idTipoPersonal = Convert.ToInt32(reader["idTipoPersonal"]);
                obDatos.idCiudad = Convert.ToInt32(reader["idCiudad"]);





                //obDatos.idPersonal = reader.GetInt32(0);
                //obDatos.Documento = reader.GetString(1);
                //obDatos.Nombre = reader.GetString(2);
                //obDatos.Apellido = reader.GetString(3);
                //obDatos.Telefono = reader.GetString(4);
                //obDatos.Estado = reader.GetString(5);
                //obDatos.Email = reader.GetString(6);
                //obDatos.Contraseña = reader.GetString(7);
                //obDatos.idTipoPersonal = reader.GetInt32(8);
                //obDatos.idCiudad = reader.GetInt32(9);
                listPersonal.Add(obDatos);
            }
            return listPersonal;
        }

        public int mtdActualizar(ClPersonalE objDatos)
        {
            ClProcesarSQL obSQL = new ClProcesarSQL();

            string Proceso = "ActualizarPersonal";
            SqlCommand Registro = obSQL.mtdProcesoAlmacenado(Proceso);

            Registro.Parameters.AddWithValue("@idPersonal", objDatos.idPersonal);
            Registro.Parameters.AddWithValue("@Documento", objDatos.Documento);
            Registro.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Registro.Parameters.AddWithValue("@Apellido", objDatos.Apellido);
            Registro.Parameters.AddWithValue("@Telefono", objDatos.Telefono);
            Registro.Parameters.AddWithValue("@Estado", objDatos.Estado);
            Registro.Parameters.AddWithValue("@Email", objDatos.Email);
            Registro.Parameters.AddWithValue("@Contraseña", objDatos.Contraseña);
            Registro.Parameters.AddWithValue("@idTipoPersonal", objDatos.idTipoPersonal);
            Registro.Parameters.AddWithValue("@idCiudad", objDatos.idCiudad);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;

        }
        public List<ClPersonalE> mtdListarPersonalXDato(int id)
        {
            ClProcesarSQL obSQL = new ClProcesarSQL();
            string Proceso = "ListarPersonalXDato";

            SqlCommand ComPersonal = obSQL.mtdProcesoAlmacenado(Proceso);
            List<ClPersonalE> listPer = new List<ClPersonalE>();
            ComPersonal.Parameters.AddWithValue("@idPersonal", id);
            SqlDataReader reader = ComPersonal.ExecuteReader();
            while (reader.Read())
            {
                obDatos = new ClPersonalE();
                obDatos.Documento = reader.GetString(1);
                obDatos.Nombre = reader.GetString(2);
                obDatos.Apellido = reader.GetString(3);
                obDatos.Telefono = reader.GetString(4);
                obDatos.Estado = reader.GetString(5);
                obDatos.Email = reader.GetString(6);
                obDatos.Contraseña = reader.GetString(7);
                obDatos.idTipoPersonal = reader.GetInt32(8);
                obDatos.idCiudad = reader.GetInt32(9);
                listPer.Add(obDatos);
            }
            return listPer;
        }

        public int mtdActualizarPersonal(ClPersonalE objDatos)
        {
            ClProcesarSQL objSQL = new ClProcesarSQL();
            string Proceso = "ActualizarPersonal";
            SqlCommand Actualizar = objSQL.mtdProcesoAlmacenado(Proceso);
            Actualizar.Parameters.AddWithValue("@idPersonal", objDatos.idPersonal);
            Actualizar.Parameters.AddWithValue("@Documento", objDatos.Documento);
            Actualizar.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Actualizar.Parameters.AddWithValue("@Apellido", objDatos.Apellido);
            Actualizar.Parameters.AddWithValue("@Telefono", objDatos.Telefono);
            Actualizar.Parameters.AddWithValue("@Estado", objDatos.Estado);
            Actualizar.Parameters.AddWithValue("@Email", objDatos.Email);
            Actualizar.Parameters.AddWithValue("@Contraseña", objDatos.Contraseña);
            Actualizar.Parameters.AddWithValue("@idTipoPersonal", objDatos.idTipoPersonal);
            Actualizar.Parameters.AddWithValue("@idCiudad", objDatos.idCiudad);
            int ActualizarDatos = Actualizar.ExecuteNonQuery();
            return ActualizarDatos;
        }
        public int mtdEliminarDato(ClPersonalE objDatos)
        {
            ClProcesarSQL objSQL = new ClProcesarSQL();
            string Proceso = "EliminarDatoPorID";
            SqlCommand Eliminar = objSQL.mtdProcesoAlmacenado(Proceso);

            Eliminar.Parameters.AddWithValue("@idPersonal", objDatos.idPersonal);

            int EliminarDatos = Eliminar.ExecuteNonQuery();
            return EliminarDatos;

        }

    }
}