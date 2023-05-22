using Microsoft.Win32;
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
        ClProductosE obDatos = new ClProductosE();
        ClConexion obconexion=new ClConexion();
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
            Registro.Parameters.AddWithValue("@idTpProd", objDatos.idTipoProducto);
            int Registar=Registro.ExecuteNonQuery();
            return Registar;
        }

        public int mtdActualizar(ClProductosE objDatos)
        {
            string Proceso = "ActualizarProductos";
            SqlCommand Actualizar = obSQL.mtdProcesoAlmacenado(Proceso);
            Actualizar.Parameters.AddWithValue("@idProduc", objDatos.idProducto);
            Actualizar.Parameters.AddWithValue("@Codigo", objDatos.Codigo);
            Actualizar.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Actualizar.Parameters.AddWithValue("@Descripcion", objDatos.Descripcion);
            Actualizar.Parameters.AddWithValue("@Valor", objDatos.Valor);
            Actualizar.Parameters.AddWithValue("@Cantidad", objDatos.Cantidad);
            Actualizar.Parameters.AddWithValue("@Medida", objDatos.UnidadMed);
            Actualizar.Parameters.AddWithValue("@idTipProd", objDatos.idTipoProducto);
            int Actu = Actualizar.ExecuteNonQuery();
            return Actu;
        }
        public int mtdEliminar(int idPro)
        {
            string Proceso = "EliminarProducto";
            SqlCommand Borrar = obSQL.mtdProcesoAlmacenado(Proceso);
            Borrar.Parameters.AddWithValue("@idProd", idPro);
            int Eliminar =Borrar.ExecuteNonQuery();
            return Eliminar;
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
                obDatos.idProducto = Convert.ToInt32(datosread["idProducto"].ToString());
                obDatos.Codigo = datosread["Codigo"].ToString();
                obDatos.Nombre = datosread["Nombre"].ToString();
                obDatos.Descripcion = datosread["Descripcion"].ToString();
                obDatos.Valor = Convert.ToInt32(datosread["ValorUni"]);
                obDatos.Cantidad = Convert.ToInt32(datosread["Cantidad"]);
                obDatos.UnidadMed = datosread["UnidadMedida"].ToString();
                obDatos.idTipoProducto = Convert.ToInt32(datosread["idTipoProduc"]);
                ListProduc.Add(obDatos);
            }
            return ListProduc;
        }


    }
}