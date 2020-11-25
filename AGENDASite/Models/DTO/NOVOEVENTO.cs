using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDASite.Models.DTO
{
    public class NOVOEVENTO
    {
        public EVENTO Evento { get; set; }
        public string TipoEvento { get; set; }
        public string StatusEvento { get; set; }
        public List<int> Usuarios { get; set; }
    }
    
}