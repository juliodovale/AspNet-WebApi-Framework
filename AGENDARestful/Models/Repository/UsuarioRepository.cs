using AGENDARestful.Models.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDARestful.Models.Repository
{
    public class UsuarioRepository: Repository
    {
        public CadastrarRetornoEnum Cadastrar(USUARIO Usuario)
        {
            try
            {
                string query = @"SELECT TOP 1 * FROM USUARIO WHERE EMAIL = @EMAIL";
                var currentUser = GetConnection().Query<USUARIO>(query, new { EMAIL = Usuario.email }).FirstOrDefault();

                if (currentUser == null)
                {
                    query = @"insert into usuario (NOME, EMAIL, SENHA, NASCIMENTO, IDGENERO) 
                             values (@nome, @email, @senha, @nascimento, (SELECT TOP 1 ID FROM GENERO WHERE DESCRICAO = @DESCRICAO))";
                    GetConnection().Query(query, new
                    {
                        nome = Usuario.nome,
                        email = Usuario.email,
                        senha = Usuario.senha,
                        nascimento = Usuario.nascimento,
                        DESCRICAO = Usuario.genero

                    }).FirstOrDefault();

                    return CadastrarRetornoEnum.cadastrado;
                }
                else
                {
                    return CadastrarRetornoEnum.existente;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return CadastrarRetornoEnum.falha;
            }
        }

        public void deletar(int IdUsuario)
        {
            string query = @"delete from usuario where id = @id";
            GetConnection().Query(query, new { id = IdUsuario }).FirstOrDefault();
        }

        public void atualizar(USUARIO usuario)
        {
            string query1 = @"select * from usuario where id = @id";
            var item = GetConnection().Query(query1, new { id = usuario.id }).FirstOrDefault();

            if (item != null)
            {
                string query2 = @"update usuario 
                                   set nome = @nome, email = @email, senha = @senha, nascimento = @nascimento, idgenero = @idgenero
                                 where id = @id";
                GetConnection().Query(query2, new
                {
                    id = usuario.id,
                    nome = usuario.nome,
                    email = usuario.email,
                    senha = usuario.senha,
                    nascimento = usuario.nascimento,
                    idgenero = usuario.idGenero
                }).FirstOrDefault();
            }

        }

        public USUARIO GetUsuario(string email)
        {
            string query = @"SELECT * FROM USUARIO WHERE EMAIL = @EMAIL";
            var Usuario = GetConnection().Query<USUARIO>(query, new { EMAIL = email }).FirstOrDefault();

            return Usuario;

        }

        public List<USUARIO> GetAllUsuario()
        {
            string query = @"	SELECT 
		                             A.ID
		                            ,A.NOME
		                            ,A.EMAIL
		                            ,A.SENHA
		                            ,A.NASCIMENTO
		                            ,A.IDGENERO
		                            ,B.DESCRICAO AS GENERO 
	                            FROM USUARIO A 
	                            join GENERO B ON B.ID = A.IDGENERO";
            var list = GetConnection().Query<USUARIO>(query).ToList();

            return list;
        }
    }
}