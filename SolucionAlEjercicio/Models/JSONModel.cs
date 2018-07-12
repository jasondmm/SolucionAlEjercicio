using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolucionAlEjercicio.Models
{
    public class JSONModel
    {
        public class Base
        {
            public string source { get; set; }
            public string replacement { get; set; }
        }
        public class Values
        {
            public int order { get; set; }
            public int rule { get; set; }
            public bool isTermination { get; set; }
        }
    }
}