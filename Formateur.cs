using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCBN
{
    class Formateur
    {
        public int Id { get; set; }
        public FormateurExterne FormateurExterne { get; set; }
        public Employe FormateurInterne { get; set; }
    }
}
