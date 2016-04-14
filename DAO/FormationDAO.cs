using System;
using System.Collections.Generic;
using System.Linq;
using AirAtlantique.Model;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.DAO
{
    class FormationDAO
    {
        public static void AjouterFormation(string nom, int duree, DateTime dureeValide, bool estGlobale, bool estActive, List<string> métierChoisis)
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Metier> métier = new List<Metier>();
                foreach (var nomMétier in métierChoisis)
                {
                    IQueryable<Metier> metier = from métierItem in db.metiers
                                                where métierItem.nom == nomMétier
                                                select métierItem;
                    Metier metierRecherché = metier.First();
                    métier.Add(metierRecherché);
                }

                db.formations.Add(new Formation()
                {
                    nom = nom,
                    duree = duree,
                    dureeValide = dureeValide,
                    estGlobale = estGlobale,
                    estActive = estActive,
                    metiers = métier
                });
                db.SaveChanges();
            }
        }

        public static List<Formation> ListerFormations()
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Formation> ListeFormations = (from item in db.formations
                                                   where item.estActive == true
                                                   select item).ToList();
                return ListeFormations;
            }
        }

        public static List<Formation> SelectFormationEmploye(Employe employeSelectionne)
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Formation> returnFormation = new List<Formation>();
                List<Session> sessionEmploye = (from e in db.employes
                                                where e.nom == employeSelectionne.nom
                                                where e.prenom == employeSelectionne.prenom
                                                select e.sessions).ToList().First().ToList();

                foreach (var item in sessionEmploye)
                {
                    returnFormation.Add(item.formation);
                }

                    //Ne pas envoyer 2 fois la même formation
                    //foreach (var item in sessionEmploye)
                    //{
                    //    if (returnFormation.Count() == 0)
                    //    {
                    //        returnFormation.Add(item.formation);
                    //    }

                    //    else if (returnFormation.Count() != 0)
                    //    {
                    //        foreach (var nomF in returnFormation)
                    //        {
                    //            if (item.nom != nomF.nom)
                    //            {
                    //                returnFormation.Add(item.formation);
                    //            }
                    //        }
                    //    }
                    //}
                    return returnFormation;
            }
        }
    }


}
