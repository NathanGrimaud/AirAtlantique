using AirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AirAtlantique
{
    class LiaisonBDD
    {
        #region
        //Formations

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
                                                   select item).ToList();
                return ListeFormations;
            }
        }

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

        #endregion

        #region
        //Métiers
        public static List<Metier> ListerMétier()
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Metier> ListeMetiers = (from item in db.metiers
                                             select item).ToList();
                return ListeMetiers;
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

        public static void SupprimerMétier(string nom)
        {
            using (var db = new AirAtlantiqueContext())
            {
                db.metiers.Remove(new Metier()
                {
                    nom = nom,
                });
                db.SaveChanges();
            }
        }
        #endregion

        #region
        //Employés
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


        //public static Formation SelectFormationEmploye(Employe employeSelectionne)
        //{
        //    using (var db = new AirAtlantiqueContext())
        //    {
        //        Formation formationEmploye = (from e in db.employes
        //                                      where e.nom == employeSelectionne.nom
        //                                      where e.prenom == employeSelectionne.prenom
        //                                      from se in e.sessions
        //                                      join s in db.sessions on se.id equals s.id
        //                                      join f in db.formations on s.id equals f.id
        //                                      select f).First();
        //        return formationEmploye;
        //    }
        //}


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
                return returnFormation;
            }
        }

        //public string List<string> InfosEmployés(string nomEmployé, string email, string metier, string formations, DateTime debutSession, DateTime finSession, DateTime demande, string commentaire, string status)
        //{
        //    List<Metier> metierEmploye = ListerMétier();
        //    List<Employe> employe = ListerEmployé();
        //    List<string> infosEmploye = new List<string>();
        //    string[] nomEtprenom = nomEmployé.Split(' ');
        //    string nom = nomEtprenom[0];
        //    string prenom = nomEtprenom[1];

        //    foreach (var item in employe)
        //    {
        //        if (item.nom == nom && item.prenom == prenom)
        //        {
        //            infosEmploye.Add(SelectMetierEmploye(item).nom);
        //            infosEmploye.Add(SelectFormationEmploye(item).nom);
        //        }
        //    }
        //    //using (var db = new AirAtlantiqueContext())
        //    //{

        //    //    List<string> EmployeDetails = new List<string>();
        //    //    string[] nomEtprenom = nomEmployé.Split(' ');
        //    //    string nom = nomEtprenom[0];
        //    //    string prenom = nomEtprenom[1];
        //    //    var DetailsEmploye = (from e in db.employes
        //    //                          join d in db.demandes on e.id equals d.id
        //    //                          from me in e.metier
        //    //                          join m in db.metiers on me.id equals m.id
        //    //                          from fm in m.formations
        //    //                          join f in db.formations on fm.id equals f.id
        //    //                          join s in db.sessions on f.id equals s.id
        //    //                          where e.nom == nom
        //    //                          where e.prenom == prenom
        //    //                          select new
        //    //                          {
        //    //                              nomEmploye = e.nom,
        //    //                              prenomEmploye = e.prenom,
        //    //                              mailEmploye = e.email,
        //    //                              MetierEmploye = m.nom,
        //    //                              FormationsEmploye = f.nom,
        //    //                              demandesEmploye = d.dateDemande,
        //    //                              CommentaireEmploye = d.commentaire,
        //    //                              statusDemande = d.status,
        //    //                              debutSession = s.dateDebut,
        //    //                              finSession = s.dateFin
        //    //                          }).First();

        //    //}
        //}
        #endregion

        #region
        //Sessions

        public static void AjouterSession(string nomSession, DateTime date_debut, DateTime date_fin, string formationConcernee, List<string> employeConcerne)
        {
            using (var db = new AirAtlantiqueContext())
            {
                List<Employe> employé = new List<Employe>();
                foreach (var nomEmployé in employeConcerne)
                {
                    string[] nomEtprenom = nomEmployé.Split(' ');
                    string nom = nomEtprenom[0];
                    string prenom = nomEtprenom[1];

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
        #endregion


    }
}
