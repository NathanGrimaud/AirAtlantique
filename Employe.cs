using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCBN
{
    class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string MotDePasse { get; set; }
        public string Identifiant { get; set; }
        public string Email { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Demande> Demandes { get; set; }
        public Employe()
        {
                
        }
    }
}
