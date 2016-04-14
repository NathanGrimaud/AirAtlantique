using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AirAtlantique.DAO;
using System.Windows.Input;

namespace AirAtlantique.Pages.Métier
{
    /// <summary>
    /// Logique d'interaction pour AjouterMetier.xaml
    /// </summary>
    public partial class AjouterMetier : UserControl
    {
        public AjouterMetier()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Gestion des métiers";
            ShowData();

        }
        private void ShowData()
        {
            foreach (var metier in MetierDAO.ListerMétier())
            {
                listeMetiers.Items.Add(metier.nom);
            }
        }

        private void RefreshData()
        {
            if (listeMetiers.HasItems)
            {
                listeMetiers.Items.Clear();
                supprimer.Visibility = Visibility.Hidden;
            }
            ShowData();
            alertEmpty.Text = String.Empty;
            alertExist.Text = String.Empty;
            BT_maj.Visibility = Visibility.Hidden;
            TB_ajoutMetier.Clear();
        }

        private void ajoutMetier_Click(object sender, RoutedEventArgs e)
        {
            if (TB_ajoutMetier.Text != "")
            {
                MetierDAO.AjouterMétier(TB_ajoutMetier.Text);
                TB_ajoutMetier.Clear();
                listeMetiers.Items.Clear();
                ShowData();
            }
            else
            {
                alertEmpty.Text = "Veuillez entrer un métier valide!";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home.Home());
        }

        private void supprimer_Click(object sender, RoutedEventArgs e)
        {
            var item = listeMetiers.SelectedItem.ToString();
            MetierDAO.SupprimerMétier(item);
            RefreshData();
        }

        private void listeMetiers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            supprimer.Visibility = Visibility.Visible;
            BT_maj.Visibility = Visibility.Visible;
            if (listeMetiers.HasItems)
            {
                TB_ajoutMetier.Text = listeMetiers.SelectedItem.ToString();
            }
        }

        private void BT_maj_Click(object sender, RoutedEventArgs e)
        {
            Model.Metier metierAMaj = MetierDAO.SelectMetier(listeMetiers.SelectedItem.ToString());
            metierAMaj.nom = TB_ajoutMetier.Text;
            MetierDAO.EditerMétier(metierAMaj);
            TB_ajoutMetier.Focus();
            RefreshData();
        }
    }
}
