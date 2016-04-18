﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AirAtlantique.DAO;
using System.Windows.Input;
using System.Linq;
using System.Collections;

namespace AirAtlantique.Pages.Employé
{
    /// <summary>
    /// Logique d'interaction pour GérerEmployé.xaml
    /// </summary>
    public partial class GérerEmployé : UserControl
    {
        public GérerEmployé()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Gestion des employés";
            RefreshEmployes();
        }

        private void RefreshEmployes()
        {
            LB_liste_employé.Items.Refresh();
            foreach (var employé in EmployéDAO.ListerEmployé())
            {
                LB_liste_employé.Items.Add(employé.prenom + " " + employé.nom);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new HomeEmployés());
        }

        private void ClearSessionItems()
        {
            LB_Sessions.Items.Clear();
            LB_Sessions_DateDebut.Items.Clear();
            LB_Sessions_DateFin.Items.Clear();
        }

        private void ClearEmployeItems()
        {
            TB_Nom.Clear();
            TB_Prénom.Clear();
            LB_liste_employé.Items.Clear();
            LB_metiers_Employe.Items.Clear();
            LB_Formations.Items.Clear();
        }

        private void supprimerEmployé_Click(object sender, RoutedEventArgs e)
        {
            Model.Employe clicEmploye = EmployéDAO.SelectUniqueEmployé(LB_liste_employé.SelectedItem.ToString());

            EmployéDAO.SupprimerEmployé(clicEmploye);
            ClearEmployeItems();
        }

        public void editerEmployé_Click(object sender, RoutedEventArgs e)
        {
            validerMaj.Visibility = Visibility.Visible;
            annulerMaj.Visibility = Visibility.Visible;
            TB_Nom.IsEnabled = true;
            TB_Prénom.IsEnabled = true;
            LB_metiers_Employe.IsEnabled = true;
            MetiersDispo.Visibility = Visibility.Visible;
            SelectMetierDispo();
        }

        private void SelectMetierDispo()
        {
            //On ajoute les métiers disponibles pour l'employé
            foreach (var metier in MetierDAO.ListerMétier())
            {
                foreach (var item in LB_metiers_Employe.Items)
                {
                    if (item.ToString() != metier.nom)
                    {
                        LB_MétiersDispo.Items.Add(metier.nom);
                    }
                }
            }
        }

        public void ajoutMetier_Click(object sender, RoutedEventArgs e)
        {
            LB_metiers_Employe.Items.Add(LB_MétiersDispo.SelectedItem.ToString());
            LB_MétiersDispo.Items.Clear();

        }
        private void annulerMaj_Click(object sender, RoutedEventArgs e)
        {
            validerMaj.Visibility = Visibility.Hidden;
            annulerMaj.Visibility = Visibility.Hidden;
        }

        public void validerMaj_Click(object sender, RoutedEventArgs e)
        {
            Model.Employe EmployeSelectionne = EmployéDAO.SelectUniqueEmployé(LB_liste_employé.SelectedItem.ToString());
            EmployeSelectionne.nom = TB_Nom.Text;
            EmployeSelectionne.prenom = TB_Prénom.Text;
            EmployeSelectionne.email = TB_Prénom.Text.ToLower() + "." + TB_Nom.Text.ToLower() + "@airatlantique.com";
            EmployeSelectionne.login = TB_Prénom.Text.ToLower() + "." + TB_Nom.Text.ToLower();
            EmployeSelectionne.password = TB_Prénom.Text.ToLower() + "." + TB_Nom.Text.ToLower();
            

            EmployéDAO.EditerEmployé(EmployeSelectionne);
            validerMaj.Visibility = Visibility.Hidden;
            annulerMaj.Visibility = Visibility.Hidden;
            ClearEmployeItems();
            RefreshEmployes();
        }

        private void LB_liste_employé_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LB_metiers_Employe.Items.Clear();
            LB_Formations.Items.Clear();
            supprimerEmployé.Visibility = Visibility.Visible;
            editerEmployé.Visibility = Visibility.Visible;
            LB_metiers_Employe.IsEnabled = false;

            if (LB_liste_employé.HasItems)
            {
                Model.Employe clicEmploye = EmployéDAO.SelectUniqueEmployé(LB_liste_employé.SelectedItem.ToString());
                TB_Nom.Text = clicEmploye.nom;
                TB_Prénom.Text = clicEmploye.prenom;


                Model.Metier metiers = MetierDAO.SelectMetierEmploye(clicEmploye);
                LB_metiers_Employe.Items.Add(metiers.nom);

                List<Model.Formation> formations = FormationDAO.SelectFormationEmploye(clicEmploye);
                if (formations.Count == 0)
                {
                    LB_Formations.Items.Add("Aucune formation !");
                }
                foreach (var item in formations)
                {
                    LB_Formations.Items.Add(item.nom);
                }
            }
        }

        private void LB_Formations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_Formations.HasItems)
            {
                ClearSessionItems();
                session.Visibility = Visibility.Visible;
                editerEmployé.Visibility = Visibility.Visible;
                supprimerEmployé.Visibility = Visibility.Visible;
                List<Model.Session> sessionsEmploye = SessionDAO.ListerSession(EmployéDAO.SelectUniqueEmployé(LB_liste_employé.SelectedItem.ToString()), LB_Formations.SelectedItem.ToString());
                foreach (var item in sessionsEmploye)
                {
                    LB_Sessions.Items.Add(item.nom);
                    LB_Sessions_DateDebut.Items.Add(item.dateDebut);
                    LB_Sessions_DateFin.Items.Add(item.dateFin);
                }
            }
        }

        private void LB_metiers_Employe_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            //Une fois un métier ajouté, on recharge la listbox des métiers disponibles
            SelectMetierDispo();
        }
    }
}
