using AGENDARestful.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AGENDARestful.Controllers
{
    public class AgendaController : ApiController
    {
       
        [Route("api/agenda/criarevento")]
        [HttpPost]
        public void criarevento([FromBody] NOVOEVENTO NovoEvento)
        {
            Agenda.Agenda.CriarEvento(NovoEvento);
        }

        [Route("api/agenda/deletarevento")]
        [HttpPost]
        public void DeletarEvento([FromBody] int IdEvento)
        {
            Agenda.Agenda.DeletarEvento(IdEvento);
        }

        [Route("api/agenda/atualizarevento")]
        [HttpPost]
        public void atualizarevento([FromBody] EVENTO id)
        {
            Agenda.Agenda.AtualizarEvento(id);
        }

        [Route("api/agenda/geteventosporusuario")]
        [HttpGet]
        public List<EVENTOSPORUSUARIO> GetEventosPorUsuario(int idUsuario)
        {
           return Agenda.Agenda.GetEventosPorUsuario(idUsuario);
        }

    }
}
