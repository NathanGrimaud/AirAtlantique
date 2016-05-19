using AirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace AirAtlantique.DAO
{
    class MetierDAO
    {
        public static List<Metier> ListerMétier()
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Metier> ListeMetiers = (from item in db.metiers
                                             select item).ToList();
                return ListeMetiers;
            }
        }

        public static Metier SelectMetier(string nomMetier)
        {
            using (var db = new AirAtlantiqueContext())
            {
                Metier metier = (from m in db.metiers
                                 where nomMetier == m.nom
                                 select m).First();
                return metier;
            }
        }

        public static void AjouterMétier(string nom)
        {
            using (var db = new AirAtlantiqueContext())
            {
                db.metiers.Add(new Metier()
                {
                    nom = nom,
                });
                db.SaveChanges();
            }
        }

        public static void EditerMétier(Metier metier)
        {
            using (var db = new AirAtlantiqueContext())
            {
                var original = db.metiers.Find(metier.id);
                if (original != null)
                {
                    if (original.nom != metier.nom)
                    {
                        original.nom = metier.nom;
                        db.SaveChanges();
                    }
                }
            }
        }

        public static void SupprimerMétier(Model.Metier métier)
        {
            using (var db = new AirAtlantiqueContext())
            {
                db.metiers.Remove(db.metiers.Find(métier.id));
                db.SaveChanges();
            }
        }

        public static Metier SelectMetierEmploye(Employe employeSelectionne)
        {
            using (var db = new AirAtlantiqueContext())
            {
                Metier metierEmploye = (from e in db.employes
                                        where e.nom == employeSelectionne.nom
                                        where e.prenom == employeSelectionne.prenom
                                        from me in e.metier
                                        join m in db.metiers on me.id equals m.id
                                        select m).First();
                return metierEmploye;
            }
        }
    }
}
