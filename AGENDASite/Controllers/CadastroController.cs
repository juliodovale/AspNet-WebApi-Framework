using AGENDASite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGENDASite.Controllers
{
    public class CadastroController : Controller
    {

        private readonly Services.AgendaRestfulService usuarioService;

        public CadastroController()
        {
            usuarioService = new Services.AgendaRestfulService();
        }


        [Authorize]
        public ActionResult Usuario()
        {
            var listUsuarios = usuarioService.GetAllUsuario();
            return View(listUsuarios);
        }

        [HttpPost]
        public string Cadastrar()
        {

            var data = Request["data"];
            var formUsuario = JsonConvert.DeserializeObject<Models.DTO.USUARIO>(data);

            var createdUser = usuarioService.CadastrarUsuario(formUsuario);

            return createdUser ? "Usuario criado com sucesso!" : "Falha ao criar usuario";
        }
    }
}