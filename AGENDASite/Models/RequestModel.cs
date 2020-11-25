using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGENDASite.Models
{
    public class RequestModel
    {
        public string url { get; set; }
        public Dictionary<string, string> headers { get; set; }
        public string contentType { get; set; }
        public string body { get; set; }
        public string token { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
    }
}