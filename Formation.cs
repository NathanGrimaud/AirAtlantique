using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCBN
{
    class Formation
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime Duree { get; set; }
        public DateTime DureeValidite { get; set; }
        public List<Demande> Demandes { get; set; }
        public List<Session> Sessions { get; set; }
        public bool EstGlobale { get; set; }
        public bool EstActive { get; set; }
        public Formation()
        {

        }
    }
}
