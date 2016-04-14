using System.Windows;
using AirAtlantique.Pages.Login;
using AirAtlantique.Pages;

namespace AirAtlantique
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.init(this.ContentArea,this.SideMenu);
            ContentArea.Content = new Login();
        }
    }
}
