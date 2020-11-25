using AGENDARestful.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AGENDARestful.Controllers
{
    public class UsuarioController : ApiController
    {
        [Route("api/usuario/cadastrar")]
        [HttpPost]
        public CadastrarRetornoEnum Cadastrar([FromBody] USUARIO usuario)
        {
            return Usuario.Usuario.Cadastrar(usuario);
        }

        [Route("api/usuario/deletar")]
        [HttpPost]
        public void deletar([FromBody] int IdUsuario)
        {
            Usuario.Usuario.Deletar(IdUsuario);
        }

        [Route("api/usuario/atualizar")]
        [HttpPost]
        public void atualizar([FromBody] USUARIO usuario)
        {
            Usuario.Usuario.Atualizar(usuario);
        }

        [Route("api/usuario/getusuario")]
        [HttpGet]
        public USUARIO GetUsuario(string email)
        {
           return Usuario.Usuario.GetUsuario(email);
        }

        [Route("api/usuario/getallusuario")]
        [HttpGet]
        public List<USUARIO> GetAllUsuario()
        {
            return Usuario.Usuario.GetAllUsuario();
        }
    }
}
