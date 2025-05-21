using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFvarosok
{
    internal class Varos
    {
        public string Sorszam { get; set; }
        public string Varosnev { get; set; }
        public string Jaras { get; set; }
        public string Kisterseg { get; set; }
        public string Nepesseg { get; set; }
        public string Terulet { get; set; }

        public Varos(string sorszam, string varosnev, string jaras, string kisterseg, string nepesseg, string terulet)
        {
            Sorszam = sorszam;
            Varosnev = varosnev;
            Jaras = jaras;
            Kisterseg = kisterseg;
            Nepesseg = nepesseg;
            Terulet = terulet;
        }
    }
}
