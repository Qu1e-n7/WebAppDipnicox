using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClProductoVentaD
    {
        ClProcesarSQL objSQL= new ClProcesarSQL();
        public List<ClVentaE> mtdListProdVen(int idVenta)
        {
            SqlCommand Listar = objSQL.mtdProcesoAlmacenado("ListaProduVentaId");
            Listar.Parameters.AddWithValue("@idVenta", idVenta);
            List<ClVentaE> Lista = new List<ClVentaE>();
            ClVentaE obDatos = null;
            SqlDataReader rd = Listar.ExecuteReader();
            while (rd.Read())
            {
                obDatos = new ClVentaE();
                obDatos.idProductoVenta = rd.GetInt32(0);
                obDatos.Nombre = rd.GetString(2);
                obDatos.Image = rd.GetString(1);
                obDatos.Valor = rd.GetInt32(3);
                obDatos.Cantidad = rd.GetInt32(4); ;
                obDatos.Total = rd.IsDBNull(5) ? 0 : rd.GetInt32(5);
                obDatos.Estado = rd.GetString(6); ;
                Lista.Add(obDatos);
            }
            return Lista;
        }
        public int mtdRegProductoVenta(ClVentaE objDatos)
        {
            SqlCommand Registro = objSQL.mtdProcesoAlmacenado("AgregarProductoVenta");
            Registro.Parameters.AddWithValue("@idVenta", objDatos.idVenta);
            Registro.Parameters.AddWithValue("@idProducto", objDatos.idProducto);
            Registro.Parameters.AddWithValue("@Cantidad", objDatos.CantidadVen);
            int Registar = Registro.ExecuteNonQuery();
            return Registar;
        }
        public int mtdEliminar(int idProdVenta)
        {
            SqlCommand eliminar = objSQL.mtdProcesoAlmacenado("EliminarProdVenta");
            eliminar.Parameters.AddWithValue("@idProdVenta", idProdVenta);
            int eliminado = eliminar.ExecuteNonQuery();
            return eliminado;

        }
    }
}