using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirAtlantique.Pages.Employé
{
    /// <summary>
    /// Logique d'interaction pour employes.xaml
    /// </summary>
    public partial class HomeEmployés : UserControl
    {
        public HomeEmployés()
        {
            InitializeComponent();
            ((MainWindow)System.Windows.Application.Current.MainWindow).page_name.Text = "Employés";
        }

        private void ajouterEmployé_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new AjouterEmployé());
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new Home.Home());
        }

        private void ajouterEmployé_Copy_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new GérerEmployé());
        }
    }
}

