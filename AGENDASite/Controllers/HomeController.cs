using AGENDASite.Models;
using AGENDASite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGENDASite.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgendaRestfulService agendaResfulService;


        public HomeController()
        {
            agendaResfulService = new AgendaRestfulService();
        }

        //private static List<EventoModel> _listaEvento = new List<EventoModel>()
        //{
        //    new EventoModel() { Id=1, Nome="Reunião Diária", Descricao="Posição dos Projetos", Data="01/01/2021", Local= "Sala 1", IdStatus=1, IdTipo= 1}
        //};

        [Authorize]
        public ActionResult Index(int id)
        {
            var eventosPorUsuario = agendaResfulService.GetEventosPorUsuario(id);
            return View(eventosPorUsuario);
        }
    }
}

