﻿using AirAtlantique.Pages.Component;
using System;
using System.Collections.Generic;

namespace AirAtlantique.Pages.Home
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home 
    {

        public Home()
        {
            InitializeComponent();
        }

        private void ajoutFormation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new Formation.ajouterFormation());
        }

        private void employes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new Employé.HomeEmployés());
        }

        private void ajoutSession_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new Session.AjouterSession());
        }

        private void metiers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new Métier.AjouterMetier());
        }
    }
}
