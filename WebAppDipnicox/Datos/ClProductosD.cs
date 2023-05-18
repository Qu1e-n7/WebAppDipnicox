using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppDipnicox.Entidades;
using WebAppDipnicox.Vista;

namespace WebAppDipnicox.Datos
{
    public class ClProductosD
    {
        ClProcesarSQL obSQL = new ClProcesarSQL();
        ClProductosE obDatos = null;
        public int mtdRegistrar(ClProductosE objDatos)
        {
            string Proceso="AgregarProductos";
            SqlCommand Registro = obSQL.mtdProcesoAlmacenado(Proceso);
            Registro.Parameters.AddWithValue("@Codigo", objDatos.Codigo);
            Registro.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Registro.Parameters.AddWithValue("@Descripcion", objDatos.Descripcion);
            Registro.Parameters.AddWithValue("@Valor", objDatos.Valor);
            Registro.Parameters.AddWithValue("@Cantidad", objDatos.Cantidad);
            Registro.Parameters.AddWithValue("@Medida", objDatos.UnidadMed);
            Registro.Parameters.AddWithValue("@idtpProd", objDatos.idTipoProducto);
            int Registar=Registro.ExecuteNonQuery();
            return Registar;
        }

        public List<ClProductosE> mtdListaPorProducto(int id)
        {
            string Proceso = "ListaPorProducto";
            
            SqlCommand ComList = obSQL.mtdProcesoAlmacenado(Proceso);
            List<ClProductosE> listProdu = new List<ClProductosE>();
            ComList.Parameters.AddWithValue("@idProducto", id);
            SqlDataReader Dato = ComList.ExecuteReader();
            while (Dato.Read())
            {
                obDatos = new ClProductosE();
                obDatos.Codigo =Dato.GetString(1);
                obDatos.Nombre =Dato.GetString(2);
                obDatos.Descripcion =Dato.GetString(3);
                obDatos.Valor =Dato.GetInt32(4);
                obDatos.Cantidad =Dato.GetInt32(5);
                obDatos.UnidadMed =Dato.GetString(6);
                obDatos.idTipoProducto =Dato.GetInt32(7);
                listProdu.Add(obDatos);
            }
            return listProdu;
        }
        public List<ClProductosE> mtdListarProductos()
        {
            string proceso = "ListarProductos";
            SqlCommand ComaList = obSQL.mtdProcesoAlmacenado(proceso);
            SqlDataReader datosread=ComaList.ExecuteReader();
            List<ClProductosE> ListProduc=new List<ClProductosE>();
            while (datosread.Read())
            {
                obDatos = new ClProductosE();
                obDatos.Codigo = datosread.GetString(0);
                obDatos.Nombre = datosread.GetString(1);
                obDatos.Descripcion = datosread.GetString(2);
                obDatos.Valor = datosread.GetInt32(3);
                obDatos.Cantidad = datosread.GetInt32(4);
                obDatos.UnidadMed = datosread.GetString(5);
                obDatos.idTipoProducto = datosread.GetInt32(6);
                ListProduc.Add(obDatos);
            }
            return ListProduc;
        }


    }
}