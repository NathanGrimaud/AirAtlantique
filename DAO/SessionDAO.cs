using AirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AirAtlantique.DAO
{
    class SessionDAO
    {
        public static void AjouterSession(string nomSession, DateTime date_debut, DateTime date_fin, string formationConcernee, List<string> employeConcerne)
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Employe> employé = new List<Employe>();
                foreach (var nomEmployé in employeConcerne)
                {
                    string[] nomPrenom = nomEmployé.Split(' ');
                    string prenom = nomPrenom[0];
                    string nom = nomPrenom[1];

                    Employe employés = (from e in db.employes
                                        where e.nom == nom
                                        where e.prenom == prenom
                                        select e).First();
                    employé.Add(employés);
                }

                db.sessions.Add(new Session()
                {
                    nom = nomSession,
                    dateDebut = date_debut,
                    dateFin = date_fin,
                    formation = (from f in db.formations where f.nom == formationConcernee select f).First(),
                    employes = employé
                });
                db.SaveChanges();
            }
        }

        public static List<Session> ListerSession(Employe employeSelectionne, string formation)
        {
            using (var db = new AirAtlantiqueContext())
            {

                List<Session> lesSessions = (from f in db.formations
                                             where f.nom == formation
                                             join s in db.sessions on f.id equals s.formation.id
                                             from se in s.employes
                                             join e in db.employes on se.id equals e.id
                                             where e.nom == employeSelectionne.nom
                                             where e.prenom == employeSelectionne.prenom
                                             select s).ToList();
                return lesSessions;
            }
        }

        public static List<Session> ListerAllSession()
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Session> lesSessions = (from s in db.sessions
                                             select s).ToList();
                return lesSessions;
            }
        }

        public static Session SelectUniqueSession(string nomSession)
        {
            using (var db = new AirAtlantiqueContext())
            {
                Session session = (from s in db.sessions
                                   where s.nom == nomSession
                                   select s).First();
                return session;
            }
        }

        //public static void EditerSession(Session session, string nom, string prenom, string mail, Metier metier)
        //{
        //    using (var db = new AirAtlantiqueContext())
        //    {
        //        var employeToChange = db.employes.Find(employes.id);
        //        Metier metierToChange = db.metiers.Find(metier.ID);
        //        if (employeToChange != null)
        //        {
        //            employeToChange.Nom = nom;
        //            employeToChange.Prenom = prenom;
        //            employeToChange.mail = mail;
        //            employeToChange.Metier = metierToChange;
        //            db.SaveChanges();
        //        }
        //    }
        //}

        public static void SupprimerSession(Session sessionDelete)
        {
            using (var db = new AirAtlantiqueContext())
            {
                db.sessions.Remove(db.sessions.Find(sessionDelete.id));
                db.SaveChanges();
            }
        }

        public static Session SelectSession(string sessionSelectionne)
        {
            using (var db = new AirAtlantiqueContext())
            {
                Session session = (from s in db.sessions
                                   where sessionSelectionne == s.nom
                                   select s).First();
                return session;
            }
        }

    }
}
