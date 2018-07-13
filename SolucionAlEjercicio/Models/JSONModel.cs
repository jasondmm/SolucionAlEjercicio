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
        public class DatosJSON
        {
            public List<Base> oBase { get; set; }
            public List<string> oCypher { get; set; }
            public List<List<Values>> oValues { get; set; }
            public List<string> oWords { get; set; }
        }
    }
}