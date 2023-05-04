using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;
using static WebAppDipnicox.Datos.ClTipoPersonalD;

namespace WebAppDipnicox.Datos
{
    public class ClTipoPersonalD
    {
        public List<ClTipoPersonalE> mtdListarTipoPersonal()
        {
            string sql = "SELECT * FROM TipoPersonal";
            ClProcesarSQL objSQL = new ClProcesarSQL();
            DataTable tblDatos = objSQL.mtdSelectDesc(sql);

            List<ClTipoPersonalE> ListaTipoPersonal = new List<ClTipoPersonalE>();
            ClTipoPersonalE objDatosTiposPersonal = null;

            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                objDatosTiposPersonal = new ClTipoPersonalE();
                objDatosTiposPersonal.idTipoPersonal = int.Parse(tblDatos.Rows[i]["idTipoPersonal"].ToString());
                objDatosTiposPersonal.TipoPersonal = tblDatos.Rows[i]["TipoPersonal"].ToString();
                ListaTipoPersonal.Add(objDatosTiposPersonal);
            }

            return ListaTipoPersonal;
        }
    }
}