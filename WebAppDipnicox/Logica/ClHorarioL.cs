using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppDipnicox.Datos;
using WebAppDipnicox.Entidades;

namespace WebAppDipnicox.Logica
{
    public class ClHorarioL
    {
        ClHorarioD obHorario = new ClHorarioD();
        public List<ClDiaE> mtdListaDias()
        {
            List<ClDiaE> Lista=obHorario.mtdDias();
            return Lista;
        }
        public int mtdAgregarHorario(ClHorarioE obDatos)
        {
            int registrar = obHorario.mtdAgregarHorario(obDatos);
            return registrar;
        } 

        public int mtdAgregarHoraDi(ClHorarioDiaE obDatos)
        {
            int registrar = obHorario.AgregarHorarDia(obDatos);
            return registrar;
        }

        public List<ClHorarioDiaE> MtdListHoras(int idHorario)
        {
            List<ClHorarioDiaE> lista = obHorario.mtdListHora(idHorario);
            return lista;
        }

        public ClHorarioDiaE MtdListHoraDia(int idDia, int idHorario)
        {
            List<ClHorarioDiaE> lista = obHorario.mtdListHora(idHorario);
            ClHorarioDiaE obHorarioE = new ClHorarioDiaE();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].idHorarioDia == idDia)
                {
                    obHorarioE.idHorarioDia = lista[i].idHorarioDia;
                    obHorarioE.Dia = lista[i].Dia;
                    obHorarioE.HoraInicio = lista[i].HoraInicio;
                    obHorarioE.HoraFinal = lista[i].HoraFinal;
                    break;
                }
            

            }
            return obHorarioE;
        }
        public int mtdActHorarioDia(ClHorarioDiaE obDatos)
        {
            int Actualizar = obHorario.mtdActuHorarioDia(obDatos);
            return Actualizar;

        }

        public int mtdidHorario(int id)
        {
            List<ClHorarioE> Lista = obHorario.mtdListHorario(id);
            int idHorario = 0;
            for (int i = 0; i < Lista.Count; i++)
            {
                if (Lista[i].idPersonal==id)
                {
                    idHorario = Lista[i].idHorario;
                    break;
                }
            }
            return idHorario;

        }

        public int mtdEliHorarioDia(int idHorarDia)
        {
            int eliminar = obHorario.mtdEliHorarioDia(idHorarDia);
            return eliminar;
        }
    }
}