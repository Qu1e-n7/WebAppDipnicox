using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Vista;

namespace WebAppDipnicox.Datos
{
    public class ClVentaD
    {
        ClProcesarSQL objSQL = new ClProcesarSQL();
        public int mtdRegistrarVenta(ClVentaE objDatos)
        {
            SqlCommand Registro = objSQL.mtdProcesoAlmacenado("AgregarVenta");
            Registro.Parameters.AddWithValue("@Estado", objDatos.Estado);
            Registro.Parameters.AddWithValue("@idCliente", (object)objDatos.idCliente ?? DBNull.Value);
            Registro.Parameters.AddWithValue("@idPersonal", (object)objDatos.idPersonal ?? DBNull.Value);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }

        public List<ClVentaE> mtdListar()
        {
            SqlCommand Listar = objSQL.mtdProcesoAlmacenado("ListaVenta");
            List<ClVentaE> Lista =new List<ClVentaE>();
            ClVentaE obDatos = null;
            SqlDataReader rd = Listar.ExecuteReader();
            while (rd.Read()) {
                obDatos = new ClVentaE();
                obDatos.idVenta = rd.GetInt32(0);
                obDatos.Codigo = rd.GetString(1) ;
                obDatos.Fecha = rd.IsDBNull(2) ? null : rd.GetString(2); 
                obDatos.Estado = rd.GetString(3);
                obDatos.TotalVen = rd.IsDBNull(4) ? null : rd.GetString(4); ;
                obDatos.idCliente = rd.IsDBNull(5) ? (int?)null : rd.GetInt32(5); 
                obDatos.idPersonal = rd.IsDBNull(6) ? (int?)null : rd.GetInt32(6);
                obDatos.idTipoVenta = rd.IsDBNull(7) ? (int?)null : rd.GetInt32(7);
                Lista.Add(obDatos);
            }
            return Lista;   
        }

        public int mtdActualizar(ClVentaE obDatos)
        {
            SqlCommand actu = objSQL.mtdProcesoAlmacenado("ConfirmarVenta");
            actu.Parameters.AddWithValue("@Estado", obDatos.Estado);
            actu.Parameters.AddWithValue("@Total", obDatos.Total);
            actu.Parameters.AddWithValue("@idTipoVenta", obDatos.idTipoVenta);
            actu.Parameters.AddWithValue("@idVenta", obDatos.idVenta );
            int actualizar= actu.ExecuteNonQuery();
            return actualizar;
        }

        public List<ClVentaE> mtdConfirma()
        {
            SqlCommand Lista = objSQL.mtdProcesoAlmacenado("ListarVentasConfi");
            SqlDataReader rd = Lista.ExecuteReader();
            ClVentaE obDatos = null;
            List<ClVentaE> listaventa = new List<ClVentaE>();
            while (rd.Read())
            {
                obDatos = new ClVentaE();
                obDatos.idVenta = rd.GetInt32(0);
                obDatos.Codigo = rd.GetString(1);
                obDatos.Fecha = rd.IsDBNull(2) ? null : rd.GetString(2);
                obDatos.TotalVen = rd.GetString(3);
                obDatos.Cliente = rd.IsDBNull(4) ? null : rd.GetString(4);
                obDatos.Personal = rd.IsDBNull(5) ? null : rd.GetString(5);
                obDatos.TipVent = rd.GetString(6);
                
                listaventa.Add(obDatos);
            }
            return listaventa;
        }
        public List<ClVentaProductoE> mtdListarCodigo(int idVenta)
        {
            SqlCommand Lista = objSQL.mtdProcesoAlmacenado("ListarCodigo");
            Lista.Parameters.AddWithValue("@idVenta", idVenta);
            SqlDataReader rd = Lista.ExecuteReader();
            ClVentaProductoE obDatos = null;
            List<ClVentaProductoE> listaventa = new List<ClVentaProductoE>();
            while (rd.Read())
            {
                obDatos = new ClVentaProductoE();
                obDatos.idVenta = rd.GetInt32(0);
                obDatos.Nombre = rd.GetString(1);
                obDatos.Codigo = rd.GetString(2);
                obDatos.Total = rd.GetInt32(3);
             

                listaventa.Add(obDatos);
            }
            return listaventa;
        }

    }
}