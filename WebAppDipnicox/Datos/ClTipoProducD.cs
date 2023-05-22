using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClTipoProducD
    {
        public List<ClTipoProducE> mtdListarTipoPersonal()
        {
            string sql = "SELECT * FROM TipoProduc";
            ClProcesarSQL objSQL = new ClProcesarSQL();
            DataTable tblDatos = objSQL.mtdSelectDesc(sql);

            List<ClTipoProducE> listTipProd = new List<ClTipoProducE>();
            ClTipoProducE obDatoTipProd = null;

            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                obDatoTipProd = new ClTipoProducE();
                obDatoTipProd.idTipoProduc = int.Parse(tblDatos.Rows[i]["idTipoProduc"].ToString());
                obDatoTipProd.Nombre = tblDatos.Rows[i]["Nombre"].ToString();
                listTipProd.Add(obDatoTipProd);
            }

            return listTipProd;
        }
    }
}