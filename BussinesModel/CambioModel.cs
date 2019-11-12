using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDirmod.Models
{
    public class CambioModel
    {
        public string updated { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string value { get; set; }
        public string quantity { get; set; }
        public string amount { get; set; }
    }

    public class ResultCambioModel
    {
        public CambioModel result { get; set; }
        public string status { get; set; }
    }
}