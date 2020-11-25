using AGENDARestful.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDARestful.Usuario
{
    public class Usuario
    {
        public static CadastrarRetornoEnum Cadastrar(USUARIO usuario)
        {
            using (var repo = new Models.Repository.UsuarioRepository())
            {
                return repo.Cadastrar(usuario);
            }
        }

        public static void Deletar(int IdUsuario)
        {
            using (var repo = new Models.Repository.UsuarioRepository())
            {
                repo.deletar(IdUsuario);
            }
        }

        public static void Atualizar(USUARIO usuario)
        {
            using (var repo = new Models.Repository.UsuarioRepository())
            {
                repo.atualizar(usuario);
            }
        }

        public static USUARIO GetUsuario(string email)
        {
            using (var repo = new Models.Repository.UsuarioRepository())
            {
                return repo.GetUsuario(email);
            }
        }

        public static List<USUARIO> GetAllUsuario()
        {
            using (var repo = new Models.Repository.UsuarioRepository())
            {
                return repo.GetAllUsuario();
            }
        }
    }
}