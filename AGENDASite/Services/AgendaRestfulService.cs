using AGENDASite.Models;
using AGENDASite.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AGENDASite.Services
{
    public class AgendaRestfulService: BaseService
    {
        public bool CadastrarUsuario(USUARIO Usuario)
        {
            var endPoint = "/api/usuario/cadastrar";
            var response = Post<USUARIO>(endPoint, Usuario);

            return response.Success;
        }
        public bool DeletarUsuario(int IdUsuario)
        {
            var endPoint = "/api/usuario/deletar";
            var response = Post<string>(endPoint, IdUsuario.ToString());

            return response.Success;
        }
        public bool AtualizarUsuario(USUARIO Usuario)
        {
            var endPoint = "/api/usuario/atualizar";
            var response = Post<USUARIO>(endPoint, Usuario);

            return response.Success;
        }
        public USUARIO GetUsuario(string email)
        {
            var endPoint = "api/usuario/getusuario?email=" + email;
            var response = Get(endPoint);


            if (response.Success)
            {
                var Usuario = JsonConvert.DeserializeObject<USUARIO>(response.Data);
                return Usuario;
            }
            else
            {
                return null;
            }
            
        }

        public List<USUARIO> GetAllUsuario()
        {
            var endPoint = "api/usuario/getallusuario";
            var response = Get(endPoint);


            if (response.Success)
            {
                var list = JsonConvert.DeserializeObject<List<USUARIO>>(response.Data);
                return list;
            }
            else
            {
                return null;
            }

        }
        public bool CriarEvento(NOVOEVENTO NovoEvento)
        {
            var endPoint =  "/api/agenda/criarevento";
            var response = Post<NOVOEVENTO>(endPoint, NovoEvento);

            return response.Success;

        }
        public bool DeletarEvento(int IdEvento)
        {
            
            var endPoint = "/api/agenda/deletarevento";
            var response = Post<string>(endPoint, IdEvento.ToString());

            return response.Success;

        }
        public bool AtualizarEvento(EVENTO Evento)
        {
            
            var endPoint = "/api/agenda/atualizarevento";
            var response = Post<EVENTO>(endPoint, Evento);

            return response.Success;

        }
        public List<EVENTOSPORUSUARIO> GetEventosPorUsuario(int IdUsuario)
        {
            List<EVENTOSPORUSUARIO> list = null;
            var endPoint = "/api/agenda/geteventosporusuario?idUsuario=" + IdUsuario;
            var response = Get(endPoint);
            
            if (response.Success)
            {
                list = JsonConvert.DeserializeObject<List<EVENTOSPORUSUARIO>>(response.Data);
            }
            return list;
        }
        private ResponseModel Post<T>(string endPoint, T body)
        {
            var requestModel = new RequestModel();
            var headers = new Dictionary<string, string>();
            var baseUrl = ConfigurationManager.AppSettings["BASEURL"];
            requestModel.url = baseUrl + endPoint;
            headers.Add("cache-control", "no-cache");
            requestModel.headers = headers;
            requestModel.body = body.GetType() != typeof(string) ? JsonConvert.SerializeObject(body) : requestModel.body;

            var response = Post(requestModel);

            return response;
        }
        private ResponseModel Get(string endPoint)
        {
            var requestModel = new RequestModel();
            var headers = new Dictionary<string, string>();
            
            headers.Add("cache-control", "no-cache");
            requestModel.headers = headers;
            requestModel.body = "";

            var baseUrl = ConfigurationManager.AppSettings["BASEURL"];
            requestModel.url = baseUrl + endPoint;

            var response = Get(requestModel);

            return response;
        }
    }
}