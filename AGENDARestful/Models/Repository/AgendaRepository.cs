using AGENDARestful.Models.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDARestful.Models.Repository
{
    public class AgendaRepository : Repository
    {
      
        public void criarevento(NOVOEVENTO NovoEvento)
        {   
            string query = @"insert into evento (idtipo, nome, descricao, data, local, idstatus )
                             values (
                                      (SELECT TOP 1 ID FROM TIPO_EVENTO WHERE DESCRICAO = @DESCRICAOEVENTO), 
                                       @nome, 
                                       @descricao,
                                       @data, 
                                       @local, 
                                       (SELECT TOP 1 ID FROM STATUS_EVENTO WHERE DESCRICAO = @DESCRICAOSTATUS)
                                   )
                            SELECT SCOPE_IDENTITY()";
            var idEvento = GetConnection().Query<int>(query, new
            {
                nome = NovoEvento.Evento.nome,
                descricao = NovoEvento.Evento.descricao,
                data = NovoEvento.Evento.data,
                local = NovoEvento.Evento.local,
                DESCRICAOEVENTO = NovoEvento.TipoEvento,
                DESCRICAOSTATUS = NovoEvento.StatusEvento
            }).FirstOrDefault();

            if (idEvento > 0)
            {
                NovoEvento.Usuarios.ForEach(user => 
                {
                    query = "INSERT INTO PARTICIPANTES_EVENTO (IDEVENTO, IDUSUARIO) VALUES (@IDEVENTO, @IDUSUARIO)";
                    GetConnection().Query(query, new { IDEVENTO = idEvento, IDUSUARIO = user }).FirstOrDefault();
                });
            }
        }

        public void DeletarEvento (int IdEvento)
        {
            string query = @"DELETE PARTICIPANTES WHERE IDEVENTO = @IDEVENTO";
            GetConnection().Query(query, new { IDEVENTO = IdEvento }).FirstOrDefault();

            query = @"delete from evento where id = @id";
            GetConnection().Query(query, new { id = IdEvento }).FirstOrDefault();
        }

        public void AtualizarEvento(EVENTO Evento)
        {
            string query1 = @"select * from evento where id = @id";
            var item = GetConnection().Query(query1, new { id = Evento.id }).FirstOrDefault();

            if (item != null)
            {
                string query2 = @"update evento 
                                 set idtipo = @idtipo, nome = @nome, descricao = @descricao, data = @data, local = @local, idstatus = @idstatus";
                GetConnection().Query(query2, new
                {
                    nome = item.nome,
                    descricao = item.descricao,
                    data = item.data,
                    local = item.local,
                    idstatus = item.id
               }).FirstOrDefault();
            }

        }
        public List<EVENTOSPORUSUARIO> GetEventosPorUsuario(int idUsuario)
        {
            string query = @"SELECT 
                                 A.ID AS IDEVENTO
                                ,A.NOME AS NOMEEVENTO
                                ,A.DESCRICAO AS DESCRICAOEVENTO
                                ,A.DATA AS DATAEVENTO
                                ,A.LOCAL AS LOCALEVENTO
                                ,C.ID AS IDUSUARIO
                                ,C.NOME AS NOMEUSUARIO
                                ,C.EMAIL AS EMAILUSUARIO
                                ,C.NASCIMENTO AS NASCIMENTOUSUARIO
                                ,F.DESCRICAO AS GENEROUSUARIO
                                ,D.DESCRICAO AS DESCRICAOSTATUS
                                ,E.DESCRICAO AS DESCRICAOTIPOEVENTO
                            FROM EVENTO A
                            JOIN PARTICIPANTES_EVENTO B ON B.IDEVENTO = A.ID
                            JOIN USUARIO C ON C.ID = B.IDUSUARIO
                            JOIN STATUS_EVENTO D ON D.ID = A.IDSTATUS
                            JOIN TIPO_EVENTO E ON E.ID = A.IDTIPO
                            JOIN GENERO F ON F.ID = C.IDGENERO
                            WHERE C.ID = @IDUSUARIO";

            var list = GetConnection().Query<EVENTOSPORUSUARIO>(query, new { IDUSUARIO = idUsuario }).ToList();

            return list;
        }

    }
}