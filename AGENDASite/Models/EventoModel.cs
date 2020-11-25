using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDASite.Models
{
    public class EventoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public string Local { get; set; }
        public int IdStatus { get; set; }
        public int IdTipo { get; set; }
    }
}