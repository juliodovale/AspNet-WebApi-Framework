using AGENDARestful.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDARestful.Agenda
{
    public class Agenda
    {
       
        public static void CriarEvento(NOVOEVENTO NovoEvento)
        {
            using (var repo = new Models.Repository.AgendaRepository())
            {
                repo.criarevento(NovoEvento);
            }
        }

        public static void DeletarEvento(int  IdEvento)
        {
            using (var repo = new Models.Repository.AgendaRepository())
            {
                repo.DeletarEvento(IdEvento);
            }
        }

        public static void AtualizarEvento(EVENTO evento)
        {
            using (var repo = new Models.Repository.AgendaRepository())
            {
                repo.AtualizarEvento(evento);
            }
        }

        public static List<EVENTOSPORUSUARIO> GetEventosPorUsuario(int IdEvento)
        {
            using (var repo = new Models.Repository.AgendaRepository())
            {
                return repo.GetEventosPorUsuario(IdEvento);
            }
        }
    }
}