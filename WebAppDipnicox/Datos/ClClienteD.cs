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
        ClProcesarSQL objSQL = new ClProcesarSQL();
        public ClClienteE mtdLogin(string Usua, string Clave)
        {

            string consulta = "Select * from Cliente where Email='" + Usua + "' and Contraseña='" + Clave + "'";
            DataTable tblPersonal = objSQL.mtdSelectDesc(consulta);
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

        public int mtdRegistrarCliente(ClClienteE objDatos)
        {

            string Proceso = "RegistrarCliente";
            SqlCommand Registro = objSQL.mtdProcesoAlmacenado(Proceso);
            Registro.Parameters.AddWithValue("@Documento", objDatos.Documento);
            Registro.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Registro.Parameters.AddWithValue("@Apellido", objDatos.Apellido);
            Registro.Parameters.AddWithValue("@Telefono", objDatos.Telefono);
            Registro.Parameters.AddWithValue("@Email", objDatos.Email);
            Registro.Parameters.AddWithValue("@Contraseña", objDatos.Contraseña);
            Registro.Parameters.AddWithValue("@idCiudad", objDatos.idCiudad);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }

        public List<ClClienteE> Lista()
        {
            string Consulta = "Select * from Cliente";
            DataTable dt = objSQL.mtdSelectDesc(Consulta);
            ClClienteE obClienteE = null;
            List<ClClienteE> Lista = new List<ClClienteE>();
            if (dt.Rows.Count > 0)
            {
                obClienteE = new ClClienteE();
                obClienteE.idCliente = int.Parse(dt.Rows[0]["idCliente"].ToString());

                obClienteE.Nombre = dt.Rows[0]["Nombre"].ToString();
                obClienteE.Apellido = dt.Rows[0]["Apellido"].ToString();
                Lista.Add(obClienteE);
            }

            return Lista;
        }
    }

}
