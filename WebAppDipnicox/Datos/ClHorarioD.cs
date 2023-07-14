using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Datos
{
    public class ClHorarioD
    {
        ClProcesarSQL obSQL = new ClProcesarSQL();
        public List<ClDiaE> mtdDias()
        {
            string proceso = "ListarDias";
            SqlCommand ComaList = obSQL.mtdProcesoAlmacenado(proceso);
            SqlDataReader datosread = ComaList.ExecuteReader();
            List<ClDiaE> ListDias = new List<ClDiaE>();
            ClDiaE obDatos = null;
            while (datosread.Read())
            {
                obDatos = new ClDiaE();
                obDatos.idDia = Convert.ToInt32(datosread["idDia"].ToString());
                obDatos.Dia = datosread["Dia"].ToString();
                ListDias.Add(obDatos);
            }
            return ListDias;
        }
        public int mtdAgregarHorario(ClHorarioE obDatos)
        {
            SqlCommand Agregar = obSQL.mtdProcesoAlmacenado("AgregarHorario");
            Agregar.Parameters.AddWithValue("@FechIni", obDatos.FechaInicio);
            Agregar.Parameters.AddWithValue("@FechFinal", obDatos.FechaFinal);
            Agregar.Parameters.AddWithValue("@idPersonal", obDatos.idPersonal);
            int agreg = Agregar.ExecuteNonQuery();
            return agreg;
        }
        public int AgregarHorarDia(ClHorarioDiaE obHorario)
        {
            string proceso = "AgregarHorarioDia";
            SqlCommand Registar = obSQL.mtdProcesoAlmacenado(proceso);
            Registar.Parameters.AddWithValue("@idHorario", obHorario.idHorario);
            Registar.Parameters.AddWithValue("@idDia", obHorario.idDia);
            Registar.Parameters.AddWithValue("@HoraIni", obHorario.HoraInicio);
            Registar.Parameters.AddWithValue("@HoraFin", obHorario.HoraFinal);
            int Registro = Registar.ExecuteNonQuery();
            return Registro;

        }

        public  List<ClHorarioE> mtdListHorario(int id)
        {
            SqlCommand Listar = obSQL.mtdProcesoAlmacenado("ListHorario");
            Listar.Parameters.AddWithValue("@idPersonal", id);
            SqlDataReader rd = Listar.ExecuteReader();
            List<ClHorarioE> ListHorario=new List<ClHorarioE>();
            ClHorarioE obDatos = null;
            while (rd.Read())
            {
                obDatos = new ClHorarioE();
                obDatos.idHorario = rd.GetInt32(0);
                obDatos.FechaInicio = rd.GetDateTime(1);
                obDatos.FechaFinal = rd.GetDateTime(2);
                obDatos.idPersonal = rd.GetInt32(3);
                ListHorario.Add(obDatos);
            }
            return ListHorario;
        }

        public List<ClHorarioDiaE> mtdListHora(int id)
        {
            SqlCommand Listar = obSQL.mtdProcesoAlmacenado("ListHoras");
            Listar.Parameters.AddWithValue("@idHorario", id);
            SqlDataReader rd = Listar.ExecuteReader();
            List<ClHorarioDiaE> ListaHorario = new List<ClHorarioDiaE>();
            ClHorarioDiaE obDatos = null;
            while (rd.Read())
            {
                obDatos = new ClHorarioDiaE();
                obDatos.idHorarioDia = rd.GetInt32(0);
                obDatos.Dia = rd.GetString(1);
                obDatos.HoraInicio = rd.GetTimeSpan(2);
                obDatos.HoraFinal = rd.GetTimeSpan(3);
                ListaHorario.Add(obDatos);
            }
            return ListaHorario;
        }

        public int mtdActuHorarioDia(ClHorarioDiaE obDatos)
        {
            SqlCommand Actualizar = obSQL.mtdProcesoAlmacenado("Actu_HorarioDia ");
            Actualizar.Parameters.AddWithValue("@idHorarDia", obDatos.idHorarioDia);
            Actualizar.Parameters.AddWithValue("@HoraIni", obDatos.HoraInicio);
            Actualizar.Parameters.AddWithValue("@HoraFin", obDatos.HoraFinal);
            int Actualizado = Actualizar.ExecuteNonQuery();
            return Actualizado;

        }
        
    }
}
