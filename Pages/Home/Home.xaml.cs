using AirAtlantique.Pages.Component;
using System;
using System.Collections.Generic;
using AirAtlantique.Model;
using AirAtlantique.Services;

namespace AirAtlantique.Pages.Home
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home 
    {
        Employe employe;
        public Home(Employe emp)
        {
            InitializeComponent();
            this.employe = emp;
            if (AdService.isRH(this.employe))
            {
                ajoutFormation.IsEnabled = true;
            }
        }

        private void ajoutFormation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new Formation.ajouterFormation(employe));
        }

        private void employes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           Switcher.Navigate(new Employé.HomeEmployés());
           // Switcher.Navigate(new Employé.HomeEmployés(employe));
        }

        private void ajoutSession_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new Session.AjouterSession());
            //Swicher.Navigate(new Session.AjouterSession(employe));
        }

        private void metiers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new Métier.AjouterMetier());
            //Switcher.Navigate(new Métier.AjouterMetier(employe));
        }
    }
}
