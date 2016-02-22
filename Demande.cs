using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCBN
{
    class Demande
    {
        public int Id { get; set; }
        public DateTime DateDemande { get; set; }
        public string Commentaire { get; set; }
        public Employe Emplote { get; set; }
        public Status Status { get; set; }
        public Formation Formation { get; set; }
    }
}
