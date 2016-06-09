﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AirAtlantique.DAO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirAtlantique.Pages.Session
{
    /// <summary>
    /// Logique d'interaction pour AjouterSession.xaml
    /// </summary>
    public partial class AjouterSession : UserControl
    {
        public AjouterSession()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Ajouter une session";
            ShowData();
            ShowSession();
        }

        //On affiche les formations disponibles
        private void ShowData()
        {
            foreach (var formations in FormationDAO.ListerFormations())
            {
                CB_listeFormations.Items.Add(formations.nom);
            }
        }

        private void RefreshData()
        {
            TB_NomSession.Clear();
            LB_session.Items.Clear();
            DP_date_debut.SelectedDate = null;
            DP_date_fin.SelectedDate = null;
            LB_employés.SelectedItems.Clear();
            TB_NomSession.Focus();
        }

        private void listeFormations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LB_employés.Items.Clear();
            if (CB_listeFormations != null)
            {
                SelectEmploye(CB_listeFormations.SelectedItem.ToString());
            }

        }

        private void SelectEmploye(string formation)
        {
            foreach (var employes in EmployéDAO.MétierEmployéFormation(formation))
            {
                LB_employés.Items.Add(employes.prenom + " " + employes.nom);
            }
        }


        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Session.AjouterSession());
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {

            List<string> employé = new List<string>();
            foreach (var item in LB_employés.SelectedItems)
            {
                employé.Add(item.ToString());
            }

            if (LB_employés.SelectedItem == null)
            {
                TB_Alert.Text = "Veuillez renseigner tout les champs";
                TB_Alert.Visibility = Visibility.Visible;
            }
            else
            {

                SessionDAO.AjouterSession(TB_NomSession.Text, DP_date_debut.SelectedDate.Value, DP_date_fin.SelectedDate.Value, CB_listeFormations.Text, employé);

                TB_Alert.Visibility = Visibility.Hidden;
                TB_NomSession.Clear();
                DP_date_debut.SelectedDate = null;
                DP_date_fin.SelectedDate = null;
                LB_employés.Items.Clear();

                RefreshData();
                ShowSession();
            }
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home.Home());
        }

        private void ShowSession()
        {
            List<Model.Session> sessions = SessionDAO.ListerAllSession();
            foreach (var item in sessions)
            {
                LB_session.Items.Add(item.nom);
            }
        }

        private void LB_session_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_session.HasItems)
            {
                BT_MAJ.Visibility = Visibility.Visible;
                BT_SUPPR.Visibility = Visibility.Visible;
                Model.Session session = SessionDAO.SelectSession(LB_session.SelectedItem.ToString());
                TB_NomSession.Text = session.nom;
                DP_date_debut.SelectedDate = session.dateDebut;
                DP_date_fin.SelectedDate = session.dateFin;

                List<Model.Formation> formationClick = FormationDAO.ListerFormations();
                foreach (var item in formationClick)
                {
                    CB_listeFormations.Items.Add(item.nom);
                }
                Model.Formation formationSession = FormationDAO.SelectFormationSession(session);
                CB_listeFormations.SelectedItem = formationSession.nom;
            }
        }



        private void BT_MAJ_Click(object sender, RoutedEventArgs e)
        {
            Model.Session maSession = SessionDAO.SelectSession(LB_session.SelectedItem.ToString());
            string formation = CB_listeFormations.Text;

            List<string> employé = new List<string>();
            foreach (var item in LB_employés.SelectedItems)
            {
                employé.Add(item.ToString());
            }


            maSession.nom = TB_NomSession.Text;
            maSession.dateDebut = DP_date_debut.DisplayDate;
            maSession.dateDebut = DP_date_fin.DisplayDate;
            
            SessionDAO.EditerSession(maSession, formation, employé);
            TB_NomSession.Clear();
            DP_date_debut.SelectedDate = null;
            DP_date_fin.SelectedDate = null;
            LB_employés.Items.Clear();

            RefreshData();
            ShowSession();
        }

        private void BT_SUPPR_Click(object sender, RoutedEventArgs e)
        {
            Model.Session sessionClick = SessionDAO.SelectUniqueSession(LB_session.SelectedItem.ToString());
            SessionDAO.SupprimerSession(sessionClick);
            BT_MAJ.Visibility = Visibility.Hidden;
            BT_SUPPR.Visibility = Visibility.Hidden;
            BT_ajouter.Visibility = Visibility.Visible;
            BT_annuler.Visibility = Visibility.Hidden;
            RefreshData();
            ShowSession();
        }
    }
}
