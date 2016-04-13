using AirAtlantique.Pages.Component;
using System;
using System.Collections.Generic;

namespace AirAtlantique.Pages
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home 
    {
        public Home(Dictionary<String, Object> parameters) : base()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Accueil";
            Switcher.changeMenu(new SideMenu());
            foreach (var item in parameters)
            {
                @params.Text += $"key : {item.Key}  value :  {item.Value} ";
            }

        }

        public Home()
        {
            InitializeComponent();
        }

        private void ajoutFormation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new ajouterFormation());
        }

        private void employes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new HomeEmployés());
        }

        private void ajoutSession_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new AjouterSession());
        }

        private void metiers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Switcher.Navigate(new AjouterMetier());
        }
    }
}
