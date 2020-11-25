using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDASite.Models.DTO
{
    public class USUARIO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string nascimento { get; set; }
        public int idGenero { get; set; }
        public string genero { get; set; }

    }
}