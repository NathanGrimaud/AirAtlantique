using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCBN
{
    class Session
    {
        public int Id { get; set; }
        public List<Employe> Employees { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public Formateur Formateur { get; set; }

    }
}
