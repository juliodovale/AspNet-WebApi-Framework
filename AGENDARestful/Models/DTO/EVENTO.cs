﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDARestful.Models.DTO
{
    public class EVENTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public string local { get; set; }

    }
    
}