using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClCiudadD
    {
        public List<ClCiudadE> mtdCiudad()
        {
            string sql = "SELECT * FROM Ciudad";
            ClProcesarSQL objSQL = new ClProcesarSQL();
            DataTable tblDatos = objSQL.mtdSelectDesc(sql);



            List<ClCiudadE> ListaCiudad = new List<ClCiudadE>();
            ClCiudadE objCiudad = null;

            for (int i = 0; i < tblDatos.Rows.Count; i++)
            {
                objCiudad = new ClCiudadE();
                objCiudad.idCiudad = int.Parse(tblDatos.Rows[i]["idCiudad"].ToString());
                objCiudad.Ciudad = tblDatos.Rows[i]["Ciudad"].ToString();
                ListaCiudad.Add(objCiudad);
            }

            return ListaCiudad;
        }
    }
}