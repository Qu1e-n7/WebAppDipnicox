using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
        ClConexion obconexion = new ClConexion();
        public int mtdRegistrar(ClProductosE objDatos)
        {
            string Proceso = "AgregarProductos";
            SqlCommand Registro = obSQL.mtdProcesoAlmacenado(Proceso);
            Registro.Parameters.AddWithValue("@Codigo", objDatos.Codigo);
            Registro.Parameters.AddWithValue("@Nombre", objDatos.Nombre);
            Registro.Parameters.AddWithValue("@Descripcion", objDatos.Descripcion);
            Registro.Parameters.AddWithValue("@image", objDatos.Image);
            Registro.Parameters.AddWithValue("@Valor", objDatos.Valor);
            Registro.Parameters.AddWithValue("@Cantidad", objDatos.Cantidad);
            Registro.Parameters.AddWithValue("@Medida", objDatos.UnidadMed);
            Registro.Parameters.AddWithValue("@idTpProd", objDatos.idTipoProducto);
            int Registar = Registro.ExecuteNonQuery();
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
            Actualizar.Parameters.AddWithValue("@image", objDatos.Image);
            Actualizar.Parameters.AddWithValue("@Valor", objDatos.Valor);
            Actualizar.Parameters.AddWithValue("@Cantidad", objDatos.Cantidad);
            Actualizar.Parameters.AddWithValue("@Medida", objDatos.UnidadMed);
            Actualizar.Parameters.AddWithValue("@idTipProd", objDatos.idTipoProducto);
            int Actu = Actualizar.ExecuteNonQuery();
            return Actu;
        }
        public List<ClNotificacionE> mtdTrMensa(int id )
        {
            List<ClNotificacionE> mensajes= new List<ClNotificacionE>();
            ClNotificacionE obNotifi =null;
            string trigger = "(SELECT * FROM ( SELECT Titulo,Descripcion, SUBSTRING(Descripcion, CHARINDEX('Para:', Descripcion) + LEN('Para:'), CHARINDEX('Mensaje:', Descripcion) - CHARINDEX('Para:', Descripcion) - LEN('Para:')) AS id FROM Notificaciones WHERE Descripcion LIKE '%Para:%Mensaje:%COT:%') AS Subconsulta WHERE id = "+id+")";
            SqlCommand TriggMensa = obSQL.mtdTrigger(trigger);
            SqlDataReader reader = TriggMensa.ExecuteReader();
            while (reader.Read())
            {
                obNotifi = new ClNotificacionE();
                obNotifi.Titulo = reader.GetString(0);
                obNotifi.Descripcion = reader.GetString(1);
                mensajes.Add(obNotifi);
            }

            return mensajes;
        }
        public List<ClNotificacionE> mtdTrMensa1()
        {
            List<ClNotificacionE> mensajes = new List<ClNotificacionE>();
            ClNotificacionE obNotifi = null;
            string trigger = "  SELECT Titulo,Descripcion FROM Notificaciones";
            SqlCommand TriggMensa = obSQL.mtdTrigger(trigger);
            SqlDataReader reader = TriggMensa.ExecuteReader();
            while (reader.Read())
            {
                obNotifi = new ClNotificacionE();
                obNotifi.Titulo = reader.GetString(0);
                obNotifi.Descripcion = reader.GetString(1);
                mensajes.Add(obNotifi);
            }

            return mensajes;
        }
        public int mtdEliminar(int idPro)
        {
            string Proceso = "EliminarProducto";
            SqlCommand Borrar = obSQL.mtdProcesoAlmacenado(Proceso);
            Borrar.Parameters.AddWithValue("@idProd", idPro);
            int Eliminar = Borrar.ExecuteNonQuery();
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
                obDatos.Codigo = Dato.GetString(1);
                obDatos.Nombre = Dato.GetString(2);
                obDatos.Descripcion = Dato.GetString(3);
                obDatos.Image = Dato.GetString(4);
                obDatos.Valor = Dato.GetInt32(5);
                obDatos.Cantidad = Dato.GetInt32(6);
                obDatos.UnidadMed = Dato.GetString(7);
                obDatos.idTipoProducto = Dato.GetInt32(8);
                listProdu.Add(obDatos);
            }
            return listProdu;
        }
        public List<ClProductosE> mtdListarProductos()
        {
            string proceso = "ListarProductos";
            SqlCommand ComaList = obSQL.mtdProcesoAlmacenado(proceso);
            SqlDataReader datosread = ComaList.ExecuteReader();
            List<ClProductosE> ListProduc = new List<ClProductosE>();
            while (datosread.Read())
            {
                obDatos = new ClProductosE();
                obDatos.idProducto = Convert.ToInt32(datosread["idProducto"].ToString());
                obDatos.Codigo = datosread["Codigo"].ToString();
                obDatos.Nombre = datosread["Nombre"].ToString();
                obDatos.Descripcion = datosread["Descripcion"].ToString();
                obDatos.Image = datosread["Imagen"].ToString();
                obDatos.Valor = Convert.ToInt32(datosread["ValorUni"]);
                obDatos.Cantidad = Convert.ToInt32(datosread["Cantidad"]);
                obDatos.UnidadMed = datosread["UnidadMedida"].ToString();
                obDatos.idTipoProducto = Convert.ToInt32(datosread["idTipoProduc"]);
                ListProduc.Add(obDatos);
            }
            return ListProduc;
        }

        public List<ClProductosE> mtdBuscar(string Nombrebusca)
        {
            string Proceso = "BuscarProducto";

            SqlCommand ComList = obSQL.mtdProcesoAlmacenado(Proceso);
            List<ClProductosE> listaProd = new List<ClProductosE>();
            ComList.Parameters.AddWithValue("@Nombre", Nombrebusca);
            SqlDataReader BuscarDatos = ComList.ExecuteReader();

            while (BuscarDatos.Read())
            {
                obDatos = new ClProductosE();
                obDatos.Codigo = BuscarDatos.GetString(1);
                obDatos.Nombre = BuscarDatos.GetString(2);
                obDatos.Descripcion = BuscarDatos.GetString(3);
                //obDatos.Image = BuscarDatos.GetString(4);
                obDatos.Valor = BuscarDatos.GetInt32(4);
                obDatos.Cantidad = BuscarDatos.GetInt32(5);
                obDatos.UnidadMed = BuscarDatos.GetString(6);
                obDatos.idTipoProducto = BuscarDatos.GetInt32(7);
                listaProd.Add(obDatos);
            }
            return listaProd;

        }
    }
}