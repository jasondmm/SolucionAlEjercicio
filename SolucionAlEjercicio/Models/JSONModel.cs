using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        [DataContract]
        public class Location
        {
            [DataMember]
            public int row { get; set; }
            [DataMember]
            public int column { get; set; }
            [DataMember]
            public char character { get; set; }
            public string NextPosition { get; set; }

            public Location(int row, int column, char character, string NextPosition)
            {
                this.row = row;
                this.column = column;
                this.character = character;
                this.NextPosition = NextPosition;
            }
            
        }
    }
}