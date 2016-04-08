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

namespace AirAtlantique.Pages
{
    /// <summary>
    /// Logique d'interaction pour employes.xaml
    /// </summary>
    public partial class HomeEmployés : UserControl
    {
        public HomeEmployés()
        {
            InitializeComponent();
        }

        private void ajouterEmployé_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new AjouterEmployé());
        }

        private void metiers_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Navigate(new AjouterMetier());
        }

    }
}

