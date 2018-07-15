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
        public class JSONData
        {
            public List<Base> oBase { get; set; }
            public List<string> oCypher { get; set; }
            public List<List<Values>> oValues { get; set; }
            public List<string> oWords { get; set; }
        }
        public class Puzzle
        {
            public List<string> Words { get; set; }
            public List<string> Lines { get; set; }
        }
        public class Location
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public string NextPosition { get; set; }

            public Location(int Row, int Col, string NextPosition)
            {
                this.Row = Row;
                this.Col = Col;
                this.NextPosition = NextPosition;
            }
        }
    }
}