using AirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AirAtlantique.DAO
{
    class EmployéDAO
    {
        public static List<Employe> MétierEmployéFormation(string formation)
        {
            using (var db = new AirAtlantiqueContext())
            {
                //récupère les métiers d'un employé en fonction de la formation
                List<Employe> ListeEmployeWithFormations = new List<Employe>();
                ListeEmployeWithFormations = (from e in db.employes
                                              from me in e.metier
                                              join m in db.metiers on me.id equals m.id
                                              from fm in m.formations
                                              join f in db.formations on fm.id equals f.id
                                              where f.nom == formation
                                              select e).ToList();
                return ListeEmployeWithFormations;
            }
        }

        public static void AjouterEmployé(string nom, string prenom, string password, string login, string email, List<string> métierChoisis)
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
                db.employes.Add(new Employe()
                {
                    nom = nom,
                    prenom = prenom,
                    password = password,
                    login = login,
                    email = email,
                    metier = métier
                });
                db.SaveChanges();
            }
        }

        public static List<Employe> ListerEmployé()
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Employe> ListeEmployes = (from item in db.employes
                                               select item).ToList();
                return ListeEmployes;
            }
        }

        public static Employe SelectUniqueEmployé(string nomEmploye)
        {
            using (var db = new AirAtlantiqueContext())
            {
                string[] nomEtprenom = nomEmploye.Split(' ');
                string nom = nomEtprenom[1];
                string prenom = nomEtprenom[0];

                Employe employe = (from e in db.employes
                                   where nom == e.nom
                                   where prenom == e.prenom
                                   select e).First();
                return employe;
            }
        }

        public static void EditerEmployé(Employe employeSelectionne)
        {
            using (var db = new AirAtlantiqueContext())
            {
                var original = db.employes.Find(employeSelectionne.id);
                if (original != null)
                {
                    original.nom = employeSelectionne.nom;
                    original.prenom = employeSelectionne.prenom;
                    original.login = employeSelectionne.login;
                    original.password = employeSelectionne.password;
                    original.email = employeSelectionne.email;
                    //original.metier = employeSelectionne.metier;

                    db.SaveChanges();
                }
            }
        }

        public static void SupprimerEmployé(Employe employeSelectionne)
        {
            using (var db = new AirAtlantiqueContext())
            {
                db.employes.Remove(db.employes.Find(employeSelectionne.id));
                db.SaveChanges();
            }
        }
    }
}
