using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDASite.Models.DTO
{
    public class EVENTOSPORUSUARIO
    {
        public int IDEVENTO { get; set; }
        public string NOMEEVENTO { get; set; }
        public string DESCRICAOEVENTO { get; set; }
        public DateTime DATAEVENTO { get; set; }
        public string LOCALEVENTO { get; set; }
        public int IDUSUARIO { get; set; }
        public string NOMEUSUARIO { get; set; }
        public string EMAILUSUARIO { get; set; }
        public DateTime NASCIMENTOUSUARIO { get; set; }
        public string GENEROUSUARIO { get; set; }
        public string DESCRICAOSTATUS { get; set; }
        public string DESCRICAOTIPOEVENTO { get; set; }
    }                     
}