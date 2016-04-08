using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique
{
    class LiaisonBDD
    {
        public static void AddFormation(string nom, int duree, DateTime dureeValide, bool estGlobale, bool estActive, ICollection<Model.Metier> metierRequis)
        {
            using (var db = new AirAtlantiqueContext())
            {
                db.formations.Add(new Model.Formation()
                {
                    nom = nom,
                    duree = duree,
                    dureeValide = dureeValide,
                    estGlobale = estGlobale,
                    estActive = estActive,
                    metiers = metierRequis
                });
                db.SaveChanges();
            }
        }

        public static void AddEmploye(string nom, string prenom, string password, string login, string email)
        {
            using (var db = new AirAtlantiqueContext())
            {
                db.employes.Add(new Model.Employe()
                {
                    nom = nom,
                    prenom = prenom,
                    password = password,
                    login = login,
                    email = email
                });
                db.SaveChanges();
            }

        }

        public static List<Model.Metier> ListeMetiers()
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Model.Metier> ListeMetiers = (from item in db.metiers
                                                   select item).ToList();
                return ListeMetiers;
            }
        }

        public static List<Model.Employe> ListeEmployes()
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Model.Employe> ListeEmployes = (from item in db.employes
                                                     select item).ToList();
                return ListeEmployes;
            }
        }



    }
}
